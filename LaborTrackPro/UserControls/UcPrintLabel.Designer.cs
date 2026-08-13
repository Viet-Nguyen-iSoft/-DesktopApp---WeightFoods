namespace LaborTrackPro.UserControls
{
  partial class UcPrintLabel
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
      picStatus = new PictureBox();
      panel1 = new Panel();
      tableLayoutPanel1 = new TableLayoutPanel();
      lbInternalExternal = new Label();
      tableLayoutPanel2 = new TableLayoutPanel();
      lbNameLabel = new Label();
      tableLayoutPanel3 = new TableLayoutPanel();
      lbMRCode = new Label();
      tableLayoutPanel12 = new TableLayoutPanel();
      lbTare = new Label();
      label19 = new Label();
      tableLayoutPanel11 = new TableLayoutPanel();
      lbDepartment = new Label();
      label17 = new Label();
      tableLayoutPanel10 = new TableLayoutPanel();
      lbOperator = new Label();
      label15 = new Label();
      tableLayoutPanel9 = new TableLayoutPanel();
      lbDate = new Label();
      label13 = new Label();
      tableLayoutPanel8 = new TableLayoutPanel();
      lbNet = new Label();
      label11 = new Label();
      tableLayoutPanel4 = new TableLayoutPanel();
      lbPO = new Label();
      label2 = new Label();
      lbMRName = new Label();
      ((System.ComponentModel.ISupportInitialize)picStatus).BeginInit();
      panel1.SuspendLayout();
      tableLayoutPanel1.SuspendLayout();
      tableLayoutPanel2.SuspendLayout();
      tableLayoutPanel3.SuspendLayout();
      tableLayoutPanel12.SuspendLayout();
      tableLayoutPanel11.SuspendLayout();
      tableLayoutPanel10.SuspendLayout();
      tableLayoutPanel9.SuspendLayout();
      tableLayoutPanel8.SuspendLayout();
      tableLayoutPanel4.SuspendLayout();
      SuspendLayout();
      // 
      // picStatus
      // 
      picStatus.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      picStatus.Image = Properties.Resources.icon_confirm;
      picStatus.Location = new Point(337, 3);
      picStatus.Name = "picStatus";
      picStatus.Size = new Size(44, 44);
      picStatus.SizeMode = PictureBoxSizeMode.StretchImage;
      picStatus.TabIndex = 0;
      picStatus.TabStop = false;
      picStatus.Visible = false;
      // 
      // panel1
      // 
      panel1.BackColor = Color.Transparent;
      panel1.Controls.Add(tableLayoutPanel1);
      panel1.Dock = DockStyle.Fill;
      panel1.Location = new Point(0, 0);
      panel1.Margin = new Padding(0);
      panel1.Name = "panel1";
      panel1.Size = new Size(390, 500);
      panel1.TabIndex = 3;
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.ColumnCount = 1;
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.Controls.Add(lbInternalExternal, 0, 1);
      tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
      tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 2);
      tableLayoutPanel1.Dock = DockStyle.Fill;
      tableLayoutPanel1.Location = new Point(0, 0);
      tableLayoutPanel1.Margin = new Padding(0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.Padding = new Padding(3);
      tableLayoutPanel1.RowCount = 3;
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.Size = new Size(390, 500);
      tableLayoutPanel1.TabIndex = 1;
      // 
      // lbInternalExternal
      // 
      lbInternalExternal.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      lbInternalExternal.AutoSize = true;
      lbInternalExternal.Font = new Font("Microsoft Sans Serif", 12.75F);
      lbInternalExternal.Location = new Point(6, 53);
      lbInternalExternal.Name = "lbInternalExternal";
      lbInternalExternal.Size = new Size(378, 40);
      lbInternalExternal.TabIndex = 3;
      lbInternalExternal.Text = "...";
      lbInternalExternal.TextAlign = ContentAlignment.MiddleCenter;
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel2.ColumnCount = 3;
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
      tableLayoutPanel2.Controls.Add(picStatus, 2, 0);
      tableLayoutPanel2.Controls.Add(lbNameLabel, 1, 0);
      tableLayoutPanel2.Location = new Point(3, 3);
      tableLayoutPanel2.Margin = new Padding(0);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 1;
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.Size = new Size(384, 50);
      tableLayoutPanel2.TabIndex = 1;
      // 
      // lbNameLabel
      // 
      lbNameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      lbNameLabel.AutoSize = true;
      lbNameLabel.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
      lbNameLabel.Location = new Point(53, 0);
      lbNameLabel.Name = "lbNameLabel";
      lbNameLabel.Size = new Size(278, 50);
      lbNameLabel.TabIndex = 1;
      lbNameLabel.Text = "PHIẾU CÂN";
      lbNameLabel.TextAlign = ContentAlignment.MiddleCenter;
      // 
      // tableLayoutPanel3
      // 
      tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel3.ColumnCount = 1;
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel3.Controls.Add(lbMRCode, 0, 2);
      tableLayoutPanel3.Controls.Add(tableLayoutPanel12, 0, 7);
      tableLayoutPanel3.Controls.Add(tableLayoutPanel11, 0, 6);
      tableLayoutPanel3.Controls.Add(tableLayoutPanel10, 0, 5);
      tableLayoutPanel3.Controls.Add(tableLayoutPanel9, 0, 4);
      tableLayoutPanel3.Controls.Add(tableLayoutPanel8, 0, 3);
      tableLayoutPanel3.Controls.Add(tableLayoutPanel4, 0, 0);
      tableLayoutPanel3.Controls.Add(lbMRName, 0, 1);
      tableLayoutPanel3.Location = new Point(3, 93);
      tableLayoutPanel3.Margin = new Padding(0);
      tableLayoutPanel3.Name = "tableLayoutPanel3";
      tableLayoutPanel3.RowCount = 8;
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 12.499999F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 12.499999F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel3.Size = new Size(384, 404);
      tableLayoutPanel3.TabIndex = 2;
      // 
      // lbMRCode
      // 
      lbMRCode.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      lbMRCode.AutoSize = true;
      lbMRCode.Font = new Font("Microsoft Sans Serif", 12.75F);
      lbMRCode.Location = new Point(3, 100);
      lbMRCode.Name = "lbMRCode";
      lbMRCode.Size = new Size(378, 50);
      lbMRCode.TabIndex = 13;
      lbMRCode.Text = "...";
      lbMRCode.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // tableLayoutPanel12
      // 
      tableLayoutPanel12.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel12.ColumnCount = 2;
      tableLayoutPanel12.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 125F));
      tableLayoutPanel12.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel12.Controls.Add(lbTare, 1, 0);
      tableLayoutPanel12.Controls.Add(label19, 0, 0);
      tableLayoutPanel12.Location = new Point(0, 350);
      tableLayoutPanel12.Margin = new Padding(0);
      tableLayoutPanel12.Name = "tableLayoutPanel12";
      tableLayoutPanel12.RowCount = 1;
      tableLayoutPanel12.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel12.Size = new Size(384, 54);
      tableLayoutPanel12.TabIndex = 12;
      // 
      // lbTare
      // 
      lbTare.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      lbTare.AutoSize = true;
      lbTare.Font = new Font("Microsoft Sans Serif", 12.75F);
      lbTare.Location = new Point(128, 0);
      lbTare.Name = "lbTare";
      lbTare.Size = new Size(253, 54);
      lbTare.TabIndex = 3;
      lbTare.Text = "...";
      lbTare.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // label19
      // 
      label19.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label19.AutoSize = true;
      label19.Font = new Font("Microsoft Sans Serif", 12.75F);
      label19.Location = new Point(3, 0);
      label19.Name = "label19";
      label19.Size = new Size(119, 54);
      label19.TabIndex = 2;
      label19.Text = "Tare:";
      label19.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // tableLayoutPanel11
      // 
      tableLayoutPanel11.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel11.ColumnCount = 2;
      tableLayoutPanel11.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 125F));
      tableLayoutPanel11.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel11.Controls.Add(lbDepartment, 1, 0);
      tableLayoutPanel11.Controls.Add(label17, 0, 0);
      tableLayoutPanel11.Location = new Point(0, 300);
      tableLayoutPanel11.Margin = new Padding(0);
      tableLayoutPanel11.Name = "tableLayoutPanel11";
      tableLayoutPanel11.RowCount = 1;
      tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel11.Size = new Size(384, 50);
      tableLayoutPanel11.TabIndex = 11;
      // 
      // lbDepartment
      // 
      lbDepartment.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      lbDepartment.AutoSize = true;
      lbDepartment.Font = new Font("Microsoft Sans Serif", 12.75F);
      lbDepartment.Location = new Point(128, 0);
      lbDepartment.Name = "lbDepartment";
      lbDepartment.Size = new Size(253, 50);
      lbDepartment.TabIndex = 3;
      lbDepartment.Text = "...";
      lbDepartment.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // label17
      // 
      label17.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label17.AutoSize = true;
      label17.Font = new Font("Microsoft Sans Serif", 12.75F);
      label17.Location = new Point(3, 0);
      label17.Name = "label17";
      label17.Size = new Size(119, 50);
      label17.TabIndex = 2;
      label17.Text = "Phòng ban:";
      label17.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // tableLayoutPanel10
      // 
      tableLayoutPanel10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel10.ColumnCount = 2;
      tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 125F));
      tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel10.Controls.Add(lbOperator, 1, 0);
      tableLayoutPanel10.Controls.Add(label15, 0, 0);
      tableLayoutPanel10.Location = new Point(0, 250);
      tableLayoutPanel10.Margin = new Padding(0);
      tableLayoutPanel10.Name = "tableLayoutPanel10";
      tableLayoutPanel10.RowCount = 1;
      tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel10.Size = new Size(384, 50);
      tableLayoutPanel10.TabIndex = 10;
      // 
      // lbOperator
      // 
      lbOperator.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      lbOperator.AutoSize = true;
      lbOperator.Font = new Font("Microsoft Sans Serif", 12.75F);
      lbOperator.Location = new Point(128, 0);
      lbOperator.Name = "lbOperator";
      lbOperator.Size = new Size(253, 50);
      lbOperator.TabIndex = 3;
      lbOperator.Text = "...";
      lbOperator.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // label15
      // 
      label15.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label15.AutoSize = true;
      label15.Font = new Font("Microsoft Sans Serif", 12.75F);
      label15.Location = new Point(3, 0);
      label15.Name = "label15";
      label15.Size = new Size(119, 50);
      label15.TabIndex = 2;
      label15.Text = "Người cân:";
      label15.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // tableLayoutPanel9
      // 
      tableLayoutPanel9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel9.ColumnCount = 2;
      tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 125F));
      tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel9.Controls.Add(lbDate, 1, 0);
      tableLayoutPanel9.Controls.Add(label13, 0, 0);
      tableLayoutPanel9.Location = new Point(0, 200);
      tableLayoutPanel9.Margin = new Padding(0);
      tableLayoutPanel9.Name = "tableLayoutPanel9";
      tableLayoutPanel9.RowCount = 1;
      tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel9.Size = new Size(384, 50);
      tableLayoutPanel9.TabIndex = 9;
      // 
      // lbDate
      // 
      lbDate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      lbDate.AutoSize = true;
      lbDate.Font = new Font("Microsoft Sans Serif", 12.75F);
      lbDate.Location = new Point(128, 0);
      lbDate.Name = "lbDate";
      lbDate.Size = new Size(253, 50);
      lbDate.TabIndex = 3;
      lbDate.Text = "...";
      lbDate.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // label13
      // 
      label13.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label13.AutoSize = true;
      label13.Font = new Font("Microsoft Sans Serif", 12.75F);
      label13.Location = new Point(3, 0);
      label13.Name = "label13";
      label13.Size = new Size(119, 50);
      label13.TabIndex = 2;
      label13.Text = "Ngày:";
      label13.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // tableLayoutPanel8
      // 
      tableLayoutPanel8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel8.ColumnCount = 2;
      tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 125F));
      tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel8.Controls.Add(lbNet, 1, 0);
      tableLayoutPanel8.Controls.Add(label11, 0, 0);
      tableLayoutPanel8.Location = new Point(0, 150);
      tableLayoutPanel8.Margin = new Padding(0);
      tableLayoutPanel8.Name = "tableLayoutPanel8";
      tableLayoutPanel8.RowCount = 1;
      tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel8.Size = new Size(384, 50);
      tableLayoutPanel8.TabIndex = 8;
      // 
      // lbNet
      // 
      lbNet.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      lbNet.AutoSize = true;
      lbNet.Font = new Font("Microsoft Sans Serif", 12.75F);
      lbNet.Location = new Point(128, 0);
      lbNet.Name = "lbNet";
      lbNet.Size = new Size(253, 50);
      lbNet.TabIndex = 3;
      lbNet.Text = "...";
      lbNet.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // label11
      // 
      label11.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label11.AutoSize = true;
      label11.Font = new Font("Microsoft Sans Serif", 12.75F);
      label11.Location = new Point(3, 0);
      label11.Name = "label11";
      label11.Size = new Size(119, 50);
      label11.TabIndex = 2;
      label11.Text = "Net:";
      label11.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // tableLayoutPanel4
      // 
      tableLayoutPanel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel4.ColumnCount = 2;
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 125F));
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel4.Controls.Add(lbPO, 1, 0);
      tableLayoutPanel4.Controls.Add(label2, 0, 0);
      tableLayoutPanel4.Location = new Point(0, 0);
      tableLayoutPanel4.Margin = new Padding(0);
      tableLayoutPanel4.Name = "tableLayoutPanel4";
      tableLayoutPanel4.RowCount = 1;
      tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel4.Size = new Size(384, 50);
      tableLayoutPanel4.TabIndex = 4;
      // 
      // lbPO
      // 
      lbPO.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      lbPO.AutoSize = true;
      lbPO.Font = new Font("Microsoft Sans Serif", 12.75F);
      lbPO.Location = new Point(128, 0);
      lbPO.Name = "lbPO";
      lbPO.Size = new Size(253, 50);
      lbPO.TabIndex = 3;
      lbPO.Text = "`";
      lbPO.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // label2
      // 
      label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label2.AutoSize = true;
      label2.Font = new Font("Microsoft Sans Serif", 12.75F);
      label2.Location = new Point(3, 0);
      label2.Name = "label2";
      label2.Size = new Size(119, 50);
      label2.TabIndex = 2;
      label2.Text = "Lệnh sản xuất:";
      label2.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // lbMRName
      // 
      lbMRName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      lbMRName.AutoSize = true;
      lbMRName.Font = new Font("Microsoft Sans Serif", 12.75F);
      lbMRName.Location = new Point(3, 50);
      lbMRName.Name = "lbMRName";
      lbMRName.Size = new Size(378, 50);
      lbMRName.TabIndex = 3;
      lbMRName.Text = "...";
      lbMRName.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // UcPrintLabel
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.White;
      Controls.Add(panel1);
      Margin = new Padding(4);
      Name = "UcPrintLabel";
      Size = new Size(390, 500);
      ((System.ComponentModel.ISupportInitialize)picStatus).EndInit();
      panel1.ResumeLayout(false);
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      tableLayoutPanel2.ResumeLayout(false);
      tableLayoutPanel2.PerformLayout();
      tableLayoutPanel3.ResumeLayout(false);
      tableLayoutPanel3.PerformLayout();
      tableLayoutPanel12.ResumeLayout(false);
      tableLayoutPanel12.PerformLayout();
      tableLayoutPanel11.ResumeLayout(false);
      tableLayoutPanel11.PerformLayout();
      tableLayoutPanel10.ResumeLayout(false);
      tableLayoutPanel10.PerformLayout();
      tableLayoutPanel9.ResumeLayout(false);
      tableLayoutPanel9.PerformLayout();
      tableLayoutPanel8.ResumeLayout(false);
      tableLayoutPanel8.PerformLayout();
      tableLayoutPanel4.ResumeLayout(false);
      tableLayoutPanel4.PerformLayout();
      ResumeLayout(false);
    }

    #endregion

    private PictureBox picStatus;
    private Panel panel1;
    private TableLayoutPanel tableLayoutPanel1;
    private TableLayoutPanel tableLayoutPanel2;
    private TableLayoutPanel tableLayoutPanel3;
    private Label lbNameLabel;
    private Label label2;
    private Label lbPO;
    private TableLayoutPanel tableLayoutPanel4;
    private TableLayoutPanel tableLayoutPanel12;
    private Label lbTare;
    private Label label19;
    private TableLayoutPanel tableLayoutPanel11;
    private Label lbDepartment;
    private Label label17;
    private TableLayoutPanel tableLayoutPanel10;
    private Label lbDate;
    private Label label15;
    private TableLayoutPanel tableLayoutPanel9;
    private Label lbOperator;
    private Label label13;
    private TableLayoutPanel tableLayoutPanel8;
    private Label lbNet;
    private Label label11;
    private Label lbMRName;
    private Label lbMRCode;
    private Label lbInternalExternal;
  }
}
