namespace LaborTrackPro.Forms.Settings
{
  partial class FrmMaterial
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
      DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
      DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
      DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
      DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
      DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
      tableLayoutPanel1 = new TableLayoutPanel();
      tableLayoutPanel2 = new TableLayoutPanel();
      txtSearch = new CustomControls.RJControls.RJTextBox();
      btnSearch = new LaborTrackPro.Custom.RJButton();
      btnSyncImage = new LaborTrackPro.Custom.RJButton();
      cbbMaterialType = new ComboBox();
      dgvProductMaterial = new DataGridView();
      tableLayoutPanel1.SuspendLayout();
      tableLayoutPanel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)dgvProductMaterial).BeginInit();
      SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.BackColor = Color.White;
      tableLayoutPanel1.ColumnCount = 1;
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
      tableLayoutPanel1.Controls.Add(dgvProductMaterial, 0, 2);
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
      tableLayoutPanel1.Size = new Size(1605, 513);
      tableLayoutPanel1.TabIndex = 4;
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel2.BackColor = Color.White;
      tableLayoutPanel2.ColumnCount = 8;
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 935F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 15F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 15F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 15F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
      tableLayoutPanel2.Controls.Add(txtSearch, 0, 0);
      tableLayoutPanel2.Controls.Add(btnSearch, 4, 0);
      tableLayoutPanel2.Controls.Add(btnSyncImage, 7, 0);
      tableLayoutPanel2.Controls.Add(cbbMaterialType, 2, 0);
      tableLayoutPanel2.Location = new Point(10, 10);
      tableLayoutPanel2.Margin = new Padding(0);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 1;
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.Size = new Size(1585, 60);
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
      txtSearch.Font = new Font("Roboto", 20.25F);
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
      btnSearch.Font = new Font("Roboto", 20.25F, FontStyle.Bold);
      btnSearch.ForeColor = Color.White;
      btnSearch.Location = new Point(1168, 5);
      btnSearch.Name = "btnSearch";
      btnSearch.Size = new Size(194, 50);
      btnSearch.TabIndex = 8;
      btnSearch.Text = "Tìm kiếm";
      btnSearch.TextColor = Color.White;
      btnSearch.UseVisualStyleBackColor = false;
      btnSearch.Click += btnSearch_Click;
      // 
      // btnSyncImage
      // 
      btnSyncImage.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      btnSyncImage.BackColor = Color.FromArgb(49, 68, 108);
      btnSyncImage.BackgroundColor = Color.FromArgb(49, 68, 108);
      btnSyncImage.BorderColor = Color.PaleVioletRed;
      btnSyncImage.BorderRadius = 5;
      btnSyncImage.BorderSize = 0;
      btnSyncImage.FlatAppearance.BorderSize = 0;
      btnSyncImage.FlatStyle = FlatStyle.Flat;
      btnSyncImage.Font = new Font("Roboto", 20.25F, FontStyle.Bold);
      btnSyncImage.ForeColor = Color.White;
      btnSyncImage.Location = new Point(1388, 5);
      btnSyncImage.Name = "btnSyncImage";
      btnSyncImage.Size = new Size(194, 50);
      btnSyncImage.TabIndex = 9;
      btnSyncImage.Text = "Đồng bộ ảnh";
      btnSyncImage.TextColor = Color.White;
      btnSyncImage.UseVisualStyleBackColor = false;
      btnSyncImage.Click += btnSyncImage_Click;
      // 
      // cbbMaterialType
      // 
      cbbMaterialType.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      cbbMaterialType.DropDownStyle = ComboBoxStyle.DropDownList;
      cbbMaterialType.Font = new Font("Roboto Light", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
      cbbMaterialType.FormattingEnabled = true;
      cbbMaterialType.Items.AddRange(new object[] { "Tất cả", "Nguyên liệu", "Vật tư", "Bán thành phẩm", "Thành phẩm", "Phế phẩm" });
      cbbMaterialType.Location = new Point(953, 11);
      cbbMaterialType.Name = "cbbMaterialType";
      cbbMaterialType.Size = new Size(194, 37);
      cbbMaterialType.TabIndex = 10;
      // 
      // dgvProductMaterial
      // 
      dgvProductMaterial.AllowUserToAddRows = false;
      dgvProductMaterial.AllowUserToResizeRows = false;
      dataGridViewCellStyle11.BackColor = Color.White;
      dataGridViewCellStyle11.Font = new Font("Roboto Light", 14.25F);
      dgvProductMaterial.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
      dgvProductMaterial.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      dgvProductMaterial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
      dgvProductMaterial.BackgroundColor = Color.White;
      dgvProductMaterial.BorderStyle = BorderStyle.None;
      dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle12.BackColor = Color.FromArgb(228, 148, 1);
      dataGridViewCellStyle12.Font = new Font("Roboto", 14.25F, FontStyle.Bold);
      dataGridViewCellStyle12.ForeColor = SystemColors.Window;
      dataGridViewCellStyle12.SelectionBackColor = Color.FromArgb(228, 148, 1);
      dataGridViewCellStyle12.SelectionForeColor = SystemColors.Window;
      dataGridViewCellStyle12.WrapMode = DataGridViewTriState.True;
      dgvProductMaterial.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
      dgvProductMaterial.ColumnHeadersHeight = 45;
      dgvProductMaterial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle13.BackColor = SystemColors.Window;
      dataGridViewCellStyle13.Font = new Font("Roboto Light", 14.25F);
      dataGridViewCellStyle13.ForeColor = SystemColors.ControlText;
      dataGridViewCellStyle13.SelectionBackColor = SystemColors.Highlight;
      dataGridViewCellStyle13.SelectionForeColor = SystemColors.HighlightText;
      dataGridViewCellStyle13.WrapMode = DataGridViewTriState.False;
      dgvProductMaterial.DefaultCellStyle = dataGridViewCellStyle13;
      dgvProductMaterial.EnableHeadersVisualStyles = false;
      dgvProductMaterial.Location = new Point(13, 82);
      dgvProductMaterial.Margin = new Padding(3, 2, 3, 2);
      dgvProductMaterial.Name = "dgvProductMaterial";
      dgvProductMaterial.ReadOnly = true;
      dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle14.BackColor = SystemColors.Control;
      dataGridViewCellStyle14.Font = new Font("Roboto Light", 14.25F);
      dataGridViewCellStyle14.ForeColor = SystemColors.WindowText;
      dataGridViewCellStyle14.SelectionBackColor = SystemColors.Highlight;
      dataGridViewCellStyle14.SelectionForeColor = SystemColors.HighlightText;
      dataGridViewCellStyle14.WrapMode = DataGridViewTriState.True;
      dgvProductMaterial.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
      dgvProductMaterial.RowHeadersVisible = false;
      dgvProductMaterial.RowHeadersWidth = 30;
      dataGridViewCellStyle15.Font = new Font("Roboto Light", 14.25F);
      dgvProductMaterial.RowsDefaultCellStyle = dataGridViewCellStyle15;
      dgvProductMaterial.RowTemplate.Height = 45;
      dgvProductMaterial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      dgvProductMaterial.Size = new Size(1579, 419);
      dgvProductMaterial.TabIndex = 1;
      // 
      // FrmMaterial
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(1605, 513);
      Controls.Add(tableLayoutPanel1);
      Name = "FrmMaterial";
      Text = "FrmSettingProductMaterial";
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)dgvProductMaterial).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private TableLayoutPanel tableLayoutPanel2;
    private Custom.RJButton btnImport;
    private CustomControls.RJControls.RJTextBox txtSearch;
    private Custom.RJButton btnSearch;
    private DataGridView dgvProductMaterial;
    private Custom.RJButton btnSyncImage;
    private ComboBox cbbMaterialType;
  }
}