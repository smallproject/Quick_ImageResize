using System;
using System.Globalization;
using System.IO;
using System.Text;


namespace Quick_ImageResize
{
    class Logs_Class
    {
        StringBuilder logtext = new StringBuilder();
        string _logpath = Directory.GetCurrentDirectory() + @"\log.txt";
        public Logs_Class() 
        {

            if (!File.Exists(_logpath))
            {
                Header();
                using (FileStream stream = File.Create(_logpath))
                {
                    AddText(stream, logtext.ToString());
                }
            }
        }

        public void ManageLogs(string text)
        {
            if (!File.Exists(_logpath))
            {
                new Logs_Class();
            }
            CreateLog(text);
        }

        private void CreateLog(String Text)
        {

                logtext.Clear();
                string text = AddString(Text);
                logtext.AppendLine(text);
                File.AppendAllText(_logpath, logtext.ToString());

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
