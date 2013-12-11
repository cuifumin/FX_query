using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1Chart;

namespace weihu_fx
{
    public partial class ShowAlarmData : Form
    {
        #region ���Զ���

        private static string conStr;

        private static string conStr2;

        private static string conStr3;

        private DataSet dsdata = new DataSet();

        private static string baseTableName = "test";

        private string positionName;

        private StringBuilder sql = new StringBuilder(100);

        private DateTime dtStart;

        private DateTime dtEnd;

        #endregion

        #region ��������

        public ShowAlarmData()
        {
            InitializeComponent();
        }

        public ShowAlarmData(string positionname, DateTime dtStart, DateTime dtEnd, int type)
        {
            InitializeComponent();

            initMsg();
            this.Text = "��������:" + positionname + "(" + dtStart + "��" + dtEnd + ")";
            this.TopMost = true;

            this.dtStart = dtStart;
            this.dtEnd = dtEnd;
            positionName = positionname;
            queryWindHistory(positionName);

            dgvResult2.DataSource = dsdata;
            dgvResult2.DataMember = baseTableName;
            if (type == 3)
            {
                creatChart_Line(chartLine_time, 0, dsdata, baseTableName, "ʱ��", "����(m/s)");
            }
            else
            {
                dgvResult2.Visible = true;
                chartLine_time.Visible = false;
                btnLine.Enabled = false;
            }
        }

        private void ShowAlarmData_Load(object sender, EventArgs e)
        {
        }

        private void initMsg()
        {
            baseTableName = "test";
            try
            {
                conStr = System.Configuration
                    .ConfigurationManager.ConnectionStrings["connectString"]
                    .ToString();
            }
            catch (Exception)
            {
                conStr = ConnectionUtil.conStr1;
            }
            try
            {
                conStr2 = System.Configuration
                    .ConfigurationManager.ConnectionStrings["connectString2"]
                    .ToString();
            }
            catch (Exception)
            {
                conStr = ConnectionUtil.conStr2;
            }
            try
            {
                conStr3 = System.Configuration
                    .ConfigurationManager.ConnectionStrings["connectString3"]
                    .ToString();
            }
            catch (Exception)
            {
                conStr = ConnectionUtil.conStr3;
            }
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            dgvResult2.Visible = false;
            chartLine_time.Visible = true;
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            dgvResult2.Visible = true;
            chartLine_time.Visible = false;
        }

        public static void creatChart_Line(C1Chart c1c, int series, DataSet dataSource, string tablename, string strTimeCol, string strVCol)
        {
            int rowNum = dataSource.Tables[tablename].Rows.Count;
            if (rowNum == 0)
            {
                //MessageBox.Show("���������ļ�¼��Ϊ�㣬������ѡ���ѯ����");
                return;
            }

            DateTime[] x = new DateTime[rowNum];
            Single[] y = new Single[rowNum];

            for (int i = 0; i < rowNum; i++)
            {
                x[i] = DateTime.Parse(dataSource.Tables[tablename].Rows[rowNum - 1 - i][strTimeCol].ToString());
                y[i] = Convert.ToSingle(dataSource.Tables[tablename].Rows[rowNum - 1 - i][strVCol]);
            }

            ChartDataSeries Series = c1c.ChartGroups.Group0.ChartData.SeriesList[series];
            Series.X.CopyDataIn(x);
            Series.Y.CopyDataIn(y);

            double tempV = 0;

            for (int i = 0; i < rowNum; i++)
            {
                if (y[i] > tempV)
                {
                    tempV = y[i];
                }
            }

            c1c.ChartArea.AxisX.SetMinMax(x[0], x[rowNum - 1]);
            c1c.ChartArea.AxisY.SetMinMax(0, (tempV / 10 + 1) * 10);

            c1c.ChartArea.AxisX.Text = strTimeCol;
            c1c.ChartArea.AxisY.Text = strVCol;
        }

