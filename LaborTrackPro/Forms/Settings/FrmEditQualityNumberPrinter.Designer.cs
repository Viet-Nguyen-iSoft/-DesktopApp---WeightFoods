namespace LaborTrackPro.Forms.Settings
{
    partial class FrmEditQualityNumberPrinter
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
      label7 = new Label();
      tableLayoutPanel1 = new TableLayoutPanel();
      tableLayoutPanel4 = new TableLayoutPanel();
      btnSave = new LaborTrackPro.Custom.RJButton();
      btnCancel = new LaborTrackPro.Custom.RJButton();
      tableLayoutPanel2 = new TableLayoutPanel();
      tableLayoutPanel5 = new TableLayoutPanel();
      txtNumberPrint = new CustomControls.RJControls.RJTextBox();
      btnUp = new LaborTrackPro.Custom.RJButton();
      btnDown = new LaborTrackPro.Custom.RJButton();
      label1 = new Label();
      label8 = new Label();
      txtTitleName = new CustomControls.RJControls.RJTextBox();
      tableLayoutPanel1.SuspendLayout();
      tableLayoutPanel4.SuspendLayout();
      tableLayoutPanel2.SuspendLayout();
      tableLayoutPanel5.SuspendLayout();
      SuspendLayout();
      // 
      // label7
      // 
      label7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label7.AutoSize = true;
      label7.Font = new Font("Roboto", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
      label7.Location = new Point(3, 0);
      label7.Name = "label7";
      label7.Size = new Size(808, 60);
      label7.TabIndex = 3;
      label7.Text = "Cài đặt phiếu in";
      label7.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.BackColor = Color.LightGray;
      tableLayoutPanel1.ColumnCount = 1;
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.Controls.Add(label7, 0, 0);
      tableLayoutPanel1.Controls.Add(tableLayoutPanel4, 0, 4);
      tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 2);
      tableLayoutPanel1.Dock = DockStyle.Fill;
      tableLayoutPanel1.Location = new Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 6;
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
      tableLayoutPanel1.Size = new Size(814, 357);
      tableLayoutPanel1.TabIndex = 4;
      // 
      // tableLayoutPanel4
      // 
      tableLayoutPanel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel4.BackColor = Color.LightGray;
      tableLayoutPanel4.ColumnCount = 5;
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 3F));
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
      tableLayoutPanel4.Controls.Add(btnSave, 3, 0);
      tableLayoutPanel4.Controls.Add(btnCancel, 1, 0);
      tableLayoutPanel4.Location = new Point(0, 287);
      tableLayoutPanel4.Margin = new Padding(0);
      tableLayoutPanel4.Name = "tableLayoutPanel4";
      tableLayoutPanel4.RowCount = 1;
      tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel4.Size = new Size(814, 60);
      tableLayoutPanel4.TabIndex = 2;
      // 
      // btnSave
      // 
      btnSave.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      btnSave.BackColor = Color.FromArgb(49, 68, 108);
      btnSave.BackgroundColor = Color.FromArgb(49, 68, 108);
      btnSave.BorderColor = Color.PaleVioletRed;
      btnSave.BorderRadius = 5;
      btnSave.BorderSize = 0;
      btnSave.FlatAppearance.BorderSize = 0;
      btnSave.FlatStyle = FlatStyle.Flat;
      btnSave.Font = new Font("Roboto", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
      btnSave.ForeColor = Color.White;
      btnSave.Location = new Point(411, 5);
      btnSave.Name = "btnSave";
      btnSave.Size = new Size(194, 50);
      btnSave.TabIndex = 6;
      btnSave.Text = "Lưu";
      btnSave.TextColor = Color.White;
      btnSave.UseVisualStyleBackColor = false;
      btnSave.Click += btnSave_Click;
      // 
      // btnCancel
      // 
      btnCancel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      btnCancel.BackColor = Color.Tomato;
      btnCancel.BackgroundColor = Color.Tomato;
      btnCancel.BorderColor = Color.PaleVioletRed;
      btnCancel.BorderRadius = 5;
      btnCancel.BorderSize = 0;
      btnCancel.FlatAppearance.BorderSize = 0;
      btnCancel.FlatStyle = FlatStyle.Flat;
      btnCancel.Font = new Font("Roboto", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
      btnCancel.ForeColor = Color.White;
      btnCancel.Location = new Point(208, 5);
      btnCancel.Name = "btnCancel";
      btnCancel.Size = new Size(194, 50);
      btnCancel.TabIndex = 8;
      btnCancel.Text = "Thoát";
      btnCancel.TextColor = Color.White;
      btnCancel.UseVisualStyleBackColor = false;
      btnCancel.Click += btnCancel_Click;
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel2.ColumnCount = 2;
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.Controls.Add(tableLayoutPanel5, 1, 1);
      tableLayoutPanel2.Controls.Add(label1, 0, 1);
      tableLayoutPanel2.Controls.Add(label8, 0, 0);
      tableLayoutPanel2.Controls.Add(txtTitleName, 1, 0);
      tableLayoutPanel2.Location = new Point(3, 73);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 2;
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
      tableLayoutPanel2.Size = new Size(808, 181);
      tableLayoutPanel2.TabIndex = 4;
      // 
      // tableLayoutPanel5
      // 
      tableLayoutPanel5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel5.ColumnCount = 3;
      tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
      tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
      tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
      tableLayoutPanel5.Controls.Add(txtNumberPrint, 0, 0);
      tableLayoutPanel5.Controls.Add(btnUp, 2, 0);
      tableLayoutPanel5.Controls.Add(btnDown, 1, 0);
      tableLayoutPanel5.Location = new Point(232, 90);
      tableLayoutPanel5.Margin = new Padding(0);
      tableLayoutPanel5.Name = "tableLayoutPanel5";
      tableLayoutPanel5.RowCount = 1;
      tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel5.Size = new Size(576, 91);
      tableLayoutPanel5.TabIndex = 21;
      // 
      // txtNumberPrint
      // 
      txtNumberPrint.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      txtNumberPrint.BackColor = SystemColors.Window;
      txtNumberPrint.BorderColor = Color.Black;
      txtNumberPrint.BorderFocusColor = Color.FromArgb(228, 148, 1);
      txtNumberPrint.BorderRadius = 5;
      txtNumberPrint.BorderSize = 2;
      txtNumberPrint.Enabled = false;
      txtNumberPrint.Font = new Font("Roboto", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
      txtNumberPrint.ForeColor = Color.FromArgb(64, 64, 64);
      txtNumberPrint.Location = new Point(4, 21);
      txtNumberPrint.Margin = new Padding(4);
      txtNumberPrint.Multiline = false;
      txtNumberPrint.Name = "txtNumberPrint";
      txtNumberPrint.Padding = new Padding(10, 7, 10, 7);
      txtNumberPrint.PasswordChar = false;
      txtNumberPrint.PlaceholderColor = Color.DarkGray;
      txtNumberPrint.PlaceholderText = "";
      txtNumberPrint.Size = new Size(222, 48);
      txtNumberPrint.TabIndex = 22;
      txtNumberPrint.Texts = "1";
      txtNumberPrint.UnderlinedStyle = false;
      txtNumberPrint._TextChanged += txtNumericNumberPrint__TextChanged;
      txtNumberPrint.KeyPress += txtNumericNumberPrint_KeyPress;
      // 
      // btnUp
      // 
      btnUp.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      btnUp.BackColor = Color.FromArgb(49, 68, 108);
      btnUp.BackgroundColor = Color.FromArgb(49, 68, 108);
      btnUp.BorderColor = Color.PaleVioletRed;
      btnUp.BorderRadius = 5;
      btnUp.BorderSize = 0;
      btnUp.FlatAppearance.BorderSize = 0;
      btnUp.FlatStyle = FlatStyle.Flat;
      btnUp.Font = new Font("Roboto", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
      btnUp.ForeColor = Color.White;
      btnUp.Location = new Point(405, 20);
      btnUp.Name = "btnUp";
      btnUp.Size = new Size(168, 50);
      btnUp.TabIndex = 9;
      btnUp.Text = "Tăng";
      btnUp.TextColor = Color.White;
      btnUp.UseVisualStyleBackColor = false;
      btnUp.Click += btnUp_Click;
      // 
      // btnDown
      // 
      btnDown.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      btnDown.BackColor = Color.FromArgb(49, 68, 108);
      btnDown.BackgroundColor = Color.FromArgb(49, 68, 108);
      btnDown.BorderColor = Color.PaleVioletRed;
      btnDown.BorderRadius = 5;
      btnDown.BorderSize = 0;
      btnDown.FlatAppearance.BorderSize = 0;
      btnDown.FlatStyle = FlatStyle.Flat;
      btnDown.Font = new Font("Roboto", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
      btnDown.ForeColor = Color.White;
      btnDown.Location = new Point(233, 20);
      btnDown.Name = "btnDown";
      btnDown.Size = new Size(166, 50);
      btnDown.TabIndex = 23;
      btnDown.Text = "Giảm";
      btnDown.TextColor = Color.White;
      btnDown.UseVisualStyleBackColor = false;
      btnDown.Click += btnDown_Click;
      // 
      // label1
      // 
      label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label1.AutoSize = true;
      label1.Font = new Font("Roboto", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
      label1.Location = new Point(3, 90);
      label1.Name = "label1";
      label1.Size = new Size(226, 91);
      label1.TabIndex = 15;
      label1.Text = "Số lượng phiếu in";
      label1.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // label8
      // 
      label8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label8.AutoSize = true;
      label8.Font = new Font("Roboto", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
      label8.Location = new Point(3, 0);
      label8.Name = "label8";
      label8.Size = new Size(226, 90);
      label8.TabIndex = 20;
      label8.Text = "Phòng ban";
      label8.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // txtTitleName
      // 
      txtTitleName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      txtTitleName.BackColor = SystemColors.Window;
      txtTitleName.BorderColor = Color.Black;
      txtTitleName.BorderFocusColor = Color.FromArgb(228, 148, 1);
      txtTitleName.BorderRadius = 5;
      txtTitleName.BorderSize = 2;
      txtTitleName.Font = new Font("Roboto", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
      txtTitleName.ForeColor = Color.FromArgb(64, 64, 64);
      txtTitleName.Location = new Point(236, 21);
      txtTitleName.Margin = new Padding(4);
      txtTitleName.Multiline = false;
      txtTitleName.Name = "txtTitleName";
      txtTitleName.Padding = new Padding(10, 7, 10, 7);
      txtTitleName.PasswordChar = false;
      txtTitleName.PlaceholderColor = Color.DarkGray;
      txtTitleName.PlaceholderText = "";
      txtTitleName.Size = new Size(568, 48);
      txtTitleName.TabIndex = 8;
      txtTitleName.Texts = "";
      txtTitleName.UnderlinedStyle = false;
      // 
      // FrmEditQualityNumberPrinter
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(814, 357);
      ControlBox = false;
      Controls.Add(tableLayoutPanel1);
      Margin = new Padding(3, 2, 3, 2);
      MaximizeBox = false;
      MinimizeBox = false;
      Name = "FrmEditQualityNumberPrinter";
      ShowIcon = false;
      StartPosition = FormStartPosition.CenterParent;
      Text = " ";
      Load += FrmEditQualityNumberPrinter_Load;
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      tableLayoutPanel4.ResumeLayout(false);
      tableLayoutPanel2.ResumeLayout(false);
      tableLayoutPanel2.PerformLayout();
      tableLayoutPanel5.ResumeLayout(false);
      ResumeLayout(false);
    }

    #endregion

    private Label label7;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label8;
        private TableLayoutPanel tableLayoutPanel4;
        private Custom.RJButton btnSave;
        private Custom.RJButton btnCancel;
        private CustomControls.RJControls.RJTextBox txtTitleName;
        private TableLayoutPanel tableLayoutPanel5;
        private CustomControls.RJControls.RJTextBox txtNumberPrint;
        private Custom.RJButton btnDown;
        private Custom.RJButton btnUp;
    private TableLayoutPanel tableLayoutPanel2;
  }
}