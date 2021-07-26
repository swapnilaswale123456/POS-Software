namespace Orion
{
    partial class frmReportSales
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
            this.cmbItemName = new System.Windows.Forms.ComboBox();
            this.rbItem = new System.Windows.Forms.RadioButton();
            this.rbBestProductSale = new System.Windows.Forms.RadioButton();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.rbCustomer = new System.Windows.Forms.RadioButton();
            this.rbQuickSale = new System.Windows.Forms.RadioButton();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.lbl1080 = new System.Windows.Forms.Label();
            this.lbl1129 = new System.Windows.Forms.Label();
            this.lbl1081 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.btnClose = new System.Windows.Forms.Button();
            this.rbPOS = new System.Windows.Forms.RadioButton();
            this.rbToday = new System.Windows.Forms.RadioButton();
            this.lbl1127 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.cmbEmpSale = new System.Windows.Forms.ComboBox();
            this.rbEmpSale = new System.Windows.Forms.RadioButton();
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
            this.panel1.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmbEmpSale);
            this.panel2.Controls.Add(this.rbEmpSale);
            this.panel2.Controls.Add(this.cmbItemName);
            this.panel2.Controls.Add(this.rbItem);
            this.panel2.Controls.Add(this.rbBestProductSale);
            this.panel2.Controls.Add(this.cmbCustomer);
            this.panel2.Controls.Add(this.rbCustomer);
            this.panel2.Controls.Add(this.rbQuickSale);
            this.panel2.Controls.Add(this.dateFrom);
            this.panel2.Controls.Add(this.lbl1080);
            this.panel2.Controls.Add(this.lbl1129);
            this.panel2.Controls.Add(this.lbl1081);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.dateTo);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.rbPOS);
            this.panel2.Controls.Add(this.rbToday);
            this.panel2.Controls.Add(this.lbl1127);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(255, 426);
            this.panel2.TabIndex = 14;
            // 
            // cmbItemName
            // 
            this.cmbItemName.BackColor = System.Drawing.Color.White;
            this.cmbItemName.FormattingEnabled = true;
            this.cmbItemName.Location = new System.Drawing.Point(32, 293);
            this.cmbItemName.Name = "cmbItemName";
            this.cmbItemName.Size = new System.Drawing.Size(198, 25);
            this.cmbItemName.TabIndex = 91;
            // 
            // rbItem
            // 
            this.rbItem.AutoSize = true;
            this.rbItem.Location = new System.Drawing.Point(20, 269);
            this.rbItem.Name = "rbItem";
            this.rbItem.Size = new System.Drawing.Size(112, 21);
            this.rbItem.TabIndex = 171;
            this.rbItem.Text = "Search by Item";
            this.rbItem.UseVisualStyleBackColor = true;
            // 
            // rbBestProductSale
            // 
            this.rbBestProductSale.AutoSize = true;
            this.rbBestProductSale.Location = new System.Drawing.Point(20, 191);
            this.rbBestProductSale.Name = "rbBestProductSale";
            this.rbBestProductSale.Size = new System.Drawing.Size(127, 21);
            this.rbBestProductSale.TabIndex = 170;
            this.rbBestProductSale.Text = "Best Product Sale";
            this.rbBestProductSale.UseVisualStyleBackColor = true;
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.BackColor = System.Drawing.Color.White;
            this.cmbCustomer.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(32, 241);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(198, 25);
            this.cmbCustomer.TabIndex = 169;
            // 
            // rbCustomer
            // 
            this.rbCustomer.AutoSize = true;
            this.rbCustomer.Location = new System.Drawing.Point(20, 215);
            this.rbCustomer.Name = "rbCustomer";
            this.rbCustomer.Size = new System.Drawing.Size(143, 21);
            this.rbCustomer.TabIndex = 161;
            this.rbCustomer.Text = "Search by Customer";
            this.rbCustomer.UseVisualStyleBackColor = true;
            // 
            // rbQuickSale
            // 
            this.rbQuickSale.AutoSize = true;
            this.rbQuickSale.Location = new System.Drawing.Point(20, 168);
            this.rbQuickSale.Name = "rbQuickSale";
            this.rbQuickSale.Size = new System.Drawing.Size(143, 21);
            this.rbQuickSale.TabIndex = 160;
            this.rbQuickSale.Text = "Search by QuickSale";
            this.rbQuickSale.UseVisualStyleBackColor = true;
            // 
            // dateFrom
            // 
            this.dateFrom.CustomFormat = "MMM-dd-yyyy";
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFrom.Location = new System.Drawing.Point(66, 81);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(164, 25);
            this.dateFrom.TabIndex = 157;
            // 
            // lbl1080
            // 
            this.lbl1080.AutoSize = true;
            this.lbl1080.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl1080.Location = new System.Drawing.Point(18, 85);
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
            this.lbl1129.Location = new System.Drawing.Point(12, 61);
            this.lbl1129.Name = "lbl1129";
            this.lbl1129.Size = new System.Drawing.Size(117, 13);
            this.lbl1129.TabIndex = 0;
            this.lbl1129.Text = "Use Criteria ................";
            // 
            // lbl1081
            // 
            this.lbl1081.AutoSize = true;
            this.lbl1081.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl1081.Location = new System.Drawing.Point(18, 116);
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
            this.btnRefresh.Location = new System.Drawing.Point(32, 389);
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
            this.dateTo.Location = new System.Drawing.Point(66, 112);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(164, 25);
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
            this.btnClose.Location = new System.Drawing.Point(144, 389);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 25);
            this.btnClose.TabIndex = 156;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // rbPOS
            // 
            this.rbPOS.AutoSize = true;
            this.rbPOS.Location = new System.Drawing.Point(20, 146);
            this.rbPOS.Name = "rbPOS";
            this.rbPOS.Size = new System.Drawing.Size(111, 21);
            this.rbPOS.TabIndex = 18;
            this.rbPOS.Text = "Search by POS";
            this.rbPOS.UseVisualStyleBackColor = true;
            // 
            // rbToday
            // 
            this.rbToday.AutoSize = true;
            this.rbToday.Checked = true;
            this.rbToday.Location = new System.Drawing.Point(20, 36);
            this.rbToday.Name = "rbToday";
            this.rbToday.Size = new System.Drawing.Size(70, 21);
            this.rbToday.TabIndex = 0;
            this.rbToday.TabStop = true;
            this.rbToday.Text = "Today\'s";
            this.rbToday.UseVisualStyleBackColor = true;
            // 
            // lbl1127
            // 
            this.lbl1127.AutoSize = true;
            this.lbl1127.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.lbl1127.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl1127.Location = new System.Drawing.Point(13, 3);
            this.lbl1127.Name = "lbl1127";
            this.lbl1127.Size = new System.Drawing.Size(53, 30);
            this.lbl1127.TabIndex = 17;
            this.lbl1127.Text = "Sale";
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(255, 40);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(19, 426);
            this.panel4.TabIndex = 15;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.crystalReportViewer1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(274, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(658, 426);
            this.panel3.TabIndex = 16;
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
            this.crystalReportViewer1.Size = new System.Drawing.Size(658, 426);
            this.crystalReportViewer1.TabIndex = 1;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // cmbEmpSale
            // 
            this.cmbEmpSale.BackColor = System.Drawing.Color.White;
            this.cmbEmpSale.FormattingEnabled = true;
            this.cmbEmpSale.Location = new System.Drawing.Point(31, 348);
            this.cmbEmpSale.Name = "cmbEmpSale";
            this.cmbEmpSale.Size = new System.Drawing.Size(198, 25);
            this.cmbEmpSale.TabIndex = 172;
            // 
            // rbEmpSale
            // 
            this.rbEmpSale.AutoSize = true;
            this.rbEmpSale.Location = new System.Drawing.Point(19, 324);
            this.rbEmpSale.Name = "rbEmpSale";
            this.rbEmpSale.Size = new System.Drawing.Size(172, 21);
            this.rbEmpSale.TabIndex = 173;
            this.rbEmpSale.Text = "Search by Employee Sale";
            this.rbEmpSale.UseVisualStyleBackColor = true;
            // 
            // frmReportSales
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
            this.Name = "frmReportSales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report -  Sales";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReportSales_Load);
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
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.RadioButton rbPOS;
        private System.Windows.Forms.RadioButton rbToday;
        private System.Windows.Forms.Label lbl1127;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl1129;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.Label lbl1080;
        private System.Windows.Forms.Label lbl1081;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.RadioButton rbQuickSale;
        private System.Windows.Forms.RadioButton rbCustomer;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.RadioButton rbBestProductSale;
        private System.Windows.Forms.RadioButton rbItem;
        private System.Windows.Forms.ComboBox cmbItemName;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.ComboBox cmbEmpSale;
        private System.Windows.Forms.RadioButton rbEmpSale;
    }
}