using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace weihu_fx
{
    public partial class 异物数据解析 : Form
    {
        #region 属性定义

        private Button closingButton;

        private DateTime dtStart, dtEnd;

        private string[] broadIp;

        private string[][] stationK;

        private string conStr;

        private DataSet dsResult;

        private DataSet dsSystemMsg;

        private DataSet dsStationOnOff;

        private DataSet dsOutput;

        private string tableName = "allData_YW";

        private int currentPageNum = 0;

        private int totalPageNum = 0;

        #endregion

        #region 初始化及关闭

        public 异物数据解析()
        {
            InitializeComponent();
        }

        public 异物数据解析(Button b)
        {
            closingButton = b;
            InitializeComponent();
        }

        private void 异物数据解析_Load(object sender, EventArgs e)
        {
            try
            {
                initConStr();
                initBroadMsg();
                initBroadIp();
                initDataSet();
                dtpStart_ValueChanged(this, new EventArgs());
                dtpEnd_ValueChanged(this, new EventArgs());

                //Console.WriteLine("异物数据查询系统启动成功！");
            }
            catch (Exception)
            {
            }
           
        }

        private void initBroadMsg()
        {
            broadIp = BroadIPAndPositionKUtil.getDropIPString();
            stationK = BroadIPAndPositionKUtil.getDropStationK();
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
                MessageBox.Show("数据库连接字符串初始化失败，请检测系统引用文件或系统运行环境后重新启动系统！");
                //Console.WriteLine(ee.StackTrace);
            }
        }

        private void initDataSet()
        {
            dsSystemMsg = new DataSet();
            DataTable dt = new DataTable(tableName);
            for (int i = 0; i < 8; i++)
            {
                DataColumn newDataColumn = new DataColumn("D" + i + "/D" + (i + 8));
                dt.Columns.Add(newDataColumn);
            }
            dsSystemMsg.Tables.Add(dt);


            dsStationOnOff = new DataSet();
            dt = new DataTable(tableName);

            for (int i = 0; i < 8; i++)
            {
                DataColumn newDataColumn = new DataColumn("D" + i + "/D" + (i + 8));
                dt.Columns.Add(newDataColumn);
            }
            dsStationOnOff.Tables.Add(dt);

            dsOutput = new DataSet();
            dt = new DataTable(tableName);
            for (int i = 0; i < 8; i++)
            {
                DataColumn newDataColumn = new DataColumn("D" + i + "/D" + (i + 8));
                dt.Columns.Add(newDataColumn);
            }
            dsOutput.Tables.Add(dt);

        }

        private void initBroadIp()
        {
            cbIp.Items.Clear();
            for (int i = 0; i < broadIp.Length; i++)
            {
                cbIp.Items.Add(broadIp[i]);
            }
            cbIp.SelectedIndex = 0;
        }

        #endregion

        #region 下拉选择菜单

        private void refreshPositionK(int broadIpIndex)
        {
            if (broadIpIndex != -1)
            {
                cbPositionK.Items.Clear();
                for (int i = 0; i < stationK[broadIpIndex].Length; i++)
                {
                    cbPositionK.Items.Add(stationK[broadIpIndex][i]);
                }
                cbPositionK.SelectedIndex = 0;
            }
            else
            {
                cbPositionK.Items.Clear();
            }
        }

        private void cbIp_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbPositionK.Items.Clear();
            cbPositionK.Text = "";
            closePage();
        }

        private void cbPositionK_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null != dsResult && cbPositionK.Items.Count != 0)
            {
                openPage();
                setResultMsg();
            }
        }

        #endregion

        #region 分页

        private void clearPageMsg()
        {
            currentPageNum = totalPageNum = 0;
            setPageMsgLogic();
        }

        private void closePage()
        {
            clearPageMsg();
            btnFirstPage.Enabled = false;
            btnLastPage.Enabled = false;
        }

        private void openPage()
        {
            setPageMsg();
            btnFirstPage.Enabled = true;
            btnLastPage.Enabled = true;
        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            currentPageNum = 0;
            setPageMsgLogic();
            setResultMsg();
        }

        private void btnFrontPage_Click(object sender, EventArgs e)
        {
            if (currentPageNum >= 0)
            {
                currentPageNum--;
                setPageMsgLogic();
                setResultMsg();
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (currentPageNum <= totalPageNum)
            {
                currentPageNum++;
                setPageMsgLogic();
                setResultMsg();
            }
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            currentPageNum = totalPageNum;
            setPageMsgLogic();
            setResultMsg();
        }

        private void setPageMsg()
        {
            currentPageNum = 0;
            totalPageNum = dsResult.Tables[tableName].Rows.Count - 1;
            setPageMsgLogic();
        }

        private void setPageMsgLogic()
        {
            if (currentPageNum == 0)
            {
                btnFrontPage.Enabled = false;
            }
            else
            {
                btnFrontPage.Enabled = true;
            }
            if (currentPageNum == totalPageNum)
            {
                btnNextPage.Enabled = false;
            }
            else
            {
                btnNextPage.Enabled = true;
            }
            tbCurrentPageNum.Text = currentPageNum.ToString();
            tbTotalPageNum.Text = totalPageNum.ToString();
        }

        #endregion

        #region 查询

        private void btnQueryByIp_Click(object sender, EventArgs e)
        {
            if (dateLimit1Second() == 1)
            {
                MessageBox.Show("起始时间必须小于截止时间！");
                return;
            }

            string sql = "select * from " + tableName + " where ip='" + cbIp.Text + "' and datetime >='" + dtStart + "' and datetime<='" + dtEnd + "'";

            try
            {
                Cursor = Cursors.WaitCursor;

                SqlConnection con = ConnectionUtil.getConn(conStr);
               SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                DataSet dataSet = new DataSet();

                con.Open();
                adapter.Fill(dataSet, tableName);
                ConnectionUtil.closeConn(con);

                dsResult = dataSet;
                if (dsResult.Tables[tableName].Rows.Count == 0)
                {
                    MessageBox.Show("查询记录为0条，请重新选择条件查询！");
                    clearData();
                }
                else
                {
                    refreshPositionK(cbIp.SelectedIndex);
                }
            }
            catch (Exception)
            {
                //Console.WriteLine(ee.StackTrace);
                MessageBox.Show("查询失败！！！");
            }
            finally
            {
                Cursor = Cursors.Default;
            }

        }

        private void setResultMsg()
        {
            string[] dropData = dsResult.Tables[tableName].Rows[currentPageNum][3].ToString().Split(' ');

            tbDateTime.Text = dsResult.Tables[tableName].Rows[currentPageNum][2].ToString();

            setSystemMsgDataSet(dropData);
            setStationOnOffDataSet(dropData);
            setOutputDataSet(dropData);

            formatData();
        }

        private void setSystemMsgDataSet(string[] dropData)
        {
            dsSystemMsg.Tables[tableName].Rows.Clear();

            for (int i = 4; i < 4 + 8; i++)
            {
                DataRow dr = dsSystemMsg.Tables[tableName].NewRow();
                string[] strBits;
                try
                {
                    strBits = ConvertUtil.byteToStringArray(Convert.ToByte(dropData[i]));
                    for (int j = 0; j < 8; j++)
                    {
                        dr[j] = strBits[j];
                    }
                }
                catch (Exception ee)
                {
                    Console.WriteLine(ee.StackTrace);
                }
                dsSystemMsg.Tables[tableName].Rows.Add(dr);
            }
            dgvSystemMsg.DataSource = dsSystemMsg;
            dgvSystemMsg.DataMember = tableName;
        }

        private void setStationOnOffDataSet(string[] dropData)
        {
            dsStationOnOff.Tables[tableName].Rows.Clear();

            int offset = getPositionKIndexInBroad();
            for (int i = 4 + 8 + 16 * offset; i < ((4 + 8 + 16 * offset) + 16); i++)
            {
                DataRow dr = dsStationOnOff.Tables[tableName].NewRow();
                string[] strBits;
                try
                {
                    strBits = ConvertUtil.byteToStringArray(Convert.ToByte(dropData[i]));
                    for (int j = 0; j < 8; j++)
                    {
                        dr[j] = strBits[j];
                    }
                }
                catch (Exception)
                {
                    //Console.WriteLine(ee.StackTrace);
                }
                dsStationOnOff.Tables[tableName].Rows.Add(dr);
            }

            dgvStationOnOff.DataSource = dsStationOnOff;
            dgvStationOnOff.DataMember = tableName;
        }

        private void setOutputDataSet(string[] dropData)
        {
            dsOutput.Tables[tableName].Rows.Clear();

            int offset = getPositionKIndexInBroad();
            for (int i = 4 + 8 + 256 + offset; i < 4 + 8 + 256 + offset + 2; i++)
            {
                DataRow dr = dsOutput.Tables[tableName].NewRow();
                string[] strBits;
                try
                {
                    strBits = ConvertUtil.byteToStringArray(Convert.ToByte(dropData[i]));
                    for (int j = 0; j < 8; j++)
                    {
                        dr[j] = strBits[j];
                    }
                }
                catch (Exception)
                {
                    //Console.WriteLine(ee.StackTrace);
                }
                dsOutput.Tables[tableName].Rows.Add(dr);
            }

            dgvOutput.DataSource = dsOutput;
            dgvOutput.DataMember = tableName;
        }

        private int getPositionKIndexInBroad()
        {
            int broadIndex = getBroadIndex();
            string temp = cbPositionK.Text;

            if (broadIndex >= 0)
            {
                for (int i = 0; i < stationK[broadIndex].Length; i++)
                {
                    if (temp.Equals(stationK[broadIndex][i]))
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        private int getBroadIndex()
        {
            string temp = cbIp.Text;

            for (int i = 0; i < broadIp.Length; i++)
            {
                if (temp.Equals(broadIp[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        private void clearData()
        {
            dsSystemMsg.Tables[tableName].Rows.Clear();
            dgvSystemMsg.Refresh();

            dsStationOnOff.Tables[tableName].Rows.Clear();
            dgvStationOnOff.Refresh();

            dsOutput.Tables[tableName].Rows.Clear();
            dgvOutput.Refresh();
        }

        #endregion

        #region 时间

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            dtStart = dtpStart.Value;
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            dtEnd = dtpEnd.Value;
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

        #endregion

        #region 显示格式

        private void formatData()
        {
            setSystemMsgDataSetFormat();
            setStationOnOffDataSetFormat();
            setOutputDataSetFormat();
        }

        private void setSystemMsgDataSetFormat()
        {
            foreach (DataGridViewColumn col in dgvSystemMsg.Columns)
            {
                col.Width = 55;
            }
        }

        private void setStationOnOffDataSetFormat()
        {
            foreach (DataGridViewColumn col in dgvStationOnOff.Columns)
            {
                col.Width = 55;
            }
        }

        private void setOutputDataSetFormat()
        {
            foreach (DataGridViewColumn col in dgvOutput.Columns)
            {
                col.Width = 55;
            }
        }

        //生成序号事件
        private void dgvSystemMsg_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                                                e.RowBounds.Location.Y,
                                                dgvSystemMsg.RowHeadersWidth - 4,
                                                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, ("字节" + e.RowIndex).ToString(),
                dgvSystemMsg.RowHeadersDefaultCellStyle.Font, rectangle,
                dgvSystemMsg.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void dgvStationOnOff_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                                                e.RowBounds.Location.Y,
                                                dgvStationOnOff.RowHeadersWidth - 4,
                                                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, ("字节" + e.RowIndex).ToString(),
                dgvStationOnOff.RowHeadersDefaultCellStyle.Font, rectangle,
                dgvStationOnOff.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void dgvOutput_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                                                e.RowBounds.Location.Y,
                                                dgvOutput.RowHeadersWidth - 4,
                                                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, ("字节" + e.RowIndex).ToString(),
                dgvOutput.RowHeadersDefaultCellStyle.Font, rectangle,
                dgvOutput.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        #endregion

    }
}