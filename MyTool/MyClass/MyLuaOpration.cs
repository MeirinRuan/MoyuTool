using NLua;
using System;
using System.IO;

namespace MyTool
{
    class MyLuaOpration
    {

        public static string MyNLua_GetCurrentPath()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
            return directoryInfo.FullName;
        }


        public static void MyNLua_OutPutLog(string log)
        {
            Console.WriteLine(log);
        }

    }
}
