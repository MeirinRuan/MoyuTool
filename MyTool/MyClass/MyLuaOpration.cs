using LuaInterface;
using System;
using System.IO;

namespace MyTool
{
    class MyLuaOpration
    {
        public static string BaseDirectory = "\\MyLua51";

        /// <summary>
        /// 获取luainterface目录
        /// </summary>
        /// <returns></returns>
        public static string MyLua_GetBaseLuaPath()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory() + BaseDirectory);
            return directoryInfo.FullName;
        }


        /// <summary>
        /// 输出log
        /// </summary>
        /// <param name="log">仅接收一个返回的字符串，用空格隔开</param>
        public static void MyLua_OutPutLog(string log)
        {
            var str = log.Split(' ');
            foreach(var s in str)
                Console.WriteLine(s);
        }

        /// <summary>
        /// 传参给lua
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string[] MyLua_ToLuaData(string value)
        {
            return new string[] { value, "1", "22" };
            
        }

    }
}
