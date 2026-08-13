namespace LaborTrackPro.Forms
{
  partial class FrmDatetimePicker
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
      tableLayoutPanel1 = new TableLayoutPanel();
      tableLayoutPanel4 = new TableLayoutPanel();
      lbDatetimeCurrent = new Label();
      flowLayoutPanel1 = new FlowLayoutPanel();
      tableLayoutPanel2 = new TableLayoutPanel();
      label7 = new Label();
      label6 = new Label();
      label5 = new Label();
      label4 = new Label();
      label3 = new Label();
      label1 = new Label();
      label2 = new Label();
      tableLayoutPanel3 = new TableLayoutPanel();
      btnNextYear = new LaborTrackPro.Custom.RJButton();
      btnBackYear = new LaborTrackPro.Custom.RJButton();
      lbYearCurrent = new Label();
      btnBackMonth = new LaborTrackPro.Custom.RJButton();
      btnNextMonth = new LaborTrackPro.Custom.RJButton();
      lbMonthCurrent = new Label();
      btnExit = new LaborTrackPro.Custom.RJButton();
      btnToday = new Button();
      tableLayoutPanel1.SuspendLayout();
      tableLayoutPanel4.SuspendLayout();
      tableLayoutPanel2.SuspendLayout();
      tableLayoutPanel3.SuspendLayout();
      SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.ColumnCount = 1;
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.Controls.Add(tableLayoutPanel4, 0, 3);
      tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 2);
      tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
      tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 0);
      tableLayoutPanel1.Dock = DockStyle.Fill;
      tableLayoutPanel1.Location = new Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 4;
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
      tableLayoutPanel1.Size = new Size(1068, 537);
      tableLayoutPanel1.TabIndex = 0;
      // 
      // tableLayoutPanel4
      // 
      tableLayoutPanel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel4.BackColor = Color.White;
      tableLayoutPanel4.ColumnCount = 2;
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
      tableLayoutPanel4.Controls.Add(btnToday, 0, 0);
      tableLayoutPanel4.Controls.Add(lbDatetimeCurrent, 1, 0);
      tableLayoutPanel4.Location = new Point(3, 480);
      tableLayoutPanel4.Name = "tableLayoutPanel4";
      tableLayoutPanel4.RowCount = 1;
      tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel4.Size = new Size(1062, 54);
      tableLayoutPanel4.TabIndex = 3;
      // 
      // lbDatetimeCurrent
      // 
      lbDatetimeCurrent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      lbDatetimeCurrent.AutoSize = true;
      lbDatetimeCurrent.BackColor = Color.White;
      lbDatetimeCurrent.Font = new Font("Roboto", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
      lbDatetimeCurrent.ForeColor = Color.Black;
      lbDatetimeCurrent.Location = new Point(534, 3);
      lbDatetimeCurrent.Margin = new Padding(3);
      lbDatetimeCurrent.Name = "lbDatetimeCurrent";
      lbDatetimeCurrent.Size = new Size(525, 48);
      lbDatetimeCurrent.TabIndex = 3;
      lbDatetimeCurrent.Text = "2025";
      lbDatetimeCurrent.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // flowLayoutPanel1
      // 
      flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      flowLayoutPanel1.Location = new Point(3, 113);
      flowLayoutPanel1.Name = "flowLayoutPanel1";
      flowLayoutPanel1.Size = new Size(1062, 361);
      flowLayoutPanel1.TabIndex = 0;
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel2.BackColor = Color.FromArgb(49, 68, 108);
      tableLayoutPanel2.ColumnCount = 7;
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
      tableLayoutPanel2.Controls.Add(label7, 6, 0);
      tableLayoutPanel2.Controls.Add(label6, 5, 0);
      tableLayoutPanel2.Controls.Add(label5, 4, 0);
      tableLayoutPanel2.Controls.Add(label4, 3, 0);
      tableLayoutPanel2.Controls.Add(label3, 2, 0);
      tableLayoutPanel2.Controls.Add(label1, 1, 0);
      tableLayoutPanel2.Controls.Add(label2, 0, 0);
      tableLayoutPanel2.Location = new Point(3, 60);
      tableLayoutPanel2.Margin = new Padding(3, 0, 3, 0);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 1;
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.Size = new Size(1062, 50);
      tableLayoutPanel2.TabIndex = 1;
      // 
      // label7
      // 
      label7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label7.AutoSize = true;
      label7.BackColor = Color.White;
      label7.Font = new Font("Roboto", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
      label7.ForeColor = Color.Black;
      label7.Location = new Point(909, 3);
      label7.Margin = new Padding(3);
      label7.Name = "label7";
      label7.Size = new Size(150, 44);
      label7.TabIndex = 8;
      label7.Text = "Chủ nhật";
      label7.TextAlign = ContentAlignment.MiddleCenter;
      // 
      // label6
      // 
      label6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label6.AutoSize = true;
      label6.BackColor = Color.White;
      label6.Font = new Font("Roboto", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
      label6.ForeColor = Color.Black;
      label6.Location = new Point(758, 3);
      label6.Margin = new Padding(3);
      label6.Name = "label6";
      label6.Size = new Size(145, 44);
      label6.TabIndex = 7;
      label6.Text = "Thứ 7";
      label6.TextAlign = ContentAlignment.MiddleCenter;
      // 
      // label5
      // 
      label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label5.AutoSize = true;
      label5.BackColor = Color.White;
      label5.Font = new Font("Roboto", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
      label5.ForeColor = Color.Black;
      label5.Location = new Point(607, 3);
      label5.Margin = new Padding(3);
      label5.Name = "label5";
      label5.Size = new Size(145, 44);
      label5.TabIndex = 6;
      label5.Text = "Thứ 6";
      label5.TextAlign = ContentAlignment.MiddleCenter;
      // 
      // label4
      // 
      label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label4.AutoSize = true;
      label4.BackColor = Color.White;
      label4.Font = new Font("Roboto", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
      label4.ForeColor = Color.Black;
      label4.Location = new Point(456, 3);
      label4.Margin = new Padding(3);
      label4.Name = "label4";
      label4.Size = new Size(145, 44);
      label4.TabIndex = 5;
      label4.Text = "Thứ 5";
      label4.TextAlign = ContentAlignment.MiddleCenter;
      // 
      // label3
      // 
      label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label3.AutoSize = true;
      label3.BackColor = Color.White;
      label3.Font = new Font("Roboto", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
      label3.ForeColor = Color.Black;
      label3.Location = new Point(305, 3);
      label3.Margin = new Padding(3);
      label3.Name = "label3";
      label3.Size = new Size(145, 44);
      label3.TabIndex = 4;
      label3.Text = "Thứ 4";
      label3.TextAlign = ContentAlignment.MiddleCenter;
      // 
      // label1
      // 
      label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label1.AutoSize = true;
      label1.BackColor = Color.White;
      label1.Font = new Font("Roboto", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
      label1.ForeColor = Color.Black;
      label1.Location = new Point(154, 3);
      label1.Margin = new Padding(3);
      label1.Name = "label1";
      label1.Size = new Size(145, 44);
      label1.TabIndex = 3;
      label1.Text = "Thứ 3";
      label1.TextAlign = ContentAlignment.MiddleCenter;
      // 
      // label2
      // 
      label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label2.AutoSize = true;
      label2.BackColor = Color.White;
      label2.Font = new Font("Roboto", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
      label2.ForeColor = Color.Black;
      label2.Location = new Point(3, 3);
      label2.Margin = new Padding(3);
      label2.Name = "label2";
      label2.Size = new Size(145, 44);
      label2.TabIndex = 2;
      label2.Text = "Thứ 2";
      label2.TextAlign = ContentAlignment.MiddleCenter;
      // 
      // tableLayoutPanel3
      // 
      tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel3.BackColor = Color.White;
      tableLayoutPanel3.ColumnCount = 9;
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66.6666641F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
      tableLayoutPanel3.Controls.Add(btnNextYear, 2, 0);
      tableLayoutPanel3.Controls.Add(btnBackYear, 0, 0);
      tableLayoutPanel3.Controls.Add(lbYearCurrent, 1, 0);
      tableLayoutPanel3.Controls.Add(btnBackMonth, 4, 0);
      tableLayoutPanel3.Controls.Add(btnNextMonth, 6, 0);
      tableLayoutPanel3.Controls.Add(lbMonthCurrent, 5, 0);
      tableLayoutPanel3.Controls.Add(btnExit, 8, 0);
      tableLayoutPanel3.Location = new Point(3, 3);
      tableLayoutPanel3.Name = "tableLayoutPanel3";
      tableLayoutPanel3.RowCount = 1;
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel3.Size = new Size(1062, 54);
      tableLayoutPanel3.TabIndex = 2;
      // 
      // btnNextYear
      // 
      btnNextYear.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      btnNextYear.BackColor = Color.Silver;
      btnNextYear.BackgroundColor = Color.Silver;
      btnNextYear.BorderColor = Color.PaleVioletRed;
      btnNextYear.BorderRadius = 5;
      btnNextYear.BorderSize = 0;
      btnNextYear.FlatAppearance.BorderSize = 0;
      btnNextYear.FlatStyle = FlatStyle.Flat;
      btnNextYear.Font = new Font("Roboto", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
      btnNextYear.ForeColor = Color.Black;
      btnNextYear.Location = new Point(203, 7);
      btnNextYear.Name = "btnNextYear";
      btnNextYear.Size = new Size(94, 40);
      btnNextYear.TabIndex = 5;
      btnNextYear.Text = ">";
      btnNextYear.TextColor = Color.Black;
      btnNextYear.UseVisualStyleBackColor = false;
      btnNextYear.Click += btnNextYear_Click;
      // 
      // btnBackYear
      // 
      btnBackYear.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      btnBackYear.BackColor = Color.Silver;
      btnBackYear.BackgroundColor = Color.Silver;
      btnBackYear.BorderColor = Color.PaleVioletRed;
      btnBackYear.BorderRadius = 5;
      btnBackYear.BorderSize = 0;
      btnBackYear.FlatAppearance.BorderSize = 0;
      btnBackYear.FlatStyle = FlatStyle.Flat;
      btnBackYear.Font = new Font("Roboto", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
      btnBackYear.ForeColor = Color.Black;
      btnBackYear.Location = new Point(3, 7);
      btnBackYear.Name = "btnBackYear";
      btnBackYear.Size = new Size(94, 40);
      btnBackYear.TabIndex = 4;
      btnBackYear.Text = "<";
      btnBackYear.TextColor = Color.Black;
      btnBackYear.UseVisualStyleBackColor = false;
      btnBackYear.Click += btnBackYear_Click;
      // 
      // lbYearCurrent
      // 
      lbYearCurrent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      lbYearCurrent.AutoSize = true;
      lbYearCurrent.BackColor = Color.White;
      lbYearCurrent.Font = new Font("Roboto", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
      lbYearCurrent.ForeColor = Color.Black;
      lbYearCurrent.Location = new Point(103, 3);
      lbYearCurrent.Margin = new Padding(3);
      lbYearCurrent.Name = "lbYearCurrent";
      lbYearCurrent.Size = new Size(94, 48);
      lbYearCurrent.TabIndex = 3;
      lbYearCurrent.Text = "2025";
      lbYearCurrent.TextAlign = ContentAlignment.MiddleCenter;
      // 
      // btnBackMonth
      // 
      btnBackMonth.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      btnBackMonth.BackColor = Color.Silver;
      btnBackMonth.BackgroundColor = Color.Silver;
      btnBackMonth.BorderColor = Color.PaleVioletRed;
      btnBackMonth.BorderRadius = 5;
      btnBackMonth.BorderSize = 0;
      btnBackMonth.FlatAppearance.BorderSize = 0;
      btnBackMonth.FlatStyle = FlatStyle.Flat;
      btnBackMonth.Font = new Font("Roboto", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
      btnBackMonth.ForeColor = Color.Black;
      btnBackMonth.Location = new Point(380, 7);
      btnBackMonth.Name = "btnBackMonth";
      btnBackMonth.Size = new Size(94, 40);
      btnBackMonth.TabIndex = 6;
      btnBackMonth.Text = "<";
      btnBackMonth.TextColor = Color.Black;
      btnBackMonth.UseVisualStyleBackColor = false;
      btnBackMonth.Click += btnBackMonth_Click;
      // 
      // btnNextMonth
      // 
      btnNextMonth.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      btnNextMonth.BackColor = Color.Silver;
      btnNextMonth.BackgroundColor = Color.Silver;
      btnNextMonth.BorderColor = Color.PaleVioletRed;
      btnNextMonth.BorderRadius = 5;
      btnNextMonth.BorderSize = 0;
      btnNextMonth.FlatAppearance.BorderSize = 0;
      btnNextMonth.FlatStyle = FlatStyle.Flat;
      btnNextMonth.Font = new Font("Roboto", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
      btnNextMonth.ForeColor = Color.Black;
      btnNextMonth.Location = new Point(680, 7);
      btnNextMonth.Name = "btnNextMonth";
      btnNextMonth.Size = new Size(94, 40);
      btnNextMonth.TabIndex = 7;
      btnNextMonth.Text = ">";
      btnNextMonth.TextColor = Color.Black;
      btnNextMonth.UseVisualStyleBackColor = false;
      btnNextMonth.Click += btnNextMonth_Click;
      // 
      // lbMonthCurrent
      // 
      lbMonthCurrent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      lbMonthCurrent.AutoSize = true;
      lbMonthCurrent.BackColor = Color.White;
      lbMonthCurrent.Font = new Font("Roboto", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
      lbMonthCurrent.ForeColor = Color.Black;
      lbMonthCurrent.Location = new Point(480, 3);
      lbMonthCurrent.Margin = new Padding(3);
      lbMonthCurrent.Name = "lbMonthCurrent";
      lbMonthCurrent.Size = new Size(194, 48);
      lbMonthCurrent.TabIndex = 8;
      lbMonthCurrent.Text = "Tháng 1";
      lbMonthCurrent.TextAlign = ContentAlignment.MiddleCenter;
      // 
      // btnExit
      // 
      btnExit.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      btnExit.BackColor = Color.FromArgb(49, 68, 108);
      btnExit.BackgroundColor = Color.FromArgb(49, 68, 108);
      btnExit.BorderColor = Color.PaleVioletRed;
      btnExit.BorderRadius = 5;
      btnExit.BorderSize = 0;
      btnExit.FlatAppearance.BorderSize = 0;
      btnExit.FlatStyle = FlatStyle.Flat;
      btnExit.Font = new Font("Roboto", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
      btnExit.ForeColor = Color.White;
      btnExit.Location = new Point(934, 3);
      btnExit.Name = "btnExit";
      btnExit.Size = new Size(125, 48);
      btnExit.TabIndex = 9;
      btnExit.Text = "Thoát";
      btnExit.TextColor = Color.White;
      btnExit.UseVisualStyleBackColor = false;
      btnExit.Click += btnExit_Click;
      // 
      // btnToday
      // 
      btnToday.Anchor = AnchorStyles.Right;
      btnToday.BackColor = Color.LightGreen;
      btnToday.FlatAppearance.BorderSize = 0;
      btnToday.FlatStyle = FlatStyle.Flat;
      btnToday.Font = new Font("Roboto", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
      btnToday.Location = new Point(380, 8);
      btnToday.Name = "btnToday";
      btnToday.Size = new Size(148, 38);
      btnToday.TabIndex = 0;
      btnToday.Text = "Hôm nay";
      btnToday.UseVisualStyleBackColor = false;
      btnToday.Click += btnToday_Click;
      // 
      // FrmDatetimePicker
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(1068, 537);
      ControlBox = false;
      Controls.Add(tableLayoutPanel1);
      Name = "FrmDatetimePicker";
      StartPosition = FormStartPosition.CenterParent;
      Text = " ";
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel4.ResumeLayout(false);
      tableLayoutPanel4.PerformLayout();
      tableLayoutPanel2.ResumeLayout(false);
      tableLayoutPanel2.PerformLayout();
      tableLayoutPanel3.ResumeLayout(false);
      tableLayoutPanel3.PerformLayout();
      ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private FlowLayoutPanel flowLayoutPanel1;
    private TableLayoutPanel tableLayoutPanel2;
    private Label label7;
    private Label label6;
    private Label label5;
    private Label label4;
    private Label label3;
    private Label label1;
    private Label label2;
    private TableLayoutPanel tableLayoutPanel3;
    private Label lbYearCurrent;
    private Custom.RJButton btnBackYear;
    private Custom.RJButton btnNextYear;
    private Custom.RJButton btnBackMonth;
    private Custom.RJButton btnNextMonth;
    private Label lbMonthCurrent;
    private TableLayoutPanel tableLayoutPanel4;
    private Label lbDatetimeCurrent;
    private Custom.RJButton btnExit;
    private Button btnToday;
  }
}