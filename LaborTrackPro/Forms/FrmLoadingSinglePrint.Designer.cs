namespace LaborTrackPro.Forms
{
  partial class FrmLoadingSinglePrint
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
      panel1 = new Panel();
      SuspendLayout();
      // 
      // panel1
      // 
      panel1.Dock = DockStyle.Fill;
      panel1.Location = new Point(0, 0);
      panel1.Margin = new Padding(0);
      panel1.Name = "panel1";
      panel1.Size = new Size(500, 500);
      panel1.TabIndex = 1;
      // 
      // FrmLoadingSinglePrint
      // 
      AutoScaleDimensions = new SizeF(96F, 96F);
      AutoScaleMode = AutoScaleMode.Dpi;
      AutoSizeMode = AutoSizeMode.GrowAndShrink;
      BackColor = Color.White;
      ClientSize = new Size(500, 500);
      ControlBox = false;
      Controls.Add(panel1);
      FormBorderStyle = FormBorderStyle.None;
      Margin = new Padding(3, 2, 3, 2);
      Name = "FrmLoadingSinglePrint";
      StartPosition = FormStartPosition.CenterParent;
      Text = "FrmLoadingSinglePrint";
      Load += FrmLoadingSinglePrint_Load;
      Shown += FrmLoadingSinglePrint_Shown;
      ResumeLayout(false);
    }

    #endregion

    private Panel panel1;
  }
}