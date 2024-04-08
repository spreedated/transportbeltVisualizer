using System;
using System.Windows.Forms;
using TransportbeltRender;
using WinFormsApp1.ViewModels;

namespace WinFormsApp1
{
    public partial class Main : Form
    {
        private readonly MainViewModel vm;

        public Main()
        {
            this.InitializeComponent();
            this.vm = new()
            {
                Instance = this,
                LsbCrates = this.LSB_Crates,
                LsbPallets = this.LSB_Pallets,
                PbxRenderImage = this.PBX_RenderImage,
                BtnSaveImage = this.BTN_SaveImage,
                NudCrate = this.NUD_Crate,
                NudCrateCount = this.NUD_CrateCount,
                NudPalletPosition = this.NUD_PalletPosition,
                ChkDrawBackground = this.CHK_DrawBackground,
                PbxCrateColor = this.PBX_CrateColor,
                PbxPalletColor = this.PBX_PalletColor,
                PbxScannerColor = this.PBX_ScannerColor,
                PbxBackgroundColor = this.PBX_BackgroundColor
            };
            this.vm.LoadDefaultValues();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.DataBindings.Add("Text", this.vm, "Title");

            this.NUD_BandSegments.DataBindings.Add("Value", this.vm.Elements, "TransportBandSegments", false, DataSourceUpdateMode.OnPropertyChanged);
            this.NUD_ScannerPosition.DataBindings.Add("Value", this.vm.Elements, "ScannerPosition", false, DataSourceUpdateMode.OnPropertyChanged);
            this.NUD_BandYLocation.DataBindings.Add("Value", this.vm.Properties, "BandYLocation", false, DataSourceUpdateMode.OnPropertyChanged);

            this.BTN_SaveImage.Command = this.vm.SaveCommand;
            this.BTN_SaveImage.CommandParameter = this.BTN_SaveImage;

            this.BTN_Render.Command = this.vm.RenderCommand;
            this.BTN_Render.CommandParameter = this.BTN_Render;

            this.BTN_AddCrate.Command = this.vm.AddCrateCommand;
            this.BTN_RemoveCrate.Command = this.vm.RemCrateCommand;

            this.BTN_AddPallet.Command = this.vm.AddPalletCommand;
            this.BTN_RemovePallet.Command = this.vm.RemPalletCommand;

            this.CHK_DrawBackground.Command = this.vm.DrawBackgroundCheckedChangedCommand;
        }

        private static SixLabors.ImageSharp.Color RunColorDialog(object sender, SixLabors.ImageSharp.Color @default)
        {
            PictureBox pbx = (PictureBox)sender;

            using (ColorDialog cd = new()
            {
                Color = pbx.BackColor
            })
            {
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    pbx.BackColor = cd.Color;
                    return cd.Color.ToImageSharpColor();
                }
            }

            return @default;
        }

        private void PBX_CrateColor_Click(object sender, EventArgs e)
        {
            this.vm.Properties.CrateColor = RunColorDialog(sender, this.vm.Properties.CrateColor);
        }

        private void PBX_PalletColor_Click(object sender, EventArgs e)
        {
            this.vm.Properties.PalletColor = RunColorDialog(sender, this.vm.Properties.PalletColor);
        }

        private void PBX_ScannerColor_Click(object sender, EventArgs e)
        {
            this.vm.Properties.ScannerColor = RunColorDialog(sender, this.vm.Properties.ScannerColor);
        }

        private void PBX_BackgroundColor_Click(object sender, EventArgs e)
        {
            this.vm.Properties.BackgroundColor = RunColorDialog(sender, this.vm.Properties.BackgroundColor);
        }
    }
}
