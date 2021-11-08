using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// Image rescaling
    /// </summary>
    public class RescaleImageTest : ITest
    {
        public void Run()
        {
            // TODO
            // Grab an image from a public URL and write a function that rescales the image to a desired format
            // The use of 3rd party plugins is permitted
            // For example: 100x80 (thumbnail) and 1200x1600 (preview)
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Resources";
            string changedFileName = "newFile.jpg";
            System.Drawing.Image img = System.Drawing.Image.FromFile(string.Concat(path, "/Capture.JPG"));
            img = resizeImage(img);
            img.Save(string.Concat(path, "/"+ changedFileName));
        }

        private static System.Drawing.Image resizeImage(System.Drawing.Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);


            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;
            

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (System.Drawing.Image)b;
        }
        private System.Drawing.Image resizeImage(System.Drawing.Image img)
        {
            Bitmap b = new Bitmap(img);
            System.Drawing.Image i = resizeImage(b, new Size(100, 100));
            return i;
        }
    }
}
