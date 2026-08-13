namespace LaborTrackPro.UserControls
{
  partial class UcPanelLogin
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      tableLayoutPanel1 = new TableLayoutPanel();
      label1 = new Label();
      tableLayoutPanel2 = new TableLayoutPanel();
      label2 = new Label();
      rjTextBox1 = new CustomControls.RJControls.RJTextBox();
      tableLayoutPanel3 = new TableLayoutPanel();
      label3 = new Label();
      rjTextBox2 = new CustomControls.RJControls.RJTextBox();
      btnLogin = new LaborTrackPro.Custom.RJButton();
      tableLayoutPanel1.SuspendLayout();
      tableLayoutPanel2.SuspendLayout();
      tableLayoutPanel3.SuspendLayout();
      SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.BackColor = Color.FromArgb(255, 204, 204);
      tableLayoutPanel1.ColumnCount = 3;
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
      tableLayoutPanel1.Controls.Add(label1, 1, 1);
      tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 3);
      tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 1, 5);
      tableLayoutPanel1.Controls.Add(btnLogin, 1, 7);
      tableLayoutPanel1.Dock = DockStyle.Fill;
      tableLayoutPanel1.Location = new Point(0, 0);
      tableLayoutPanel1.Margin = new Padding(0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 9;
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 110F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 110F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
      tableLayoutPanel1.Size = new Size(650, 530);
      tableLayoutPanel1.TabIndex = 0;
      // 
      // label1
      // 
      label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label1.AutoSize = true;
      label1.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
      label1.ForeColor = Color.Red;
      label1.Location = new Point(30, 30);
      label1.Margin = new Padding(0);
      label1.Name = "label1";
      label1.Size = new Size(590, 80);
      label1.TabIndex = 0;
      label1.Text = "ĐĂNG NHẬP";
      label1.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.ColumnCount = 1;
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.Controls.Add(label2, 0, 0);
      tableLayoutPanel2.Controls.Add(rjTextBox1, 0, 1);
      tableLayoutPanel2.Dock = DockStyle.Fill;
      tableLayoutPanel2.Location = new Point(30, 130);
      tableLayoutPanel2.Margin = new Padding(0);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 2;
      tableLayoutPanel2.RowStyles.Add(new RowStyle());
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.Size = new Size(590, 110);
      tableLayoutPanel2.TabIndex = 1;
      // 
      // label2
      // 
      label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label2.AutoSize = true;
      label2.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold);
      label2.ForeColor = Color.FromArgb(255, 56, 60);
      label2.Location = new Point(0, 0);
      label2.Margin = new Padding(0);
      label2.Name = "label2";
      label2.Size = new Size(590, 37);
      label2.TabIndex = 1;
      label2.Text = "Tên đăng nhập";
      label2.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // rjTextBox1
      // 
      rjTextBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      rjTextBox1.BackColor = SystemColors.Window;
      rjTextBox1.BorderColor = Color.White;
      rjTextBox1.BorderFocusColor = Color.HotPink;
      rjTextBox1.BorderRadius = 5;
      rjTextBox1.BorderSize = 2;
      rjTextBox1.Font = new Font("Microsoft Sans Serif", 26.25F);
      rjTextBox1.ForeColor = Color.FromArgb(64, 64, 64);
      rjTextBox1.Location = new Point(4, 46);
      rjTextBox1.Margin = new Padding(4);
      rjTextBox1.Multiline = false;
      rjTextBox1.Name = "rjTextBox1";
      rjTextBox1.Padding = new Padding(10, 7, 10, 7);
      rjTextBox1.PasswordChar = false;
      rjTextBox1.PlaceholderColor = Color.DarkGray;
      rjTextBox1.PlaceholderText = "";
      rjTextBox1.Size = new Size(582, 54);
      rjTextBox1.TabIndex = 2;
      rjTextBox1.Texts = "";
      rjTextBox1.UnderlinedStyle = false;
      // 
      // tableLayoutPanel3
      // 
      tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel3.ColumnCount = 1;
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel3.Controls.Add(label3, 0, 0);
      tableLayoutPanel3.Controls.Add(rjTextBox2, 0, 1);
      tableLayoutPanel3.Location = new Point(30, 255);
      tableLayoutPanel3.Margin = new Padding(0);
      tableLayoutPanel3.Name = "tableLayoutPanel3";
      tableLayoutPanel3.RowCount = 2;
      tableLayoutPanel3.RowStyles.Add(new RowStyle());
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel3.Size = new Size(590, 110);
      tableLayoutPanel3.TabIndex = 2;
      // 
      // label3
      // 
      label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label3.AutoSize = true;
      label3.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold);
      label3.ForeColor = Color.FromArgb(255, 56, 60);
      label3.Location = new Point(0, 0);
      label3.Margin = new Padding(0);
      label3.Name = "label3";
      label3.Size = new Size(590, 37);
      label3.TabIndex = 1;
      label3.Text = "Mật khẩu";
      label3.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // rjTextBox2
      // 
      rjTextBox2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      rjTextBox2.BackColor = SystemColors.Window;
      rjTextBox2.BorderColor = Color.White;
      rjTextBox2.BorderFocusColor = Color.HotPink;
      rjTextBox2.BorderRadius = 5;
      rjTextBox2.BorderSize = 2;
      rjTextBox2.Font = new Font("Microsoft Sans Serif", 26.25F);
      rjTextBox2.ForeColor = Color.FromArgb(64, 64, 64);
      rjTextBox2.Location = new Point(4, 46);
      rjTextBox2.Margin = new Padding(4);
      rjTextBox2.Multiline = false;
      rjTextBox2.Name = "rjTextBox2";
      rjTextBox2.Padding = new Padding(10, 7, 10, 7);
      rjTextBox2.PasswordChar = false;
      rjTextBox2.PlaceholderColor = Color.DarkGray;
      rjTextBox2.PlaceholderText = "";
      rjTextBox2.Size = new Size(582, 54);
      rjTextBox2.TabIndex = 2;
      rjTextBox2.Texts = "";
      rjTextBox2.UnderlinedStyle = false;
      // 
      // btnLogin
      // 
      btnLogin.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      btnLogin.BackColor = Color.Red;
      btnLogin.BackgroundColor = Color.Red;
      btnLogin.BorderColor = Color.PaleVioletRed;
      btnLogin.BorderRadius = 5;
      btnLogin.BorderSize = 0;
      btnLogin.FlatAppearance.BorderSize = 0;
      btnLogin.FlatStyle = FlatStyle.Flat;
      btnLogin.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
      btnLogin.ForeColor = Color.White;
      btnLogin.Location = new Point(33, 433);
      btnLogin.Name = "btnLogin";
      btnLogin.Size = new Size(584, 64);
      btnLogin.TabIndex = 3;
      btnLogin.Text = "ĐĂNG NHẬP";
      btnLogin.TextColor = Color.White;
      btnLogin.UseVisualStyleBackColor = false;
      btnLogin.Click += btnLogin_Click;
      // 
      // UcPanelLogin
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      Controls.Add(tableLayoutPanel1);
      Name = "UcPanelLogin";
      Size = new Size(650, 530);
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      tableLayoutPanel2.ResumeLayout(false);
      tableLayoutPanel2.PerformLayout();
      tableLayoutPanel3.ResumeLayout(false);
      tableLayoutPanel3.PerformLayout();
      ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private Label label1;
    private TableLayoutPanel tableLayoutPanel2;
    private Label label2;
    private CustomControls.RJControls.RJTextBox rjTextBox1;
    private TableLayoutPanel tableLayoutPanel3;
    private Label label3;
    private CustomControls.RJControls.RJTextBox rjTextBox2;
    private Custom.RJButton btnLogin;
  }
}
