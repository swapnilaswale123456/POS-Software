namespace Orion
{
    partial class frmItemInformation
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
			this.btnBrowosePhoto = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.btnDefaultWarehouse = new System.Windows.Forms.Button();
			this.lbl1040 = new System.Windows.Forms.Label();
			this.cmbDefaultWarehouse = new System.Windows.Forms.ComboBox();
			this.btnShelf = new System.Windows.Forms.Button();
			this.cmbShelf = new System.Windows.Forms.ComboBox();
			this.label28 = new System.Windows.Forms.Label();
			this.lbl1043 = new System.Windows.Forms.Label();
			this.txtItemID = new System.Windows.Forms.TextBox();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnAlter = new System.Windows.Forms.Button();
			this.chkExp = new System.Windows.Forms.CheckBox();
			this.btnReset = new System.Windows.Forms.Button();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.txtSalesPrice = new System.Windows.Forms.TextBox();
			this.btnWarehouse = new System.Windows.Forms.Button();
			this.btnGroup = new System.Windows.Forms.Button();
			this.cmbGroup = new System.Windows.Forms.ComboBox();
			this.cmbWarehouse = new System.Windows.Forms.ComboBox();
			this.dtpExpDate = new System.Windows.Forms.DateTimePicker();
			this.label22 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.txtOpeningStock = new System.Windows.Forms.TextBox();
			this.lbl1046 = new System.Windows.Forms.Label();
			this.lbl1044 = new System.Windows.Forms.Label();
			this.lbl1042 = new System.Windows.Forms.Label();
			this.lbl1041 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.chkAutoBarcode = new System.Windows.Forms.CheckBox();
			this.cbVATapplicable = new System.Windows.Forms.CheckBox();
			this.label19 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.txtReorderPoint = new System.Windows.Forms.TextBox();
			this.lbl1039 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnSubmit = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.lbl1029 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.txtPurchaseCost = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.txtBarcode = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.txtBatch = new System.Windows.Forms.TextBox();
			this.txtUnit = new System.Windows.Forms.TextBox();
			this.lbl1037 = new System.Windows.Forms.Label();
			this.lbl1034 = new System.Windows.Forms.Label();
			this.lbl1033 = new System.Windows.Forms.Label();
			this.lbl1032 = new System.Windows.Forms.Label();
			this.lbl1031 = new System.Windows.Forms.Label();
			this.lbl1030 = new System.Windows.Forms.Label();
			this.txtItemName = new System.Windows.Forms.TextBox();
			this.lbl1028 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.lbl1038 = new System.Windows.Forms.Label();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.panel5.SuspendLayout();
			this.SuspendLayout();
			// 
			// errorProvider
			// 
			this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
			this.errorProvider.ContainerControl = this;
			// 
			// btnBrowosePhoto
			// 
			this.btnBrowosePhoto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnBrowosePhoto.Location = new System.Drawing.Point(9, 231);
			this.btnBrowosePhoto.Name = "btnBrowosePhoto";
			this.btnBrowosePhoto.Size = new System.Drawing.Size(145, 23);
			this.btnBrowosePhoto.TabIndex = 47;
			this.btnBrowosePhoto.Text = "Browse Photo";
			this.btnBrowosePhoto.UseVisualStyleBackColor = true;
			this.btnBrowosePhoto.Click += new System.EventHandler(this.btnBrowosePhoto_Click);
			// 
			// panel1
			// 
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1111, 28);
			this.panel1.TabIndex = 6;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btnBrowosePhoto);
			this.panel2.Controls.Add(this.pictureBox1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel2.Location = new System.Drawing.Point(0, 28);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(165, 474);
			this.panel2.TabIndex = 7;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pictureBox1.ErrorImage = global::Orion.Properties.Resources.No_image_found;
			this.pictureBox1.Image = global::Orion.Properties.Resources.No_image_found;
			this.pictureBox1.Location = new System.Drawing.Point(9, 79);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(145, 149);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 46;
			this.pictureBox1.TabStop = false;
			// 
			// panel4
			// 
			this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel4.Location = new System.Drawing.Point(1060, 28);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(51, 474);
			this.panel4.TabIndex = 8;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.btnDefaultWarehouse);
			this.panel5.Controls.Add(this.lbl1040);
			this.panel5.Controls.Add(this.cmbDefaultWarehouse);
			this.panel5.Controls.Add(this.btnShelf);
			this.panel5.Controls.Add(this.cmbShelf);
			this.panel5.Controls.Add(this.label28);
			this.panel5.Controls.Add(this.lbl1043);
			this.panel5.Controls.Add(this.txtItemID);
			this.panel5.Controls.Add(this.btnDelete);
			this.panel5.Controls.Add(this.btnAlter);
			this.panel5.Controls.Add(this.chkExp);
			this.panel5.Controls.Add(this.btnReset);
			this.panel5.Controls.Add(this.btnRefresh);
			this.panel5.Controls.Add(this.txtSalesPrice);
			this.panel5.Controls.Add(this.btnWarehouse);
			this.panel5.Controls.Add(this.btnGroup);
			this.panel5.Controls.Add(this.cmbGroup);
			this.panel5.Controls.Add(this.cmbWarehouse);
			this.panel5.Controls.Add(this.dtpExpDate);
			this.panel5.Controls.Add(this.label22);
			this.panel5.Controls.Add(this.label23);
			this.panel5.Controls.Add(this.label24);
			this.panel5.Controls.Add(this.txtOpeningStock);
			this.panel5.Controls.Add(this.lbl1046);
			this.panel5.Controls.Add(this.lbl1044);
			this.panel5.Controls.Add(this.lbl1042);
			this.panel5.Controls.Add(this.lbl1041);
			this.panel5.Controls.Add(this.label20);
			this.panel5.Controls.Add(this.chkAutoBarcode);
			this.panel5.Controls.Add(this.cbVATapplicable);
			this.panel5.Controls.Add(this.label19);
			this.panel5.Controls.Add(this.label17);
			this.panel5.Controls.Add(this.txtReorderPoint);
			this.panel5.Controls.Add(this.lbl1039);
			this.panel5.Controls.Add(this.label15);
			this.panel5.Controls.Add(this.btnClose);
			this.panel5.Controls.Add(this.btnSubmit);
			this.panel5.Controls.Add(this.label9);
			this.panel5.Controls.Add(this.lbl1029);
			this.panel5.Controls.Add(this.label14);
			this.panel5.Controls.Add(this.label10);
			this.panel5.Controls.Add(this.txtPurchaseCost);
			this.panel5.Controls.Add(this.label13);
			this.panel5.Controls.Add(this.txtBarcode);
			this.panel5.Controls.Add(this.label11);
			this.panel5.Controls.Add(this.txtBatch);
			this.panel5.Controls.Add(this.txtUnit);
			this.panel5.Controls.Add(this.lbl1037);
			this.panel5.Controls.Add(this.lbl1034);
			this.panel5.Controls.Add(this.lbl1033);
			this.panel5.Controls.Add(this.lbl1032);
			this.panel5.Controls.Add(this.lbl1031);
			this.panel5.Controls.Add(this.lbl1030);
			this.panel5.Controls.Add(this.txtItemName);
			this.panel5.Controls.Add(this.lbl1028);
			this.panel5.Controls.Add(this.label12);
			this.panel5.Controls.Add(this.lbl1038);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel5.Location = new System.Drawing.Point(165, 28);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(895, 474);
			this.panel5.TabIndex = 9;
			// 
			// btnDefaultWarehouse
			// 
			this.btnDefaultWarehouse.BackColor = System.Drawing.Color.White;
			this.btnDefaultWarehouse.FlatAppearance.BorderColor = System.Drawing.Color.White;
			this.btnDefaultWarehouse.FlatAppearance.BorderSize = 0;
			this.btnDefaultWarehouse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
			this.btnDefaultWarehouse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
			this.btnDefaultWarehouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDefaultWarehouse.Image = global::Orion.Properties.Resources.Circle_Add__04;
			this.btnDefaultWarehouse.Location = new System.Drawing.Point(446, 305);
			this.btnDefaultWarehouse.Name = "btnDefaultWarehouse";
			this.btnDefaultWarehouse.Size = new System.Drawing.Size(17, 17);
			this.btnDefaultWarehouse.TabIndex = 104;
			this.btnDefaultWarehouse.UseVisualStyleBackColor = false;
			this.btnDefaultWarehouse.Click += new System.EventHandler(this.btnDefaultWarehouse_Click);
			// 
			// lbl1040
			// 
			this.lbl1040.AutoSize = true;
			this.lbl1040.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lbl1040.Location = new System.Drawing.Point(8, 305);
			this.lbl1040.Name = "lbl1040";
			this.lbl1040.Size = new System.Drawing.Size(155, 23);
			this.lbl1040.TabIndex = 103;
			this.lbl1040.Text = "Default Warehouse";
			// 
			// cmbDefaultWarehouse
			// 
			this.cmbDefaultWarehouse.BackColor = System.Drawing.Color.White;
			this.cmbDefaultWarehouse.FormattingEnabled = true;
			this.cmbDefaultWarehouse.Location = new System.Drawing.Point(164, 302);
			this.cmbDefaultWarehouse.Name = "cmbDefaultWarehouse";
			this.cmbDefaultWarehouse.Size = new System.Drawing.Size(318, 29);
			this.cmbDefaultWarehouse.TabIndex = 102;
			// 
			// btnShelf
			// 
			this.btnShelf.BackColor = System.Drawing.Color.White;
			this.btnShelf.FlatAppearance.BorderColor = System.Drawing.Color.White;
			this.btnShelf.FlatAppearance.BorderSize = 0;
			this.btnShelf.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
			this.btnShelf.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
			this.btnShelf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnShelf.Image = global::Orion.Properties.Resources.Circle_Add__04;
			this.btnShelf.Location = new System.Drawing.Point(841, 119);
			this.btnShelf.Name = "btnShelf";
			this.btnShelf.Size = new System.Drawing.Size(17, 17);
			this.btnShelf.TabIndex = 101;
			this.btnShelf.UseVisualStyleBackColor = false;
			this.btnShelf.Click += new System.EventHandler(this.btnShelf_Click);
			// 
			// cmbShelf
			// 
			this.cmbShelf.BackColor = System.Drawing.Color.White;
			this.cmbShelf.FormattingEnabled = true;
			this.cmbShelf.Location = new System.Drawing.Point(659, 115);
			this.cmbShelf.Name = "cmbShelf";
			this.cmbShelf.Size = new System.Drawing.Size(218, 29);
			this.cmbShelf.TabIndex = 100;
			// 
			// label28
			// 
			this.label28.AutoSize = true;
			this.label28.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
			this.label28.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label28.Location = new System.Drawing.Point(642, 119);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(14, 23);
			this.label28.TabIndex = 99;
			this.label28.Text = ":";
			// 
			// lbl1043
			// 
			this.lbl1043.AutoSize = true;
			this.lbl1043.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lbl1043.Location = new System.Drawing.Point(519, 119);
			this.lbl1043.Name = "lbl1043";
			this.lbl1043.Size = new System.Drawing.Size(47, 23);
			this.lbl1043.TabIndex = 98;
			this.lbl1043.Text = "Shelf";
			// 
			// txtItemID
			// 
			this.txtItemID.BackColor = System.Drawing.SystemColors.Control;
			this.txtItemID.Font = new System.Drawing.Font("Segoe UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtItemID.Location = new System.Drawing.Point(483, 83);
			this.txtItemID.Name = "txtItemID";
			this.txtItemID.Size = new System.Drawing.Size(30, 26);
			this.txtItemID.TabIndex = 97;
			this.txtItemID.Visible = false;
			// 
			// btnDelete
			// 
			this.btnDelete.BackColor = System.Drawing.Color.Orange;
			this.btnDelete.FlatAppearance.BorderSize = 0;
			this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDelete.ForeColor = System.Drawing.Color.White;
			this.btnDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnDelete.Location = new System.Drawing.Point(340, 335);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(86, 32);
			this.btnDelete.TabIndex = 96;
			this.btnDelete.Text = "DELETE";
			this.btnDelete.UseVisualStyleBackColor = false;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnAlter
			// 
			this.btnAlter.BackColor = System.Drawing.Color.Orange;
			this.btnAlter.FlatAppearance.BorderSize = 0;
			this.btnAlter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAlter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAlter.ForeColor = System.Drawing.Color.White;
			this.btnAlter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnAlter.Location = new System.Drawing.Point(252, 335);
			this.btnAlter.Name = "btnAlter";
			this.btnAlter.Size = new System.Drawing.Size(86, 32);
			this.btnAlter.TabIndex = 95;
			this.btnAlter.Text = "ALTER";
			this.btnAlter.UseVisualStyleBackColor = false;
			this.btnAlter.Click += new System.EventHandler(this.btnAlter_Click);
			// 
			// chkExp
			// 
			this.chkExp.AutoSize = true;
			this.chkExp.Checked = true;
			this.chkExp.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkExp.Location = new System.Drawing.Point(660, 182);
			this.chkExp.Name = "chkExp";
			this.chkExp.Size = new System.Drawing.Size(173, 27);
			this.chkExp.TabIndex = 94;
			this.chkExp.Text = "An expiration date";
			this.chkExp.UseVisualStyleBackColor = true;
			this.chkExp.CheckedChanged += new System.EventHandler(this.chkExp_CheckedChanged);
			// 
			// btnReset
			// 
			this.btnReset.BackColor = System.Drawing.Color.Orange;
			this.btnReset.FlatAppearance.BorderSize = 0;
			this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnReset.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnReset.ForeColor = System.Drawing.Color.White;
			this.btnReset.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnReset.Location = new System.Drawing.Point(428, 335);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(86, 32);
			this.btnReset.TabIndex = 93;
			this.btnReset.Text = "RESET";
			this.btnReset.UseVisualStyleBackColor = false;
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// btnRefresh
			// 
			this.btnRefresh.BackColor = System.Drawing.Color.Orange;
			this.btnRefresh.FlatAppearance.BorderSize = 0;
			this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnRefresh.ForeColor = System.Drawing.Color.White;
			this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnRefresh.Location = new System.Drawing.Point(516, 335);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(86, 32);
			this.btnRefresh.TabIndex = 92;
			this.btnRefresh.Text = "REFRESH";
			this.btnRefresh.UseVisualStyleBackColor = false;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// txtSalesPrice
			// 
			this.txtSalesPrice.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.txtSalesPrice.Location = new System.Drawing.Point(370, 238);
			this.txtSalesPrice.Name = "txtSalesPrice";
			this.txtSalesPrice.Size = new System.Drawing.Size(112, 29);
			this.txtSalesPrice.TabIndex = 70;
			// 
			// btnWarehouse
			// 
			this.btnWarehouse.BackColor = System.Drawing.Color.White;
			this.btnWarehouse.FlatAppearance.BorderColor = System.Drawing.Color.White;
			this.btnWarehouse.FlatAppearance.BorderSize = 0;
			this.btnWarehouse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
			this.btnWarehouse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
			this.btnWarehouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnWarehouse.Image = global::Orion.Properties.Resources.Circle_Add__04;
			this.btnWarehouse.Location = new System.Drawing.Point(841, 86);
			this.btnWarehouse.Name = "btnWarehouse";
			this.btnWarehouse.Size = new System.Drawing.Size(17, 17);
			this.btnWarehouse.TabIndex = 91;
			this.btnWarehouse.UseVisualStyleBackColor = false;
			this.btnWarehouse.Click += new System.EventHandler(this.btnWarehouse_Click);
			// 
			// btnGroup
			// 
			this.btnGroup.BackColor = System.Drawing.Color.White;
			this.btnGroup.FlatAppearance.BorderColor = System.Drawing.Color.White;
			this.btnGroup.FlatAppearance.BorderSize = 0;
			this.btnGroup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
			this.btnGroup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
			this.btnGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnGroup.Image = global::Orion.Properties.Resources.Circle_Add__04;
			this.btnGroup.Location = new System.Drawing.Point(445, 152);
			this.btnGroup.Name = "btnGroup";
			this.btnGroup.Size = new System.Drawing.Size(17, 17);
			this.btnGroup.TabIndex = 90;
			this.btnGroup.UseVisualStyleBackColor = false;
			this.btnGroup.Click += new System.EventHandler(this.btnGroup_Click);
			// 
			// cmbGroup
			// 
			this.cmbGroup.BackColor = System.Drawing.Color.White;
			this.cmbGroup.FormattingEnabled = true;
			this.cmbGroup.Location = new System.Drawing.Point(164, 148);
			this.cmbGroup.Name = "cmbGroup";
			this.cmbGroup.Size = new System.Drawing.Size(318, 29);
			this.cmbGroup.TabIndex = 89;
			// 
			// cmbWarehouse
			// 
			this.cmbWarehouse.BackColor = System.Drawing.Color.White;
			this.cmbWarehouse.FormattingEnabled = true;
			this.cmbWarehouse.Location = new System.Drawing.Point(659, 82);
			this.cmbWarehouse.Name = "cmbWarehouse";
			this.cmbWarehouse.Size = new System.Drawing.Size(218, 29);
			this.cmbWarehouse.TabIndex = 88;
			// 
			// dtpExpDate
			// 
			this.dtpExpDate.CustomFormat = "MMM-dd-yyyy";
			this.dtpExpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpExpDate.Location = new System.Drawing.Point(659, 213);
			this.dtpExpDate.Name = "dtpExpDate";
			this.dtpExpDate.Size = new System.Drawing.Size(115, 29);
			this.dtpExpDate.TabIndex = 87;
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
			this.label22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label22.Location = new System.Drawing.Point(642, 86);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(14, 23);
			this.label22.TabIndex = 84;
			this.label22.Text = ":";
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
			this.label23.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label23.Location = new System.Drawing.Point(643, 151);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(14, 23);
			this.label23.TabIndex = 85;
			this.label23.Text = ":";
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
			this.label24.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label24.Location = new System.Drawing.Point(643, 217);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(14, 23);
			this.label24.TabIndex = 86;
			this.label24.Text = ":";
			// 
			// txtOpeningStock
			// 
			this.txtOpeningStock.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.txtOpeningStock.Location = new System.Drawing.Point(659, 147);
			this.txtOpeningStock.Name = "txtOpeningStock";
			this.txtOpeningStock.Size = new System.Drawing.Size(115, 29);
			this.txtOpeningStock.TabIndex = 83;
			// 
			// lbl1046
			// 
			this.lbl1046.AutoSize = true;
			this.lbl1046.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lbl1046.Location = new System.Drawing.Point(520, 217);
			this.lbl1046.Name = "lbl1046";
			this.lbl1046.Size = new System.Drawing.Size(94, 23);
			this.lbl1046.TabIndex = 82;
			this.lbl1046.Text = "Expiry date";
			// 
			// lbl1044
			// 
			this.lbl1044.AutoSize = true;
			this.lbl1044.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lbl1044.Location = new System.Drawing.Point(520, 151);
			this.lbl1044.Name = "lbl1044";
			this.lbl1044.Size = new System.Drawing.Size(113, 23);
			this.lbl1044.TabIndex = 81;
			this.lbl1044.Text = "Opening Unit";
			// 
			// lbl1042
			// 
			this.lbl1042.AutoSize = true;
			this.lbl1042.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lbl1042.Location = new System.Drawing.Point(519, 86);
			this.lbl1042.Name = "lbl1042";
			this.lbl1042.Size = new System.Drawing.Size(95, 23);
			this.lbl1042.TabIndex = 80;
			this.lbl1042.Text = "Warehouse";
			// 
			// lbl1041
			// 
			this.lbl1041.AutoSize = true;
			this.lbl1041.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl1041.ForeColor = System.Drawing.Color.Gray;
			this.lbl1041.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lbl1041.Location = new System.Drawing.Point(519, 55);
			this.lbl1041.Name = "lbl1041";
			this.lbl1041.Size = new System.Drawing.Size(129, 23);
			this.lbl1041.TabIndex = 79;
			this.lbl1041.Text = "Opening Stock";
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
			this.label20.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label20.Location = new System.Drawing.Point(147, 213);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(14, 23);
			this.label20.TabIndex = 78;
			this.label20.Text = ":";
			// 
			// chkAutoBarcode
			// 
			this.chkAutoBarcode.AutoSize = true;
			this.chkAutoBarcode.Checked = true;
			this.chkAutoBarcode.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkAutoBarcode.Location = new System.Drawing.Point(164, 212);
			this.chkAutoBarcode.Name = "chkAutoBarcode";
			this.chkAutoBarcode.Size = new System.Drawing.Size(209, 27);
			this.chkAutoBarcode.TabIndex = 77;
			this.chkAutoBarcode.Text = "Auto generate Barcode";
			this.chkAutoBarcode.UseVisualStyleBackColor = true;
			// 
			// cbVATapplicable
			// 
			this.cbVATapplicable.AutoSize = true;
			this.cbVATapplicable.Location = new System.Drawing.Point(369, 211);
			this.cbVATapplicable.Name = "cbVATapplicable";
			this.cbVATapplicable.Size = new System.Drawing.Size(145, 27);
			this.cbVATapplicable.TabIndex = 76;
			this.cbVATapplicable.Text = "VAT Applicable";
			this.cbVATapplicable.UseVisualStyleBackColor = true;
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
			this.label19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label19.Location = new System.Drawing.Point(148, 305);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(14, 23);
			this.label19.TabIndex = 75;
			this.label19.Text = ":";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
			this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label17.Location = new System.Drawing.Point(148, 275);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(14, 23);
			this.label17.TabIndex = 74;
			this.label17.Text = ":";
			// 
			// txtReorderPoint
			// 
			this.txtReorderPoint.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.txtReorderPoint.Location = new System.Drawing.Point(164, 271);
			this.txtReorderPoint.Name = "txtReorderPoint";
			this.txtReorderPoint.Size = new System.Drawing.Size(115, 29);
			this.txtReorderPoint.TabIndex = 73;
			// 
			// lbl1039
			// 
			this.lbl1039.AutoSize = true;
			this.lbl1039.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lbl1039.Location = new System.Drawing.Point(10, 275);
			this.lbl1039.Name = "lbl1039";
			this.lbl1039.Size = new System.Drawing.Size(114, 23);
			this.lbl1039.TabIndex = 72;
			this.lbl1039.Text = "Reorder Point";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
			this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label15.Location = new System.Drawing.Point(360, 242);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(14, 23);
			this.label15.TabIndex = 71;
			this.label15.Text = ":";
			// 
			// btnClose
			// 
			this.btnClose.BackColor = System.Drawing.Color.Orange;
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnClose.ForeColor = System.Drawing.Color.White;
			this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnClose.Location = new System.Drawing.Point(604, 335);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(86, 32);
			this.btnClose.TabIndex = 68;
			this.btnClose.Text = "CLOSE";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnSubmit
			// 
			this.btnSubmit.BackColor = System.Drawing.Color.Orange;
			this.btnSubmit.FlatAppearance.BorderSize = 0;
			this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSubmit.ForeColor = System.Drawing.Color.White;
			this.btnSubmit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnSubmit.Location = new System.Drawing.Point(164, 335);
			this.btnSubmit.Name = "btnSubmit";
			this.btnSubmit.Size = new System.Drawing.Size(86, 32);
			this.btnSubmit.TabIndex = 67;
			this.btnSubmit.Text = "SAVE";
			this.btnSubmit.UseVisualStyleBackColor = false;
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
			this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label9.Location = new System.Drawing.Point(148, 242);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(14, 23);
			this.label9.TabIndex = 66;
			this.label9.Text = ":";
			// 
			// lbl1029
			// 
			this.lbl1029.AutoSize = true;
			this.lbl1029.ForeColor = System.Drawing.Color.DimGray;
			this.lbl1029.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lbl1029.Location = new System.Drawing.Point(8, 38);
			this.lbl1029.Name = "lbl1029";
			this.lbl1029.Size = new System.Drawing.Size(435, 23);
			this.lbl1029.TabIndex = 60;
			this.lbl1029.Text = "You are required to fill the following details of the item: ";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
			this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label14.Location = new System.Drawing.Point(148, 86);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(14, 23);
			this.label14.TabIndex = 61;
			this.label14.Text = ":";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
			this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label10.Location = new System.Drawing.Point(148, 185);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(14, 23);
			this.label10.TabIndex = 65;
			this.label10.Text = ":";
			// 
			// txtPurchaseCost
			// 
			this.txtPurchaseCost.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.txtPurchaseCost.Location = new System.Drawing.Point(164, 238);
			this.txtPurchaseCost.Name = "txtPurchaseCost";
			this.txtPurchaseCost.Size = new System.Drawing.Size(115, 29);
			this.txtPurchaseCost.TabIndex = 59;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
			this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label13.Location = new System.Drawing.Point(148, 119);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(14, 23);
			this.label13.TabIndex = 62;
			this.label13.Text = ":";
			// 
			// txtBarcode
			// 
			this.txtBarcode.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.txtBarcode.Location = new System.Drawing.Point(164, 181);
			this.txtBarcode.Name = "txtBarcode";
			this.txtBarcode.Size = new System.Drawing.Size(318, 29);
			this.txtBarcode.TabIndex = 58;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
			this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label11.Location = new System.Drawing.Point(148, 152);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(14, 23);
			this.label11.TabIndex = 64;
			this.label11.Text = ":";
			// 
			// txtBatch
			// 
			this.txtBatch.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.txtBatch.Location = new System.Drawing.Point(370, 115);
			this.txtBatch.Name = "txtBatch";
			this.txtBatch.Size = new System.Drawing.Size(112, 29);
			this.txtBatch.TabIndex = 57;
			// 
			// txtUnit
			// 
			this.txtUnit.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.txtUnit.Location = new System.Drawing.Point(164, 115);
			this.txtUnit.Name = "txtUnit";
			this.txtUnit.Size = new System.Drawing.Size(115, 29);
			this.txtUnit.TabIndex = 56;
			// 
			// lbl1037
			// 
			this.lbl1037.AutoSize = true;
			this.lbl1037.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lbl1037.Location = new System.Drawing.Point(10, 242);
			this.lbl1037.Name = "lbl1037";
			this.lbl1037.Size = new System.Drawing.Size(118, 23);
			this.lbl1037.TabIndex = 55;
			this.lbl1037.Text = "Purchase Cost";
			// 
			// lbl1034
			// 
			this.lbl1034.AutoSize = true;
			this.lbl1034.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lbl1034.Location = new System.Drawing.Point(10, 185);
			this.lbl1034.Name = "lbl1034";
			this.lbl1034.Size = new System.Drawing.Size(72, 23);
			this.lbl1034.TabIndex = 54;
			this.lbl1034.Text = "Barcode";
			// 
			// lbl1033
			// 
			this.lbl1033.AutoSize = true;
			this.lbl1033.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lbl1033.Location = new System.Drawing.Point(10, 152);
			this.lbl1033.Name = "lbl1033";
			this.lbl1033.Size = new System.Drawing.Size(109, 23);
			this.lbl1033.TabIndex = 53;
			this.lbl1033.Text = "Group Name";
			// 
			// lbl1032
			// 
			this.lbl1032.AutoSize = true;
			this.lbl1032.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lbl1032.Location = new System.Drawing.Point(312, 119);
			this.lbl1032.Name = "lbl1032";
			this.lbl1032.Size = new System.Drawing.Size(53, 23);
			this.lbl1032.TabIndex = 52;
			this.lbl1032.Text = "Batch";
			// 
			// lbl1031
			// 
			this.lbl1031.AutoSize = true;
			this.lbl1031.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lbl1031.Location = new System.Drawing.Point(10, 119);
			this.lbl1031.Name = "lbl1031";
			this.lbl1031.Size = new System.Drawing.Size(42, 23);
			this.lbl1031.TabIndex = 51;
			this.lbl1031.Text = "Unit";
			// 
			// lbl1030
			// 
			this.lbl1030.AutoSize = true;
			this.lbl1030.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lbl1030.Location = new System.Drawing.Point(10, 86);
			this.lbl1030.Name = "lbl1030";
			this.lbl1030.Size = new System.Drawing.Size(96, 23);
			this.lbl1030.TabIndex = 50;
			this.lbl1030.Text = "Item Name";
			// 
			// txtItemName
			// 
			this.txtItemName.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.txtItemName.Location = new System.Drawing.Point(164, 82);
			this.txtItemName.Name = "txtItemName";
			this.txtItemName.Size = new System.Drawing.Size(318, 29);
			this.txtItemName.TabIndex = 49;
			// 
			// lbl1028
			// 
			this.lbl1028.AutoSize = true;
			this.lbl1028.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
			this.lbl1028.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lbl1028.Location = new System.Drawing.Point(6, 4);
			this.lbl1028.Name = "lbl1028";
			this.lbl1028.Size = new System.Drawing.Size(239, 37);
			this.lbl1028.TabIndex = 48;
			this.lbl1028.Text = "Item Information";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
			this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label12.Location = new System.Drawing.Point(357, 119);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(14, 23);
			this.label12.TabIndex = 63;
			this.label12.Text = ":";
			// 
			// lbl1038
			// 
			this.lbl1038.AutoSize = true;
			this.lbl1038.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lbl1038.Location = new System.Drawing.Point(294, 242);
			this.lbl1038.Name = "lbl1038";
			this.lbl1038.Size = new System.Drawing.Size(90, 23);
			this.lbl1038.TabIndex = 69;
			this.lbl1038.Text = "Sales Price";
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "openFileDialog";
			// 
			// frmItemInformation
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1111, 502);
			this.ControlBox = false;
			this.Controls.Add(this.panel5);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmItemInformation";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Item Information";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmItemInformation_Load);
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button btnBrowosePhoto;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnWarehouse;
        private System.Windows.Forms.Button btnGroup;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.ComboBox cmbWarehouse;
        private System.Windows.Forms.DateTimePicker dtpExpDate;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtOpeningStock;
        private System.Windows.Forms.Label lbl1046;
        private System.Windows.Forms.Label lbl1044;
        private System.Windows.Forms.Label lbl1042;
        private System.Windows.Forms.Label lbl1041;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox chkAutoBarcode;
        private System.Windows.Forms.CheckBox cbVATapplicable;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtReorderPoint;
        private System.Windows.Forms.Label lbl1039;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtSalesPrice;
        private System.Windows.Forms.Label lbl1038;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl1029;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPurchaseCost;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtBatch;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Label lbl1037;
        private System.Windows.Forms.Label lbl1034;
        private System.Windows.Forms.Label lbl1033;
        private System.Windows.Forms.Label lbl1032;
        private System.Windows.Forms.Label lbl1031;
        private System.Windows.Forms.Label lbl1030;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label lbl1028;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.CheckBox chkExp;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAlter;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnShelf;
        private System.Windows.Forms.ComboBox cmbShelf;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label lbl1043;
        private System.Windows.Forms.Label lbl1040;
        private System.Windows.Forms.ComboBox cmbDefaultWarehouse;
        private System.Windows.Forms.Button btnDefaultWarehouse;
        private System.Windows.Forms.TextBox txtItemID;
    }
}