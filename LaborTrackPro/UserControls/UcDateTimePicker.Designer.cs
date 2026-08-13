namespace LaborTrackPro.UserControls
{
  partial class UcDateTimePicker
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
      lbDateTime = new Label();
      tableLayoutPanel1.SuspendLayout();
      SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.BackColor = Color.Transparent;
      tableLayoutPanel1.ColumnCount = 1;
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
      tableLayoutPanel1.Controls.Add(lbDateTime, 0, 0);
      tableLayoutPanel1.Dock = DockStyle.Fill;
      tableLayoutPanel1.Location = new Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 1;
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.Size = new Size(212, 62);
      tableLayoutPanel1.TabIndex = 0;
      // 
      // lbDateTime
      // 
      lbDateTime.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      lbDateTime.AutoSize = true;
      lbDateTime.BackColor = SystemColors.GradientActiveCaption;
      lbDateTime.Font = new Font("Roboto", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
      lbDateTime.Location = new Point(0, 0);
      lbDateTime.Margin = new Padding(0);
      lbDateTime.Name = "lbDateTime";
      lbDateTime.Size = new Size(212, 62);
      lbDateTime.TabIndex = 1;
      lbDateTime.Text = "dd/MM/yyyy";
      lbDateTime.TextAlign = ContentAlignment.MiddleCenter;
      // 
      // UcDateTimePicker
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.Transparent;
      Controls.Add(tableLayoutPanel1);
      Name = "UcDateTimePicker";
      Size = new Size(212, 62);
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private Label lbDateTime;
  }
}
