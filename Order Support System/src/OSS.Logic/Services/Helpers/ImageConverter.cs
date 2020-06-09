using System.IO;
using System.Threading.Tasks;
using ImageMagick;
using OSS.Common.Constants;

namespace OSS.Logic.Services.Helpers
{
    public class ImageConverter
    {

        public async Task ResizeTo800X600(string path)
        {
            var processedPath = ConstantsValue.ImagePath + @"\Processed\" + Path.GetFileName(path);
            var croppedPath = ConstantsValue.ImagePath + @"\Cropped\" + Path.GetFileName(path);

            await Resize(path, processedPath, 1600, 1200);
            await Resize(path, croppedPath, 300, 200);

        }

        private async Task Resize(string path, string dstPath, int width, int height)
        {
            using (var image = new MagickImage(path))
            {
                var size = new MagickGeometry(width, height) { IgnoreAspectRatio = true };
                var optimizer = new ImageOptimizer();

                image.Resize(size);
                image.Write(dstPath);
                optimizer.LosslessCompress(dstPath);
            }
        }
    }
}