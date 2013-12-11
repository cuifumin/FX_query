using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace weihu_fx
{
    public partial class 全部数据查询 : Form
    {
        public 全部数据查询()
        {
            InitializeComponent();
        }

        private void btnWind_Click(object sender, EventArgs e)
        {
            new 风数据解析().Show();
        }

        private void btnDrop_Click(object sender, EventArgs e)
        {
            new 异物数据解析().Show();
        }

        private void 全部数据查询_Load(object sender, EventArgs e)
        {
        }

    }
}