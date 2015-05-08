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
            CDM.Manage();
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

        private static string FolderPath()
        {
            //return @"C:\git_root\Quick_ImageResize\source\Quick_ImageResize\Quick_ImageResize\Stored Image";
            //return @"C:\git_root\Quick_ImageResize\source\Quick_ImageResize\Quick_ImageResize\Stored Image";
            return @"\Stored Image";
        }

        public static void ProcessFile(string targetDirectory)
        {
            string[] fileEntries = Directory.GetFiles(targetDirectory);

            foreach (var filename in fileEntries)
            {
                Console.WriteLine(filename);
            }
        }
    }
}
