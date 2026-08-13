namespace LaborTrackPro
{
  partial class FrmConfirm
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
      tableLayoutPanel3 = new TableLayoutPanel();
      btnCancel = new LaborTrackPro.Custom.RJButton();
      btnConfirm = new LaborTrackPro.Custom.RJButton();
      tableLayoutPanel4 = new TableLayoutPanel();
      lbInformation = new Label();
      picIcon = new PictureBox();
      tableLayoutPanel1.SuspendLayout();
      tableLayoutPanel2.SuspendLayout();
      tableLayoutPanel3.SuspendLayout();
      tableLayoutPanel4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)picIcon).BeginInit();
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
      tableLayoutPanel1.Margin = new Padding(0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 3;
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 3F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 3F));
      tableLayoutPanel1.Size = new Size(938, 257);
      tableLayoutPanel1.TabIndex = 0;
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel2.BackColor = Color.FromArgb(248, 237, 224);
      tableLayoutPanel2.ColumnCount = 1;
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 2);
      tableLayoutPanel2.Controls.Add(tableLayoutPanel4, 0, 0);
      tableLayoutPanel2.Location = new Point(3, 3);
      tableLayoutPanel2.Margin = new Padding(0);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 4;
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 3F));
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 3F));
      tableLayoutPanel2.Size = new Size(932, 251);
      tableLayoutPanel2.TabIndex = 0;
      // 
      // tableLayoutPanel3
      // 
      tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel3.ColumnCount = 4;
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 3F));
      tableLayoutPanel3.Controls.Add(btnCancel, 2, 0);
      tableLayoutPanel3.Controls.Add(btnConfirm, 1, 0);
      tableLayoutPanel3.Location = new Point(0, 188);
      tableLayoutPanel3.Margin = new Padding(0);
      tableLayoutPanel3.Name = "tableLayoutPanel3";
      tableLayoutPanel3.RowCount = 1;
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel3.Size = new Size(932, 60);
      tableLayoutPanel3.TabIndex = 1;
      // 
      // btnCancel
      // 
      btnCancel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      btnCancel.BackColor = Color.Tomato;
      btnCancel.BackgroundColor = Color.Tomato;
      btnCancel.BorderColor = Color.PaleVioletRed;
      btnCancel.BorderRadius = 5;
      btnCancel.BorderSize = 0;
      btnCancel.FlatAppearance.BorderSize = 0;
      btnCancel.FlatStyle = FlatStyle.Flat;
      btnCancel.Font = new Font("Microsoft Sans Serif", 20.25F);
      btnCancel.ForeColor = Color.White;
      btnCancel.Location = new Point(732, 3);
      btnCancel.Name = "btnCancel";
      btnCancel.Size = new Size(194, 54);
      btnCancel.TabIndex = 8;
      btnCancel.Text = "Hủy";
      btnCancel.TextColor = Color.White;
      btnCancel.UseVisualStyleBackColor = false;
      btnCancel.Click += btnCancel_Click;
      // 
      // btnConfirm
      // 
      btnConfirm.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      btnConfirm.BackColor = Color.FromArgb(31, 130, 53);
      btnConfirm.BackgroundColor = Color.FromArgb(31, 130, 53);
      btnConfirm.BorderColor = Color.PaleVioletRed;
      btnConfirm.BorderRadius = 5;
      btnConfirm.BorderSize = 0;
      btnConfirm.FlatAppearance.BorderSize = 0;
      btnConfirm.FlatStyle = FlatStyle.Flat;
      btnConfirm.Font = new Font("Microsoft Sans Serif", 20.25F);
      btnConfirm.ForeColor = Color.White;
      btnConfirm.Location = new Point(532, 3);
      btnConfirm.Name = "btnConfirm";
      btnConfirm.Size = new Size(194, 54);
      btnConfirm.TabIndex = 7;
      btnConfirm.Text = "Xác nhận";
      btnConfirm.TextColor = Color.White;
      btnConfirm.UseVisualStyleBackColor = false;
      btnConfirm.Click += btnConfirm_Click;
      // 
      // tableLayoutPanel4
      // 
      tableLayoutPanel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel4.ColumnCount = 2;
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85F));
      tableLayoutPanel4.Controls.Add(lbInformation, 1, 0);
      tableLayoutPanel4.Controls.Add(picIcon, 0, 0);
      tableLayoutPanel4.Location = new Point(0, 0);
      tableLayoutPanel4.Margin = new Padding(0);
      tableLayoutPanel4.Name = "tableLayoutPanel4";
      tableLayoutPanel4.RowCount = 1;
      tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel4.Size = new Size(932, 185);
      tableLayoutPanel4.TabIndex = 2;
      // 
      // lbInformation
      // 
      lbInformation.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      lbInformation.AutoSize = true;
      lbInformation.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
      lbInformation.ForeColor = Color.Black;
      lbInformation.Location = new Point(142, 0);
      lbInformation.Name = "lbInformation";
      lbInformation.Size = new Size(787, 185);
      lbInformation.TabIndex = 11;
      lbInformation.Text = "...";
      lbInformation.TextAlign = ContentAlignment.MiddleCenter;
      // 
      // picIcon
      // 
      picIcon.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      picIcon.Location = new Point(10, 30);
      picIcon.Margin = new Padding(10, 30, 10, 30);
      picIcon.Name = "picIcon";
      picIcon.Size = new Size(119, 125);
      picIcon.SizeMode = PictureBoxSizeMode.StretchImage;
      picIcon.TabIndex = 12;
      picIcon.TabStop = false;
      // 
      // FrmConfirm
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = SystemColors.Control;
      ClientSize = new Size(938, 257);
      ControlBox = false;
      Controls.Add(tableLayoutPanel1);
      FormBorderStyle = FormBorderStyle.FixedSingle;
      Name = "FrmConfirm";
      StartPosition = FormStartPosition.CenterScreen;
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel2.ResumeLayout(false);
      tableLayoutPanel3.ResumeLayout(false);
      tableLayoutPanel4.ResumeLayout(false);
      tableLayoutPanel4.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)picIcon).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private TableLayoutPanel tableLayoutPanel2;
    private TableLayoutPanel tableLayoutPanel3;
    private Label lbInformation;
    private Custom.RJButton btnConfirm;
    private Custom.RJButton btnCancel;
    private TableLayoutPanel tableLayoutPanel4;
    private PictureBox picIcon;
  }
}