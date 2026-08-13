namespace LaborTrackPro
{
  partial class FrmInformation
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
      components = new System.ComponentModel.Container();
      tableLayoutPanel1 = new TableLayoutPanel();
      tableLayoutPanel4 = new TableLayoutPanel();
      lbInformation = new Label();
      picIcon = new PictureBox();
      timerInformation = new System.Windows.Forms.Timer(components);
      tableLayoutPanel1.SuspendLayout();
      tableLayoutPanel4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)picIcon).BeginInit();
      SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.BackColor = Color.FromArgb(49, 68, 108);
      tableLayoutPanel1.ColumnCount = 3;
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 3F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 3F));
      tableLayoutPanel1.Controls.Add(tableLayoutPanel4, 1, 1);
      tableLayoutPanel1.Dock = DockStyle.Fill;
      tableLayoutPanel1.Location = new Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 3;
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 3F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 3F));
      tableLayoutPanel1.Size = new Size(896, 208);
      tableLayoutPanel1.TabIndex = 1;
      // 
      // tableLayoutPanel4
      // 
      tableLayoutPanel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel4.BackColor = Color.FromArgb(248, 237, 224);
      tableLayoutPanel4.ColumnCount = 2;
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.4931126F));
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 82.50689F));
      tableLayoutPanel4.Controls.Add(lbInformation, 1, 0);
      tableLayoutPanel4.Controls.Add(picIcon, 0, 0);
      tableLayoutPanel4.Location = new Point(3, 3);
      tableLayoutPanel4.Margin = new Padding(0);
      tableLayoutPanel4.Name = "tableLayoutPanel4";
      tableLayoutPanel4.RowCount = 1;
      tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
      tableLayoutPanel4.Size = new Size(890, 202);
      tableLayoutPanel4.TabIndex = 3;
      // 
      // lbInformation
      // 
      lbInformation.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      lbInformation.AutoSize = true;
      lbInformation.Font = new Font("Roboto", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
      lbInformation.ForeColor = Color.Black;
      lbInformation.Location = new Point(158, 0);
      lbInformation.Name = "lbInformation";
      lbInformation.Size = new Size(729, 202);
      lbInformation.TabIndex = 11;
      lbInformation.Text = "...";
      lbInformation.TextAlign = ContentAlignment.MiddleCenter;
      // 
      // picIcon
      // 
      picIcon.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      picIcon.Location = new Point(20, 46);
      picIcon.Margin = new Padding(20);
      picIcon.Name = "picIcon";
      picIcon.Size = new Size(115, 109);
      picIcon.SizeMode = PictureBoxSizeMode.StretchImage;
      picIcon.TabIndex = 12;
      picIcon.TabStop = false;
      // 
      // timerInformation
      // 
      timerInformation.Interval = 2000;
      timerInformation.Tick += timerInformation_Tick;
      // 
      // FrmInformation
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(896, 208);
      ControlBox = false;
      Controls.Add(tableLayoutPanel1);
      FormBorderStyle = FormBorderStyle.None;
      Name = "FrmInformation";
      StartPosition = FormStartPosition.CenterParent;
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel4.ResumeLayout(false);
      tableLayoutPanel4.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)picIcon).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private TableLayoutPanel tableLayoutPanel4;
    private Label lbInformation;
    private PictureBox picIcon;
    private System.Windows.Forms.Timer timerInformation;
  }
}