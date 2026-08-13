namespace LaborTrackPro.Forms.MasterData
{
  partial class FrmProduction
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
      DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
      DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
      DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
      DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
      DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
      tableLayoutPanel1 = new TableLayoutPanel();
      tableLayoutPanel2 = new TableLayoutPanel();
      txtSearch = new CustomControls.RJControls.RJTextBox();
      btnSearch = new LaborTrackPro.Custom.RJButton();
      dgv = new DataGridView();
      No = new DataGridViewTextBoxColumn();
      NameProductionOrder = new DataGridViewTextBoxColumn();
      Code = new DataGridViewTextBoxColumn();
      Description = new DataGridViewTextBoxColumn();
      Column2 = new DataGridViewTextBoxColumn();
      Created = new DataGridViewTextBoxColumn();
      Update = new DataGridViewTextBoxColumn();
      btnDetail = new DataGridViewButtonColumn();
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
      tableLayoutPanel1.Size = new Size(1852, 600);
      tableLayoutPanel1.TabIndex = 6;
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel2.BackColor = Color.White;
      tableLayoutPanel2.ColumnCount = 4;
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 935F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 15F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.Controls.Add(txtSearch, 0, 0);
      tableLayoutPanel2.Controls.Add(btnSearch, 2, 0);
      tableLayoutPanel2.Location = new Point(10, 10);
      tableLayoutPanel2.Margin = new Padding(0);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 1;
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.Size = new Size(1832, 60);
      tableLayoutPanel2.TabIndex = 0;
      // 
      // txtSearch
      // 
      txtSearch.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      txtSearch.BackColor = SystemColors.Window;
      txtSearch.BorderColor = Color.Black;
      txtSearch.BorderFocusColor = Color.FromArgb(228, 148, 1);
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
      dgv.Columns.AddRange(new DataGridViewColumn[] { No, NameProductionOrder, Code, Description, Column2, Created, Update, btnDetail });
      dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle5.BackColor = SystemColors.Window;
      dataGridViewCellStyle5.Font = new Font("Roboto Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
      dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
      dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
      dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
      dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
      dgv.DefaultCellStyle = dataGridViewCellStyle5;
      dgv.EnableHeadersVisualStyles = false;
      dgv.Location = new Point(13, 82);
      dgv.Margin = new Padding(3, 2, 3, 2);
      dgv.Name = "dgv";
      dgv.ReadOnly = true;
      dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle6.BackColor = SystemColors.Control;
      dataGridViewCellStyle6.Font = new Font("Roboto Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
      dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
      dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
      dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
      dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
      dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
      dgv.RowHeadersVisible = false;
      dgv.RowHeadersWidth = 30;
      dataGridViewCellStyle7.Font = new Font("Roboto Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
      dgv.RowsDefaultCellStyle = dataGridViewCellStyle7;
      dgv.RowTemplate.Height = 45;
      dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      dgv.Size = new Size(1826, 506);
      dgv.TabIndex = 2;
      // 
      // No
      // 
      No.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
      No.DataPropertyName = "No";
      dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
      No.DefaultCellStyle = dataGridViewCellStyle3;
      No.HeaderText = "Stt";
      No.Name = "No";
      No.ReadOnly = true;
      No.Width = 59;
      // 
      // NameProductionOrder
      // 
      NameProductionOrder.DataPropertyName = "Name";
      NameProductionOrder.HeaderText = "Tên sản phẩm";
      NameProductionOrder.Name = "NameProductionOrder";
      NameProductionOrder.ReadOnly = true;
      // 
      // Code
      // 
      Code.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      Code.DataPropertyName = "Code";
      Code.HeaderText = "Mã";
      Code.Name = "Code";
      Code.ReadOnly = true;
      Code.Width = 62;
      // 
      // Description
      // 
      Description.DataPropertyName = "Description";
      Description.HeaderText = "Mô tả";
      Description.Name = "Description";
      Description.ReadOnly = true;
      // 
      // Column2
      // 
      Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
      Column2.DataPropertyName = "MaterialNumbers";
      dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
      Column2.DefaultCellStyle = dataGridViewCellStyle4;
      Column2.HeaderText = "Số nguyên liệu-vật tư";
      Column2.Name = "Column2";
      Column2.ReadOnly = true;
      Column2.Width = 219;
      // 
      // Created
      // 
      Created.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      Created.DataPropertyName = "CreatedAt";
      Created.HeaderText = "Ngày tạo";
      Created.Name = "Created";
      Created.ReadOnly = true;
      Created.Width = 111;
      // 
      // Update
      // 
      Update.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      Update.DataPropertyName = "UpdatedAt";
      Update.HeaderText = "Cập nhật";
      Update.Name = "Update";
      Update.ReadOnly = true;
      Update.Width = 111;
      // 
      // btnDetail
      // 
      btnDetail.HeaderText = "";
      btnDetail.Name = "btnDetail";
      btnDetail.ReadOnly = true;
      btnDetail.Text = "Chi tiết";
      btnDetail.UseColumnTextForButtonValue = true;
      // 
      // FrmProduction
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(1852, 600);
      Controls.Add(tableLayoutPanel1);
      Name = "FrmProduction";
      Text = "FrmProduction";
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private TableLayoutPanel tableLayoutPanel2;
    private CustomControls.RJControls.RJTextBox txtSearch;
    private Custom.RJButton btnSearch;
    private DataGridView dgv;
    private DataGridViewTextBoxColumn No;
    private DataGridViewTextBoxColumn NameProductionOrder;
    private DataGridViewTextBoxColumn Code;
    private DataGridViewTextBoxColumn Description;
    private DataGridViewTextBoxColumn Column2;
    private DataGridViewTextBoxColumn Created;
    private DataGridViewTextBoxColumn Update;
    private DataGridViewButtonColumn btnDetail;
  }
}