namespace LaborTrackPro.Forms
{
  partial class FrmOpModePO
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
      ucTitleFrm = new LaborTrackPro.UserControls.UcTitleFrm();
      flowLayoutPanel = new FlowLayoutPanel();
      tableLayoutPanel1.SuspendLayout();
      SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.BackColor = Color.White;
      tableLayoutPanel1.ColumnCount = 3;
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 15F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 15F));
      tableLayoutPanel1.Controls.Add(ucTitleFrm, 1, 1);
      tableLayoutPanel1.Controls.Add(flowLayoutPanel, 1, 3);
      tableLayoutPanel1.Dock = DockStyle.Fill;
      tableLayoutPanel1.Location = new Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 5;
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 85F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
      tableLayoutPanel1.Size = new Size(1022, 543);
      tableLayoutPanel1.TabIndex = 1;
      // 
      // ucTitleFrm
      // 
      ucTitleFrm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      ucTitleFrm.Location = new Point(15, 15);
      ucTitleFrm.Margin = new Padding(0);
      ucTitleFrm.Name = "ucTitleFrm";
      ucTitleFrm.Size = new Size(992, 85);
      ucTitleFrm.TabIndex = 2;
      // 
      // flowLayoutPanel
      // 
      flowLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      flowLayoutPanel.Location = new Point(15, 144);
      flowLayoutPanel.Margin = new Padding(0);
      flowLayoutPanel.Name = "flowLayoutPanel";
      flowLayoutPanel.Size = new Size(992, 354);
      flowLayoutPanel.TabIndex = 3;
      // 
      // FrmOpModePO
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(1022, 543);
      Controls.Add(tableLayoutPanel1);
      Name = "FrmOpModePO";
      Text = "FrmModeOrderProduction";
      tableLayoutPanel1.ResumeLayout(false);
      ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private UserControls.UcTitleFrm ucTitleFrm;
    private FlowLayoutPanel flowLayoutPanel;
  }
}