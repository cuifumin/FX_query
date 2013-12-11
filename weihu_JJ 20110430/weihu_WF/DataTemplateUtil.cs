using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace weihu_fx
{
    class DataTemplateUtil
    {
        #region ��ṹģ��

        //����ʷ���ݱ�ṹ
        public static DataTable getWindHistoryTemplateTable(string tableName)
        {
            DataTable newTable = new DataTable(tableName);
            DataColumn newDataColumn = new DataColumn("ʱ��", typeof(DateTime));
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("����(m/s)", typeof(decimal));
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("����(��)", typeof(decimal));
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("�¶�(��)", typeof(decimal));
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("��ѹ(hPa)", typeof(decimal));
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("ʪ��(%)", typeof(decimal));
            newTable.Columns.Add(newDataColumn);

            return newTable;
        }

        //�籨�����ݱ�ṹ
        public static DataTable getWindAlarmTemplateTable(string tableName)
        {
            DataTable newTable = new DataTable(tableName);
            DataColumn newDataColumn = new DataColumn("ʱ��", typeof(DateTime));
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("������");
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("����K���");
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("�������");
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("��������");
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("���ٽ���ֵ");
            newTable.Columns.Add(newDataColumn);

            return newTable;
        }

        //��վ���������ݱ�ṹ
        public static DataTable getStationOnOffTemplateTable(string tableName)
        {
            DataTable newTable = new DataTable(tableName);
            DataColumn newDataColumn = new DataColumn("ʱ��", typeof(DateTime));
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("��վ����");
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("�豸����");
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("��Ϣ����");
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("��Ϣ״̬");
            newTable.Columns.Add(newDataColumn);

            return newTable;
        }

        //���ﱨ�����ݱ�ṹ
        //����������ݱ�ṹ
        public static DataTable getDropAlarmTemplateTable(string tableName)
        {
            DataTable newTable = new DataTable(tableName);
            DataColumn newDataColumn = new DataColumn("ʱ��", typeof(DateTime));
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("��������");
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("�豸����");
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("��Ϣ����");
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("��Ϣ״̬");
            newTable.Columns.Add(newDataColumn);

            return newTable;
        }

        //ͬ�ṹ���ݱ���
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
            DataColumn newDataColumn = new DataColumn("����(m/s)", typeof(decimal));
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("����(��)", typeof(decimal));
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("�¶�(��)", typeof(decimal));
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("��ѹ(hPa)", typeof(decimal));
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("ʪ��(%)", typeof(decimal));
            newTable.Columns.Add(newDataColumn);
            newDataColumn = new DataColumn("�����ȼ�", typeof(int));
            newTable.Columns.Add(newDataColumn);

            return newTable;
        }
        #endregion
    
    }
}
