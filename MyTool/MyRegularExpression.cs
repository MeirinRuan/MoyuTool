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
        const string Const_Null = "无";         //无
        const string Const_Activity = "火爆";     //火爆活动
        const string Const_Shop = "商店";         //商店
        const string Const_TaskSort = "排行榜";     //排行榜

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
                        //最后一个子表
                        else
                        {
                            end = TableText.Length;
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
            //Console.WriteLine(Convert.ToInt32(match.Value));
            return Convert.ToInt32(match.Value);
        }

        //判断combo的类型
        public string GetLuaTableType(string tSecondTable)
        {
            if (tSecondTable != null)
            {
                if (tSecondTable.Contains("50044"))
                {
                    return Const_Activity;
                }
                else if (tSecondTable.Contains("50013"))
                {
                    return Const_Shop;
                }
                else if (tSecondTable.Contains("SendLuaMsg(4,0,\"67\""))
                {
                    return Const_TaskSort;
                }
            }
            return Const_Null;
        }
    }
}
