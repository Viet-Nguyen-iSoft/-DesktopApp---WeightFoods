namespace ReaderHID
{
  partial class Form1
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
      this.label1 = new System.Windows.Forms.Label();
      this.cbbCOM = new System.Windows.Forms.ComboBox();
      this.btnConnect = new System.Windows.Forms.Button();
      this.txtData = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.lbStatus = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Roboto Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(24, 85);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(74, 33);
      this.label1.TabIndex = 0;
      this.label1.Text = "COM";
      // 
      // cbbCOM
      // 
      this.cbbCOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbbCOM.Font = new System.Drawing.Font("Roboto Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cbbCOM.FormattingEnabled = true;
      this.cbbCOM.Location = new System.Drawing.Point(120, 82);
      this.cbbCOM.Name = "cbbCOM";
      this.cbbCOM.Size = new System.Drawing.Size(219, 41);
      this.cbbCOM.TabIndex = 1;
      // 
      // btnConnect
      // 
      this.btnConnect.Font = new System.Drawing.Font("Roboto Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnConnect.Location = new System.Drawing.Point(356, 80);
      this.btnConnect.Name = "btnConnect";
      this.btnConnect.Size = new System.Drawing.Size(137, 43);
      this.btnConnect.TabIndex = 2;
      this.btnConnect.Text = "Kết nối";
      this.btnConnect.UseVisualStyleBackColor = true;
      this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
      // 
      // txtData
      // 
      this.txtData.Font = new System.Drawing.Font("Roboto Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtData.Location = new System.Drawing.Point(120, 154);
      this.txtData.Name = "txtData";
      this.txtData.Size = new System.Drawing.Size(373, 40);
      this.txtData.TabIndex = 3;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Roboto Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(28, 154);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(70, 33);
      this.label2.TabIndex = 4;
      this.label2.Text = "Data";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Roboto", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(24, 23);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(160, 33);
      this.label3.TabIndex = 5;
      this.label3.Text = "Đọc thẻ HID";
      // 
      // lbStatus
      // 
      this.lbStatus.AutoSize = true;
      this.lbStatus.Font = new System.Drawing.Font("Roboto Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lbStatus.Location = new System.Drawing.Point(28, 233);
      this.lbStatus.Name = "lbStatus";
      this.lbStatus.Size = new System.Drawing.Size(146, 33);
      this.lbStatus.TabIndex = 6;
      this.lbStatus.Text = "Trạng thái: ";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(536, 301);
      this.Controls.Add(this.lbStatus);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.txtData);
      this.Controls.Add(this.btnConnect);
      this.Controls.Add(this.cbbCOM);
      this.Controls.Add(this.label1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Form1";
      this.ShowIcon = false;
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox cbbCOM;
    private System.Windows.Forms.Button btnConnect;
    private System.Windows.Forms.TextBox txtData;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label lbStatus;
  }
}

