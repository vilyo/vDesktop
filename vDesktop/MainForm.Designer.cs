namespace vDesktop
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnDownload = new System.Windows.Forms.Button();
            this.cbIsAutoStart = new System.Windows.Forms.CheckBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.timerWaitDownload = new System.Timers.Timer();
            this.txtTitle = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.timerWaitDownload)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(28, 27);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 0;
            this.btnDownload.Text = "手动下载";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // cbIsAutoStart
            // 
            this.cbIsAutoStart.AutoSize = true;
            this.cbIsAutoStart.Location = new System.Drawing.Point(28, 72);
            this.cbIsAutoStart.Name = "cbIsAutoStart";
            this.cbIsAutoStart.Size = new System.Drawing.Size(72, 16);
            this.cbIsAutoStart.TabIndex = 1;
            this.cbIsAutoStart.Text = "自动启动";
            this.cbIsAutoStart.UseVisualStyleBackColor = true;
            this.cbIsAutoStart.CheckedChanged += new System.EventHandler(this.cbIsAutoStart_CheckedChanged);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // timerWaitDownload
            // 
            this.timerWaitDownload.Enabled = true;
            this.timerWaitDownload.SynchronizingObject = this;
            this.timerWaitDownload.Elapsed += new System.Timers.ElapsedEventHandler(this.timerWaitDownload_Elapsed);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(28, 105);
            this.txtTitle.Multiline = true;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(231, 83);
            this.txtTitle.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.cbIsAutoStart);
            this.Controls.Add(this.btnDownload);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "vDesktop";
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.timerWaitDownload)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.CheckBox cbIsAutoStart;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Timers.Timer timerWaitDownload;
        private System.Windows.Forms.TextBox txtTitle;
    }
}

