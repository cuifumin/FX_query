using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace weihu_fx
{
    class SqlDAO
    {
        public static StringBuilder exceptionMsg;

        public static DataSet getDataSet(string conStr, string sql, string tableName)
        {
            DataSet dataSet = new DataSet();
            SqlConnection con = ConnectionUtil.getConn(conStr);
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);

            try
            {
                con.Open();
                adapter.Fill(dataSet, tableName);

                return dataSet;
            }
            catch (Exception e)
            {
                exceptionMsg = new StringBuilder().AppendLine("exception message : " + e.Message).AppendLine("exception stacktrace : " + e.StackTrace).AppendLine("connect string : " + conStr).AppendLine("sql : " + sql);
                return null;
            }
            finally
            {
                ConnectionUtil.closeConn(con);
            }
        }
    
    }
}
