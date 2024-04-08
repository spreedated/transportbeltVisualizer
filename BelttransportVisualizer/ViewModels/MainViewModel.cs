using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Logic;
using WinFormsApp1.Models;

namespace WinFormsApp1.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly Assembly assembly;

        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private Form instance;

        [ObservableProperty]
        private TransportImage transportImage;

        [ObservableProperty]
        private TransportImageProperties properties;

        [ObservableProperty]
        private TransportImageRenderElements elements;

        [ObservableProperty]
        private ListBox lsbCrates;

        [ObservableProperty]
        private ListBox lsbPallets;

        [ObservableProperty]
        private PictureBox pbxRenderImage;

        [ObservableProperty]
        private Button btnSaveImage;

        [ObservableProperty]
        private NumericUpDown nudCrate;

        [ObservableProperty]
        private NumericUpDown nudCrateCount;

        [ObservableProperty]
        private NumericUpDown nudPalletPosition;

        [ObservableProperty]
        private CheckBox chkDrawBackground;

        [ObservableProperty]
        private PictureBox pbxCrateColor;

        [ObservableProperty]
        private PictureBox pbxPalletColor;

        [ObservableProperty]
        private PictureBox pbxScannerColor;

        [ObservableProperty]
        private PictureBox pbxBackgroundColor;

        #region Constructor
        public MainViewModel()
        {
            this.assembly = typeof(MainViewModel).Assembly;

            this.Elements = new()
            {
                TransportBandSegments = 10,
                ScannerPosition = 4
            };

            this.Properties = new();
        }
        #endregion

        [RelayCommand(CanExecute = nameof(CanExecuteSave))]
        private void Save(Button caller)
        {
            SaveFileDialog sfd = new()
            {
                Filter = "PNG Image|*.png",
                Title = "Save Image",
                FileName = $"TransportImage_{DateTime.Now:yyyyMMddHHmmss}.png",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Task.Run(async () =>
                {
                    this.Instance.Invoke(() => caller.Enabled = false);
                    await this.TransportImage.SaveToFile(sfd.FileName);
                    this.Instance.Invoke(() => caller.Enabled = true);
                });
            }
        }

        private bool CanExecuteSave()
        {
            return this.TransportImage != null;
        }

        [RelayCommand]
        private void Render(Button caller)
        {
            caller.Enabled = false;

            this.Elements.CrateOnSegments = this.LsbCrates.Items.OfType<int>().ToArray();
            this.Elements.CratesOnPallets = new(this.LsbPallets.Items.OfType<string>().Select(x => new System.Collections.Generic.KeyValuePair<int, int>(int.Parse(x.Split(',')[0]), int.Parse(x.Split(',')[1]))));

            this.TransportImage = new(this.PbxRenderImage.Width, this.PbxRenderImage.Height, this.Properties, this.Elements);

            Task.Run(() =>
            {
                this.Instance.Invoke(async () =>
                {
                    this.PbxRenderImage.Image?.Dispose();
                    this.PbxRenderImage.Image = null;

                    await this.TransportImage.Render();
                    this.PbxRenderImage.Image = await this.TransportImage.SaveAsWinFormsImage();
                    caller.Enabled = true;
                    this.BtnSaveImage.Enabled = true;
                });
            });
        }

        [RelayCommand]
        private void AddCrate()
        {
            if (int.TryParse(this.NudCrate.Value.ToString(), out int position) && !this.LsbCrates.Items.Contains(position))
            {
                this.LsbCrates.Items.Add(position);
            }
        }

        [RelayCommand]
        private void RemCrate()
        {
            if (this.LsbCrates.SelectedIndex <= -1)
            {
                return;
            }

            this.LsbCrates.Items.RemoveAt(this.LsbCrates.SelectedIndex);
        }

        [RelayCommand]
        private void AddPallet()
        {
            int pPosition = (int)this.NudPalletPosition.Value;

            if (this.LsbPallets.Items.OfType<string>().Any(x => int.Parse(x.Split(',')[0]) == pPosition))
            {
                return;
            }

            this.LsbPallets.Items.Add($"{pPosition},{this.NudCrateCount.Value}");
        }

        [RelayCommand]
        private void RemPallet()
        {
            if (this.LsbPallets.SelectedIndex <= -1)
            {
                return;
            }

            this.LsbPallets.Items.RemoveAt(this.LsbPallets.SelectedIndex);
        }

        [RelayCommand]
        private void DrawBackgroundCheckedChanged()
        {
            this.Properties.DrawBackground = this.ChkDrawBackground.Checked;
        }

        public void LoadDefaultValues()
        {
            this.Title = $"{this.assembly.GetCustomAttribute<AssemblyTitleAttribute>().Title} v{this.assembly.GetName().Version}";

            this.LsbCrates.Items.AddRange(new object[] { 0, 4, 5, 8 });
            this.LsbPallets.Items.AddRange(new object[] { "1,7", "2,3", "6,2", "7,12", "9,2" });

            this.PbxCrateColor.BackColor = this.Properties.CrateColor.ToSystemDrawingColor();
            this.PbxPalletColor.BackColor = this.Properties.PalletColor.ToSystemDrawingColor();
            this.PbxScannerColor.BackColor = this.Properties.ScannerColor.ToSystemDrawingColor();
            this.PbxBackgroundColor.BackColor = this.Properties.BackgroundColor.ToSystemDrawingColor();
        }
    }
}
