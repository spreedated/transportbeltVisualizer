using System.Collections.Generic;

namespace WinFormsApp1.Models
{
    public record TransportImageRenderElements
    {
        public int TransportBandSegments { get; set; }
        public int ScannerPosition { get; set; }
        public int[] CrateOnSegments { get; set; }
        public Dictionary<int, int> CratesOnPallets { get; set; }
    }
}
