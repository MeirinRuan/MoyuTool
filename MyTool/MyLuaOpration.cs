using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuaInterface;

namespace MyTool
{
    class MyLuaOpration
    {
        const string Const_Null = "无";         //无
        const string Const_Activity = "火爆";     //火爆活动
        const string Const_Shop = "商店";         //商店
        const string Const_TaskSort = "排行榜";     //排行榜
        Lua m_lua = new Lua();

        //打开lua文件
        public void OpenLuaFile(string sFileName)
        {
            m_lua.DoFile(sFileName);
        }

        //读取一级tablle
        public LuaTable ReadFirstLuaTable(string sTableName)
        {
            return m_lua.GetTable(sTableName);
        }

        //根据数字顺序读取二级table
        public LuaTable ReadSecondLuaTableBySort(LuaTable tFirstTable,int nSort)
        {
            return (LuaTable)tFirstTable[nSort];
        }

        //根据字符串读取二级table
        public LuaTable ReadSecondLuaTableByString(LuaTable tFirstTable, string sTableName)
        {
            return (LuaTable)tFirstTable[sTableName];
        }

        //判断combo的类型
        public string GetLuaTableType(LuaTable tSecondTable)
        {
            if (tSecondTable["Click"] != null)
            {
                if (tSecondTable["Click"].ToString() != "")
                {
                    string str = tSecondTable["Click"].ToString();
                    if (str.Contains("50044"))
                    {
                        return Const_Activity;
                    }
                    else if (str.Contains("50013"))
                    {
                        return Const_Shop;
                    }
                    else if (str.Contains("SendLuaMsg(4,0,\"67\""))
                    {
                        return Const_TaskSort;
                    }
                }
                return Const_Null;
            }
            return "";
        }

    }
}
