using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace weihu_fx
{
    public partial class frmShowTop : Form
    {
        public frmShowTop()
        {
            InitializeComponent();
        }

        private void frmShowTop_Load(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == "frmShowTop")
                {
                    frm.Visible = false;
                }
            }

            QueryForm form = new QueryForm();
            form.TopMost = true;
            form.Show();
            form.Activate();
        }
    }
}