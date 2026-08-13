namespace LaborTrackPro.UserControls
{
  partial class UcSettingTare
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
      lbTitle = new Label();
      tableLayoutPanel1.SuspendLayout();
      SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.BackColor = Color.FromArgb(239, 242, 243);
      tableLayoutPanel1.ColumnCount = 1;
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.Controls.Add(lbTitle, 0, 0);
      tableLayoutPanel1.Dock = DockStyle.Fill;
      tableLayoutPanel1.Location = new Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 1;
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel1.Size = new Size(411, 160);
      tableLayoutPanel1.TabIndex = 1;
      // 
      // lbTitle
      // 
      lbTitle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      lbTitle.AutoSize = true;
      lbTitle.BackColor = Color.FromArgb(228, 148, 1);
      lbTitle.Font = new Font("Roboto", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
      lbTitle.ForeColor = Color.White;
      lbTitle.Location = new Point(0, 0);
      lbTitle.Margin = new Padding(0);
      lbTitle.Name = "lbTitle";
      lbTitle.Size = new Size(411, 160);
      lbTitle.TabIndex = 3;
      lbTitle.Text = "Name";
      lbTitle.TextAlign = ContentAlignment.MiddleCenter;
      // 
      // UcSettingTare
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      Controls.Add(tableLayoutPanel1);
      Name = "UcSettingTare";
      Size = new Size(411, 160);
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private Label lbTitle;
  }
}
