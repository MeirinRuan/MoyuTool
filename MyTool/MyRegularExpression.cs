using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

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
        public Tuple<string,int> GetSecondLuaTable(string TableText)
        {
            int start = 0;
            int start2 = 0;
            int end = 0;
            Regex regex = new Regex(@"\{");
            Match match = regex.Match(TableText);
            if (match.Success)
            {
                start = match.Index + 1;
            }

            for (int i = start; i < TableText.Length; i++)
            {
                if (TableText[i].ToString() == "}")
                {
                    if (TableText[i + 1].ToString() == ",")
                    {
                        start2 = i + 2;
                        string str = TableText.Substring(start2, TableText.Length - start2);
                        Regex regex2 = new Regex(@"[^=]\s+\{");
                        Match match2 = regex2.Match(str);
                        if (match2.Success)
                        {
                            end = match2.Index + start2 + 1;
                            break;
                        }
                    }
                }
            }
            string newstr = TableText.Substring(start, end - start);
            //Console.WriteLine(newstr);
            return new Tuple<string, int>(newstr, end);
        }


        //读取子表每一项的文本
        public string GetItemLuaTable(string TableText)
        {
            Match match = Regex.Match(TableText, @"\s+.+\s+=\s+.+,");
            //Console.WriteLine(match.ToString());
            return match.ToString();
        }

        //读取子表的npcid
        public int GetNpcIdByItem(string TableText)
        {
            Match match = Regex.Match(TableText, @"(?<=nNpcId\s+=\s+).*?(?=,)");
            Console.WriteLine(match.Value);
            return 0;
        }
    }
}
