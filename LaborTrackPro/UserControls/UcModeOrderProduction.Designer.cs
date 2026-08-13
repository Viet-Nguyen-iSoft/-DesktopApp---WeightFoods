namespace LaborTrackPro.UserControls
{
  partial class UcModeOrderProduction
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
      tlpChoose.SuspendLayout();
      tableLayoutPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)picIcon).BeginInit();
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
      lbTitle.Font = new Font("Roboto", 30F, FontStyle.Bold, GraphicsUnit.Point);
      lbTitle.ForeColor = Color.White;
      lbTitle.Location = new Point(5, 516);
      lbTitle.Margin = new Padding(0);
      lbTitle.Name = "lbTitle";
      lbTitle.Size = new Size(392, 89);
      lbTitle.TabIndex = 1;
      lbTitle.Text = "Tên Cân";
      lbTitle.TextAlign = ContentAlignment.MiddleCenter;
      lbTitle.Click += lbTitle_Click;
      // 
      // tableLayoutPanel
      // 
      tableLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel.BackColor = Color.FromArgb(217, 217, 217);
      tableLayoutPanel.ColumnCount = 3;
      tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.9999962F));
      tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 270F));
      tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0000076F));
      tableLayoutPanel.Controls.Add(picIcon, 1, 1);
      tableLayoutPanel.Location = new Point(5, 5);
      tableLayoutPanel.Margin = new Padding(0);
      tableLayoutPanel.Name = "tableLayoutPanel";
      tableLayoutPanel.RowCount = 3;
      tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50.0000038F));
      tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 375F));
      tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 49.9999924F));
      tableLayoutPanel.Size = new Size(392, 511);
      tableLayoutPanel.TabIndex = 0;
      tableLayoutPanel.Click += tableLayoutPanel_Click;
      // 
      // picIcon
      // 
      picIcon.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      picIcon.Image = Properties.Resources.Weightting4x;
      picIcon.Location = new Point(60, 68);
      picIcon.Margin = new Padding(0);
      picIcon.Name = "picIcon";
      picIcon.Size = new Size(270, 375);
      picIcon.SizeMode = PictureBoxSizeMode.StretchImage;
      picIcon.TabIndex = 0;
      picIcon.TabStop = false;
      picIcon.Click += picIcon_Click;
      // 
      // UcModeOrderProduction
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      Controls.Add(tlpChoose);
      Name = "UcModeOrderProduction";
      Size = new Size(402, 605);
      tlpChoose.ResumeLayout(false);
      tlpChoose.PerformLayout();
      tableLayoutPanel.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)picIcon).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tlpChoose;
    private Label lbTitle;
    private TableLayoutPanel tableLayoutPanel;
    private PictureBox picIcon;
  }
}
