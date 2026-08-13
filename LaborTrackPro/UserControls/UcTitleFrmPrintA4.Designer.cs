namespace LaborTrackPro.UserControls
{
  partial class UcTitleFrmPrintA4
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
      label3 = new Label();
      lbTitle = new Label();
      lbStatus = new Label();
      label1 = new Label();
      picIcon = new PictureBox();
      btn = new LaborTrackPro.Custom.RJButton();
      btnPermitOverWeight = new LaborTrackPro.Custom.RJButton();
      tableLayoutPanel3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)picIcon).BeginInit();
      SuspendLayout();
      // 
      // tableLayoutPanel3
      // 
      tableLayoutPanel3.BackColor = Color.FromArgb(239, 242, 243);
      tableLayoutPanel3.ColumnCount = 10;
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 3F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 330F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
      tableLayoutPanel3.Controls.Add(label3, 0, 0);
      tableLayoutPanel3.Controls.Add(lbTitle, 2, 0);
      tableLayoutPanel3.Controls.Add(lbStatus, 5, 0);
      tableLayoutPanel3.Controls.Add(label1, 4, 0);
      tableLayoutPanel3.Controls.Add(picIcon, 1, 0);
      tableLayoutPanel3.Controls.Add(btn, 8, 0);
      tableLayoutPanel3.Controls.Add(btnPermitOverWeight, 6, 0);
      tableLayoutPanel3.Dock = DockStyle.Fill;
      tableLayoutPanel3.Location = new Point(0, 0);
      tableLayoutPanel3.Margin = new Padding(0);
      tableLayoutPanel3.Name = "tableLayoutPanel3";
      tableLayoutPanel3.RowCount = 1;
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel3.Size = new Size(1685, 72);
      tableLayoutPanel3.TabIndex = 5;
      // 
      // label3
      // 
      label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label3.AutoSize = true;
      label3.Font = new Font("Microsoft Sans Serif", 24F);
      label3.ForeColor = Color.Black;
      label3.ImageAlign = ContentAlignment.MiddleLeft;
      label3.Location = new Point(3, 0);
      label3.Name = "label3";
      label3.Size = new Size(1, 72);
      label3.TabIndex = 13;
      label3.Text = "Trạng thái máy in:";
      label3.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // lbTitle
      // 
      lbTitle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      lbTitle.AutoSize = true;
      lbTitle.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold);
      lbTitle.ForeColor = Color.Black;
      lbTitle.ImageAlign = ContentAlignment.MiddleLeft;
      lbTitle.Location = new Point(56, 0);
      lbTitle.Name = "lbTitle";
      lbTitle.Size = new Size(426, 72);
      lbTitle.TabIndex = 9;
      lbTitle.Text = "Xem trước phiếu giao nhận";
      lbTitle.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // lbStatus
      // 
      lbStatus.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      lbStatus.AutoSize = true;
      lbStatus.Font = new Font("Microsoft Sans Serif", 24F);
      lbStatus.ForeColor = Color.Black;
      lbStatus.ImageAlign = ContentAlignment.MiddleLeft;
      lbStatus.Location = new Point(869, 0);
      lbStatus.Name = "lbStatus";
      lbStatus.Size = new Size(163, 72);
      lbStatus.TabIndex = 12;
      lbStatus.Text = "N/A";
      lbStatus.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // label1
      // 
      label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label1.AutoSize = true;
      label1.Font = new Font("Microsoft Sans Serif", 24F);
      label1.ForeColor = Color.Black;
      label1.ImageAlign = ContentAlignment.MiddleLeft;
      label1.Location = new Point(588, 0);
      label1.Name = "label1";
      label1.Size = new Size(275, 72);
      label1.TabIndex = 11;
      label1.Text = "Trạng thái máy in:";
      label1.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // picIcon
      // 
      picIcon.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      picIcon.Image = Properties.Resources.icon_delivery_note;
      picIcon.Location = new Point(13, 10);
      picIcon.Margin = new Padding(10);
      picIcon.Name = "picIcon";
      picIcon.Size = new Size(30, 52);
      picIcon.SizeMode = PictureBoxSizeMode.StretchImage;
      picIcon.TabIndex = 10;
      picIcon.TabStop = false;
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
      btn.Location = new Point(1348, 6);
      btn.Name = "btn";
      btn.Size = new Size(324, 60);
      btn.TabIndex = 17;
      btn.Text = "In biên bản giao nhận";
      btn.TextColor = Color.White;
      btn.UseVisualStyleBackColor = false;
      btn.Click += btn_Click;
      // 
      // btnPermitOverWeight
      // 
      btnPermitOverWeight.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      btnPermitOverWeight.BackColor = Color.Tomato;
      btnPermitOverWeight.BackgroundColor = Color.Tomato;
      btnPermitOverWeight.BorderColor = Color.FromArgb(49, 68, 108);
      btnPermitOverWeight.BorderRadius = 5;
      btnPermitOverWeight.BorderSize = 0;
      btnPermitOverWeight.FlatAppearance.BorderSize = 0;
      btnPermitOverWeight.FlatStyle = FlatStyle.Flat;
      btnPermitOverWeight.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold);
      btnPermitOverWeight.ForeColor = Color.White;
      btnPermitOverWeight.Location = new Point(1038, 6);
      btnPermitOverWeight.Name = "btnPermitOverWeight";
      btnPermitOverWeight.Size = new Size(294, 60);
      btnPermitOverWeight.TabIndex = 18;
      btnPermitOverWeight.Text = "Xác nhận cho phép";
      btnPermitOverWeight.TextColor = Color.White;
      btnPermitOverWeight.UseVisualStyleBackColor = false;
      btnPermitOverWeight.Visible = false;
      btnPermitOverWeight.Click += btnPermitOverWeight_Click;
      // 
      // UcTitleFrmPrintA4
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      Controls.Add(tableLayoutPanel3);
      Name = "UcTitleFrmPrintA4";
      Size = new Size(1685, 72);
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
    private Label label1;
    private Label label3;
    private Label lbStatus;
    private Custom.RJButton btnPermitOverWeight;
  }
}
