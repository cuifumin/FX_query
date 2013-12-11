using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace weihu_fx
{
    class DataTemplateUtil
    {
        #region 表结构模板

        //风历史数据表结构
        public static DataTable getWindHistoryTemplateTable(string tableName)
        {
            DataTable newTable = new DataTable(tableName);
            DataColumn newDataColumn = new DataColumn("时间", typeof(DateTime));
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("风速(m/s)", typeof(decimal));
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("风向(度)", typeof(decimal));
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("温度(℃)", typeof(decimal));
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("气压(hPa)", typeof(decimal));
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("湿度(%)", typeof(decimal));
            newTable.Columns.Add(newDataColumn);

            return newTable;
        }

        //风报警数据表结构
        public static DataTable getWindAlarmTemplateTable(string tableName)
        {
            DataTable newTable = new DataTable(tableName);
            DataColumn newDataColumn = new DataColumn("时间", typeof(DateTime));
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("监测点编号");
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("监测点K里程");
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("限速里程");
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("报警级别");
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("限速建议值");
            newTable.Columns.Add(newDataColumn);

            return newTable;
        }

        //基站开关量数据表结构
        public static DataTable getStationOnOffTemplateTable(string tableName)
        {
            DataTable newTable = new DataTable(tableName);
            DataColumn newDataColumn = new DataColumn("时间", typeof(DateTime));
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("基站名称");
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("设备名称");
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("信息类型");
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("信息状态");
            newTable.Columns.Add(newDataColumn);

            return newTable;
        }

        //异物报警数据表结构
        //异物输出数据表结构
        public static DataTable getDropAlarmTemplateTable(string tableName)
        {
            DataTable newTable = new DataTable(tableName);
            DataColumn newDataColumn = new DataColumn("时间", typeof(DateTime));
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("监测点名称");
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("设备名称");
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("信息类型");
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("信息状态");
            newTable.Columns.Add(newDataColumn);

            return newTable;
        }

        //同结构数据表拷贝
        public static void copyDT(DataSet ds1, string tableName1, DataSet ds2, string tableName2)
        {
            if (ds1.Tables[tableName1].Columns.Count != ds2.Tables[tableName2].Columns.Count)
            {
                return;
            }

            int colLength = ds1.Tables[tableName1].Columns.Count;
            foreach (DataRow row in ds2.Tables[tableName2].Rows)
            {
                DataRow newRow = ds1.Tables[tableName1].NewRow();
                for (int i = 0; i < colLength; i++)
                {
                    newRow[i] = row[i];
                }

                ds1.Tables[tableName1].Rows.Add(newRow);
            }
        }

        public static DataTable getWindTable(string tableName)
        {
            DataTable newTable = new DataTable(tableName);
            DataColumn newDataColumn = new DataColumn("风速(m/s)", typeof(decimal));
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("风向(度)", typeof(decimal));
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("温度(℃)", typeof(decimal));
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("气压(hPa)", typeof(decimal));
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("湿度(%)", typeof(decimal));
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("报警等级", typeof(int));
            newTable.Columns.Add(newDataColumn);

            return newTable;
        }
        #endregion
    
    }
}
