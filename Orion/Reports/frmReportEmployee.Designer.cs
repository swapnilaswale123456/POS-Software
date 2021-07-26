namespace Orion
{
    partial class frmReportEmployee
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
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.rbPaymentByEmp = new System.Windows.Forms.RadioButton();
            this.rbPaymentByDate = new System.Windows.Forms.RadioButton();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.lbl1080 = new System.Windows.Forms.Label();
            this.lbl1129 = new System.Windows.Forms.Label();
            this.lbl1081 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.btnClose = new System.Windows.Forms.Button();
            this.rbAttnByDate = new System.Windows.Forms.RadioButton();
            this.rbEmpList = new System.Windows.Forms.RadioButton();
            this.lbl1151 = new System.Windows.Forms.Label();
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
            this.panel1.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmbEmployee);
            this.panel2.Controls.Add(this.rbPaymentByEmp);
            this.panel2.Controls.Add(this.rbPaymentByDate);
            this.panel2.Controls.Add(this.dateFrom);
            this.panel2.Controls.Add(this.lbl1080);
            this.panel2.Controls.Add(this.lbl1129);
            this.panel2.Controls.Add(this.lbl1081);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.dateTo);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.rbAttnByDate);
            this.panel2.Controls.Add(this.rbEmpList);
            this.panel2.Controls.Add(this.lbl1151);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(277, 426);
            this.panel2.TabIndex = 16;
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmployee.FormattingEnabled = true;
            this.cmbEmployee.Location = new System.Drawing.Point(46, 220);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(203, 25);
            this.cmbEmployee.TabIndex = 163;
            // 
            // rbPaymentByEmp
            // 
            this.rbPaymentByEmp.AutoSize = true;
            this.rbPaymentByEmp.Location = new System.Drawing.Point(21, 191);
            this.rbPaymentByEmp.Name = "rbPaymentByEmp";
            this.rbPaymentByEmp.Size = new System.Drawing.Size(228, 21);
            this.rbPaymentByEmp.TabIndex = 162;
            this.rbPaymentByEmp.Text = "Search employee payment by date";
            this.rbPaymentByEmp.UseVisualStyleBackColor = true;
            // 
            // rbPaymentByDate
            // 
            this.rbPaymentByDate.AutoSize = true;
            this.rbPaymentByDate.Location = new System.Drawing.Point(20, 169);
            this.rbPaymentByDate.Name = "rbPaymentByDate";
            this.rbPaymentByDate.Size = new System.Drawing.Size(167, 21);
            this.rbPaymentByDate.TabIndex = 161;
            this.rbPaymentByDate.Text = "Search payment by date";
            this.rbPaymentByDate.UseVisualStyleBackColor = true;
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
            this.lbl1080.Location = new System.Drawing.Point(20, 85);
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
            this.lbl1081.Location = new System.Drawing.Point(20, 116);
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
            this.btnRefresh.Location = new System.Drawing.Point(46, 251);
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
            this.btnClose.Location = new System.Drawing.Point(158, 251);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(91, 25);
            this.btnClose.TabIndex = 156;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // rbAttnByDate
            // 
            this.rbAttnByDate.AutoSize = true;
            this.rbAttnByDate.Location = new System.Drawing.Point(20, 146);
            this.rbAttnByDate.Name = "rbAttnByDate";
            this.rbAttnByDate.Size = new System.Drawing.Size(181, 21);
            this.rbAttnByDate.TabIndex = 18;
            this.rbAttnByDate.Text = "Search attendance by date";
            this.rbAttnByDate.UseVisualStyleBackColor = true;
            // 
            // rbEmpList
            // 
            this.rbEmpList.AutoSize = true;
            this.rbEmpList.Checked = true;
            this.rbEmpList.Location = new System.Drawing.Point(20, 36);
            this.rbEmpList.Name = "rbEmpList";
            this.rbEmpList.Size = new System.Drawing.Size(106, 21);
            this.rbEmpList.TabIndex = 0;
            this.rbEmpList.TabStop = true;
            this.rbEmpList.Text = "Employee List";
            this.rbEmpList.UseVisualStyleBackColor = true;
            // 
            // lbl1151
            // 
            this.lbl1151.AutoSize = true;
            this.lbl1151.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.lbl1151.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl1151.Location = new System.Drawing.Point(13, 3);
            this.lbl1151.Name = "lbl1151";
            this.lbl1151.Size = new System.Drawing.Size(108, 30);
            this.lbl1151.TabIndex = 17;
            this.lbl1151.Text = "Employee";
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(277, 40);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(19, 426);
            this.panel4.TabIndex = 17;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.crystalReportViewer1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(296, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(636, 426);
            this.panel3.TabIndex = 18;
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
            this.crystalReportViewer1.Size = new System.Drawing.Size(636, 426);
            this.crystalReportViewer1.TabIndex = 1;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmReportEmployee
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
            this.Name = "frmReportEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report - Employee";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReportEmployee_Load);
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
        private System.Windows.Forms.RadioButton rbPaymentByDate;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.Label lbl1080;
        private System.Windows.Forms.Label lbl1129;
        private System.Windows.Forms.Label lbl1081;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.RadioButton rbAttnByDate;
        private System.Windows.Forms.RadioButton rbEmpList;
        private System.Windows.Forms.Label lbl1151;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.RadioButton rbPaymentByEmp;
        private System.Windows.Forms.ComboBox cmbEmployee;
    }
}