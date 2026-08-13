namespace LaborTrackPro.Printer
{
  partial class TestPrinter
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
      button1 = new Button();
      txt01 = new CustomControls.RJControls.RJTextBox();
      txt02 = new CustomControls.RJControls.RJTextBox();
      SuspendLayout();
      // 
      // button1
      // 
      button1.Location = new Point(324, 32);
      button1.Name = "button1";
      button1.Size = new Size(114, 46);
      button1.TabIndex = 0;
      button1.Text = "button1";
      button1.UseVisualStyleBackColor = true;
      button1.Click += button1_Click;
      // 
      // txt01
      // 
      txt01.BackColor = SystemColors.Window;
      txt01.BorderColor = Color.MediumSlateBlue;
      txt01.BorderFocusColor = Color.HotPink;
      txt01.BorderRadius = 5;
      txt01.BorderSize = 2;
      txt01.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
      txt01.ForeColor = Color.FromArgb(64, 64, 64);
      txt01.Location = new Point(41, 32);
      txt01.Margin = new Padding(4);
      txt01.Multiline = false;
      txt01.Name = "txt01";
      txt01.Padding = new Padding(10, 7, 10, 7);
      txt01.PasswordChar = false;
      txt01.PlaceholderColor = Color.DarkGray;
      txt01.PlaceholderText = "";
      txt01.Size = new Size(250, 46);
      txt01.TabIndex = 1;
      txt01.Texts = "";
      txt01.UnderlinedStyle = false;
      // 
      // txt02
      // 
      txt02.BackColor = SystemColors.Window;
      txt02.BorderColor = Color.MediumSlateBlue;
      txt02.BorderFocusColor = Color.HotPink;
      txt02.BorderRadius = 5;
      txt02.BorderSize = 2;
      txt02.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
      txt02.ForeColor = Color.FromArgb(64, 64, 64);
      txt02.Location = new Point(41, 100);
      txt02.Margin = new Padding(4);
      txt02.Multiline = false;
      txt02.Name = "txt02";
      txt02.Padding = new Padding(10, 7, 10, 7);
      txt02.PasswordChar = false;
      txt02.PlaceholderColor = Color.DarkGray;
      txt02.PlaceholderText = "";
      txt02.Size = new Size(250, 46);
      txt02.TabIndex = 2;
      txt02.Texts = "";
      txt02.UnderlinedStyle = false;
      // 
      // TestPrinter
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(800, 450);
      Controls.Add(txt02);
      Controls.Add(txt01);
      Controls.Add(button1);
      Name = "TestPrinter";
      Text = "TestPrinter";
      ResumeLayout(false);
    }

    #endregion

    private Button button1;
    private CustomControls.RJControls.RJTextBox txt01;
    private CustomControls.RJControls.RJTextBox txt02;
  }
}