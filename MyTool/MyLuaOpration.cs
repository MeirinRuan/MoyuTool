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


    }
}
