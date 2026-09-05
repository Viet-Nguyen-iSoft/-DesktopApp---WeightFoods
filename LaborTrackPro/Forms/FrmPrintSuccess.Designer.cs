namespace LaborTrackPro.Forms
{
  partial class FrmPrintSuccess
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
      pictureBox1 = new PictureBox();
      label1 = new Label();
      pictureBox3 = new PictureBox();
      tableLayoutPanel1.SuspendLayout();
      tableLayoutPanel2.SuspendLayout();
      tableLayoutPanel3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
      ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
      SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.BackColor = Color.FromArgb(245, 211, 147);
      tableLayoutPanel1.ColumnCount = 3;
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
      tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 1);
      tableLayoutPanel1.Dock = DockStyle.Fill;
      tableLayoutPanel1.Location = new Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 3;
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
      tableLayoutPanel1.Size = new Size(586, 375);
      tableLayoutPanel1.TabIndex = 0;
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel2.BackColor = Color.White;
      tableLayoutPanel2.ColumnCount = 1;
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 0);
      tableLayoutPanel2.Controls.Add(pictureBox3, 0, 2);
      tableLayoutPanel2.Location = new Point(10, 10);
      tableLayoutPanel2.Margin = new Padding(0);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 3;
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel2.Size = new Size(566, 355);
      tableLayoutPanel2.TabIndex = 0;
      // 
      // tableLayoutPanel3
      // 
      tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel3.ColumnCount = 2;
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel3.Controls.Add(pictureBox1, 0, 0);
      tableLayoutPanel3.Controls.Add(label1, 1, 0);
      tableLayoutPanel3.Location = new Point(0, 0);
      tableLayoutPanel3.Margin = new Padding(0);
      tableLayoutPanel3.Name = "tableLayoutPanel3";
      tableLayoutPanel3.RowCount = 1;
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel3.Size = new Size(566, 70);
      tableLayoutPanel3.TabIndex = 0;

      // 
      // label1
      // 
      label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label1.AutoSize = true;
      label1.Font = new Font("Roboto Medium", 24F, FontStyle.Bold, GraphicsUnit.Point);
      label1.Location = new Point(73, 0);
      label1.Name = "label1";
      label1.Size = new Size(490, 70);
      label1.TabIndex = 1;
      label1.Text = "In phiếu thành công";
      label1.TextAlign = ContentAlignment.MiddleCenter;
      // 
      // pictureBox3
      // 
      pictureBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      pictureBox3.Image = Properties.Resources.icon_confirm;
      pictureBox3.Location = new Point(0, 80);
      pictureBox3.Margin = new Padding(0);
      pictureBox3.Name = "pictureBox3";
      pictureBox3.Size = new Size(566, 275);
      pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
      pictureBox3.TabIndex = 3;
      pictureBox3.TabStop = false;
      // 
      // FrmPrintSuccess
      // 
      AutoScaleDimensions = new SizeF(8F, 20F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.Gray;
      ClientSize = new Size(586, 375);
      ControlBox = false;
      Controls.Add(tableLayoutPanel1);
      FormBorderStyle = FormBorderStyle.None;
      Name = "FrmPrintSuccess";
      StartPosition = FormStartPosition.CenterParent;
      Text = "FrmPrintSuccess";
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel2.ResumeLayout(false);
      tableLayoutPanel3.ResumeLayout(false);
      tableLayoutPanel3.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
      ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private TableLayoutPanel tableLayoutPanel2;
    private TableLayoutPanel tableLayoutPanel3;
    private PictureBox pictureBox1;
    private Label label1;
    private PictureBox pictureBox3;
  }
}