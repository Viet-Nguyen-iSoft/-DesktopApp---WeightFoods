namespace LaborTrackPro.UC
{
    partial class UcStatusConnection
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
      picIcon = new PictureBox();
      lbStatus = new Label();
      tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)picIcon).BeginInit();
      SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.BackColor = Color.FromArgb(223, 47, 32);
      tableLayoutPanel1.ColumnCount = 2;
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
      tableLayoutPanel1.Controls.Add(picIcon, 0, 0);
      tableLayoutPanel1.Controls.Add(lbStatus, 1, 0);
      tableLayoutPanel1.Dock = DockStyle.Fill;
      tableLayoutPanel1.Location = new Point(0, 0);
      tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 1;
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.Size = new Size(198, 47);
      tableLayoutPanel1.TabIndex = 0;
      // 
      // picIcon
      // 
      picIcon.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      picIcon.Image = Properties.Resources.icon_server;
      picIcon.Location = new Point(8, 8);
      picIcon.Margin = new Padding(8);
      picIcon.Name = "picIcon";
      picIcon.Size = new Size(34, 31);
      picIcon.SizeMode = PictureBoxSizeMode.StretchImage;
      picIcon.TabIndex = 0;
      picIcon.TabStop = false;
      // 
      // lbStatus
      // 
      lbStatus.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      lbStatus.AutoSize = true;
      lbStatus.BackColor = Color.Transparent;
      lbStatus.Font = new Font("Roboto", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
      lbStatus.ForeColor = Color.White;
      lbStatus.Location = new Point(53, 0);
      lbStatus.Margin = new Padding(3, 0, 0, 0);
      lbStatus.Name = "lbStatus";
      lbStatus.Size = new Size(145, 47);
      lbStatus.TabIndex = 1;
      lbStatus.Text = "N/A";
      lbStatus.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // UcStatusConnection
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      Controls.Add(tableLayoutPanel1);
      Margin = new Padding(3, 2, 3, 2);
      Name = "UcStatusConnection";
      Size = new Size(198, 47);
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)picIcon).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
        private PictureBox picIcon;
        private Label lbStatus;
    }
}
