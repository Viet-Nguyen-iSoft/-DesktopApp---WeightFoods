namespace LaborTrackPro.Forms
{
  partial class FrmPageOperation
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
      ucFooter = new LaborTrackPro.UserControls.UcFooter();
      ucHeader = new LaborTrackPro.UserControls.UcHeader();
      panelMain = new Panel();
      tableLayoutPanel1.SuspendLayout();
      SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.ColumnCount = 1;
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.Controls.Add(ucFooter, 0, 2);
      tableLayoutPanel1.Controls.Add(ucHeader, 0, 0);
      tableLayoutPanel1.Controls.Add(panelMain, 0, 1);
      tableLayoutPanel1.Dock = DockStyle.Fill;
      tableLayoutPanel1.Location = new Point(0, 0);
      tableLayoutPanel1.Margin = new Padding(0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 3;
      tableLayoutPanel1.RowStyles.Add(new RowStyle());
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 99.99999F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle());
      tableLayoutPanel1.Size = new Size(1267, 631);
      tableLayoutPanel1.TabIndex = 0;
      // 
      // ucFooter
      // 
      ucFooter.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      ucFooter.Location = new Point(0, 577);
      ucFooter.Margin = new Padding(0);
      ucFooter.Name = "ucFooter";
      ucFooter.Size = new Size(1267, 54);
      ucFooter.TabIndex = 0;
      // 
      // ucHeader
      // 
      ucHeader.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      ucHeader.Location = new Point(0, 0);
      ucHeader.Margin = new Padding(0);
      ucHeader.Name = "ucHeader";
      ucHeader.Size = new Size(1267, 111);
      ucHeader.TabIndex = 1;
      // 
      // panelMain
      // 
      panelMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      panelMain.Location = new Point(0, 111);
      panelMain.Margin = new Padding(0);
      panelMain.Name = "panelMain";
      panelMain.Size = new Size(1267, 466);
      panelMain.TabIndex = 2;
      // 
      // FrmPageOperation
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(1267, 631);
      Controls.Add(tableLayoutPanel1);
      Name = "FrmPageOperation";
      Text = "FrmBackground";
      tableLayoutPanel1.ResumeLayout(false);
      ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private UserControls.UcFooter ucFooter;
    private UserControls.UcHeader ucHeader;
    private Panel panelMain;
  }
}