        private DataSet queryHistory(string positionName)
        {
            DataSet newDataSet = null;

            if (dtStart.CompareTo(DateTime.Now.AddDays(-10)) > 0)
            {
                //Console.WriteLine("��ȶ������10����");
                newDataSet = queryHistoryNewData(positionName);
                if (newDataSet == null)
                {
                    return newDataSet;
                }
            }
            else if (dtEnd.CompareTo(DateTime.Now.AddDays(-10)) < 0)
            {
                //Console.WriteLine("��ȶ���ԭʼ���ݿ���");
                newDataSet = queryHistoryOldData(positionName);
                if (newDataSet == null)
                {
                    return newDataSet;
                }
            }
            else
            {
                //Console.WriteLine("�¾����ݿ��ж����в�ѯ����");
                newDataSet = queryHistoryNewData(positionName);
                if (newDataSet == null)
                {
                    return newDataSet;
                }

                string tableName = StringUtil.getHistoryTableName(positionName, dtStart);
                string sql = "select * from " + tableName + " where datetime>='" + dtStart + "' and datetime<='" + dtEnd + "' order by datetime";
                DataSet dataSet = SqlDAO.getDataSet(conStr2, sql, tableName);

                if (dataSet == null)
                {
                    return newDataSet;
                }
                int cntCol = dataSet.Tables[tableName].Columns.Count - 2;
                foreach (DataRow row in dataSet.Tables[tableName].Rows)
                {
                    DataRow newRow = newDataSet.Tables[baseTableName].NewRow();
                    for (int i = 0; i < cntCol; i++)
                    {
                        if (i != 0)
                        {
                            newRow[i - 1] = row[i];
                        }
                    }

                    newDataSet.Tables[baseTableName].Rows.Add(newRow);
                }
            }

            dsdata = newDataSet;
            return dsdata;
        }

        private DataSet queryHistoryOldData(string positionName)
        {
            DataSet newDataSet = new DataSet();
            DataTable newTable = DataTemplateUtil.getWindHistoryTemplateTable(baseTableName);
            newDataSet.Tables.Add(newTable);

            try
            {
                if (dtStart.Month == dtEnd.Month)
                {
                    int type1 = StringUtil.getSuffixsIndex(dtStart);
                    int type2 = StringUtil.getSuffixsIndex(dtEnd);

                    string tableName = StringUtil.getHistoryTableName(positionName, dtStart);
                    string sql = "select * from " + tableName + " where datetime>='" + dtStart + "' and datetime<='" + dtEnd + "' order by datetime";
                    DataSet dataSet = SqlDAO.getDataSet(conStr2, sql, tableName);
                    if (dataSet == null)
                    {
                        return dataSet;
                    }
                    int cntCol = dataSet.Tables[tableName].Columns.Count - 2;
                    foreach (DataRow row in dataSet.Tables[tableName].Rows)
                    {
                        DataRow newRow = newDataSet.Tables[baseTableName].NewRow();
                        for (int i = 0; i < cntCol; i++)
                        {
                            if (i != 0)
                            {
                                newRow[i - 1] = row[i];
                            }
                        }

                        newDataSet.Tables[baseTableName].Rows.Add(newRow);
                    }

                    //��ͬѮ
                    if (type1 != type2)
                    {
                        tableName = StringUtil.getHistoryTableName(positionName, dtEnd);
                        sql = "select * from " + tableName + " where datetime>='" + dtStart + "' and datetime<='" + dtEnd + "' order by datetime";
                        dataSet = SqlDAO.getDataSet(conStr2, sql, tableName);

                        if (dataSet == null)
                        {
                            return dataSet;
                        }
                        cntCol = dataSet.Tables[tableName].Columns.Count - 2;
                        foreach (DataRow row in dataSet.Tables[tableName].Rows)
                        {
                            DataRow newRow = newDataSet.Tables[baseTableName].NewRow();
                            for (int i = 0; i < cntCol; i++)
                            {
                                if (i != 0)
                                {
                                    newRow[i - 1] = row[i];
                                }
                            }

                            newDataSet.Tables[baseTableName].Rows.Add(newRow);
                        }
                    }
                }
                //��ĩ�����³�
                else
                {
                    string tableName = StringUtil.getHistoryTableName(positionName, dtStart, 2);
                    string sql = "select * from " + tableName + " where datetime>='" + dtStart + "' and datetime<='" + dtEnd + "' order by datetime";
                    DataSet dataSet = SqlDAO.getDataSet(conStr2, sql, tableName);

                    if (dataSet == null)
                    {
                        return dataSet;
                    }
                    int cntCol = dataSet.Tables[tableName].Columns.Count - 2;
                    foreach (DataRow row in dataSet.Tables[tableName].Rows)
                    {
                        DataRow newRow = newDataSet.Tables[baseTableName].NewRow();
                        for (int i = 0; i < cntCol; i++)
                        {
                            if (i != 0)
                            {
                                newRow[i - 1] = row[i];
                            }
                        }

                        newDataSet.Tables[baseTableName].Rows.Add(newRow);
                    }

                    tableName = StringUtil.getHistoryTableName(positionName, dtEnd, 0);
                    sql = "select * from " + tableName + " where datetime>='" + dtStart + "' and datetime<='" + dtEnd + "' order by datetime";
                    dataSet = SqlDAO.getDataSet(conStr2, sql, tableName);

                    if (dataSet == null)
                    {
                        return dataSet;
                    }
                    cntCol = dataSet.Tables[tableName].Columns.Count - 2;
                    foreach (DataRow row in dataSet.Tables[tableName].Rows)
                    {
                        DataRow newRow = newDataSet.Tables[baseTableName].NewRow();
                        for (int i = 0; i < cntCol; i++)
                        {
                            if (i != 0)
                            {
                                newRow[i - 1] = row[i];
                            }
                        }

                        newDataSet.Tables[baseTableName].Rows.Add(newRow);
                    }
                }

                return newDataSet;
            }
            catch (Exception)
            {
                //Console.WriteLine(e.StackTrace);
                return null;
            }

        }

