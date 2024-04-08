using SixLabors.ImageSharp.Formats.Png;
using System.IO;
using System.Threading.Tasks;

namespace TransportbeltRender
{
    public static class Extensions
    {
        public static async Task<System.Drawing.Image> SaveAsWinFormsImage(this TransportImage ti)
        {
            if (ti.renderResult == null)
            {
                return null;
            }

            System.Drawing.Image result = null;

            using (MemoryStream ms = new())
            {
                await ti.renderResult.SaveAsync(ms, new PngEncoder());
                result = System.Drawing.Image.FromStream(ms);
            }

            return result;
        }
    }
}
