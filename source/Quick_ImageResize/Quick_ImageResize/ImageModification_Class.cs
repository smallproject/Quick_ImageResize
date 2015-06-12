using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
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

        public void ImageManage2(string path, string originalFilename, 
                                int canvasWidth, int canvasHeight,
                                int originalWidth, int originalHeight)
        {
            Image image = Image.FromFile(path + originalFilename);

            System.Drawing.Image thumbnail = new Bitmap(canvasWidth, canvasHeight);
            System.Drawing.Graphics graphic = System.Drawing.Graphics.FromImage(thumbnail);

            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphic.SmoothingMode = SmoothingMode.HighQuality;
            graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphic.CompositingQuality = CompositingQuality.HighQuality;


            double ratioX = (double) canvasWidth/(double) originalWidth;
            double ratioY = (double) canvasHeight/(double) originalHeight;
            double ratio = ratioX < ratioY ? ratioX : ratioY;


            int newHeight = Convert.ToInt32(originalHeight*ratio);
            int newWidth = Convert.ToInt32(originalWidth*ratio);

            int posX = Convert.ToInt32((canvasWidth - (originalWidth*ratio))/2);
            int posY = Convert.ToInt32((canvasHeight - (originalHeight*ratio))/2);

            graphic.Clear(Color.White);
            graphic.DrawImage(image, posX, posY, newWidth, newHeight);

            System.Drawing.Imaging.ImageCodecInfo[] info = ImageCodecInfo.GetImageEncoders();
            EncoderParameters encoderParameters;
            encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(System.Text.Encoder.Quality, 100L);
            thumbnail.Save(path + newWidth + "." + originalFilename, info[1], encoderParameters);
        }



    }
}