        //��ǰ����10���ڵ�����
        private DataSet queryHistoryNewData(string positionName)
        {
            string tableName = "feng_lishi_" + positionName;
            DataSet newDataSet = new DataSet();
            DataTable newTable = DataTemplateUtil.getWindHistoryTemplateTable(baseTableName);
            newDataSet.Tables.Add(newTable);

            string sql = "select * from " + tableName + " where datetime>='" + dtStart + "' and datetime<='" + dtEnd + "' order by datetime";
            DataSet dataSet = SqlDAO.getDataSet(conStr, sql, tableName);

            if (dataSet == null)
            {
                return dataSet;
            }
            int cntCol = dataSet.Tables[tableName].Columns.Count;
            foreach (DataRow row in dataSet.Tables[tableName].Rows)
            {
                DataRow newRow = newDataSet.Tables[baseTableName].NewRow();
                for (int i = 0; i < cntCol - 1; i++)
                {
                    if (i != 0)
                    {
                        newRow[i - 1] = row[i];
                    }
                }

                newDataSet.Tables[baseTableName].Rows.Add(newRow);
            }

            return newDataSet;
        }

        //����ʷ��ѯ���޸�3���ݿ��ѯ����
        private int queryWindHistory(string positionName)
        {
            //return queryHistory(positionName);

            DataSet newDataSet = null;
            DateTime dt = PositionAndStationUtil.getWindBeginDateTime(positionName);
            if (dtStart.CompareTo(dt) > 0)
            {
                //Console.WriteLine("���ݶ��������ݿ���");
                newDataSet = queryHistory(positionName);
                if (newDataSet == null)
                {
                    return 1;
                }
            }
            else if (dtEnd.CompareTo(dt) < 0)
            {
                //Console.WriteLine("���ݶ���ԭ���ݿ���");
                newDataSet = queryPreWindHistory(positionName);
                if (newDataSet == null)
                {
                    return 1;
                }
            }
            else
            {
                //Console.WriteLine("ԭ���ݿ�������ݿⶼ��");
                newDataSet = queryHistory(positionName);
                if (newDataSet == null)
                {
                    return 1;
                }
                DataSet temp = queryPreWindHistory(positionName);
                if (temp == null)
                {
                    return 1;
                }
                foreach (DataRow row in temp.Tables[0].Rows)
                {
                    DataRow newRow = newDataSet.Tables[0].NewRow();
                    newRow["ʱ��"] = row["ʱ��"];
                    newRow["����(m/s)"] = row["����(m/s)"];
                    newRow["����(��)"] = row["����(��)"];
                    newDataSet.Tables[0].Rows.Add(newRow);
                }
            }

            dsdata = newDataSet;
            return 0;
        }

