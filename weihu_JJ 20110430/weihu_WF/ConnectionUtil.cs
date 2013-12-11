using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace weihu_fx
{
    class ConnectionUtil
    {
        public static string conStr1 = "Data Source=192.168.1.14;Initial Catalog=京津城际防灾系统2010;Persist Security Info=True;User ID=sa;pwd=290142;connect timeout=15";

        public static string conStr2 = "Data Source=192.168.1.14;Initial Catalog=京津城际防灾历史数据;Persist Security Info=True;User ID=sa;pwd=290142;connect timeout=15";

        public static string conStr3 = "Data Source=192.168.1.14;Initial Catalog=京津城际防灾系统;Persist Security Info=True;User ID=sa;pwd=290142;connect timeout=15"; 

        public static SqlConnection getConn(string conStr)
        {
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(conStr);
            }
            catch (Exception)
            {
            }
            return conn;
        }

        public static void closeConn(SqlConnection conn)
        {
            try
            {
                conn.Close();
            }
            catch (Exception)
            {
            }
        }
    
    }
}
