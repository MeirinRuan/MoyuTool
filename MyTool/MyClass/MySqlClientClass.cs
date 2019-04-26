using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTool
{
    /// <summary>
    /// 客户端配置
    /// </summary>
    public class ClinetConfig
    {
        //客户端对应sql配置
        Dictionary<string, List<string>> list = new Dictionary<string, List<string>>()
        {
            ["npc"] = new List<string>() { "cq_npc", "cq_dynanpc" },
            ["monster"] = new List<string>() { "cq_monstertype" },


        };

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
    }
}
