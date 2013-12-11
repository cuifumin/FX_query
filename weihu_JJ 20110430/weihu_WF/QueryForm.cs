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
        #region 属性定义

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

        #region 初始化

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

        #region 退出事件

        private void QueryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确定退出历史数据查询程序吗？", "退出", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                //强制退出
                System.Diagnostics.Process tt = System.Diagnostics.Process.GetProcessById(System.Diagnostics.Process.GetCurrentProcess().Id);
                tt.Kill();
            }

        }

        #endregion

        #region 监测点列表

        private void refresh_position_list_F_K(int startIndex)
        {
            lbl_Pname.Text = "风监测点";
            cbo_Pname.Items.Clear();
            for (int i = startIndex; i < PositionAndStationUtil.windPositionName.Length; i++)
            {
                cbo_Pname.Items.Add(PositionAndStationUtil.windPositionName[i]);
            }
            cbo_Pname.SelectedIndex = 0;
        }

        private void refresh_position_list_YW_BaseStationK()
        {
            lbl_Pname.Text = "异物基站";
            cbo_Pname.Items.Clear();
            for (int i = 0; i < PositionAndStationUtil.dropStationK.Length; i++)
            {
                cbo_Pname.Items.Add(PositionAndStationUtil.dropStationK[i]);
            }
            cbo_Pname.SelectedIndex = 0;
        }

        private void refresh_position_list_DZ_BaseStationK()
        {
            lbl_Pname.Text = "地震基站";
            cbo_Pname.Items.Clear();
            for (int i = 0; i < PositionAndStationUtil.str_DZ_postion_name.Length; i++)
            {
                cbo_Pname.Items.Add(PositionAndStationUtil.str_DZ_postion_name[i]);
            }
            cbo_Pname.SelectedIndex = 0;
        }

        private void refresh_position_list_YW_PositionK()
        {
            lbl_Pname.Text = "异物监测点";
            cbo_Pname.Items.Clear();
            for (int i = 0; i < PositionAndStationUtil.bridge_name.Length; i++)
            {
                cbo_Pname.Items.Add(PositionAndStationUtil.bridge_name[i]);
            }
            cbo_Pname.SelectedIndex = 0;
        }

        private void refresh_position_list_DZ_PositionK()
        {
            lbl_Pname.Text = "地震监测点";
            cbo_Pname.Items.Clear();
            for (int i = 0; i < PositionAndStationUtil.str_DZ_postion_name.Length; i++)
            {
                cbo_Pname.Items.Add(PositionAndStationUtil.str_DZ_postion_name[i]);
            }
            cbo_Pname.SelectedIndex = 0;
        }  

        private void refresh_position_list_F_BaseStationK()
        {
            lbl_Pname.Text = "风基站";
            cbo_Pname.Items.Clear();
            for (int i = 0; i < PositionAndStationUtil.windStationK.Length; i++)
            {
                cbo_Pname.Items.Add(PositionAndStationUtil.windStationK[i]);
            }
            cbo_Pname.SelectedIndex = 0;
        }

        private void refresh_position_list_ALL_BaseStationK()
        {
            lbl_Pname.Text = "基站";
            cbo_Pname.Items.Clear();
            for (int i = 0; i < PositionAndStationUtil.allStationK.Length; i++)
            {
                cbo_Pname.Items.Add(PositionAndStationUtil.allStationK[i]);
            }
            cbo_Pname.SelectedIndex = 0;
        }

        private void refresh_position_list_F_JJFAndStation()
        {
            lbl_Pname.Text = "地点";
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
            lbl_Pname.Text = "地点";
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
            lbl_Pname.Text = "地点";
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

        #region 查询按钮

        //查询类型检测
        private bool preQuery()
        {
            if (queryType == 1)
            {
                if (!PositionAndStationUtil.isPositionName(1, cbo_Pname.Text))
                {
                    MessageBox.Show(cbo_Pname.Text + "监测点不存在！");
                    return false;
                }
            }
            else if (queryType == 3)
            {
                if (!("全部".Equals(cbo_Pname.Text) || PositionAndStationUtil.isPositionName(1, cbo_Pname.Text)))
                {
                    MessageBox.Show(cbo_Pname.Text + "监测点不存在！");
                    return false;
                }
            }
            else if (queryType == 5)
            {
                if (!("全部".Equals(cbo_Pname.Text) || PositionAndStationUtil.isPositionName(3, cbo_Pname.Text)))
                {
                    MessageBox.Show(cbo_Pname.Text + "监测点不存在！");
                    return false;
                }
            }
            else if (queryType == 6)
            {
                if (!("全部".Equals(cbo_Pname.Text) || PositionAndStationUtil.isBaseStationK(4, cbo_Pname.Text)))
                {
                    MessageBox.Show(cbo_Pname.Text + "基站不存在！");
                    return false;
                }
            }
            else if (queryType == 7)
            {
                if (!("全部".Equals(cbo_Pname.Text) || PositionAndStationUtil.isBaseStationK(1, cbo_Pname.Text)))
                {
                    MessageBox.Show(cbo_Pname.Text + "基站不存在！");
                    return false;
                }
            }
            else if (queryType == 9)
            {
                if (!("全部".Equals(cbo_Pname.Text) || PositionAndStationUtil.isBaseStationK(3, cbo_Pname.Text)))
                {
                    MessageBox.Show(cbo_Pname.Text + "基站不存在！");
                    return false;
                }
            }
            else if (queryType == 10)
            {
                if (!("全部".Equals(cbo_Pname.Text) || PositionAndStationUtil.isPositionName(3, cbo_Pname.Text)))
                {
                    MessageBox.Show(cbo_Pname.Text + "监测点不存在！");
                    return false;
                }
            }

            return true;
        }

        //选择查询
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

        //查询按钮事件
        private void btnQuery_Click(object sender, EventArgs e)
        {
            //限制查询日期
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

            //执行查询
            if (intQuery > 0)
            {
                //查询过程出错
                //MessageBox.Show("查询失败，请检测数据库后再次查询！");
                new 错误提示(exceptionMsg, "查询失败，请检测数据库后再次查询！").Show();
                return;
            }

            currentTableName = baseTableName;
            Cursor = Cursors.WaitCursor;

            btnShowDategridview.Enabled = true;
            //刷新dgdresult
            dgdResult.Columns.Clear();
            dgdResult.DataSource = dsdata;
            if (queryType < 13 || (queryType >= 21 && queryType <= 23))
            {
                dgdResult.DataMember = baseTableName;
            }

            if (queryType==3)
            {
                dgdResult.Columns["限速里程"].Visible = false;
            }

            if (queryType <= 10 || (queryType >= 21 && queryType <= 23))
            {
                if (dgdResult.Rows.Count != 0)
                {
                    dgdResult.Sort(dgdResult.Columns["时间"], ListSortDirection.Ascending);
                }
                else
                {
                    MessageBox.Show("查询返回记录为0条！");
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
                    //dgdResult.Sort(dgdResult.Columns["监测点"], ListSortDirection.Ascending);
                }
                else
                {
                    MessageBox.Show("查询返回记录为0条！");
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

            //判断是显示chart还是表格
            //只有查询风速历史记录时，将风速值生成折线图，优先显示图表，其他情况均显示表格
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
                    creatChart_Line(chartLine_time, 0, dsdata, baseTableName, "时间", "风速(m/s)");
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

        #region 历史数据查询

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

                    //不同旬
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
                //月末跨入月初
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

        //当前日期10天内的数据
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

        //风历史查询，修改3数据库查询数据
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
                newRow["时间"] = row["时间"];
                newRow["风速(m/s)"] = row["风速(m/s)"];
                newRow["风向(度)"] = row["风向(度)"];
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

        //风历史查询原数据库
        private DataSet queryPreWindHistory(string positionName)
        {
            

            string tableName = "历史数据表" + positionName;
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
                newRow["时间"] = row["time"];
                newRow["风速(m/s)"] = Double.Parse(row["velocity"].ToString()) / 10;
                newRow["风向(度)"] = Double.Parse(row["direction"].ToString()) / 10;
                newDataSet.Tables[baseTableName].Rows.Add(newRow);
            }

            return newDataSet;
        }

        //风历史查询2011-04-30
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

        #region 报警数据查询

        //风报警查询原数据库
        private int queryWindAlarm()
        {
            DataSet newDataSet = null;
            string positionName = cbo_Pname.Text;
            DateTime dt = PositionAndStationUtil.getWindBeginDateTime(positionName);
            if (dtStart.CompareTo(dt) > 0)
            {
                //Console.WriteLine("数据都在新数据库内");
                newDataSet = queryPostWindAlarm(positionName);
                if (newDataSet == null)
                {
                    exceptionMsg = SqlDAO.exceptionMsg;
                    return 1;
                }
            }
            else if (dtEnd.CompareTo(dt) < 0)
            {
                //Console.WriteLine("数据都在原数据库内");
                newDataSet = queryPreWindAlarm(positionName);
                if (newDataSet == null)
                {
                    exceptionMsg = SqlDAO.exceptionMsg;
                    return 1;
                }
            }
            else
            {
                //Console.WriteLine("原数据库和新数据库都有");
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
            if ("全部".Equals(positionName))
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
                    newRow["限速里程"] = PositionAndStationUtil.windPositionStartK[index] + " - " + PositionAndStationUtil.windPositionEndK[index];

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

            string tableName = "防风报警记录表";
            string sql;
            if ("全部".Equals(positionName))
            {
                sql = "select * from " + tableName + " where 时间 >='" + dtStart + "' and 时间 <='" + dtEnd + "'";
            }
            else
            {
                sql = "select * from " + tableName + " where 监测点名称 = '" + positionName + "' and 时间 >='" + dtStart + "' and 时间 <='" + dtEnd + "'";
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
                    newRow["时间"] = row["时间"];
                    newRow["监测点编号"] = row["监测点名称"];
                    newRow[4] = row[3];
                    newRow[5] = row[4];

                    int index = PositionAndStationUtil.getWindPositionIndex(row["监测点名称"].ToString());
                    newRow["监测点K里程"] = PositionAndStationUtil.windPositionK[index];
                    newRow["限速里程"] = PositionAndStationUtil.windPositionStartK[index] + " - " + PositionAndStationUtil.windPositionEndK[index];

                    newTable.Rows.Add(newRow);
                }
            }

            newDataSet.Tables.Add(newTable);
            return newDataSet;
        }

        //异物报警查询
        private int queryDropAlarm()
        {
            DataSet newDataSet = new DataSet();
            DataTable newTable = DataTemplateUtil.getDropAlarmTemplateTable(baseTableName); 

            string tableName = "station_onoff_info_common";
            string sql, stationID = PositionAndStationUtil.getDropKByBridgeName(cbo_Pname.Text);
            if ("全部".Equals(stationID))
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
                        newRow["时间"] = row["datetime"];
                        newRow["监测点名称"] = PositionAndStationUtil.getBridgeNameByDropK(row["station_ID"].ToString());
                        newRow["设备名称"] = rowStr[0];
                        newRow["信息类型"] = rowStr[1];
                        newRow["信息状态"] = rowStr[2];
                        newTable.Rows.Add(newRow);
                    }
                }
            }

            newDataSet.Tables.Add(newTable);
            dsdata = newDataSet;
            return 0;
        }

        //地震报警查询
        private int queryEarthQuakeAlarm()
        {
            DataSet newDataSet = new DataSet();
            DataTable newTable = DataTemplateUtil.getDropAlarmTemplateTable(baseTableName);

            string tableName = "station_onoff_info_common";
            string sql, stationID = PositionAndStationUtil.getEarthQuakeKByEarthQuakeName(cbo_Pname.Text);
            if ("全部".Equals(stationID))
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
                        newRow["时间"] = row["datetime"];
                        newRow["监测点名称"] = PositionAndStationUtil.getEarthQuakeNameByEarthQuakeK(row["station_ID"].ToString());
                        newRow["设备名称"] = rowStr[0];
                        newRow["信息类型"] = rowStr[1];
                        newRow["信息状态"] = rowStr[2];
                        newTable.Rows.Add(newRow);
                    }
                }
            }

            newDataSet.Tables.Add(newTable);
            dsdata = newDataSet;
            return 0;
        }

        #endregion

        #region 基站查询

        //全部基站信息查询
        private int queryBaseStationAll()
        {
            DataSet newDataSet = new DataSet();
            DataTable newTable = DataTemplateUtil.getStationOnOffTemplateTable(baseTableName);

            string tableName = "station_onoff_info_Common";
            string sql = "";
            string stationID = cbo_Pname.Text;
            if ("全部".Equals(stationID))
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
                newRow["时间"] = row["datetime"];
                newRow["基站名称"] = row["station_ID"];
                newRow["设备名称"] = rowStr[0];
                newRow["信息类型"] = rowStr[1];
                newRow["信息状态"] = rowStr[2];
                newTable.Rows.Add(newRow);
            }           

            newDataSet.Tables.Add(newTable);
            dsdata = newDataSet;
            return 0;
        }

        //风基站信息查询
        private int queryBaseStationWind()
        {
            DataSet newDataSet = new DataSet();
            DataTable newTable = DataTemplateUtil.getStationOnOffTemplateTable(baseTableName);

            string tableName = "station_onoff_info_Common";
            string sql = "";
            string stationID = cbo_Pname.Text;
            if ("全部".Equals(stationID))
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
                newRow["时间"] = row["datetime"];
                newRow["基站名称"] = row["station_ID"];
                newRow["设备名称"] = rowStr[0];
                newRow["信息类型"] = rowStr[1];
                newRow["信息状态"] = rowStr[2];
                newTable.Rows.Add(newRow);
            }

            newDataSet.Tables.Add(newTable);
            dsdata = newDataSet;
            return 0;
        }
      
        //异物基站信息查询
        private int queryBaseStationDrop()
        {
            DataSet newDataSet = new DataSet();
            DataTable newTable = DataTemplateUtil.getStationOnOffTemplateTable(baseTableName);

            string tableName = "station_onoff_info_Common";
            string  sql;
            string stationID = cbo_Pname.Text;
            if ("全部".Equals(stationID))
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
                newRow["时间"] = row["datetime"];
                newRow["基站名称"] = row["station_ID"];
                newRow["设备名称"] = rowStr[0];
                newRow["信息类型"] = rowStr[1];
                newRow["信息状态"] = rowStr[2];
                newTable.Rows.Add(newRow);
            }
           
            newDataSet.Tables.Add(newTable);
            dsdata = newDataSet;
            return 0;
        }

        //地震基站信息查询
        private int queryBaseStationEarthQuake()
        {
            DataSet newDataSet = new DataSet();
            DataTable newTable = DataTemplateUtil.getStationOnOffTemplateTable(baseTableName);

            string tableName = "station_onoff_info_Common";
            string sql;
            string stationID = PositionAndStationUtil.getEarthQuakeKByEarthQuakeName(cbo_Pname.Text); ;
            if ("全部".Equals(stationID))
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
                newRow["时间"] = row["datetime"];
                newRow["基站名称"] = PositionAndStationUtil.getEarthQuakeNameByEarthQuakeK(row["station_ID"].ToString());
                newRow["设备名称"] = rowStr[0];
                newRow["信息类型"] = rowStr[1];
                newRow["信息状态"] = rowStr[2];
                newTable.Rows.Add(newRow);
            }

            newDataSet.Tables.Add(newTable);
            dsdata = newDataSet;
            return 0;
        }

        #endregion

        #region 输出查询

        //异物输出查询
        private int queryDropOutput()
        {
            DataSet newDataSet = new DataSet();
            DataTable newTable = DataTemplateUtil.getDropAlarmTemplateTable(baseTableName);

            string tableName = "station_onoff_info_output_YW";
            string sql, stationID = PositionAndStationUtil.getDropKByBridgeName(cbo_Pname.Text);
            if ("全部".Equals(stationID))
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
                    newRow["时间"] = row["datetime"];
                    newRow["监测点名称"] = PositionAndStationUtil.getBridgeNameByDropK(row["station_ID"].ToString());
                    newRow["设备名称"] = rowStr[0];
                    newRow["信息类型"] = rowStr[1];
                    newRow["信息状态"] = rowStr[2];
                    newTable.Rows.Add(newRow);
                }
            }

            newDataSet.Tables.Add(newTable);
            dsdata = newDataSet;
            return 0;
        }

        //地震输出查询
        private int queryEarthQuakeOutput()
        {
            DataSet newDataSet = new DataSet();
            DataTable newTable = DataTemplateUtil.getDropAlarmTemplateTable(baseTableName);

            string tableName = "station_onoff_info_output_DZ";
            string sql, stationID = PositionAndStationUtil.getEarthQuakeKByEarthQuakeName(cbo_Pname.Text);
            if ("全部".Equals(stationID))
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
                    newRow["时间"] = row["datetime"];
                    newRow["监测点名称"] = PositionAndStationUtil.getEarthQuakeNameByEarthQuakeK(row["station_ID"].ToString());
                    newRow["设备名称"] = rowStr[0];
                    newRow["信息类型"] = rowStr[1];
                    newRow["信息状态"] = rowStr[2];
                    newTable.Rows.Add(newRow);
                }
            }

            newDataSet.Tables.Add(newTable);
            dsdata = newDataSet;
            return 0;
        }

        #endregion

        #region 统计查询

        //日最大风速查询
        private int queryMaxWindDay()
        {
            string tableName = "feng_lishi_day_max";
            DateTime strDate = dtpStart.Value;
            DateTime endDate = dtpStart.Value;
            formatDateByDay(ref strDate, ref endDate);

            string sql = "select positionID,datetime,velocity from " + tableName + " where datetime>='" + strDate + "' and datetime<='" + endDate + "'";

            DataSet newDataSet = new DataSet();
            DataTable newTable = new DataTable(baseTableName);
            DataColumn newColumn = new DataColumn("监测点");
            newTable.Columns.Add(newColumn);
            newColumn = new DataColumn("时间", typeof(DateTime));
            newTable.Columns.Add(newColumn);
            newColumn = new DataColumn("风速值(m/s)", typeof(decimal));
            newTable.Columns.Add(newColumn);
            newColumn = new DataColumn("风力等级");
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

        //月最大风速查询
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
            DataColumn newColumn = new DataColumn("监测点");
            newTable.Columns.Add(newColumn);
            newColumn = new DataColumn("时间", typeof(DateTime));
            newTable.Columns.Add(newColumn);
            newColumn = new DataColumn("风速值(m/s)", typeof(decimal));
            newTable.Columns.Add(newColumn);
            newColumn = new DataColumn("风力等级");
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

        #region 原有数据查询

        //原有风故障告警历史记录查询
        private int queryPreBaseStationWind()
        {
            string tableName = "设备故障告警历史记录表_防风";
            string sql = "";
            string stationID = cbo_Pname.Text;
            if ("全部".Equals(stationID))
            {
                sql = "select * from " + tableName + " where 故障时间>='" + dtStart + "' and 故障时间<='" + dtEnd + "'";
            }
            else
            {
                sql = "select * from " + tableName + " where 地点 = '" + stationID + "' and 故障时间>='" + dtStart + "' and 故障时间<='" + dtEnd + "'";
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
            currentTableName = "设备故障告警历史记录表_防风";

            dgdResult.DataMember = "设备故障告警历史记录表_防风";
            dgdResult.Columns["故障时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            dgdResult.Columns["故障时间"].Width = 180;
            dgdResult.Columns["恢复时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            dgdResult.Columns["恢复时间"].Width = 180;
            dgdResult.Columns["告警信息"].Width = 200;
            dgdResult.Columns["告警原因"].Width = 200;
            dgdResult.Columns["地点"].Width = 150;
            dgdResult.Columns["ID"].Visible = false;
            dgdResult.Columns["备注"].Visible = false;
        }

        //原有异物故障告警历史记录查询
        private int queryPreBaseStationDrop()
        {
            string tableName = "设备故障告警历史记录表_异物";
            string sql = "";
            string stationID = cbo_Pname.Text;
            if ("全部".Equals(stationID))
            {
                sql = "select * from " + tableName + " where 故障时间>='" + dtStart + "' and 故障时间<='" + dtEnd + "'";
            }
            else
            {
                sql = "select * from " + tableName + " where 地点 = '" + stationID + "' and 故障时间>='" + dtStart + "' and 故障时间<='" + dtEnd + "'";
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
            currentTableName = "设备故障告警历史记录表_异物";

            dgdResult.DataMember = "设备故障告警历史记录表_异物";
            dgdResult.Columns["故障时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            dgdResult.Columns["故障时间"].Width = 180;
            dgdResult.Columns["恢复时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            dgdResult.Columns["恢复时间"].Width = 180;
            dgdResult.Columns["告警信息"].Width = 200;
            dgdResult.Columns["告警原因"].Width = 200;
            dgdResult.Columns["地点"].Width = 150;
            dgdResult.Columns["ID"].Visible = false;
            dgdResult.Columns["备注"].Visible = false;
        }

        //原有异物侵限报警记录查询
        private int queryPreDropAlarm()
        {
            string tableName = "异物侵限报警记录表";
            string sql = "";
            string stationID = cbo_Pname.Text;
            if ("全部".Equals(stationID))
            {
                sql = "select * from " + tableName + " where 时间>='" + dtStart + "' and 时间<='" + dtEnd + "'";
            }
            else
            {
                sql = "select * from " + tableName + " where 监测点名称 = '" + stationID + "' and 时间>='" + dtStart + "' and 时间<='" + dtEnd + "'";
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
            currentTableName = "异物侵限报警记录表";

            dgdResult.DataMember = "异物侵限报警记录表";
            dgdResult.Columns["时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            dgdResult.Columns["时间"].Width = 180;
            dgdResult.Columns["信息类型"].Width = 200;
            dgdResult.Columns["信息内容"].Width = 200;
            dgdResult.Columns["ID"].Visible = false;
            dgdResult.Columns["备注"].Visible = false;
        }

        //原有通信故障报警历史记录查询
        private int queryPreAllAlarm()
        {
            string tableName = "通信故障告警历史记录表";
            string sql = "";
            string stationID = cbo_Pname.Text;
            if ("全部".Equals(stationID))
            {
                sql = "select * from " + tableName + " where 故障时间>='" + dtStart + "' and 故障时间<='" + dtEnd + "'";
            }
            else
            {
                sql = "select * from " + tableName + " where 地点 = '" + stationID + "' and 故障时间>='" + dtStart + "' and 故障时间<='" + dtEnd + "'";
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
            currentTableName = "通信故障告警历史记录表";

            dgdResult.DataMember = "通信故障告警历史记录表";
            dgdResult.Columns["故障时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            dgdResult.Columns["故障时间"].Width = 180;
            dgdResult.Columns["恢复时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            dgdResult.Columns["恢复时间"].Width = 180;
            dgdResult.Columns["告警信息"].Width = 200;
            dgdResult.Columns["告警原因"].Width = 200;
            dgdResult.Columns["地点"].Width = 150;
            dgdResult.Columns["ID"].Visible = false;
            dgdResult.Columns["备注"].Visible = false;
        }

        #endregion

        #endregion

        #region 表格按钮/折线按钮

        //表格按钮
        private void btnShowDategridview_Click(object sender, EventArgs e)
        {
            dgdResult.Visible = true;
            chartLine_time.Visible = false;
        }

        //折线按钮
        private void btnShowChart_Click(object sender, EventArgs e)
        {
            dgdResult.Visible = false;
            chartLine_time.Visible = true;
        }

        #endregion

        #region 日期限制及格式

        private bool checkDate()
        {
            if (dateLimit1Second() == 1)
            {
                MessageBox.Show("截止时间必须大于起始时间！");
                return false;
            }
            if (queryType == 1 || queryType == 2)
            {
                if (dateLimitDay() == 1)
                {
                    MessageBox.Show("检索时间范围超限，历史记录最大间隔为1天！");
                    return false;
                }
            }
            else if (queryType == 3 || queryType == 5)
            {
                if (dateLimitYear() == 1)
                {
                    MessageBox.Show("检索时间范围超限，查询最大间隔为1年！");
                    return false;
                }
            } 
            else if (queryType <= 10)
            {
                if (dateLimitMonth() == 1)
                {
                    MessageBox.Show("检索时间范围超限，查询最大间隔为30天！");
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

        //关闭时间选择按钮
        private void closeChoose()
        {
            cbo_Pname.Enabled = false;
            dtpStart.Enabled = false;
            dtpEnd.Enabled = false;
        }

        //开启时间选择按钮
        private void openChoose()
        {
            label1.Text = "起始时间";
            label31.Text = "截止时间";
            dtpStart.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            cbo_Pname.Enabled = true;
            dtpStart.Enabled = true;
            dtpEnd.Enabled = true;
        }

        //单一时间选择
        private void changeSingle()
        {
            label1.Text = "查询日期";
            cbo_Pname.Enabled = false;
            dtpStart.Enabled = true;
            dtpEnd.Enabled = false;
        }

        private void changeSingleDay()
        {
            dtpStart.CustomFormat = "yyyy-MM-dd";
            label1.Text = "查询日期";
            cbo_Pname.Enabled = false;
            dtpStart.Enabled = true;
            dtpEnd.Enabled = false;
        }

        private void changeSingleMonth()
        {
            dtpStart.CustomFormat = "yyyy-MM";
            label1.Text = "查询日期";
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

        //风速转换等级
        private string getWindLevel(double windSpeed)
        {

            if (windSpeed >= 0.0 && windSpeed <= 0.2)
            {
                return 0 + "级";
            }
            else if (windSpeed >= 0.3 && windSpeed <= 1.5)
            {
                return 1 + "级";
            }
            else if (windSpeed >= 1.6 && windSpeed <= 3.3)
            {
                return 2 + "级";
            }
            else if (windSpeed >= 3.4 && windSpeed <= 5.4)
            {
                return 3 + "级";
            }
            else if (windSpeed >= 5.5 && windSpeed <= 7.9)
            {
                return 4 + "级";
            }
            else if (windSpeed >= 8.0 && windSpeed <= 10.7)
            {
                return 5 + "级";
            }
            else if (windSpeed >= 10.8 && windSpeed <= 13.8)
            {
                return 6 + "级";
            }
            else if (windSpeed >= 13.9 && windSpeed <= 17.1)
            {
                return 7 + "级";
            }
            else if (windSpeed >= 17.2 && windSpeed <= 20.7)
            {
                return 8 + "级";
            }
            else if (windSpeed >= 20.8 && windSpeed <= 24.4)
            {
                return 9 + "级";
            }
            else if (windSpeed >= 24.5 && windSpeed <= 28.4)
            {
                return 10 + "级";
            }
            else if (windSpeed >= 28.5 && windSpeed <= 32.6)
            {
                return 11 + "级";
            }
            else if (windSpeed >= 32.7)
            {
                return 12 + "级";
            }
            else
            {
                return "无效值";
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

        #region 查询菜单按钮

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

        //历史查询
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

        //报警查询
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

        //基本信息查询
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

        //异物输出
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

        //地震输出
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

        //日最大风速
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

        //月最大风速
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

        //原数据查询
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

        #region 生成折线/生成序号事件

        //生成折线
        public void creatChart_Line(C1Chart c1c, int series, DataSet dataSource, string tablename, string strTimeCol, string strVCol)
        {
            int rowNum = dataSource.Tables[tablename].Rows.Count;
            if (rowNum == 0)
            {
                MessageBox.Show("符合条件的记录数为零，请重新选择查询条件");
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

        //生成序号事件
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

        #region 窗体大小设置

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
                if ("时间".Equals(col.Name))
                {
                    col.Width = 150;
                    col.DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                }
                else if ("风速(m/s)".Equals(col.Name))
                {
                    col.Width = 100;
                    col.DefaultCellStyle.Format = "N1";
                }
                else if ("风向(度)".Equals(col.Name))
                {
                    col.Width = 100;
                    col.DefaultCellStyle.Format = "N1";
                }
                else if ("温度(℃)".Equals(col.Name))
                {
                    col.Width = 100;
                    col.DefaultCellStyle.Format = "N1";
                }
                else if ("气压(hPa)".Equals(col.Name))
                {
                    col.Width = 100;
                    col.DefaultCellStyle.Format = "N1";
                }
                else if ("湿度(%)".Equals(col.Name))
                {
                    col.Width = 100;
                    col.DefaultCellStyle.Format = "N1";
                }
                else if ("限速里程".Equals(col.Name))
                {
                    col.Width = 150;
                    col.DefaultCellStyle.Format = "N1";
                }
                else if ("区间".Equals(col.Name))
                {
                    col.Width = 140;
                    col.DefaultCellStyle.Format = "N1";
                }
                else if ("报警级别".Equals(col.Name))
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
                if ("时间".Equals(col.Name))
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
                if ("时间".Equals(col.Name))
                {
                    col.Width = 125;
                    col.DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                    break;
                }
            }
        }

        #endregion

        #region 全部数据查询

        private void dtpStart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Alt && e.KeyCode == Keys.S)
            {
                new 全部数据查询().Show();
            }
        }

        #endregion

        #region 结果集处理

        private void dgdResult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if ( (queryType == 3 || queryType == 4) && (e.RowIndex >= 0) )
            {
                DateTime dtStart = new DateTime();
                DateTime dtEnd = new DateTime();
                DataGridView dgv = (DataGridView)sender;
                DataGridViewRow nowRow = dgv.Rows[e.RowIndex];

                if ("0".Equals(nowRow.Cells["报警级别"].Value.ToString()))
                {
                    dtEnd = Convert.ToDateTime(dgv.Rows[e.RowIndex].Cells["时间"].Value.ToString()).AddMinutes(1);

                    if (e.RowIndex == 0)
                    {
                        dtStart = Convert.ToDateTime(dgv.Rows[e.RowIndex].Cells["时间"].Value.ToString()).AddMinutes(-1);
                    }
                    else
                    {
                        for (int i = e.RowIndex - 1; i >= 0; i--)
                        {
                            if ("0".Equals(dgv.Rows[i].Cells["报警级别"].Value.ToString()))
                            {
                                dtStart = Convert.ToDateTime(dgv.Rows[i].Cells["时间"].Value.ToString()).AddMinutes(-1);
                                break;
                            }
                            else if (i == 0)
                            {
                                dtStart = Convert.ToDateTime(dgv.Rows[i].Cells["时间"].Value.ToString()).AddMinutes(-1);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    dtStart = Convert.ToDateTime(dgv.Rows[e.RowIndex].Cells["时间"].Value.ToString()).AddMinutes(-1);
                    for (int i = e.RowIndex; i < dgv.Rows.Count; i++)
                    {
                        if ("0".Equals(dgv.Rows[i].Cells["报警级别"].Value.ToString()))
                        {
                            dtEnd = Convert.ToDateTime(dgv.Rows[i].Cells["时间"].Value.ToString()).AddMinutes(1);
                            break;
                        }
                        else if (i == dgv.Rows.Count - 1)
                        {
                            dtEnd = Convert.ToDateTime(dgv.Rows[i].Cells["时间"].Value.ToString()).AddMinutes(1);
                            break;
                        }
                    }
                }

                ShowAlarmData showAlarmData = new ShowAlarmData(nowRow.Cells[1].Value.ToString(), dtStart, dtEnd, queryType);

                showAlarmData.ShowDialog();
            }
        }
        
        #endregion

        #region 导出到Excel

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dsdata == null || dsdata.Tables.Count <= 0)
            {
                MessageBox.Show("数据导入失败，原因是无数据导入Excel，请查询后导入数据！");
                return;
            }

            toExcel(dsdata);
            this.Activate();
            MessageBox.Show("导出Excel完毕");
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

        #region 滑动菜单

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