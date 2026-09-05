namespace LaborTrackPro.UserControls
{
  partial class UcTitleFrm
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
      tableLayoutPanel3 = new TableLayoutPanel();
      btn = new LaborTrackPro.Custom.RJButton();
      picIcon = new PictureBox();
      lbTitle = new Label();
      tableLayoutPanel3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)picIcon).BeginInit();
      SuspendLayout();
      // 
      // tableLayoutPanel3
      // 
      tableLayoutPanel3.BackColor = Color.FromArgb(239, 242, 243);
      tableLayoutPanel3.ColumnCount = 5;
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 3F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 83F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
      tableLayoutPanel3.Controls.Add(btn, 3, 0);
      tableLayoutPanel3.Controls.Add(picIcon, 1, 0);
      tableLayoutPanel3.Controls.Add(lbTitle, 2, 0);
      tableLayoutPanel3.Dock = DockStyle.Fill;
      tableLayoutPanel3.Location = new Point(0, 0);
      tableLayoutPanel3.Margin = new Padding(0);
      tableLayoutPanel3.Name = "tableLayoutPanel3";
      tableLayoutPanel3.RowCount = 1;
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel3.Size = new Size(1120, 80);
      tableLayoutPanel3.TabIndex = 4;
      // 
      // btn
      // 
      btn.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      btn.BackColor = Color.FromArgb(49, 68, 108);
      btn.BackgroundColor = Color.FromArgb(49, 68, 108);
      btn.BorderColor = Color.FromArgb(49, 68, 108);
      btn.BorderRadius = 5;
      btn.BorderSize = 0;
      btn.FlatAppearance.BorderSize = 0;
      btn.FlatStyle = FlatStyle.Flat;
      btn.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold);
      btn.ForeColor = Color.White;
      btn.Location = new Point(907, 10);
      btn.Name = "btn";
      btn.Size = new Size(200, 60);
      btn.TabIndex = 8;
      btn.Text = "Tìm kiếm";
      btn.TextColor = Color.White;
      btn.UseVisualStyleBackColor = false;
      btn.Click += btnSearch_Click;

      // lbTitle
      // 
      lbTitle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      lbTitle.AutoSize = true;
      lbTitle.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold);
      lbTitle.ForeColor = Color.Black;
      lbTitle.ImageAlign = ContentAlignment.MiddleLeft;
      lbTitle.Location = new Point(89, 0);
      lbTitle.Name = "lbTitle";
      lbTitle.Size = new Size(812, 80);
      lbTitle.TabIndex = 9;
      lbTitle.Text = "Title";
      lbTitle.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // UcTitleFrm
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      Controls.Add(tableLayoutPanel3);
      Name = "UcTitleFrm";
      Size = new Size(1120, 80);
      tableLayoutPanel3.ResumeLayout(false);
      tableLayoutPanel3.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)picIcon).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel3;
    private Custom.RJButton btn;
    private PictureBox picIcon;
    private Label lbTitle;
  }
}
