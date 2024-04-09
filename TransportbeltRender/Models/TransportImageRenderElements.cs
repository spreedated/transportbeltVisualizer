using System.Collections.Generic;

namespace TransportbeltRender.Models
{
    public record TransportImageRenderElements
    {
        public int TransportBandSegments { get; set; } = 10;
        public int ScannerPosition { get; set; } = -1;
        public int[] CrateOnSegments { get; set; } = [];
        public Dictionary<int, int> CratesOnPallets { get; set; } = [];
    }
}
