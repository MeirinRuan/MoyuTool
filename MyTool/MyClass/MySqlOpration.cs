using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

namespace MyTool
{
    class MySqlOpration
    {
        //连接数据库字符串
        public string GetMySqlConnectstring(List<string> Sqlinfo)
        {
            string ConnectText = string.Format("Server={0};Uid={1};Pwd={2};Database={3};Port={4};",Sqlinfo[0], Sqlinfo[1], Sqlinfo[2], Sqlinfo[3], Sqlinfo[4]);
            return ConnectText;
        }

        //连接数据库
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

        //执行语句 用于返回dataset
        public DataSet MySqlCommand_GetDataSet(List<string> Sqlinfo,string sText)
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

        //执行语句 用于返回单个表第几个字段信息的查询结果
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

        //执行语句 用于返回单个表全部字段信息的查询结果
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
                for (int i = 0; i < j; i ++)
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

        //读取sql文件,返回插入的表信息
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


        //匹配sql字段数据
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
            for (int i= 0; i < mc_value.Count; i++)
            {
                List<string> values = new List<string>();
                foreach (string str in mc_value[i].Value.Split(','))
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
    }




    //sql文件的类 用于存插入表的信息
    class SqlFileInfoStruct
    {
        //表
        public string Text = "";

        //表名
        public string TableName = "";

        //表字段集合
        public List<string> Field = new List<string>();

        //表字段值集合
        public Dictionary<int,List<string>> Value = new Dictionary<int, List<string>>();



    }
}
