namespace Orion
{
    partial class frmReportReturn
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
            this.components = new System.ComponentModel.Container();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl1121 = new System.Windows.Forms.Label();
            this.cmbItem = new System.Windows.Forms.ComboBox();
            this.rbPurchaseReturnByItem = new System.Windows.Forms.RadioButton();
            this.rbSaleReturnByItem = new System.Windows.Forms.RadioButton();
            this.rbTodayPurchaseReturn = new System.Windows.Forms.RadioButton();
            this.rbPurchaseReturnByDate = new System.Windows.Forms.RadioButton();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.lbl1080 = new System.Windows.Forms.Label();
            this.lbl1129 = new System.Windows.Forms.Label();
            this.lbl1081 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.btnClose = new System.Windows.Forms.Button();
            this.rbSaleReturnByDate = new System.Windows.Forms.RadioButton();
            this.rbTodaySaleReturn = new System.Windows.Forms.RadioButton();
            this.lbl1138 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(932, 40);
            this.panel1.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbl1121);
            this.panel2.Controls.Add(this.cmbItem);
            this.panel2.Controls.Add(this.rbPurchaseReturnByItem);
            this.panel2.Controls.Add(this.rbSaleReturnByItem);
            this.panel2.Controls.Add(this.rbTodayPurchaseReturn);
            this.panel2.Controls.Add(this.rbPurchaseReturnByDate);
            this.panel2.Controls.Add(this.dateFrom);
            this.panel2.Controls.Add(this.lbl1080);
            this.panel2.Controls.Add(this.lbl1129);
            this.panel2.Controls.Add(this.lbl1081);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.dateTo);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.rbSaleReturnByDate);
            this.panel2.Controls.Add(this.rbTodaySaleReturn);
            this.panel2.Controls.Add(this.lbl1138);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(295, 426);
            this.panel2.TabIndex = 18;
            // 
            // lbl1121
            // 
            this.lbl1121.AutoSize = true;
            this.lbl1121.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl1121.Location = new System.Drawing.Point(22, 170);
            this.lbl1121.Name = "lbl1121";
            this.lbl1121.Size = new System.Drawing.Size(33, 17);
            this.lbl1121.TabIndex = 172;
            this.lbl1121.Text = "Item";
            // 
            // cmbItem
            // 
            this.cmbItem.BackColor = System.Drawing.Color.White;
            this.cmbItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.cmbItem.FormattingEnabled = true;
            this.cmbItem.Location = new System.Drawing.Point(86, 167);
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.Size = new System.Drawing.Size(198, 25);
            this.cmbItem.TabIndex = 171;
            // 
            // rbPurchaseReturnByItem
            // 
            this.rbPurchaseReturnByItem.AutoSize = true;
            this.rbPurchaseReturnByItem.Location = new System.Drawing.Point(20, 266);
            this.rbPurchaseReturnByItem.Name = "rbPurchaseReturnByItem";
            this.rbPurchaseReturnByItem.Size = new System.Drawing.Size(208, 21);
            this.rbPurchaseReturnByItem.TabIndex = 164;
            this.rbPurchaseReturnByItem.Text = "Search purchase return by item";
            this.rbPurchaseReturnByItem.UseVisualStyleBackColor = true;
            // 
            // rbSaleReturnByItem
            // 
            this.rbSaleReturnByItem.AutoSize = true;
            this.rbSaleReturnByItem.Location = new System.Drawing.Point(20, 244);
            this.rbSaleReturnByItem.Name = "rbSaleReturnByItem";
            this.rbSaleReturnByItem.Size = new System.Drawing.Size(184, 21);
            this.rbSaleReturnByItem.TabIndex = 163;
            this.rbSaleReturnByItem.Text = "Search sales return by item";
            this.rbSaleReturnByItem.UseVisualStyleBackColor = true;
            // 
            // rbTodayPurchaseReturn
            // 
            this.rbTodayPurchaseReturn.AutoSize = true;
            this.rbTodayPurchaseReturn.Checked = true;
            this.rbTodayPurchaseReturn.Location = new System.Drawing.Point(20, 57);
            this.rbTodayPurchaseReturn.Name = "rbTodayPurchaseReturn";
            this.rbTodayPurchaseReturn.Size = new System.Drawing.Size(166, 21);
            this.rbTodayPurchaseReturn.TabIndex = 162;
            this.rbTodayPurchaseReturn.TabStop = true;
            this.rbTodayPurchaseReturn.Text = "Today\'s purchase return";
            this.rbTodayPurchaseReturn.UseVisualStyleBackColor = true;
            // 
            // rbPurchaseReturnByDate
            // 
            this.rbPurchaseReturnByDate.AutoSize = true;
            this.rbPurchaseReturnByDate.Location = new System.Drawing.Point(20, 221);
            this.rbPurchaseReturnByDate.Name = "rbPurchaseReturnByDate";
            this.rbPurchaseReturnByDate.Size = new System.Drawing.Size(209, 21);
            this.rbPurchaseReturnByDate.TabIndex = 161;
            this.rbPurchaseReturnByDate.Text = "Search purchase return by date";
            this.rbPurchaseReturnByDate.UseVisualStyleBackColor = true;
            // 
            // dateFrom
            // 
            this.dateFrom.CustomFormat = "MMM-dd-yyyy";
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFrom.Location = new System.Drawing.Point(86, 101);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(198, 25);
            this.dateFrom.TabIndex = 157;
            // 
            // lbl1080
            // 
            this.lbl1080.AutoSize = true;
            this.lbl1080.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl1080.Location = new System.Drawing.Point(22, 105);
            this.lbl1080.Name = "lbl1080";
            this.lbl1080.Size = new System.Drawing.Size(38, 17);
            this.lbl1080.TabIndex = 156;
            this.lbl1080.Text = "From";
            // 
            // lbl1129
            // 
            this.lbl1129.AutoSize = true;
            this.lbl1129.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1129.ForeColor = System.Drawing.Color.Silver;
            this.lbl1129.Location = new System.Drawing.Point(12, 81);
            this.lbl1129.Name = "lbl1129";
            this.lbl1129.Size = new System.Drawing.Size(117, 13);
            this.lbl1129.TabIndex = 0;
            this.lbl1129.Text = "Use Criteria ................";
            // 
            // lbl1081
            // 
            this.lbl1081.AutoSize = true;
            this.lbl1081.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl1081.Location = new System.Drawing.Point(22, 136);
            this.lbl1081.Name = "lbl1081";
            this.lbl1081.Size = new System.Drawing.Size(22, 17);
            this.lbl1081.TabIndex = 158;
            this.lbl1081.Text = "To";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Orange;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(77, 298);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(106, 25);
            this.btnRefresh.TabIndex = 157;
            this.btnRefresh.Text = "PREVIEW";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dateTo
            // 
            this.dateTo.CustomFormat = "MMM-dd-yyyy";
            this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTo.Location = new System.Drawing.Point(86, 132);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(198, 25);
            this.dateTo.TabIndex = 159;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Orange;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(189, 298);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 25);
            this.btnClose.TabIndex = 156;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // rbSaleReturnByDate
            // 
            this.rbSaleReturnByDate.AutoSize = true;
            this.rbSaleReturnByDate.Location = new System.Drawing.Point(20, 198);
            this.rbSaleReturnByDate.Name = "rbSaleReturnByDate";
            this.rbSaleReturnByDate.Size = new System.Drawing.Size(185, 21);
            this.rbSaleReturnByDate.TabIndex = 18;
            this.rbSaleReturnByDate.Text = "Search sales return by date";
            this.rbSaleReturnByDate.UseVisualStyleBackColor = true;
            // 
            // rbTodaySaleReturn
            // 
            this.rbTodaySaleReturn.AutoSize = true;
            this.rbTodaySaleReturn.Checked = true;
            this.rbTodaySaleReturn.Location = new System.Drawing.Point(20, 36);
            this.rbTodaySaleReturn.Name = "rbTodaySaleReturn";
            this.rbTodaySaleReturn.Size = new System.Drawing.Size(142, 21);
            this.rbTodaySaleReturn.TabIndex = 0;
            this.rbTodaySaleReturn.TabStop = true;
            this.rbTodaySaleReturn.Text = "Today\'s sales return";
            this.rbTodaySaleReturn.UseVisualStyleBackColor = true;
            // 
            // lbl1138
            // 
            this.lbl1138.AutoSize = true;
            this.lbl1138.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.lbl1138.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl1138.Location = new System.Drawing.Point(13, 3);
            this.lbl1138.Name = "lbl1138";
            this.lbl1138.Size = new System.Drawing.Size(79, 30);
            this.lbl1138.TabIndex = 17;
            this.lbl1138.Text = "Return";
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(295, 40);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(19, 426);
            this.panel4.TabIndex = 19;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.crystalReportViewer1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(314, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(618, 426);
            this.panel3.TabIndex = 20;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ShowCloseButton = false;
            this.crystalReportViewer1.ShowCopyButton = false;
            this.crystalReportViewer1.ShowGroupTreeButton = false;
            this.crystalReportViewer1.ShowLogo = false;
            this.crystalReportViewer1.ShowParameterPanelButton = false;
            this.crystalReportViewer1.ShowRefreshButton = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(618, 426);
            this.crystalReportViewer1.TabIndex = 1;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmReportReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 466);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReportReturn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report -  Return";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReportReturn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbItem;
        private System.Windows.Forms.RadioButton rbPurchaseReturnByItem;
        private System.Windows.Forms.RadioButton rbSaleReturnByItem;
        private System.Windows.Forms.RadioButton rbTodayPurchaseReturn;
        private System.Windows.Forms.RadioButton rbPurchaseReturnByDate;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.Label lbl1080;
        private System.Windows.Forms.Label lbl1129;
        private System.Windows.Forms.Label lbl1081;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.RadioButton rbSaleReturnByDate;
        private System.Windows.Forms.RadioButton rbTodaySaleReturn;
        private System.Windows.Forms.Label lbl1138;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Label lbl1121;
    }
}