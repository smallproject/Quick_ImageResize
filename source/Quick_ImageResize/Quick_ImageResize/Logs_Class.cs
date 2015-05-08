using System;
using System.Globalization;
using System.IO;
using System.Text;


namespace Quick_ImageResize
{
    class Logs_Class
    {
        StringBuilder logtext = new StringBuilder();
        public void ManageLogs(string text)
        {
            CreateLog(text);
        }

        private void CreateLog(String Text)
        {
            string _logpath = Directory.GetCurrentDirectory() + @"\log.txt";

            if (!File.Exists(_logpath))
            {
                Header();
                using (FileStream stream = File.Create(_logpath))
                {
                    AddText(stream, logtext.ToString());
                }
                CreateLog(Text);
            }
            else
            {
                logtext.Clear();
                string text = AddString(Text);
                logtext.AppendLine(text);
                File.AppendAllText(_logpath, logtext.ToString());

                //using (FileStream stream = File.OpenWrite(_logpath))
                //{
                //    string text = AddString(Text);
                //    AddText(stream, text);
                //}
            }
        }

        private void Header()
        {
            logtext.AppendLine("###################################################");
            logtext.AppendLine("One click resize photo");
            logtext.AppendLine("###################################################");
            logtext.AppendLine();
            logtext.AppendLine();
            logtext.AppendLine();
            logtext.AppendLine(string.Format("{0}", AddString("log starts here!")));
        }

        private string AddString(string log)
        {
            string value = string.Empty;
            value = string.Format("{0}:{1}", DateTime.Now.ToString(CultureInfo.InvariantCulture), log);
            return value;
        }

        private void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0 , info.Length);
        }
    }
}
