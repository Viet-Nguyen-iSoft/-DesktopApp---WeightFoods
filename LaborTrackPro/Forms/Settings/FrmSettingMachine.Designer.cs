namespace LaborTrackPro.Forms.Settings
{
    partial class FrmSettingMachine
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
      DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
      DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
      tableLayoutPanel1 = new TableLayoutPanel();
      btnSave = new LaborTrackPro.Custom.RJButton();
      tableLayoutPanel3 = new TableLayoutPanel();
      dgvMachine = new DataGridView();
      label2 = new Label();
      tableLayoutPanel1.SuspendLayout();
      tableLayoutPanel3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)dgvMachine).BeginInit();
      SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.BackColor = Color.White;
      tableLayoutPanel1.ColumnCount = 1;
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.Controls.Add(btnSave, 0, 4);
      tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 2);
      tableLayoutPanel1.Controls.Add(label2, 0, 1);
      tableLayoutPanel1.Dock = DockStyle.Fill;
      tableLayoutPanel1.Location = new Point(0, 0);
      tableLayoutPanel1.Margin = new Padding(0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 6;
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel1.Size = new Size(1369, 739);
      tableLayoutPanel1.TabIndex = 2;
      // 
      // btnSave
      // 
      btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
      btnSave.BackColor = Color.FromArgb(40, 167, 48);
      btnSave.BackgroundColor = Color.FromArgb(40, 167, 48);
      btnSave.BorderColor = Color.PaleVioletRed;
      btnSave.BorderRadius = 5;
      btnSave.BorderSize = 0;
      btnSave.FlatAppearance.BorderSize = 0;
      btnSave.FlatStyle = FlatStyle.Flat;
      btnSave.Font = new Font("Roboto", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
      btnSave.ForeColor = Color.White;
      btnSave.Location = new Point(1199, 669);
      btnSave.Margin = new Padding(0, 0, 20, 0);
      btnSave.Name = "btnSave";
      btnSave.Size = new Size(150, 50);
      btnSave.TabIndex = 8;
      btnSave.Text = "Lưu";
      btnSave.TextColor = Color.White;
      btnSave.UseVisualStyleBackColor = false;
      btnSave.Click += btnSave_Click;
      // 
      // tableLayoutPanel3
      // 
      tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel3.ColumnCount = 3;
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 18F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 18F));
      tableLayoutPanel3.Controls.Add(dgvMachine, 1, 0);
      tableLayoutPanel3.Location = new Point(3, 82);
      tableLayoutPanel3.Margin = new Padding(3, 2, 3, 2);
      tableLayoutPanel3.Name = "tableLayoutPanel3";
      tableLayoutPanel3.RowCount = 2;
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
      tableLayoutPanel3.Size = new Size(1363, 570);
      tableLayoutPanel3.TabIndex = 9;
      // 
      // dgvMachine
      // 
      dgvMachine.AllowUserToAddRows = false;
      dgvMachine.AllowUserToResizeRows = false;
      dataGridViewCellStyle1.BackColor = Color.White;
      dataGridViewCellStyle1.Font = new Font("Roboto", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
      dgvMachine.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
      dgvMachine.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      dgvMachine.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      dgvMachine.BackgroundColor = Color.White;
      dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle2.BackColor = Color.FromArgb(228, 148, 1);
      dataGridViewCellStyle2.Font = new Font("Roboto", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
      dataGridViewCellStyle2.ForeColor = SystemColors.Window;
      dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(228, 148, 1);
      dataGridViewCellStyle2.SelectionForeColor = SystemColors.Window;
      dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
      dgvMachine.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
      dgvMachine.ColumnHeadersHeight = 45;
      dgvMachine.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle3.BackColor = SystemColors.Window;
      dataGridViewCellStyle3.Font = new Font("Roboto", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
      dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
      dataGridViewCellStyle3.SelectionBackColor = Color.Transparent;
      dataGridViewCellStyle3.SelectionForeColor = Color.Black;
      dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
      dgvMachine.DefaultCellStyle = dataGridViewCellStyle3;
      dgvMachine.EnableHeadersVisualStyles = false;
      dgvMachine.Location = new Point(21, 2);
      dgvMachine.Margin = new Padding(3, 2, 3, 2);
      dgvMachine.Name = "dgvMachine";
      dgvMachine.ReadOnly = true;
      dgvMachine.RowHeadersVisible = false;
      dgvMachine.RowHeadersWidth = 30;
      dgvMachine.RowTemplate.Height = 45;
      dgvMachine.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      dgvMachine.Size = new Size(1321, 551);
      dgvMachine.TabIndex = 2;
      dgvMachine.CellDoubleClick += dgvMachine_CellDoubleClick;
      dgvMachine.DataBindingComplete += dgvMachine_DataBindingComplete;
      // 
      // label2
      // 
      label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      label2.AutoSize = true;
      label2.Font = new Font("Roboto", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
      label2.ForeColor = Color.Black;
      label2.Location = new Point(18, 20);
      label2.Margin = new Padding(18, 0, 3, 0);
      label2.Name = "label2";
      label2.Size = new Size(1348, 60);
      label2.TabIndex = 10;
      label2.Text = "Danh sách trạm cân";
      label2.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // FrmSettingMachine
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(1369, 739);
      Controls.Add(tableLayoutPanel1);
      Name = "FrmSettingMachine";
      Text = "FrmSettingMachine";
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      tableLayoutPanel3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)dgvMachine).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
        private Custom.RJButton btnSave;
        private TableLayoutPanel tableLayoutPanel3;
        private DataGridView dgvMachine;
        private Label label2;
    }
}