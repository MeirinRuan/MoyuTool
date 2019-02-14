using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace MyTool
{
    class MySqlOpration
    {
        //初始化数据库信息
        public string[] sSqlinfo = new string[4];

        string sConnectText = "Server=192.168.19.38;Uid=root;Pwd=aaa;Port=3306;";

        //连接数据库的初始化信息
        public string[] InitSqlInfo()
        {
            //server
            sSqlinfo[0] = "192.168.19.38";
            //user
            sSqlinfo[1] = "root";
            //password
            sSqlinfo[2] = "aaa";
            //database
            //sSqlinfo[3] = "sjmy26";

            return sSqlinfo;
        }

        //连接数据库
        public bool MySqlConncet(string[] sSqlinfo)
        {
            //string sConnectText = string.Format("Server={0};Uid={1};Pwd={2};Port=3306;",
            //   sSqlinfo[0], sSqlinfo[1], sSqlinfo[2], sSqlinfo[3]);
            //MessageBox.Show(sConnectText);
            MySqlConnection conn = new MySqlConnection(sConnectText);
            //DataSet ds = new DataSet();
            try
            {
                //string sText = "show databases";
                //if (!myConnection.Ping())
                //{
                conn.Open();
                //}

                //执行语句
                //MySqlDataAdapter command = new MySqlDataAdapter(sText, myConnection);
                //command.Fill(ds);
                //SqlDatabase_ListBox.DataSource = ds.Tables[0];
                //SqlDatabase_ListBox.DisplayMember = ds.Tables[0].Columns[0].ToString();
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

        //执行语句
        public DataSet MySqlCommand_GetDataSet(string sText)
        {
            MySqlConnection conn = new MySqlConnection(sConnectText);
            //MySqlCommand cmd = new MySqlCommand();

            try
            {
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

    }
}
