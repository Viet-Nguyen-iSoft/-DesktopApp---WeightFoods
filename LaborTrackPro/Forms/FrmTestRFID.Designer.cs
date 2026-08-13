namespace LaborTrackPro.Forms
{
  partial class FrmTestRFID
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
      components = new System.ComponentModel.Container();
      textBox1 = new TextBox();
      button1 = new Button();
      label1 = new Label();
      label2 = new Label();
      textBox2 = new TextBox();
      timer1 = new System.Windows.Forms.Timer(components);
      lbStatusPrinter = new Label();
      SuspendLayout();
      // 
      // textBox1
      // 
      textBox1.Font = new Font("Segoe UI", 18F);
      textBox1.Location = new Point(161, 26);
      textBox1.Name = "textBox1";
      textBox1.Size = new Size(531, 39);
      textBox1.TabIndex = 0;
      textBox1.TextChanged += textBox1_TextChanged;
      // 
      // button1
      // 
      button1.Font = new Font("Segoe UI", 18F);
      button1.Location = new Point(542, 164);
      button1.Name = "button1";
      button1.Size = new Size(150, 44);
      button1.TabIndex = 1;
      button1.Text = "Print";
      button1.UseVisualStyleBackColor = true;
      button1.Click += button1_Click;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
      label1.Location = new Point(12, 31);
      label1.Name = "label1";
      label1.Size = new Size(127, 30);
      label1.TabIndex = 2;
      label1.Text = "Data (string)";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
      label2.Location = new Point(12, 95);
      label2.Name = "label2";
      label2.Size = new Size(108, 30);
      label2.TabIndex = 3;
      label2.Text = "Data (hex)";
      // 
      // textBox2
      // 
      textBox2.Font = new Font("Segoe UI", 18F);
      textBox2.Location = new Point(161, 90);
      textBox2.Name = "textBox2";
      textBox2.Size = new Size(531, 39);
      textBox2.TabIndex = 4;
      textBox2.Text = "00A1B2C3D4E1";
      // 
      // timer1
      // 
      timer1.Enabled = true;
      timer1.Interval = 1000;
      timer1.Tick += timer1_Tick;
      // 
      // lbStatusPrinter
      // 
      lbStatusPrinter.AutoSize = true;
      lbStatusPrinter.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
      lbStatusPrinter.Location = new Point(262, 213);
      lbStatusPrinter.Name = "lbStatusPrinter";
      lbStatusPrinter.Size = new Size(108, 30);
      lbStatusPrinter.TabIndex = 5;
      lbStatusPrinter.Text = "Data (hex)";
      // 
      // FrmTestRFID
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(708, 292);
      Controls.Add(lbStatusPrinter);
      Controls.Add(textBox2);
      Controls.Add(label2);
      Controls.Add(label1);
      Controls.Add(button1);
      Controls.Add(textBox1);
      Name = "FrmTestRFID";
      Text = "FrmTestRFID";
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private TextBox textBox1;
    private Button button1;
    private Label label1;
    private Label label2;
    private TextBox textBox2;
    private System.Windows.Forms.Timer timer1;
    private Label lbStatusPrinter;
  }
}