namespace LaborTrackPro
{
  partial class FrmMain
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
      backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
      panelMain = new Panel();
      SuspendLayout();
      // 
      // panelMain
      // 
      panelMain.Dock = DockStyle.Fill;
      panelMain.Location = new Point(0, 0);
      panelMain.Margin = new Padding(0);
      panelMain.Name = "panelMain";
      panelMain.Size = new Size(1924, 1041);
      panelMain.TabIndex = 3;
      // 
      // FrmMain
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(1924, 1041);
      Controls.Add(panelMain);
      Margin = new Padding(3, 2, 3, 2);
      Name = "FrmMain";
      ShowIcon = false;
      Load += FrmMain_Load;
      Shown += FrmMain_Shown;
      ResumeLayout(false);
    }

    #endregion
    private UC.UcStatusConnection statusConnection1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    private Panel panelMain;
  }
}