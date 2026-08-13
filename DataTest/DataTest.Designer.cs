namespace DataTest
{
  partial class DataTest
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      components = new System.ComponentModel.Container();
      label1 = new Label();
      label2 = new Label();
      label3 = new Label();
      lbNet = new Label();
      lbTare = new Label();
      lbGross = new Label();
      dgvEmployee = new DataGridView();
      label7 = new Label();
      dgvProductionOrder = new DataGridView();
      label8 = new Label();
      label9 = new Label();
      label10 = new Label();
      btnAutoRandom = new Button();
      btnRandom = new Button();
      btnReloadEmployee = new Button();
      btnReloadProductionOrder = new Button();
      lbProductionOrder = new Label();
      lbProduction = new Label();
      lbStatus = new Label();
      timer1 = new System.Windows.Forms.Timer(components);
      cbbFactory = new ComboBox();
      cbbMachine = new ComboBox();
      label5 = new Label();
      label6 = new Label();
      label11 = new Label();
      cbbEmployee = new ComboBox();
      ((System.ComponentModel.ISupportInitialize)dgvEmployee).BeginInit();
      ((System.ComponentModel.ISupportInitialize)dgvProductionOrder).BeginInit();
      SuspendLayout();
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
      label1.Location = new Point(999, 311);
      label1.Name = "label1";
      label1.Size = new Size(52, 30);
      label1.TabIndex = 0;
      label1.Text = "Net:";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
      label2.Location = new Point(999, 370);
      label2.Name = "label2";
      label2.Size = new Size(56, 30);
      label2.TabIndex = 1;
      label2.Text = "Tare:";
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
      label3.Location = new Point(999, 431);
      label3.Name = "label3";
      label3.Size = new Size(69, 30);
      label3.TabIndex = 2;
      label3.Text = "Gross:";
      // 
      // lbNet
      // 
      lbNet.AutoSize = true;
      lbNet.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
      lbNet.Location = new Point(1127, 311);
      lbNet.Name = "lbNet";
      lbNet.Size = new Size(68, 30);
      lbNet.TabIndex = 3;
      lbNet.Text = "0.0 kg";
      // 
      // lbTare
      // 
      lbTare.AutoSize = true;
      lbTare.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
      lbTare.Location = new Point(1127, 370);
      lbTare.Name = "lbTare";
      lbTare.Size = new Size(68, 30);
      lbTare.TabIndex = 4;
      lbTare.Text = "0.0 kg";
      // 
      // lbGross
      // 
      lbGross.AutoSize = true;
      lbGross.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
      lbGross.Location = new Point(1127, 431);
      lbGross.Name = "lbGross";
      lbGross.Size = new Size(68, 30);
      lbGross.TabIndex = 5;
      lbGross.Text = "0.0 kg";
      // 
      // dgvEmployee
      // 
      dgvEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dgvEmployee.Location = new Point(14, 68);
      dgvEmployee.Name = "dgvEmployee";
      dgvEmployee.RowTemplate.Height = 25;
      dgvEmployee.Size = new Size(922, 228);
      dgvEmployee.TabIndex = 6;
      // 
      // label7
      // 
      label7.AutoSize = true;
      label7.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
      label7.Location = new Point(14, 22);
      label7.Name = "label7";
      label7.Size = new Size(208, 30);
      label7.TabIndex = 7;
      label7.Text = "Danh sách nhân viên";
      // 
      // dgvProductionOrder
      // 
      dgvProductionOrder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dgvProductionOrder.Location = new Point(14, 390);
      dgvProductionOrder.Name = "dgvProductionOrder";
      dgvProductionOrder.RowTemplate.Height = 25;
      dgvProductionOrder.Size = new Size(922, 253);
      dgvProductionOrder.TabIndex = 8;
      // 
      // label8
      // 
      label8.AutoSize = true;
      label8.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
      label8.Location = new Point(14, 345);
      label8.Name = "label8";
      label8.Size = new Size(186, 30);
      label8.TabIndex = 9;
      label8.Text = "Danh sách lệnh SX";
      // 
      // label9
      // 
      label9.AutoSize = true;
      label9.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
      label9.Location = new Point(994, 481);
      label9.Name = "label9";
      label9.Size = new Size(147, 30);
      label9.TabIndex = 10;
      label9.Text = "Lệnh sản xuất:";
      // 
      // label10
      // 
      label10.AutoSize = true;
      label10.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
      label10.Location = new Point(993, 537);
      label10.Name = "label10";
      label10.Size = new Size(111, 30);
      label10.TabIndex = 11;
      label10.Text = "Sản phẩm:";
      // 
      // btnAutoRandom
      // 
      btnAutoRandom.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
      btnAutoRandom.Location = new Point(1127, 15);
      btnAutoRandom.Name = "btnAutoRandom";
      btnAutoRandom.Size = new Size(251, 47);
      btnAutoRandom.TabIndex = 12;
      btnAutoRandom.Text = "Auto Random";
      btnAutoRandom.UseVisualStyleBackColor = true;
      btnAutoRandom.Click += btnAutoRandom_Click;
      // 
      // btnRandom
      // 
      btnRandom.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
      btnRandom.Location = new Point(994, 15);
      btnRandom.Name = "btnRandom";
      btnRandom.Size = new Size(127, 47);
      btnRandom.TabIndex = 13;
      btnRandom.Text = "Random";
      btnRandom.UseVisualStyleBackColor = true;
      btnRandom.Click += btnRandom_Click;
      // 
      // btnReloadEmployee
      // 
      btnReloadEmployee.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
      btnReloadEmployee.Location = new Point(809, 12);
      btnReloadEmployee.Name = "btnReloadEmployee";
      btnReloadEmployee.Size = new Size(127, 47);
      btnReloadEmployee.TabIndex = 14;
      btnReloadEmployee.Text = "Reload";
      btnReloadEmployee.UseVisualStyleBackColor = true;
      // 
      // btnReloadProductionOrder
      // 
      btnReloadProductionOrder.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
      btnReloadProductionOrder.Location = new Point(809, 338);
      btnReloadProductionOrder.Name = "btnReloadProductionOrder";
      btnReloadProductionOrder.Size = new Size(127, 47);
      btnReloadProductionOrder.TabIndex = 15;
      btnReloadProductionOrder.Text = "Reload";
      btnReloadProductionOrder.UseVisualStyleBackColor = true;
      // 
      // lbProductionOrder
      // 
      lbProductionOrder.AutoSize = true;
      lbProductionOrder.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
      lbProductionOrder.Location = new Point(1170, 481);
      lbProductionOrder.Name = "lbProductionOrder";
      lbProductionOrder.Size = new Size(51, 30);
      lbProductionOrder.TabIndex = 18;
      lbProductionOrder.Text = "N/A";
      // 
      // lbProduction
      // 
      lbProduction.AutoSize = true;
      lbProduction.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
      lbProduction.Location = new Point(1170, 537);
      lbProduction.Name = "lbProduction";
      lbProduction.Size = new Size(51, 30);
      lbProduction.TabIndex = 19;
      lbProduction.Text = "N/A";
      // 
      // lbStatus
      // 
      lbStatus.AutoSize = true;
      lbStatus.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
      lbStatus.Location = new Point(993, 606);
      lbStatus.Name = "lbStatus";
      lbStatus.Size = new Size(118, 30);
      lbStatus.TabIndex = 20;
      lbStatus.Text = "Status: N/A";
      // 
      // timer1
      // 
      timer1.Interval = 2000;
      timer1.Tick += timer1_Tick;
      // 
      // cbbFactory
      // 
      cbbFactory.DropDownStyle = ComboBoxStyle.DropDownList;
      cbbFactory.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
      cbbFactory.FormattingEnabled = true;
      cbbFactory.Location = new Point(1127, 78);
      cbbFactory.Name = "cbbFactory";
      cbbFactory.Size = new Size(251, 40);
      cbbFactory.TabIndex = 25;
      // 
      // cbbMachine
      // 
      cbbMachine.DropDownStyle = ComboBoxStyle.DropDownList;
      cbbMachine.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
      cbbMachine.FormattingEnabled = true;
      cbbMachine.Location = new Point(1127, 136);
      cbbMachine.Name = "cbbMachine";
      cbbMachine.Size = new Size(251, 40);
      cbbMachine.TabIndex = 26;
      // 
      // label5
      // 
      label5.AutoSize = true;
      label5.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
      label5.Location = new Point(993, 83);
      label5.Name = "label5";
      label5.Size = new Size(84, 30);
      label5.TabIndex = 27;
      label5.Text = "Factory:";
      // 
      // label6
      // 
      label6.AutoSize = true;
      label6.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
      label6.Location = new Point(993, 141);
      label6.Name = "label6";
      label6.Size = new Size(98, 30);
      label6.TabIndex = 28;
      label6.Text = "Machine:";
      // 
      // label11
      // 
      label11.AutoSize = true;
      label11.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
      label11.Location = new Point(993, 200);
      label11.Name = "label11";
      label11.Size = new Size(108, 30);
      label11.TabIndex = 30;
      label11.Text = "Employee:";
      // 
      // cbbEmployee
      // 
      cbbEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
      cbbEmployee.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
      cbbEmployee.FormattingEnabled = true;
      cbbEmployee.Location = new Point(1127, 195);
      cbbEmployee.Name = "cbbEmployee";
      cbbEmployee.Size = new Size(251, 40);
      cbbEmployee.TabIndex = 29;
      // 
      // DataTest
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(1594, 655);
      Controls.Add(label11);
      Controls.Add(cbbEmployee);
      Controls.Add(label6);
      Controls.Add(label5);
      Controls.Add(cbbMachine);
      Controls.Add(cbbFactory);
      Controls.Add(lbStatus);
      Controls.Add(lbProduction);
      Controls.Add(lbProductionOrder);
      Controls.Add(btnReloadProductionOrder);
      Controls.Add(btnReloadEmployee);
      Controls.Add(btnRandom);
      Controls.Add(btnAutoRandom);
      Controls.Add(label10);
      Controls.Add(label9);
      Controls.Add(label8);
      Controls.Add(dgvProductionOrder);
      Controls.Add(label7);
      Controls.Add(dgvEmployee);
      Controls.Add(lbGross);
      Controls.Add(lbTare);
      Controls.Add(lbNet);
      Controls.Add(label3);
      Controls.Add(label2);
      Controls.Add(label1);
      Name = "DataTest";
      Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)dgvEmployee).EndInit();
      ((System.ComponentModel.ISupportInitialize)dgvProductionOrder).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private Label label1;
    private Label label2;
    private Label label3;
    private Label lbNet;
    private Label lbTare;
    private Label lbGross;
    private DataGridView dgvEmployee;
    private Label label7;
    private DataGridView dgvProductionOrder;
    private Label label8;
    private Label label9;
    private Label label10;
    private Button btnAutoRandom;
    private Button btnRandom;
    private Button btnReloadEmployee;
    private Button btnReloadProductionOrder;
    private Label lbProductionOrder;
    private Label lbProduction;
    private Label lbStatus;
    private System.Windows.Forms.Timer timer1;
    private ComboBox cbbFactory;
    private ComboBox cbbMachine;
    private Label label5;
    private Label label6;
    private Label label11;
    private ComboBox cbbEmployee;
  }
}
