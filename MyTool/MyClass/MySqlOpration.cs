using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;

namespace MyTool
{
    class MySqlOpration
    {
        /// <summary>
        /// 连接数据库字符串
        /// </summary>
        /// <param name="Sqlinfo">sql连接</param>
        /// <returns></returns>
        public string GetMySqlConnectstring(List<string> Sqlinfo)
        {
            string ConnectText = string.Format("Server={0};Uid={1};Pwd={2};Database={3};Port={4};", Sqlinfo[0], Sqlinfo[1], Sqlinfo[2], Sqlinfo[3], Sqlinfo[4]);
            return ConnectText;
        }


        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <param name="Sqlinfo">sql连接</param>
        /// <returns></returns>
        public MySqlConnection MySqlConncet(List<string> Sqlinfo)
        {

            try
            {
                string ConnectText = GetMySqlConnectstring(Sqlinfo);
                MySqlConnection conn = new MySqlConnection(ConnectText);
                //if (!myConnection.Ping())
                //{
                conn.Open();
                //}
                return conn;
            }
            catch (Exception ex)
            {
                //conn.Close();
                //错误信息
                Console.WriteLine("连接数据库失败！\n" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 执行语句 用于返回dataset
        /// </summary>
        /// <param name="Sqlinfo">sql连接</param>
        /// <param name="sText">sql语句</param>
        /// <returns></returns>
        public DataSet MySqlCommand_GetDataSet(List<string> Sqlinfo, string sText)
        {
            //string ConnectText = GetMySqlConnectstring(Sqlinfo);
            //MySqlConnection conn = new MySqlConnection(ConnectText);
            MySqlConnection conn = MySqlConncet(Sqlinfo);

            try
            {
                //conn.Open();          
                if (MySqlConncet(Sqlinfo) == null)
                {
                    //MessageBox.Show("数据库连接失败");
                    return null;
                }
                DataSet ds = new DataSet();
                MySqlDataAdapter command = new MySqlDataAdapter(sText, conn);
                command.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //关闭连接
                conn.Close();
            }
        }

        /// <summary>
        /// 执行语句 用于返回单个表第几个字段信息的查询结果
        /// </summary>
        /// <param name="Sqlinfo">sql连接</param>
        /// <param name="SqlText">tablename</param>
        /// <param name="Index">table中第几个字段</param>
        /// <returns></returns>
        public string MySqlCommand_GetNameIndex(List<string> Sqlinfo, string SqlText, int Index)
        {
            string ConnectText = GetMySqlConnectstring(Sqlinfo);
            MySqlConnection conn = new MySqlConnection(ConnectText);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select *from " + SqlText, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                string str = reader.GetName(Index);

                return str;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //关闭连接
                conn.Close();
            }
        }

        /// <summary>
        /// 执行语句 用于返回单个表全部字段信息的查询结果
        /// </summary>
        /// <param name="Sqlinfo">sql连接</param>
        /// <param name="SqlText">sql语句</param>
        /// <returns></returns>
        public List<string> MySqlCommand_GetAllField(List<string> Sqlinfo, string SqlText)
        {
            string ConnectText = GetMySqlConnectstring(Sqlinfo);
            MySqlConnection conn = new MySqlConnection(ConnectText);

            List<string> str = new List<string>();

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(SqlText, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                int j = reader.FieldCount;
                for (int i = 0; i < j; i++)
                {
                    str.Add(reader.GetName(i));
                }

                return str;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //关闭连接
                conn.Close();
            }
        }

        /// <summary>
        /// 读取sql文件,返回插入的表信息
        /// </summary>
        /// <param name="AllTexts">sql文本</param>
        /// <returns></returns>
        public List<SqlFileInfoStruct> GetTableInfo(string AllTexts)
        {
            //string[] AllLines = File.ReadAllLines(sPath, Encoding.Default);
            //读取文件中每个表的信息,表名称,表字段,字段值
            List<SqlFileInfoStruct> list_sqlfileinfo = new List<SqlFileInfoStruct>();

            Regex regex_text = new Regex(@"insert into[\s\S]+?;", RegexOptions.IgnoreCase);

            //整个表
            MatchCollection mc_text = regex_text.Matches(AllTexts);

            if (mc_text.Count > 0)
            {
                foreach (Match match in mc_text)
                {
                    SqlFileInfoStruct sqlFileInfoStruct = new SqlFileInfoStruct();
                    sqlFileInfoStruct.Text = match.Value;

                    //获取表其他信息
                    GetOtherTableInfo(sqlFileInfoStruct, match.Value);
                    //Console.WriteLine(match.Value);

                    list_sqlfileinfo.Add(sqlFileInfoStruct);
                }
            }

            return list_sqlfileinfo;
        }


        /// <summary>
        /// 匹配sql字段数据
        /// </summary>
        /// <param name="sqlFileInfoStruct">sql文件类</param>
        /// <param name="Text">tablename</param>
        public void GetOtherTableInfo(SqlFileInfoStruct sqlFileInfoStruct, string Text)
        {
            Regex regex_tablename = new Regex(@"(?<=insert into).*?(?=\()", RegexOptions.IgnoreCase);
            Regex regex_field = new Regex(@"(?<=insert into.*?\().*?(?=\))", RegexOptions.IgnoreCase);
            Regex regex_value = new Regex(@"(?<=\().*?(?=\)[,;])", RegexOptions.IgnoreCase);

            //表名
            Match match_tablename = regex_tablename.Match(Text);

            if (match_tablename.Success)
            {
                sqlFileInfoStruct.TableName = match_tablename.Value.Replace(" ", "");
            }
            //表字段
            Match match_field = regex_field.Match(Text);

            if (match_field.Success)
            {
                foreach (string str in match_field.Value.Split(','))
                {
                    //去除标点符号
                    string newstr = Regex.Replace(str, @"[\s\`]", "");
                    sqlFileInfoStruct.Field.Add(newstr);
                }
            }
            //表字段值
            MatchCollection mc_value = regex_value.Matches(Text);
            for (int i = 0; i < mc_value.Count; i++)
            {
                //过滤下字符串，如果字符串中包含","需要处理
                var strlist = SplitStringWithComma(mc_value[i].Value);
                List<string> values = new List<string>();
                foreach (var str in strlist)
                {
                    values.Add(str);
                }
                sqlFileInfoStruct.Value.Add(i, values);
            }
        }

        /// <summary>
        /// 判断field中是否有关键字，给他加``符号
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public List<string> GetFieldKeyWords(List<string> list)
        {
            FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "\\ini\\SqlKeywords.ini", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.Default);
            var keywords = sr.ReadToEnd().Split(new string[] { "\r\n" }, StringSplitOptions.None);
            var NewList = CreateDeepCopy(list);
            foreach (var keyword in keywords)
            {
                foreach (var field in list)
                {
                    if (string.Equals(field, keyword, StringComparison.CurrentCultureIgnoreCase))
                    {
                        NewList[list.IndexOf(field)] = "`" + field + "`";
                    }
                }
            }

            return NewList;
        }


        /// <summary>
        /// clone
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T CreateDeepCopy<T>(T obj)
        {
            T t;
            MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(memoryStream, obj);
            memoryStream.Position = 0;
            t = (T)formatter.Deserialize(memoryStream);
            return t;
        }

        /// <summary>
        /// 以逗号拆分字符串
        /// 若字段中包含逗号(备注：包含逗号的字段必须有单引号引用)则对其进行拼接处理
        /// 最后在去除其字段的双引号
        /// </summary>
        /// <param name="splitStr"></param>
        /// <returns></returns>
        public static string[] SplitStringWithComma(string splitStr)
        {
            var newstr = string.Empty;
            var sList = new List<string>();

            var isSplice = false;
            var array = splitStr.Split(new char[] { ',' });
            foreach (var str in array)
            {
                if (!string.IsNullOrEmpty(str) && str.IndexOf('\'') > -1)
                {
                    var firstchar = str.Substring(0, 1);
                    var lastchar = string.Empty;
                    if (str.Length > 0)
                    {
                        lastchar = str.Substring(str.Length - 1, 1);
                    }
                    if (firstchar.Equals("\'") && !lastchar.Equals("\'"))
                    {
                        isSplice = true;
                    }
                    if (lastchar.Equals("\'"))
                    {
                        if (!isSplice)
                            newstr += str;
                        else
                            newstr = newstr + "," + str;

                        isSplice = false;
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(newstr))
                        newstr += str;
                }

                if (isSplice)
                {
                    //添加因拆分时丢失的逗号
                    if (string.IsNullOrEmpty(newstr))
                        newstr += str;
                    else
                        newstr = newstr + "," + str;
                }
                else
                {
                    sList.Add(newstr.Trim());//去除字符中的单引号和首尾空格
                    newstr = string.Empty;
                }
            }
            return sList.ToArray();
        }

    }




    /// <summary>
    /// sql文件类 用于存插入表的信息
    /// </summary>
    class SqlFileInfoStruct
    {
        //表
        public string Text = "";

        //表名
        public string TableName = "";

        //表字段集合
        public List<string> Field = new List<string>();

        //表字段值集合
        public Dictionary<int, List<string>> Value = new Dictionary<int, List<string>>();



    }
}
