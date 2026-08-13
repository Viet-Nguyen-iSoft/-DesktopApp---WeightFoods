namespace LaborTrackPro.UserControls
{
  partial class UcPageData
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
      DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
      DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
      DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
      DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
      tableLayoutPanel1 = new TableLayoutPanel();
      dgvBody = new DataGridView();
      tableLayoutPanel2 = new TableLayoutPanel();
      btnNext = new LaborTrackPro.Custom.RJButton();
      btnPrevious = new LaborTrackPro.Custom.RJButton();
      lbTitlePage = new Label();
      tableLayoutPanel3 = new TableLayoutPanel();
      label2 = new Label();
      cbbNumberData = new ComboBox();
      tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)dgvBody).BeginInit();
      tableLayoutPanel2.SuspendLayout();
      tableLayoutPanel3.SuspendLayout();
      SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.ColumnCount = 1;
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.Controls.Add(dgvBody, 0, 0);
      tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 2);
      tableLayoutPanel1.Dock = DockStyle.Fill;
      tableLayoutPanel1.Location = new Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 4;
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 3F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 3F));
      tableLayoutPanel1.Size = new Size(1302, 581);
      tableLayoutPanel1.TabIndex = 0;
      // 
      // dgvBody
      // 
      dgvBody.AllowUserToAddRows = false;
      dgvBody.AllowUserToResizeRows = false;
      dataGridViewCellStyle1.BackColor = Color.White;
      dataGridViewCellStyle1.Font = new Font("Roboto Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
      dgvBody.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
      dgvBody.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      dgvBody.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      dgvBody.BackgroundColor = Color.White;
      dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle2.BackColor = Color.FromArgb(228, 148, 1);
      dataGridViewCellStyle2.Font = new Font("Roboto", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
      dataGridViewCellStyle2.ForeColor = SystemColors.Window;
      dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(228, 148, 1);
      dataGridViewCellStyle2.SelectionForeColor = SystemColors.Window;
      dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
      dgvBody.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
      dgvBody.ColumnHeadersHeight = 45;
      dgvBody.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle3.BackColor = SystemColors.Window;
      dataGridViewCellStyle3.Font = new Font("Roboto Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
      dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
      dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
      dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
      dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
      dgvBody.DefaultCellStyle = dataGridViewCellStyle3;
      dgvBody.EnableHeadersVisualStyles = false;
      dgvBody.Location = new Point(0, 0);
      dgvBody.Margin = new Padding(0);
      dgvBody.Name = "dgvBody";
      dgvBody.ReadOnly = true;
      dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle4.BackColor = SystemColors.Control;
      dataGridViewCellStyle4.Font = new Font("Roboto Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
      dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
      dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
      dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
      dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
      dgvBody.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
      dgvBody.RowHeadersVisible = false;
      dgvBody.RowHeadersWidth = 30;
      dataGridViewCellStyle5.Font = new Font("Roboto Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
      dgvBody.RowsDefaultCellStyle = dataGridViewCellStyle5;
      dgvBody.RowTemplate.Height = 45;
      dgvBody.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      dgvBody.Size = new Size(1302, 515);
      dgvBody.TabIndex = 10;
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel2.BackColor = Color.FromArgb(239, 242, 243);
      tableLayoutPanel2.ColumnCount = 5;
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
      tableLayoutPanel2.Controls.Add(btnNext, 3, 0);
      tableLayoutPanel2.Controls.Add(btnPrevious, 1, 0);
      tableLayoutPanel2.Controls.Add(lbTitlePage, 2, 0);
      tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 0);
      tableLayoutPanel2.Location = new Point(0, 518);
      tableLayoutPanel2.Margin = new Padding(0);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 1;
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.Size = new Size(1302, 60);
      tableLayoutPanel2.TabIndex = 11;
      // 
      // btnNext
      // 
      btnNext.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      btnNext.BackColor = Color.FromArgb(49, 68, 108);
      btnNext.BackgroundColor = Color.FromArgb(49, 68, 108);
      btnNext.BorderColor = Color.PaleVioletRed;
      btnNext.BorderRadius = 5;
      btnNext.BorderSize = 0;
      btnNext.FlatAppearance.BorderSize = 0;
      btnNext.FlatStyle = FlatStyle.Flat;
      btnNext.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
      btnNext.ForeColor = Color.White;
      btnNext.Location = new Point(729, 8);
      btnNext.Name = "btnNext";
      btnNext.Size = new Size(144, 44);
      btnNext.TabIndex = 0;
      btnNext.Text = ">>";
      btnNext.TextColor = Color.White;
      btnNext.UseVisualStyleBackColor = false;
      // 
      // btnPrevious
      // 
      btnPrevious.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      btnPrevious.BackColor = Color.FromArgb(49, 68, 108);
      btnPrevious.BackgroundColor = Color.FromArgb(49, 68, 108);
      btnPrevious.BorderColor = Color.PaleVioletRed;
      btnPrevious.BorderRadius = 5;
      btnPrevious.BorderSize = 0;
      btnPrevious.FlatAppearance.BorderSize = 0;
      btnPrevious.FlatStyle = FlatStyle.Flat;
      btnPrevious.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
      btnPrevious.ForeColor = Color.White;
      btnPrevious.Location = new Point(429, 8);
      btnPrevious.Name = "btnPrevious";
      btnPrevious.Size = new Size(144, 44);
      btnPrevious.TabIndex = 1;
      btnPrevious.Text = "<<";
      btnPrevious.TextColor = Color.White;
      btnPrevious.UseVisualStyleBackColor = false;
      // 
      // lbTitlePage
      // 
      lbTitlePage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      lbTitlePage.AutoSize = true;
      lbTitlePage.Font = new Font("Roboto", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
      lbTitlePage.ForeColor = Color.Black;
      lbTitlePage.Location = new Point(579, 0);
      lbTitlePage.Name = "lbTitlePage";
      lbTitlePage.Size = new Size(144, 60);
      lbTitlePage.TabIndex = 4;
      lbTitlePage.Text = "0/0";
      lbTitlePage.TextAlign = ContentAlignment.MiddleCenter;
      // 
      // tableLayoutPanel3
      // 
      tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel3.ColumnCount = 3;
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel3.Controls.Add(label2, 0, 0);
      tableLayoutPanel3.Controls.Add(cbbNumberData, 1, 0);
      tableLayoutPanel3.Location = new Point(0, 0);
      tableLayoutPanel3.Margin = new Padding(0);
      tableLayoutPanel3.Name = "tableLayoutPanel3";
      tableLayoutPanel3.RowCount = 1;
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel3.Size = new Size(426, 60);
      tableLayoutPanel3.TabIndex = 5;
      // 
      // label2
      // 
      label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label2.AutoSize = true;
      label2.Font = new Font("Roboto Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
      label2.ForeColor = Color.Black;
      label2.Location = new Point(3, 0);
      label2.Name = "label2";
      label2.Size = new Size(177, 60);
      label2.TabIndex = 5;
      label2.Text = "Số dữ liệu mỗi trang";
      label2.TextAlign = ContentAlignment.MiddleCenter;
      // 
      // cbbNumberData
      // 
      cbbNumberData.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      cbbNumberData.DropDownStyle = ComboBoxStyle.DropDownList;
      cbbNumberData.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
      cbbNumberData.FormattingEnabled = true;
      cbbNumberData.Items.AddRange(new object[] { "10", "20", "50", "100", "200", "500", "Tất cả" });
      cbbNumberData.Location = new Point(186, 7);
      cbbNumberData.Name = "cbbNumberData";
      cbbNumberData.Size = new Size(194, 45);
      cbbNumberData.TabIndex = 6;
      // 
      // UcPageData
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      Controls.Add(tableLayoutPanel1);
      Name = "UcPageData";
      Size = new Size(1302, 581);
      tableLayoutPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)dgvBody).EndInit();
      tableLayoutPanel2.ResumeLayout(false);
      tableLayoutPanel2.PerformLayout();
      tableLayoutPanel3.ResumeLayout(false);
      tableLayoutPanel3.PerformLayout();
      ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private DataGridView dgvBody;
    private TableLayoutPanel tableLayoutPanel2;
    private Custom.RJButton btnNext;
    private Custom.RJButton btnPrevious;
    private Label lbTitlePage;
    private TableLayoutPanel tableLayoutPanel3;
    private Label label2;
    private ComboBox cbbNumberData;
  }
}
