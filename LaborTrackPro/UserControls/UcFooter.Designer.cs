namespace LaborTrackPro.UserControls
{
  partial class UcFooter
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
      tableLayoutPanel1 = new TableLayoutPanel();
      label3 = new Label();
      lbDatetime = new Label();
      ucStatusConnection1 = new LaborTrackPro.UC.UcStatusConnection();
      picLockMenu = new PictureBox();
      ucStatusConnection2 = new LaborTrackPro.UC.UcStatusConnection();
      tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)picLockMenu).BeginInit();
      SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.BackColor = Color.FromArgb(228, 148, 1);
      tableLayoutPanel1.ColumnCount = 11;
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 3F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 3F));
      tableLayoutPanel1.Controls.Add(label3, 1, 0);
      tableLayoutPanel1.Controls.Add(lbDatetime, 9, 0);
      tableLayoutPanel1.Controls.Add(ucStatusConnection1, 5, 0);
      tableLayoutPanel1.Controls.Add(picLockMenu, 3, 0);
      tableLayoutPanel1.Controls.Add(ucStatusConnection2, 6, 0);
      tableLayoutPanel1.Dock = DockStyle.Fill;
      tableLayoutPanel1.Location = new Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 1;
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.Size = new Size(1763, 60);
      tableLayoutPanel1.TabIndex = 0;
      // 
      // label3
      // 
      label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label3.AutoSize = true;
      label3.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold);
      label3.ForeColor = Color.White;
      label3.Location = new Point(6, 0);
      label3.Name = "label3";
      label3.Size = new Size(527, 60);
      label3.TabIndex = 10;
      label3.Text = "Copyright @ 2025 i-Soft JSC. All rights reserved.";
      label3.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // lbDatetime
      // 
      lbDatetime.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      lbDatetime.AutoSize = true;
      lbDatetime.Font = new Font("Microsoft Sans Serif", 15.75F);
      lbDatetime.ForeColor = Color.White;
      lbDatetime.Location = new Point(1533, 0);
      lbDatetime.Name = "lbDatetime";
      lbDatetime.Size = new Size(224, 60);
      lbDatetime.TabIndex = 11;
      lbDatetime.Text = "hh:mm:ss dd/mm/yyyy";
      lbDatetime.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // ucStatusConnection1
      // 
      ucStatusConnection1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      ucStatusConnection1.Location = new Point(699, 9);
      ucStatusConnection1.Margin = new Padding(3, 2, 3, 2);
      ucStatusConnection1.Name = "ucStatusConnection1";
      ucStatusConnection1.Size = new Size(174, 42);
      ucStatusConnection1.TabIndex = 12;
      // 
      // picLockMenu
      // 
      picLockMenu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      picLockMenu.Image = Properties.Resources.icon_locked;
      picLockMenu.Location = new Point(581, 5);
      picLockMenu.Margin = new Padding(15, 5, 15, 5);
      picLockMenu.Name = "picLockMenu";
      picLockMenu.Size = new Size(70, 50);
      picLockMenu.SizeMode = PictureBoxSizeMode.StretchImage;
      picLockMenu.TabIndex = 16;
      picLockMenu.TabStop = false;
      picLockMenu.Click += picMenu_Click;
      // 
      // ucStatusConnection2
      // 
      ucStatusConnection2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      ucStatusConnection2.Location = new Point(879, 9);
      ucStatusConnection2.Margin = new Padding(3, 2, 3, 2);
      ucStatusConnection2.Name = "ucStatusConnection2";
      ucStatusConnection2.Size = new Size(174, 42);
      ucStatusConnection2.TabIndex = 18;
      // 
      // UcFooter
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      Controls.Add(tableLayoutPanel1);
      Name = "UcFooter";
      Size = new Size(1763, 60);
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)picLockMenu).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private Label label3;
    private Label lbDatetime;
    private UC.UcStatusConnection ucStatusConnection1;
    private PictureBox picLockMenu;
    private UC.UcStatusConnection ucStatusConnection2;
  }
}
