using SixLabors.ImageSharp;

namespace TransportbeltRender.Models
{
    public record TransportImageProperties
    {
        public float BandWitdh { get; set; } = 25f;
        public float BandStroke { get; set; } = 5f;
        public float BandYLocation { get; set; } = 206f;
        public float ScannerWidth { get; set; } = 10f;
        public bool DrawBackground { get; set; }
        public Color CrateColor { get; set; } = Color.FromRgb(255, 163, 0);
        public Color PalletColor { get; set; } = Color.FromRgb(155, 100, 0);
        public Color ScannerColor { get; set; } = Color.FromRgb(0, 0, 200);
        public Color BackgroundColor { get; set; } = Color.FromRgb(200, 200, 200);
    }
}
