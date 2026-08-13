namespace LaborTrackPro.Setting
{
  partial class FrmSettingServer
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
      tableLayoutPanel1 = new TableLayoutPanel();
      tableLayoutPanel3 = new TableLayoutPanel();
      tableLayoutPanel6 = new TableLayoutPanel();
      tableLayoutPanel12 = new TableLayoutPanel();
      txtIpServer = new CustomControls.RJControls.RJTextBox();
      txtTimeSync = new CustomControls.RJControls.RJTextBox();
      picAutoSync = new PictureBox();
      label3 = new Label();
      label1 = new Label();
      label2 = new Label();
      btnSaveServer = new LaborTrackPro.Custom.RJButton();
      btnSettingServer = new Label();
      tableLayoutPanel2 = new TableLayoutPanel();
      label7 = new Label();
      tableLayoutPanel4 = new TableLayoutPanel();
      btnSaveStationMachine = new LaborTrackPro.Custom.RJButton();
      cbbMachine = new ComboBox();
      tableLayoutPanel1.SuspendLayout();
      tableLayoutPanel3.SuspendLayout();
      tableLayoutPanel6.SuspendLayout();
      tableLayoutPanel12.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)picAutoSync).BeginInit();
      tableLayoutPanel2.SuspendLayout();
      tableLayoutPanel4.SuspendLayout();
      SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.BackColor = Color.White;
      tableLayoutPanel1.ColumnCount = 3;
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
      tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 1, 1);
      tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 3);
      tableLayoutPanel1.Dock = DockStyle.Fill;
      tableLayoutPanel1.Location = new Point(0, 0);
      tableLayoutPanel1.Margin = new Padding(0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 6;
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 350F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 260F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel1.Size = new Size(1265, 874);
      tableLayoutPanel1.TabIndex = 2;
      // 
      // tableLayoutPanel3
      // 
      tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel3.BackColor = Color.Gainsboro;
      tableLayoutPanel3.ColumnCount = 1;
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel3.Controls.Add(tableLayoutPanel6, 0, 1);
      tableLayoutPanel3.Controls.Add(btnSettingServer, 0, 0);
      tableLayoutPanel3.Location = new Point(13, 33);
      tableLayoutPanel3.Name = "tableLayoutPanel3";
      tableLayoutPanel3.RowCount = 2;
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel3.Size = new Size(1239, 344);
      tableLayoutPanel3.TabIndex = 14;
      // 
      // tableLayoutPanel6
      // 
      tableLayoutPanel6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel6.ColumnCount = 1;
      tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel6.Controls.Add(tableLayoutPanel12, 0, 0);
      tableLayoutPanel6.Controls.Add(btnSaveServer, 0, 2);
      tableLayoutPanel6.Location = new Point(0, 60);
      tableLayoutPanel6.Margin = new Padding(0);
      tableLayoutPanel6.Name = "tableLayoutPanel6";
      tableLayoutPanel6.RowCount = 4;
      tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
      tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel6.Size = new Size(1239, 284);
      tableLayoutPanel6.TabIndex = 13;
      // 
      // tableLayoutPanel12
      // 
      tableLayoutPanel12.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel12.ColumnCount = 3;
      tableLayoutPanel12.ColumnStyles.Add(new ColumnStyle());
      tableLayoutPanel12.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel12.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
      tableLayoutPanel12.Controls.Add(txtIpServer, 1, 0);
      tableLayoutPanel12.Controls.Add(txtTimeSync, 1, 1);
      tableLayoutPanel12.Controls.Add(picAutoSync, 1, 2);
      tableLayoutPanel12.Controls.Add(label3, 0, 1);
      tableLayoutPanel12.Controls.Add(label1, 0, 2);
      tableLayoutPanel12.Controls.Add(label2, 0, 0);
      tableLayoutPanel12.Location = new Point(0, 0);
      tableLayoutPanel12.Margin = new Padding(0);
      tableLayoutPanel12.Name = "tableLayoutPanel12";
      tableLayoutPanel12.RowCount = 3;
      tableLayoutPanel12.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333359F));
      tableLayoutPanel12.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
      tableLayoutPanel12.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333359F));
      tableLayoutPanel12.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel12.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel12.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel12.Size = new Size(1239, 174);
      tableLayoutPanel12.TabIndex = 17;
      // 
      // txtIpServer
      // 
      txtIpServer.Anchor = AnchorStyles.Left;
      txtIpServer.BackColor = SystemColors.Window;
      txtIpServer.BorderColor = Color.Black;
      txtIpServer.BorderFocusColor = Color.FromArgb(228, 148, 1);
      txtIpServer.BorderRadius = 5;
      txtIpServer.BorderSize = 2;
      txtIpServer.Font = new Font("Microsoft Sans Serif", 20.25F);
      txtIpServer.ForeColor = Color.FromArgb(64, 64, 64);
      txtIpServer.Location = new Point(394, 6);
      txtIpServer.Margin = new Padding(4);
      txtIpServer.Multiline = false;
      txtIpServer.Name = "txtIpServer";
      txtIpServer.Padding = new Padding(10, 7, 10, 7);
      txtIpServer.PasswordChar = false;
      txtIpServer.PlaceholderColor = Color.DarkGray;
      txtIpServer.PlaceholderText = "";
      txtIpServer.Size = new Size(292, 46);
      txtIpServer.TabIndex = 7;
      txtIpServer.Texts = "";
      txtIpServer.UnderlinedStyle = false;
      // 
      // txtTimeSync
      // 
      txtTimeSync.Anchor = AnchorStyles.Left;
      txtTimeSync.BackColor = SystemColors.Window;
      txtTimeSync.BorderColor = Color.Black;
      txtTimeSync.BorderFocusColor = Color.FromArgb(228, 148, 1);
      txtTimeSync.BorderRadius = 5;
      txtTimeSync.BorderSize = 2;
      txtTimeSync.Font = new Font("Microsoft Sans Serif", 20.25F);
      txtTimeSync.ForeColor = Color.FromArgb(64, 64, 64);
      txtTimeSync.Location = new Point(394, 63);
      txtTimeSync.Margin = new Padding(4);
      txtTimeSync.Multiline = false;
      txtTimeSync.Name = "txtTimeSync";
      txtTimeSync.Padding = new Padding(10, 7, 10, 7);
      txtTimeSync.PasswordChar = false;
      txtTimeSync.PlaceholderColor = Color.DarkGray;
      txtTimeSync.PlaceholderText = "";
      txtTimeSync.Size = new Size(292, 46);
      txtTimeSync.TabIndex = 7;
      txtTimeSync.Texts = "";
      txtTimeSync.UnderlinedStyle = false;
      txtTimeSync.KeyPress += txtTimeSync_KeyPress;
      // 
      // picAutoSync
      // 
      picAutoSync.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      picAutoSync.Image = Properties.Resources.icon_toggle_off;
      picAutoSync.Location = new Point(390, 115);
      picAutoSync.Margin = new Padding(0);
      picAutoSync.Name = "picAutoSync";
      picAutoSync.Size = new Size(84, 59);
      picAutoSync.SizeMode = PictureBoxSizeMode.StretchImage;
      picAutoSync.TabIndex = 7;
      picAutoSync.TabStop = false;
      picAutoSync.Click += picAutoSync_Click;
      // 
      // label3
      // 
      label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label3.AutoSize = true;
      label3.Font = new Font("Microsoft Sans Serif", 20.25F);
      label3.Location = new Point(3, 58);
      label3.Name = "label3";
      label3.Size = new Size(384, 57);
      label3.TabIndex = 2;
      label3.Text = "Thời gian đồng bộ dữ liệu(ms) :";
      label3.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // label1
      // 
      label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label1.AutoSize = true;
      label1.Font = new Font("Microsoft Sans Serif", 20.25F);
      label1.Location = new Point(3, 115);
      label1.Name = "label1";
      label1.Size = new Size(384, 59);
      label1.TabIndex = 2;
      label1.Text = "IP Server:";
      label1.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // label2
      // 
      label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label2.AutoSize = true;
      label2.Font = new Font("Microsoft Sans Serif", 20.25F);
      label2.Location = new Point(3, 0);
      label2.Name = "label2";
      label2.Size = new Size(384, 58);
      label2.TabIndex = 2;
      label2.Text = "Tự động đồng bộ dữ liệu";
      label2.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // btnSaveServer
      // 
      btnSaveServer.Anchor = AnchorStyles.Right;
      btnSaveServer.BackColor = Color.FromArgb(49, 68, 108);
      btnSaveServer.BackgroundColor = Color.FromArgb(49, 68, 108);
      btnSaveServer.BorderColor = Color.PaleVioletRed;
      btnSaveServer.BorderRadius = 5;
      btnSaveServer.BorderSize = 0;
      btnSaveServer.FlatAppearance.BorderSize = 0;
      btnSaveServer.FlatStyle = FlatStyle.Flat;
      btnSaveServer.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold);
      btnSaveServer.ForeColor = Color.White;
      btnSaveServer.Location = new Point(1016, 201);
      btnSaveServer.Margin = new Padding(3, 3, 10, 3);
      btnSaveServer.Name = "btnSaveServer";
      btnSaveServer.Size = new Size(213, 55);
      btnSaveServer.TabIndex = 24;
      btnSaveServer.Text = "Lưu thay đổi";
      btnSaveServer.TextColor = Color.White;
      btnSaveServer.UseVisualStyleBackColor = false;
      btnSaveServer.Click += btnSaveServer_Click;
      // 
      // btnSettingServer
      // 
      btnSettingServer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      btnSettingServer.AutoSize = true;
      btnSettingServer.BackColor = Color.Silver;
      btnSettingServer.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold);
      btnSettingServer.ForeColor = Color.Black;
      btnSettingServer.Location = new Point(0, 0);
      btnSettingServer.Margin = new Padding(0);
      btnSettingServer.Name = "btnSettingServer";
      btnSettingServer.Size = new Size(1239, 60);
      btnSettingServer.TabIndex = 11;
      btnSettingServer.Text = "Cài đặt kết nối Server";
      btnSettingServer.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel2.BackColor = Color.Gainsboro;
      tableLayoutPanel2.ColumnCount = 1;
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.Controls.Add(label7, 0, 0);
      tableLayoutPanel2.Controls.Add(tableLayoutPanel4, 0, 1);
      tableLayoutPanel2.Location = new Point(13, 403);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 2;
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.Size = new Size(1239, 254);
      tableLayoutPanel2.TabIndex = 16;
      // 
      // label7
      // 
      label7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label7.AutoSize = true;
      label7.BackColor = Color.Silver;
      label7.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold);
      label7.ForeColor = Color.Black;
      label7.Location = new Point(0, 0);
      label7.Margin = new Padding(0);
      label7.Name = "label7";
      label7.Size = new Size(1239, 60);
      label7.TabIndex = 11;
      label7.Text = "Cài đặt trạm cân";
      label7.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // tableLayoutPanel4
      // 
      tableLayoutPanel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel4.ColumnCount = 1;
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel4.Controls.Add(btnSaveStationMachine, 0, 3);
      tableLayoutPanel4.Controls.Add(cbbMachine, 0, 1);
      tableLayoutPanel4.Location = new Point(0, 60);
      tableLayoutPanel4.Margin = new Padding(0);
      tableLayoutPanel4.Name = "tableLayoutPanel4";
      tableLayoutPanel4.RowCount = 5;
      tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 19F));
      tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 71F));
      tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel4.Size = new Size(1239, 194);
      tableLayoutPanel4.TabIndex = 13;
      // 
      // btnSaveStationMachine
      // 
      btnSaveStationMachine.Anchor = AnchorStyles.Right;
      btnSaveStationMachine.BackColor = Color.FromArgb(49, 68, 108);
      btnSaveStationMachine.BackgroundColor = Color.FromArgb(49, 68, 108);
      btnSaveStationMachine.BorderColor = Color.PaleVioletRed;
      btnSaveStationMachine.BorderRadius = 5;
      btnSaveStationMachine.BorderSize = 0;
      btnSaveStationMachine.FlatAppearance.BorderSize = 0;
      btnSaveStationMachine.FlatStyle = FlatStyle.Flat;
      btnSaveStationMachine.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold);
      btnSaveStationMachine.ForeColor = Color.White;
      btnSaveStationMachine.Location = new Point(1016, 111);
      btnSaveStationMachine.Margin = new Padding(3, 3, 10, 3);
      btnSaveStationMachine.Name = "btnSaveStationMachine";
      btnSaveStationMachine.Size = new Size(213, 55);
      btnSaveStationMachine.TabIndex = 24;
      btnSaveStationMachine.Text = "Lưu thay đổi";
      btnSaveStationMachine.TextColor = Color.White;
      btnSaveStationMachine.UseVisualStyleBackColor = false;
      btnSaveStationMachine.Click += btnSaveStationMachine_Click;
      // 
      // cbbMachine
      // 
      cbbMachine.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      cbbMachine.DropDownStyle = ComboBoxStyle.DropDownList;
      cbbMachine.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
      cbbMachine.FormattingEnabled = true;
      cbbMachine.Location = new Point(3, 29);
      cbbMachine.Name = "cbbMachine";
      cbbMachine.Size = new Size(1233, 45);
      cbbMachine.TabIndex = 17;
      // 
      // FrmSettingServer
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(1265, 874);
      Controls.Add(tableLayoutPanel1);
      Name = "FrmSettingServer";
      Text = "FrmSettingServer";
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel3.ResumeLayout(false);
      tableLayoutPanel3.PerformLayout();
      tableLayoutPanel6.ResumeLayout(false);
      tableLayoutPanel12.ResumeLayout(false);
      tableLayoutPanel12.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)picAutoSync).EndInit();
      tableLayoutPanel2.ResumeLayout(false);
      tableLayoutPanel2.PerformLayout();
      tableLayoutPanel4.ResumeLayout(false);
      ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private Label label1;
    private CustomControls.RJControls.RJTextBox txtIpServer;
    private Label label2;
    private PictureBox picAutoSync;
    private Label label3;
    private CustomControls.RJControls.RJTextBox txtTimeSync;
    private TableLayoutPanel tableLayoutPanel3;
    private TableLayoutPanel tableLayoutPanel6;
    private Custom.RJButton btnSaveServer;
    private TableLayoutPanel tableLayoutPanel12;
    private Label btnSettingServer;
    private TableLayoutPanel tableLayoutPanel2;
    private TableLayoutPanel tableLayoutPanel4;
    private Custom.RJButton btnSaveStationMachine;
    private Label label7;
    private ComboBox cbbMachine;
  }
}