namespace LaborTrackPro.Setting
{
  partial class FrmEmployee
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
      DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
      DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
      DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
      DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
      tableLayoutPanel1 = new TableLayoutPanel();
      tableLayoutPanel2 = new TableLayoutPanel();
      btnAddNew = new LaborTrackPro.Custom.RJButton();
      txtSearch = new CustomControls.RJControls.RJTextBox();
      btnSearch = new LaborTrackPro.Custom.RJButton();
      btnSyncData = new LaborTrackPro.Custom.RJButton();
      dgv = new DataGridView();
      tableLayoutPanel1.SuspendLayout();
      tableLayoutPanel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
      SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.BackColor = Color.White;
      tableLayoutPanel1.ColumnCount = 1;
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
      tableLayoutPanel1.Controls.Add(dgv, 0, 2);
      tableLayoutPanel1.Dock = DockStyle.Fill;
      tableLayoutPanel1.Location = new Point(0, 0);
      tableLayoutPanel1.Margin = new Padding(0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.Padding = new Padding(10);
      tableLayoutPanel1.RowCount = 3;
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel1.Size = new Size(1589, 540);
      tableLayoutPanel1.TabIndex = 2;
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel2.BackColor = Color.White;
      tableLayoutPanel2.ColumnCount = 5;
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 935F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 15F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
      tableLayoutPanel2.Controls.Add(btnAddNew, 3, 0);
      tableLayoutPanel2.Controls.Add(txtSearch, 0, 0);
      tableLayoutPanel2.Controls.Add(btnSearch, 2, 0);
      tableLayoutPanel2.Controls.Add(btnSyncData, 4, 0);
      tableLayoutPanel2.Location = new Point(10, 10);
      tableLayoutPanel2.Margin = new Padding(0);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 1;
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.Size = new Size(1569, 60);
      tableLayoutPanel2.TabIndex = 0;
      // 
      // btnAddNew
      // 
      btnAddNew.Anchor = AnchorStyles.Right;
      btnAddNew.BackColor = Color.FromArgb(49, 68, 108);
      btnAddNew.BackgroundColor = Color.FromArgb(49, 68, 108);
      btnAddNew.BorderColor = Color.PaleVioletRed;
      btnAddNew.BorderRadius = 5;
      btnAddNew.BorderSize = 0;
      btnAddNew.FlatAppearance.BorderSize = 0;
      btnAddNew.FlatStyle = FlatStyle.Flat;
      btnAddNew.Font = new Font("Roboto", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
      btnAddNew.ForeColor = Color.White;
      btnAddNew.Location = new Point(1365, 5);
      btnAddNew.Name = "btnAddNew";
      btnAddNew.Size = new Size(1, 50);
      btnAddNew.TabIndex = 6;
      btnAddNew.Text = "Thêm mới";
      btnAddNew.TextColor = Color.White;
      btnAddNew.UseVisualStyleBackColor = false;
      btnAddNew.Visible = false;
      btnAddNew.Click += btnAddNew_Click;
      // 
      // txtSearch
      // 
      txtSearch.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      txtSearch.BackColor = SystemColors.Window;
      txtSearch.BorderColor = Color.Black;
      txtSearch.BorderFocusColor = Color.FromArgb(49, 68, 108);
      txtSearch.BorderRadius = 5;
      txtSearch.BorderSize = 2;
      txtSearch.Font = new Font("Roboto", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
      txtSearch.ForeColor = Color.FromArgb(64, 64, 64);
      txtSearch.Location = new Point(4, 6);
      txtSearch.Margin = new Padding(4);
      txtSearch.Multiline = false;
      txtSearch.Name = "txtSearch";
      txtSearch.Padding = new Padding(10, 7, 10, 7);
      txtSearch.PasswordChar = false;
      txtSearch.PlaceholderColor = Color.DarkGray;
      txtSearch.PlaceholderText = "";
      txtSearch.Size = new Size(927, 48);
      txtSearch.TabIndex = 7;
      txtSearch.Texts = "";
      txtSearch.UnderlinedStyle = false;
      txtSearch._TextChanged += txtSearch__TextChanged;
      // 
      // btnSearch
      // 
      btnSearch.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      btnSearch.BackColor = Color.FromArgb(49, 68, 108);
      btnSearch.BackgroundColor = Color.FromArgb(49, 68, 108);
      btnSearch.BorderColor = Color.PaleVioletRed;
      btnSearch.BorderRadius = 5;
      btnSearch.BorderSize = 0;
      btnSearch.FlatAppearance.BorderSize = 0;
      btnSearch.FlatStyle = FlatStyle.Flat;
      btnSearch.Font = new Font("Roboto", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
      btnSearch.ForeColor = Color.White;
      btnSearch.Location = new Point(953, 5);
      btnSearch.Name = "btnSearch";
      btnSearch.Size = new Size(194, 50);
      btnSearch.TabIndex = 8;
      btnSearch.Text = "Tìm kiếm";
      btnSearch.TextColor = Color.White;
      btnSearch.UseVisualStyleBackColor = false;
      btnSearch.Click += btnSearch_Click;
      // 
      // btnSyncData
      // 
      btnSyncData.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      btnSyncData.BackColor = Color.FromArgb(49, 68, 108);
      btnSyncData.BackgroundColor = Color.FromArgb(49, 68, 108);
      btnSyncData.BorderColor = Color.PaleVioletRed;
      btnSyncData.BorderRadius = 5;
      btnSyncData.BorderSize = 0;
      btnSyncData.FlatAppearance.BorderSize = 0;
      btnSyncData.FlatStyle = FlatStyle.Flat;
      btnSyncData.Font = new Font("Roboto", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
      btnSyncData.ForeColor = Color.White;
      btnSyncData.Location = new Point(1372, 5);
      btnSyncData.Name = "btnSyncData";
      btnSyncData.Size = new Size(194, 50);
      btnSyncData.TabIndex = 9;
      btnSyncData.Text = "Đồng bộ";
      btnSyncData.TextColor = Color.White;
      btnSyncData.UseVisualStyleBackColor = false;
      btnSyncData.Visible = false;
      btnSyncData.Click += btnSyncData_Click;
      // 
      // dgv
      // 
      dgv.AllowUserToAddRows = false;
      dgv.AllowUserToResizeRows = false;
      dataGridViewCellStyle1.BackColor = Color.White;
      dataGridViewCellStyle1.Font = new Font("Roboto Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
      dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
      dgv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      dgv.BackgroundColor = Color.White;
      dgv.BorderStyle = BorderStyle.None;
      dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle2.BackColor = Color.FromArgb(228, 148, 1);
      dataGridViewCellStyle2.Font = new Font("Roboto", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
      dataGridViewCellStyle2.ForeColor = SystemColors.Window;
      dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(228, 148, 1);
      dataGridViewCellStyle2.SelectionForeColor = SystemColors.Window;
      dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
      dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
      dgv.ColumnHeadersHeight = 45;
      dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle3.BackColor = SystemColors.Window;
      dataGridViewCellStyle3.Font = new Font("Roboto Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
      dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
      dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
      dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
      dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
      dgv.DefaultCellStyle = dataGridViewCellStyle3;
      dgv.EnableHeadersVisualStyles = false;
      dgv.Location = new Point(13, 82);
      dgv.Margin = new Padding(3, 2, 3, 2);
      dgv.Name = "dgv";
      dgv.ReadOnly = true;
      dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle4.BackColor = SystemColors.Control;
      dataGridViewCellStyle4.Font = new Font("Roboto Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
      dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
      dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
      dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
      dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
      dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
      dgv.RowHeadersVisible = false;
      dgv.RowHeadersWidth = 30;
      dataGridViewCellStyle5.Font = new Font("Roboto Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
      dgv.RowsDefaultCellStyle = dataGridViewCellStyle5;
      dgv.RowTemplate.Height = 45;
      dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      dgv.Size = new Size(1563, 446);
      dgv.TabIndex = 2;
      // 
      // FrmEmployee
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(1589, 540);
      Controls.Add(tableLayoutPanel1);
      Name = "FrmEmployee";
      Text = "FrmEmployee";
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private TableLayoutPanel tableLayoutPanel2;
    private Custom.RJButton btnAddNew;
    private CustomControls.RJControls.RJTextBox txtSearch;
    private Custom.RJButton btnSearch;
    private DataGridView dgv;
    private Custom.RJButton btnSyncData;
  }
}