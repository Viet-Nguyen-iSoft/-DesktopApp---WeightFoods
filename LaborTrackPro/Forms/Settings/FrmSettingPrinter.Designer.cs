namespace LaborTrackPro.Forms.Settings
{
  partial class FrmSettingPrinter
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
      DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
      DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
      tableLayoutPanel1 = new TableLayoutPanel();
      tableLayoutPanel3 = new TableLayoutPanel();
      dgv = new DataGridView();
      tableLayoutPanel5 = new TableLayoutPanel();
      btnAddNew = new LaborTrackPro.Custom.RJButton();
      label1 = new Label();
      label3 = new Label();
      tableLayoutPanel4 = new TableLayoutPanel();
      label4 = new Label();
      btnSaveIpPrintA4 = new LaborTrackPro.Custom.RJButton();
      cbbPrinterA4 = new ComboBox();
      tableLayoutPanel2 = new TableLayoutPanel();
      tableLayoutPanel6 = new TableLayoutPanel();
      tableLayoutPanel8 = new TableLayoutPanel();
      label5 = new Label();
      numberLabelWeight = new NumericUpDown();
      btnDownNumberLabelWeight = new LaborTrackPro.Custom.RJButton();
      btnUpNumberLabelWeight = new LaborTrackPro.Custom.RJButton();
      tableLayoutPanel7 = new TableLayoutPanel();
      label6 = new Label();
      txtIpPrintWeight = new CustomControls.RJControls.RJTextBox();
      btnSaveIpPrintWeight = new LaborTrackPro.Custom.RJButton();
      label2 = new Label();
      tableLayoutPanel1.SuspendLayout();
      tableLayoutPanel3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
      tableLayoutPanel5.SuspendLayout();
      tableLayoutPanel4.SuspendLayout();
      tableLayoutPanel2.SuspendLayout();
      tableLayoutPanel6.SuspendLayout();
      tableLayoutPanel8.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)numberLabelWeight).BeginInit();
      tableLayoutPanel7.SuspendLayout();
      SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.BackColor = Color.White;
      tableLayoutPanel1.ColumnCount = 3;
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 18F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 18F));
      tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 1, 3);
      tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 1);
      tableLayoutPanel1.Dock = DockStyle.Fill;
      tableLayoutPanel1.Location = new Point(0, 0);
      tableLayoutPanel1.Margin = new Padding(0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 5;
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 200F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 18F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel1.Size = new Size(1130, 800);
      tableLayoutPanel1.TabIndex = 2;
      // 
      // tableLayoutPanel3
      // 
      tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel3.BackColor = Color.Gainsboro;
      tableLayoutPanel3.ColumnCount = 1;
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel3.Controls.Add(dgv, 0, 6);
      tableLayoutPanel3.Controls.Add(tableLayoutPanel5, 0, 4);
      tableLayoutPanel3.Controls.Add(label3, 0, 0);
      tableLayoutPanel3.Controls.Add(tableLayoutPanel4, 0, 2);
      tableLayoutPanel3.Location = new Point(21, 240);
      tableLayoutPanel3.Margin = new Padding(3, 2, 3, 2);
      tableLayoutPanel3.Name = "tableLayoutPanel3";
      tableLayoutPanel3.RowCount = 8;
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 65F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 3F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 65F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 5F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 65F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 3F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
      tableLayoutPanel3.Size = new Size(1088, 538);
      tableLayoutPanel3.TabIndex = 9;
      // 
      // dgv
      // 
      dgv.AllowUserToAddRows = false;
      dgv.AllowUserToResizeRows = false;
      dataGridViewCellStyle1.BackColor = Color.White;
      dataGridViewCellStyle1.Font = new Font("Roboto", 15.75F);
      dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
      dgv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      dgv.BackgroundColor = Color.Gainsboro;
      dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle2.BackColor = Color.FromArgb(228, 148, 1);
      dataGridViewCellStyle2.Font = new Font("Roboto", 15.75F, FontStyle.Bold);
      dataGridViewCellStyle2.ForeColor = SystemColors.Window;
      dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(228, 148, 1);
      dataGridViewCellStyle2.SelectionForeColor = SystemColors.Window;
      dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
      dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
      dgv.ColumnHeadersHeight = 45;
      dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle3.BackColor = SystemColors.Window;
      dataGridViewCellStyle3.Font = new Font("Roboto", 15.75F);
      dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
      dataGridViewCellStyle3.SelectionBackColor = Color.Transparent;
      dataGridViewCellStyle3.SelectionForeColor = Color.Black;
      dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
      dgv.DefaultCellStyle = dataGridViewCellStyle3;
      dgv.EnableHeadersVisualStyles = false;
      dgv.Location = new Point(10, 208);
      dgv.Margin = new Padding(10, 2, 10, 2);
      dgv.Name = "dgv";
      dgv.ReadOnly = true;
      dgv.RowHeadersVisible = false;
      dgv.RowHeadersWidth = 30;
      dgv.RowTemplate.Height = 60;
      dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      dgv.Size = new Size(1068, 313);
      dgv.TabIndex = 2;
      // 
      // tableLayoutPanel5
      // 
      tableLayoutPanel5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel5.BackColor = Color.Transparent;
      tableLayoutPanel5.ColumnCount = 3;
      tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
      tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
      tableLayoutPanel5.Controls.Add(btnAddNew, 1, 0);
      tableLayoutPanel5.Controls.Add(label1, 0, 0);
      tableLayoutPanel5.Location = new Point(0, 138);
      tableLayoutPanel5.Margin = new Padding(0);
      tableLayoutPanel5.Name = "tableLayoutPanel5";
      tableLayoutPanel5.RowCount = 1;
      tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel5.Size = new Size(1088, 65);
      tableLayoutPanel5.TabIndex = 12;
      // 
      // btnAddNew
      // 
      btnAddNew.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      btnAddNew.BackColor = Color.FromArgb(49, 68, 108);
      btnAddNew.BackgroundColor = Color.FromArgb(49, 68, 108);
      btnAddNew.BorderColor = Color.PaleVioletRed;
      btnAddNew.BorderRadius = 5;
      btnAddNew.BorderSize = 0;
      btnAddNew.FlatAppearance.BorderSize = 0;
      btnAddNew.FlatStyle = FlatStyle.Flat;
      btnAddNew.Font = new Font("Roboto", 20.25F, FontStyle.Bold);
      btnAddNew.ForeColor = Color.White;
      btnAddNew.Location = new Point(901, 5);
      btnAddNew.Name = "btnAddNew";
      btnAddNew.Size = new Size(174, 55);
      btnAddNew.TabIndex = 11;
      btnAddNew.Text = "Thêm mới";
      btnAddNew.TextColor = Color.White;
      btnAddNew.UseVisualStyleBackColor = false;
      btnAddNew.Click += btnAddNew_Click;
      // 
      // label1
      // 
      label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label1.AutoSize = true;
      label1.Font = new Font("Roboto Light", 20.25F);
      label1.ForeColor = Color.Black;
      label1.Location = new Point(0, 0);
      label1.Margin = new Padding(0);
      label1.Name = "label1";
      label1.Size = new Size(898, 65);
      label1.TabIndex = 10;
      label1.Text = "Danh sách phiếu in";
      label1.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // label3
      // 
      label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label3.AutoSize = true;
      label3.BackColor = Color.Silver;
      label3.Font = new Font("Roboto", 20.25F, FontStyle.Bold);
      label3.ForeColor = Color.Black;
      label3.Location = new Point(0, 0);
      label3.Margin = new Padding(0);
      label3.Name = "label3";
      label3.Size = new Size(1088, 65);
      label3.TabIndex = 13;
      label3.Text = "Cài đặt máy in phiếu A4";
      label3.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // tableLayoutPanel4
      // 
      tableLayoutPanel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel4.ColumnCount = 5;
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
      tableLayoutPanel4.Controls.Add(label4, 0, 0);
      tableLayoutPanel4.Controls.Add(btnSaveIpPrintA4, 3, 0);
      tableLayoutPanel4.Controls.Add(cbbPrinterA4, 1, 0);
      tableLayoutPanel4.Location = new Point(0, 68);
      tableLayoutPanel4.Margin = new Padding(0);
      tableLayoutPanel4.Name = "tableLayoutPanel4";
      tableLayoutPanel4.RowCount = 1;
      tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel4.Size = new Size(1088, 65);
      tableLayoutPanel4.TabIndex = 14;
      // 
      // label4
      // 
      label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label4.AutoSize = true;
      label4.Font = new Font("Roboto Light", 20.25F);
      label4.ForeColor = Color.Black;
      label4.Location = new Point(0, 0);
      label4.Margin = new Padding(0);
      label4.Name = "label4";
      label4.Size = new Size(250, 65);
      label4.TabIndex = 12;
      label4.Text = "Tên máy in:";
      label4.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // btnSaveIpPrintA4
      // 
      btnSaveIpPrintA4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      btnSaveIpPrintA4.BackColor = Color.FromArgb(49, 68, 108);
      btnSaveIpPrintA4.BackgroundColor = Color.FromArgb(49, 68, 108);
      btnSaveIpPrintA4.BorderColor = Color.PaleVioletRed;
      btnSaveIpPrintA4.BorderRadius = 5;
      btnSaveIpPrintA4.BorderSize = 0;
      btnSaveIpPrintA4.FlatAppearance.BorderSize = 0;
      btnSaveIpPrintA4.FlatStyle = FlatStyle.Flat;
      btnSaveIpPrintA4.Font = new Font("Roboto", 20.25F, FontStyle.Bold);
      btnSaveIpPrintA4.ForeColor = Color.White;
      btnSaveIpPrintA4.Location = new Point(901, 5);
      btnSaveIpPrintA4.Name = "btnSaveIpPrintA4";
      btnSaveIpPrintA4.Size = new Size(174, 55);
      btnSaveIpPrintA4.TabIndex = 27;
      btnSaveIpPrintA4.Text = "Lưu";
      btnSaveIpPrintA4.TextColor = Color.White;
      btnSaveIpPrintA4.UseVisualStyleBackColor = false;
      // 
      // cbbPrinterA4
      // 
      cbbPrinterA4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      cbbPrinterA4.DropDownStyle = ComboBoxStyle.DropDownList;
      cbbPrinterA4.Font = new Font("Roboto Light", 20F);
      cbbPrinterA4.FormattingEnabled = true;
      cbbPrinterA4.Location = new Point(253, 12);
      cbbPrinterA4.Name = "cbbPrinterA4";
      cbbPrinterA4.Size = new Size(622, 41);
      cbbPrinterA4.TabIndex = 28;
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel2.BackColor = Color.Gainsboro;
      tableLayoutPanel2.ColumnCount = 1;
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.Controls.Add(tableLayoutPanel6, 0, 1);
      tableLayoutPanel2.Controls.Add(label2, 0, 0);
      tableLayoutPanel2.Location = new Point(21, 23);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 2;
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.Size = new Size(1088, 194);
      tableLayoutPanel2.TabIndex = 13;
      // 
      // tableLayoutPanel6
      // 
      tableLayoutPanel6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel6.ColumnCount = 1;
      tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.8085861F));
      tableLayoutPanel6.Controls.Add(tableLayoutPanel8, 0, 1);
      tableLayoutPanel6.Controls.Add(tableLayoutPanel7, 0, 0);
      tableLayoutPanel6.Location = new Point(3, 63);
      tableLayoutPanel6.Name = "tableLayoutPanel6";
      tableLayoutPanel6.RowCount = 2;
      tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
      tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
      tableLayoutPanel6.Size = new Size(1082, 128);
      tableLayoutPanel6.TabIndex = 13;
      // 
      // tableLayoutPanel8
      // 
      tableLayoutPanel8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel8.ColumnCount = 6;
      tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
      tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
      tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
      tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
      tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
      tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
      tableLayoutPanel8.Controls.Add(label5, 0, 0);
      tableLayoutPanel8.Controls.Add(numberLabelWeight, 1, 0);
      tableLayoutPanel8.Controls.Add(btnDownNumberLabelWeight, 3, 0);
      tableLayoutPanel8.Controls.Add(btnUpNumberLabelWeight, 4, 0);
      tableLayoutPanel8.Location = new Point(0, 64);
      tableLayoutPanel8.Margin = new Padding(0);
      tableLayoutPanel8.Name = "tableLayoutPanel8";
      tableLayoutPanel8.RowCount = 1;
      tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel8.Size = new Size(1082, 64);
      tableLayoutPanel8.TabIndex = 14;
      // 
      // label5
      // 
      label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label5.AutoSize = true;
      label5.Font = new Font("Roboto Light", 20.25F);
      label5.ForeColor = Color.Black;
      label5.Location = new Point(0, 0);
      label5.Margin = new Padding(0);
      label5.Name = "label5";
      label5.Size = new Size(250, 64);
      label5.TabIndex = 14;
      label5.Text = "Số lượng phiếu:";
      label5.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // numberLabelWeight
      // 
      numberLabelWeight.Anchor = AnchorStyles.Left;
      numberLabelWeight.Enabled = false;
      numberLabelWeight.Font = new Font("Roboto Light", 20.25F);
      numberLabelWeight.Location = new Point(253, 12);
      numberLabelWeight.Name = "numberLabelWeight";
      numberLabelWeight.Size = new Size(244, 40);
      numberLabelWeight.TabIndex = 15;
      numberLabelWeight.TextAlign = HorizontalAlignment.Right;
      // 
      // btnDownNumberLabelWeight
      // 
      btnDownNumberLabelWeight.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      btnDownNumberLabelWeight.BackColor = Color.FromArgb(49, 68, 108);
      btnDownNumberLabelWeight.BackgroundColor = Color.FromArgb(49, 68, 108);
      btnDownNumberLabelWeight.BorderColor = Color.PaleVioletRed;
      btnDownNumberLabelWeight.BorderRadius = 5;
      btnDownNumberLabelWeight.BorderSize = 0;
      btnDownNumberLabelWeight.FlatAppearance.BorderSize = 0;
      btnDownNumberLabelWeight.FlatStyle = FlatStyle.Flat;
      btnDownNumberLabelWeight.Font = new Font("Roboto", 20.25F, FontStyle.Bold);
      btnDownNumberLabelWeight.ForeColor = Color.White;
      btnDownNumberLabelWeight.Location = new Point(523, 7);
      btnDownNumberLabelWeight.Name = "btnDownNumberLabelWeight";
      btnDownNumberLabelWeight.Size = new Size(144, 50);
      btnDownNumberLabelWeight.TabIndex = 25;
      btnDownNumberLabelWeight.Text = "Giảm";
      btnDownNumberLabelWeight.TextColor = Color.White;
      btnDownNumberLabelWeight.UseVisualStyleBackColor = false;
      // 
      // btnUpNumberLabelWeight
      // 
      btnUpNumberLabelWeight.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      btnUpNumberLabelWeight.BackColor = Color.FromArgb(49, 68, 108);
      btnUpNumberLabelWeight.BackgroundColor = Color.FromArgb(49, 68, 108);
      btnUpNumberLabelWeight.BorderColor = Color.PaleVioletRed;
      btnUpNumberLabelWeight.BorderRadius = 5;
      btnUpNumberLabelWeight.BorderSize = 0;
      btnUpNumberLabelWeight.FlatAppearance.BorderSize = 0;
      btnUpNumberLabelWeight.FlatStyle = FlatStyle.Flat;
      btnUpNumberLabelWeight.Font = new Font("Roboto", 20.25F, FontStyle.Bold);
      btnUpNumberLabelWeight.ForeColor = Color.White;
      btnUpNumberLabelWeight.Location = new Point(673, 7);
      btnUpNumberLabelWeight.Name = "btnUpNumberLabelWeight";
      btnUpNumberLabelWeight.Size = new Size(144, 50);
      btnUpNumberLabelWeight.TabIndex = 24;
      btnUpNumberLabelWeight.Text = "Tăng";
      btnUpNumberLabelWeight.TextColor = Color.White;
      btnUpNumberLabelWeight.UseVisualStyleBackColor = false;
      // 
      // tableLayoutPanel7
      // 
      tableLayoutPanel7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel7.ColumnCount = 5;
      tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
      tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
      tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
      tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
      tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel7.Controls.Add(label6, 0, 0);
      tableLayoutPanel7.Controls.Add(txtIpPrintWeight, 1, 0);
      tableLayoutPanel7.Controls.Add(btnSaveIpPrintWeight, 3, 0);
      tableLayoutPanel7.Location = new Point(0, 0);
      tableLayoutPanel7.Margin = new Padding(0);
      tableLayoutPanel7.Name = "tableLayoutPanel7";
      tableLayoutPanel7.RowCount = 1;
      tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel7.Size = new Size(1082, 64);
      tableLayoutPanel7.TabIndex = 13;
      // 
      // label6
      // 
      label6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label6.AutoSize = true;
      label6.Font = new Font("Roboto Light", 20.25F);
      label6.ForeColor = Color.Black;
      label6.Location = new Point(0, 0);
      label6.Margin = new Padding(0);
      label6.Name = "label6";
      label6.Size = new Size(250, 64);
      label6.TabIndex = 12;
      label6.Text = "IP máy in nhãn:";
      label6.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // txtIpPrintWeight
      // 
      txtIpPrintWeight.Anchor = AnchorStyles.Left;
      txtIpPrintWeight.BackColor = SystemColors.Window;
      txtIpPrintWeight.BorderColor = Color.Black;
      txtIpPrintWeight.BorderFocusColor = Color.Black;
      txtIpPrintWeight.BorderRadius = 5;
      txtIpPrintWeight.BorderSize = 2;
      txtIpPrintWeight.Font = new Font("Roboto Light", 20.25F);
      txtIpPrintWeight.ForeColor = Color.FromArgb(64, 64, 64);
      txtIpPrintWeight.Location = new Point(254, 8);
      txtIpPrintWeight.Margin = new Padding(4);
      txtIpPrintWeight.Multiline = false;
      txtIpPrintWeight.Name = "txtIpPrintWeight";
      txtIpPrintWeight.Padding = new Padding(10, 7, 10, 7);
      txtIpPrintWeight.PasswordChar = false;
      txtIpPrintWeight.PlaceholderColor = Color.DarkGray;
      txtIpPrintWeight.PlaceholderText = "";
      txtIpPrintWeight.Size = new Size(242, 48);
      txtIpPrintWeight.TabIndex = 13;
      txtIpPrintWeight.Texts = "192.168.001.030";
      txtIpPrintWeight.UnderlinedStyle = false;
      // 
      // btnSaveIpPrintWeight
      // 
      btnSaveIpPrintWeight.Anchor = AnchorStyles.Right;
      btnSaveIpPrintWeight.BackColor = Color.FromArgb(49, 68, 108);
      btnSaveIpPrintWeight.BackgroundColor = Color.FromArgb(49, 68, 108);
      btnSaveIpPrintWeight.BorderColor = Color.PaleVioletRed;
      btnSaveIpPrintWeight.BorderRadius = 5;
      btnSaveIpPrintWeight.BorderSize = 0;
      btnSaveIpPrintWeight.FlatAppearance.BorderSize = 0;
      btnSaveIpPrintWeight.FlatStyle = FlatStyle.Flat;
      btnSaveIpPrintWeight.Font = new Font("Roboto", 20.25F, FontStyle.Bold);
      btnSaveIpPrintWeight.ForeColor = Color.White;
      btnSaveIpPrintWeight.Location = new Point(523, 7);
      btnSaveIpPrintWeight.Name = "btnSaveIpPrintWeight";
      btnSaveIpPrintWeight.Size = new Size(144, 50);
      btnSaveIpPrintWeight.TabIndex = 26;
      btnSaveIpPrintWeight.Text = "Lưu";
      btnSaveIpPrintWeight.TextColor = Color.White;
      btnSaveIpPrintWeight.UseVisualStyleBackColor = false;
      // 
      // label2
      // 
      label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label2.AutoSize = true;
      label2.BackColor = Color.Silver;
      label2.Font = new Font("Roboto", 20.25F, FontStyle.Bold);
      label2.ForeColor = Color.Black;
      label2.Location = new Point(0, 0);
      label2.Margin = new Padding(0);
      label2.Name = "label2";
      label2.Size = new Size(1088, 60);
      label2.TabIndex = 11;
      label2.Text = "Cài đặt máy in phiếu cân";
      label2.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // FrmSettingPrinter
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(1130, 800);
      Controls.Add(tableLayoutPanel1);
      Name = "FrmSettingPrinter";
      Text = "FrmSettingPrinterDelivery";
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel3.ResumeLayout(false);
      tableLayoutPanel3.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
      tableLayoutPanel5.ResumeLayout(false);
      tableLayoutPanel5.PerformLayout();
      tableLayoutPanel4.ResumeLayout(false);
      tableLayoutPanel4.PerformLayout();
      tableLayoutPanel2.ResumeLayout(false);
      tableLayoutPanel2.PerformLayout();
      tableLayoutPanel6.ResumeLayout(false);
      tableLayoutPanel8.ResumeLayout(false);
      tableLayoutPanel8.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)numberLabelWeight).EndInit();
      tableLayoutPanel7.ResumeLayout(false);
      tableLayoutPanel7.PerformLayout();
      ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private TableLayoutPanel tableLayoutPanel3;
    private DataGridView dgv;
    private TableLayoutPanel tableLayoutPanel5;
    private Custom.RJButton btnAddNew;
    private Label label1;
    private TableLayoutPanel tableLayoutPanel2;
    private Label label2;
    private TableLayoutPanel tableLayoutPanel6;
    private TableLayoutPanel tableLayoutPanel7;
    private Label label6;
    private CustomControls.RJControls.RJTextBox txtIpPrintWeight;
    private TableLayoutPanel tableLayoutPanel8;
    private Label label5;
    private NumericUpDown numberLabelWeight;
    private Custom.RJButton btnUpNumberLabelWeight;
    private Custom.RJButton btnDownNumberLabelWeight;
    private Label label3;
    private TableLayoutPanel tableLayoutPanel4;
    private Label label4;
    private Custom.RJButton btnSaveIpPrintWeight;
    private Custom.RJButton btnSaveIpPrintA4;
    private ComboBox cbbPrinterA4;
  }
}