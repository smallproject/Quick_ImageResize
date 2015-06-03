using System;
using System.IO;

namespace Quick_ImageResize
{
    class Program
    {
        private static ImageModification_Class CIM = new ImageModification_Class();
        private static DirectoryManagement_Class CDM = new DirectoryManagement_Class();
        private static Logs_Class CL = new Logs_Class();

        static void Main(string[] args)
        {
            
            
            ProcessFile(CDM.StoredImagePath());
        }

        private string Dimensions(string ImageUse)
        {
            string dimension = "";
            switch (ImageUse)
            {
                case "facebook-cover":
                    dimension = "851,315";
                    break;

                case "facebook-profile":
                    dimension = "180,180";
                    break;
                    
                default:
                    break;
            }

            return dimension;
        }

        private static string FolderPath()
        {
            return @"\Stored Image";
        }

        public static void ProcessFile(string targetDirectory)
        {
            string[] fileEntries = Directory.GetFiles(targetDirectory);

            foreach (var filename in fileEntries)
            {
                CIM.ImageManage(filename);
                Console.WriteLine(filename);
            }
        }
    }
}
