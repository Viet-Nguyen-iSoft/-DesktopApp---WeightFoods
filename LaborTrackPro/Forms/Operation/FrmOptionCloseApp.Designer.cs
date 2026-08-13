namespace LaborTrackPro
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
      tableLayoutPanel2 = new TableLayoutPanel();
      btnBack = new LaborTrackPro.Custom.RJButton();
      btnClose = new LaborTrackPro.Custom.RJButton();
      btnRestartApp = new LaborTrackPro.Custom.RJButton();
      btnMini = new LaborTrackPro.Custom.RJButton();
      btnCheckVersion = new LaborTrackPro.Custom.RJButton();
      tableLayoutPanel1.SuspendLayout();
      tableLayoutPanel2.SuspendLayout();
      SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.BackColor = Color.FromArgb(49, 68, 108);
      tableLayoutPanel1.ColumnCount = 3;
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 3F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 3F));
      tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 1);
      tableLayoutPanel1.Dock = DockStyle.Fill;
      tableLayoutPanel1.Location = new Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 3;
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 3F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 3F));
      tableLayoutPanel1.Size = new Size(570, 500);
      tableLayoutPanel1.TabIndex = 1;
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel2.BackColor = Color.LightSteelBlue;
      tableLayoutPanel2.ColumnCount = 3;
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
      tableLayoutPanel2.Controls.Add(btnBack, 1, 7);
      tableLayoutPanel2.Controls.Add(btnClose, 1, 5);
      tableLayoutPanel2.Controls.Add(btnRestartApp, 1, 3);
      tableLayoutPanel2.Controls.Add(btnMini, 1, 1);
      tableLayoutPanel2.Controls.Add(btnCheckVersion, 1, 9);
      tableLayoutPanel2.Location = new Point(3, 3);
      tableLayoutPanel2.Margin = new Padding(0);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 11;
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel2.Size = new Size(564, 494);
      tableLayoutPanel2.TabIndex = 0;
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
      btnBack.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold);
      btnBack.ForeColor = Color.White;
      btnBack.Location = new Point(33, 299);
      btnBack.Name = "btnBack";
      btnBack.Size = new Size(498, 76);
      btnBack.TabIndex = 9;
      btnBack.Text = "Quay lại";
      btnBack.TextColor = Color.White;
      btnBack.UseVisualStyleBackColor = false;
      btnBack.Click += btnBack_Click;
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
      btnClose.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold);
      btnClose.ForeColor = Color.White;
      btnClose.Location = new Point(33, 207);
      btnClose.Name = "btnClose";
      btnClose.Size = new Size(498, 76);
      btnClose.TabIndex = 8;
      btnClose.Text = "Đóng chương trình";
      btnClose.TextColor = Color.White;
      btnClose.UseVisualStyleBackColor = false;
      btnClose.Click += btnClose_Click;
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
      btnRestartApp.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold);
      btnRestartApp.ForeColor = Color.White;
      btnRestartApp.Location = new Point(33, 115);
      btnRestartApp.Name = "btnRestartApp";
      btnRestartApp.Size = new Size(498, 76);
      btnRestartApp.TabIndex = 7;
      btnRestartApp.Text = "Khởi động lại";
      btnRestartApp.TextColor = Color.White;
      btnRestartApp.UseVisualStyleBackColor = false;
      btnRestartApp.Click += btnRestartApp_Click;
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
      btnMini.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold);
      btnMini.ForeColor = Color.White;
      btnMini.Location = new Point(33, 23);
      btnMini.Name = "btnMini";
      btnMini.Size = new Size(498, 76);
      btnMini.TabIndex = 10;
      btnMini.Text = "Thu nhỏ màn hình";
      btnMini.TextColor = Color.White;
      btnMini.UseVisualStyleBackColor = false;
      btnMini.Click += btnMini_Click;
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
      btnCheckVersion.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold);
      btnCheckVersion.ForeColor = Color.White;
      btnCheckVersion.Location = new Point(33, 391);
      btnCheckVersion.Name = "btnCheckVersion";
      btnCheckVersion.Size = new Size(498, 76);
      btnCheckVersion.TabIndex = 11;
      btnCheckVersion.Text = "Kiểm tra bản cập nhật";
      btnCheckVersion.TextColor = Color.White;
      btnCheckVersion.UseVisualStyleBackColor = false;
      btnCheckVersion.Click += btnCheckVersion_Click;
      // 
      // FrmOptionCloseApp
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(570, 500);
      Controls.Add(tableLayoutPanel1);
      FormBorderStyle = FormBorderStyle.None;
      Name = "FrmOptionCloseApp";
      StartPosition = FormStartPosition.CenterParent;
      Text = "FrmOptionCloseApp";
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel2.ResumeLayout(false);
      ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private TableLayoutPanel tableLayoutPanel2;
    private Custom.RJButton btnClose;
    private Custom.RJButton btnRestartApp;
    private Custom.RJButton btnBack;
    private Custom.RJButton btnMini;
    private Custom.RJButton btnCheckVersion;
  }
}