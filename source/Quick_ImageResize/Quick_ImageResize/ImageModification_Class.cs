using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace Quick_ImageResize
{
    class ImageModification_Class
    {
        private DirectoryManagement_Class CDM = new DirectoryManagement_Class();
        public struct Dimensions
        {
            public int height;
            public int width;

            public Dimensions(int _height, int _width)
            {
                height = _height;
                width = _width;
            }

            public int Resolution()
            {
                return height*width;
            }
        }

        public void ImageManage(string targetDirectory)
        {

            Dimensions dimensions = new Dimensions();

            dimensions.height = 351;
            dimensions.width = 815;
            var image = Image.FromFile(targetDirectory);

            var newImage = ScaleImage(image, dimensions.width, dimensions.height);
            newImage.Save(CDM.TransformedImagePath() + "\\test.png",ImageFormat.Png);
            //int test = dimensions.Resolution();
            //Console.WriteLine(test);
        }

        private Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double) maxWidth/image.Width;
            var ratioY = (double) maxHeight/image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int) (image.Width);
            var newHeight = (int) (image.Height);

            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            return newImage;
        }



    }
}
