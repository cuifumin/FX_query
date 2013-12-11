namespace weihu_fx
{
    partial class 风数据解析
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(风数据解析));
            this.labStationOnOff = new System.Windows.Forms.Label();
            this.labSystem = new System.Windows.Forms.Label();
            this.tbDateTime = new System.Windows.Forms.TextBox();
            this.labDateTime = new System.Windows.Forms.Label();
            this.tbTotalPageNum = new System.Windows.Forms.TextBox();
            this.tbCurrentPageNum = new System.Windows.Forms.TextBox();
            this.btnLastPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.labTotalPage = new System.Windows.Forms.Label();
            this.btnFrontPage = new System.Windows.Forms.Button();
            this.btnFirstPage = new System.Windows.Forms.Button();
            this.labCurrentPage = new System.Windows.Forms.Label();
            this.gbPositionK = new System.Windows.Forms.GroupBox();
            this.cbPositionK = new System.Windows.Forms.ComboBox();
            this.labPositionK = new System.Windows.Forms.Label();
            this.gbBroadIp = new System.Windows.Forms.GroupBox();
            this.cbIp = new System.Windows.Forms.ComboBox();
            this.btnQueryByIp = new System.Windows.Forms.Button();
            this.labBroadIp = new System.Windows.Forms.Label();
            this.gbTime = new System.Windows.Forms.GroupBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.labDateEnd = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.labDateStart = new System.Windows.Forms.Label();
            this.labWindState = new System.Windows.Forms.Label();
            this.dgvSystemMsg = new System.Windows.Forms.DataGridView();
            this.dgvStationOnOff = new System.Windows.Forms.DataGridView();
            this.dgvDataState = new System.Windows.Forms.DataGridView();
            this.gbPositionK.SuspendLayout();
            this.gbBroadIp.SuspendLayout();
            this.gbTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSystemMsg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStationOnOff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataState)).BeginInit();
            this.SuspendLayout();
            // 
            // labStationOnOff
            // 
            this.labStationOnOff.AutoSize = true;
            this.labStationOnOff.Location = new System.Drawing.Point(565, 137);
            this.labStationOnOff.Name = "labStationOnOff";
            this.labStationOnOff.Size = new System.Drawing.Size(83, 12);
            this.labStationOnOff.TabIndex = 35;
            this.labStationOnOff.Text = "开关量信息 ：";
            // 
            // labSystem
            // 
            this.labSystem.AutoSize = true;
            this.labSystem.Location = new System.Drawing.Point(30, 137);
            this.labSystem.Name = "labSystem";
            this.labSystem.Size = new System.Drawing.Size(71, 12);
            this.labSystem.TabIndex = 34;
            this.labSystem.Text = "系统信息 ：";
            // 
            // tbDateTime
            // 
            this.tbDateTime.Location = new System.Drawing.Point(634, 86);
            this.tbDateTime.Name = "tbDateTime";
            this.tbDateTime.ReadOnly = true;
            this.tbDateTime.Size = new System.Drawing.Size(140, 21);
            this.tbDateTime.TabIndex = 33;
            // 
            // labDateTime
            // 
            this.labDateTime.AutoSize = true;
            this.labDateTime.Location = new System.Drawing.Point(566, 87);
            this.labDateTime.Name = "labDateTime";
            this.labDateTime.Size = new System.Drawing.Size(71, 12);
            this.labDateTime.TabIndex = 32;
            this.labDateTime.Text = "存储时间 ：";
            // 
            // tbTotalPageNum
            // 
            this.tbTotalPageNum.Location = new System.Drawing.Point(501, 118);
            this.tbTotalPageNum.Name = "tbTotalPageNum";
            this.tbTotalPageNum.ReadOnly = true;
            this.tbTotalPageNum.Size = new System.Drawing.Size(51, 21);
            this.tbTotalPageNum.TabIndex = 31;
            // 
            // tbCurrentPageNum
            // 
            this.tbCurrentPageNum.Location = new System.Drawing.Point(412, 118);
            this.tbCurrentPageNum.Name = "tbCurrentPageNum";
            this.tbCurrentPageNum.ReadOnly = true;
            this.tbCurrentPageNum.Size = new System.Drawing.Size(51, 21);
            this.tbCurrentPageNum.TabIndex = 30;
            // 
            // btnLastPage
            // 
            this.btnLastPage.Location = new System.Drawing.Point(505, 85);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Size = new System.Drawing.Size(55, 23);
            this.btnLastPage.TabIndex = 29;
            this.btnLastPage.Text = "尾页";
            this.btnLastPage.UseVisualStyleBackColor = true;
            this.btnLastPage.Click += new System.EventHandler(this.btnLastPage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Location = new System.Drawing.Point(444, 85);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(55, 23);
            this.btnNextPage.TabIndex = 28;
            this.btnNextPage.Text = "下一页";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // labTotalPage
            // 
            this.labTotalPage.AutoSize = true;
            this.labTotalPage.Location = new System.Drawing.Point(469, 121);
            this.labTotalPage.Name = "labTotalPage";
            this.labTotalPage.Size = new System.Drawing.Size(35, 12);
            this.labTotalPage.TabIndex = 27;
            this.labTotalPage.Text = "共 ：";
            // 
            // btnFrontPage
            // 
            this.btnFrontPage.Location = new System.Drawing.Point(383, 85);
            this.btnFrontPage.Name = "btnFrontPage";
            this.btnFrontPage.Size = new System.Drawing.Size(55, 23);
            this.btnFrontPage.TabIndex = 26;
            this.btnFrontPage.Text = "上一页";
            this.btnFrontPage.UseVisualStyleBackColor = true;
            this.btnFrontPage.Click += new System.EventHandler(this.btnFrontPage_Click);
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.Location = new System.Drawing.Point(322, 85);
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.Size = new System.Drawing.Size(55, 23);
            this.btnFirstPage.TabIndex = 25;
            this.btnFirstPage.Text = "首页";
            this.btnFirstPage.UseVisualStyleBackColor = true;
            this.btnFirstPage.Click += new System.EventHandler(this.btnFirstPage_Click);
            // 
            // labCurrentPage
            // 
            this.labCurrentPage.AutoSize = true;
            this.labCurrentPage.Location = new System.Drawing.Point(344, 122);
            this.labCurrentPage.Name = "labCurrentPage";
            this.labCurrentPage.Size = new System.Drawing.Size(71, 12);
            this.labCurrentPage.TabIndex = 24;
            this.labCurrentPage.Text = "当前页数 ：";
            // 
            // gbPositionK
            // 
            this.gbPositionK.Controls.Add(this.cbPositionK);
            this.gbPositionK.Controls.Add(this.labPositionK);
            this.gbPositionK.Location = new System.Drawing.Point(25, 68);
            this.gbPositionK.Name = "gbPositionK";
            this.gbPositionK.Size = new System.Drawing.Size(288, 50);
            this.gbPositionK.TabIndex = 23;
            this.gbPositionK.TabStop = false;
            this.gbPositionK.Text = "基站K里程";
            // 
            // cbPositionK
            // 
            this.cbPositionK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPositionK.FormattingEnabled = true;
            this.cbPositionK.Location = new System.Drawing.Point(48, 20);
            this.cbPositionK.Name = "cbPositionK";
            this.cbPositionK.Size = new System.Drawing.Size(230, 20);
            this.cbPositionK.TabIndex = 1;
            this.cbPositionK.SelectedIndexChanged += new System.EventHandler(this.cbPositionK_SelectedIndexChanged);
            // 
            // labPositionK
            // 
            this.labPositionK.Location = new System.Drawing.Point(3, 20);
            this.labPositionK.Name = "labPositionK";
            this.labPositionK.Size = new System.Drawing.Size(41, 20);
            this.labPositionK.TabIndex = 0;
            this.labPositionK.Text = "K里程";
            this.labPositionK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbBroadIp
            // 
            this.gbBroadIp.Controls.Add(this.cbIp);
            this.gbBroadIp.Controls.Add(this.btnQueryByIp);
            this.gbBroadIp.Controls.Add(this.labBroadIp);
            this.gbBroadIp.Location = new System.Drawing.Point(25, 12);
            this.gbBroadIp.Name = "gbBroadIp";
            this.gbBroadIp.Size = new System.Drawing.Size(288, 50);
            this.gbBroadIp.TabIndex = 22;
            this.gbBroadIp.TabStop = false;
            this.gbBroadIp.Text = "风板";
            // 
            // cbIp
            // 
            this.cbIp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIp.FormattingEnabled = true;
            this.cbIp.Location = new System.Drawing.Point(50, 20);
            this.cbIp.Name = "cbIp";
            this.cbIp.Size = new System.Drawing.Size(170, 20);
            this.cbIp.TabIndex = 1;
            this.cbIp.SelectedIndexChanged += new System.EventHandler(this.cbIp_SelectedIndexChanged);
            // 
            // btnQueryByIp
            // 
            this.btnQueryByIp.Location = new System.Drawing.Point(226, 18);
            this.btnQueryByIp.Name = "btnQueryByIp";
            this.btnQueryByIp.Size = new System.Drawing.Size(52, 23);
            this.btnQueryByIp.TabIndex = 0;
            this.btnQueryByIp.Text = "查询";
            this.btnQueryByIp.UseVisualStyleBackColor = true;
            this.btnQueryByIp.Click += new System.EventHandler(this.btnQueryByIp_Click);
            // 
            // labBroadIp
            // 
            this.labBroadIp.Location = new System.Drawing.Point(5, 20);
            this.labBroadIp.Name = "labBroadIp";
            this.labBroadIp.Size = new System.Drawing.Size(41, 20);
            this.labBroadIp.TabIndex = 0;
            this.labBroadIp.Text = "风板IP";
            this.labBroadIp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbTime
            // 
            this.gbTime.Controls.Add(this.dtpEnd);
            this.gbTime.Controls.Add(this.labDateEnd);
            this.gbTime.Controls.Add(this.dtpStart);
            this.gbTime.Controls.Add(this.labDateStart);
            this.gbTime.Location = new System.Drawing.Point(322, 12);
            this.gbTime.Name = "gbTime";
            this.gbTime.Size = new System.Drawing.Size(456, 50);
            this.gbTime.TabIndex = 21;
            this.gbTime.TabStop = false;
            this.gbTime.Text = "时间范围";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(297, 21);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(147, 21);
            this.dtpEnd.TabIndex = 1;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // labDateEnd
            // 
            this.labDateEnd.AutoSize = true;
            this.labDateEnd.Location = new System.Drawing.Point(238, 25);
            this.labDateEnd.Name = "labDateEnd";
            this.labDateEnd.Size = new System.Drawing.Size(53, 12);
            this.labDateEnd.TabIndex = 0;
            this.labDateEnd.Text = "截止时间";
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(74, 21);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(147, 21);
            this.dtpStart.TabIndex = 1;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // labDateStart
            // 
            this.labDateStart.AutoSize = true;
            this.labDateStart.Location = new System.Drawing.Point(15, 25);
            this.labDateStart.Name = "labDateStart";
            this.labDateStart.Size = new System.Drawing.Size(53, 12);
            this.labDateStart.TabIndex = 0;
            this.labDateStart.Text = "起始时间";
            // 
            // labWindState
            // 
            this.labWindState.AutoSize = true;
            this.labWindState.Location = new System.Drawing.Point(31, 439);
            this.labWindState.Name = "labWindState";
            this.labWindState.Size = new System.Drawing.Size(65, 12);
            this.labWindState.TabIndex = 39;
            this.labWindState.Text = "传感器值：";
            // 
            // dgvSystemMsg
            // 
            this.dgvSystemMsg.AllowUserToAddRows = false;
            this.dgvSystemMsg.AllowUserToDeleteRows = false;
            this.dgvSystemMsg.AllowUserToResizeColumns = false;
            this.dgvSystemMsg.AllowUserToResizeRows = false;
            this.dgvSystemMsg.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvSystemMsg.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvSystemMsg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSystemMsg.Location = new System.Drawing.Point(1, 159);
            this.dgvSystemMsg.Name = "dgvSystemMsg";
            this.dgvSystemMsg.ReadOnly = true;
            this.dgvSystemMsg.RowHeadersWidth = 51;
            this.dgvSystemMsg.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvSystemMsg.RowTemplate.Height = 23;
            this.dgvSystemMsg.Size = new System.Drawing.Size(566, 271);
            this.dgvSystemMsg.TabIndex = 38;
            this.dgvSystemMsg.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvSystemMsg_RowPostPaint);
            // 
            // dgvStationOnOff
            // 
            this.dgvStationOnOff.AllowUserToAddRows = false;
            this.dgvStationOnOff.AllowUserToDeleteRows = false;
            this.dgvStationOnOff.AllowUserToResizeColumns = false;
            this.dgvStationOnOff.AllowUserToResizeRows = false;
            this.dgvStationOnOff.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvStationOnOff.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvStationOnOff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStationOnOff.Location = new System.Drawing.Point(568, 159);
            this.dgvStationOnOff.Name = "dgvStationOnOff";
            this.dgvStationOnOff.ReadOnly = true;
            this.dgvStationOnOff.RowHeadersWidth = 51;
            this.dgvStationOnOff.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvStationOnOff.RowTemplate.Height = 23;
            this.dgvStationOnOff.Size = new System.Drawing.Size(564, 409);
            this.dgvStationOnOff.TabIndex = 36;
            this.dgvStationOnOff.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvStationOnOff_RowPostPaint);
            // 
            // dgvDataState
            // 
            this.dgvDataState.AllowUserToAddRows = false;
            this.dgvDataState.AllowUserToDeleteRows = false;
            this.dgvDataState.AllowUserToResizeColumns = false;
            this.dgvDataState.AllowUserToResizeRows = false;
            this.dgvDataState.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvDataState.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDataState.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataState.Location = new System.Drawing.Point(1, 460);
            this.dgvDataState.Name = "dgvDataState";
            this.dgvDataState.ReadOnly = true;
            this.dgvDataState.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvDataState.RowTemplate.Height = 23;
            this.dgvDataState.Size = new System.Drawing.Size(566, 108);
            this.dgvDataState.TabIndex = 37;
            this.dgvDataState.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDataState_RowPostPaint);
            // 
            // 风数据解析
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 568);
            this.Controls.Add(this.labWindState);
            this.Controls.Add(this.dgvSystemMsg);
            this.Controls.Add(this.dgvStationOnOff);
            this.Controls.Add(this.dgvDataState);
            this.Controls.Add(this.labStationOnOff);
            this.Controls.Add(this.labSystem);
            this.Controls.Add(this.tbDateTime);
            this.Controls.Add(this.labDateTime);
            this.Controls.Add(this.tbTotalPageNum);
            this.Controls.Add(this.tbCurrentPageNum);
            this.Controls.Add(this.btnLastPage);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.labTotalPage);
            this.Controls.Add(this.btnFrontPage);
            this.Controls.Add(this.btnFirstPage);
            this.Controls.Add(this.labCurrentPage);
            this.Controls.Add(this.gbPositionK);
            this.Controls.Add(this.gbBroadIp);
            this.Controls.Add(this.gbTime);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1140, 602);
            this.MinimumSize = new System.Drawing.Size(1140, 602);
            this.Name = "风数据解析";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "风数据解析";
            this.Load += new System.EventHandler(this.风数据解析_Load);
            this.gbPositionK.ResumeLayout(false);
            this.gbBroadIp.ResumeLayout(false);
            this.gbTime.ResumeLayout(false);
            this.gbTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSystemMsg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStationOnOff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataState)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labStationOnOff;
        private System.Windows.Forms.Label labSystem;
        private System.Windows.Forms.TextBox tbDateTime;
        private System.Windows.Forms.Label labDateTime;
        private System.Windows.Forms.TextBox tbTotalPageNum;
        private System.Windows.Forms.TextBox tbCurrentPageNum;
        private System.Windows.Forms.Button btnLastPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Label labTotalPage;
        private System.Windows.Forms.Button btnFrontPage;
        private System.Windows.Forms.Button btnFirstPage;
        private System.Windows.Forms.Label labCurrentPage;
        private System.Windows.Forms.GroupBox gbPositionK;
        private System.Windows.Forms.ComboBox cbPositionK;
        private System.Windows.Forms.Label labPositionK;
        private System.Windows.Forms.GroupBox gbBroadIp;
        private System.Windows.Forms.ComboBox cbIp;
        private System.Windows.Forms.Button btnQueryByIp;
        private System.Windows.Forms.Label labBroadIp;
        private System.Windows.Forms.GroupBox gbTime;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label labDateEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label labDateStart;
        private System.Windows.Forms.Label labWindState;
        private System.Windows.Forms.DataGridView dgvSystemMsg;
        private System.Windows.Forms.DataGridView dgvStationOnOff;
        private System.Windows.Forms.DataGridView dgvDataState;
    }
}