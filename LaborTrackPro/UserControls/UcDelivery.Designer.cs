namespace LaborTrackPro.UserControls
{
  partial class UcDelivery
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
      tableLayoutPanel1 = new TableLayoutPanel();
      label1 = new Label();
      tableLayoutPanel2 = new TableLayoutPanel();
      label3 = new Label();
      label2 = new Label();
      lbCode = new Label();
      lbValue = new Label();
      tableLayoutPanel1.SuspendLayout();
      tableLayoutPanel2.SuspendLayout();
      SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.BackColor = Color.White;
      tableLayoutPanel1.ColumnCount = 3;
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
      tableLayoutPanel1.Controls.Add(label1, 0, 0);
      tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 2, 0);
      tableLayoutPanel1.Dock = DockStyle.Fill;
      tableLayoutPanel1.Location = new Point(0, 0);
      tableLayoutPanel1.Margin = new Padding(0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 1;
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.Size = new Size(487, 103);
      tableLayoutPanel1.TabIndex = 1;
      // 
      // label1
      // 
      label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label1.AutoSize = true;
      label1.BackColor = Color.FromArgb(228, 148, 1);
      label1.Font = new Font("Microsoft Sans Serif", 20.25F);
      label1.ForeColor = Color.White;
      label1.Location = new Point(0, 0);
      label1.Margin = new Padding(0);
      label1.Name = "label1";
      label1.Padding = new Padding(3, 0, 0, 0);
      label1.Size = new Size(10, 103);
      label1.TabIndex = 17;
      label1.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel2.ColumnCount = 3;
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 5F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.Controls.Add(label3, 0, 1);
      tableLayoutPanel2.Controls.Add(label2, 0, 0);
      tableLayoutPanel2.Controls.Add(lbCode, 2, 0);
      tableLayoutPanel2.Controls.Add(lbValue, 2, 1);
      tableLayoutPanel2.Location = new Point(20, 0);
      tableLayoutPanel2.Margin = new Padding(0);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 2;
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
      tableLayoutPanel2.Size = new Size(467, 103);
      tableLayoutPanel2.TabIndex = 20;
      // 
      // label3
      // 
      label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label3.AutoSize = true;
      label3.BackColor = Color.Transparent;
      label3.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
      label3.ForeColor = Color.Black;
      label3.Location = new Point(0, 51);
      label3.Margin = new Padding(0);
      label3.Name = "label3";
      label3.Padding = new Padding(3, 0, 0, 0);
      label3.Size = new Size(124, 52);
      label3.TabIndex = 21;
      label3.Text = "Giá trị (Kg):";
      label3.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // label2
      // 
      label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label2.AutoSize = true;
      label2.BackColor = Color.Transparent;
      label2.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
      label2.ForeColor = Color.Black;
      label2.Location = new Point(0, 0);
      label2.Margin = new Padding(0);
      label2.Name = "label2";
      label2.Padding = new Padding(3, 0, 0, 0);
      label2.Size = new Size(124, 51);
      label2.TabIndex = 20;
      label2.Text = "Mã phiếu:";
      label2.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // lbCode
      // 
      lbCode.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      lbCode.AutoSize = true;
      lbCode.BackColor = Color.Transparent;
      lbCode.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold);
      lbCode.ForeColor = Color.Black;
      lbCode.Location = new Point(129, 0);
      lbCode.Margin = new Padding(0);
      lbCode.Name = "lbCode";
      lbCode.Padding = new Padding(3, 0, 0, 0);
      lbCode.Size = new Size(338, 51);
      lbCode.TabIndex = 18;
      lbCode.Text = "N/A";
      lbCode.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // lbValue
      // 
      lbValue.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      lbValue.AutoSize = true;
      lbValue.BackColor = Color.Transparent;
      lbValue.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold);
      lbValue.ForeColor = Color.Black;
      lbValue.Location = new Point(129, 51);
      lbValue.Margin = new Padding(0);
      lbValue.Name = "lbValue";
      lbValue.Padding = new Padding(3, 0, 0, 0);
      lbValue.Size = new Size(338, 52);
      lbValue.TabIndex = 19;
      lbValue.Text = "0";
      lbValue.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // UcDelivery
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      Controls.Add(tableLayoutPanel1);
      Name = "UcDelivery";
      Size = new Size(487, 103);
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      tableLayoutPanel2.ResumeLayout(false);
      tableLayoutPanel2.PerformLayout();
      ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private Label label1;
    private Label lbCode;
    private Label lbValue;
    private TableLayoutPanel tableLayoutPanel2;
    private Label label3;
    private Label label2;
  }
}
