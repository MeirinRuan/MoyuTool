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
  
        //读取游戏路径
        public string GetGamePath(string FilePath)
        {
            string GamePath = Regex.Match(Path.GetFullPath(FilePath), @".*?(?=\\script)").Value;
            return GamePath;
        }

        //读取control.ani的文本
        public string GetControlText(string GamePath)
        {
            GamePath = GamePath + "\\ani\\control.ani";
            string FileText = File.ReadAllText(GamePath, Encoding.Default);

            return FileText;
        }

        //根据title读取索引
        public string GetImagePathByControl(string GamePath, string FileText, string Title, int ControlType)
        {
            string str = ".*\n";
            for (int i = 0; i < ControlType; i++)
            {
                str += str;
            }
            string TitlePath = Regex.Match(FileText, string.Format(@"(?<=\[{0}\].*?\n{1}Frame{2}=)\S+", Title, str, ControlType)).Value;
            if (TitlePath != "")
            {
                TitlePath = GamePath + "\\" + TitlePath.Replace("/", "\\");
                return TitlePath;
            }
            else
            {
                return "";
            }
        }

    }
}
