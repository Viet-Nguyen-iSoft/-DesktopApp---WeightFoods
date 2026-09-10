

using LTP.Truck.Custom;

namespace LTP.Truck.Forms
{
  partial class FrmSetting
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSetting));
      tableLayoutPanel1 = new TableLayoutPanel();
      tableLayoutPanel3 = new TableLayoutPanel();
      tableLayoutPanel10 = new TableLayoutPanel();
      label1 = new Label();
      btnAddCommWeight = new RJButton();
      flowCommWeight = new FlowLayoutPanel();
      tableLayoutPanel2 = new TableLayoutPanel();
      tableLayoutPanel4 = new TableLayoutPanel();
      tableLayoutPanel6 = new TableLayoutPanel();
      btnConfirm = new Common.Custom.RJButton();
      label2 = new Label();
      tableLayoutPanel5 = new TableLayoutPanel();
      rjTextBox2 = new Common.Custom.RJTextBox();
      label3 = new Label();
      label4 = new Label();
      rjTextBox1 = new Common.Custom.RJTextBox();
      tableLayoutPanel7 = new TableLayoutPanel();
      tableLayoutPanel8 = new TableLayoutPanel();
      btnSavePrint = new Common.Custom.RJButton();
      label5 = new Label();
      tableLayoutPanel9 = new TableLayoutPanel();
      label6 = new Label();
      cbbPrint = new ComboBox();
      tableLayoutPanel1.SuspendLayout();
      tableLayoutPanel3.SuspendLayout();
      tableLayoutPanel10.SuspendLayout();
      tableLayoutPanel2.SuspendLayout();
      tableLayoutPanel4.SuspendLayout();
      tableLayoutPanel6.SuspendLayout();
      tableLayoutPanel5.SuspendLayout();
      tableLayoutPanel7.SuspendLayout();
      tableLayoutPanel8.SuspendLayout();
      tableLayoutPanel9.SuspendLayout();
      SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.BackColor = Color.White;
      tableLayoutPanel1.ColumnCount = 2;
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 5F));
      tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 0);
      tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 2);
      tableLayoutPanel1.Dock = DockStyle.Fill;
      tableLayoutPanel1.Location = new Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 5;
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
      tableLayoutPanel1.Size = new Size(1221, 998);
      tableLayoutPanel1.TabIndex = 2;
      // 
      // tableLayoutPanel3
      // 
      tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel3.BackColor = Color.FromArgb(236, 236, 236);
      tableLayoutPanel3.ColumnCount = 1;
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel3.Controls.Add(tableLayoutPanel10, 0, 0);
      tableLayoutPanel3.Controls.Add(flowCommWeight, 0, 1);
      tableLayoutPanel3.Location = new Point(0, 0);
      tableLayoutPanel3.Margin = new Padding(0);
      tableLayoutPanel3.Name = "tableLayoutPanel3";
      tableLayoutPanel3.RowCount = 2;
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel3.Size = new Size(1216, 489);
      tableLayoutPanel3.TabIndex = 2;
      // 
      // tableLayoutPanel10
      // 
      tableLayoutPanel10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel10.BackColor = Color.FromArgb(199, 199, 199);
      tableLayoutPanel10.ColumnCount = 2;
      tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 240F));
      tableLayoutPanel10.Controls.Add(label1, 0, 0);
      tableLayoutPanel10.Controls.Add(btnAddCommWeight, 1, 0);
      tableLayoutPanel10.Location = new Point(0, 0);
      tableLayoutPanel10.Margin = new Padding(0);
      tableLayoutPanel10.Name = "tableLayoutPanel10";
      tableLayoutPanel10.RowCount = 1;
      tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel10.Size = new Size(1216, 60);
      tableLayoutPanel10.TabIndex = 2;
      // 
      // label1
      // 
      label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label1.AutoSize = true;
      label1.BackColor = Color.FromArgb(199, 199, 199);
      label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
      label1.Location = new Point(0, 0);
      label1.Margin = new Padding(0);
      label1.Name = "label1";
      label1.Size = new Size(976, 60);
      label1.TabIndex = 0;
      label1.Text = "Thông tin kết nối cân";
      label1.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // btnAddCommWeight
      // 
      btnAddCommWeight.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      btnAddCommWeight.BackColor = Color.FromArgb(51, 108, 181);
      btnAddCommWeight.BackgroundColor = Color.FromArgb(51, 108, 181);
      btnAddCommWeight.BorderColor = Color.PaleVioletRed;
      btnAddCommWeight.BorderRadius = 5;
      btnAddCommWeight.BorderSize = 0;
      btnAddCommWeight.FlatAppearance.BorderSize = 0;
      btnAddCommWeight.FlatStyle = FlatStyle.Flat;
      btnAddCommWeight.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
      btnAddCommWeight.ForeColor = Color.White;
      btnAddCommWeight.Image = (Image)resources.GetObject("btnAddCommWeight.Image");
      btnAddCommWeight.ImageAlign = ContentAlignment.MiddleLeft;
      btnAddCommWeight.Location = new Point(979, 3);
      btnAddCommWeight.Name = "btnAddCommWeight";
      btnAddCommWeight.Padding = new Padding(10, 0, 0, 0);
      btnAddCommWeight.Size = new Size(234, 54);
      btnAddCommWeight.TabIndex = 0;
      btnAddCommWeight.Text = "        Thêm kết nối";
      btnAddCommWeight.TextAlign = ContentAlignment.MiddleLeft;
      btnAddCommWeight.TextColor = Color.White;
      btnAddCommWeight.UseVisualStyleBackColor = false;
      // 
      // flowCommWeight
      // 
      flowCommWeight.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      flowCommWeight.Location = new Point(3, 63);
      flowCommWeight.Name = "flowCommWeight";
      flowCommWeight.Size = new Size(1210, 423);
      flowCommWeight.TabIndex = 3;
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel2.ColumnCount = 3;
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
      tableLayoutPanel2.Controls.Add(tableLayoutPanel4, 0, 0);
      tableLayoutPanel2.Controls.Add(tableLayoutPanel7, 2, 0);
      tableLayoutPanel2.Location = new Point(0, 499);
      tableLayoutPanel2.Margin = new Padding(0);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 1;
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.Size = new Size(1216, 244);
      tableLayoutPanel2.TabIndex = 3;
      // 
      // tableLayoutPanel4
      // 
      tableLayoutPanel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel4.BackColor = Color.FromArgb(236, 236, 236);
      tableLayoutPanel4.ColumnCount = 1;
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel4.Controls.Add(tableLayoutPanel6, 0, 3);
      tableLayoutPanel4.Controls.Add(label2, 0, 0);
      tableLayoutPanel4.Controls.Add(tableLayoutPanel5, 0, 1);
      tableLayoutPanel4.Location = new Point(0, 0);
      tableLayoutPanel4.Margin = new Padding(0);
      tableLayoutPanel4.Name = "tableLayoutPanel4";
      tableLayoutPanel4.RowCount = 5;
      tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
      tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 5F));
      tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
      tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 5F));
      tableLayoutPanel4.Size = new Size(422, 244);
      tableLayoutPanel4.TabIndex = 1;
      // 
      // tableLayoutPanel6
      // 
      tableLayoutPanel6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel6.ColumnCount = 4;
      tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle());
      tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle());
      tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 5F));
      tableLayoutPanel6.Controls.Add(btnConfirm, 2, 0);
      tableLayoutPanel6.Location = new Point(0, 179);
      tableLayoutPanel6.Margin = new Padding(0);
      tableLayoutPanel6.Name = "tableLayoutPanel6";
      tableLayoutPanel6.RowCount = 1;
      tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel6.Size = new Size(422, 60);
      tableLayoutPanel6.TabIndex = 6;
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
      btnConfirm.Image = Properties.Resources.icon_save;
      btnConfirm.ImageAlign = ContentAlignment.MiddleLeft;
      btnConfirm.Location = new Point(223, 3);
      btnConfirm.Name = "btnConfirm";
      btnConfirm.Padding = new Padding(10, 0, 0, 0);
      btnConfirm.Size = new Size(191, 54);
      btnConfirm.TabIndex = 0;
      btnConfirm.Text = "       Lưu thay đổi";
      btnConfirm.TextColor = Color.White;
      btnConfirm.UseVisualStyleBackColor = false;
      // 
      // label2
      // 
      label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label2.AutoSize = true;
      label2.BackColor = Color.FromArgb(199, 199, 199);
      label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
      label2.Location = new Point(0, 0);
      label2.Margin = new Padding(0);
      label2.Name = "label2";
      label2.Size = new Size(422, 60);
      label2.TabIndex = 0;
      label2.Text = "Thông tin kết nối Server";
      label2.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // tableLayoutPanel5
      // 
      tableLayoutPanel5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel5.ColumnCount = 2;
      tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
      tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel5.Controls.Add(rjTextBox2, 1, 1);
      tableLayoutPanel5.Controls.Add(label3, 0, 0);
      tableLayoutPanel5.Controls.Add(label4, 0, 1);
      tableLayoutPanel5.Controls.Add(rjTextBox1, 1, 0);
      tableLayoutPanel5.Location = new Point(3, 63);
      tableLayoutPanel5.Name = "tableLayoutPanel5";
      tableLayoutPanel5.RowCount = 2;
      tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
      tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
      tableLayoutPanel5.Size = new Size(416, 108);
      tableLayoutPanel5.TabIndex = 7;
      // 
      // rjTextBox2
      // 
      rjTextBox2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      rjTextBox2.BackColor = SystemColors.Window;
      rjTextBox2.BorderColor = Color.Black;
      rjTextBox2.BorderFocusColor = Color.HotPink;
      rjTextBox2.BorderRadius = 5;
      rjTextBox2.BorderSize = 2;
      rjTextBox2.Font = new Font("Roboto Condensed", 15.75F);
      rjTextBox2.ForeColor = Color.FromArgb(64, 64, 64);
      rjTextBox2.Location = new Point(154, 61);
      rjTextBox2.Margin = new Padding(4);
      rjTextBox2.Multiline = false;
      rjTextBox2.Name = "rjTextBox2";
      rjTextBox2.Padding = new Padding(10, 7, 10, 7);
      rjTextBox2.PasswordChar = false;
      rjTextBox2.PlaceholderColor = Color.DarkGray;
      rjTextBox2.PlaceholderText = "";
      rjTextBox2.Size = new Size(258, 40);
      rjTextBox2.TabIndex = 4;
      rjTextBox2.Texts = "";
      rjTextBox2.UnderlinedStyle = false;
      // 
      // label3
      // 
      label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label3.AutoSize = true;
      label3.BackColor = Color.Transparent;
      label3.Font = new Font("Segoe UI", 15.75F);
      label3.Location = new Point(0, 0);
      label3.Margin = new Padding(0);
      label3.Name = "label3";
      label3.Size = new Size(150, 54);
      label3.TabIndex = 1;
      label3.Text = "IP:";
      label3.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // label4
      // 
      label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label4.AutoSize = true;
      label4.BackColor = Color.Transparent;
      label4.Font = new Font("Segoe UI", 15.75F);
      label4.Location = new Point(0, 54);
      label4.Margin = new Padding(0);
      label4.Name = "label4";
      label4.Size = new Size(150, 54);
      label4.TabIndex = 2;
      label4.Text = "Port:";
      label4.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // rjTextBox1
      // 
      rjTextBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      rjTextBox1.BackColor = SystemColors.Window;
      rjTextBox1.BorderColor = Color.Black;
      rjTextBox1.BorderFocusColor = Color.HotPink;
      rjTextBox1.BorderRadius = 5;
      rjTextBox1.BorderSize = 2;
      rjTextBox1.Font = new Font("Roboto Condensed", 15.75F);
      rjTextBox1.ForeColor = Color.FromArgb(64, 64, 64);
      rjTextBox1.Location = new Point(154, 7);
      rjTextBox1.Margin = new Padding(4);
      rjTextBox1.Multiline = false;
      rjTextBox1.Name = "rjTextBox1";
      rjTextBox1.Padding = new Padding(10, 7, 10, 7);
      rjTextBox1.PasswordChar = false;
      rjTextBox1.PlaceholderColor = Color.DarkGray;
      rjTextBox1.PlaceholderText = "";
      rjTextBox1.Size = new Size(258, 40);
      rjTextBox1.TabIndex = 3;
      rjTextBox1.Texts = "";
      rjTextBox1.UnderlinedStyle = false;
      // 
      // tableLayoutPanel7
      // 
      tableLayoutPanel7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel7.BackColor = Color.FromArgb(236, 236, 236);
      tableLayoutPanel7.ColumnCount = 1;
      tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel7.Controls.Add(tableLayoutPanel8, 0, 3);
      tableLayoutPanel7.Controls.Add(label5, 0, 0);
      tableLayoutPanel7.Controls.Add(tableLayoutPanel9, 0, 1);
      tableLayoutPanel7.Location = new Point(432, 0);
      tableLayoutPanel7.Margin = new Padding(0);
      tableLayoutPanel7.Name = "tableLayoutPanel7";
      tableLayoutPanel7.RowCount = 5;
      tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
      tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 5F));
      tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
      tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 5F));
      tableLayoutPanel7.Size = new Size(784, 244);
      tableLayoutPanel7.TabIndex = 2;
      // 
      // tableLayoutPanel8
      // 
      tableLayoutPanel8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel8.ColumnCount = 4;
      tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle());
      tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle());
      tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 5F));
      tableLayoutPanel8.Controls.Add(btnSavePrint, 2, 0);
      tableLayoutPanel8.Location = new Point(0, 179);
      tableLayoutPanel8.Margin = new Padding(0);
      tableLayoutPanel8.Name = "tableLayoutPanel8";
      tableLayoutPanel8.RowCount = 1;
      tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel8.Size = new Size(784, 60);
      tableLayoutPanel8.TabIndex = 6;
      // 
      // btnSavePrint
      // 
      btnSavePrint.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      btnSavePrint.BackColor = Color.FromArgb(51, 108, 181);
      btnSavePrint.BackgroundColor = Color.FromArgb(51, 108, 181);
      btnSavePrint.BorderColor = Color.PaleVioletRed;
      btnSavePrint.BorderRadius = 4;
      btnSavePrint.BorderSize = 0;
      btnSavePrint.FlatAppearance.BorderSize = 0;
      btnSavePrint.FlatStyle = FlatStyle.Flat;
      btnSavePrint.Font = new Font("Roboto", 15.75F, FontStyle.Bold);
      btnSavePrint.ForeColor = Color.White;
      btnSavePrint.Image = Properties.Resources.icon_save;
      btnSavePrint.ImageAlign = ContentAlignment.MiddleLeft;
      btnSavePrint.Location = new Point(585, 3);
      btnSavePrint.Name = "btnSavePrint";
      btnSavePrint.Padding = new Padding(10, 0, 0, 0);
      btnSavePrint.Size = new Size(191, 54);
      btnSavePrint.TabIndex = 0;
      btnSavePrint.Text = "       Lưu thay đổi";
      btnSavePrint.TextColor = Color.White;
      btnSavePrint.UseVisualStyleBackColor = false;
      // 
      // label5
      // 
      label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label5.AutoSize = true;
      label5.BackColor = Color.FromArgb(199, 199, 199);
      label5.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
      label5.Location = new Point(0, 0);
      label5.Margin = new Padding(0);
      label5.Name = "label5";
      label5.Size = new Size(784, 60);
      label5.TabIndex = 0;
      label5.Text = "Thông tin kết nối máy in";
      label5.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // tableLayoutPanel9
      // 
      tableLayoutPanel9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel9.ColumnCount = 3;
      tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
      tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 5F));
      tableLayoutPanel9.Controls.Add(label6, 0, 0);
      tableLayoutPanel9.Controls.Add(cbbPrint, 1, 0);
      tableLayoutPanel9.Location = new Point(3, 63);
      tableLayoutPanel9.Name = "tableLayoutPanel9";
      tableLayoutPanel9.RowCount = 2;
      tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
      tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
      tableLayoutPanel9.Size = new Size(778, 108);
      tableLayoutPanel9.TabIndex = 7;
      // 
      // label6
      // 
      label6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label6.AutoSize = true;
      label6.BackColor = Color.Transparent;
      label6.Font = new Font("Segoe UI", 15.75F);
      label6.Location = new Point(0, 0);
      label6.Margin = new Padding(0);
      label6.Name = "label6";
      label6.Size = new Size(150, 54);
      label6.TabIndex = 1;
      label6.Text = "Máy in:";
      label6.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // cbbPrint
      // 
      cbbPrint.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      cbbPrint.DropDownStyle = ComboBoxStyle.DropDownList;
      cbbPrint.Font = new Font("Roboto", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
      cbbPrint.FormattingEnabled = true;
      cbbPrint.Location = new Point(153, 6);
      cbbPrint.Name = "cbbPrint";
      cbbPrint.Size = new Size(617, 41);
      cbbPrint.TabIndex = 2;
      // 
      // FrmSetting
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(1221, 998);
      Controls.Add(tableLayoutPanel1);
      Name = "FrmSetting";
      Text = "FrmSetting";
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel3.ResumeLayout(false);
      tableLayoutPanel10.ResumeLayout(false);
      tableLayoutPanel10.PerformLayout();
      tableLayoutPanel2.ResumeLayout(false);
      tableLayoutPanel4.ResumeLayout(false);
      tableLayoutPanel4.PerformLayout();
      tableLayoutPanel6.ResumeLayout(false);
      tableLayoutPanel5.ResumeLayout(false);
      tableLayoutPanel5.PerformLayout();
      tableLayoutPanel7.ResumeLayout(false);
      tableLayoutPanel7.PerformLayout();
      tableLayoutPanel8.ResumeLayout(false);
      tableLayoutPanel9.ResumeLayout(false);
      tableLayoutPanel9.PerformLayout();
      ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private TableLayoutPanel tableLayoutPanel4;
    private Label label2;
    private TableLayoutPanel tableLayoutPanel3;
    private TableLayoutPanel tableLayoutPanel10;
    private Label label1;
    private RJButton btnAddCommWeight;
    private FlowLayoutPanel flowCommWeight;
    private TableLayoutPanel tableLayoutPanel2;
    private TableLayoutPanel tableLayoutPanel6;
    private Common.Custom.RJButton btnConfirm;
    private TableLayoutPanel tableLayoutPanel5;
    private Label label3;
    private Label label4;
    private Common.Custom.RJTextBox rjTextBox2;
    private Common.Custom.RJTextBox rjTextBox1;
    private TableLayoutPanel tableLayoutPanel7;
    private TableLayoutPanel tableLayoutPanel8;
    private Common.Custom.RJButton btnSavePrint;
    private Label label5;
    private TableLayoutPanel tableLayoutPanel9;
    private Label label6;
    private ComboBox cbbPrint;
  }
}
