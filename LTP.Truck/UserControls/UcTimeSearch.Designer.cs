namespace LTP.Truck.UserControls
{
  partial class UcTimeSearch
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
      tableLayoutPanel10 = new TableLayoutPanel();
      dtpDate = new DateTimePicker();
      hour = new NumericUpDown();
      minute = new NumericUpDown();
      tableLayoutPanel10.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)hour).BeginInit();
      ((System.ComponentModel.ISupportInitialize)minute).BeginInit();
      SuspendLayout();
      // 
      // tableLayoutPanel10
      // 
      tableLayoutPanel10.ColumnCount = 3;
      tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 65F));
      tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 65F));
      tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel10.Controls.Add(dtpDate, 2, 0);
      tableLayoutPanel10.Controls.Add(hour, 0, 0);
      tableLayoutPanel10.Controls.Add(minute, 1, 0);
      tableLayoutPanel10.Dock = DockStyle.Fill;
      tableLayoutPanel10.Location = new Point(0, 0);
      tableLayoutPanel10.Margin = new Padding(0);
      tableLayoutPanel10.Name = "tableLayoutPanel10";
      tableLayoutPanel10.RowCount = 1;
      tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel10.Size = new Size(362, 58);
      tableLayoutPanel10.TabIndex = 23;
      // 
      // dtpDate
      // 
      dtpDate.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      dtpDate.CalendarFont = new Font("Roboto", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
      dtpDate.Font = new Font("Roboto", 20.25F);
      dtpDate.Format = DateTimePickerFormat.Short;
      dtpDate.Location = new Point(133, 9);
      dtpDate.Name = "dtpDate";
      dtpDate.Size = new Size(226, 40);
      dtpDate.TabIndex = 20;
      // 
      // hour
      // 
      hour.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      hour.Font = new Font("Roboto", 20.25F);
      hour.Location = new Point(3, 9);
      hour.Maximum = new decimal(new int[] { 23, 0, 0, 0 });
      hour.Name = "hour";
      hour.Size = new Size(59, 40);
      hour.TabIndex = 26;
      // 
      // minute
      // 
      minute.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      minute.Font = new Font("Roboto", 20.25F);
      minute.Location = new Point(68, 9);
      minute.Maximum = new decimal(new int[] { 59, 0, 0, 0 });
      minute.Name = "minute";
      minute.Size = new Size(59, 40);
      minute.TabIndex = 27;
      // 
      // UcTimeSearch
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      Controls.Add(tableLayoutPanel10);
      Name = "UcTimeSearch";
      Size = new Size(362, 58);
      tableLayoutPanel10.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)hour).EndInit();
      ((System.ComponentModel.ISupportInitialize)minute).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel10;
    private DateTimePicker dtpDate;
    private NumericUpDown hour;
    private NumericUpDown minute;
  }
}
