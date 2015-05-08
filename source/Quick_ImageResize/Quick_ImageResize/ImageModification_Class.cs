using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Quick_ImageResize
{
    class ImageModification_Class
    {
        public void ImageManage(string targetDirectory)
        {
            Directory.CreateDirectory(targetDirectory, DirectorySecurity)
        }

    }
}
