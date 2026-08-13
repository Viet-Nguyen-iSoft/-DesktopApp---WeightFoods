namespace LaborTrackPro.Forms.Operation
{
  partial class FrmScanRfidDelivery
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmScanRfidDelivery));
      tableLayoutPanel1 = new TableLayoutPanel();
      tableLayoutPanel2 = new TableLayoutPanel();
      tableLayoutPanel3 = new TableLayoutPanel();
      ucIdCard = new LaborTrackPro.UserControls.UcIdCard();
      pictureBox1 = new PictureBox();
      btnNext = new LaborTrackPro.Custom.RJButton();
      ucTitleFrm = new LaborTrackPro.UserControls.UcTitleFrm();
      tableLayoutPanel1.SuspendLayout();
      tableLayoutPanel2.SuspendLayout();
      tableLayoutPanel3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
      SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.BackColor = Color.White;
      tableLayoutPanel1.ColumnCount = 3;
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 15F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 15F));
      tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 2);
      tableLayoutPanel1.Controls.Add(btnNext, 1, 3);
      tableLayoutPanel1.Controls.Add(ucTitleFrm, 1, 1);
      tableLayoutPanel1.Dock = DockStyle.Fill;
      tableLayoutPanel1.Location = new Point(0, 0);
      tableLayoutPanel1.Margin = new Padding(0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 5;
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 85F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
      tableLayoutPanel1.Size = new Size(1265, 723);
      tableLayoutPanel1.TabIndex = 1;
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel2.BackColor = Color.White;
      tableLayoutPanel2.ColumnCount = 5;
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
      tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 3, 0);
      tableLayoutPanel2.Controls.Add(pictureBox1, 1, 0);
      tableLayoutPanel2.Location = new Point(15, 100);
      tableLayoutPanel2.Margin = new Padding(0);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 1;
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.Size = new Size(1235, 548);
      tableLayoutPanel2.TabIndex = 0;
      // 
      // tableLayoutPanel3
      // 
      tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel3.ColumnCount = 1;
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel3.Controls.Add(ucIdCard, 0, 1);
      tableLayoutPanel3.Location = new Point(642, 0);
      tableLayoutPanel3.Margin = new Padding(0);
      tableLayoutPanel3.Name = "tableLayoutPanel3";
      tableLayoutPanel3.RowCount = 3;
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 17F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 66F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 17F));
      tableLayoutPanel3.Size = new Size(442, 548);
      tableLayoutPanel3.TabIndex = 1;
      // 
      // ucIdCard
      // 
      ucIdCard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      ucIdCard.Location = new Point(3, 96);
      ucIdCard.Name = "ucIdCard";
      ucIdCard.Size = new Size(436, 355);
      ucIdCard.TabIndex = 0;
      // 
      // pictureBox1
      // 
      pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
      pictureBox1.Location = new Point(150, 0);
      pictureBox1.Margin = new Padding(0);
      pictureBox1.Name = "pictureBox1";
      pictureBox1.Size = new Size(442, 548);
      pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      pictureBox1.TabIndex = 2;
      pictureBox1.TabStop = false;
      // 
      // btnNext
      // 
      btnNext.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      btnNext.BackColor = Color.Gray;
      btnNext.BackgroundColor = Color.Gray;
      btnNext.BorderColor = Color.PaleVioletRed;
      btnNext.BorderRadius = 5;
      btnNext.BorderSize = 0;
      btnNext.Enabled = false;
      btnNext.FlatAppearance.BorderSize = 0;
      btnNext.FlatStyle = FlatStyle.Flat;
      btnNext.Font = new Font("Microsoft Sans Serif", 20.25F);
      btnNext.ForeColor = Color.White;
      btnNext.Location = new Point(1048, 648);
      btnNext.Margin = new Padding(0);
      btnNext.Name = "btnNext";
      btnNext.Size = new Size(202, 60);
      btnNext.TabIndex = 10;
      btnNext.Text = "Tiếp theo";
      btnNext.TextColor = Color.White;
      btnNext.UseVisualStyleBackColor = false;
      btnNext.Click += btnNext_Click;
      // 
      // ucTitleFrm
      // 
      ucTitleFrm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      ucTitleFrm.Location = new Point(15, 15);
      ucTitleFrm.Margin = new Padding(0);
      ucTitleFrm.Name = "ucTitleFrm";
      ucTitleFrm.Size = new Size(1235, 85);
      ucTitleFrm.TabIndex = 11;
      // 
      // FrmScanRfidDelivery
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(1265, 723);
      Controls.Add(tableLayoutPanel1);
      Name = "FrmScanRfidDelivery";
      Text = "FrmScanRfidDelivery";
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel2.ResumeLayout(false);
      tableLayoutPanel3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private TableLayoutPanel tableLayoutPanel2;
    private TableLayoutPanel tableLayoutPanel3;
    private UserControls.UcIdCard ucIdCard;
    private PictureBox pictureBox1;
    private Custom.RJButton btnNext;
    private UserControls.UcTitleFrm ucTitleFrm;
  }
}