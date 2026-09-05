namespace LaborTrackPro.UserControls
{
    partial class UcHeader
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
      tableLayoutPanel2 = new TableLayoutPanel();
      tableLayoutPanel4 = new TableLayoutPanel();
      btnHome = new LaborTrackPro.Custom.RJButton();
      btnBack = new LaborTrackPro.Custom.RJButton();
      pictureBox2 = new PictureBox();
      tableLayoutPanel1.SuspendLayout();
      tableLayoutPanel2.SuspendLayout();
      tableLayoutPanel4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
      SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.BackColor = Color.FromArgb(228, 148, 1);
      tableLayoutPanel1.ColumnCount = 1;
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
      tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
      tableLayoutPanel1.Dock = DockStyle.Fill;
      tableLayoutPanel1.Location = new Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 1;
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel1.Size = new Size(1143, 95);
      tableLayoutPanel1.TabIndex = 0;
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel2.BackColor = Color.FromArgb(228, 148, 1);
      tableLayoutPanel2.ColumnCount = 4;
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
      tableLayoutPanel2.Controls.Add(tableLayoutPanel4, 0, 0);
      tableLayoutPanel2.Controls.Add(pictureBox2, 2, 0);
      tableLayoutPanel2.Location = new Point(0, 0);
      tableLayoutPanel2.Margin = new Padding(0);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 1;
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.Size = new Size(1143, 95);
      tableLayoutPanel2.TabIndex = 0;
      // 
      // tableLayoutPanel4
      // 
      tableLayoutPanel4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel4.ColumnCount = 4;
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 78F));
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel4.Controls.Add(btnHome, 1, 0);
      tableLayoutPanel4.Controls.Add(btnBack, 3, 0);
      tableLayoutPanel4.Location = new Point(3, 15);
      tableLayoutPanel4.Name = "tableLayoutPanel4";
      tableLayoutPanel4.RowCount = 1;
      tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel4.Size = new Size(294, 65);
      tableLayoutPanel4.TabIndex = 3;
      // 
      // btnHome
      // 
      btnHome.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      btnHome.BackColor = Color.FromArgb(49, 68, 108);
      btnHome.BackgroundColor = Color.FromArgb(49, 68, 108);
      btnHome.BorderColor = Color.PaleVioletRed;
      btnHome.BorderRadius = 5;
      btnHome.BorderSize = 0;
      btnHome.FlatAppearance.BorderSize = 0;
      btnHome.FlatStyle = FlatStyle.Flat;
      btnHome.Font = new Font("Segoe UI", 14.25F);
      btnHome.ForeColor = Color.Black;
      btnHome.Image = Properties.Resources.BtnHome;
      btnHome.Location = new Point(10, 0);
      btnHome.Margin = new Padding(0);
      btnHome.Name = "btnHome";
      btnHome.Size = new Size(78, 65);
      btnHome.TabIndex = 7;
      btnHome.TextColor = Color.Black;
      btnHome.UseVisualStyleBackColor = false;
      btnHome.Click += btnHome_Click;
      // 
      // btnBack
      // 
      btnBack.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      btnBack.BackColor = Color.FromArgb(49, 68, 108);
      btnBack.BackgroundColor = Color.FromArgb(49, 68, 108);
      btnBack.BorderColor = Color.PaleVioletRed;
      btnBack.BorderRadius = 5;
      btnBack.BorderSize = 0;
      btnBack.FlatAppearance.BorderSize = 0;
      btnBack.FlatStyle = FlatStyle.Flat;
      btnBack.Font = new Font("Roboto", 20.25F);
      btnBack.ForeColor = Color.White;
      btnBack.Location = new Point(98, 0);
      btnBack.Margin = new Padding(0);
      btnBack.Name = "btnBack";
      btnBack.Size = new Size(196, 65);
      btnBack.TabIndex = 9;
      btnBack.Text = "Quay lại";
      btnBack.TextColor = Color.White;
      btnBack.UseVisualStyleBackColor = false;
      btnBack.Click += btnBack_Click;

      // 
      // UcHeader
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      Controls.Add(tableLayoutPanel1);
      Name = "UcHeader";
      Size = new Size(1143, 95);
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel2.ResumeLayout(false);
      tableLayoutPanel4.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private PictureBox pictureBox2;
    private TableLayoutPanel tableLayoutPanel4;
    private Custom.RJButton btnHome;
    private Custom.RJButton btnBack;
  }
}
