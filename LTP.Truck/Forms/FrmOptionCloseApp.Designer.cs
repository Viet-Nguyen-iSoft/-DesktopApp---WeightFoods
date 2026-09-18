namespace LTP.Truck.Forms
{
  partial class FrmOptionCloseApp
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
      btnMini = new Common.Custom.RJButton();
      btnRestartApp = new Common.Custom.RJButton();
      btnClose = new Common.Custom.RJButton();
      btnBack = new Common.Custom.RJButton();
      btnCheckVersion = new Common.Custom.RJButton();
      tableLayoutPanel1.SuspendLayout();
      SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.ColumnCount = 3;
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
      tableLayoutPanel1.Controls.Add(btnMini, 1, 1);
      tableLayoutPanel1.Controls.Add(btnRestartApp, 1, 3);
      tableLayoutPanel1.Controls.Add(btnClose, 1, 5);
      tableLayoutPanel1.Controls.Add(btnBack, 1, 7);
      tableLayoutPanel1.Controls.Add(btnCheckVersion, 1, 9);
      tableLayoutPanel1.Dock = DockStyle.Fill;
      tableLayoutPanel1.Location = new Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 11;
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel1.Size = new Size(450, 517);
      tableLayoutPanel1.TabIndex = 0;
      // 
      // btnMini
      // 
      btnMini.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      btnMini.BackColor = Color.FromArgb(49, 68, 108);
      btnMini.BackgroundColor = Color.FromArgb(49, 68, 108);
      btnMini.BorderColor = Color.PaleVioletRed;
      btnMini.BorderRadius = 5;
      btnMini.BorderSize = 0;
      btnMini.FlatAppearance.BorderSize = 0;
      btnMini.FlatStyle = FlatStyle.Flat;
      btnMini.Font = new Font("Roboto", 15.75F, FontStyle.Bold);
      btnMini.ForeColor = Color.White;
      btnMini.Location = new Point(23, 23);
      btnMini.Name = "btnMini";
      btnMini.Size = new Size(404, 73);
      btnMini.TabIndex = 0;
      btnMini.Text = "Thu nhỏ màn hình";
      btnMini.TextColor = Color.White;
      btnMini.UseVisualStyleBackColor = false;
      // 
      // btnRestartApp
      // 
      btnRestartApp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      btnRestartApp.BackColor = Color.FromArgb(49, 68, 108);
      btnRestartApp.BackgroundColor = Color.FromArgb(49, 68, 108);
      btnRestartApp.BorderColor = Color.PaleVioletRed;
      btnRestartApp.BorderRadius = 5;
      btnRestartApp.BorderSize = 0;
      btnRestartApp.FlatAppearance.BorderSize = 0;
      btnRestartApp.FlatStyle = FlatStyle.Flat;
      btnRestartApp.Font = new Font("Roboto", 15.75F, FontStyle.Bold);
      btnRestartApp.ForeColor = Color.White;
      btnRestartApp.Location = new Point(23, 122);
      btnRestartApp.Name = "btnRestartApp";
      btnRestartApp.Size = new Size(404, 73);
      btnRestartApp.TabIndex = 1;
      btnRestartApp.Text = "Khởi động lại";
      btnRestartApp.TextColor = Color.White;
      btnRestartApp.UseVisualStyleBackColor = false;
      // 
      // btnClose
      // 
      btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      btnClose.BackColor = Color.FromArgb(49, 68, 108);
      btnClose.BackgroundColor = Color.FromArgb(49, 68, 108);
      btnClose.BorderColor = Color.PaleVioletRed;
      btnClose.BorderRadius = 5;
      btnClose.BorderSize = 0;
      btnClose.FlatAppearance.BorderSize = 0;
      btnClose.FlatStyle = FlatStyle.Flat;
      btnClose.Font = new Font("Roboto", 15.75F, FontStyle.Bold);
      btnClose.ForeColor = Color.White;
      btnClose.Location = new Point(23, 221);
      btnClose.Name = "btnClose";
      btnClose.Size = new Size(404, 73);
      btnClose.TabIndex = 2;
      btnClose.Text = "Đóng chương trình";
      btnClose.TextColor = Color.White;
      btnClose.UseVisualStyleBackColor = false;
      // 
      // btnBack
      // 
      btnBack.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      btnBack.BackColor = Color.FromArgb(49, 68, 108);
      btnBack.BackgroundColor = Color.FromArgb(49, 68, 108);
      btnBack.BorderColor = Color.PaleVioletRed;
      btnBack.BorderRadius = 5;
      btnBack.BorderSize = 0;
      btnBack.FlatAppearance.BorderSize = 0;
      btnBack.FlatStyle = FlatStyle.Flat;
      btnBack.Font = new Font("Roboto", 15.75F, FontStyle.Bold);
      btnBack.ForeColor = Color.White;
      btnBack.Location = new Point(23, 320);
      btnBack.Name = "btnBack";
      btnBack.Size = new Size(404, 73);
      btnBack.TabIndex = 3;
      btnBack.Text = "Quay lại";
      btnBack.TextColor = Color.White;
      btnBack.UseVisualStyleBackColor = false;
      // 
      // btnCheckVersion
      // 
      btnCheckVersion.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      btnCheckVersion.BackColor = Color.FromArgb(49, 68, 108);
      btnCheckVersion.BackgroundColor = Color.FromArgb(49, 68, 108);
      btnCheckVersion.BorderColor = Color.PaleVioletRed;
      btnCheckVersion.BorderRadius = 5;
      btnCheckVersion.BorderSize = 0;
      btnCheckVersion.FlatAppearance.BorderSize = 0;
      btnCheckVersion.FlatStyle = FlatStyle.Flat;
      btnCheckVersion.Font = new Font("Roboto", 15.75F, FontStyle.Bold);
      btnCheckVersion.ForeColor = Color.White;
      btnCheckVersion.Location = new Point(23, 419);
      btnCheckVersion.Name = "btnCheckVersion";
      btnCheckVersion.Size = new Size(404, 73);
      btnCheckVersion.TabIndex = 4;
      btnCheckVersion.Text = "Kiểm tra bản cập nhật";
      btnCheckVersion.TextColor = Color.White;
      btnCheckVersion.UseVisualStyleBackColor = false;
      // 
      // FrmOptionCloseApp
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(450, 517);
      ControlBox = false;
      Controls.Add(tableLayoutPanel1);
      Name = "FrmOptionCloseApp";
      StartPosition = FormStartPosition.CenterParent;
      tableLayoutPanel1.ResumeLayout(false);
      ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private Common.Custom.RJButton btnMini;
    private Common.Custom.RJButton btnRestartApp;
    private Common.Custom.RJButton btnClose;
    private Common.Custom.RJButton btnBack;
    private Common.Custom.RJButton btnCheckVersion;
  }
}