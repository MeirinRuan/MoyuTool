using System;
using System.Collections.Generic;
using System.IO;

namespace MyTool
{
    /// <summary>
    /// 客户端配置
    /// </summary>
    public class ClinetConfig
    {
        //客户端对应sql配置
        Dictionary<string, List<string>> list = new Dictionary<string, List<string>>();

        //ini配置路径
        public string inipath;

        /// <summary>
        /// 构造函数中读取客户端ini配置，保存到list中
        /// </summary>
        public ClinetConfig()
        {
            inipath = Directory.GetCurrentDirectory() + "\\ini\\sql2client.ini";
            IniFiles ini = new IniFiles(inipath);
            if (ini.ExistINIFile())
            {
                var Keys = ini.ReadKeys("sql2client");

                for (int i = 0; i < Keys.Count; i++)
                {
                    var valuelist = ini.IniReadValue("sql2client", Keys[i]).Split(',');
                    list.Add(Keys[i], new List<string>(valuelist));
                }
            }
        }

        /// <summary>
        /// 获得数据库对应的配置行数
        /// </summary>
        /// <returns></returns>
        public int GetConfigVersion(string database)
        {
            IniFiles ini = new IniFiles(inipath);
            if (ini.ExistINIFile())
            {
                if (database.Contains("xsj"))
                    return Convert.ToInt32(ini.IniReadValue("clientconfig", "xsjmy"));
                else
                    return Convert.ToInt32(ini.IniReadValue("clientconfig", "sjmy"));
            }
            else
                return 0;
        }
        
        /// <summary>
        /// 判断是否存在对应配置
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        /// <returns></returns>
        public bool IsConfig(string key, string value)
        {
            if (list[key].Contains(value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 根据v值获得k值
        /// </summary>
        /// <param name="value">v值</param>
        /// <returns></returns>
        public string GetKey(string value)
        {
            foreach (var v in list)
            {
                if (v.Value.Contains(value))
                {
                    return v.Key;
                }
            }

            return "";
        }

        /// <summary>
        /// 根据客户端默认值的ini配置填入
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string SetDefaultFieldByClientIni(string value)
        {
            IniFiles ini = new IniFiles(inipath);
            if (ini.ExistINIFile())
            {
                var DefaultField = ini.ReadKeys("defaultfield");
                foreach (var v in DefaultField)
                {
                    if (value.Contains(v))
                        return ini.IniReadValue("defaultfield", v);
                }
                return "0";
            }
            else
                return "0";
        }
    }
}
