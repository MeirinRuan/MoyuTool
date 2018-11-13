using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace MyTool
{
    class MyFilesOpration
    {

        //读取control.ani的文本
        public string GetControlText(string GamePath)
        {
            GamePath = GamePath + "\\ani\\control.ani";
            string FileText = File.ReadAllText(GamePath, Encoding.Default);

            return FileText;
        }

        //根据title读取索引
        public string GetImagePathByControl(string FileText, string Title)
        {
            Regex regex = new Regex(@"[" + Title + "]");
            Match match = regex.Match(FileText);
            Console.WriteLine(match.Value);

            return "";
        }
    }
}
