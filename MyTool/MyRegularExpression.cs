using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MyTool
{
    class MyRegularExpression
    {
        //读取tTabConfig表的文本
        public string GetLuaTableTabConfig(string FileText)
        {
            string startstr = "tTabConfig=\r\n{";
            string str = FileText.Substring(FileText.IndexOf(startstr) + startstr.Length, FileText.IndexOf("}\r\n") - FileText.IndexOf("tTabConfig=\r\n{") - startstr.Length);
            return str;
        }

        //读取子表的文本
        public string GetSecondLuaTable(string TableText)
        {
            Match match = Regex.Match(TableText, @"(?is)(?<=)(.*)(?=)");
            string TableText = match.ToString().Substring(1, );
            Console.WriteLine(match.ToString());
            return "";
        }

        //读取子表每一项的文本
        public string GetItemLuaTable(string TableText)
        {
            Match match = Regex.Match(TableText, @"\s+.+\s+=\s+.+,");
            //Console.WriteLine(match.ToString());
            return match.ToString();
        }
    }
}
