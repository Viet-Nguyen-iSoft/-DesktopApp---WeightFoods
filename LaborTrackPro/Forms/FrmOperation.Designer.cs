namespace LaborTrackPro.Forms
{
  partial class FrmOperation
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOperation));
      tableLayoutPanel1 = new TableLayoutPanel();
      panelMenu = new TableLayoutPanel();
      flowLayoutPanel1 = new FlowLayoutPanel();
      btnHome = new LaborTrackPro.Custom.RJButton();
      btnMasterData = new LaborTrackPro.Custom.RJButton();
      btnEmployee = new LaborTrackPro.Custom.RJButton();
      tableLayoutPanel5 = new TableLayoutPanel();
      btnMenu = new PictureBox();
      tableLayoutPanel2 = new TableLayoutPanel();
      tableLayoutPanel4 = new TableLayoutPanel();
      btnClose = new PictureBox();
      tableLayoutPanel3 = new TableLayoutPanel();
      label1 = new Label();
      label2 = new Label();
      panelMain = new Panel();
      tableLayoutPanel1.SuspendLayout();
      panelMenu.SuspendLayout();
      flowLayoutPanel1.SuspendLayout();
      tableLayoutPanel5.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)btnMenu).BeginInit();
      tableLayoutPanel2.SuspendLayout();
      tableLayoutPanel4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)btnClose).BeginInit();
      tableLayoutPanel3.SuspendLayout();
      SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.BackColor = Color.White;
      tableLayoutPanel1.ColumnCount = 3;
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 5F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.Controls.Add(panelMenu, 0, 0);
      tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 2, 0);
      tableLayoutPanel1.Dock = DockStyle.Fill;
      tableLayoutPanel1.Location = new Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 1;
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.Size = new Size(982, 495);
      tableLayoutPanel1.TabIndex = 2;
      // 
      // panelMenu
      // 
      panelMenu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      panelMenu.BackColor = Color.White;
      panelMenu.ColumnCount = 1;
      panelMenu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      panelMenu.Controls.Add(flowLayoutPanel1, 0, 2);
      panelMenu.Controls.Add(tableLayoutPanel5, 0, 0);
      panelMenu.Location = new Point(0, 0);
      panelMenu.Margin = new Padding(0);
      panelMenu.Name = "panelMenu";
      panelMenu.RowCount = 3;
      panelMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
      panelMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 5F));
      panelMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      panelMenu.Size = new Size(250, 495);
      panelMenu.TabIndex = 1;
      // 
      // flowLayoutPanel1
      // 
      flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      flowLayoutPanel1.BackColor = Color.FromArgb(236, 236, 236);
      flowLayoutPanel1.Controls.Add(btnHome);
      flowLayoutPanel1.Controls.Add(btnMasterData);
      flowLayoutPanel1.Controls.Add(btnEmployee);
      flowLayoutPanel1.Location = new Point(0, 85);
      flowLayoutPanel1.Margin = new Padding(0);
      flowLayoutPanel1.Name = "flowLayoutPanel1";
      flowLayoutPanel1.Size = new Size(250, 410);
      flowLayoutPanel1.TabIndex = 0;
      // 
      // btnHome
      // 
      btnHome.BackColor = Color.Silver;
      btnHome.BackgroundColor = Color.Silver;
      btnHome.BorderColor = Color.PaleVioletRed;
      btnHome.BorderRadius = 5;
      btnHome.BorderSize = 0;
      btnHome.Dock = DockStyle.Top;
      btnHome.FlatAppearance.BorderSize = 0;
      btnHome.FlatStyle = FlatStyle.Flat;
      btnHome.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
      btnHome.ForeColor = Color.Black;
      btnHome.Image = (Image)resources.GetObject("btnHome.Image");
      btnHome.ImageAlign = ContentAlignment.MiddleLeft;
      btnHome.Location = new Point(3, 3);
      btnHome.Name = "btnHome";
      btnHome.Padding = new Padding(15, 0, 0, 0);
      btnHome.Size = new Size(242, 70);
      btnHome.TabIndex = 0;
      btnHome.Text = "       TRANG CHÍNH";
      btnHome.TextAlign = ContentAlignment.MiddleLeft;
      btnHome.TextColor = Color.Black;
      btnHome.UseVisualStyleBackColor = false;
      // 
      // btnMasterData
      // 
      btnMasterData.BackColor = Color.Silver;
      btnMasterData.BackgroundColor = Color.Silver;
      btnMasterData.BorderColor = Color.PaleVioletRed;
      btnMasterData.BorderRadius = 5;
      btnMasterData.BorderSize = 0;
      btnMasterData.Dock = DockStyle.Top;
      btnMasterData.FlatAppearance.BorderSize = 0;
      btnMasterData.FlatStyle = FlatStyle.Flat;
      btnMasterData.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
      btnMasterData.ForeColor = Color.Black;
      btnMasterData.Image = (Image)resources.GetObject("btnMasterData.Image");
      btnMasterData.ImageAlign = ContentAlignment.MiddleLeft;
      btnMasterData.Location = new Point(3, 79);
      btnMasterData.Name = "btnMasterData";
      btnMasterData.Padding = new Padding(15, 0, 0, 0);
      btnMasterData.Size = new Size(242, 70);
      btnMasterData.TabIndex = 2;
      btnMasterData.Text = "       DỮ LIỆU";
      btnMasterData.TextAlign = ContentAlignment.MiddleLeft;
      btnMasterData.TextColor = Color.Black;
      btnMasterData.UseVisualStyleBackColor = false;
      // 
      // btnEmployee
      // 
      btnEmployee.BackColor = Color.Silver;
      btnEmployee.BackgroundColor = Color.Silver;
      btnEmployee.BorderColor = Color.PaleVioletRed;
      btnEmployee.BorderRadius = 5;
      btnEmployee.BorderSize = 0;
      btnEmployee.Dock = DockStyle.Top;
      btnEmployee.FlatAppearance.BorderSize = 0;
      btnEmployee.FlatStyle = FlatStyle.Flat;
      btnEmployee.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
      btnEmployee.ForeColor = Color.Black;
      btnEmployee.Image = (Image)resources.GetObject("btnEmployee.Image");
      btnEmployee.ImageAlign = ContentAlignment.MiddleLeft;
      btnEmployee.Location = new Point(3, 155);
      btnEmployee.Name = "btnEmployee";
      btnEmployee.Padding = new Padding(15, 0, 0, 0);
      btnEmployee.Size = new Size(242, 70);
      btnEmployee.TabIndex = 4;
      btnEmployee.Text = "       NHÂN VIÊN";
      btnEmployee.TextAlign = ContentAlignment.MiddleLeft;
      btnEmployee.TextColor = Color.Black;
      btnEmployee.UseVisualStyleBackColor = false;
      // 
      // tableLayoutPanel5
      // 
      tableLayoutPanel5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel5.BackColor = Color.FromArgb(236, 236, 236);
      tableLayoutPanel5.ColumnCount = 2;
      tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
      tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel5.Controls.Add(btnMenu, 0, 0);
      tableLayoutPanel5.Location = new Point(0, 0);
      tableLayoutPanel5.Margin = new Padding(0);
      tableLayoutPanel5.Name = "tableLayoutPanel5";
      tableLayoutPanel5.RowCount = 1;
      tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel5.Size = new Size(250, 80);
      tableLayoutPanel5.TabIndex = 1;
      // 
      // btnMenu
      // 
      btnMenu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      btnMenu.Image = (Image)resources.GetObject("btnMenu.Image");
      btnMenu.Location = new Point(5, 5);
      btnMenu.Margin = new Padding(5);
      btnMenu.Name = "btnMenu";
      btnMenu.Size = new Size(70, 70);
      btnMenu.SizeMode = PictureBoxSizeMode.StretchImage;
      btnMenu.TabIndex = 0;
      btnMenu.TabStop = false;
      btnMenu.Click += btnMenu_Click;
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel2.BackColor = Color.White;
      tableLayoutPanel2.ColumnCount = 1;
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.Controls.Add(tableLayoutPanel4, 0, 0);
      tableLayoutPanel2.Controls.Add(panelMain, 0, 2);
      tableLayoutPanel2.Location = new Point(255, 0);
      tableLayoutPanel2.Margin = new Padding(0);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 3;
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 5F));
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.Size = new Size(727, 495);
      tableLayoutPanel2.TabIndex = 0;
      // 
      // tableLayoutPanel4
      // 
      tableLayoutPanel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel4.BackColor = Color.FromArgb(236, 236, 236);
      tableLayoutPanel4.ColumnCount = 2;
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
      tableLayoutPanel4.Controls.Add(btnClose, 1, 0);
      tableLayoutPanel4.Controls.Add(tableLayoutPanel3, 0, 0);
      tableLayoutPanel4.Location = new Point(0, 0);
      tableLayoutPanel4.Margin = new Padding(0);
      tableLayoutPanel4.Name = "tableLayoutPanel4";
      tableLayoutPanel4.RowCount = 1;
      tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel4.Size = new Size(727, 80);
      tableLayoutPanel4.TabIndex = 2;
      // 
      // btnClose
      // 
      btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      btnClose.Image = (Image)resources.GetObject("btnClose.Image");
      btnClose.Location = new Point(657, 10);
      btnClose.Margin = new Padding(10);
      btnClose.Name = "btnClose";
      btnClose.Size = new Size(60, 60);
      btnClose.SizeMode = PictureBoxSizeMode.StretchImage;
      btnClose.TabIndex = 21;
      btnClose.TabStop = false;
      btnClose.Click += btnClose_Click;
      // 
      // tableLayoutPanel3
      // 
      tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel3.ColumnCount = 1;
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel3.Controls.Add(label1, 0, 1);
      tableLayoutPanel3.Controls.Add(label2, 0, 0);
      tableLayoutPanel3.Location = new Point(3, 3);
      tableLayoutPanel3.Name = "tableLayoutPanel3";
      tableLayoutPanel3.RowCount = 2;
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle());
      tableLayoutPanel3.Size = new Size(641, 74);
      tableLayoutPanel3.TabIndex = 22;
      // 
      // label1
      // 
      label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label1.AutoSize = true;
      label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
      label1.Location = new Point(5, 44);
      label1.Margin = new Padding(5, 0, 0, 0);
      label1.Name = "label1";
      label1.Size = new Size(636, 30);
      label1.TabIndex = 4;
      label1.Text = "Trang chính";
      label1.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // label2
      // 
      label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label2.AutoSize = true;
      label2.Font = new Font("Segoe UI", 24.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
      label2.Location = new Point(0, 0);
      label2.Margin = new Padding(0);
      label2.Name = "label2";
      label2.Size = new Size(641, 44);
      label2.TabIndex = 3;
      label2.Text = "HỆ THỐNG CÂN HÀNG";
      label2.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // panelMain
      // 
      panelMain.BackColor = Color.FromArgb(236, 236, 236);
      panelMain.Dock = DockStyle.Fill;
      panelMain.Location = new Point(0, 85);
      panelMain.Margin = new Padding(0);
      panelMain.Name = "panelMain";
      panelMain.Size = new Size(727, 410);
      panelMain.TabIndex = 3;
      // 
      // FrmOperation
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.White;
      ClientSize = new Size(982, 495);
      Controls.Add(tableLayoutPanel1);
      Name = "FrmOperation";
      Text = "FrmOperation";
      tableLayoutPanel1.ResumeLayout(false);
      panelMenu.ResumeLayout(false);
      flowLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel5.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)btnMenu).EndInit();
      tableLayoutPanel2.ResumeLayout(false);
      tableLayoutPanel4.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)btnClose).EndInit();
      tableLayoutPanel3.ResumeLayout(false);
      tableLayoutPanel3.PerformLayout();
      ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private TableLayoutPanel panelMenu;
    private TableLayoutPanel tableLayoutPanel2;
    private TableLayoutPanel tableLayoutPanel4;
    private PictureBox btnClose;
    private FlowLayoutPanel flowLayoutPanel1;
    private Custom.RJButton btnHome;
    private Custom.RJButton btnMasterData;
    private Custom.RJButton btnEmployee;
    private TableLayoutPanel tableLayoutPanel5;
    private PictureBox btnMenu;
    private TableLayoutPanel tableLayoutPanel3;
    private Label label1;
    private Label label2;
    private Panel panelMain;
  }
}