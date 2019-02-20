using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;

namespace MyTool
{
    class MySqlOpration
    {
        //连接数据库字符串
        public string GetMySqlConnectString(string[] Sqlinfo)
        {
            string ConnectText = string.Format("Server={0};Uid={1};Pwd={2};Database={3};Port=3306;",Sqlinfo[0], Sqlinfo[1], Sqlinfo[2], Sqlinfo[3]);
            return ConnectText;
        }

        //连接数据库
        public bool MySqlConncet(string[] Sqlinfo)
        {
            string ConnectText = GetMySqlConnectString(Sqlinfo);
            MySqlConnection conn = new MySqlConnection(ConnectText);
            try
            {
                //if (!myConnection.Ping())
                //{
                conn.Open();
                //}
                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                //错误信息
                MessageBox.Show(ex.ToString());
                throw;
            }
            finally
            {
                //关闭连接
                conn.Close();
            }
        }

        //执行语句 用于返回dataset
        public DataSet MySqlCommand_GetDataSet(string[] Sqlinfo,string sText)
        {
            string ConnectText = GetMySqlConnectString(Sqlinfo);
            MySqlConnection conn = new MySqlConnection(ConnectText);

            try
            {
                conn.Open();
                DataSet ds = new DataSet();
                MySqlDataAdapter command = new MySqlDataAdapter(sText, conn);
                command.Fill(ds);
                return ds;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                //关闭连接
                conn.Close();
            }
        }

        //执行语句 用于返回单个表第几个字段信息的查询结果
        public string MySqlCommand_GetNameIndex(string[] Sqlinfo, string SqlText, int Index)
        {
            string ConnectText = GetMySqlConnectString(Sqlinfo);
            MySqlConnection conn = new MySqlConnection(ConnectText);

            string str = "";

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(SqlText, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                str = reader.GetName(Index);

                return str;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                //关闭连接
                conn.Close();
            }
        }

        //执行语句 用于返回单个表全部字段信息的查询结果
        public List<String> MySqlCommand_GetAllField(String[] Sqlinfo, String SqlText)
        {
            String ConnectText = GetMySqlConnectString(Sqlinfo);
            MySqlConnection conn = new MySqlConnection(ConnectText);

            List<String> str = new List<String>();

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
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                //关闭连接
                conn.Close();
            }
        }

        //逐行读取sql文件,返回插入的表信息
        public List<SqlFileInfoStruct> GetTableInfo(String AllTexts)
        {
            //String[] AllLines = File.ReadAllLines(sPath, Encoding.Default);
            //读取文件中每个表的信息,表名称,表字段,字段值
            List<SqlFileInfoStruct> list_sqlfileinfo = new List<SqlFileInfoStruct>();

            Regex regex_tablename = new Regex(@"(?<=insert into).*?(?=\()", RegexOptions.IgnoreCase);
            Regex regex_field = new Regex(@"(?<=insert into.*?\().*?(?=\))", RegexOptions.IgnoreCase);
            Regex regex_value = new Regex(@"(?<=\().*?(?=\),)", RegexOptions.IgnoreCase);

            //表名
            Match match_tablename = regex_tablename.Match(AllTexts);
            if (match_tablename.Success)
            {
                SqlFileInfoStruct sqlFileInfoStruct = new SqlFileInfoStruct();
                sqlFileInfoStruct.TableName = match_tablename.Value;
            }
            //表字段
            Match match_field = regex_field.Match(AllTexts);
            if (match_field.Success)
            {
                match_field.Value.Split(',');
            }


            return list_sqlfileinfo;
        }


    }

    //sql文件的类 用于存插入表的信息
    class SqlFileInfoStruct
    {
        //表名
        public string TableName;

        //表字段集合
        public List<String> Field;

        //表字段值集合
        public List<String> Value;



    }
}
