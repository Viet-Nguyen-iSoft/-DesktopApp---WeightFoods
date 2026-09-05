namespace LaborTrackPro.Forms
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
      tableLayoutPanel1 = new TableLayoutPanel();
      tableLayoutPanel2 = new TableLayoutPanel();
      tableLayoutPanel3 = new TableLayoutPanel();
      tableLayoutPanel10 = new TableLayoutPanel();
      label1 = new Label();
      btnAddCommWeight = new LaborTrackPro.Custom.RJButton();
      tableLayoutPanel1.SuspendLayout();
      tableLayoutPanel2.SuspendLayout();
      tableLayoutPanel3.SuspendLayout();
      tableLayoutPanel10.SuspendLayout();
      SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.BackColor = Color.White;
      tableLayoutPanel1.ColumnCount = 2;
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 5F));
      tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
      tableLayoutPanel1.Dock = DockStyle.Fill;
      tableLayoutPanel1.Location = new Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 4;
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 5F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 5F));
      tableLayoutPanel1.Size = new Size(1198, 733);
      tableLayoutPanel1.TabIndex = 1;
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel2.ColumnCount = 3;
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 5F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
      tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 0);
      tableLayoutPanel2.Location = new Point(0, 0);
      tableLayoutPanel2.Margin = new Padding(0);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 1;
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.Size = new Size(1193, 361);
      tableLayoutPanel2.TabIndex = 0;
      // 
      // tableLayoutPanel3
      // 
      tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel3.BackColor = Color.FromArgb(236, 236, 236);
      tableLayoutPanel3.ColumnCount = 1;
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel3.Controls.Add(tableLayoutPanel10, 0, 0);
      tableLayoutPanel3.Location = new Point(0, 0);
      tableLayoutPanel3.Margin = new Padding(0);
      tableLayoutPanel3.Name = "tableLayoutPanel3";
      tableLayoutPanel3.RowCount = 2;
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel3.Size = new Size(594, 361);
      tableLayoutPanel3.TabIndex = 0;
      // 
      // tableLayoutPanel10
      // 
      tableLayoutPanel10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel10.BackColor = Color.FromArgb(199, 199, 199);
      tableLayoutPanel10.ColumnCount = 2;
      tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
      tableLayoutPanel10.Controls.Add(label1, 0, 0);
      tableLayoutPanel10.Controls.Add(btnAddCommWeight, 1, 0);
      tableLayoutPanel10.Location = new Point(0, 0);
      tableLayoutPanel10.Margin = new Padding(0);
      tableLayoutPanel10.Name = "tableLayoutPanel10";
      tableLayoutPanel10.RowCount = 1;
      tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel10.Size = new Size(594, 60);
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
      label1.Size = new Size(394, 60);
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
      btnAddCommWeight.Image = Properties.Resources.icon_add_white;
      btnAddCommWeight.ImageAlign = ContentAlignment.MiddleLeft;
      btnAddCommWeight.Location = new Point(397, 3);
      btnAddCommWeight.Name = "btnAddCommWeight";
      btnAddCommWeight.Padding = new Padding(10, 0, 0, 0);
      btnAddCommWeight.Size = new Size(194, 54);
      btnAddCommWeight.TabIndex = 0;
      btnAddCommWeight.Text = "        Thêm kết nối";
      btnAddCommWeight.TextAlign = ContentAlignment.MiddleLeft;
      btnAddCommWeight.TextColor = Color.White;
      btnAddCommWeight.UseVisualStyleBackColor = false;
      btnAddCommWeight.Click += btnAddCommWeight_Click;
      // 
      // FrmSetting
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(1198, 733);
      Controls.Add(tableLayoutPanel1);
      Name = "FrmSetting";
      Text = "FrmSetting";
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel2.ResumeLayout(false);
      tableLayoutPanel3.ResumeLayout(false);
      tableLayoutPanel10.ResumeLayout(false);
      tableLayoutPanel10.PerformLayout();
      ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private TableLayoutPanel tableLayoutPanel2;
    private TableLayoutPanel tableLayoutPanel3;
    private Label label1;
    private TableLayoutPanel tableLayoutPanel10;
    private Custom.RJButton btnAddCommWeight;
  }
}