using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1Chart;
using System.Configuration;
using System.IO;
using System.Data.SqlClient;

namespace weihu_fx
{
    public partial class QueryForm : Form
    {
        #region ���Զ���

        private static string conStr;

        private static string conStr2;

        private static string conStr3;

        private DataSet dsdata;

        private DateTime dtStart, dtEnd = new DateTime();

        private static string baseTableName;

        private int queryType = 1;

        private static string currentTableName;

        private static StringBuilder exceptionMsg;

        #endregion

        #region ��ʼ��

        public QueryForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtpStart.Value = DateTime.Now.AddMinutes(-10);
            dtpStart_ValueChanged(sender, e);
            dtpEnd_ValueChanged(sender, e);
            pnlMenuBar1_Click(this.pnlMenuBar1, new EventArgs());
            lbl_his_F_Click(this.lbl_his_F, new EventArgs());
            baseTableName = "test";

            initConStr();
            this.TopMost = true;
        }

        private void initConStr()
        {
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

        #endregion

        #region �˳��¼�

        private void QueryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("ȷ���˳���ʷ���ݲ�ѯ������", "�˳�", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                //ǿ���˳�
                System.Diagnostics.Process tt = System.Diagnostics.Process.GetProcessById(System.Diagnostics.Process.GetCurrentProcess().Id);
                tt.Kill();
            }

        }

        #endregion

        #region �����б�

        private void refresh_position_list_F_K(int startIndex)
        {
            lbl_Pname.Text = "�����";
            cbo_Pname.Items.Clear();
            for (int i = startIndex; i < PositionAndStationUtil.windPositionName.Length; i++)
            {
                cbo_Pname.Items.Add(PositionAndStationUtil.windPositionName[i]);
            }
            cbo_Pname.SelectedIndex = 0;
        }

        private void refresh_position_list_YW_BaseStationK()
        {
            lbl_Pname.Text = "�����վ";
            cbo_Pname.Items.Clear();
            for (int i = 0; i < PositionAndStationUtil.dropStationK.Length; i++)
            {
                cbo_Pname.Items.Add(PositionAndStationUtil.dropStationK[i]);
            }
            cbo_Pname.SelectedIndex = 0;
        }

        private void refresh_position_list_DZ_BaseStationK()
        {
            lbl_Pname.Text = "�����վ";
            cbo_Pname.Items.Clear();
            for (int i = 0; i < PositionAndStationUtil.str_DZ_postion_name.Length; i++)
            {
                cbo_Pname.Items.Add(PositionAndStationUtil.str_DZ_postion_name[i]);
            }
            cbo_Pname.SelectedIndex = 0;
        }

        private void refresh_position_list_YW_PositionK()
        {
            lbl_Pname.Text = "�������";
            cbo_Pname.Items.Clear();
            for (int i = 0; i < PositionAndStationUtil.bridge_name.Length; i++)
            {
                cbo_Pname.Items.Add(PositionAndStationUtil.bridge_name[i]);
            }
            cbo_Pname.SelectedIndex = 0;
        }

        private void refresh_position_list_DZ_PositionK()
        {
            lbl_Pname.Text = "�������";
            cbo_Pname.Items.Clear();
            for (int i = 0; i < PositionAndStationUtil.str_DZ_postion_name.Length; i++)
            {
                cbo_Pname.Items.Add(PositionAndStationUtil.str_DZ_postion_name[i]);
            }
            cbo_Pname.SelectedIndex = 0;
        }  

        private void refresh_position_list_F_BaseStationK()
        {
            lbl_Pname.Text = "���վ";
            cbo_Pname.Items.Clear();
            for (int i = 0; i < PositionAndStationUtil.windStationK.Length; i++)
            {
                cbo_Pname.Items.Add(PositionAndStationUtil.windStationK[i]);
            }
            cbo_Pname.SelectedIndex = 0;
        }

        private void refresh_position_list_ALL_BaseStationK()
        {
            lbl_Pname.Text = "��վ";
            cbo_Pname.Items.Clear();
            for (int i = 0; i < PositionAndStationUtil.allStationK.Length; i++)
            {
                cbo_Pname.Items.Add(PositionAndStationUtil.allStationK[i]);
            }
            cbo_Pname.SelectedIndex = 0;
        }

        private void refresh_position_list_F_JJFAndStation()
        {
            lbl_Pname.Text = "�ص�";
            cbo_Pname.Items.Clear();
            for (int i = 0; i < PositionAndStationUtil.windPositionName.Length; i++)
            {
                if (i == 0)
                {
                    cbo_Pname.Items.Add(PositionAndStationUtil.windPositionName[i]);
                }
                else
                {
                    cbo_Pname.Items.Add(PositionAndStationUtil.windPositionName[i] + " " + PositionAndStationUtil.windStationK[i]);
                }
            }
            cbo_Pname.SelectedIndex = 0;
        }

        private void refresh_position_list_F_BridgeAndStation()
        {
            lbl_Pname.Text = "�ص�";
            cbo_Pname.Items.Clear();
            for (int i = 0; i < PositionAndStationUtil.bridge_name.Length; i++)
            {
                if (i == 0)
                {
                    cbo_Pname.Items.Add(PositionAndStationUtil.bridge_name[i]);
                }
                else
                {
                    cbo_Pname.Items.Add(PositionAndStationUtil.bridge_name[i] + " " + PositionAndStationUtil.dropStationK[i]);
                }
            }
            cbo_Pname.SelectedIndex = 0;
        }

        private void refresh_position_list_F_All()
        {
            lbl_Pname.Text = "�ص�";
            cbo_Pname.Items.Clear();
            for (int i = 0; i < PositionAndStationUtil.windPositionName.Length; i++)
            {
                if (i == 0)
                {
                    cbo_Pname.Items.Add(PositionAndStationUtil.windPositionName[i]);
                }
                else
                {
                    cbo_Pname.Items.Add(PositionAndStationUtil.windPositionName[i] + " " + PositionAndStationUtil.windStationK[i]);
                }
            }
            for (int i = 1; i < PositionAndStationUtil.bridge_name.Length; i++)
            {
                cbo_Pname.Items.Add(PositionAndStationUtil.bridge_name[i] + " " + PositionAndStationUtil.dropStationK[i]);
            }
            cbo_Pname.SelectedIndex = 0;
        }

        #endregion

        #region ��ѯ��ť

        //��ѯ���ͼ��
        private bool preQuery()
        {
            if (queryType == 1)
            {
                if (!PositionAndStationUtil.isPositionName(1, cbo_Pname.Text))
                {
                    MessageBox.Show(cbo_Pname.Text + "���㲻���ڣ�");
                    return false;
                }
            }
            else if (queryType == 3)
            {
                if (!("ȫ��".Equals(cbo_Pname.Text) || PositionAndStationUtil.isPositionName(1, cbo_Pname.Text)))
                {
                    MessageBox.Show(cbo_Pname.Text + "���㲻���ڣ�");
                    return false;
                }
            }
            else if (queryType == 5)
            {
                if (!("ȫ��".Equals(cbo_Pname.Text) || PositionAndStationUtil.isPositionName(3, cbo_Pname.Text)))
                {
                    MessageBox.Show(cbo_Pname.Text + "���㲻���ڣ�");
                    return false;
                }
            }
            else if (queryType == 6)
            {
                if (!("ȫ��".Equals(cbo_Pname.Text) || PositionAndStationUtil.isBaseStationK(4, cbo_Pname.Text)))
                {
                    MessageBox.Show(cbo_Pname.Text + "��վ�����ڣ�");
                    return false;
                }
            }
            else if (queryType == 7)
            {
                if (!("ȫ��".Equals(cbo_Pname.Text) || PositionAndStationUtil.isBaseStationK(1, cbo_Pname.Text)))
                {
                    MessageBox.Show(cbo_Pname.Text + "��վ�����ڣ�");
                    return false;
                }
            }
            else if (queryType == 9)
            {
                if (!("ȫ��".Equals(cbo_Pname.Text) || PositionAndStationUtil.isBaseStationK(3, cbo_Pname.Text)))
                {
                    MessageBox.Show(cbo_Pname.Text + "��վ�����ڣ�");
                    return false;
                }
            }
            else if (queryType == 10)
            {
                if (!("ȫ��".Equals(cbo_Pname.Text) || PositionAndStationUtil.isPositionName(3, cbo_Pname.Text)))
                {
                    MessageBox.Show(cbo_Pname.Text + "���㲻���ڣ�");
                    return false;
                }
            }

            return true;
        }

        //ѡ���ѯ
        private int doQuery()
        {
            int intQuery = 1;

            if (queryType == 1)
            {
                intQuery = queryWindHistory();
            }
            else if (queryType == 3)
            {
                intQuery = queryWindAlarm();
            }           
            else if (queryType == 5)
            {
                intQuery = queryDropAlarm();
            }
            else if (queryType == 6)
            {
                intQuery = queryBaseStationAll();
            }
            else if (queryType == 7)
            {
                intQuery = queryBaseStationWind();
            }
            else if (queryType == 9)
            {
                intQuery = queryBaseStationDrop();
            }
            else if (queryType == 10)
            {
                intQuery = queryDropOutput();
            }
            else if (queryType == 11)
            {
                intQuery = queryMaxWindDay();
            }
            else if (queryType == 12)
            {
                intQuery = queryMaxWindMonth();
            }
            else if (queryType == 13)
            {
                intQuery = queryPreBaseStationWind();
            }
            else if (queryType == 14)
            {
                intQuery = queryPreBaseStationDrop();
            }
            else if (queryType == 15)
            {
                intQuery = queryPreDropAlarm();
            }
            else if (queryType == 16)
            {
                intQuery = queryPreAllAlarm();
            }
            else if (queryType == 21)
            {
                intQuery = queryEarthQuakeAlarm();
            }
            else if (queryType == 22)
            {
                intQuery = queryBaseStationEarthQuake();
            }
            else if (queryType == 23)
            {
                intQuery = queryEarthQuakeOutput();
            }

            return intQuery;
        }

