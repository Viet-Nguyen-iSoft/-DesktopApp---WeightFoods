namespace LaborTrackPro.UserControls
{
  partial class UcItemMode
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
      tlpChoose = new TableLayoutPanel();
      lbTitle = new Label();
      tableLayoutPanel = new TableLayoutPanel();
      picIcon = new PictureBox();
      picConnect = new PictureBox();
      tlpChoose.SuspendLayout();
      tableLayoutPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)picIcon).BeginInit();
      ((System.ComponentModel.ISupportInitialize)picConnect).BeginInit();
      SuspendLayout();
      // 
      // tlpChoose
      // 
      tlpChoose.BackColor = Color.FromArgb(159, 159, 159);
      tlpChoose.ColumnCount = 3;
      tlpChoose.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 5F));
      tlpChoose.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tlpChoose.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 5F));
      tlpChoose.Controls.Add(lbTitle, 1, 2);
      tlpChoose.Controls.Add(tableLayoutPanel, 1, 1);
      tlpChoose.Dock = DockStyle.Fill;
      tlpChoose.Location = new Point(0, 0);
      tlpChoose.Margin = new Padding(3, 2, 3, 2);
      tlpChoose.Name = "tlpChoose";
      tlpChoose.RowCount = 3;
      tlpChoose.RowStyles.Add(new RowStyle(SizeType.Absolute, 5F));
      tlpChoose.RowStyles.Add(new RowStyle(SizeType.Percent, 85.18518F));
      tlpChoose.RowStyles.Add(new RowStyle(SizeType.Percent, 14.8148193F));
      tlpChoose.Size = new Size(402, 605);
      tlpChoose.TabIndex = 1;
      // 
      // lbTitle
      // 
      lbTitle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      lbTitle.AutoSize = true;
      lbTitle.BackColor = Color.Transparent;
      lbTitle.Font = new Font("Microsoft Sans Serif", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
      lbTitle.ForeColor = Color.White;
      lbTitle.Location = new Point(5, 516);
      lbTitle.Margin = new Padding(0);
      lbTitle.Name = "lbTitle";
      lbTitle.Size = new Size(392, 89);
      lbTitle.TabIndex = 1;
      lbTitle.Text = "Tên Cân";
      lbTitle.TextAlign = ContentAlignment.MiddleCenter;
      // 
      // tableLayoutPanel
      // 
      tableLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel.BackColor = Color.FromArgb(217, 217, 217);
      tableLayoutPanel.ColumnCount = 3;
      tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
      tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
      tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
      tableLayoutPanel.Controls.Add(picIcon, 1, 1);
      tableLayoutPanel.Controls.Add(picConnect, 2, 0);
      tableLayoutPanel.Location = new Point(5, 5);
      tableLayoutPanel.Margin = new Padding(0);
      tableLayoutPanel.Name = "tableLayoutPanel";
      tableLayoutPanel.RowCount = 3;
      tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
      tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
      tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
      tableLayoutPanel.Size = new Size(392, 511);
      tableLayoutPanel.TabIndex = 0;
      // 
      // picIcon
      // 
      picIcon.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      picIcon.Image = Properties.Resources.Weightting4x;
      picIcon.Location = new Point(98, 127);
      picIcon.Margin = new Padding(0);
      picIcon.Name = "picIcon";
      picIcon.Size = new Size(196, 255);
      picIcon.SizeMode = PictureBoxSizeMode.Zoom;
      picIcon.TabIndex = 0;
      picIcon.TabStop = false;
      // 
      // picConnect
      // 
      picConnect.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      picConnect.BackgroundImageLayout = ImageLayout.Stretch;
      picConnect.Image = Properties.Resources.icon_disconnected;
      picConnect.Location = new Point(335, 5);
      picConnect.Margin = new Padding(5);
      picConnect.Name = "picConnect";
      picConnect.Size = new Size(52, 55);
      picConnect.SizeMode = PictureBoxSizeMode.StretchImage;
      picConnect.TabIndex = 3;
      picConnect.TabStop = false;
      picConnect.Visible = false;
      // 
      // UcItemMode
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      Controls.Add(tlpChoose);
      Name = "UcItemMode";
      Size = new Size(402, 605);
      tlpChoose.ResumeLayout(false);
      tlpChoose.PerformLayout();
      tableLayoutPanel.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)picIcon).EndInit();
      ((System.ComponentModel.ISupportInitialize)picConnect).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tlpChoose;
    private Label lbTitle;
    private TableLayoutPanel tableLayoutPanel;
    private PictureBox picIcon;
    private PictureBox picConnect;
  }
}
