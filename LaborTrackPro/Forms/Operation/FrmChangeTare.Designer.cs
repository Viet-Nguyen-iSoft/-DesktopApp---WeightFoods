namespace LaborTrackPro.Forms.Operation
{
  partial class FrmChangeTare
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
      flowLayoutPanel = new FlowLayoutPanel();
      ucTitleFrm = new LaborTrackPro.UserControls.UcTitleFrm();
      tableLayoutPanel2 = new TableLayoutPanel();
      tableLayoutPanel3 = new TableLayoutPanel();
      btnUp = new LaborTrackPro.Custom.RJButton();
      btnDown = new LaborTrackPro.Custom.RJButton();
      tableLayoutPanel1.SuspendLayout();
      tableLayoutPanel2.SuspendLayout();
      tableLayoutPanel3.SuspendLayout();
      SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.BackColor = Color.White;
      tableLayoutPanel1.ColumnCount = 3;
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 15F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 15F));
      tableLayoutPanel1.Controls.Add(ucTitleFrm, 1, 1);
      tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 3);
      tableLayoutPanel1.Dock = DockStyle.Fill;
      tableLayoutPanel1.Location = new Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 5;
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 85F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel1.Size = new Size(1338, 928);
      tableLayoutPanel1.TabIndex = 2;
      // 
      // flowLayoutPanel
      // 
      flowLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      flowLayoutPanel.AutoScroll = true;
      flowLayoutPanel.BackColor = Color.FromArgb(239, 242, 243);
      flowLayoutPanel.Location = new Point(0, 0);
      flowLayoutPanel.Margin = new Padding(0);
      flowLayoutPanel.Name = "flowLayoutPanel";
      flowLayoutPanel.Padding = new Padding(10);
      flowLayoutPanel.Size = new Size(1223, 798);
      flowLayoutPanel.TabIndex = 0;
      // 
      // ucTitleFrm
      // 
      ucTitleFrm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      ucTitleFrm.Location = new Point(15, 15);
      ucTitleFrm.Margin = new Padding(0);
      ucTitleFrm.Name = "ucTitleFrm";
      ucTitleFrm.Size = new Size(1308, 85);
      ucTitleFrm.TabIndex = 3;
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel2.ColumnCount = 3;
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 15F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
      tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 2, 0);
      tableLayoutPanel2.Controls.Add(flowLayoutPanel, 0, 0);
      tableLayoutPanel2.Location = new Point(15, 115);
      tableLayoutPanel2.Margin = new Padding(0);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 1;
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.Size = new Size(1308, 798);
      tableLayoutPanel2.TabIndex = 5;
      // 
      // tableLayoutPanel3
      // 
      tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel3.ColumnCount = 1;
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel3.Controls.Add(btnUp, 0, 0);
      tableLayoutPanel3.Controls.Add(btnDown, 0, 2);
      tableLayoutPanel3.Location = new Point(1238, 0);
      tableLayoutPanel3.Margin = new Padding(0);
      tableLayoutPanel3.Name = "tableLayoutPanel3";
      tableLayoutPanel3.RowCount = 3;
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 200F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 200F));
      tableLayoutPanel3.Size = new Size(70, 798);
      tableLayoutPanel3.TabIndex = 1;
      // 
      // btnUp
      // 
      btnUp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      btnUp.BackColor = Color.FromArgb(239, 242, 243);
      btnUp.BackgroundColor = Color.FromArgb(239, 242, 243);
      btnUp.BorderColor = Color.PaleVioletRed;
      btnUp.BorderRadius = 5;
      btnUp.BorderSize = 0;
      btnUp.FlatAppearance.BorderSize = 0;
      btnUp.FlatStyle = FlatStyle.Flat;
      btnUp.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
      btnUp.ForeColor = Color.White;
      btnUp.Image = Properties.Resources.icon_up;
      btnUp.Location = new Point(3, 0);
      btnUp.Margin = new Padding(3, 0, 3, 3);
      btnUp.Name = "btnUp";
      btnUp.Size = new Size(64, 197);
      btnUp.TabIndex = 1;
      btnUp.TextColor = Color.White;
      btnUp.UseVisualStyleBackColor = false;
      // 
      // btnDown
      // 
      btnDown.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      btnDown.BackColor = Color.FromArgb(239, 242, 243);
      btnDown.BackgroundColor = Color.FromArgb(239, 242, 243);
      btnDown.BorderColor = Color.PaleVioletRed;
      btnDown.BorderRadius = 5;
      btnDown.BorderSize = 0;
      btnDown.FlatAppearance.BorderSize = 0;
      btnDown.FlatStyle = FlatStyle.Flat;
      btnDown.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
      btnDown.ForeColor = Color.White;
      btnDown.Image = Properties.Resources.icon_down;
      btnDown.Location = new Point(3, 601);
      btnDown.Margin = new Padding(3, 3, 3, 0);
      btnDown.Name = "btnDown";
      btnDown.Size = new Size(64, 197);
      btnDown.TabIndex = 2;
      btnDown.TextColor = Color.White;
      btnDown.UseVisualStyleBackColor = false;
      // 
      // FrmChangeTare
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(1338, 928);
      Controls.Add(tableLayoutPanel1);
      MaximizeBox = false;
      MinimizeBox = false;
      Name = "FrmChangeTare";
      ShowIcon = false;
      StartPosition = FormStartPosition.CenterScreen;
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel2.ResumeLayout(false);
      tableLayoutPanel3.ResumeLayout(false);
      ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private FlowLayoutPanel flowLayoutPanel;
    private UserControls.UcTitleFrm ucTitleFrm;
    private TableLayoutPanel tableLayoutPanel2;
    private TableLayoutPanel tableLayoutPanel3;
    private Custom.RJButton btnUp;
    private Custom.RJButton btnDown;
  }
}