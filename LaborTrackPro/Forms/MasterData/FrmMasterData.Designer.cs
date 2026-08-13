namespace LaborTrackPro.Forms.Settings
{
  partial class FrmMasterData
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMasterData));
      tableLayoutPanel1 = new TableLayoutPanel();
      tableLayoutPanel3 = new TableLayoutPanel();
      btnEmployee = new LaborTrackPro.Custom.RJButton();
      btnMaterial = new LaborTrackPro.Custom.RJButton();
      btnOrderProduct = new LaborTrackPro.Custom.RJButton();
      btnDepartment = new LaborTrackPro.Custom.RJButton();
      btnProduct = new LaborTrackPro.Custom.RJButton();
      pnlBody = new Panel();
      tableLayoutPanel2 = new TableLayoutPanel();
      tableLayoutPanel4 = new TableLayoutPanel();
      pictureBox1 = new PictureBox();
      label2 = new Label();
      tableLayoutPanel1.SuspendLayout();
      tableLayoutPanel3.SuspendLayout();
      tableLayoutPanel2.SuspendLayout();
      tableLayoutPanel4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
      SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.BackColor = Color.White;
      tableLayoutPanel1.ColumnCount = 3;
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 5F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 5F));
      tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 1, 3);
      tableLayoutPanel1.Controls.Add(pnlBody, 1, 4);
      tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 1);
      tableLayoutPanel1.Dock = DockStyle.Fill;
      tableLayoutPanel1.Location = new Point(0, 0);
      tableLayoutPanel1.Margin = new Padding(0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 6;
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 18F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 83F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 18F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 18F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel1.Size = new Size(1674, 723);
      tableLayoutPanel1.TabIndex = 1;
      // 
      // tableLayoutPanel3
      // 
      tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel3.ColumnCount = 12;
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel3.Controls.Add(btnEmployee, 0, 0);
      tableLayoutPanel3.Controls.Add(btnMaterial, 8, 0);
      tableLayoutPanel3.Controls.Add(btnOrderProduct, 4, 0);
      tableLayoutPanel3.Controls.Add(btnDepartment, 2, 0);
      tableLayoutPanel3.Controls.Add(btnProduct, 6, 0);
      tableLayoutPanel3.Location = new Point(20, 119);
      tableLayoutPanel3.Margin = new Padding(15, 0, 15, 0);
      tableLayoutPanel3.Name = "tableLayoutPanel3";
      tableLayoutPanel3.RowCount = 1;
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel3.Size = new Size(1634, 58);
      tableLayoutPanel3.TabIndex = 2;
      // 
      // btnEmployee
      // 
      btnEmployee.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      btnEmployee.BackColor = Color.FromArgb(228, 148, 1);
      btnEmployee.BackgroundColor = Color.FromArgb(228, 148, 1);
      btnEmployee.BorderColor = Color.PaleVioletRed;
      btnEmployee.BorderRadius = 5;
      btnEmployee.BorderSize = 0;
      btnEmployee.FlatAppearance.BorderSize = 0;
      btnEmployee.FlatStyle = FlatStyle.Flat;
      btnEmployee.Font = new Font("Roboto", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
      btnEmployee.ForeColor = Color.White;
      btnEmployee.Location = new Point(0, 0);
      btnEmployee.Margin = new Padding(0);
      btnEmployee.Name = "btnEmployee";
      btnEmployee.Size = new Size(220, 58);
      btnEmployee.TabIndex = 9;
      btnEmployee.Text = "Nhân viên";
      btnEmployee.TextColor = Color.White;
      btnEmployee.UseVisualStyleBackColor = false;
      btnEmployee.Click += btnEmployee_Click;
      // 
      // btnMaterial
      // 
      btnMaterial.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      btnMaterial.BackColor = Color.FromArgb(239, 242, 243);
      btnMaterial.BackgroundColor = Color.FromArgb(239, 242, 243);
      btnMaterial.BorderColor = Color.PaleVioletRed;
      btnMaterial.BorderRadius = 5;
      btnMaterial.BorderSize = 0;
      btnMaterial.FlatAppearance.BorderSize = 0;
      btnMaterial.FlatStyle = FlatStyle.Flat;
      btnMaterial.Font = new Font("Roboto", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
      btnMaterial.ForeColor = Color.Black;
      btnMaterial.Location = new Point(900, 0);
      btnMaterial.Margin = new Padding(0);
      btnMaterial.Name = "btnMaterial";
      btnMaterial.Size = new Size(300, 58);
      btnMaterial.TabIndex = 11;
      btnMaterial.Text = "Nguyên liệu - Vật tư";
      btnMaterial.TextColor = Color.Black;
      btnMaterial.UseVisualStyleBackColor = false;
      btnMaterial.Click += btnMaterial_Click;
      // 
      // btnOrderProduct
      // 
      btnOrderProduct.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      btnOrderProduct.BackColor = Color.FromArgb(239, 242, 243);
      btnOrderProduct.BackgroundColor = Color.FromArgb(239, 242, 243);
      btnOrderProduct.BorderColor = Color.PaleVioletRed;
      btnOrderProduct.BorderRadius = 5;
      btnOrderProduct.BorderSize = 0;
      btnOrderProduct.FlatAppearance.BorderSize = 0;
      btnOrderProduct.FlatStyle = FlatStyle.Flat;
      btnOrderProduct.Font = new Font("Roboto", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
      btnOrderProduct.ForeColor = Color.Black;
      btnOrderProduct.Location = new Point(460, 0);
      btnOrderProduct.Margin = new Padding(0);
      btnOrderProduct.Name = "btnOrderProduct";
      btnOrderProduct.Size = new Size(220, 58);
      btnOrderProduct.TabIndex = 12;
      btnOrderProduct.Text = "Lệnh sản xuất";
      btnOrderProduct.TextColor = Color.Black;
      btnOrderProduct.UseVisualStyleBackColor = false;
      btnOrderProduct.Click += btnOrderProduct_Click;
      // 
      // btnDepartment
      // 
      btnDepartment.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      btnDepartment.BackColor = Color.FromArgb(239, 242, 243);
      btnDepartment.BackgroundColor = Color.FromArgb(239, 242, 243);
      btnDepartment.BorderColor = Color.PaleVioletRed;
      btnDepartment.BorderRadius = 5;
      btnDepartment.BorderSize = 0;
      btnDepartment.FlatAppearance.BorderSize = 0;
      btnDepartment.FlatStyle = FlatStyle.Flat;
      btnDepartment.Font = new Font("Roboto", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
      btnDepartment.ForeColor = Color.Black;
      btnDepartment.Location = new Point(230, 0);
      btnDepartment.Margin = new Padding(0);
      btnDepartment.Name = "btnDepartment";
      btnDepartment.Size = new Size(220, 58);
      btnDepartment.TabIndex = 13;
      btnDepartment.Text = "Phòng ban";
      btnDepartment.TextColor = Color.Black;
      btnDepartment.UseVisualStyleBackColor = false;
      btnDepartment.Click += btnDepartment_Click;
      // 
      // btnProduct
      // 
      btnProduct.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      btnProduct.BackColor = Color.FromArgb(239, 242, 243);
      btnProduct.BackgroundColor = Color.FromArgb(239, 242, 243);
      btnProduct.BorderColor = Color.PaleVioletRed;
      btnProduct.BorderRadius = 5;
      btnProduct.BorderSize = 0;
      btnProduct.FlatAppearance.BorderSize = 0;
      btnProduct.FlatStyle = FlatStyle.Flat;
      btnProduct.Font = new Font("Roboto", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
      btnProduct.ForeColor = Color.Black;
      btnProduct.Location = new Point(690, 0);
      btnProduct.Margin = new Padding(0);
      btnProduct.Name = "btnProduct";
      btnProduct.Size = new Size(200, 58);
      btnProduct.TabIndex = 14;
      btnProduct.Text = "Sản phẩm";
      btnProduct.TextColor = Color.Black;
      btnProduct.UseVisualStyleBackColor = false;
      btnProduct.Click += btnProduct_Click;
      // 
      // pnlBody
      // 
      pnlBody.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      pnlBody.Location = new Point(5, 177);
      pnlBody.Margin = new Padding(0);
      pnlBody.Name = "pnlBody";
      pnlBody.Size = new Size(1664, 528);
      pnlBody.TabIndex = 3;
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel2.BackColor = Color.FromArgb(239, 242, 243);
      tableLayoutPanel2.ColumnCount = 3;
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 15F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 15F));
      tableLayoutPanel2.Controls.Add(tableLayoutPanel4, 1, 1);
      tableLayoutPanel2.Location = new Point(20, 18);
      tableLayoutPanel2.Margin = new Padding(15, 0, 15, 0);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 3;
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
      tableLayoutPanel2.Size = new Size(1634, 83);
      tableLayoutPanel2.TabIndex = 6;
      // 
      // tableLayoutPanel4
      // 
      tableLayoutPanel4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel4.ColumnCount = 4;
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 58F));
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 15F));
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle());
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel4.Controls.Add(pictureBox1, 0, 0);
      tableLayoutPanel4.Controls.Add(label2, 2, 0);
      tableLayoutPanel4.Location = new Point(15, 12);
      tableLayoutPanel4.Margin = new Padding(0);
      tableLayoutPanel4.Name = "tableLayoutPanel4";
      tableLayoutPanel4.RowCount = 1;
      tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel4.Size = new Size(1604, 58);
      tableLayoutPanel4.TabIndex = 4;
      // 
      // pictureBox1
      // 
      pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
      pictureBox1.Location = new Point(3, 3);
      pictureBox1.Name = "pictureBox1";
      pictureBox1.Size = new Size(52, 52);
      pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      pictureBox1.TabIndex = 7;
      pictureBox1.TabStop = false;
      // 
      // label2
      // 
      label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label2.AutoSize = true;
      label2.Font = new Font("Roboto", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
      label2.Location = new Point(76, 0);
      label2.Name = "label2";
      label2.Size = new Size(259, 58);
      label2.TabIndex = 1;
      label2.Text = "DỮ LIỆU TRẠM CÂN";
      label2.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // FrmMasterData
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(1674, 723);
      Controls.Add(tableLayoutPanel1);
      Name = "FrmMasterData";
      Text = "FrmMasterData";
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel3.ResumeLayout(false);
      tableLayoutPanel2.ResumeLayout(false);
      tableLayoutPanel4.ResumeLayout(false);
      tableLayoutPanel4.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private TableLayoutPanel tableLayoutPanel3;
    private Custom.RJButton btnEmployee;
    private Custom.RJButton btnMaterial;
    private Custom.RJButton btnOrderProduct;
    private Custom.RJButton btnDepartment;
    private Panel pnlBody;
    private TableLayoutPanel tableLayoutPanel2;
    private TableLayoutPanel tableLayoutPanel4;
    private PictureBox pictureBox1;
    private Label label2;
    private Custom.RJButton btnProduct;
  }
}