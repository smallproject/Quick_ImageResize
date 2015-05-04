using System.IO;

namespace Quick_ImageResize
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        private string Dimensions(string ImageUse)
        {
            string dimension = "";
            switch (ImageUse)
            {
                case "facebook":
                    dimension = "851,315";
                    break;
                default:
                    break;
            }

            return dimension;
        }

        private string GetFiles()
        {
            FileStream stream = new FileStream();
        }
    }
}
