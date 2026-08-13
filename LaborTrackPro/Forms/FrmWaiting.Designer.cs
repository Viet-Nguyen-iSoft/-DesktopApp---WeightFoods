namespace LaborTrackPro.Forms
{
  partial class FrmWaiting
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
      lbDepartment = new Label();
      pictureBoxLogo = new PictureBox();
      lbOperator = new Label();
      lbHello = new Label();
      tableLayoutPanel2 = new TableLayoutPanel();
      btnMenu = new PictureBox();
      lbStatusConnectServer = new Label();
      tableLayoutPanel3 = new TableLayoutPanel();
      lbVersion = new Label();
      lbStatusHID = new Label();
      tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
      tableLayoutPanel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)btnMenu).BeginInit();
      tableLayoutPanel3.SuspendLayout();
      SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.BackColor = Color.White;
      tableLayoutPanel1.ColumnCount = 1;
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.Controls.Add(lbDepartment, 0, 5);
      tableLayoutPanel1.Controls.Add(pictureBoxLogo, 0, 1);
      tableLayoutPanel1.Controls.Add(lbOperator, 0, 4);
      tableLayoutPanel1.Controls.Add(lbHello, 0, 3);
      tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
      tableLayoutPanel1.Controls.Add(lbStatusConnectServer, 0, 6);
      tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 8);
      tableLayoutPanel1.Dock = DockStyle.Fill;
      tableLayoutPanel1.Location = new Point(0, 0);
      tableLayoutPanel1.Margin = new Padding(0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 10;
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 200F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle());
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
      tableLayoutPanel1.Size = new Size(1285, 1047);
      tableLayoutPanel1.TabIndex = 0;
      // 
      // lbDepartment
      // 
      lbDepartment.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      lbDepartment.AutoSize = true;
      lbDepartment.Font = new Font("Microsoft Sans Serif", 30F, FontStyle.Regular, GraphicsUnit.Point, 0);
      lbDepartment.ForeColor = Color.Black;
      lbDepartment.Location = new Point(3, 742);
      lbDepartment.Name = "lbDepartment";
      lbDepartment.Size = new Size(1279, 100);
      lbDepartment.TabIndex = 22;
      lbDepartment.Text = "Hello";
      lbDepartment.TextAlign = ContentAlignment.MiddleCenter;
      lbDepartment.Visible = false;
      // 
      // pictureBoxLogo
      // 
      pictureBoxLogo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
      pictureBoxLogo.Image = Properties.Resources.HSFLogo;
      pictureBoxLogo.Location = new Point(339, 200);
      pictureBoxLogo.Margin = new Padding(0);
      pictureBoxLogo.Name = "pictureBoxLogo";
      pictureBoxLogo.Size = new Size(607, 222);
      pictureBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
      pictureBoxLogo.TabIndex = 0;
      pictureBoxLogo.TabStop = false;
      pictureBoxLogo.Click += pictureBoxLogo_Click;
      // 
      // lbOperator
      // 
      lbOperator.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      lbOperator.AutoSize = true;
      lbOperator.Font = new Font("Microsoft Sans Serif", 60F, FontStyle.Bold);
      lbOperator.ForeColor = Color.Black;
      lbOperator.Location = new Point(3, 622);
      lbOperator.Name = "lbOperator";
      lbOperator.Size = new Size(1279, 120);
      lbOperator.TabIndex = 16;
      lbOperator.Text = "Hello";
      lbOperator.TextAlign = ContentAlignment.MiddleCenter;
      lbOperator.Visible = false;
      // 
      // lbHello
      // 
      lbHello.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      lbHello.AutoSize = true;
      lbHello.Font = new Font("Microsoft Sans Serif", 39.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
      lbHello.ForeColor = Color.FromArgb(228, 148, 1);
      lbHello.Location = new Point(3, 522);
      lbHello.Name = "lbHello";
      lbHello.Size = new Size(1279, 100);
      lbHello.TabIndex = 15;
      lbHello.Text = "Welcome";
      lbHello.TextAlign = ContentAlignment.MiddleCenter;
      lbHello.Visible = false;
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel2.ColumnCount = 1;
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
      tableLayoutPanel2.Controls.Add(btnMenu, 0, 0);
      tableLayoutPanel2.Location = new Point(3, 3);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 1;
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.Size = new Size(1279, 194);
      tableLayoutPanel2.TabIndex = 19;
      // 
      // btnMenu
      // 
      btnMenu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      btnMenu.Image = Properties.Resources.icon_menu_app;
      btnMenu.Location = new Point(1204, 10);
      btnMenu.Margin = new Padding(3, 10, 10, 3);
      btnMenu.Name = "btnMenu";
      btnMenu.Size = new Size(65, 58);
      btnMenu.SizeMode = PictureBoxSizeMode.StretchImage;
      btnMenu.TabIndex = 19;
      btnMenu.TabStop = false;
      btnMenu.Click += btnMenu_Click;
      // 
      // lbStatusConnectServer
      // 
      lbStatusConnectServer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      lbStatusConnectServer.AutoSize = true;
      lbStatusConnectServer.Font = new Font("Microsoft Sans Serif", 30F);
      lbStatusConnectServer.ForeColor = Color.Red;
      lbStatusConnectServer.Location = new Point(3, 842);
      lbStatusConnectServer.Name = "lbStatusConnectServer";
      lbStatusConnectServer.Size = new Size(1279, 100);
      lbStatusConnectServer.TabIndex = 21;
      lbStatusConnectServer.Text = "Mất kết nối Server. Vui lòng kiểm tra đường truyền";
      lbStatusConnectServer.TextAlign = ContentAlignment.MiddleCenter;
      lbStatusConnectServer.Visible = false;
      // 
      // tableLayoutPanel3
      // 
      tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel3.ColumnCount = 3;
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
      tableLayoutPanel3.Controls.Add(lbVersion, 0, 0);
      tableLayoutPanel3.Controls.Add(lbStatusHID, 2, 0);
      tableLayoutPanel3.Location = new Point(0, 982);
      tableLayoutPanel3.Margin = new Padding(0);
      tableLayoutPanel3.Name = "tableLayoutPanel3";
      tableLayoutPanel3.RowCount = 1;
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel3.Size = new Size(1285, 50);
      tableLayoutPanel3.TabIndex = 20;
      // 
      // lbVersion
      // 
      lbVersion.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      lbVersion.AutoSize = true;
      lbVersion.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold);
      lbVersion.ForeColor = Color.FromArgb(228, 148, 1);
      lbVersion.Location = new Point(0, 0);
      lbVersion.Margin = new Padding(0);
      lbVersion.Name = "lbVersion";
      lbVersion.Padding = new Padding(30, 0, 0, 0);
      lbVersion.Size = new Size(886, 50);
      lbVersion.TabIndex = 14;
      lbVersion.Text = "Copyright @ 2025 i-Soft JSC. All rights reserved.  | Version 1.0.0";
      lbVersion.TextAlign = ContentAlignment.MiddleLeft;
      lbVersion.Click += label2_Click;
      // 
      // lbStatusHID
      // 
      lbStatusHID.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      lbStatusHID.AutoSize = true;
      lbStatusHID.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Italic);
      lbStatusHID.ForeColor = Color.Red;
      lbStatusHID.Location = new Point(955, 0);
      lbStatusHID.Name = "lbStatusHID";
      lbStatusHID.Padding = new Padding(0, 0, 30, 0);
      lbStatusHID.Size = new Size(327, 50);
      lbStatusHID.TabIndex = 21;
      lbStatusHID.Text = "Mất kết nối đọc thẻ HID";
      lbStatusHID.TextAlign = ContentAlignment.MiddleRight;
      // 
      // FrmWaiting
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(1285, 1047);
      Controls.Add(tableLayoutPanel1);
      Name = "FrmWaiting";
      StartPosition = FormStartPosition.CenterParent;
      Text = "FrmWaiting";
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
      tableLayoutPanel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)btnMenu).EndInit();
      tableLayoutPanel3.ResumeLayout(false);
      tableLayoutPanel3.PerformLayout();
      ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private PictureBox pictureBoxLogo;
    private Label lbHello;
    private Label lbOperator;
    private Label lbVersion;
    private TableLayoutPanel tableLayoutPanel2;
    private TableLayoutPanel tableLayoutPanel3;
    private PictureBox btnMenu;
    private Label lbStatusHID;
    private Label lbStatusConnectServer;
    private Label lbDepartment;
  }
}