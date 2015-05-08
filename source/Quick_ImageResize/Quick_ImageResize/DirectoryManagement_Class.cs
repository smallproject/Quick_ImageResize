using System;
using System.IO;
using System.Security.AccessControl;

namespace Quick_ImageResize
{
    class DirectoryManagement_Class
    {
        private Logs_Class log = new Logs_Class();
        public string CurrentDirectoryPath()
        {
            string CurrentDirectory = Directory.GetCurrentDirectory();
            return CurrentDirectory;
        }

        public string StoredImagePath()
        {
            string CurrentDirectory = CurrentDirectoryPath();
            string StoredImage = CurrentDirectory + @"\Stored Image";
            return StoredImage;
        }

        public string TransformedImagePath()
        {
            string CurrentDirectory = CurrentDirectoryPath();
            string TransformedImage = CurrentDirectory + @"\Transformed Image";
            return TransformedImage;
        }

        public void Manage()
        {
            string path = "";
            if (!Directory.Exists(StoredImagePath()))
            {
                Directory.CreateDirectory(StoredImagePath());
                log.ManageLogs(string.Format("Directory \"Stored Image\" has been created."));
            }

            if (!Directory.Exists(TransformedImagePath()))
            {
                Directory.CreateDirectory(TransformedImagePath());
                log.ManageLogs(string.Format("Directory \"Transformed Image\" has been created."));
            }
        }

        public DirectorySecurity DirectorySecurity(string path)
        {
            DirectorySecurity().AddAccessRule(new);
        }
    }
}
