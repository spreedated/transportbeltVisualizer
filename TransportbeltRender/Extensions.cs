using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using System.Threading.Tasks;

namespace TransportbeltRender
{
    public static class Extensions
    {
        public static async Task SaveToFile(this TransportImage ti, string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            await Task.Run(() => ti.renderResult.Save(path, new PngEncoder()));
        }

        public static System.Drawing.Color ToSystemDrawingColor(this Color c)
        {
            Argb32 converted = c.ToPixel<Argb32>();
            return System.Drawing.Color.FromArgb(converted.A, converted.R, converted.G, converted.B);
        }

        public static Color ToImageSharpColor(this System.Drawing.Color c)
        {
            return Color.FromRgba(c.R, c.G, c.B, c.A);
        }
    }
}
