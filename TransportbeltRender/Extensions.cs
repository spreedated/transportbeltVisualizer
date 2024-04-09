using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using System.IO;
using System.Threading.Tasks;

namespace TransportbeltRender
{
    public static class Extensions
    {
        /// <summary>
        /// Saves the image to a file, as a PNG
        /// </summary>
        /// <param name="ti"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static async Task SaveToFile(this TransportImage ti, string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            await Task.Run(() => ti.renderResult.Save(path, new PngEncoder()));
        }

        /// <summary>
        /// Saves the image to a stream, as a PNG
        /// </summary>
        /// <param name="ti"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static async Task SaveToStream(this TransportImage ti, Stream stream)
        {
            if (stream == null || !stream.CanWrite)
            {
                return;
            }

            stream.Position = 0;
            stream.Seek(0, SeekOrigin.Begin);

            await ti.renderResult.SaveAsync(stream, new PngEncoder());
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
