using Avalonia.Media.Imaging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using System.IO;
using System.Threading.Tasks;

namespace TransportbeltRender
{
    public static class Extensions
    {
        public static async Task<Bitmap> SaveAsAvaloniaImage(this TransportImage ti)
        {
            if (ti.renderResult == null)
            {
                return null;
            }

            Bitmap result = null;

            using (MemoryStream ms = new())
            {
                await ti.renderResult.SaveAsync(ms, new PngEncoder());
                ms.Position = 0;
                ms.Seek(0, SeekOrigin.Begin);

                result = new(ms);
            }

            return result;
        }

        public static Avalonia.Media.Color ToAvaloniaColor(this Color color)
        {
            var c = color.ToPixel<Rgba32>();

            return Avalonia.Media.Color.FromArgb(c.A, c.R, c.G, c.B);
        }

        public static Color ToImageSharpColor(this Avalonia.Media.Color color)
        {
            return Color.FromRgba(color.R, color.G, color.B, color.A);
        }
    }
}
