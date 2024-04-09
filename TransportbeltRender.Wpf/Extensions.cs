using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace TransportbeltRender
{
    public static class Extensions
    {
        public static async Task<System.Windows.Media.ImageSource> SaveAsWpfImage(this TransportImage ti)
        {
            if (ti.renderResult == null)
            {
                return null;
            }

            BitmapImage result = new();

            using (MemoryStream ms = new())
            {
                await ti.renderResult.SaveAsync(ms, new PngEncoder());
                ms.Position = 0;
                ms.Seek(0, SeekOrigin.Begin);

                result.BeginInit();
                result.StreamSource = ms;
                result.CacheOption = BitmapCacheOption.OnLoad;
                result.EndInit();
                result.Freeze();
            }

            return result;
        }

        public static System.Windows.Media.Color ToWpfColor(this Color color)
        {
            var c = color.ToPixel<Rgba32>();

            return System.Windows.Media.Color.FromArgb(c.A, c.R, c.G, c.B);
        }

        public static Color ToImageSharpColor(this System.Windows.Media.Color color)
        {
            return Color.FromRgba(color.R, color.G, color.B, color.A);
        }
    }
}
