using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace weihu_fx
{
    public partial class 错误提示 : Form
    {
        public static int picStatus = 1;

        public 错误提示()
        {
            InitializeComponent();
        }

        public 错误提示(StringBuilder msg1, string msg2)
        {
            InitializeComponent();
            try
            {
                textBox1.Text = msg1.ToString();
                textBox2.Text = msg2.ToString();
            }
            catch (Exception)
            {
                
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (picStatus == 1)
            {
                picStatus = 0;
                button1.BackgroundImage = global::weihu_fx.Properties.Resources.nolines_minus;
                this.Height = 372;
            }
            else
            {
                picStatus = 1;
                button1.BackgroundImage = global::weihu_fx.Properties.Resources.nolines_plus;
                this.Height = 144;
            }
        }

        private void 错误提示_Load(object sender, EventArgs e)
        {
            this.Height = 144;
        }
    }
}