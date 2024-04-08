using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PBX_RenderImage = new PictureBox();
            this.BTN_Render = new Button();
            this.NUD_BandSegments = new NumericUpDown();
            this.LBL_BandSegments = new Label();
            this.LBL_ScannerPosition = new Label();
            this.NUD_ScannerPosition = new NumericUpDown();
            this.GRP_CratesOnSegments = new GroupBox();
            this.BTN_RemoveCrate = new Button();
            this.BTN_AddCrate = new Button();
            this.NUD_Crate = new NumericUpDown();
            this.LSB_Crates = new ListBox();
            this.GRP_BandProps = new GroupBox();
            this.GRP_CratesOnPallets = new GroupBox();
            this.LBL_CrateCount = new Label();
            this.LBL_PalletPosition = new Label();
            this.NUD_CrateCount = new NumericUpDown();
            this.BTN_RemovePallet = new Button();
            this.BTN_AddPallet = new Button();
            this.NUD_PalletPosition = new NumericUpDown();
            this.LSB_Pallets = new ListBox();
            this.GRP_ImageRender = new GroupBox();
            this.BTN_SaveImage = new Button();
            this.GRP_ImageOptions = new GroupBox();
            this.PBX_BackgroundColor = new PictureBox();
            this.LBL_BackgroundColor = new Label();
            this.PBX_ScannerColor = new PictureBox();
            this.LBL_ScannerColor = new Label();
            this.PBX_PalletColor = new PictureBox();
            this.LBL_PalletColor = new Label();
            this.PBX_CrateColor = new PictureBox();
            this.LBL_CrateColor = new Label();
            this.LBL_BandYLocation = new Label();
            this.NUD_BandYLocation = new NumericUpDown();
            this.CHK_DrawBackground = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)this.PBX_RenderImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.NUD_BandSegments).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.NUD_ScannerPosition).BeginInit();
            this.GRP_CratesOnSegments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.NUD_Crate).BeginInit();
            this.GRP_BandProps.SuspendLayout();
            this.GRP_CratesOnPallets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.NUD_CrateCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.NUD_PalletPosition).BeginInit();
            this.GRP_ImageRender.SuspendLayout();
            this.GRP_ImageOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.PBX_BackgroundColor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.PBX_ScannerColor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.PBX_PalletColor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.PBX_CrateColor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.NUD_BandYLocation).BeginInit();
            this.SuspendLayout();
            // 
            // PBX_RenderImage
            // 
            this.PBX_RenderImage.Dock = DockStyle.Fill;
            this.PBX_RenderImage.Location = new Point(3, 19);
            this.PBX_RenderImage.Name = "PBX_RenderImage";
            this.PBX_RenderImage.Size = new Size(900, 256);
            this.PBX_RenderImage.TabIndex = 0;
            this.PBX_RenderImage.TabStop = false;
            // 
            // BTN_Render
            // 
            this.BTN_Render.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.BTN_Render.Location = new Point(803, 12);
            this.BTN_Render.Name = "BTN_Render";
            this.BTN_Render.Size = new Size(111, 23);
            this.BTN_Render.TabIndex = 1;
            this.BTN_Render.Text = "&Render";
            this.BTN_Render.UseVisualStyleBackColor = true;
            // 
            // NUD_BandSegments
            // 
            this.NUD_BandSegments.Location = new Point(101, 27);
            this.NUD_BandSegments.Maximum = new decimal(new int[] { 40, 0, 0, 0 });
            this.NUD_BandSegments.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.NUD_BandSegments.Name = "NUD_BandSegments";
            this.NUD_BandSegments.Size = new Size(44, 23);
            this.NUD_BandSegments.TabIndex = 2;
            this.NUD_BandSegments.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // LBL_BandSegments
            // 
            this.LBL_BandSegments.AutoSize = true;
            this.LBL_BandSegments.Location = new Point(6, 29);
            this.LBL_BandSegments.Name = "LBL_BandSegments";
            this.LBL_BandSegments.Size = new Size(89, 15);
            this.LBL_BandSegments.TabIndex = 3;
            this.LBL_BandSegments.Text = "BandSegments:";
            this.LBL_BandSegments.TextAlign = ContentAlignment.MiddleRight;
            // 
            // LBL_ScannerPosition
            // 
            this.LBL_ScannerPosition.AutoSize = true;
            this.LBL_ScannerPosition.Location = new Point(6, 58);
            this.LBL_ScannerPosition.Name = "LBL_ScannerPosition";
            this.LBL_ScannerPosition.Size = new Size(98, 15);
            this.LBL_ScannerPosition.TabIndex = 5;
            this.LBL_ScannerPosition.Text = "Scanner Position:";
            this.LBL_ScannerPosition.TextAlign = ContentAlignment.MiddleRight;
            // 
            // NUD_ScannerPosition
            // 
            this.NUD_ScannerPosition.Location = new Point(110, 56);
            this.NUD_ScannerPosition.Maximum = new decimal(new int[] { 40, 0, 0, 0 });
            this.NUD_ScannerPosition.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
            this.NUD_ScannerPosition.Name = "NUD_ScannerPosition";
            this.NUD_ScannerPosition.Size = new Size(44, 23);
            this.NUD_ScannerPosition.TabIndex = 4;
            this.NUD_ScannerPosition.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // GRP_CratesOnSegments
            // 
            this.GRP_CratesOnSegments.Controls.Add(this.BTN_RemoveCrate);
            this.GRP_CratesOnSegments.Controls.Add(this.BTN_AddCrate);
            this.GRP_CratesOnSegments.Controls.Add(this.NUD_Crate);
            this.GRP_CratesOnSegments.Controls.Add(this.LSB_Crates);
            this.GRP_CratesOnSegments.Location = new Point(188, 12);
            this.GRP_CratesOnSegments.Name = "GRP_CratesOnSegments";
            this.GRP_CratesOnSegments.Size = new Size(126, 132);
            this.GRP_CratesOnSegments.TabIndex = 6;
            this.GRP_CratesOnSegments.TabStop = false;
            this.GRP_CratesOnSegments.Text = "Crates on segments";
            // 
            // BTN_RemoveCrate
            // 
            this.BTN_RemoveCrate.Location = new Point(6, 93);
            this.BTN_RemoveCrate.Name = "BTN_RemoveCrate";
            this.BTN_RemoveCrate.Size = new Size(40, 23);
            this.BTN_RemoveCrate.TabIndex = 9;
            this.BTN_RemoveCrate.Text = "Rem";
            this.BTN_RemoveCrate.UseVisualStyleBackColor = true;
            // 
            // BTN_AddCrate
            // 
            this.BTN_AddCrate.Location = new Point(6, 51);
            this.BTN_AddCrate.Name = "BTN_AddCrate";
            this.BTN_AddCrate.Size = new Size(40, 23);
            this.BTN_AddCrate.TabIndex = 8;
            this.BTN_AddCrate.Text = "Add";
            this.BTN_AddCrate.UseVisualStyleBackColor = true;
            // 
            // NUD_Crate
            // 
            this.NUD_Crate.Location = new Point(6, 22);
            this.NUD_Crate.Name = "NUD_Crate";
            this.NUD_Crate.Size = new Size(40, 23);
            this.NUD_Crate.TabIndex = 8;
            // 
            // LSB_Crates
            // 
            this.LSB_Crates.FormattingEnabled = true;
            this.LSB_Crates.ItemHeight = 15;
            this.LSB_Crates.Location = new Point(52, 22);
            this.LSB_Crates.Name = "LSB_Crates";
            this.LSB_Crates.Size = new Size(68, 94);
            this.LSB_Crates.TabIndex = 0;
            // 
            // GRP_BandProps
            // 
            this.GRP_BandProps.Controls.Add(this.LBL_BandSegments);
            this.GRP_BandProps.Controls.Add(this.NUD_BandSegments);
            this.GRP_BandProps.Controls.Add(this.LBL_ScannerPosition);
            this.GRP_BandProps.Controls.Add(this.NUD_ScannerPosition);
            this.GRP_BandProps.Location = new Point(12, 12);
            this.GRP_BandProps.Name = "GRP_BandProps";
            this.GRP_BandProps.Size = new Size(170, 132);
            this.GRP_BandProps.TabIndex = 7;
            this.GRP_BandProps.TabStop = false;
            this.GRP_BandProps.Text = "Band properties";
            // 
            // GRP_CratesOnPallets
            // 
            this.GRP_CratesOnPallets.Controls.Add(this.LBL_CrateCount);
            this.GRP_CratesOnPallets.Controls.Add(this.LBL_PalletPosition);
            this.GRP_CratesOnPallets.Controls.Add(this.NUD_CrateCount);
            this.GRP_CratesOnPallets.Controls.Add(this.BTN_RemovePallet);
            this.GRP_CratesOnPallets.Controls.Add(this.BTN_AddPallet);
            this.GRP_CratesOnPallets.Controls.Add(this.NUD_PalletPosition);
            this.GRP_CratesOnPallets.Controls.Add(this.LSB_Pallets);
            this.GRP_CratesOnPallets.Location = new Point(320, 12);
            this.GRP_CratesOnPallets.Name = "GRP_CratesOnPallets";
            this.GRP_CratesOnPallets.Size = new Size(211, 132);
            this.GRP_CratesOnPallets.TabIndex = 10;
            this.GRP_CratesOnPallets.TabStop = false;
            this.GRP_CratesOnPallets.Text = "Crates on pallets";
            // 
            // LBL_CrateCount
            // 
            this.LBL_CrateCount.AutoSize = true;
            this.LBL_CrateCount.Location = new Point(3, 52);
            this.LBL_CrateCount.Name = "LBL_CrateCount";
            this.LBL_CrateCount.Size = new Size(72, 15);
            this.LBL_CrateCount.TabIndex = 12;
            this.LBL_CrateCount.Text = "Crate count:";
            this.LBL_CrateCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // LBL_PalletPosition
            // 
            this.LBL_PalletPosition.AutoSize = true;
            this.LBL_PalletPosition.Location = new Point(22, 24);
            this.LBL_PalletPosition.Name = "LBL_PalletPosition";
            this.LBL_PalletPosition.Size = new Size(53, 15);
            this.LBL_PalletPosition.TabIndex = 11;
            this.LBL_PalletPosition.Text = "Position:";
            this.LBL_PalletPosition.TextAlign = ContentAlignment.MiddleRight;
            // 
            // NUD_CrateCount
            // 
            this.NUD_CrateCount.Location = new Point(81, 50);
            this.NUD_CrateCount.Name = "NUD_CrateCount";
            this.NUD_CrateCount.Size = new Size(40, 23);
            this.NUD_CrateCount.TabIndex = 10;
            // 
            // BTN_RemovePallet
            // 
            this.BTN_RemovePallet.Location = new Point(81, 93);
            this.BTN_RemovePallet.Name = "BTN_RemovePallet";
            this.BTN_RemovePallet.Size = new Size(40, 23);
            this.BTN_RemovePallet.TabIndex = 9;
            this.BTN_RemovePallet.Text = "Rem";
            this.BTN_RemovePallet.UseVisualStyleBackColor = true;
            // 
            // BTN_AddPallet
            // 
            this.BTN_AddPallet.Location = new Point(6, 93);
            this.BTN_AddPallet.Name = "BTN_AddPallet";
            this.BTN_AddPallet.Size = new Size(40, 23);
            this.BTN_AddPallet.TabIndex = 8;
            this.BTN_AddPallet.Text = "Add";
            this.BTN_AddPallet.UseVisualStyleBackColor = true;
            // 
            // NUD_PalletPosition
            // 
            this.NUD_PalletPosition.Location = new Point(81, 21);
            this.NUD_PalletPosition.Name = "NUD_PalletPosition";
            this.NUD_PalletPosition.Size = new Size(40, 23);
            this.NUD_PalletPosition.TabIndex = 8;
            // 
            // LSB_Pallets
            // 
            this.LSB_Pallets.FormattingEnabled = true;
            this.LSB_Pallets.ItemHeight = 15;
            this.LSB_Pallets.Location = new Point(127, 22);
            this.LSB_Pallets.Name = "LSB_Pallets";
            this.LSB_Pallets.Size = new Size(78, 94);
            this.LSB_Pallets.TabIndex = 0;
            // 
            // GRP_ImageRender
            // 
            this.GRP_ImageRender.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.GRP_ImageRender.Controls.Add(this.PBX_RenderImage);
            this.GRP_ImageRender.Location = new Point(12, 150);
            this.GRP_ImageRender.Name = "GRP_ImageRender";
            this.GRP_ImageRender.Size = new Size(906, 278);
            this.GRP_ImageRender.TabIndex = 11;
            this.GRP_ImageRender.TabStop = false;
            this.GRP_ImageRender.Text = "Rendered image";
            // 
            // BTN_SaveImage
            // 
            this.BTN_SaveImage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.BTN_SaveImage.Enabled = false;
            this.BTN_SaveImage.Location = new Point(803, 41);
            this.BTN_SaveImage.Name = "BTN_SaveImage";
            this.BTN_SaveImage.Size = new Size(111, 23);
            this.BTN_SaveImage.TabIndex = 12;
            this.BTN_SaveImage.Text = "&Save image";
            this.BTN_SaveImage.UseVisualStyleBackColor = true;
            // 
            // GRP_ImageOptions
            // 
            this.GRP_ImageOptions.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.GRP_ImageOptions.Controls.Add(this.PBX_BackgroundColor);
            this.GRP_ImageOptions.Controls.Add(this.LBL_BackgroundColor);
            this.GRP_ImageOptions.Controls.Add(this.PBX_ScannerColor);
            this.GRP_ImageOptions.Controls.Add(this.LBL_ScannerColor);
            this.GRP_ImageOptions.Controls.Add(this.PBX_PalletColor);
            this.GRP_ImageOptions.Controls.Add(this.LBL_PalletColor);
            this.GRP_ImageOptions.Controls.Add(this.PBX_CrateColor);
            this.GRP_ImageOptions.Controls.Add(this.LBL_CrateColor);
            this.GRP_ImageOptions.Controls.Add(this.LBL_BandYLocation);
            this.GRP_ImageOptions.Controls.Add(this.NUD_BandYLocation);
            this.GRP_ImageOptions.Controls.Add(this.CHK_DrawBackground);
            this.GRP_ImageOptions.Location = new Point(537, 12);
            this.GRP_ImageOptions.Name = "GRP_ImageOptions";
            this.GRP_ImageOptions.Size = new Size(260, 132);
            this.GRP_ImageOptions.TabIndex = 13;
            this.GRP_ImageOptions.TabStop = false;
            this.GRP_ImageOptions.Text = "Image options";
            // 
            // PBX_BackgroundColor
            // 
            this.PBX_BackgroundColor.BorderStyle = BorderStyle.FixedSingle;
            this.PBX_BackgroundColor.Cursor = Cursors.Hand;
            this.PBX_BackgroundColor.Location = new Point(212, 102);
            this.PBX_BackgroundColor.Name = "PBX_BackgroundColor";
            this.PBX_BackgroundColor.Size = new Size(24, 24);
            this.PBX_BackgroundColor.TabIndex = 20;
            this.PBX_BackgroundColor.TabStop = false;
            this.PBX_BackgroundColor.Click += this.PBX_BackgroundColor_Click;
            // 
            // LBL_BackgroundColor
            // 
            this.LBL_BackgroundColor.AutoSize = true;
            this.LBL_BackgroundColor.Location = new Point(127, 106);
            this.LBL_BackgroundColor.Name = "LBL_BackgroundColor";
            this.LBL_BackgroundColor.Size = new Size(79, 15);
            this.LBL_BackgroundColor.TabIndex = 19;
            this.LBL_BackgroundColor.Text = "Backgr. color:";
            this.LBL_BackgroundColor.TextAlign = ContentAlignment.MiddleRight;
            // 
            // PBX_ScannerColor
            // 
            this.PBX_ScannerColor.BorderStyle = BorderStyle.FixedSingle;
            this.PBX_ScannerColor.Cursor = Cursors.Hand;
            this.PBX_ScannerColor.Location = new Point(212, 72);
            this.PBX_ScannerColor.Name = "PBX_ScannerColor";
            this.PBX_ScannerColor.Size = new Size(24, 24);
            this.PBX_ScannerColor.TabIndex = 18;
            this.PBX_ScannerColor.TabStop = false;
            this.PBX_ScannerColor.Click += this.PBX_ScannerColor_Click;
            // 
            // LBL_ScannerColor
            // 
            this.LBL_ScannerColor.AutoSize = true;
            this.LBL_ScannerColor.Location = new Point(124, 76);
            this.LBL_ScannerColor.Name = "LBL_ScannerColor";
            this.LBL_ScannerColor.Size = new Size(82, 15);
            this.LBL_ScannerColor.TabIndex = 17;
            this.LBL_ScannerColor.Text = "Scanner color:";
            this.LBL_ScannerColor.TextAlign = ContentAlignment.MiddleRight;
            // 
            // PBX_PalletColor
            // 
            this.PBX_PalletColor.BorderStyle = BorderStyle.FixedSingle;
            this.PBX_PalletColor.Cursor = Cursors.Hand;
            this.PBX_PalletColor.Location = new Point(80, 102);
            this.PBX_PalletColor.Name = "PBX_PalletColor";
            this.PBX_PalletColor.Size = new Size(24, 24);
            this.PBX_PalletColor.TabIndex = 16;
            this.PBX_PalletColor.TabStop = false;
            this.PBX_PalletColor.Click += this.PBX_PalletColor_Click;
            // 
            // LBL_PalletColor
            // 
            this.LBL_PalletColor.AutoSize = true;
            this.LBL_PalletColor.Location = new Point(6, 106);
            this.LBL_PalletColor.Name = "LBL_PalletColor";
            this.LBL_PalletColor.Size = new Size(69, 15);
            this.LBL_PalletColor.TabIndex = 15;
            this.LBL_PalletColor.Text = "Pallet color:";
            this.LBL_PalletColor.TextAlign = ContentAlignment.MiddleRight;
            // 
            // PBX_CrateColor
            // 
            this.PBX_CrateColor.BorderStyle = BorderStyle.FixedSingle;
            this.PBX_CrateColor.Cursor = Cursors.Hand;
            this.PBX_CrateColor.Location = new Point(80, 72);
            this.PBX_CrateColor.Name = "PBX_CrateColor";
            this.PBX_CrateColor.Size = new Size(24, 24);
            this.PBX_CrateColor.TabIndex = 14;
            this.PBX_CrateColor.TabStop = false;
            this.PBX_CrateColor.Click += this.PBX_CrateColor_Click;
            // 
            // LBL_CrateColor
            // 
            this.LBL_CrateColor.AutoSize = true;
            this.LBL_CrateColor.Location = new Point(6, 76);
            this.LBL_CrateColor.Name = "LBL_CrateColor";
            this.LBL_CrateColor.Size = new Size(68, 15);
            this.LBL_CrateColor.TabIndex = 13;
            this.LBL_CrateColor.Text = "Crate color:";
            this.LBL_CrateColor.TextAlign = ContentAlignment.MiddleRight;
            // 
            // LBL_BandYLocation
            // 
            this.LBL_BandYLocation.AutoSize = true;
            this.LBL_BandYLocation.Location = new Point(6, 44);
            this.LBL_BandYLocation.Name = "LBL_BandYLocation";
            this.LBL_BandYLocation.Size = new Size(126, 15);
            this.LBL_BandYLocation.TabIndex = 12;
            this.LBL_BandYLocation.Text = "Band Y location offset:";
            this.LBL_BandYLocation.TextAlign = ContentAlignment.MiddleRight;
            // 
            // NUD_BandYLocation
            // 
            this.NUD_BandYLocation.Location = new Point(138, 42);
            this.NUD_BandYLocation.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.NUD_BandYLocation.Minimum = new decimal(new int[] { 200, 0, 0, 0 });
            this.NUD_BandYLocation.Name = "NUD_BandYLocation";
            this.NUD_BandYLocation.Size = new Size(40, 23);
            this.NUD_BandYLocation.TabIndex = 9;
            this.NUD_BandYLocation.Value = new decimal(new int[] { 206, 0, 0, 0 });
            // 
            // CHK_DrawBackground
            // 
            this.CHK_DrawBackground.AutoSize = true;
            this.CHK_DrawBackground.Location = new Point(6, 22);
            this.CHK_DrawBackground.Name = "CHK_DrawBackground";
            this.CHK_DrawBackground.Size = new Size(120, 19);
            this.CHK_DrawBackground.TabIndex = 0;
            this.CHK_DrawBackground.Text = "Draw background";
            this.CHK_DrawBackground.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(928, 440);
            this.Controls.Add(this.GRP_ImageOptions);
            this.Controls.Add(this.BTN_SaveImage);
            this.Controls.Add(this.GRP_ImageRender);
            this.Controls.Add(this.GRP_CratesOnPallets);
            this.Controls.Add(this.GRP_BandProps);
            this.Controls.Add(this.GRP_CratesOnSegments);
            this.Controls.Add(this.BTN_Render);
            this.DoubleBuffered = true;
            this.MinimumSize = new Size(944, 479);
            this.Name = "Main";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Hessen Mousa";
            ((System.ComponentModel.ISupportInitialize)this.PBX_RenderImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.NUD_BandSegments).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.NUD_ScannerPosition).EndInit();
            this.GRP_CratesOnSegments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.NUD_Crate).EndInit();
            this.GRP_BandProps.ResumeLayout(false);
            this.GRP_BandProps.PerformLayout();
            this.GRP_CratesOnPallets.ResumeLayout(false);
            this.GRP_CratesOnPallets.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.NUD_CrateCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.NUD_PalletPosition).EndInit();
            this.GRP_ImageRender.ResumeLayout(false);
            this.GRP_ImageOptions.ResumeLayout(false);
            this.GRP_ImageOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.PBX_BackgroundColor).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.PBX_ScannerColor).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.PBX_PalletColor).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.PBX_CrateColor).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.NUD_BandYLocation).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private PictureBox PBX_RenderImage;
        private Button BTN_Render;
        private NumericUpDown NUD_BandSegments;
        private Label LBL_BandSegments;
        private Label LBL_ScannerPosition;
        private NumericUpDown NUD_ScannerPosition;
        private GroupBox GRP_CratesOnSegments;
        private GroupBox GRP_BandProps;
        private Button BTN_RemoveCrate;
        private Button BTN_AddCrate;
        private NumericUpDown NUD_Crate;
        private ListBox LSB_Crates;
        private GroupBox GRP_CratesOnPallets;
        private NumericUpDown NUD_CrateCount;
        private Button BTN_RemovePallet;
        private Button BTN_AddPallet;
        private NumericUpDown NUD_PalletPosition;
        private ListBox LSB_Pallets;
        private Label LBL_CrateCount;
        private Label LBL_PalletPosition;
        private GroupBox GRP_ImageRender;
        private Button BTN_SaveImage;
        private GroupBox GRP_ImageOptions;
        private CheckBox CHK_DrawBackground;
        private Label LBL_BandYLocation;
        private NumericUpDown NUD_BandYLocation;
        private Label LBL_CrateColor;
        private PictureBox PBX_CrateColor;
        private PictureBox PBX_PalletColor;
        private Label LBL_PalletColor;
        private PictureBox PBX_ScannerColor;
        private Label LBL_ScannerColor;
        private PictureBox PBX_BackgroundColor;
        private Label LBL_BackgroundColor;
    }
}
