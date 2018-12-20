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
            string endstr = "}\r\n";
            string str = FileText.Substring(FileText.IndexOf(startstr) + startstr.Length, FileText.IndexOf(endstr) - FileText.IndexOf(startstr) - startstr.Length);
            return str;
        }

        //读取tTabConfig子表的文本
        public Tuple<string,int> GetSecondLuaTable(string TableText)
        {
            int start = 0;
            int start2 = 0;
            int end = 0;

            //匹配左括号
            Regex regex = new Regex(@"\{");
            Match match = regex.Match(TableText);
            if (match.Success)
            {
                start = match.Index + 1;
            }

            //匹配右括号
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
            return new Tuple<string, int>(newstr, end);
        }

        //读取tTabConfig子表的title
        public string GetTabConfigTitleByItem(string TableText)
        {
            Match match = Regex.Match(TableText, @"(?<=Title\s+=\s+"")\w+(?="",)");
            return match.Value;
        }

        //读取tTabConfig子表的npcid
        public int GetTabConfigNpcIdByItem(string TableText)
        {
            Match match = Regex.Match(TableText, @"(?<=nNpcId\s+=\s+).*?(?=,)");
            return Convert.ToInt32(match.Value);
        }

        //读取tTaskList表的文本
        public string GetLuaTableTaskList(string FileText)
        {
            Regex regex = new Regex(@"tTaskList=\{\s+\[1\]=\{");
            Match match = regex.Match(FileText);
            string startstr = match.Value;
            string endstr = "}\r\n}";
            string str = FileText.Substring(FileText.IndexOf(startstr) + startstr.Length, FileText.IndexOf(endstr) - FileText.IndexOf(startstr) - startstr.Length);
            //Console.WriteLine(str);
            return str;
        }

        //读取tTaskList子表的文本
        public Tuple<string, int, int, int> GetActivityLuaTable(string TableText)
        {
            int start = 0;
            int end = 0;
            int taskid = 0;
            int npcid = 0;

            //匹配taskid
            Regex regex_taskid = new Regex(@"(?<=\[)\d+(?=\]=\{)");
            Match match_taskid = regex_taskid.Match(TableText);
            if (match_taskid.Success)
            {
                taskid = Convert.ToInt32(match_taskid.Value);
            }

            //匹配npcid
            Regex regex_npc = new Regex(@"(?<=TaskNpcId\s+=\s+)\d+(?=,)");
            Match match_npc = regex_npc.Match(TableText);
            if (match_npc.Success)
            {
                npcid = Convert.ToInt32(match_npc.Value);
            }

            //匹配子表文本
            Regex regex_table = new Regex(@"(?<=\[\d+\]=\{)([\s\S]*?)(?=\[\d+\])");
            Match match_table = regex_table.Match(TableText);
            string newstr = "";
            if (match_table.Success)
            {
                start = match_table.Index + 1;
                newstr = match_table.Value;
                end = start + match_table.Value.Length;
            }
            //最后一个子表
            else
            {
                end = TableText.Length;
                newstr = TableText.Substring(start, end);
            }
            return new Tuple<string, int, int, int>(newstr, end, taskid, npcid);
        }

        //读取tTaskList子表的ico
        public string GetTaskListIcoByItem(string TableText)
        {
            Match match = Regex.Match(TableText, @"(?<=TaskIcon="").*?(?="",)");
            return match.Value;
        }

        //读取tTaskList子表的title
        public string GetTaskListTitleByItem(string TableText)
        {
            Match match = Regex.Match(TableText, @"(?<=TaskName="").*?(?="",)");
            return match.Value;
        }

        //读取tTaskList子表的Recommend
        public bool GetTaskListRecommendByItem(string TableText)
        {
            Match match = Regex.Match(TableText, "Recommend=1,");
            if (match.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //读取tTaskList子表的TeamNumStr
        public string GetTaskListTeamNumStrByItem(string TableText)
        {
            Match match = Regex.Match(TableText, @"(?<=TeamNumStr="").*?(?="",)");
            if (match.Success)
            {
                return match.Value;
            }
            else
            {
                return "";
            }
        }

        //读取tTaskList子表的DetailTime
        public string[] GetTaskListDetailTimeByItem(string TableText)
        {
            Match match = Regex.Match(TableText, @"(?<=DetailTime=\{).*?(?=\},)");
            string[] str = Regex.Split(match.Value, ",");
            return str;
        }

        //判断combo的类型
        public string GetLuaTableType(string tSecondTable)
        {
            if (tSecondTable != null)
            {
                //匹配wndid
                Regex regex_wndid = new Regex(@"(?<=\s+WndId\s+=\s+)\d+(?=,)");
                Match match_wndid = regex_wndid.Match(tSecondTable);
                if (tSecondTable.Contains("50044") && match_wndid.Value == "50046")
                {
                    return Const_Activity;
                }
                else if (tSecondTable.Contains("50013") && match_wndid.Value == "50013")
                {
                    return Const_Shop;
                }
                else if (tSecondTable.Contains("SendLuaMsg(4,0,\"67"))
                {
                    return Const_TaskSort;
                }
                return Const_Null;
            }
            return Const_Null;
        }
    }
}
