namespace LaborTrackPro.Forms
{
  partial class FrmLoadingPrinting
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
      tableLayoutPanel2 = new TableLayoutPanel();
      tableLayoutPanel4 = new TableLayoutPanel();
      lbStatus = new Label();
      lbNumberPrinted = new Label();
      tableLayoutPanel1 = new TableLayoutPanel();
      btnCancel = new LaborTrackPro.Custom.RJButton();
      pictureBox1 = new PictureBox();
      label1 = new Label();
      progressBar1 = new ProgressBar();
      flowLayoutPanel = new FlowLayoutPanel();
      tableLayoutPanel2.SuspendLayout();
      tableLayoutPanel4.SuspendLayout();
      tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
      SuspendLayout();
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.BackColor = Color.White;
      tableLayoutPanel2.ColumnCount = 1;
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.Controls.Add(tableLayoutPanel4, 0, 0);
      tableLayoutPanel2.Controls.Add(flowLayoutPanel, 0, 1);
      tableLayoutPanel2.Dock = DockStyle.Fill;
      tableLayoutPanel2.Location = new Point(0, 0);
      tableLayoutPanel2.Margin = new Padding(0);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 2;
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 200F));
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.Size = new Size(1424, 963);
      tableLayoutPanel2.TabIndex = 1;
      // 
      // tableLayoutPanel4
      // 
      tableLayoutPanel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel4.BackColor = Color.White;
      tableLayoutPanel4.ColumnCount = 1;
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel4.Controls.Add(lbStatus, 0, 5);
      tableLayoutPanel4.Controls.Add(lbNumberPrinted, 0, 1);
      tableLayoutPanel4.Controls.Add(tableLayoutPanel1, 0, 0);
      tableLayoutPanel4.Controls.Add(progressBar1, 0, 3);
      tableLayoutPanel4.Location = new Point(3, 3);
      tableLayoutPanel4.Name = "tableLayoutPanel4";
      tableLayoutPanel4.RowCount = 6;
      tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
      tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
      tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
      tableLayoutPanel4.RowStyles.Add(new RowStyle());
      tableLayoutPanel4.Size = new Size(1418, 194);
      tableLayoutPanel4.TabIndex = 1;
      // 
      // lbStatus
      // 
      lbStatus.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      lbStatus.AutoSize = true;
      lbStatus.Font = new Font("Roboto", 19.8000011F);
      lbStatus.Location = new Point(3, 161);
      lbStatus.Name = "lbStatus";
      lbStatus.Size = new Size(1412, 33);
      lbStatus.TabIndex = 2;
      lbStatus.Text = "Vui lòng chờ ...";
      lbStatus.TextAlign = ContentAlignment.MiddleCenter;
      // 
      // lbNumberPrinted
      // 
      lbNumberPrinted.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      lbNumberPrinted.AutoSize = true;
      lbNumberPrinted.Font = new Font("Roboto", 30F);
      lbNumberPrinted.Location = new Point(3, 60);
      lbNumberPrinted.Name = "lbNumberPrinted";
      lbNumberPrinted.Size = new Size(1412, 61);
      lbNumberPrinted.TabIndex = 1;
      lbNumberPrinted.Text = ".../...";
      lbNumberPrinted.TextAlign = ContentAlignment.MiddleCenter;
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel1.ColumnCount = 3;
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
      tableLayoutPanel1.Controls.Add(btnCancel, 2, 0);
      tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
      tableLayoutPanel1.Controls.Add(label1, 1, 0);
      tableLayoutPanel1.Location = new Point(0, 0);
      tableLayoutPanel1.Margin = new Padding(0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 1;
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.Size = new Size(1418, 60);
      tableLayoutPanel1.TabIndex = 4;
      // 
      // btnCancel
      // 
      btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      btnCancel.BackColor = Color.FromArgb(224, 224, 224);
      btnCancel.BackgroundColor = Color.FromArgb(224, 224, 224);
      btnCancel.BorderColor = Color.PaleVioletRed;
      btnCancel.BorderRadius = 5;
      btnCancel.BorderSize = 0;
      btnCancel.FlatAppearance.BorderSize = 0;
      btnCancel.FlatStyle = FlatStyle.Flat;
      btnCancel.Font = new Font("Roboto", 20.25F, FontStyle.Bold);
      btnCancel.ForeColor = Color.Black;
      btnCancel.Location = new Point(1271, 3);
      btnCancel.Name = "btnCancel";
      btnCancel.Size = new Size(144, 54);
      btnCancel.TabIndex = 7;
      btnCancel.Text = "Hủy";
      btnCancel.TextColor = Color.Black;
      btnCancel.UseVisualStyleBackColor = false;
      btnCancel.Visible = false;
      btnCancel.Click += btnCancel_Click;
      // 
      // pictureBox1
      // 
      pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      pictureBox1.Image = Properties.Resources.Printer;
      pictureBox1.Location = new Point(3, 2);
      pictureBox1.Margin = new Padding(3, 2, 3, 2);
      pictureBox1.Name = "pictureBox1";
      pictureBox1.Size = new Size(62, 56);
      pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      pictureBox1.TabIndex = 0;
      pictureBox1.TabStop = false;
      // 
      // label1
      // 
      label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label1.AutoSize = true;
      label1.Font = new Font("Roboto", 20.25F, FontStyle.Bold);
      label1.Location = new Point(153, 0);
      label1.Name = "label1";
      label1.Size = new Size(1112, 60);
      label1.TabIndex = 0;
      label1.Text = "Đang in phiếu";
      label1.TextAlign = ContentAlignment.MiddleCenter;
      // 
      // progressBar1
      // 
      progressBar1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      progressBar1.BackColor = Color.White;
      progressBar1.ForeColor = Color.Lime;
      progressBar1.Location = new Point(18, 133);
      progressBar1.Margin = new Padding(18, 2, 18, 2);
      progressBar1.Name = "progressBar1";
      progressBar1.Size = new Size(1382, 16);
      progressBar1.Style = ProgressBarStyle.Continuous;
      progressBar1.TabIndex = 3;
      // 
      // flowLayoutPanel
      // 
      flowLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      flowLayoutPanel.AutoScroll = true;
      flowLayoutPanel.BackColor = Color.Gainsboro;
      flowLayoutPanel.Location = new Point(0, 200);
      flowLayoutPanel.Margin = new Padding(0);
      flowLayoutPanel.Name = "flowLayoutPanel";
      flowLayoutPanel.Padding = new Padding(5);
      flowLayoutPanel.Size = new Size(1424, 763);
      flowLayoutPanel.TabIndex = 1;
      // 
      // FrmLoadingPrinting
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(1424, 963);
      ControlBox = false;
      Controls.Add(tableLayoutPanel2);
      Margin = new Padding(3, 2, 3, 2);
      Name = "FrmLoadingPrinting";
      WindowState = FormWindowState.Maximized;
      tableLayoutPanel2.ResumeLayout(false);
      tableLayoutPanel4.ResumeLayout(false);
      tableLayoutPanel4.PerformLayout();
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel2;
    private ProgressBar progressBar1;
    private PictureBox pictureBox1;
    private TableLayoutPanel tableLayoutPanel4;
    private Label lbStatus;
    private Label lbNumberPrinted;
    private Label label1;
    private FlowLayoutPanel flowLayoutPanel;
    private TableLayoutPanel tableLayoutPanel1;
    private Custom.RJButton btnCancel;
  }
}