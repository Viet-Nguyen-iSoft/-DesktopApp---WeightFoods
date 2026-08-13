namespace LaborTrackPro.Forms.Operation
{
  partial class FrmReviewDelivery
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
      ucTitleFrmPrintA41 = new LaborTrackPro.UserControls.UcTitleFrmPrintA4();
      tableLayoutPanel2 = new TableLayoutPanel();
      tableLayoutPanel4 = new TableLayoutPanel();
      btnQC = new LaborTrackPro.Custom.RJButton();
      btnReceiving = new LaborTrackPro.Custom.RJButton();
      tableLayoutPanel6 = new TableLayoutPanel();
      webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
      tableLayoutPanel1.SuspendLayout();
      tableLayoutPanel2.SuspendLayout();
      tableLayoutPanel4.SuspendLayout();
      tableLayoutPanel6.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
      SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.BackColor = Color.White;
      tableLayoutPanel1.ColumnCount = 3;
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 15F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 15F));
      tableLayoutPanel1.Controls.Add(ucTitleFrmPrintA41, 1, 1);
      tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 3);
      tableLayoutPanel1.Dock = DockStyle.Fill;
      tableLayoutPanel1.Location = new Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 5;
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 85F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
      tableLayoutPanel1.Size = new Size(1419, 599);
      tableLayoutPanel1.TabIndex = 2;
      // 
      // ucTitleFrmPrintA41
      // 
      ucTitleFrmPrintA41.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      ucTitleFrmPrintA41.Location = new Point(18, 18);
      ucTitleFrmPrintA41.Name = "ucTitleFrmPrintA41";
      ucTitleFrmPrintA41.Size = new Size(1383, 79);
      ucTitleFrmPrintA41.TabIndex = 3;
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel2.BackColor = Color.White;
      tableLayoutPanel2.ColumnCount = 3;
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.Controls.Add(tableLayoutPanel4, 0, 0);
      tableLayoutPanel2.Controls.Add(tableLayoutPanel6, 2, 0);
      tableLayoutPanel2.Location = new Point(15, 115);
      tableLayoutPanel2.Margin = new Padding(0);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 1;
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.Size = new Size(1389, 469);
      tableLayoutPanel2.TabIndex = 4;
      // 
      // tableLayoutPanel4
      // 
      tableLayoutPanel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel4.BackColor = Color.White;
      tableLayoutPanel4.ColumnCount = 1;
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel4.Controls.Add(btnReceiving, 0, 0);
      tableLayoutPanel4.Controls.Add(btnQC, 0, 1);
      tableLayoutPanel4.Location = new Point(0, 0);
      tableLayoutPanel4.Margin = new Padding(0);
      tableLayoutPanel4.Name = "tableLayoutPanel4";
      tableLayoutPanel4.RowCount = 3;
      tableLayoutPanel4.RowStyles.Add(new RowStyle());
      tableLayoutPanel4.RowStyles.Add(new RowStyle());
      tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel4.Size = new Size(200, 469);
      tableLayoutPanel4.TabIndex = 4;
      // 
      // btnQC
      // 
      btnQC.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      btnQC.BackColor = Color.FromArgb(49, 68, 108);
      btnQC.BackgroundColor = Color.FromArgb(49, 68, 108);
      btnQC.BorderColor = Color.PaleVioletRed;
      btnQC.BorderRadius = 5;
      btnQC.BorderSize = 0;
      btnQC.FlatAppearance.BorderSize = 0;
      btnQC.FlatStyle = FlatStyle.Flat;
      btnQC.Font = new Font("Microsoft Sans Serif", 20.25F);
      btnQC.ForeColor = Color.White;
      btnQC.Location = new Point(0, 70);
      btnQC.Margin = new Padding(0, 5, 0, 0);
      btnQC.Name = "btnQC";
      btnQC.Size = new Size(200, 60);
      btnQC.TabIndex = 11;
      btnQC.Text = "QC";
      btnQC.TextColor = Color.White;
      btnQC.UseVisualStyleBackColor = false;
      btnQC.Click += btnQC_Click;
      // 
      // btnReceiving
      // 
      btnReceiving.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      btnReceiving.BackColor = Color.FromArgb(49, 68, 108);
      btnReceiving.BackgroundColor = Color.FromArgb(49, 68, 108);
      btnReceiving.BorderColor = Color.PaleVioletRed;
      btnReceiving.BorderRadius = 5;
      btnReceiving.BorderSize = 0;
      btnReceiving.FlatAppearance.BorderSize = 0;
      btnReceiving.FlatStyle = FlatStyle.Flat;
      btnReceiving.Font = new Font("Microsoft Sans Serif", 20.25F);
      btnReceiving.ForeColor = Color.White;
      btnReceiving.Location = new Point(0, 5);
      btnReceiving.Margin = new Padding(0, 5, 0, 0);
      btnReceiving.Name = "btnReceiving";
      btnReceiving.Size = new Size(200, 60);
      btnReceiving.TabIndex = 10;
      btnReceiving.Text = "Bên nhận";
      btnReceiving.TextColor = Color.White;
      btnReceiving.UseVisualStyleBackColor = false;
      btnReceiving.Click += btnReceiving_Click;
      // 
      // tableLayoutPanel6
      // 
      tableLayoutPanel6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel6.BackColor = Color.FromArgb(239, 242, 243);
      tableLayoutPanel6.ColumnCount = 3;
      tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 5F));
      tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 5F));
      tableLayoutPanel6.Controls.Add(webView21, 1, 1);
      tableLayoutPanel6.Location = new Point(210, 0);
      tableLayoutPanel6.Margin = new Padding(0);
      tableLayoutPanel6.Name = "tableLayoutPanel6";
      tableLayoutPanel6.RowCount = 3;
      tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 5F));
      tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 5F));
      tableLayoutPanel6.Size = new Size(1179, 469);
      tableLayoutPanel6.TabIndex = 5;
      // 
      // webView21
      // 
      webView21.AllowExternalDrop = true;
      webView21.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      webView21.BackColor = Color.White;
      webView21.CreationProperties = null;
      webView21.DefaultBackgroundColor = Color.White;
      webView21.Location = new Point(5, 5);
      webView21.Margin = new Padding(0);
      webView21.Name = "webView21";
      webView21.Size = new Size(1169, 459);
      webView21.TabIndex = 2;
      webView21.ZoomFactor = 1D;
      // 
      // FrmReviewDelivery
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(1419, 599);
      Controls.Add(tableLayoutPanel1);
      Name = "FrmReviewDelivery";
      Text = "FrmReviewDelivery";
      Load += FrmReviewDelivery_Load;
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel2.ResumeLayout(false);
      tableLayoutPanel4.ResumeLayout(false);
      tableLayoutPanel6.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
    private UserControls.UcTitleFrmPrintA4 ucTitleFrmPrintA41;
    private TableLayoutPanel tableLayoutPanel2;
    private Custom.RJButton btnReceiving;
    private Custom.RJButton btnQC;
    private TableLayoutPanel tableLayoutPanel4;
    private TableLayoutPanel tableLayoutPanel6;
  }
}