namespace Common.Settings
{
  partial class PopupSettingTcpClient
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
      tableLayoutPanel3 = new TableLayoutPanel();
      label1 = new Label();
      tableLayoutPanel1 = new TableLayoutPanel();
      rjTextBox3 = new Common.Custom.RJTextBox();
      rjTextBox2 = new Common.Custom.RJTextBox();
      label3 = new Label();
      label2 = new Label();
      label5 = new Label();
      label4 = new Label();
      label6 = new Label();
      rjTextBox1 = new Common.Custom.RJTextBox();
      pictureBox1 = new PictureBox();
      tableLayoutPanel2 = new TableLayoutPanel();
      btnConfirm = new Common.Custom.RJButton();
      btnClose = new Common.Custom.RJButton();
      pictureBox2 = new PictureBox();
      tableLayoutPanel3.SuspendLayout();
      tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
      tableLayoutPanel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
      SuspendLayout();
      // 
      // tableLayoutPanel3
      // 
      tableLayoutPanel3.BackColor = Color.FromArgb(236, 236, 236);
      tableLayoutPanel3.ColumnCount = 1;
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel3.Controls.Add(label1, 0, 0);
      tableLayoutPanel3.Controls.Add(tableLayoutPanel1, 0, 1);
      tableLayoutPanel3.Controls.Add(tableLayoutPanel2, 0, 3);
      tableLayoutPanel3.Dock = DockStyle.Fill;
      tableLayoutPanel3.Location = new Point(0, 0);
      tableLayoutPanel3.Margin = new Padding(0);
      tableLayoutPanel3.Name = "tableLayoutPanel3";
      tableLayoutPanel3.RowCount = 5;
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 300F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
      tableLayoutPanel3.Size = new Size(537, 509);
      tableLayoutPanel3.TabIndex = 4;
      // 
      // label1
      // 
      label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label1.AutoSize = true;
      label1.BackColor = Color.FromArgb(199, 199, 199);
      label1.Font = new Font("Roboto Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
      label1.Location = new Point(0, 0);
      label1.Margin = new Padding(0);
      label1.Name = "label1";
      label1.Size = new Size(537, 60);
      label1.TabIndex = 0;
      label1.Text = "Chọn chuẩn kết nối";
      label1.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel1.ColumnCount = 2;
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.Controls.Add(pictureBox2, 1, 4);
      tableLayoutPanel1.Controls.Add(rjTextBox3, 1, 2);
      tableLayoutPanel1.Controls.Add(rjTextBox2, 1, 1);
      tableLayoutPanel1.Controls.Add(label3, 0, 1);
      tableLayoutPanel1.Controls.Add(label2, 0, 0);
      tableLayoutPanel1.Controls.Add(label5, 0, 3);
      tableLayoutPanel1.Controls.Add(label4, 0, 2);
      tableLayoutPanel1.Controls.Add(label6, 0, 4);
      tableLayoutPanel1.Controls.Add(rjTextBox1, 1, 0);
      tableLayoutPanel1.Controls.Add(pictureBox1, 1, 3);
      tableLayoutPanel1.Location = new Point(10, 60);
      tableLayoutPanel1.Margin = new Padding(10, 0, 10, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 5;
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20.666666F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 19.333334F));
      tableLayoutPanel1.Size = new Size(517, 300);
      tableLayoutPanel1.TabIndex = 3;
      // 
      // rjTextBox3
      // 
      rjTextBox3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      rjTextBox3.BackColor = SystemColors.Window;
      rjTextBox3.BorderColor = Color.Black;
      rjTextBox3.BorderFocusColor = Color.HotPink;
      rjTextBox3.BorderRadius = 5;
      rjTextBox3.BorderSize = 2;
      rjTextBox3.Font = new Font("Roboto Light", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
      rjTextBox3.ForeColor = Color.FromArgb(64, 64, 64);
      rjTextBox3.Location = new Point(194, 130);
      rjTextBox3.Margin = new Padding(4);
      rjTextBox3.Multiline = false;
      rjTextBox3.Name = "rjTextBox3";
      rjTextBox3.Padding = new Padding(10, 7, 10, 7);
      rjTextBox3.PasswordChar = false;
      rjTextBox3.PlaceholderColor = Color.DarkGray;
      rjTextBox3.PlaceholderText = "";
      rjTextBox3.Size = new Size(319, 40);
      rjTextBox3.TabIndex = 10;
      rjTextBox3.Texts = "";
      rjTextBox3.UnderlinedStyle = false;
      // 
      // rjTextBox2
      // 
      rjTextBox2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      rjTextBox2.BackColor = SystemColors.Window;
      rjTextBox2.BorderColor = Color.Black;
      rjTextBox2.BorderFocusColor = Color.HotPink;
      rjTextBox2.BorderRadius = 5;
      rjTextBox2.BorderSize = 2;
      rjTextBox2.Font = new Font("Roboto Light", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
      rjTextBox2.ForeColor = Color.FromArgb(64, 64, 64);
      rjTextBox2.Location = new Point(194, 70);
      rjTextBox2.Margin = new Padding(4);
      rjTextBox2.Multiline = false;
      rjTextBox2.Name = "rjTextBox2";
      rjTextBox2.Padding = new Padding(10, 7, 10, 7);
      rjTextBox2.PasswordChar = false;
      rjTextBox2.PlaceholderColor = Color.DarkGray;
      rjTextBox2.PlaceholderText = "";
      rjTextBox2.Size = new Size(319, 40);
      rjTextBox2.TabIndex = 9;
      rjTextBox2.Texts = "";
      rjTextBox2.UnderlinedStyle = false;
      // 
      // label3
      // 
      label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label3.AutoSize = true;
      label3.BackColor = Color.Transparent;
      label3.Font = new Font("Roboto Light", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
      label3.Location = new Point(0, 60);
      label3.Margin = new Padding(0);
      label3.Name = "label3";
      label3.Size = new Size(190, 60);
      label3.TabIndex = 3;
      label3.Text = "Port:";
      label3.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // label2
      // 
      label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label2.AutoSize = true;
      label2.BackColor = Color.Transparent;
      label2.Font = new Font("Roboto Light", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
      label2.Location = new Point(0, 0);
      label2.Margin = new Padding(0);
      label2.Name = "label2";
      label2.Size = new Size(190, 60);
      label2.TabIndex = 1;
      label2.Text = "Địa chỉ IP:";
      label2.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // label5
      // 
      label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label5.AutoSize = true;
      label5.BackColor = Color.Transparent;
      label5.Font = new Font("Roboto Light", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
      label5.Location = new Point(0, 180);
      label5.Margin = new Padding(0);
      label5.Name = "label5";
      label5.Size = new Size(190, 62);
      label5.TabIndex = 5;
      label5.Text = "Gửi lệnh lấy dữ liệu:";
      label5.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // label4
      // 
      label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label4.AutoSize = true;
      label4.BackColor = Color.Transparent;
      label4.Font = new Font("Roboto Light", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
      label4.Location = new Point(0, 120);
      label4.Margin = new Padding(0);
      label4.Name = "label4";
      label4.Size = new Size(190, 60);
      label4.TabIndex = 4;
      label4.Text = "Timeout (s):";
      label4.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // label6
      // 
      label6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label6.AutoSize = true;
      label6.BackColor = Color.Transparent;
      label6.Font = new Font("Roboto Light", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
      label6.Location = new Point(0, 242);
      label6.Margin = new Padding(0);
      label6.Name = "label6";
      label6.Size = new Size(190, 58);
      label6.TabIndex = 6;
      label6.Text = "Tự động kết nối:";
      label6.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // rjTextBox1
      // 
      rjTextBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      rjTextBox1.BackColor = SystemColors.Window;
      rjTextBox1.BorderColor = Color.Black;
      rjTextBox1.BorderFocusColor = Color.HotPink;
      rjTextBox1.BorderRadius = 5;
      rjTextBox1.BorderSize = 2;
      rjTextBox1.Font = new Font("Roboto Light", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
      rjTextBox1.ForeColor = Color.FromArgb(64, 64, 64);
      rjTextBox1.Location = new Point(194, 10);
      rjTextBox1.Margin = new Padding(4);
      rjTextBox1.Multiline = false;
      rjTextBox1.Name = "rjTextBox1";
      rjTextBox1.Padding = new Padding(10, 7, 10, 7);
      rjTextBox1.PasswordChar = false;
      rjTextBox1.PlaceholderColor = Color.DarkGray;
      rjTextBox1.PlaceholderText = "";
      rjTextBox1.Size = new Size(319, 40);
      rjTextBox1.TabIndex = 8;
      rjTextBox1.Texts = "";
      rjTextBox1.UnderlinedStyle = false;
      // 
      // pictureBox1
      // 
      pictureBox1.Anchor = AnchorStyles.Left;
      pictureBox1.Location = new Point(193, 191);
      pictureBox1.Name = "pictureBox1";
      pictureBox1.Size = new Size(100, 40);
      pictureBox1.TabIndex = 11;
      pictureBox1.TabStop = false;
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel2.ColumnCount = 3;
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
      tableLayoutPanel2.Controls.Add(btnConfirm, 1, 0);
      tableLayoutPanel2.Controls.Add(btnClose, 2, 0);
      tableLayoutPanel2.Location = new Point(10, 439);
      tableLayoutPanel2.Margin = new Padding(10, 0, 10, 0);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 1;
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.Size = new Size(517, 60);
      tableLayoutPanel2.TabIndex = 4;
      // 
      // btnConfirm
      // 
      btnConfirm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      btnConfirm.BackColor = Color.FromArgb(51, 108, 181);
      btnConfirm.BackgroundColor = Color.FromArgb(51, 108, 181);
      btnConfirm.BorderColor = Color.PaleVioletRed;
      btnConfirm.BorderRadius = 4;
      btnConfirm.BorderSize = 0;
      btnConfirm.FlatAppearance.BorderSize = 0;
      btnConfirm.FlatStyle = FlatStyle.Flat;
      btnConfirm.Font = new Font("Roboto", 15.75F, FontStyle.Bold);
      btnConfirm.ForeColor = Color.White;
      btnConfirm.Image = Properties.Resources.icon_confirm;
      btnConfirm.ImageAlign = ContentAlignment.MiddleLeft;
      btnConfirm.Location = new Point(200, 3);
      btnConfirm.Name = "btnConfirm";
      btnConfirm.Padding = new Padding(10, 0, 0, 0);
      btnConfirm.Size = new Size(154, 54);
      btnConfirm.TabIndex = 0;
      btnConfirm.Text = "       Xác nhận";
      btnConfirm.TextColor = Color.White;
      btnConfirm.UseVisualStyleBackColor = false;
      // 
      // btnClose
      // 
      btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      btnClose.BackColor = Color.Tomato;
      btnClose.BackgroundColor = Color.Tomato;
      btnClose.BorderColor = Color.PaleVioletRed;
      btnClose.BorderRadius = 4;
      btnClose.BorderSize = 0;
      btnClose.FlatAppearance.BorderSize = 0;
      btnClose.FlatStyle = FlatStyle.Flat;
      btnClose.Font = new Font("Roboto", 15.75F, FontStyle.Bold);
      btnClose.ForeColor = Color.White;
      btnClose.Image = Properties.Resources.icon_close;
      btnClose.ImageAlign = ContentAlignment.MiddleLeft;
      btnClose.Location = new Point(360, 3);
      btnClose.Name = "btnClose";
      btnClose.Padding = new Padding(10, 0, 0, 0);
      btnClose.Size = new Size(154, 54);
      btnClose.TabIndex = 1;
      btnClose.Text = "       Đóng";
      btnClose.TextColor = Color.White;
      btnClose.UseVisualStyleBackColor = false;
      // 
      // pictureBox2
      // 
      pictureBox2.Anchor = AnchorStyles.Left;
      pictureBox2.Location = new Point(193, 251);
      pictureBox2.Name = "pictureBox2";
      pictureBox2.Size = new Size(100, 40);
      pictureBox2.TabIndex = 12;
      pictureBox2.TabStop = false;
      // 
      // PopupSettingTcpClient
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(537, 509);
      ControlBox = false;
      Controls.Add(tableLayoutPanel3);
      Name = "PopupSettingTcpClient";
      tableLayoutPanel3.ResumeLayout(false);
      tableLayoutPanel3.PerformLayout();
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
      tableLayoutPanel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel3;
    private Label label1;
    private TableLayoutPanel tableLayoutPanel1;
    private Label label2;
    private TableLayoutPanel tableLayoutPanel2;
    private Custom.RJButton btnConfirm;
    private Custom.RJButton btnClose;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label label6;
    private Custom.RJTextBox rjTextBox1;
    private Custom.RJTextBox rjTextBox3;
    private Custom.RJTextBox rjTextBox2;
    private PictureBox pictureBox1;
    private PictureBox pictureBox2;
  }
}