        //��ѯ��ť�¼�
        private void btnQuery_Click(object sender, EventArgs e)
        {
            //���Ʋ�ѯ����
            if (queryType <= 10)
            {
                if (!checkDate())
                {
                    return;
                }
            }

            int intQuery = 1;
            exceptionMsg = new StringBuilder();
            if (preQuery())
            {
                Cursor = Cursors.WaitCursor;
                intQuery = doQuery();
                Cursor = Cursors.Default;
            }
            else
            {
                return;
            }

            //ִ�в�ѯ
            if (intQuery > 0)
            {
                //��ѯ���̳���
                //MessageBox.Show("��ѯʧ�ܣ��������ݿ���ٴβ�ѯ��");
                new ������ʾ(exceptionMsg, "��ѯʧ�ܣ��������ݿ���ٴβ�ѯ��").Show();
                return;
            }

            currentTableName = baseTableName;
            Cursor = Cursors.WaitCursor;

            btnShowDategridview.Enabled = true;
            //ˢ��dgdresult
            dgdResult.Columns.Clear();
            dgdResult.DataSource = dsdata;
            if (queryType < 13 || (queryType >= 21 && queryType <= 23))
            {
                dgdResult.DataMember = baseTableName;
            }

            if (queryType==3)
            {
                dgdResult.Columns["�������"].Visible = false;
            }

            if (queryType <= 10 || (queryType >= 21 && queryType <= 23))
            {
                if (dgdResult.Rows.Count != 0)
                {
                    dgdResult.Sort(dgdResult.Columns["ʱ��"], ListSortDirection.Ascending);
                }
                else
                {
                    MessageBox.Show("��ѯ���ؼ�¼Ϊ0����");
                }
            }
            else if (queryType == 13)
            {
                setPreBaseStationWind();
            }
            else if (queryType == 14)
            {
                setPreBaseStationDrop();
            }
            else if (queryType == 15)
            {
                setPreDropAlarm();
            }
            else if (queryType == 16)
            {
                setPreAllAlarm();
            }
            else
            {
                if (dgdResult.Rows.Count != 0)
                {
                    //dgdResult.Sort(dgdResult.Columns["����"], ListSortDirection.Ascending);
                }
                else
                {
                    MessageBox.Show("��ѯ���ؼ�¼Ϊ0����");
                }
            }

            if (dgdResult.Rows.Count >= 0 && dgdResult.Rows.Count <= 9999)
            {
                dgdResult.RowHeadersWidth = 41;
            }
            else if (dgdResult.Rows.Count > 10000)
            {
                dgdResult.RowHeadersWidth = 55;
            }

            //�ж�����ʾchart���Ǳ��
            //ֻ�в�ѯ������ʷ��¼ʱ��������ֵ��������ͼ��������ʾͼ�������������ʾ���
            if (queryType == 1)
            {
                btnShowChart.Enabled = true;
                if (dsdata.Tables[baseTableName].Rows.Count == 0)
                {
                    btnShowDategridview_Click(sender, e);
                }
                else
                {
                    btnShowChart_Click(sender, e);
                    creatChart_Line(chartLine_time, 0, dsdata, baseTableName, "ʱ��", "����(m/s)");
                }
            }
            else
            {
                btnShowChart.Enabled = false;
                btnShowDategridview_Click(sender, e);
            }
           
            QueryForm_SizeChanged(this, new EventArgs());

            Cursor = Cursors.Default;
        }

        #region ��ʷ���ݲ�ѯ

        private DataSet queryHistory(string positionName)
        {
            DataSet newDataSet = queryHistoryNewData(positionName);
            if (newDataSet == null)
            {
                exceptionMsg = SqlDAO.exceptionMsg;
                return null;
            }

            if (dtEnd.CompareTo(DateTime.Now.AddDays(-10)) < 0 || dtStart.CompareTo(DateTime.Now.AddDays(-10)) < 0)
            {
                DataSet oldDataSet = queryHistoryOldData(positionName);
                if (oldDataSet != null)
                {
                    foreach (DataRow row in oldDataSet.Tables[baseTableName].Rows)
                    {
                        DataRow newRow = newDataSet.Tables[baseTableName].NewRow();
                        for (int i = 0; i < oldDataSet.Tables[baseTableName].Columns.Count; i++)
                        {
                            newRow[i] = row[i];
                        }
                        newDataSet.Tables[baseTableName].Rows.Add(newRow);
                    }
                }
            }            

            return newDataSet;
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
                        exceptionMsg = SqlDAO.exceptionMsg;
                        return null;
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
                            exceptionMsg = SqlDAO.exceptionMsg;
                            return null;
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
                        exceptionMsg = SqlDAO.exceptionMsg;
                        return null;
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
                        exceptionMsg = SqlDAO.exceptionMsg;
                        return null;
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
            catch (Exception e)
            {
                //Console.WriteLine(e.StackTrace);
                exceptionMsg = new StringBuilder().AppendLine("exception message : " + e.Message).AppendLine("exception stacktrace : " + e.StackTrace);
                return null;
            }

        }

        //��ǰ����10���ڵ�����
        private DataSet queryHistoryNewData(string positionName)
        {
            string tableName = "feng_lishi_" + positionName;
            DataSet newDataSet = new DataSet();
            DataTable newTable= DataTemplateUtil.getWindHistoryTemplateTable(baseTableName);
            newDataSet.Tables.Add(newTable);

            string sql = "select * from " + tableName + " where datetime>='" + dtStart + "' and datetime<='" + dtEnd + "' order by datetime";
            DataSet dataSet = SqlDAO.getDataSet(conStr, sql, tableName);

            if (dataSet == null)
            {
                exceptionMsg = SqlDAO.exceptionMsg;
                return null;
            }
            int cntCol = dataSet.Tables[tableName].Columns.Count;
            foreach (DataRow row in dataSet.Tables[tableName].Rows)
            {
                DataRow newRow = newDataSet.Tables[baseTableName].NewRow();
                for (int i = 0; i < cntCol-1; i++)
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
        private int queryWindHistory()
        {
            string positionName = cbo_Pname.Text;
            DataSet newDataSet = new DataSet();
            DataTable newTable = DataTemplateUtil.getWindHistoryTemplateTable(baseTableName);
            newDataSet.Tables.Add(newTable);
            DataSet dataSet = queryPreWindHistory(positionName);
            if (dataSet == null)
            {
                exceptionMsg = SqlDAO.exceptionMsg;
                return 1;
            }

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                DataRow newRow = newDataSet.Tables[0].NewRow();
                newRow["ʱ��"] = row["ʱ��"];
                newRow["����(m/s)"] = row["����(m/s)"];
                newRow["����(��)"] = row["����(��)"];
                newDataSet.Tables[0].Rows.Add(newRow);
            }

            dataSet = queryHistory(positionName);
            if (dataSet != null)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    DataRow newRow = newDataSet.Tables[0].NewRow();
                    for (int i = 0; i < dataSet.Tables[0].Columns.Count; i++)
                    {
                        newRow[i] = row[i];
                    }
                    newDataSet.Tables[0].Rows.Add(newRow);
                }
            }

            dataSet = queryHistory20110430(positionName);
            if (dataSet != null)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    DataRow newRow = newDataSet.Tables[0].NewRow();
                    for (int i = 0; i < dataSet.Tables[0].Columns.Count; i++)
                    {
                        newRow[i] = row[i];
                    }
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

            if (dtEnd < DateTime.Parse("2011-4-30 15:00"))
            {
                return newDataSet;
            }

            string sql = "select * from " + tableName + " where time>='" + dtStart + "' and time<='" + dtEnd + "' order by time";
            DataSet dataSet = SqlDAO.getDataSet(conStr3, sql, tableName);

