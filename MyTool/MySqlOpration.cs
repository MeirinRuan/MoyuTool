using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace MyTool
{
    class MySqlOpration
    {
        //初始化数据库信息
        public string[] sSqlinfo = new string[4];

        public string[] InitSqlInfo()
        {
            //server
            sSqlinfo[0] = "127.0.0.1";
            //user
            sSqlinfo[1] = "root";
            //password
            sSqlinfo[2] = "aaa";
            //database
            sSqlinfo[3] = "sjmy";

            return sSqlinfo;
        }

        //连接数据库
        public bool MySqlConncet(string[] sSqlinfo)
        {
            string sConnectText = string.Format("server={0};user id={1};password={2};database={3};port=3306",
                sSqlinfo[0], sSqlinfo[1], sSqlinfo[2], sSqlinfo[3]);
            //MessageBox.Show(sConnectText);
            MySqlConnection myConnection = new MySqlConnection(sConnectText);
            //DataSet ds = new DataSet();
            try
            {
                //string sText = "show databases";
                if (!myConnection.Ping())
                {
                    myConnection.Open();
                }

                //执行语句
                //MySqlDataAdapter command = new MySqlDataAdapter(sText, myConnection);
                //command.Fill(ds);
                //SqlDatabase_ListBox.DataSource = ds.Tables[0];
                //SqlDatabase_ListBox.DisplayMember = ds.Tables[0].Columns[0].ToString();
                return true;
            }
            catch (Exception ex)
            {
                myConnection.Close();
                //错误信息
                MessageBox.Show(ex.ToString());
                throw;
            }
            finally
            {
                //关闭连接
                myConnection.Close();
            }
        }

    }
}
