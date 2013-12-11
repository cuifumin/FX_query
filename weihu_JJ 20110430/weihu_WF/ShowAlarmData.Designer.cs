namespace weihu_fx
{
    partial class ShowAlarmData
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowAlarmData));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLine = new System.Windows.Forms.Button();
            this.btnData = new System.Windows.Forms.Button();
            this.dgvResult2 = new System.Windows.Forms.DataGridView();
            this.chartLine_time = new C1.Win.C1Chart.C1Chart();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLine_time)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnLine);
            this.panel1.Controls.Add(this.btnData);
            this.panel1.Location = new System.Drawing.Point(-1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(687, 36);
            this.panel1.TabIndex = 85;
            // 
            // btnLine
            // 
            this.btnLine.Location = new System.Drawing.Point(12, 6);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(83, 27);
            this.btnLine.TabIndex = 2;
            this.btnLine.Text = "图表显示";
            this.btnLine.UseVisualStyleBackColor = true;
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // btnData
            // 
            this.btnData.Location = new System.Drawing.Point(101, 6);
            this.btnData.Name = "btnData";
            this.btnData.Size = new System.Drawing.Size(91, 27);
            this.btnData.TabIndex = 3;
            this.btnData.Text = "列表显示";
            this.btnData.UseVisualStyleBackColor = true;
            this.btnData.Click += new System.EventHandler(this.btnData_Click);
            // 
            // dgvResult2
            // 
            this.dgvResult2.AllowUserToAddRows = false;
            this.dgvResult2.AllowUserToDeleteRows = false;
            this.dgvResult2.AllowUserToResizeColumns = false;
            this.dgvResult2.AllowUserToResizeRows = false;
            this.dgvResult2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResult2.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvResult2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult2.Location = new System.Drawing.Point(-1, 39);
            this.dgvResult2.Name = "dgvResult2";
            this.dgvResult2.ReadOnly = true;
            this.dgvResult2.RowTemplate.Height = 23;
            this.dgvResult2.Size = new System.Drawing.Size(687, 473);
            this.dgvResult2.TabIndex = 87;
            this.dgvResult2.Visible = false;
            this.dgvResult2.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvResult2_RowPostPaint);
            // 
            // chartLine_time
            // 
            this.chartLine_time.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chartLine_time.BackColor = System.Drawing.Color.White;
            this.chartLine_time.Interaction.Enabled = true;
            this.chartLine_time.Location = new System.Drawing.Point(-1, 39);
            this.chartLine_time.Name = "chartLine_time";
            this.chartLine_time.PropBag = resources.GetString("chartLine_time.PropBag");
            this.chartLine_time.Size = new System.Drawing.Size(687, 473);
            this.chartLine_time.TabIndex = 88;
            // 
            // ShowAlarmData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 513);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvResult2);
            this.Controls.Add(this.chartLine_time);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShowAlarmData";
            this.Text = "ShowAlarmData";
            this.SizeChanged += new System.EventHandler(this.ShowAlarmData_SizeChanged);
            this.Load += new System.EventHandler(this.ShowAlarmData_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLine_time)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Button btnData;
        private System.Windows.Forms.DataGridView dgvResult2;
        private C1.Win.C1Chart.C1Chart chartLine_time;
    }
}