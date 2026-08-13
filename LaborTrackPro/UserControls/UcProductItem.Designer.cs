namespace LaborTrackPro.UserControls
{
  partial class UcProductItem
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
      tableLayoutPanel2 = new TableLayoutPanel();
      lbName = new Label();
      tableLayoutPanel3 = new TableLayoutPanel();
      lbCode = new Label();
      tableLayoutPanel1.SuspendLayout();
      tableLayoutPanel2.SuspendLayout();
      tableLayoutPanel3.SuspendLayout();
      SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.BackColor = Color.Red;
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
      tableLayoutPanel1.Size = new Size(381, 267);
      tableLayoutPanel1.TabIndex = 0;
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel2.BackColor = Color.FromArgb(224, 224, 224);
      tableLayoutPanel2.ColumnCount = 1;
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 1);
      tableLayoutPanel2.Controls.Add(lbName, 0, 0);
      tableLayoutPanel2.Location = new Point(3, 3);
      tableLayoutPanel2.Margin = new Padding(0);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 2;
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.RowStyles.Add(new RowStyle());
      tableLayoutPanel2.Size = new Size(375, 261);
      tableLayoutPanel2.TabIndex = 1;
      // 
      // lbName
      // 
      lbName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      lbName.AutoSize = true;
      lbName.BackColor = Color.FromArgb(224, 224, 224);
      lbName.Font = new Font("Times New Roman", 28F);
      lbName.ForeColor = Color.Black;
      lbName.Location = new Point(0, 0);
      lbName.Margin = new Padding(0);
      lbName.Name = "lbName";
      lbName.Size = new Size(375, 198);
      lbName.TabIndex = 16;
      lbName.Text = "...";
      lbName.TextAlign = ContentAlignment.MiddleCenter;
      // 
      // tableLayoutPanel3
      // 
      tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel3.ColumnCount = 1;
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
      tableLayoutPanel3.Controls.Add(lbCode, 0, 0);
      tableLayoutPanel3.Location = new Point(0, 198);
      tableLayoutPanel3.Margin = new Padding(0);
      tableLayoutPanel3.Name = "tableLayoutPanel3";
      tableLayoutPanel3.RowCount = 1;
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
      tableLayoutPanel3.Size = new Size(375, 63);
      tableLayoutPanel3.TabIndex = 19;
      // 
      // lbCode
      // 
      lbCode.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      lbCode.AutoSize = true;
      lbCode.BackColor = Color.DimGray;
      lbCode.Font = new Font("Times New Roman", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
      lbCode.ForeColor = Color.White;
      lbCode.Location = new Point(0, 0);
      lbCode.Margin = new Padding(0);
      lbCode.Name = "lbCode";
      lbCode.Size = new Size(375, 63);
      lbCode.TabIndex = 17;
      lbCode.Text = "...";
      lbCode.TextAlign = ContentAlignment.MiddleCenter;
      // 
      // UcProductItem
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      Controls.Add(tableLayoutPanel1);
      Name = "UcProductItem";
      Size = new Size(381, 267);
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel2.ResumeLayout(false);
      tableLayoutPanel2.PerformLayout();
      tableLayoutPanel3.ResumeLayout(false);
      tableLayoutPanel3.PerformLayout();
      ResumeLayout(false);
    }

    #endregion
    private Custom.ElipseControl elipseControl1;
    private TableLayoutPanel tableLayoutPanel1;
    private TableLayoutPanel tableLayoutPanel2;
    private Label lbName;
    private TableLayoutPanel tableLayoutPanel3;
    private Label lbCode;
  }
}
