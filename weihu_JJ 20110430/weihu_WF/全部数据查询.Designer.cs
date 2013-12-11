namespace weihu_fx
{
    partial class 全部数据查询
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(全部数据查询));
            this.btnDrop = new System.Windows.Forms.Button();
            this.btnWind = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDrop
            // 
            this.btnDrop.Location = new System.Drawing.Point(206, 12);
            this.btnDrop.Name = "btnDrop";
            this.btnDrop.Size = new System.Drawing.Size(96, 37);
            this.btnDrop.TabIndex = 5;
            this.btnDrop.Text = "异物数据查询";
            this.btnDrop.UseVisualStyleBackColor = true;
            this.btnDrop.Click += new System.EventHandler(this.btnDrop_Click);
            // 
            // btnWind
            // 
            this.btnWind.Location = new System.Drawing.Point(64, 12);
            this.btnWind.Name = "btnWind";
            this.btnWind.Size = new System.Drawing.Size(96, 37);
            this.btnWind.TabIndex = 3;
            this.btnWind.Text = "风数据查询";
            this.btnWind.UseVisualStyleBackColor = true;
            this.btnWind.Click += new System.EventHandler(this.btnWind_Click);
            // 
            // 全部数据查询
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 70);
            this.Controls.Add(this.btnDrop);
            this.Controls.Add(this.btnWind);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(383, 104);
            this.MinimumSize = new System.Drawing.Size(383, 104);
            this.Name = "全部数据查询";
            this.Text = "全部数据查询";
            this.Load += new System.EventHandler(this.全部数据查询_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDrop;
        private System.Windows.Forms.Button btnWind;
    }
}