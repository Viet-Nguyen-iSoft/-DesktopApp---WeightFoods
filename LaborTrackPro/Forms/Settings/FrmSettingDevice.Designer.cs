namespace LaborTrackPro.Forms.Settings
{
  partial class FrmSettingDevice
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
      tableLayoutPanel9 = new TableLayoutPanel();
      tableLayoutPanel3 = new TableLayoutPanel();
      tableLayoutPanel4 = new TableLayoutPanel();
      portHID = new NumericUpDown();
      txtIpHID = new CustomControls.RJControls.RJTextBox();
      label1 = new Label();
      label4 = new Label();
      timeoutHID = new NumericUpDown();
      checkConnectHID = new NumericUpDown();
      label12 = new Label();
      label11 = new Label();
      label3 = new Label();
      tableLayoutPanel5 = new TableLayoutPanel();
      btnBackHid = new LaborTrackPro.Custom.RJButton();
      btnSaveHid = new LaborTrackPro.Custom.RJButton();
      tableLayoutPanel2 = new TableLayoutPanel();
      tableLayoutPanel6 = new TableLayoutPanel();
      tableLayoutPanel11 = new TableLayoutPanel();
      btnBackWeight = new LaborTrackPro.Custom.RJButton();
      btnSaveWeight = new LaborTrackPro.Custom.RJButton();
      tableLayoutPanel12 = new TableLayoutPanel();
      portWeight = new NumericUpDown();
      txtIpWeight = new CustomControls.RJControls.RJTextBox();
      label7 = new Label();
      label6 = new Label();
      label5 = new Label();
      timeoutWeight = new NumericUpDown();
      checkConnectWeight = new NumericUpDown();
      sampleTimeWeight = new NumericUpDown();
      label10 = new Label();
      label9 = new Label();
      label2 = new Label();
      tableLayoutPanel1 = new TableLayoutPanel();
      label8 = new Label();
      label13 = new Label();
      txtNameWeight = new CustomControls.RJControls.RJTextBox();
      txtNameHID = new CustomControls.RJControls.RJTextBox();
      tableLayoutPanel9.SuspendLayout();
      tableLayoutPanel3.SuspendLayout();
      tableLayoutPanel4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)portHID).BeginInit();
      ((System.ComponentModel.ISupportInitialize)timeoutHID).BeginInit();
      ((System.ComponentModel.ISupportInitialize)checkConnectHID).BeginInit();
      tableLayoutPanel5.SuspendLayout();
      tableLayoutPanel2.SuspendLayout();
      tableLayoutPanel6.SuspendLayout();
      tableLayoutPanel11.SuspendLayout();
      tableLayoutPanel12.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)portWeight).BeginInit();
      ((System.ComponentModel.ISupportInitialize)timeoutWeight).BeginInit();
      ((System.ComponentModel.ISupportInitialize)checkConnectWeight).BeginInit();
      ((System.ComponentModel.ISupportInitialize)sampleTimeWeight).BeginInit();
      tableLayoutPanel1.SuspendLayout();
      SuspendLayout();
      // 
      // tableLayoutPanel9
      // 
      tableLayoutPanel9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel9.ColumnCount = 4;
      tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 580F));
      tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
      tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 580F));
      tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel9.Controls.Add(tableLayoutPanel3, 2, 0);
      tableLayoutPanel9.Controls.Add(tableLayoutPanel2, 0, 0);
      tableLayoutPanel9.Location = new Point(18, 20);
      tableLayoutPanel9.Margin = new Padding(0);
      tableLayoutPanel9.Name = "tableLayoutPanel9";
      tableLayoutPanel9.RowCount = 1;
      tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel9.Size = new Size(1598, 480);
      tableLayoutPanel9.TabIndex = 14;
      // 
      // tableLayoutPanel3
      // 
      tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel3.BackColor = Color.Gainsboro;
      tableLayoutPanel3.ColumnCount = 1;
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel3.Controls.Add(tableLayoutPanel4, 0, 1);
      tableLayoutPanel3.Controls.Add(label3, 0, 0);
      tableLayoutPanel3.Controls.Add(tableLayoutPanel5, 0, 3);
      tableLayoutPanel3.Location = new Point(603, 3);
      tableLayoutPanel3.Name = "tableLayoutPanel3";
      tableLayoutPanel3.RowCount = 4;
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
      tableLayoutPanel3.Size = new Size(574, 474);
      tableLayoutPanel3.TabIndex = 9;
      // 
      // tableLayoutPanel4
      // 
      tableLayoutPanel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel4.ColumnCount = 3;
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle());
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
      tableLayoutPanel4.Controls.Add(txtNameHID, 1, 0);
      tableLayoutPanel4.Controls.Add(label13, 0, 0);
      tableLayoutPanel4.Controls.Add(portHID, 1, 2);
      tableLayoutPanel4.Controls.Add(txtIpHID, 1, 1);
      tableLayoutPanel4.Controls.Add(label1, 0, 1);
      tableLayoutPanel4.Controls.Add(label4, 0, 2);
      tableLayoutPanel4.Controls.Add(timeoutHID, 1, 3);
      tableLayoutPanel4.Controls.Add(checkConnectHID, 1, 4);
      tableLayoutPanel4.Controls.Add(label12, 0, 3);
      tableLayoutPanel4.Controls.Add(label11, 0, 4);
      tableLayoutPanel4.Location = new Point(0, 60);
      tableLayoutPanel4.Margin = new Padding(0);
      tableLayoutPanel4.Name = "tableLayoutPanel4";
      tableLayoutPanel4.RowCount = 6;
      tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
      tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
      tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
      tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
      tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
      tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
      tableLayoutPanel4.Size = new Size(574, 324);
      tableLayoutPanel4.TabIndex = 18;
      // 
      // portHID
      // 
      portHID.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      portHID.Font = new Font("Microsoft Sans Serif", 24F);
      portHID.Location = new Point(273, 113);
      portHID.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
      portHID.Name = "portHID";
      portHID.Size = new Size(278, 44);
      portHID.TabIndex = 15;
      portHID.TextAlign = HorizontalAlignment.Right;
      // 
      // txtIpHID
      // 
      txtIpHID.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      txtIpHID.BackColor = SystemColors.Window;
      txtIpHID.BorderColor = Color.Black;
      txtIpHID.BorderFocusColor = Color.Black;
      txtIpHID.BorderRadius = 5;
      txtIpHID.BorderSize = 2;
      txtIpHID.Font = new Font("Microsoft Sans Serif", 20.25F);
      txtIpHID.ForeColor = Color.FromArgb(64, 64, 64);
      txtIpHID.Location = new Point(274, 58);
      txtIpHID.Margin = new Padding(4);
      txtIpHID.Multiline = false;
      txtIpHID.Name = "txtIpHID";
      txtIpHID.Padding = new Padding(10, 7, 10, 7);
      txtIpHID.PasswordChar = false;
      txtIpHID.PlaceholderColor = Color.DarkGray;
      txtIpHID.PlaceholderText = "";
      txtIpHID.Size = new Size(276, 46);
      txtIpHID.TabIndex = 13;
      txtIpHID.Texts = "192.168.001.030";
      txtIpHID.UnderlinedStyle = false;
      // 
      // label1
      // 
      label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label1.AutoSize = true;
      label1.Font = new Font("Microsoft Sans Serif", 20.25F);
      label1.ForeColor = Color.Black;
      label1.Location = new Point(0, 54);
      label1.Margin = new Padding(0);
      label1.Name = "label1";
      label1.Size = new Size(270, 54);
      label1.TabIndex = 12;
      label1.Text = "IP:";
      label1.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // label4
      // 
      label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label4.AutoSize = true;
      label4.Font = new Font("Microsoft Sans Serif", 20.25F);
      label4.ForeColor = Color.Black;
      label4.Location = new Point(0, 108);
      label4.Margin = new Padding(0);
      label4.Name = "label4";
      label4.Size = new Size(270, 54);
      label4.TabIndex = 14;
      label4.Text = "Port:";
      label4.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // timeoutHID
      // 
      timeoutHID.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      timeoutHID.Font = new Font("Microsoft Sans Serif", 24F);
      timeoutHID.Location = new Point(273, 167);
      timeoutHID.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
      timeoutHID.Name = "timeoutHID";
      timeoutHID.Size = new Size(278, 44);
      timeoutHID.TabIndex = 17;
      timeoutHID.TextAlign = HorizontalAlignment.Right;
      // 
      // checkConnectHID
      // 
      checkConnectHID.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      checkConnectHID.Font = new Font("Microsoft Sans Serif", 24F);
      checkConnectHID.Location = new Point(273, 221);
      checkConnectHID.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
      checkConnectHID.Name = "checkConnectHID";
      checkConnectHID.Size = new Size(278, 44);
      checkConnectHID.TabIndex = 18;
      checkConnectHID.TextAlign = HorizontalAlignment.Right;
      // 
      // label12
      // 
      label12.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label12.AutoSize = true;
      label12.Font = new Font("Microsoft Sans Serif", 20.25F);
      label12.ForeColor = Color.Black;
      label12.Location = new Point(0, 162);
      label12.Margin = new Padding(0);
      label12.Name = "label12";
      label12.Size = new Size(270, 54);
      label12.TabIndex = 16;
      label12.Text = "Timeout (ms):";
      label12.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // label11
      // 
      label11.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label11.AutoSize = true;
      label11.Font = new Font("Microsoft Sans Serif", 20.25F);
      label11.ForeColor = Color.Black;
      label11.Location = new Point(0, 216);
      label11.Margin = new Padding(0);
      label11.Name = "label11";
      label11.Size = new Size(270, 54);
      label11.TabIndex = 15;
      label11.Text = "Kiểm tra kết nối (ms):";
      label11.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // label3
      // 
      label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label3.AutoSize = true;
      label3.BackColor = Color.Silver;
      label3.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold);
      label3.ForeColor = Color.Black;
      label3.Location = new Point(0, 0);
      label3.Margin = new Padding(0);
      label3.Name = "label3";
      label3.Size = new Size(574, 60);
      label3.TabIndex = 13;
      label3.Text = "Cài đặt kết nối đầu đọc thẻ HID";
      label3.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // tableLayoutPanel5
      // 
      tableLayoutPanel5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel5.ColumnCount = 4;
      tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle());
      tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle());
      tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 3F));
      tableLayoutPanel5.Controls.Add(btnBackHid, 1, 0);
      tableLayoutPanel5.Controls.Add(btnSaveHid, 2, 0);
      tableLayoutPanel5.Location = new Point(0, 404);
      tableLayoutPanel5.Margin = new Padding(0);
      tableLayoutPanel5.Name = "tableLayoutPanel5";
      tableLayoutPanel5.RowCount = 1;
      tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel5.Size = new Size(574, 70);
      tableLayoutPanel5.TabIndex = 19;
      // 
      // btnBackHid
      // 
      btnBackHid.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      btnBackHid.BackColor = Color.FromArgb(49, 68, 108);
      btnBackHid.BackgroundColor = Color.FromArgb(49, 68, 108);
      btnBackHid.BorderColor = Color.PaleVioletRed;
      btnBackHid.BorderRadius = 5;
      btnBackHid.BorderSize = 0;
      btnBackHid.FlatAppearance.BorderSize = 0;
      btnBackHid.FlatStyle = FlatStyle.Flat;
      btnBackHid.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold);
      btnBackHid.ForeColor = Color.White;
      btnBackHid.Location = new Point(175, 7);
      btnBackHid.Name = "btnBackHid";
      btnBackHid.Size = new Size(174, 55);
      btnBackHid.TabIndex = 25;
      btnBackHid.Text = "Quay lại";
      btnBackHid.TextColor = Color.White;
      btnBackHid.UseVisualStyleBackColor = false;
      btnBackHid.Click += btnBackHid_Click;
      // 
      // btnSaveHid
      // 
      btnSaveHid.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      btnSaveHid.BackColor = Color.FromArgb(49, 68, 108);
      btnSaveHid.BackgroundColor = Color.FromArgb(49, 68, 108);
      btnSaveHid.BorderColor = Color.PaleVioletRed;
      btnSaveHid.BorderRadius = 5;
      btnSaveHid.BorderSize = 0;
      btnSaveHid.FlatAppearance.BorderSize = 0;
      btnSaveHid.FlatStyle = FlatStyle.Flat;
      btnSaveHid.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold);
      btnSaveHid.ForeColor = Color.White;
      btnSaveHid.Location = new Point(355, 7);
      btnSaveHid.Name = "btnSaveHid";
      btnSaveHid.Size = new Size(213, 55);
      btnSaveHid.TabIndex = 24;
      btnSaveHid.Text = "Lưu thay đổi";
      btnSaveHid.TextColor = Color.White;
      btnSaveHid.UseVisualStyleBackColor = false;
      btnSaveHid.Click += btnSaveHid_Click;
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel2.BackColor = Color.Gainsboro;
      tableLayoutPanel2.ColumnCount = 1;
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.Controls.Add(tableLayoutPanel6, 0, 1);
      tableLayoutPanel2.Controls.Add(label2, 0, 0);
      tableLayoutPanel2.Location = new Point(3, 3);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 2;
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.Size = new Size(574, 474);
      tableLayoutPanel2.TabIndex = 13;
      // 
      // tableLayoutPanel6
      // 
      tableLayoutPanel6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel6.ColumnCount = 1;
      tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel6.Controls.Add(tableLayoutPanel11, 0, 2);
      tableLayoutPanel6.Controls.Add(tableLayoutPanel12, 0, 0);
      tableLayoutPanel6.Location = new Point(0, 60);
      tableLayoutPanel6.Margin = new Padding(0);
      tableLayoutPanel6.Name = "tableLayoutPanel6";
      tableLayoutPanel6.RowCount = 3;
      tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
      tableLayoutPanel6.Size = new Size(574, 414);
      tableLayoutPanel6.TabIndex = 13;
      // 
      // tableLayoutPanel11
      // 
      tableLayoutPanel11.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel11.ColumnCount = 4;
      tableLayoutPanel11.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel11.ColumnStyles.Add(new ColumnStyle());
      tableLayoutPanel11.ColumnStyles.Add(new ColumnStyle());
      tableLayoutPanel11.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 3F));
      tableLayoutPanel11.Controls.Add(btnBackWeight, 1, 0);
      tableLayoutPanel11.Controls.Add(btnSaveWeight, 2, 0);
      tableLayoutPanel11.Location = new Point(0, 344);
      tableLayoutPanel11.Margin = new Padding(0);
      tableLayoutPanel11.Name = "tableLayoutPanel11";
      tableLayoutPanel11.RowCount = 1;
      tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel11.Size = new Size(574, 70);
      tableLayoutPanel11.TabIndex = 16;
      // 
      // btnBackWeight
      // 
      btnBackWeight.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      btnBackWeight.BackColor = Color.FromArgb(49, 68, 108);
      btnBackWeight.BackgroundColor = Color.FromArgb(49, 68, 108);
      btnBackWeight.BorderColor = Color.PaleVioletRed;
      btnBackWeight.BorderRadius = 5;
      btnBackWeight.BorderSize = 0;
      btnBackWeight.FlatAppearance.BorderSize = 0;
      btnBackWeight.FlatStyle = FlatStyle.Flat;
      btnBackWeight.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold);
      btnBackWeight.ForeColor = Color.White;
      btnBackWeight.Location = new Point(175, 7);
      btnBackWeight.Name = "btnBackWeight";
      btnBackWeight.Size = new Size(174, 55);
      btnBackWeight.TabIndex = 25;
      btnBackWeight.Text = "Quay lại";
      btnBackWeight.TextColor = Color.White;
      btnBackWeight.UseVisualStyleBackColor = false;
      btnBackWeight.Click += btnBackWeight_Click;
      // 
      // btnSaveWeight
      // 
      btnSaveWeight.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      btnSaveWeight.BackColor = Color.FromArgb(49, 68, 108);
      btnSaveWeight.BackgroundColor = Color.FromArgb(49, 68, 108);
      btnSaveWeight.BorderColor = Color.PaleVioletRed;
      btnSaveWeight.BorderRadius = 5;
      btnSaveWeight.BorderSize = 0;
      btnSaveWeight.FlatAppearance.BorderSize = 0;
      btnSaveWeight.FlatStyle = FlatStyle.Flat;
      btnSaveWeight.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold);
      btnSaveWeight.ForeColor = Color.White;
      btnSaveWeight.Location = new Point(355, 7);
      btnSaveWeight.Name = "btnSaveWeight";
      btnSaveWeight.Size = new Size(213, 55);
      btnSaveWeight.TabIndex = 24;
      btnSaveWeight.Text = "Lưu thay đổi";
      btnSaveWeight.TextColor = Color.White;
      btnSaveWeight.UseVisualStyleBackColor = false;
      btnSaveWeight.Click += btnSaveWeight_Click;
      // 
      // tableLayoutPanel12
      // 
      tableLayoutPanel12.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel12.ColumnCount = 3;
      tableLayoutPanel12.ColumnStyles.Add(new ColumnStyle());
      tableLayoutPanel12.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel12.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
      tableLayoutPanel12.Controls.Add(txtNameWeight, 1, 0);
      tableLayoutPanel12.Controls.Add(label8, 0, 0);
      tableLayoutPanel12.Controls.Add(portWeight, 1, 2);
      tableLayoutPanel12.Controls.Add(txtIpWeight, 1, 1);
      tableLayoutPanel12.Controls.Add(label7, 0, 5);
      tableLayoutPanel12.Controls.Add(label6, 0, 1);
      tableLayoutPanel12.Controls.Add(label5, 0, 2);
      tableLayoutPanel12.Controls.Add(timeoutWeight, 1, 3);
      tableLayoutPanel12.Controls.Add(checkConnectWeight, 1, 4);
      tableLayoutPanel12.Controls.Add(sampleTimeWeight, 1, 5);
      tableLayoutPanel12.Controls.Add(label10, 0, 3);
      tableLayoutPanel12.Controls.Add(label9, 0, 4);
      tableLayoutPanel12.Location = new Point(0, 0);
      tableLayoutPanel12.Margin = new Padding(0);
      tableLayoutPanel12.Name = "tableLayoutPanel12";
      tableLayoutPanel12.RowCount = 6;
      tableLayoutPanel12.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
      tableLayoutPanel12.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
      tableLayoutPanel12.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
      tableLayoutPanel12.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
      tableLayoutPanel12.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
      tableLayoutPanel12.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
      tableLayoutPanel12.Size = new Size(574, 324);
      tableLayoutPanel12.TabIndex = 17;
      // 
      // portWeight
      // 
      portWeight.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      portWeight.Font = new Font("Microsoft Sans Serif", 24F);
      portWeight.Location = new Point(298, 113);
      portWeight.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
      portWeight.Name = "portWeight";
      portWeight.Size = new Size(253, 44);
      portWeight.TabIndex = 15;
      portWeight.TextAlign = HorizontalAlignment.Right;
      // 
      // txtIpWeight
      // 
      txtIpWeight.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      txtIpWeight.BackColor = SystemColors.Window;
      txtIpWeight.BorderColor = Color.Black;
      txtIpWeight.BorderFocusColor = Color.Black;
      txtIpWeight.BorderRadius = 5;
      txtIpWeight.BorderSize = 2;
      txtIpWeight.Font = new Font("Microsoft Sans Serif", 20.25F);
      txtIpWeight.ForeColor = Color.FromArgb(64, 64, 64);
      txtIpWeight.Location = new Point(299, 58);
      txtIpWeight.Margin = new Padding(4);
      txtIpWeight.Multiline = false;
      txtIpWeight.Name = "txtIpWeight";
      txtIpWeight.Padding = new Padding(10, 7, 10, 7);
      txtIpWeight.PasswordChar = false;
      txtIpWeight.PlaceholderColor = Color.DarkGray;
      txtIpWeight.PlaceholderText = "";
      txtIpWeight.Size = new Size(251, 46);
      txtIpWeight.TabIndex = 13;
      txtIpWeight.Texts = "192.168.001.030";
      txtIpWeight.UnderlinedStyle = false;
      // 
      // label7
      // 
      label7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label7.AutoSize = true;
      label7.Font = new Font("Microsoft Sans Serif", 20.25F);
      label7.ForeColor = Color.Black;
      label7.Location = new Point(0, 270);
      label7.Margin = new Padding(0);
      label7.Name = "label7";
      label7.Size = new Size(295, 54);
      label7.TabIndex = 14;
      label7.Text = "Thời gian lấy mẫu (ms):";
      label7.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // label6
      // 
      label6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label6.AutoSize = true;
      label6.Font = new Font("Microsoft Sans Serif", 20.25F);
      label6.ForeColor = Color.Black;
      label6.Location = new Point(0, 54);
      label6.Margin = new Padding(0);
      label6.Name = "label6";
      label6.Size = new Size(295, 54);
      label6.TabIndex = 12;
      label6.Text = "IP:";
      label6.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // label5
      // 
      label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label5.AutoSize = true;
      label5.Font = new Font("Microsoft Sans Serif", 20.25F);
      label5.ForeColor = Color.Black;
      label5.Location = new Point(0, 108);
      label5.Margin = new Padding(0);
      label5.Name = "label5";
      label5.Size = new Size(295, 54);
      label5.TabIndex = 14;
      label5.Text = "Port:";
      label5.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // timeoutWeight
      // 
      timeoutWeight.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      timeoutWeight.Font = new Font("Microsoft Sans Serif", 24F);
      timeoutWeight.Location = new Point(298, 167);
      timeoutWeight.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
      timeoutWeight.Name = "timeoutWeight";
      timeoutWeight.Size = new Size(253, 44);
      timeoutWeight.TabIndex = 17;
      timeoutWeight.TextAlign = HorizontalAlignment.Right;
      // 
      // checkConnectWeight
      // 
      checkConnectWeight.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      checkConnectWeight.Font = new Font("Microsoft Sans Serif", 24F);
      checkConnectWeight.Location = new Point(298, 221);
      checkConnectWeight.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
      checkConnectWeight.Name = "checkConnectWeight";
      checkConnectWeight.Size = new Size(253, 44);
      checkConnectWeight.TabIndex = 18;
      checkConnectWeight.TextAlign = HorizontalAlignment.Right;
      // 
      // sampleTimeWeight
      // 
      sampleTimeWeight.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      sampleTimeWeight.Font = new Font("Microsoft Sans Serif", 24F);
      sampleTimeWeight.Location = new Point(298, 275);
      sampleTimeWeight.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
      sampleTimeWeight.Name = "sampleTimeWeight";
      sampleTimeWeight.Size = new Size(253, 44);
      sampleTimeWeight.TabIndex = 19;
      sampleTimeWeight.TextAlign = HorizontalAlignment.Right;
      // 
      // label10
      // 
      label10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label10.AutoSize = true;
      label10.Font = new Font("Microsoft Sans Serif", 20.25F);
      label10.ForeColor = Color.Black;
      label10.Location = new Point(0, 162);
      label10.Margin = new Padding(0);
      label10.Name = "label10";
      label10.Size = new Size(295, 54);
      label10.TabIndex = 16;
      label10.Text = "Timeout (ms):";
      label10.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // label9
      // 
      label9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label9.AutoSize = true;
      label9.Font = new Font("Microsoft Sans Serif", 20.25F);
      label9.ForeColor = Color.Black;
      label9.Location = new Point(0, 216);
      label9.Margin = new Padding(0);
      label9.Name = "label9";
      label9.Size = new Size(295, 54);
      label9.TabIndex = 15;
      label9.Text = "Kiểm tra kết nối (ms):";
      label9.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // label2
      // 
      label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label2.AutoSize = true;
      label2.BackColor = Color.Silver;
      label2.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold);
      label2.ForeColor = Color.Black;
      label2.Location = new Point(0, 0);
      label2.Margin = new Padding(0);
      label2.Name = "label2";
      label2.Size = new Size(574, 60);
      label2.TabIndex = 11;
      label2.Text = "Cài đặt kết nối cân";
      label2.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.BackColor = Color.White;
      tableLayoutPanel1.ColumnCount = 3;
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 18F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 18F));
      tableLayoutPanel1.Controls.Add(tableLayoutPanel9, 1, 1);
      tableLayoutPanel1.Dock = DockStyle.Fill;
      tableLayoutPanel1.Location = new Point(0, 0);
      tableLayoutPanel1.Margin = new Padding(0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 5;
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 480F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 18F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel1.Size = new Size(1634, 826);
      tableLayoutPanel1.TabIndex = 3;
      // 
      // label8
      // 
      label8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label8.AutoSize = true;
      label8.Font = new Font("Microsoft Sans Serif", 20.25F);
      label8.ForeColor = Color.Black;
      label8.Location = new Point(0, 0);
      label8.Margin = new Padding(0);
      label8.Name = "label8";
      label8.Size = new Size(295, 54);
      label8.TabIndex = 20;
      label8.Text = "Tên thiết bị:";
      label8.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // label13
      // 
      label13.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label13.AutoSize = true;
      label13.Font = new Font("Microsoft Sans Serif", 20.25F);
      label13.ForeColor = Color.Black;
      label13.Location = new Point(0, 0);
      label13.Margin = new Padding(0);
      label13.Name = "label13";
      label13.Size = new Size(270, 54);
      label13.TabIndex = 21;
      label13.Text = "Tên thiết bị:";
      label13.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // txtNameWeight
      // 
      txtNameWeight.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      txtNameWeight.BackColor = SystemColors.Window;
      txtNameWeight.BorderColor = Color.Black;
      txtNameWeight.BorderFocusColor = Color.Black;
      txtNameWeight.BorderRadius = 5;
      txtNameWeight.BorderSize = 2;
      txtNameWeight.Font = new Font("Microsoft Sans Serif", 20.25F);
      txtNameWeight.ForeColor = Color.FromArgb(64, 64, 64);
      txtNameWeight.Location = new Point(299, 4);
      txtNameWeight.Margin = new Padding(4);
      txtNameWeight.Multiline = false;
      txtNameWeight.Name = "txtNameWeight";
      txtNameWeight.Padding = new Padding(10, 7, 10, 7);
      txtNameWeight.PasswordChar = false;
      txtNameWeight.PlaceholderColor = Color.DarkGray;
      txtNameWeight.PlaceholderText = "";
      txtNameWeight.Size = new Size(251, 46);
      txtNameWeight.TabIndex = 21;
      txtNameWeight.Texts = "";
      txtNameWeight.UnderlinedStyle = false;
      // 
      // txtNameHID
      // 
      txtNameHID.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      txtNameHID.BackColor = SystemColors.Window;
      txtNameHID.BorderColor = Color.Black;
      txtNameHID.BorderFocusColor = Color.Black;
      txtNameHID.BorderRadius = 5;
      txtNameHID.BorderSize = 2;
      txtNameHID.Font = new Font("Microsoft Sans Serif", 20.25F);
      txtNameHID.ForeColor = Color.FromArgb(64, 64, 64);
      txtNameHID.Location = new Point(274, 4);
      txtNameHID.Margin = new Padding(4);
      txtNameHID.Multiline = false;
      txtNameHID.Name = "txtNameHID";
      txtNameHID.Padding = new Padding(10, 7, 10, 7);
      txtNameHID.PasswordChar = false;
      txtNameHID.PlaceholderColor = Color.DarkGray;
      txtNameHID.PlaceholderText = "";
      txtNameHID.Size = new Size(276, 46);
      txtNameHID.TabIndex = 22;
      txtNameHID.Texts = "";
      txtNameHID.UnderlinedStyle = false;
      // 
      // FrmSettingDevice
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(1634, 826);
      Controls.Add(tableLayoutPanel1);
      Name = "FrmSettingDevice";
      Text = "FrmSettingDevice";
      tableLayoutPanel9.ResumeLayout(false);
      tableLayoutPanel3.ResumeLayout(false);
      tableLayoutPanel3.PerformLayout();
      tableLayoutPanel4.ResumeLayout(false);
      tableLayoutPanel4.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)portHID).EndInit();
      ((System.ComponentModel.ISupportInitialize)timeoutHID).EndInit();
      ((System.ComponentModel.ISupportInitialize)checkConnectHID).EndInit();
      tableLayoutPanel5.ResumeLayout(false);
      tableLayoutPanel2.ResumeLayout(false);
      tableLayoutPanel2.PerformLayout();
      tableLayoutPanel6.ResumeLayout(false);
      tableLayoutPanel11.ResumeLayout(false);
      tableLayoutPanel12.ResumeLayout(false);
      tableLayoutPanel12.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)portWeight).EndInit();
      ((System.ComponentModel.ISupportInitialize)timeoutWeight).EndInit();
      ((System.ComponentModel.ISupportInitialize)checkConnectWeight).EndInit();
      ((System.ComponentModel.ISupportInitialize)sampleTimeWeight).EndInit();
      tableLayoutPanel1.ResumeLayout(false);
      ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel9;
    private TableLayoutPanel tableLayoutPanel3;
    private TableLayoutPanel tableLayoutPanel4;
    private NumericUpDown portHID;
    private CustomControls.RJControls.RJTextBox txtIpHID;
    private Label label1;
    private Label label4;
    private NumericUpDown timeoutHID;
    private NumericUpDown checkConnectHID;
    private Label label12;
    private Label label11;
    private Label label3;
    private TableLayoutPanel tableLayoutPanel5;
    private Custom.RJButton btnBackHid;
    private Custom.RJButton btnSaveHid;
    private TableLayoutPanel tableLayoutPanel2;
    private TableLayoutPanel tableLayoutPanel6;
    private TableLayoutPanel tableLayoutPanel11;
    private Custom.RJButton btnBackWeight;
    private Custom.RJButton btnSaveWeight;
    private TableLayoutPanel tableLayoutPanel12;
    private NumericUpDown portWeight;
    private CustomControls.RJControls.RJTextBox txtIpWeight;
    private Label label7;
    private Label label6;
    private Label label5;
    private NumericUpDown timeoutWeight;
    private NumericUpDown checkConnectWeight;
    private NumericUpDown sampleTimeWeight;
    private Label label10;
    private Label label9;
    private Label label2;
    private TableLayoutPanel tableLayoutPanel1;
    private CustomControls.RJControls.RJTextBox txtNameHID;
    private Label label13;
    private CustomControls.RJControls.RJTextBox txtNameWeight;
    private Label label8;
  }
}