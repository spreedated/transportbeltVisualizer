using BelttransportVisualizerWpf.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using TransportbeltRender;
using TransportbeltRender.Models;

namespace BelttransportVisualizerWpf.ViewModels
{
    internal partial class MainWindowViewModel : ObservableObject
    {
        private readonly Assembly assembly;

        [ObservableProperty]
        private Window instance;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
        private TransportImage transportImage;

        [ObservableProperty]
        private TransportImageProperties properties;

        [ObservableProperty]
        private TransportImageRenderElements elements;

        [ObservableProperty]
        private string title;

        public Color ImageBackgroundColor
        {
            get
            {
                return this.Properties.BackgroundColor.ToWpfColor();
            }

            set
            {
                this.Properties.BackgroundColor = value.ToImageSharpColor();
                base.OnPropertyChanged(nameof(this.ImageBackgroundColor));
            }
        }

        public Color ImageScannerColor
        {
            get
            {
                return this.Properties.ScannerColor.ToWpfColor();
            }

            set
            {
                this.Properties.ScannerColor = value.ToImageSharpColor();
                base.OnPropertyChanged(nameof(this.ImageScannerColor));
            }
        }

        public Color ImageCrateColor
        {
            get
            {
                return this.Properties.CrateColor.ToWpfColor();
            }

            set
            {
                this.Properties.CrateColor = value.ToImageSharpColor();
                base.OnPropertyChanged(nameof(this.ImageCrateColor));
            }
        }

        public Color ImagePalletColor
        {
            get
            {
                return this.Properties.PalletColor.ToWpfColor();
            }

            set
            {
                this.Properties.PalletColor = value.ToImageSharpColor();
                base.OnPropertyChanged(nameof(this.ImagePalletColor));
            }
        }

        [ObservableProperty]
        private ImageSource renderedImage;

        [ObservableProperty]
        private float renderBoxWidth;

        [ObservableProperty]
        private float renderBoxHeight;

        [ObservableProperty]
        private ObservableCollection<int> cratesOnSegments;

        [ObservableProperty]
        private int selectedCrateOnSegment;

        [ObservableProperty]
        private int selectedCrateToAddOnSegment;

        [ObservableProperty]
        private ObservableCollection<string> cratesOnPallets;

        [ObservableProperty]
        private string selectedCrateOnPallet;

        [ObservableProperty]
        private int selectedPositionToAddPallet;

        [ObservableProperty]
        private int selectedCrateToAddPallet;

        #region Constructor
        public MainWindowViewModel()
        {
            this.assembly = typeof(MainWindowViewModel).Assembly;

            this.Title = $"{this.assembly.GetCustomAttribute<AssemblyTitleAttribute>().Title} v{this.assembly.GetName().Version}";

            this.Elements = new()
            {
                TransportBandSegments = 10,
                ScannerPosition = 4
            };

            this.Properties = new();

            this.LoadDefaultValues();
        }
        #endregion

        [RelayCommand(CanExecute = nameof(CanExecuteSave))]
        private async Task Save()
        {
            SaveFileDialog sfd = new()
            {
                Filter = "PNG Image|*.png",
                Title = "Save Image",
                FileName = $"TransportImage_{DateTime.Now:yyyyMMddHHmmss}.png",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };

            bool? result = sfd.ShowDialog();

            if (result != null && (bool)result)
            {
                //this.Instance.Dispatcher.Invoke(() => caller.IsEnabled = false);
                await this.TransportImage.SaveToFile(sfd.FileName);
                //this.Instance.Dispatcher.Invoke(() => caller.IsEnabled = true);
            }
        }

        private bool CanExecuteSave()
        {
            return this.TransportImage != null;
        }

        [RelayCommand]
        private async Task Render()
        {
            //caller.IsEnabled = false;

            this.Elements.CrateOnSegments = [.. this.CratesOnSegments];
            this.Elements.CratesOnPallets = new(this.CratesOnPallets.Select(x => new System.Collections.Generic.KeyValuePair<int, int>(int.Parse(x.Split(',')[0]), int.Parse(x.Split(',')[1]))));

            this.TransportImage = new((int)((MainWindow)this.Instance).UiRenderImageGrid.ActualWidth, (int)((MainWindow)this.Instance).UiRenderImageGrid.ActualHeight, this.Properties, this.Elements);

            await this.TransportImage.Render();
            this.RenderedImage = await this.TransportImage.SaveAsWpfImage();

            //caller.Enabled = true;
            //this.BtnSaveImage.Enabled = true;
        }

        public void LoadDefaultValues()
        {
            this.CratesOnSegments = [0, 4, 5, 8];
            this.CratesOnPallets = ["1,7", "2,3", "6,2", "7,12", "9,2"];
        }

        [RelayCommand]
        private void AddCrate()
        {
            if (this.CratesOnSegments.Contains(this.SelectedCrateToAddOnSegment))
            {
                return;
            }
            this.CratesOnSegments.Add(this.SelectedCrateToAddOnSegment);
        }

        [RelayCommand]
        private void RemCrate()
        {
            this.CratesOnSegments.Remove(this.SelectedCrateOnSegment);
            this.SelectedCrateOnSegment = default;
        }

        [RelayCommand]
        private void AddPallet()
        {
            if (this.CratesOnPallets.Select(x => int.Parse(x.Split(',')[0])).Any(x => x == this.SelectedPositionToAddPallet))
            {
                return;
            }

            this.CratesOnPallets.Add($"{this.SelectedPositionToAddPallet},{this.SelectedCrateToAddPallet}");
        }

        [RelayCommand]
        private void RemPallet()
        {
            if (this.SelectedCrateOnPallet != default)
            {
                this.CratesOnPallets.Remove(this.SelectedCrateOnPallet);
            }
        }
    }
}
