    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

namespace weihu_zx
{
    class clsData
    {
        public static DataSet PopulateDatasetTable(string strConnection, string strTableName, string strSQL, ref DataSet dsData)
        {

            DataTable dt = new DataTable();

            foreach (DataTable table in dsData.Tables)
            {
                if (table.TableName == strTableName)
                {
                    dsData.Tables.Remove(table);
                    dsData.AcceptChanges();
                    break;
                }
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    SqlDataAdapter daAdatper = new SqlDataAdapter(strSQL, conn);
                    conn.Open();
                    daAdatper.Fill(dsData, strTableName);
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception ex)
            {
                //if (clsCheckServerState.bServerAlive)
                //{
                //    clsErrList.insertErrRecord(clsCommon.serverTime, "clsData.PopulateDatasetTable", ex.Message+"/----/"+strSQL);
                //}
                MessageBox.Show(ex.Message, "clsData.PopulateDatasetTable");
            }

            return dsData;
        }

        public static void removeTableIfExist(ref DataSet dsData, string strTableName)
        {
            foreach (DataTable table in dsData.Tables)
            {
                if (table.TableName == strTableName)
                {
                    dsData.Tables.Remove(table);
                    dsData.AcceptChanges();
                    break;
                }
            }
        }

        public static DataSet PopulateDatasetTable(SqlConnection conn, string strTableName, string strSQL, ref DataSet dsData)
        {

            DataTable dt = new DataTable();
            foreach (DataTable table in dsData.Tables)
            {
                if (table.TableName == strTableName)
                {
                    table.Clear();
                }
            }

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlDataAdapter daAdatper = new SqlDataAdapter(strSQL, conn);
                daAdatper.Fill(dsData, strTableName);
            }
            catch (Exception ex)
            {
                if (clsCheckServerState.bServerAlive)
                {
                    clsErrList.insertErrRecord(clsCommon.serverTime, "clsCommon.PopulateDatasetTable", ex.Message);
                }
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return dsData;

        }
    
    }
}