            if (dataSet == null)
            {
                exceptionMsg = SqlDAO.exceptionMsg;
                return null;
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

        //����ʷ��ѯ2011-04-30
        private DataSet queryHistory20110430(string positionName)
        {

            if (dtStart>DateTime.Parse("2011-4-30 18:00:00") )
            {
                return null;
            }

            string tableName = "feng_lishi_" + positionName + "_20110430";
            DataSet newDataSet = new DataSet();
            DataTable newTable = DataTemplateUtil.getWindHistoryTemplateTable(baseTableName);
            newDataSet.Tables.Add(newTable);

            string sql = "select * from " + tableName + " where datetime>='" + dtStart + "' and datetime<='" + dtEnd + "' order by datetime";
            DataSet dataSet = SqlDAO.getDataSet(conStr, sql, tableName);

            if (dataSet == null)
            {
                exceptionMsg = SqlDAO.exceptionMsg;
                return null;
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

        #endregion

        #region �������ݲ�ѯ

        //�籨����ѯԭ���ݿ�
        private int queryWindAlarm()
        {
            DataSet newDataSet = null;
            string positionName = cbo_Pname.Text;
            DateTime dt = PositionAndStationUtil.getWindBeginDateTime(positionName);
            if (dtStart.CompareTo(dt) > 0)
            {
                //Console.WriteLine("���ݶ��������ݿ���");
                newDataSet = queryPostWindAlarm(positionName);
                if (newDataSet == null)
                {
                    exceptionMsg = SqlDAO.exceptionMsg;
                    return 1;
                }
            }
            else if (dtEnd.CompareTo(dt) < 0)
            {
                //Console.WriteLine("���ݶ���ԭ���ݿ���");
                newDataSet = queryPreWindAlarm(positionName);
                if (newDataSet == null)
                {
                    exceptionMsg = SqlDAO.exceptionMsg;
                    return 1;
                }
            }
            else
            {
                //Console.WriteLine("ԭ���ݿ�������ݿⶼ��");
                newDataSet = queryPostWindAlarm(positionName);
                if (newDataSet == null)
                {
                    exceptionMsg = SqlDAO.exceptionMsg;
                    return 1;
                }

                DataSet temp = queryPreWindAlarm(positionName);
                if (temp == null)
                {
                    exceptionMsg = SqlDAO.exceptionMsg;
                    return 1;
                }
                foreach (DataRow row in temp.Tables[0].Rows)
                {
                    DataRow newRow = newDataSet.Tables[0].NewRow();
                    for (int i = 0; i < temp.Tables[0].Columns.Count; i++)
                    {
                        newRow[i] = row[i];
                    }
                    newDataSet.Tables[0].Rows.Add(newRow);
                }
            }

            dsdata = newDataSet;
            return 0;
        }

        private DataSet queryPostWindAlarm(string positionName)
        {
            DataSet newDataSet = new DataSet();
            DataTable newTable = DataTemplateUtil.getWindAlarmTemplateTable(baseTableName);

            string tableName = "alarmLevel_F";
            string sql;
            if ("ȫ��".Equals(positionName))
            {
                sql = "select * from " + tableName + " where datetime>='" + dtStart + "' and datetime<='" + dtEnd + "'";
            }
            else
            {
                sql = "select * from " + tableName + " where windID = '" + positionName + "' and datetime>='" + dtStart + "' and datetime<='" + dtEnd + "'";
            }

            DataSet dataSet = SqlDAO.getDataSet(conStr, sql, tableName);

            if (dataSet == null)
            {
                exceptionMsg = SqlDAO.exceptionMsg;
                return null;
            }
            foreach (DataRow row in dataSet.Tables[tableName].Rows)
            {
                if (PositionAndStationUtil.isPositionName(1, row[2].ToString()))
                {
                    DataRow newRow = newTable.NewRow();
                    newRow[0] = row[1];
                    newRow[1] = row[2];
                    newRow[4] = row[3];
                    newRow[5] = row[4];

                    int index = PositionAndStationUtil.getWindPositionIndex(row[2].ToString());
                    newRow[2] = PositionAndStationUtil.windPositionK[index];
                    newRow["�������"] = PositionAndStationUtil.windPositionStartK[index] + " - " + PositionAndStationUtil.windPositionEndK[index];

                    newTable.Rows.Add(newRow);
                }
            }

            newDataSet.Tables.Add(newTable);
            return newDataSet;
        }

        private DataSet queryPreWindAlarm(string positionName)
        {
            DataSet newDataSet = new DataSet();
            DataTable newTable = DataTemplateUtil.getWindAlarmTemplateTable(baseTableName);

            string tableName = "���籨����¼��";
            string sql;
            if ("ȫ��".Equals(positionName))
            {
                sql = "select * from " + tableName + " where ʱ�� >='" + dtStart + "' and ʱ�� <='" + dtEnd + "'";
            }
            else
            {
                sql = "select * from " + tableName + " where �������� = '" + positionName + "' and ʱ�� >='" + dtStart + "' and ʱ�� <='" + dtEnd + "'";
            }

            DataSet dataSet = SqlDAO.getDataSet(conStr3, sql, tableName);

            if (dataSet == null)
            {
                exceptionMsg = SqlDAO.exceptionMsg;
                return null;
            }
            foreach (DataRow row in dataSet.Tables[tableName].Rows)
            {
                if (PositionAndStationUtil.isPositionName(1, row[2].ToString()))
                {
                    DataRow newRow = newTable.NewRow();
                    newRow["ʱ��"] = row["ʱ��"];
                    newRow["������"] = row["��������"];
                    newRow[4] = row[3];
                    newRow[5] = row[4];

                    int index = PositionAndStationUtil.getWindPositionIndex(row["��������"].ToString());
                    newRow["����K���"] = PositionAndStationUtil.windPositionK[index];
                    newRow["�������"] = PositionAndStationUtil.windPositionStartK[index] + " - " + PositionAndStationUtil.windPositionEndK[index];

                    newTable.Rows.Add(newRow);
                }
            }

            newDataSet.Tables.Add(newTable);
            return newDataSet;
        }

        //���ﱨ����ѯ
        private int queryDropAlarm()
        {
            DataSet newDataSet = new DataSet();
            DataTable newTable = DataTemplateUtil.getDropAlarmTemplateTable(baseTableName); 

            string tableName = "station_onoff_info_common";
            string sql, stationID = PositionAndStationUtil.getDropKByBridgeName(cbo_Pname.Text);
            if ("ȫ��".Equals(stationID))
            {
                sql = "select * from " + tableName + " where datetime>='" + dtStart + "' and datetime<='" + dtEnd + "' and byte_ID >= 10 and byte_ID <= 13 and thread_index>=2";
            }
            else
            {
                sql = "select * from " + tableName + " where station_ID = '" + stationID + "' and datetime>='" + dtStart + "' and datetime<='" + dtEnd + "' and byte_ID >= 10 and byte_ID <= 13 and thread_index>=2";
            }

            DataSet dataSet = SqlDAO.getDataSet(conStr, sql, tableName);

            if (dataSet == null)
            {
                exceptionMsg = SqlDAO.exceptionMsg;
                return 1;
            }
            int gridType = PositionAndStationUtil.getDropPositionGridType(stationID);
            int ioType = PositionAndStationUtil.getDropPositionIOType(stationID);
            int cntCol = dataSet.Tables[tableName].Columns.Count;
            foreach (DataRow row in dataSet.Tables[tableName].Rows)
            {
                if (PositionAndStationUtil.isBaseStationK(3, row[2].ToString()))
                {
                    string[] rowStr = new string[3];
                    try
                    {
                        if (gridType == 1)
                        {
                            rowStr = ConvertToChina.getDropAlarmState1("" + row["byte_ID"], "" + row["bit_ID"], "" + row["status"], ioType).Split(',');
                        }
                        else if (gridType == 2)
                        {
                            rowStr = ConvertToChina.getDropAlarmState2("" + row["byte_ID"], "" + row["bit_ID"], "" + row["status"], ioType).Split(',');
                        }
                        else if (gridType == 3)
                        {
                            rowStr = ConvertToChina.getDropAlarmState3("" + row["byte_ID"], "" + row["bit_ID"], "" + row["status"], ioType).Split(',');
                        }
                        else if (gridType == 4)
                        {
                            rowStr = ConvertToChina.getDropAlarmState4("" + row["byte_ID"], "" + row["bit_ID"], "" + row["status"], ioType).Split(',');
                        }
                        else if (gridType == 5)
                        {
                            rowStr = ConvertToChina.getDropAlarmState("" + row["byte_ID"], "" + row["bit_ID"], "" + row["status"]).Split(',');
                        }
                        else
                        {
                            throw new Exception("Error type, Cann't find dropPositionName type!");
                        }
                    }
                    catch (Exception)
                    {
                        rowStr = null;
                    }

                    if (rowStr != null && rowStr.Length == 3)
                    {
                        DataRow newRow = newTable.NewRow();
                        newRow["ʱ��"] = row["datetime"];
                        newRow["��������"] = PositionAndStationUtil.getBridgeNameByDropK(row["station_ID"].ToString());
                        newRow["�豸����"] = rowStr[0];
                        newRow["��Ϣ����"] = rowStr[1];
                        newRow["��Ϣ״̬"] = rowStr[2];
                        newTable.Rows.Add(newRow);
                    }
                }
            }

            newDataSet.Tables.Add(newTable);
            dsdata = newDataSet;
            return 0;
        }

        //���𱨾���ѯ
        private int queryEarthQuakeAlarm()
        {
            DataSet newDataSet = new DataSet();
            DataTable newTable = DataTemplateUtil.getDropAlarmTemplateTable(baseTableName);

            string tableName = "station_onoff_info_common";
            string sql, stationID = PositionAndStationUtil.getEarthQuakeKByEarthQuakeName(cbo_Pname.Text);
            if ("ȫ��".Equals(stationID))
            {
                sql = "select * from " + tableName + " where datetime>='" + dtStart + "' and datetime<='" + dtEnd 
                    + "' and (byte_ID = 12  or byte_ID = 3 or byte_ID = 5) and thread_index>=4";
            }
            else
            {
                sql = "select * from " + tableName + " where station_ID = '" + stationID + "' and datetime>='" + dtStart + "' and datetime<='" + dtEnd
                    + "' and (byte_ID = 12  or byte_ID = 3 or byte_ID = 5) and thread_index>=4";
            }

            DataSet dataSet = SqlDAO.getDataSet(conStr, sql, tableName);
            if (dataSet == null)
            {
                exceptionMsg = SqlDAO.exceptionMsg;
                return 1;
            }

            foreach (DataRow row in dataSet.Tables[tableName].Rows)
            {
                if ("12".Equals(row["byte_ID"].ToString()))
                {
                }
                else if ("3".Equals(row["byte_ID"].ToString()) && "3".Equals(row["bit_ID"].ToString()))
                {
                }
                else if ("5".Equals(row["byte_ID"].ToString()) && "3".Equals(row["bit_ID"].ToString()))
                {
                }
                else
                {
                    continue;
                }

                if (PositionAndStationUtil.isBaseStationK(2, row["station_ID"].ToString()))
                {
                    string[] rowStr = ConvertToChina.getEarthQuakeAlarmState("" + row["byte_ID"], "" + row["bit_ID"], "" + row["status"]).Split(',');
                    if (rowStr != null && rowStr.Length == 3)
                    {
                        DataRow newRow = newTable.NewRow();
                        newRow["ʱ��"] = row["datetime"];
                        newRow["��������"] = PositionAndStationUtil.getEarthQuakeNameByEarthQuakeK(row["station_ID"].ToString());
                        newRow["�豸����"] = rowStr[0];
                        newRow["��Ϣ����"] = rowStr[1];
                        newRow["��Ϣ״̬"] = rowStr[2];
                        newTable.Rows.Add(newRow);
                    }
                }
            }

            newDataSet.Tables.Add(newTable);
            dsdata = newDataSet;
            return 0;
        }

        #endregion

        #region ��վ��ѯ

        //ȫ����վ��Ϣ��ѯ
        private int queryBaseStationAll()
        {
            DataSet newDataSet = new DataSet();
            DataTable newTable = DataTemplateUtil.getStationOnOffTemplateTable(baseTableName);

            string tableName = "station_onoff_info_Common";
            string sql = "";
            string stationID = cbo_Pname.Text;
            if ("ȫ��".Equals(stationID))
            {
                sql = "select * from " + tableName + " where datetime>='" + dtStart + "' and datetime<='" + dtEnd + "'";
            }
            else
            {
                sql = "select * from " + tableName + " where station_ID = '" + stationID + "' and datetime>='" + dtStart + "' and datetime<='" + dtEnd + "'";
            }

            DataSet dataSet = SqlDAO.getDataSet(conStr, sql, tableName);
            if (dataSet == null)
            {
                exceptionMsg = SqlDAO.exceptionMsg;
                return 1;
            }

            foreach (DataRow row in dataSet.Tables[tableName].Rows)
            {
                string[] rowStr = null;
                if (row["thread_index"].ToString().Equals("0") || row["thread_index"].ToString().Equals("1"))
                {
                    if (("2".Equals(row["byte_ID"].ToString()) || "3".Equals(row["byte_ID"].ToString())) && ("4".Equals(row["bit_ID"].ToString())))
                    {
                        continue;
                    }
                    rowStr = ConvertToChina.getWindStationOnOffState("" + row["byte_ID"], "" + row["bit_ID"], "" + row["status"]).Split(',');
                }
                else if (row["thread_index"].ToString().Equals("2") || row["thread_index"].ToString().Equals("3"))
                {
                    rowStr = ConvertToChina.getDropStationOnOffState("" + row["byte_ID"], "" + row["bit_ID"], "" + row["status"]).Split(',');
                }
                else
                {
                    rowStr = ConvertToChina.getEarthQuakeStationOnOffState("" + row["byte_ID"], "" + row["bit_ID"], "" + row["status"]).Split(',');
                }

                DataRow newRow = newTable.NewRow();
                newRow["ʱ��"] = row["datetime"];
                newRow["��վ����"] = row["station_ID"];
                newRow["�豸����"] = rowStr[0];
                newRow["��Ϣ����"] = rowStr[1];
                newRow["��Ϣ״̬"] = rowStr[2];
                newTable.Rows.Add(newRow);
            }           

            newDataSet.Tables.Add(newTable);
            dsdata = newDataSet;
            return 0;
        }

        //���վ��Ϣ��ѯ
        private int queryBaseStationWind()
        {
            DataSet newDataSet = new DataSet();
            DataTable newTable = DataTemplateUtil.getStationOnOffTemplateTable(baseTableName);

            string tableName = "station_onoff_info_Common";
            string sql = "";
            string stationID = cbo_Pname.Text;
            if ("ȫ��".Equals(stationID))
            {
                sql = "select * from " + tableName+ " where datetime>='" + dtStart + "' and datetime<='" + dtEnd + "' and thread_index<2";
            }
            else
            {
                sql = "select * from " + tableName + " where station_ID = '" + stationID + "' and datetime>='" + dtStart + "' and datetime<='" + dtEnd + "' and thread_index<2";
            }

            DataSet dataSet = SqlDAO.getDataSet(conStr, sql, tableName);
            if (dataSet == null)
            {
                exceptionMsg = SqlDAO.exceptionMsg;
                return 1;
            }
            foreach (DataRow row in dataSet.Tables[tableName].Rows)
            {
                if (("2".Equals(row["byte_ID"].ToString()) || "3".Equals(row["byte_ID"].ToString())) && ("4".Equals(row["bit_ID"].ToString())))
                {
                    continue;
                }
                string[] rowStr = ConvertToChina.getWindStationOnOffState("" + row["byte_ID"], "" + row["bit_ID"], "" + row["status"]).Split(',');
                DataRow newRow = newTable.NewRow();
                newRow["ʱ��"] = row["datetime"];
                newRow["��վ����"] = row["station_ID"];
                newRow["�豸����"] = rowStr[0];
                newRow["��Ϣ����"] = rowStr[1];
                newRow["��Ϣ״̬"] = rowStr[2];
                newTable.Rows.Add(newRow);
            }

            newDataSet.Tables.Add(newTable);
            dsdata = newDataSet;
            return 0;
        }
      
        //�����վ��Ϣ��ѯ
        private int queryBaseStationDrop()
        {
            DataSet newDataSet = new DataSet();
            DataTable newTable = DataTemplateUtil.getStationOnOffTemplateTable(baseTableName);

            string tableName = "station_onoff_info_Common";
            string  sql;
            string stationID = cbo_Pname.Text;
            if ("ȫ��".Equals(stationID))
            {
                sql = "select * from " + tableName + " where datetime>='" + dtStart + "' and datetime<='" + dtEnd + "' and thread_index>= 2 and thread_index <= 3";
            }
            else
            {
                sql = "select * from " + tableName + " where station_ID = '" + stationID + "' and datetime>='" + dtStart + "' and datetime<='" + dtEnd + "' and thread_index>=2 and thread_index <= 4";
            }

            DataSet dataSet = SqlDAO.getDataSet(conStr, sql, tableName);
            if (dataSet == null)
            {
                exceptionMsg = SqlDAO.exceptionMsg;
                return 1;
            }

            foreach (DataRow row in dataSet.Tables[tableName].Rows)
            {
                string[] rowStr = ConvertToChina.getDropStationOnOffState("" + row["byte_ID"], "" + row["bit_ID"], "" + row["status"]).Split(',');
                DataRow newRow = newTable.NewRow();
                newRow["ʱ��"] = row["datetime"];
                newRow["��վ����"] = row["station_ID"];
                newRow["�豸����"] = rowStr[0];
                newRow["��Ϣ����"] = rowStr[1];
                newRow["��Ϣ״̬"] = rowStr[2];
                newTable.Rows.Add(newRow);
            }
           
            newDataSet.Tables.Add(newTable);
            dsdata = newDataSet;
            return 0;
        }

        //�����վ��Ϣ��ѯ
        private int queryBaseStationEarthQuake()
        {
            DataSet newDataSet = new DataSet();
            DataTable newTable = DataTemplateUtil.getStationOnOffTemplateTable(baseTableName);

            string tableName = "station_onoff_info_Common";
            string sql;
            string stationID = PositionAndStationUtil.getEarthQuakeKByEarthQuakeName(cbo_Pname.Text); ;
            if ("ȫ��".Equals(stationID))
            {
                sql = "select * from " + tableName + " where datetime>='" + dtStart + "' and datetime<='" + dtEnd + "' and thread_index >= 4";
            }
            else
            {
                sql = "select * from " + tableName + " where station_ID = '" + stationID + "' and datetime>='" + dtStart + "' and datetime<='" + dtEnd + "' and thread_index>=4";
            }

            DataSet dataSet = SqlDAO.getDataSet(conStr, sql, tableName);
            if (dataSet == null)
            {
                exceptionMsg = SqlDAO.exceptionMsg;
                return 1;
            }

            foreach (DataRow row in dataSet.Tables[tableName].Rows)
            {
                string[] rowStr = ConvertToChina.getEarthQuakeStationOnOffState("" + row["byte_ID"], "" + row["bit_ID"], "" + row["status"]).Split(',');
                DataRow newRow = newTable.NewRow();
                newRow["ʱ��"] = row["datetime"];
                newRow["��վ����"] = PositionAndStationUtil.getEarthQuakeNameByEarthQuakeK(row["station_ID"].ToString());
                newRow["�豸����"] = rowStr[0];
                newRow["��Ϣ����"] = rowStr[1];
                newRow["��Ϣ״̬"] = rowStr[2];
                newTable.Rows.Add(newRow);
            }

            newDataSet.Tables.Add(newTable);
            dsdata = newDataSet;
            return 0;
        }

        #endregion

        #region �����ѯ

        //���������ѯ
        private int queryDropOutput()
        {
            DataSet newDataSet = new DataSet();
            DataTable newTable = DataTemplateUtil.getDropAlarmTemplateTable(baseTableName);

            string tableName = "station_onoff_info_output_YW";
            string sql, stationID = PositionAndStationUtil.getDropKByBridgeName(cbo_Pname.Text);
            if ("ȫ��".Equals(stationID))
            {
                sql = "select * from " + tableName + " where datetime>='" + dtStart + "' and datetime<='" + dtEnd + "'";
            }
            else
            {
                sql = "select * from " + tableName + " where station_ID = '" + stationID + "' and datetime>='" + dtStart + "' and datetime<='" + dtEnd + "'";
            }

            DataSet dataSet = SqlDAO.getDataSet(conStr, sql, tableName);
            if (dataSet == null)
            {
                exceptionMsg = SqlDAO.exceptionMsg;
                return 1;
            }

            int ioType = PositionAndStationUtil.getDropPositionIOType(stationID);
            int cntCol = dataSet.Tables[tableName].Columns.Count;
            foreach (DataRow row in dataSet.Tables[tableName].Rows)
            {
                string[] rowStr = new string[3];

                try
                {
                    if (ioType == 1)
                    {
                        rowStr = ConvertToChina.getDropOutputState1("" + row["byte_ID"], "" + row["bit_ID"], "" + row["status"]).Split(',');
                    }
                    else if (ioType == 2)
                    {
                        rowStr = ConvertToChina.getDropOutputState2("" + row["byte_ID"], "" + row["bit_ID"], "" + row["status"]).Split(',');
                    }
                    else
                    {
                        rowStr = ConvertToChina.getDropOutputState("" + row["byte_ID"], "" + row["bit_ID"], "" + row["status"]).Split(',');
                    }
                }
                catch (Exception)
                {
                    rowStr = null;
                }

                if (rowStr != null && rowStr.Length == 3)
                {
                    DataRow newRow = newTable.NewRow();
                    newRow["ʱ��"] = row["datetime"];
                    newRow["��������"] = PositionAndStationUtil.getBridgeNameByDropK(row["station_ID"].ToString());
                    newRow["�豸����"] = rowStr[0];
                    newRow["��Ϣ����"] = rowStr[1];
                    newRow["��Ϣ״̬"] = rowStr[2];
                    newTable.Rows.Add(newRow);
                }
            }

            newDataSet.Tables.Add(newTable);
            dsdata = newDataSet;
            return 0;
        }

        //���������ѯ
        private int queryEarthQuakeOutput()
        {
            DataSet newDataSet = new DataSet();
            DataTable newTable = DataTemplateUtil.getDropAlarmTemplateTable(baseTableName);

            string tableName = "station_onoff_info_output_DZ";
            string sql, stationID = PositionAndStationUtil.getEarthQuakeKByEarthQuakeName(cbo_Pname.Text);
            if ("ȫ��".Equals(stationID))
            {
                sql = "select * from " + tableName + " where datetime>='" + dtStart + "' and datetime<='" + dtEnd + "'";
            }
            else
            {
                sql = "select * from " + tableName + " where station_ID = '" + stationID + "' and datetime>='" + dtStart + "' and datetime<='" + dtEnd + "'";
            }

            DataSet dataSet = SqlDAO.getDataSet(conStr, sql, tableName);
            if (dataSet == null)
            {
                exceptionMsg = SqlDAO.exceptionMsg;
                return 1;
            }

            int cntCol = dataSet.Tables[tableName].Columns.Count;
            foreach (DataRow row in dataSet.Tables[tableName].Rows)
            {
                string[] rowStr = ConvertToChina.getEarthQuakeOutputState("" + row["byte_ID"], "" + row["bit_ID"], "" + row["status"]).Split(',');

                if (rowStr != null && rowStr.Length == 3)
                {
                    DataRow newRow = newTable.NewRow();
                    newRow["ʱ��"] = row["datetime"];
                    newRow["��������"] = PositionAndStationUtil.getEarthQuakeNameByEarthQuakeK(row["station_ID"].ToString());
                    newRow["�豸����"] = rowStr[0];
                    newRow["��Ϣ����"] = rowStr[1];
                    newRow["��Ϣ״̬"] = rowStr[2];
                    newTable.Rows.Add(newRow);
                }
            }

            newDataSet.Tables.Add(newTable);
            dsdata = newDataSet;
            return 0;
        }

        #endregion

        #region ͳ�Ʋ�ѯ

        //�������ٲ�ѯ
        private int queryMaxWindDay()
        {
            string tableName = "feng_lishi_day_max";
            DateTime strDate = dtpStart.Value;
            DateTime endDate = dtpStart.Value;
            formatDateByDay(ref strDate, ref endDate);

            string sql = "select positionID,datetime,velocity from " + tableName + " where datetime>='" + strDate + "' and datetime<='" + endDate + "'";

            DataSet newDataSet = new DataSet();
            DataTable newTable = new DataTable(baseTableName);
            DataColumn newColumn = new DataColumn("����");
            newTable.Columns.Add(newColumn);
            newColumn = new DataColumn("ʱ��", typeof(DateTime));
            newTable.Columns.Add(newColumn);
            newColumn = new DataColumn("����ֵ(m/s)", typeof(decimal));
            newTable.Columns.Add(newColumn);
            newColumn = new DataColumn("�����ȼ�");
            newTable.Columns.Add(newColumn);

            DataSet dataSet = SqlDAO.getDataSet(conStr, sql, tableName);

            if (dataSet == null)
            {
                exceptionMsg = SqlDAO.exceptionMsg;
                return 1;
            }
            foreach (DataRow row in dataSet.Tables[tableName].Rows)
            {
                if (PositionAndStationUtil.isPositionName(1, row["positionID"].ToString()))
                {
                    DataRow newRow = newTable.NewRow();
                    newRow[0] = PositionAndStationUtil.getPositionKByName("wind", row["positionID"].ToString());
                    newRow[1] = row["datetime"];
                    newRow[2] = row["velocity"];
                    newRow[3] = getWindLevel(Convert.ToDouble(row["velocity"]));

                    newTable.Rows.Add(newRow);   
                }
            }

            newDataSet.Tables.Add(newTable);
            dsdata = newDataSet;
            return 0;
        }

        //�������ٲ�ѯ
        private int queryMaxWindMonth()
        {
            string tableName = "feng_lishi_month_max";
            DateTime strDate = dtpStart.Value;
            DateTime endDate = dtpStart.Value;
            formatDateByMonth(ref strDate, ref endDate);

            string sql = "select positionID,datetime,velocity from " + tableName +
                " where datetime>='" + strDate + "' and datetime<='" + endDate + "'";

            DataSet newDataSet = new DataSet();
            DataTable newTable = new DataTable(baseTableName);
            DataColumn newColumn = new DataColumn("����");
            newTable.Columns.Add(newColumn);
            newColumn = new DataColumn("ʱ��", typeof(DateTime));
            newTable.Columns.Add(newColumn);
            newColumn = new DataColumn("����ֵ(m/s)", typeof(decimal));
            newTable.Columns.Add(newColumn);
            newColumn = new DataColumn("�����ȼ�");
            newTable.Columns.Add(newColumn);

            DataSet dataSet = SqlDAO.getDataSet(conStr, sql, tableName);
            if (dataSet == null)
            {
                exceptionMsg = SqlDAO.exceptionMsg;
                return 1;
            }

            foreach (DataRow row in dataSet.Tables[tableName].Rows)
            {
                if (PositionAndStationUtil.isPositionName(1, row["positionID"].ToString()))
                {
                    DataRow newRow = newTable.NewRow();
                    newRow[0] = PositionAndStationUtil.getPositionKByName("wind", row["positionID"].ToString());
                    newRow[1] = row["datetime"];
                    newRow[2] = row["velocity"];
                    newRow[3] = getWindLevel(Convert.ToDouble(row["velocity"]));

                    newTable.Rows.Add(newRow);   
                }
            }

            newDataSet.Tables.Add(newTable);
            dsdata = newDataSet;
            return 0;
        }

        #endregion

        #region ԭ�����ݲ�ѯ

        //ԭ�з���ϸ澯��ʷ��¼��ѯ
        private int queryPreBaseStationWind()
        {
            string tableName = "�豸���ϸ澯��ʷ��¼��_����";
            string sql = "";
            string stationID = cbo_Pname.Text;
            if ("ȫ��".Equals(stationID))
            {
                sql = "select * from " + tableName + " where ����ʱ��>='" + dtStart + "' and ����ʱ��<='" + dtEnd + "'";
            }
            else
            {
                sql = "select * from " + tableName + " where �ص� = '" + stationID + "' and ����ʱ��>='" + dtStart + "' and ����ʱ��<='" + dtEnd + "'";
            }

            DataSet dataSet = SqlDAO.getDataSet(conStr3, sql, tableName);
            if (dataSet == null)
            {
                exceptionMsg = SqlDAO.exceptionMsg;
                return 1;
            }

            dsdata = dataSet;
            return 0;
        }

        private void setPreBaseStationWind()
        {
            currentTableName = "�豸���ϸ澯��ʷ��¼��_����";

            dgdResult.DataMember = "�豸���ϸ澯��ʷ��¼��_����";
            dgdResult.Columns["����ʱ��"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            dgdResult.Columns["����ʱ��"].Width = 180;
            dgdResult.Columns["�ָ�ʱ��"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            dgdResult.Columns["�ָ�ʱ��"].Width = 180;
            dgdResult.Columns["�澯��Ϣ"].Width = 200;
            dgdResult.Columns["�澯ԭ��"].Width = 200;
            dgdResult.Columns["�ص�"].Width = 150;
            dgdResult.Columns["ID"].Visible = false;
            dgdResult.Columns["��ע"].Visible = false;
        }

        //ԭ��������ϸ澯��ʷ��¼��ѯ
        private int queryPreBaseStationDrop()
        {
            string tableName = "�豸���ϸ澯��ʷ��¼��_����";
            string sql = "";
            string stationID = cbo_Pname.Text;
            if ("ȫ��".Equals(stationID))
            {
                sql = "select * from " + tableName + " where ����ʱ��>='" + dtStart + "' and ����ʱ��<='" + dtEnd + "'";
            }
            else
            {
                sql = "select * from " + tableName + " where �ص� = '" + stationID + "' and ����ʱ��>='" + dtStart + "' and ����ʱ��<='" + dtEnd + "'";
            }

            DataSet dataSet = SqlDAO.getDataSet(conStr3, sql, tableName);
            if (dataSet == null)
            {
                exceptionMsg = SqlDAO.exceptionMsg;
                return 1;
            }

            dsdata = dataSet;
            return 0;
        }

        private void setPreBaseStationDrop()
        {
            currentTableName = "�豸���ϸ澯��ʷ��¼��_����";

            dgdResult.DataMember = "�豸���ϸ澯��ʷ��¼��_����";
            dgdResult.Columns["����ʱ��"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            dgdResult.Columns["����ʱ��"].Width = 180;
            dgdResult.Columns["�ָ�ʱ��"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            dgdResult.Columns["�ָ�ʱ��"].Width = 180;
            dgdResult.Columns["�澯��Ϣ"].Width = 200;
            dgdResult.Columns["�澯ԭ��"].Width = 200;
            dgdResult.Columns["�ص�"].Width = 150;
            dgdResult.Columns["ID"].Visible = false;
            dgdResult.Columns["��ע"].Visible = false;
        }

        //ԭ���������ޱ�����¼��ѯ
        private int queryPreDropAlarm()
        {
            string tableName = "�������ޱ�����¼��";
            string sql = "";
            string stationID = cbo_Pname.Text;
            if ("ȫ��".Equals(stationID))
            {
                sql = "select * from " + tableName + " where ʱ��>='" + dtStart + "' and ʱ��<='" + dtEnd + "'";
            }
            else
            {
                sql = "select * from " + tableName + " where �������� = '" + stationID + "' and ʱ��>='" + dtStart + "' and ʱ��<='" + dtEnd + "'";
            }

            DataSet dataSet = SqlDAO.getDataSet(conStr3, sql, tableName);
            if (dataSet == null)
            {
                exceptionMsg = SqlDAO.exceptionMsg;
                return 1;
            }

            dsdata = dataSet;
            return 0;
        }

        private void setPreDropAlarm()
        {
            currentTableName = "�������ޱ�����¼��";

            dgdResult.DataMember = "�������ޱ�����¼��";
            dgdResult.Columns["ʱ��"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            dgdResult.Columns["ʱ��"].Width = 180;
            dgdResult.Columns["��Ϣ����"].Width = 200;
            dgdResult.Columns["��Ϣ����"].Width = 200;
            dgdResult.Columns["ID"].Visible = false;
            dgdResult.Columns["��ע"].Visible = false;
        }

        //ԭ��ͨ�Ź��ϱ�����ʷ��¼��ѯ
        private int queryPreAllAlarm()
        {
            string tableName = "ͨ�Ź��ϸ澯��ʷ��¼��";
            string sql = "";
            string stationID = cbo_Pname.Text;
            if ("ȫ��".Equals(stationID))
            {
                sql = "select * from " + tableName + " where ����ʱ��>='" + dtStart + "' and ����ʱ��<='" + dtEnd + "'";
            }
            else
            {
                sql = "select * from " + tableName + " where �ص� = '" + stationID + "' and ����ʱ��>='" + dtStart + "' and ����ʱ��<='" + dtEnd + "'";
            }

            DataSet dataSet = SqlDAO.getDataSet(conStr3, sql, tableName);
            if (dataSet == null)
            {
                exceptionMsg = SqlDAO.exceptionMsg;
                return 1;
            }

            dsdata = dataSet;
            return 0;
        }

        private void setPreAllAlarm()
        {
            currentTableName = "ͨ�Ź��ϸ澯��ʷ��¼��";

            dgdResult.DataMember = "ͨ�Ź��ϸ澯��ʷ��¼��";
            dgdResult.Columns["����ʱ��"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            dgdResult.Columns["����ʱ��"].Width = 180;
            dgdResult.Columns["�ָ�ʱ��"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            dgdResult.Columns["�ָ�ʱ��"].Width = 180;
            dgdResult.Columns["�澯��Ϣ"].Width = 200;
            dgdResult.Columns["�澯ԭ��"].Width = 200;
            dgdResult.Columns["�ص�"].Width = 150;
            dgdResult.Columns["ID"].Visible = false;
            dgdResult.Columns["��ע"].Visible = false;
        }

        #endregion

        #endregion

        #region ���ť/���߰�ť

        //���ť
        private void btnShowDategridview_Click(object sender, EventArgs e)
        {
            dgdResult.Visible = true;
            chartLine_time.Visible = false;
        }

        //���߰�ť
        private void btnShowChart_Click(object sender, EventArgs e)
        {
            dgdResult.Visible = false;
            chartLine_time.Visible = true;
        }

        #endregion

        #region �������Ƽ���ʽ

        private bool checkDate()
        {
            if (dateLimit1Second() == 1)
            {
                MessageBox.Show("��ֹʱ����������ʼʱ�䣡");
                return false;
            }
            if (queryType == 1 || queryType == 2)
            {
                if (dateLimitDay() == 1)
                {
                    MessageBox.Show("����ʱ�䷶Χ���ޣ���ʷ��¼�����Ϊ1�죡");
                    return false;
                }
            }
            else if (queryType == 3 || queryType == 5)
            {
                if (dateLimitYear() == 1)
                {
                    MessageBox.Show("����ʱ�䷶Χ���ޣ���ѯ�����Ϊ1�꣡");
                    return false;
                }
            } 
            else if (queryType <= 10)
            {
                if (dateLimitMonth() == 1)
                {
                    MessageBox.Show("����ʱ�䷶Χ���ޣ���ѯ�����Ϊ30�죡");
                    return false;
                }
            }

            return true;
        }

        private int dateLimitDay()
        {
            TimeSpan ts = dtpEnd.Value - dtpStart.Value;
            if (ts.Days <= 1)
            {
                return 0;
            }
            return 1;
        }

        private int dateLimitMonth()
        {
            TimeSpan ts = dtpEnd.Value - dtpStart.Value;
            if (ts.Days <= 30)
            {
                return 0;
            }
            return 1;
        }

        private int dateLimitYear()
        {
            TimeSpan ts = dtpEnd.Value - dtpStart.Value;
            if (ts.Days <= 365)
            {
                return 0;
            }
            return 1;
        }

        private int dateLimit1Second()
        {
            TimeSpan ts = dtpEnd.Value - dtpStart.Value;

            if (dtpEnd.Value.CompareTo(dtpStart.Value) <= 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        //�ر�ʱ��ѡ��ť
        private void closeChoose()
        {
            cbo_Pname.Enabled = false;
            dtpStart.Enabled = false;
            dtpEnd.Enabled = false;
        }

        //����ʱ��ѡ��ť
        private void openChoose()
        {
            label1.Text = "��ʼʱ��";
            label31.Text = "��ֹʱ��";
            dtpStart.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            cbo_Pname.Enabled = true;
            dtpStart.Enabled = true;
            dtpEnd.Enabled = true;
        }

        //��һʱ��ѡ��
        private void changeSingle()
        {
            label1.Text = "��ѯ����";
            cbo_Pname.Enabled = false;
            dtpStart.Enabled = true;
            dtpEnd.Enabled = false;
        }

        private void changeSingleDay()
        {
            dtpStart.CustomFormat = "yyyy-MM-dd";
            label1.Text = "��ѯ����";
            cbo_Pname.Enabled = false;
            dtpStart.Enabled = true;
            dtpEnd.Enabled = false;
        }

        private void changeSingleMonth()
        {
            dtpStart.CustomFormat = "yyyy-MM";
            label1.Text = "��ѯ����";
            cbo_Pname.Enabled = false;
            dtpStart.Enabled = true;
            dtpEnd.Enabled = false;
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            dtStart = dtpStart.Value;
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            dtEnd = dtpEnd.Value;
        }

        //����ת���ȼ�
        private string getWindLevel(double windSpeed)
        {

            if (windSpeed >= 0.0 && windSpeed <= 0.2)
            {
                return 0 + "��";
            }
            else if (windSpeed >= 0.3 && windSpeed <= 1.5)
            {
                return 1 + "��";
            }
            else if (windSpeed >= 1.6 && windSpeed <= 3.3)
            {
                return 2 + "��";
            }
            else if (windSpeed >= 3.4 && windSpeed <= 5.4)
            {
                return 3 + "��";
            }
            else if (windSpeed >= 5.5 && windSpeed <= 7.9)
            {
                return 4 + "��";
            }
            else if (windSpeed >= 8.0 && windSpeed <= 10.7)
            {
                return 5 + "��";
            }
            else if (windSpeed >= 10.8 && windSpeed <= 13.8)
            {
                return 6 + "��";
            }
            else if (windSpeed >= 13.9 && windSpeed <= 17.1)
            {
                return 7 + "��";
            }
            else if (windSpeed >= 17.2 && windSpeed <= 20.7)
            {
                return 8 + "��";
            }
            else if (windSpeed >= 20.8 && windSpeed <= 24.4)
            {
                return 9 + "��";
            }
            else if (windSpeed >= 24.5 && windSpeed <= 28.4)
            {
                return 10 + "��";
            }
            else if (windSpeed >= 28.5 && windSpeed <= 32.6)
            {
                return 11 + "��";
            }
            else if (windSpeed >= 32.7)
            {
                return 12 + "��";
            }
            else
            {
                return "��Чֵ";
            }

        }

        private void formatDateByDay(ref DateTime dt1, ref DateTime dt2)
        {
            dt1 = dt1.AddHours(-dt1.Hour);
            dt1 = dt1.AddMinutes(-dt1.Minute);
            dt1 = dt1.AddSeconds(-dt1.Second);

            dt2 = dt2.AddHours(-dt2.Hour);
            dt2 = dt2.AddMinutes(-dt2.Minute);
            dt2 = dt2.AddSeconds(-dt2.Second);
            dt2 = dt2.AddDays(1);
            dt2 = dt2.AddSeconds(-1);
        }

        private void formatDateByMonth(ref DateTime dt1, ref DateTime dt2)
        {
            dt1 = dt1.AddDays(-(dt1.Day - 1));
            dt1 = dt1.AddHours(-dt1.Hour);
            dt1 = dt1.AddMinutes(-dt1.Minute);
            dt1 = dt1.AddSeconds(-dt1.Second);

            dt2 = dt2.AddDays(-(dt2.Day - 1));
            dt2 = dt2.AddHours(-dt2.Hour);
            dt2 = dt2.AddMinutes(-dt2.Minute);
            dt2 = dt2.AddSeconds(-dt2.Second);
            dt2 = dt2.AddMonths(1);
            dt2 = dt2.AddSeconds(-1);
        }

        #endregion

        #region ��ѯ�˵���ť

        private void format_Pnl_Image(Panel pnl)
        {
            init_pnl_image(pnl_his_F);

            init_pnl_image(pnl_alarm_F);

            init_pnl_image(pnl_alarm_YW);
            init_pnl_image(pnl_alarm_DZ);


            init_pnl_image(pnl_equip_ALL);
            init_pnl_image(pnl_equip_F);
            init_pnl_image(pnl_equip_DZ);

            init_pnl_image(pnl_equip_YW);

            init_pnl_image(pnl_database_status);
            init_pnl_image(pnl_database_status_DZ);

            init_pnl_image(panel6);
            init_pnl_image(panel7);

            init_pnl_image(panel11);
            init_pnl_image(panel12);
            init_pnl_image(panel17);
            init_pnl_image(panel18);

            pnl.BackgroundImage = imageList1.Images[1];
        }

        private void init_pnl_image(Panel pnl)
        {
            if (pnl.BackgroundImage != imageList1.Images[0])
            {
                pnl.BackgroundImage = imageList1.Images[0];
            }
        }

        private void changeLab(object sender, EventArgs e)
        {
            System.Windows.Forms.Label lbl = (System.Windows.Forms.Label)sender;
            Panel pnl = (Panel)lbl.Parent;
            format_Pnl_Image(pnl);
        }

        private void changePnl(object sender, EventArgs e)
        {
            Panel pnl = (Panel)sender;
            format_Pnl_Image(pnl);
        }

        //��ʷ��ѯ
        private void lbl_his_F_Click(object sender, EventArgs e)
        {
            openChoose();
            changeLab(sender, e);
            queryType = 1;
            refresh_position_list_F_K(1);
        }

        private void pnl_his_F_Click(object sender, EventArgs e)
        {
            openChoose();
            changePnl(sender, e);
            queryType = 1;
            refresh_position_list_F_K(1);
        }

        //������ѯ
        private void lbl_alarm_F_Click(object sender, EventArgs e)
        {
            openChoose();
            changeLab(sender, e);
            queryType = 3;
            refresh_position_list_F_K(0);
        }

        private void pnl_alarm_F_Click(object sender, EventArgs e)
        {
            openChoose();
            changePnl(sender, e);
            queryType = 3;
            refresh_position_list_F_K(0);
        }

        private void lbl_alarm_YU_Click(object sender, EventArgs e)
        {
            openChoose();
            changeLab(sender, e);
            queryType = 4;
        }

        private void pnl_alarm_YU_Click(object sender, EventArgs e)
        {
            openChoose();
            changePnl(sender, e);
            queryType = 4;
        }

        private void lbl_alarm_YW_Click(object sender, EventArgs e)
        {
            openChoose();
            changeLab(sender, e);
            queryType = 5;
            refresh_position_list_YW_PositionK();
        }

        private void pnl_alarm_YW_Click(object sender, EventArgs e)
        {
            openChoose();
            changePnl(sender, e);
            queryType = 5;
            refresh_position_list_YW_PositionK();
        }

        private void pnl_alarm_DZ_Click(object sender, EventArgs e)
        {
            openChoose();
            changePnl(sender, e);
            queryType = 21;
            refresh_position_list_DZ_PositionK();
        }

        private void lbl_alarm_DZ_Click(object sender, EventArgs e)
        {
            openChoose();
            changeLab(sender, e);
            queryType = 21;
            refresh_position_list_DZ_PositionK();
        }

        //������Ϣ��ѯ
        private void lbl_eqiup_ALL_Click(object sender, EventArgs e)
        {
            openChoose();
            changeLab(sender, e);
            queryType = 6;
            refresh_position_list_ALL_BaseStationK();
        }

        private void pnl_equip_ALL_Click(object sender, EventArgs e)
        {
            openChoose();
            changePnl(sender, e);
            queryType = 6;
            refresh_position_list_ALL_BaseStationK();
        }

        private void lbl_equip_F_Click(object sender, EventArgs e)
        {
            openChoose();
            changeLab(sender, e);
            queryType = 7;
            refresh_position_list_F_BaseStationK();
        }

        private void pnl_equip_F_Click(object sender, EventArgs e)
        {
            openChoose();
            changePnl(sender, e);
            queryType = 7;
            refresh_position_list_F_BaseStationK();
        }     

        private void lbl_equip_YW_Click(object sender, EventArgs e)
        {
            openChoose();
            changeLab(sender, e);
            queryType = 9;
            refresh_position_list_YW_BaseStationK();
        }

        private void pnl_equip_YW_Click(object sender, EventArgs e)
        {
            openChoose();
            changePnl(sender, e);
            queryType = 9;
            refresh_position_list_YW_BaseStationK();
        }

        private void pnl_equip_DZ_Click(object sender, EventArgs e)
        {
            openChoose();
            changePnl(sender, e);
            queryType = 22;
            refresh_position_list_DZ_BaseStationK();
        }

        private void lbl_equip_DZ_Click(object sender, EventArgs e)
        {
            openChoose();
            changeLab(sender, e);
            queryType = 22;
            refresh_position_list_DZ_BaseStationK();
        }

        //�������
        private void lab_Output_YW_Click(object sender, EventArgs e)
        {
            openChoose();
            changeLab(sender, e);
            queryType = 10;
            refresh_position_list_YW_PositionK();
        }

        private void pnl_database_status_Click(object sender, EventArgs e)
        {
            openChoose();
            changePnl(sender, e);
            queryType = 10;
            refresh_position_list_YW_PositionK();
        }

        //�������
        private void pnl_database_status_DZ_Click(object sender, EventArgs e)
        {
            openChoose();
            changePnl(sender, e);
            queryType = 23;
            refresh_position_list_DZ_PositionK();
        }

        private void lab_Output_DZ_Click(object sender, EventArgs e)
        {
            openChoose();
            changeLab(sender, e);
            queryType = 23;
            refresh_position_list_DZ_PositionK();
        }

        //��������
        private void label7_Click(object sender, EventArgs e)
        {
            changeSingleDay();
            changeLab(sender, e);
            queryType = 11;
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            changeSingleDay();
            changePnl(sender, e);
            queryType = 11;
        }

        //��������
        private void label8_Click(object sender, EventArgs e)
        {
            changeSingleMonth();
            changeLab(sender, e);
            queryType = 12;
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            changeSingleMonth();
            changePnl(sender, e);
            queryType = 12;
        }

        //ԭ���ݲ�ѯ
        private void label11_Click(object sender, EventArgs e)
        {
            openChoose();
            changeLab(sender, e);
            queryType = 13;
            refresh_position_list_F_JJFAndStation();
        }

        private void panel11_Click(object sender, EventArgs e)
        {
            openChoose();
            changePnl(sender, e);
            queryType = 13;
            refresh_position_list_F_JJFAndStation();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            openChoose();
            changeLab(sender, e);
            queryType = 14;
            refresh_position_list_F_BridgeAndStation();
        }

        private void panel12_Click(object sender, EventArgs e)
        {
            openChoose();
            changePnl(sender, e);
            queryType = 14;
            refresh_position_list_F_BridgeAndStation();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            openChoose();
            changeLab(sender, e);
            queryType = 15;
            refresh_position_list_YW_PositionK();
        }

        private void panel17_Click(object sender, EventArgs e)
        {
            openChoose();
            changePnl(sender, e);
            queryType = 15;
            refresh_position_list_YW_PositionK();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            openChoose();
            changeLab(sender, e);
            queryType = 16;
            refresh_position_list_F_All();
        }

        private void panel18_Click(object sender, EventArgs e)
        {
            openChoose();
            changePnl(sender, e);
            queryType = 16;
            refresh_position_list_F_All();
        }

        #endregion

        #region ��������/��������¼�

        //��������
        public void creatChart_Line(C1Chart c1c, int series, DataSet dataSource, string tablename, string strTimeCol, string strVCol)
        {
            int rowNum = dataSource.Tables[tablename].Rows.Count;
            if (rowNum == 0)
            {
                MessageBox.Show("���������ļ�¼��Ϊ�㣬������ѡ���ѯ����");
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

        //��������¼�
        private void dgdResult_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgdResult.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgdResult.RowHeadersDefaultCellStyle.Font, rectangle,
                dgdResult.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);

        }

        #endregion

        #region �����С����

        private void QueryForm_SizeChanged(object sender, EventArgs e)
        {
            if ((queryType >= 1 && queryType <= 10) || (queryType >= 21 && queryType <= 23))
            {
                formatTotal();
            }
            else if (queryType == 11)
            {
                formatWindMaxDay();
            }
            else if (queryType == 12)
            {
                formatWindMaxMonth();
            }
        }

        private void formatTotal()
        {
            foreach (DataGridViewColumn col in dgdResult.Columns)
            {
                if ("ʱ��".Equals(col.Name))
                {
                    col.Width = 150;
                    col.DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
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
                else if ("�������".Equals(col.Name))
                {
                    col.Width = 150;
                    col.DefaultCellStyle.Format = "N1";
                }
                else if ("����".Equals(col.Name))
                {
                    col.Width = 140;
                    col.DefaultCellStyle.Format = "N1";
                }
                else if ("��������".Equals(col.Name))
                {
                    col.Width = 60;
                    col.DefaultCellStyle.Format = "N1";
                }
                else
                {
                    col.Width = 120;
                }
            }
        }

        private void formatWindMaxDay()
        {
            dgdResult.ColumnHeadersDefaultCellStyle.BackColor = Color.Yellow;

            foreach (DataGridViewColumn col in dgdResult.Columns)
            {
                if ("ʱ��".Equals(col.Name))
                {
                    col.Width = 125;
                    col.DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                    break;
                }
            }
        }

        private void formatWindMaxMonth()
        {
            dgdResult.ColumnHeadersDefaultCellStyle.BackColor = Color.Yellow;

            foreach (DataGridViewColumn col in dgdResult.Columns)
            {
                if ("ʱ��".Equals(col.Name))
                {
                    col.Width = 125;
                    col.DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                    break;
                }
            }
        }

        #endregion

        #region ȫ�����ݲ�ѯ

        private void dtpStart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Alt && e.KeyCode == Keys.S)
            {
                new ȫ�����ݲ�ѯ().Show();
            }
        }

        #endregion

        #region ���������

        private void dgdResult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if ( (queryType == 3 || queryType == 4) && (e.RowIndex >= 0) )
            {
                DateTime dtStart = new DateTime();
                DateTime dtEnd = new DateTime();
                DataGridView dgv = (DataGridView)sender;
                DataGridViewRow nowRow = dgv.Rows[e.RowIndex];

                if ("0".Equals(nowRow.Cells["��������"].Value.ToString()))
                {
                    dtEnd = Convert.ToDateTime(dgv.Rows[e.RowIndex].Cells["ʱ��"].Value.ToString()).AddMinutes(1);

                    if (e.RowIndex == 0)
                    {
                        dtStart = Convert.ToDateTime(dgv.Rows[e.RowIndex].Cells["ʱ��"].Value.ToString()).AddMinutes(-1);
                    }
                    else
                    {
                        for (int i = e.RowIndex - 1; i >= 0; i--)
                        {
                            if ("0".Equals(dgv.Rows[i].Cells["��������"].Value.ToString()))
                            {
                                dtStart = Convert.ToDateTime(dgv.Rows[i].Cells["ʱ��"].Value.ToString()).AddMinutes(-1);
                                break;
                            }
                            else if (i == 0)
                            {
                                dtStart = Convert.ToDateTime(dgv.Rows[i].Cells["ʱ��"].Value.ToString()).AddMinutes(-1);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    dtStart = Convert.ToDateTime(dgv.Rows[e.RowIndex].Cells["ʱ��"].Value.ToString()).AddMinutes(-1);
                    for (int i = e.RowIndex; i < dgv.Rows.Count; i++)
                    {
                        if ("0".Equals(dgv.Rows[i].Cells["��������"].Value.ToString()))
                        {
                            dtEnd = Convert.ToDateTime(dgv.Rows[i].Cells["ʱ��"].Value.ToString()).AddMinutes(1);
                            break;
                        }
                        else if (i == dgv.Rows.Count - 1)
                        {
                            dtEnd = Convert.ToDateTime(dgv.Rows[i].Cells["ʱ��"].Value.ToString()).AddMinutes(1);
                            break;
                        }
                    }
                }

                ShowAlarmData showAlarmData = new ShowAlarmData(nowRow.Cells[1].Value.ToString(), dtStart, dtEnd, queryType);

                showAlarmData.ShowDialog();
            }
        }
        
        #endregion

        #region ������Excel

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dsdata == null || dsdata.Tables.Count <= 0)
            {
                MessageBox.Show("���ݵ���ʧ�ܣ�ԭ���������ݵ���Excel�����ѯ�������ݣ�");
                return;
            }

            toExcel(dsdata);
            this.Activate();
            MessageBox.Show("����Excel���");
        }

        private void toExcel(DataSet ds)
        {
            Microsoft.Office.Interop.Excel.Application m_objExcel;

            // Start a new workbook in Excel.
            m_objExcel = new Microsoft.Office.Interop.Excel.Application();
            m_objExcel.Workbooks.Add(true);

            DataTable myDataTable = ds.Tables[currentTableName];
            int row = 2;
            m_objExcel.Visible = true;

            for (int i = 0; i < myDataTable.Columns.Count; i++)
            {
                m_objExcel.Cells[1, i + 1] = myDataTable.Columns[i].ColumnName.ToString();
            }

            for (int i = 0; i < myDataTable.Rows.Count; i++)
            {
                for (int j = 0; j < myDataTable.Columns.Count; j++)
                {
                    m_objExcel.Cells[row, j + 1] = myDataTable.Rows[i][j];
                }
                row++;
            }

            m_objExcel.Visible = true;

            System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objExcel);
            m_objExcel = null;
            GC.Collect();
        }
       
        #endregion

        #region �����˵�

        private void pnlMenuBar1_Click(object sender, EventArgs e)
        {
            pnlMenuBar1.SendToBack();
            pnlMenuBar1.Dock = DockStyle.Top;
            pnlMenuBar2.SendToBack();
            pnlMenuBar2.Dock = DockStyle.Bottom;
            pnlMenuBar3.SendToBack();
            pnlMenuBar3.Dock = DockStyle.Bottom;
            pnlMenuBar4.SendToBack();
            pnlMenuBar4.Dock = DockStyle.Bottom;
            pnlMenuBar5.SendToBack();
            pnlMenuBar5.Dock = DockStyle.Bottom;
            pnlMenuBar6.SendToBack();
            pnlMenuBar6.Dock = DockStyle.Bottom;

            pnlMenu2.SendToBack();
            pnlMenu3.SendToBack();
            pnlMenu4.SendToBack();
            pnlMenu5.SendToBack();
            pnlMenu6.SendToBack();

            pnlMenu1.BringToFront();
            pnlMenu1.Dock = DockStyle.Fill;

            pnl_his_F_Click(this.pnl_his_F, new EventArgs());
        }

        private void pnlMenuBar2_Click(object sender, EventArgs e)
        {
            pnlMenuBar2.SendToBack();
            pnlMenuBar2.Dock = DockStyle.Top;
            pnlMenuBar1.SendToBack();
            pnlMenuBar1.Dock = DockStyle.Top;
            pnlMenuBar3.SendToBack();
            pnlMenuBar3.Dock = DockStyle.Bottom;
            pnlMenuBar4.SendToBack();
            pnlMenuBar4.Dock = DockStyle.Bottom;
            pnlMenuBar5.SendToBack();
            pnlMenuBar5.Dock = DockStyle.Bottom;
            pnlMenuBar6.SendToBack();
            pnlMenuBar6.Dock = DockStyle.Bottom;

            pnlMenu1.SendToBack();
            pnlMenu3.SendToBack();
            pnlMenu4.SendToBack();
            pnlMenu5.SendToBack();
            pnlMenu6.SendToBack();

            pnlMenu2.BringToFront();
            pnlMenu2.Dock = DockStyle.Fill;

            pnl_alarm_F_Click(this.pnl_alarm_F, new EventArgs());
        }

        private void pnlMenuBar3_Click(object sender, EventArgs e)
        {
            pnlMenuBar3.SendToBack();
            pnlMenuBar3.Dock = DockStyle.Top;
            pnlMenuBar2.SendToBack();
            pnlMenuBar2.Dock = DockStyle.Top;
            pnlMenuBar1.SendToBack();
            pnlMenuBar1.Dock = DockStyle.Top;
            pnlMenuBar4.SendToBack();
            pnlMenuBar4.Dock = DockStyle.Bottom;
            pnlMenuBar5.SendToBack();
            pnlMenuBar5.Dock = DockStyle.Bottom;
            pnlMenuBar6.SendToBack();
            pnlMenuBar6.Dock = DockStyle.Bottom;

            pnlMenu1.SendToBack();
            pnlMenu2.SendToBack();
            pnlMenu4.SendToBack();
            pnlMenu5.SendToBack();
            pnlMenu6.SendToBack();

            pnlMenu3.BringToFront();
            pnlMenu3.Dock = DockStyle.Fill;

            pnl_equip_ALL_Click(this.pnl_equip_ALL, new EventArgs());
        }

        private void pnlMenuBar4_Click(object sender, EventArgs e)
        {
            pnlMenuBar4.SendToBack();
            pnlMenuBar4.Dock = DockStyle.Top;
            pnlMenuBar3.SendToBack();
            pnlMenuBar3.Dock = DockStyle.Top;
            pnlMenuBar2.SendToBack();
            pnlMenuBar2.Dock = DockStyle.Top;
            pnlMenuBar1.SendToBack();
            pnlMenuBar1.Dock = DockStyle.Top;
            pnlMenuBar5.SendToBack();
            pnlMenuBar5.Dock = DockStyle.Bottom;
            pnlMenuBar6.SendToBack();
            pnlMenuBar6.Dock = DockStyle.Bottom;

            pnlMenu1.SendToBack();
            pnlMenu2.SendToBack();
            pnlMenu3.SendToBack();
            pnlMenu5.SendToBack();
            pnlMenu6.SendToBack();

            pnlMenu4.BringToFront();
            pnlMenu4.Dock = DockStyle.Fill;

            pnl_database_status_Click(this.pnl_database_status, new EventArgs());
        }

        private void pnlMenuBar5_Click(object sender, EventArgs e)
        {
            pnlMenuBar5.SendToBack();
            pnlMenuBar5.Dock = DockStyle.Top;
            pnlMenuBar4.SendToBack();
            pnlMenuBar4.Dock = DockStyle.Top;
            pnlMenuBar3.SendToBack();
            pnlMenuBar3.Dock = DockStyle.Top;
            pnlMenuBar2.SendToBack();
            pnlMenuBar2.Dock = DockStyle.Top;
            pnlMenuBar1.SendToBack();
            pnlMenuBar1.Dock = DockStyle.Top;
            pnlMenuBar6.SendToBack();
            pnlMenuBar6.Dock = DockStyle.Bottom;

            pnlMenu1.SendToBack();
            pnlMenu2.SendToBack();
            pnlMenu3.SendToBack();
            pnlMenu4.SendToBack();
            pnlMenu6.SendToBack();

            pnlMenu5.BringToFront();
            pnlMenu5.Dock = DockStyle.Fill;

            panel6_Click(this.panel6, new EventArgs());
        }

        private void pnlMenuBar6_Click(object sender, EventArgs e)
        {
            pnlMenuBar6.SendToBack();
            pnlMenuBar6.Dock = DockStyle.Top;
            pnlMenuBar5.SendToBack();
            pnlMenuBar5.Dock = DockStyle.Top;
            pnlMenuBar4.SendToBack();
            pnlMenuBar4.Dock = DockStyle.Top;
            pnlMenuBar3.SendToBack();
            pnlMenuBar3.Dock = DockStyle.Top;
            pnlMenuBar2.SendToBack();
            pnlMenuBar2.Dock = DockStyle.Top;
            pnlMenuBar1.SendToBack();
            pnlMenuBar1.Dock = DockStyle.Top;

            pnlMenu1.SendToBack();
            pnlMenu2.SendToBack();
            pnlMenu3.SendToBack();
            pnlMenu4.SendToBack();
            pnlMenu5.SendToBack();

            pnlMenu6.BringToFront();
            pnlMenu6.Dock = DockStyle.Fill;

            panel11_Click(this.panel11, new EventArgs());
        }

        #endregion

    }
}