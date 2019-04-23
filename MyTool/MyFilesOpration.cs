using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace MyTool
{
    class MyFilesOpration
    {

        //读取游戏路径
        public string GetGamePathByScript(string FilePath)
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

    public class IniFiles
    {
        public string inipath;

        [DllImport("kernel32")]//返回0表示失败，非0为成功
        private static extern long WritePrivateProfileString(string section, string key,
            string val, string filePath);

        [DllImport("kernel32")]//返回取得字符串缓冲区的长度
        private static extern int GetPrivateProfileString(string section, string key,
            string def, StringBuilder retVal, int size, string filePath);

        public IniFiles(string INIPath)
        {
            
            inipath = INIPath;
            
        }

        public IniFiles() { }

        /// <summary> 
        /// 读出INI文件 
        /// </summary> 
        /// <param name="Section">项目名称(如 [TypeName] )</param> 
        /// <param name="Key">键</param> 
        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(500);
            GetPrivateProfileString(Section, Key, "", temp, 500, inipath);
            return temp.ToString();
        }


        /// <summary> 
        /// 写入INI文件 
        /// </summary> 
        /// <param name="Section">项目名称(如 [TypeName] )</param> 
        /// <param name="Key">键</param> 
        /// <param name="Value">值</param> 
        public void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, inipath);
        }


        /// <summary> 
        /// 验证文件是否存在 
        /// </summary> 
        /// <returns>布尔值</returns> 
        public bool ExistINIFile()
        {
            return File.Exists(inipath);
        }


    }

}
