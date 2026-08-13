namespace LaborTrackPro.Forms.Operation
{
  partial class PopupScanRfid
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopupScanRfid));
      tableLayoutPanel1 = new TableLayoutPanel();
      tableLayoutPanel2 = new TableLayoutPanel();
      tableLayoutPanel3 = new TableLayoutPanel();
      ucIdCard = new LaborTrackPro.UserControls.UcIdCard();
      pictureBox1 = new PictureBox();
      ucTitleFrm = new LaborTrackPro.UserControls.UcTitleFrm();
      tableLayoutPanel4 = new TableLayoutPanel();
      btnConfirm = new LaborTrackPro.Custom.RJButton();
      btnCancel = new LaborTrackPro.Custom.RJButton();
      tableLayoutPanel1.SuspendLayout();
      tableLayoutPanel2.SuspendLayout();
      tableLayoutPanel3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
      tableLayoutPanel4.SuspendLayout();
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
      tableLayoutPanel1.Controls.Add(ucTitleFrm, 1, 1);
      tableLayoutPanel1.Controls.Add(tableLayoutPanel4, 1, 3);
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
      tableLayoutPanel1.Size = new Size(1615, 905);
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
      tableLayoutPanel2.Size = new Size(1585, 730);
      tableLayoutPanel2.TabIndex = 0;
      // 
      // tableLayoutPanel3
      // 
      tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel3.ColumnCount = 1;
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel3.Controls.Add(ucIdCard, 0, 1);
      tableLayoutPanel3.Location = new Point(817, 0);
      tableLayoutPanel3.Margin = new Padding(0);
      tableLayoutPanel3.Name = "tableLayoutPanel3";
      tableLayoutPanel3.RowCount = 3;
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 17F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 66F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 17F));
      tableLayoutPanel3.Size = new Size(617, 730);
      tableLayoutPanel3.TabIndex = 1;
      // 
      // ucIdCard
      // 
      ucIdCard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      ucIdCard.Location = new Point(3, 127);
      ucIdCard.Name = "ucIdCard";
      ucIdCard.Size = new Size(611, 475);
      ucIdCard.TabIndex = 0;
      // 
      // pictureBox1
      // 
      pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
      pictureBox1.Location = new Point(150, 0);
      pictureBox1.Margin = new Padding(0);
      pictureBox1.Name = "pictureBox1";
      pictureBox1.Size = new Size(617, 730);
      pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      pictureBox1.TabIndex = 2;
      pictureBox1.TabStop = false;
      // 
      // ucTitleFrm
      // 
      ucTitleFrm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      ucTitleFrm.Location = new Point(15, 15);
      ucTitleFrm.Margin = new Padding(0);
      ucTitleFrm.Name = "ucTitleFrm";
      ucTitleFrm.Size = new Size(1585, 85);
      ucTitleFrm.TabIndex = 11;
      // 
      // tableLayoutPanel4
      // 
      tableLayoutPanel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel4.ColumnCount = 4;
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 5F));
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
      tableLayoutPanel4.Controls.Add(btnConfirm, 1, 0);
      tableLayoutPanel4.Controls.Add(btnCancel, 3, 0);
      tableLayoutPanel4.Location = new Point(15, 830);
      tableLayoutPanel4.Margin = new Padding(0);
      tableLayoutPanel4.Name = "tableLayoutPanel4";
      tableLayoutPanel4.RowCount = 1;
      tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel4.Size = new Size(1585, 60);
      tableLayoutPanel4.TabIndex = 12;
      // 
      // btnConfirm
      // 
      btnConfirm.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      btnConfirm.BackColor = Color.FromArgb(49, 68, 108);
      btnConfirm.BackgroundColor = Color.FromArgb(49, 68, 108);
      btnConfirm.BorderColor = Color.PaleVioletRed;
      btnConfirm.BorderRadius = 5;
      btnConfirm.BorderSize = 0;
      btnConfirm.FlatAppearance.BorderSize = 0;
      btnConfirm.FlatStyle = FlatStyle.Flat;
      btnConfirm.Font = new Font("Microsoft Sans Serif", 20.25F);
      btnConfirm.ForeColor = Color.White;
      btnConfirm.Location = new Point(1180, 0);
      btnConfirm.Margin = new Padding(0);
      btnConfirm.Name = "btnConfirm";
      btnConfirm.Size = new Size(200, 60);
      btnConfirm.TabIndex = 10;
      btnConfirm.Text = "Xác nhận";
      btnConfirm.TextColor = Color.White;
      btnConfirm.UseVisualStyleBackColor = false;
      btnConfirm.Click += btnConfirm_Click;
      // 
      // btnCancel
      // 
      btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      btnCancel.BackColor = Color.Tomato;
      btnCancel.BackgroundColor = Color.Tomato;
      btnCancel.BorderColor = Color.PaleVioletRed;
      btnCancel.BorderRadius = 5;
      btnCancel.BorderSize = 0;
      btnCancel.FlatAppearance.BorderSize = 0;
      btnCancel.FlatStyle = FlatStyle.Flat;
      btnCancel.Font = new Font("Microsoft Sans Serif", 20.25F);
      btnCancel.ForeColor = Color.White;
      btnCancel.Location = new Point(1385, 0);
      btnCancel.Margin = new Padding(0);
      btnCancel.Name = "btnCancel";
      btnCancel.Size = new Size(200, 60);
      btnCancel.TabIndex = 11;
      btnCancel.Text = "Hủy";
      btnCancel.TextColor = Color.White;
      btnCancel.UseVisualStyleBackColor = false;
      btnCancel.Click += btnCancel_Click;
      // 
      // PopupScanRfid
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(1615, 905);
      ControlBox = false;
      Controls.Add(tableLayoutPanel1);
      MaximizeBox = false;
      MinimizeBox = false;
      Name = "PopupScanRfid";
      StartPosition = FormStartPosition.CenterScreen;
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel2.ResumeLayout(false);
      tableLayoutPanel3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
      tableLayoutPanel4.ResumeLayout(false);
      ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private TableLayoutPanel tableLayoutPanel2;
    private TableLayoutPanel tableLayoutPanel3;
    private UserControls.UcIdCard ucIdCard;
    private PictureBox pictureBox1;
    private UserControls.UcTitleFrm ucTitleFrm;
    private Custom.RJButton btnConfirm;
    private TableLayoutPanel tableLayoutPanel4;
    private Custom.RJButton btnCancel;
  }
}