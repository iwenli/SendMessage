namespace SendMessage.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtUid = new System.Windows.Forms.TextBox();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.ts = new System.Windows.Forms.ToolStrip();
            this.tsLogin = new System.Windows.Forms.ToolStripButton();
            this.tsLogout = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsExit = new System.Windows.Forms.ToolStripButton();
            this.panelQueryParam = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cbFrom = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.ts.SuspendLayout();
            this.panelQueryParam.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUid
            // 
            this.txtUid.Location = new System.Drawing.Point(106, 58);
            this.txtUid.Name = "txtUid";
            this.txtUid.Size = new System.Drawing.Size(180, 23);
            this.txtUid.TabIndex = 0;
            this.txtUid.Text = "5627228";
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.ForeColor = System.Drawing.Color.Gray;
            this.txtLog.Location = new System.Drawing.Point(0, 239);
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(1075, 470);
            this.txtLog.TabIndex = 1;
            this.txtLog.Text = "";
            // 
            // ts
            // 
            this.ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLogin,
            this.tsLogout,
            this.toolStripSeparator1,
            this.tsExit});
            this.ts.Location = new System.Drawing.Point(0, 0);
            this.ts.Name = "ts";
            this.ts.Size = new System.Drawing.Size(1075, 25);
            this.ts.TabIndex = 3;
            this.ts.Text = "toolStrip1";
            // 
            // tsLogin
            // 
            this.tsLogin.Image = global::SendMessage.Properties.Resources.user_16;
            this.tsLogin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsLogin.Name = "tsLogin";
            this.tsLogin.Size = new System.Drawing.Size(64, 22);
            this.tsLogin.Text = "登录(&I)";
            // 
            // tsLogout
            // 
            this.tsLogout.Enabled = false;
            this.tsLogout.Image = global::SendMessage.Properties.Resources.left_16;
            this.tsLogout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsLogout.Name = "tsLogout";
            this.tsLogout.Size = new System.Drawing.Size(66, 22);
            this.tsLogout.Text = "注销(&L)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsExit
            // 
            this.tsExit.Image = global::SendMessage.Properties.Resources.block_16;
            this.tsExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsExit.Name = "tsExit";
            this.tsExit.Size = new System.Drawing.Size(68, 22);
            this.tsExit.Text = "退出(&X)";
            // 
            // panelQueryParam
            // 
            this.panelQueryParam.Controls.Add(this.btnSend);
            this.panelQueryParam.Controls.Add(this.btnSearch);
            this.panelQueryParam.Controls.Add(this.txtMsg);
            this.panelQueryParam.Controls.Add(this.txtUid);
            this.panelQueryParam.Controls.Add(this.label3);
            this.panelQueryParam.Controls.Add(this.cbFrom);
            this.panelQueryParam.Controls.Add(this.label2);
            this.panelQueryParam.Controls.Add(this.label1);
            this.panelQueryParam.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelQueryParam.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelQueryParam.Location = new System.Drawing.Point(0, 25);
            this.panelQueryParam.Name = "panelQueryParam";
            this.panelQueryParam.Size = new System.Drawing.Size(1075, 214);
            this.panelQueryParam.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(968, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(95, 34);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "查询";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // cbFrom
            // 
            this.cbFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbFrom.FormattingEnabled = true;
            this.cbFrom.Items.AddRange(new object[] {
            "妈妈帮"});
            this.cbFrom.Location = new System.Drawing.Point(106, 13);
            this.cbFrom.Name = "cbFrom";
            this.cbFrom.Size = new System.Drawing.Size(180, 25);
            this.cbFrom.TabIndex = 0;
            this.cbFrom.Text = "妈妈帮";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "平台：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "用户：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(12, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 41);
            this.label3.TabIndex = 0;
            this.label3.Text = "发送   \r\n的内容：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(106, 96);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(180, 80);
            this.txtMsg.TabIndex = 0;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Enabled = false;
            this.btnSend.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSend.Location = new System.Drawing.Point(338, 142);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(95, 34);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "发送";
            this.btnSend.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1075, 709);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.panelQueryParam);
            this.Controls.Add(this.ts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "MainForm";
            this.ShowIcon = true;
            this.ShowInTaskbar = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.ts.ResumeLayout(false);
            this.ts.PerformLayout();
            this.panelQueryParam.ResumeLayout(false);
            this.panelQueryParam.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.TextBox txtUid;
        private System.Windows.Forms.ToolStrip ts;
        private System.Windows.Forms.ToolStripButton tsLogin;
        private System.Windows.Forms.ToolStripButton tsLogout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsExit;
        private System.Windows.Forms.Panel panelQueryParam;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cbFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSend;
    }
}