        //����ʷ��ѯԭ���ݿ�
        private DataSet queryPreWindHistory(string positionName)
        {
            string tableName = "��ʷ���ݱ�" + positionName;
            DataSet newDataSet = new DataSet();
            DataTable newTable = DataTemplateUtil.getWindHistoryTemplateTable(baseTableName);
            newDataSet.Tables.Add(newTable);

            string sql = "select * from " + tableName + " where time>='" + dtStart + "' and time<='" + dtEnd + "' order by time";
            DataSet dataSet = SqlDAO.getDataSet(conStr3, sql, tableName);

            if (dataSet == null)
            {
                return dataSet;
            }

            foreach (DataRow row in dataSet.Tables[tableName].Rows)
            {
                DataRow newRow = newDataSet.Tables[baseTableName].NewRow();
                newRow["ʱ��"] = row["time"];
                newRow["����(m/s)"] = Double.Parse(row["velocity"].ToString()) / 10;
                newRow["����(��)"] = Double.Parse(row["direction"].ToString()) / 10;
                newDataSet.Tables[baseTableName].Rows.Add(newRow);
            }

            return newDataSet;
        }

        #endregion

        #region �����С����/��������¼�
        
        //��������¼�
        private void dgvResult2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgvResult2.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgvResult2.RowHeadersDefaultCellStyle.Font, rectangle,
                dgvResult2.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void ShowAlarmData_SizeChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn col in dgvResult2.Columns)
            {
                if ("ʱ��".Equals(col.Name))
                {
                    col.Width = 150;
                    col.DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                }
                else if ("����ǿ��(mm/h)".Equals(col.Name))
                {
                    col.Width = 150;
                    col.DefaultCellStyle.Format = "N1";
                }
                else if ("Сʱ������(mm/h)".Equals(col.Name))
                {
                    col.Width = 150;
                    col.DefaultCellStyle.Format = "N1";
                }
                else if ("24Сʱ������(mm)".Equals(col.Name))
                {
                    col.Width = 150;
                    col.DefaultCellStyle.Format = "N1";
                }
                else if ("����������(mm)".Equals(col.Name))
                {
                    col.Width = 150;
                    col.DefaultCellStyle.Format = "N1";
                }
                else if ("����(m/s)".Equals(col.Name))
                {
                    col.Width = 100;
                    col.DefaultCellStyle.Format = "N1";
                }
                else if ("����(��)".Equals(col.Name))
                {
                    col.Width = 100;
                    col.DefaultCellStyle.Format = "N1";
                }
                else if ("�¶�(��)".Equals(col.Name))
                {
                    col.Width = 100;
                    col.DefaultCellStyle.Format = "N1";
                }
                else if ("��ѹ(hPa)".Equals(col.Name))
                {
                    col.Width = 100;
                    col.DefaultCellStyle.Format = "N1";
                }
                else if ("ʪ��(%)".Equals(col.Name))
                {
                    col.Width = 100;
                    col.DefaultCellStyle.Format = "N1";
                }
                else
                {
                    col.Width = 120;
                }
            }
        }

        #endregion

    }
}