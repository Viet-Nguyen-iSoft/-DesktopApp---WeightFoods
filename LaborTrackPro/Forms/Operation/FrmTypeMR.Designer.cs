namespace LaborTrackPro.Forms.Operation
{
  partial class FrmTypeMR
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
      tableLayoutPanel2 = new TableLayoutPanel();
      itemSemiFgs = new LaborTrackPro.UserControls.UcItemMode();
      itemMaterial = new LaborTrackPro.UserControls.UcItemMode();
      itemFGs = new LaborTrackPro.UserControls.UcItemMode();
      itemMaterialRaw = new LaborTrackPro.UserControls.UcItemMode();
      tableLayoutPanel1.SuspendLayout();
      tableLayoutPanel2.SuspendLayout();
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
      tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 3);
      tableLayoutPanel1.Dock = DockStyle.Fill;
      tableLayoutPanel1.Location = new Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 5;
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 85F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
      tableLayoutPanel1.Size = new Size(1338, 901);
      tableLayoutPanel1.TabIndex = 3;
      // 
      // ucTitleFrm
      // 
      ucTitleFrm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      ucTitleFrm.Location = new Point(15, 15);
      ucTitleFrm.Margin = new Padding(0);
      ucTitleFrm.Name = "ucTitleFrm";
      ucTitleFrm.Size = new Size(1308, 85);
      ucTitleFrm.TabIndex = 2;
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel2.ColumnCount = 9;
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 450F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 450F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 450F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 450F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
      tableLayoutPanel2.Controls.Add(itemSemiFgs, 5, 1);
      tableLayoutPanel2.Controls.Add(itemMaterial, 3, 1);
      tableLayoutPanel2.Controls.Add(itemFGs, 7, 1);
      tableLayoutPanel2.Controls.Add(itemMaterialRaw, 1, 1);
      tableLayoutPanel2.Location = new Point(15, 180);
      tableLayoutPanel2.Margin = new Padding(0);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 3;
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 600F));
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
      tableLayoutPanel2.Size = new Size(1308, 640);
      tableLayoutPanel2.TabIndex = 3;
      // 
      // itemSemiFgs
      // 
      itemSemiFgs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      itemSemiFgs.Connected = false;
      itemSemiFgs.Location = new Point(672, 23);
      itemSemiFgs.Name = "itemSemiFgs";
      itemSemiFgs.Size = new Size(444, 594);
      itemSemiFgs.TabIndex = 4;
      // 
      // itemMaterial
      // 
      itemMaterial.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      itemMaterial.Connected = false;
      itemMaterial.Location = new Point(192, 23);
      itemMaterial.Name = "itemMaterial";
      itemMaterial.Size = new Size(444, 594);
      itemMaterial.TabIndex = 1;
      // 
      // itemFGs
      // 
      itemFGs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      itemFGs.Connected = false;
      itemFGs.Location = new Point(1152, 23);
      itemFGs.Name = "itemFGs";
      itemFGs.Size = new Size(444, 594);
      itemFGs.TabIndex = 2;
      // 
      // itemMaterialRaw
      // 
      itemMaterialRaw.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      itemMaterialRaw.Connected = false;
      itemMaterialRaw.Location = new Point(-288, 23);
      itemMaterialRaw.Name = "itemMaterialRaw";
      itemMaterialRaw.Size = new Size(444, 594);
      itemMaterialRaw.TabIndex = 0;
      // 
      // FrmTypeMR
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(1338, 901);
      Controls.Add(tableLayoutPanel1);
      Name = "FrmTypeMR";
      Text = "FrmTypeMR";
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel2.ResumeLayout(false);
      ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private UserControls.UcTitleFrm ucTitleFrm;
    private TableLayoutPanel tableLayoutPanel2;
    private UserControls.UcItemMode itemMaterialRaw;
    private UserControls.UcItemMode itemMaterial;
    private UserControls.UcItemMode itemFGs;
    private UserControls.UcItemMode itemSemiFgs;
  }
}