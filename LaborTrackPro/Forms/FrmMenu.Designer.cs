namespace LaborTrackPro
{
    partial class FrmMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
      tableLayoutPanel2 = new TableLayoutPanel();
      tableLayoutPanel3 = new TableLayoutPanel();
      btnSetting = new LaborTrackPro.Custom.RJButton();
      btnMasterData = new LaborTrackPro.Custom.RJButton();
      tableLayoutPanel2.SuspendLayout();
      tableLayoutPanel3.SuspendLayout();
      SuspendLayout();
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.BackColor = Color.White;
      tableLayoutPanel2.ColumnCount = 3;
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
      tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 1, 1);
      tableLayoutPanel2.Dock = DockStyle.Fill;
      tableLayoutPanel2.Location = new Point(0, 0);
      tableLayoutPanel2.Margin = new Padding(3, 2, 3, 2);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 3;
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
      tableLayoutPanel2.Size = new Size(1145, 724);
      tableLayoutPanel2.TabIndex = 4;
      // 
      // tableLayoutPanel3
      // 
      tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel3.BackColor = Color.FromArgb(239, 242, 243);
      tableLayoutPanel3.ColumnCount = 3;
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28571F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 71.42857F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
      tableLayoutPanel3.Controls.Add(btnSetting, 1, 3);
      tableLayoutPanel3.Controls.Add(btnMasterData, 1, 1);
      tableLayoutPanel3.Location = new Point(346, 74);
      tableLayoutPanel3.Margin = new Padding(3, 2, 3, 2);
      tableLayoutPanel3.Name = "tableLayoutPanel3";
      tableLayoutPanel3.RowCount = 5;
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 43.7500038F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 12.499999F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 43.7500038F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel3.Size = new Size(452, 575);
      tableLayoutPanel3.TabIndex = 4;
      // 
      // btnSetting
      // 
      btnSetting.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      btnSetting.BackColor = Color.FromArgb(228, 148, 1);
      btnSetting.BackgroundColor = Color.FromArgb(228, 148, 1);
      btnSetting.BackgroundImageLayout = ImageLayout.Stretch;
      btnSetting.BorderColor = Color.PaleVioletRed;
      btnSetting.BorderRadius = 10;
      btnSetting.BorderSize = 0;
      btnSetting.FlatAppearance.BorderSize = 0;
      btnSetting.FlatStyle = FlatStyle.Flat;
      btnSetting.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Bold);
      btnSetting.ForeColor = Color.White;
      btnSetting.Image = (Image)resources.GetObject("btnSetting.Image");
      btnSetting.ImageAlign = ContentAlignment.MiddleLeft;
      btnSetting.Location = new Point(64, 312);
      btnSetting.Margin = new Padding(0);
      btnSetting.Name = "btnSetting";
      btnSetting.Padding = new Padding(30, 0, 0, 0);
      btnSetting.Size = new Size(322, 80);
      btnSetting.TabIndex = 21;
      btnSetting.Text = "CÀI ĐẶT";
      btnSetting.TextColor = Color.White;
      btnSetting.UseVisualStyleBackColor = false;
      btnSetting.Click += btnSetting_Click;
      // 
      // btnMasterData
      // 
      btnMasterData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      btnMasterData.BackColor = Color.FromArgb(228, 148, 1);
      btnMasterData.BackgroundColor = Color.FromArgb(228, 148, 1);
      btnMasterData.BackgroundImageLayout = ImageLayout.Stretch;
      btnMasterData.BorderColor = Color.PaleVioletRed;
      btnMasterData.BorderRadius = 10;
      btnMasterData.BorderSize = 0;
      btnMasterData.FlatAppearance.BorderSize = 0;
      btnMasterData.FlatStyle = FlatStyle.Flat;
      btnMasterData.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Bold);
      btnMasterData.ForeColor = Color.White;
      btnMasterData.Image = (Image)resources.GetObject("btnMasterData.Image");
      btnMasterData.ImageAlign = ContentAlignment.MiddleLeft;
      btnMasterData.Location = new Point(64, 181);
      btnMasterData.Margin = new Padding(0);
      btnMasterData.Name = "btnMasterData";
      btnMasterData.Padding = new Padding(30, 0, 0, 0);
      btnMasterData.Size = new Size(322, 80);
      btnMasterData.TabIndex = 22;
      btnMasterData.Text = "THÔNG TIN DỮ LIỆU";
      btnMasterData.TextColor = Color.White;
      btnMasterData.UseVisualStyleBackColor = false;
      btnMasterData.Click += btnMasterData_Click;
      // 
      // FrmMenu
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      AutoSize = true;
      BackgroundImageLayout = ImageLayout.Stretch;
      ClientSize = new Size(1145, 724);
      Controls.Add(tableLayoutPanel2);
      DoubleBuffered = true;
      FormBorderStyle = FormBorderStyle.None;
      Margin = new Padding(3, 2, 3, 2);
      Name = "FrmMenu";
      StartPosition = FormStartPosition.CenterScreen;
      Text = "Form1";
      tableLayoutPanel2.ResumeLayout(false);
      tableLayoutPanel3.ResumeLayout(false);
      ResumeLayout(false);
    }

    #endregion
    private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
    private Custom.RJButton btnSetting;
    private Custom.RJButton btnMasterData;
  }
}
