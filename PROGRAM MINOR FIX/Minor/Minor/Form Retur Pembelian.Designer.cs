namespace Minor
{
    partial class Form_Retur_Pembelian
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
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxID = new System.Windows.Forms.ListBox();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtJmlRet = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBoxReturBy = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.txtDeskripsi = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtJumlahBar = new System.Windows.Forms.TextBox();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.groupBoxDetail = new System.Windows.Forms.GroupBox();
            this.txtNamaBar = new System.Windows.Forms.TextBox();
            this.txtIDBar = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridViewDetail = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxBarang = new System.Windows.Forms.GroupBox();
            this.listBoxBrg = new System.Windows.Forms.ListBox();
            this.labelTanggal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetail)).BeginInit();
            this.groupBoxBarang.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 58;
            this.label3.Text = "Jumlah Retur :";
            // 
            // listBoxID
            // 
            this.listBoxID.Enabled = false;
            this.listBoxID.FormattingEnabled = true;
            this.listBoxID.Location = new System.Drawing.Point(161, 116);
            this.listBoxID.Name = "listBoxID";
            this.listBoxID.Size = new System.Drawing.Size(140, 43);
            this.listBoxID.TabIndex = 104;
            this.listBoxID.Click += new System.EventHandler(this.listBoxID_Click);
            this.listBoxID.SelectedIndexChanged += new System.EventHandler(this.listBoxID_SelectedIndexChanged);
            // 
            // txtNama
            // 
            this.txtNama.Enabled = false;
            this.txtNama.Location = new System.Drawing.Point(428, 109);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(140, 20);
            this.txtNama.TabIndex = 103;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(124, 183);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 23);
            this.button1.TabIndex = 60;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(313, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 102;
            this.label2.Text = "Nama Supplier";
            // 
            // txtJmlRet
            // 
            this.txtJmlRet.Enabled = false;
            this.txtJmlRet.Location = new System.Drawing.Point(124, 93);
            this.txtJmlRet.Name = "txtJmlRet";
            this.txtJmlRet.Size = new System.Drawing.Size(148, 20);
            this.txtJmlRet.TabIndex = 59;
            this.txtJmlRet.TextChanged += new System.EventHandler(this.txtJmlRet_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 116);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(18, 13);
            this.label12.TabIndex = 101;
            this.label12.Text = "ID";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(158, 59);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(45, 13);
            this.labelID.TabIndex = 100;
            this.labelID.Text = "XX9999";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(313, 146);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 13);
            this.label14.TabIndex = 99;
            this.label14.Text = "Tanggal Transaksi";
            // 
            // comboBoxReturBy
            // 
            this.comboBoxReturBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxReturBy.FormattingEnabled = true;
            this.comboBoxReturBy.Items.AddRange(new object[] {
            "Faktur Pemesanan",
            "Retur Penjualan"});
            this.comboBoxReturBy.Location = new System.Drawing.Point(161, 89);
            this.comboBoxReturBy.Name = "comboBoxReturBy";
            this.comboBoxReturBy.Size = new System.Drawing.Size(139, 21);
            this.comboBoxReturBy.TabIndex = 98;
            this.comboBoxReturBy.SelectedIndexChanged += new System.EventHandler(this.comboBoxReturBy_SelectedIndexChanged);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(197, 183);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 61;
            this.button3.Text = "Remove";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtDeskripsi
            // 
            this.txtDeskripsi.Enabled = false;
            this.txtDeskripsi.Location = new System.Drawing.Point(124, 121);
            this.txtDeskripsi.Multiline = true;
            this.txtDeskripsi.Name = "txtDeskripsi";
            this.txtDeskripsi.Size = new System.Drawing.Size(148, 54);
            this.txtDeskripsi.TabIndex = 57;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(14, 92);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 13);
            this.label15.TabIndex = 97;
            this.label15.Text = "Retur by";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(14, 59);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(102, 13);
            this.label16.TabIndex = 96;
            this.label16.Text = "No Retur Pembelian";
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(71, 511);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 23);
            this.button2.TabIndex = 94;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtJumlahBar
            // 
            this.txtJumlahBar.Enabled = false;
            this.txtJumlahBar.Location = new System.Drawing.Point(124, 66);
            this.txtJumlahBar.Name = "txtJumlahBar";
            this.txtJumlahBar.Size = new System.Drawing.Size(148, 20);
            this.txtJumlahBar.TabIndex = 57;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Jumlah";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 60;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(334, -19);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 107;
            this.dateTimePicker2.Visible = false;
            // 
            // groupBoxDetail
            // 
            this.groupBoxDetail.Controls.Add(this.button3);
            this.groupBoxDetail.Controls.Add(this.button1);
            this.groupBoxDetail.Controls.Add(this.txtJmlRet);
            this.groupBoxDetail.Controls.Add(this.label3);
            this.groupBoxDetail.Controls.Add(this.txtDeskripsi);
            this.groupBoxDetail.Controls.Add(this.txtJumlahBar);
            this.groupBoxDetail.Controls.Add(this.txtNamaBar);
            this.groupBoxDetail.Controls.Add(this.txtIDBar);
            this.groupBoxDetail.Controls.Add(this.label11);
            this.groupBoxDetail.Controls.Add(this.label10);
            this.groupBoxDetail.Controls.Add(this.label8);
            this.groupBoxDetail.Controls.Add(this.label7);
            this.groupBoxDetail.Controls.Add(this.dataGridViewDetail);
            this.groupBoxDetail.Location = new System.Drawing.Point(252, 170);
            this.groupBoxDetail.Name = "groupBoxDetail";
            this.groupBoxDetail.Size = new System.Drawing.Size(313, 335);
            this.groupBoxDetail.TabIndex = 92;
            this.groupBoxDetail.TabStop = false;
            this.groupBoxDetail.Text = "Detail Retur Pembelian";
            // 
            // txtNamaBar
            // 
            this.txtNamaBar.Enabled = false;
            this.txtNamaBar.Location = new System.Drawing.Point(124, 41);
            this.txtNamaBar.Name = "txtNamaBar";
            this.txtNamaBar.Size = new System.Drawing.Size(148, 20);
            this.txtNamaBar.TabIndex = 57;
            // 
            // txtIDBar
            // 
            this.txtIDBar.Enabled = false;
            this.txtIDBar.Location = new System.Drawing.Point(124, 17);
            this.txtIDBar.Name = "txtIDBar";
            this.txtIDBar.Size = new System.Drawing.Size(148, 20);
            this.txtIDBar.TabIndex = 57;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 124);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 56;
            this.label11.Text = "Deskripsi :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 13);
            this.label10.TabIndex = 56;
            this.label10.Text = "Jumlah Barang :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 56;
            this.label8.Text = "Nama Barang :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 56;
            this.label7.Text = "ID Barang :";
            // 
            // dataGridViewDetail
            // 
            this.dataGridViewDetail.AllowUserToAddRows = false;
            this.dataGridViewDetail.AllowUserToDeleteRows = false;
            this.dataGridViewDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            this.dataGridViewDetail.Location = new System.Drawing.Point(10, 219);
            this.dataGridViewDetail.Name = "dataGridViewDetail";
            this.dataGridViewDetail.ReadOnly = true;
            this.dataGridViewDetail.Size = new System.Drawing.Size(286, 110);
            this.dataGridViewDetail.TabIndex = 55;
            this.dataGridViewDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDetail_CellClick);
            // 
            // Column6
            // 
            this.Column6.HeaderText = "ID Barang";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 60;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Nama Barang";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 60;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Deskripsi";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 60;
            // 
            // groupBoxBarang
            // 
            this.groupBoxBarang.Controls.Add(this.listBoxBrg);
            this.groupBoxBarang.Location = new System.Drawing.Point(12, 170);
            this.groupBoxBarang.Name = "groupBoxBarang";
            this.groupBoxBarang.Size = new System.Drawing.Size(221, 335);
            this.groupBoxBarang.TabIndex = 95;
            this.groupBoxBarang.TabStop = false;
            this.groupBoxBarang.Text = "Barang";
            // 
            // listBoxBrg
            // 
            this.listBoxBrg.FormattingEnabled = true;
            this.listBoxBrg.Location = new System.Drawing.Point(8, 19);
            this.listBoxBrg.Name = "listBoxBrg";
            this.listBoxBrg.Size = new System.Drawing.Size(167, 303);
            this.listBoxBrg.TabIndex = 0;
            this.listBoxBrg.Click += new System.EventHandler(this.listBoxBrg_Click);
            // 
            // labelTanggal
            // 
            this.labelTanggal.AutoSize = true;
            this.labelTanggal.Location = new System.Drawing.Point(365, 46);
            this.labelTanggal.Name = "labelTanggal";
            this.labelTanggal.Size = new System.Drawing.Size(61, 13);
            this.labelTanggal.TabIndex = 91;
            this.labelTanggal.Text = "dd-mm-yyyy";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(217, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 16);
            this.label1.TabIndex = 90;
            this.label1.Text = "Form Retur Pembelian";
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(393, 511);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(112, 23);
            this.button4.TabIndex = 93;
            this.button4.Text = "Cancel";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(233, 511);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(110, 23);
            this.button5.TabIndex = 94;
            this.button5.Text = "Print";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Location = new System.Drawing.Point(33, 9);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker3.TabIndex = 108;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(428, 143);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(139, 20);
            this.textBox1.TabIndex = 109;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(262, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 110;
            this.label4.Text = "label4";
            // 
            // Form_Retur_Pembelian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 548);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dateTimePicker3);
            this.Controls.Add(this.listBoxID);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.comboBoxReturBy);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.groupBoxDetail);
            this.Controls.Add(this.groupBoxBarang);
            this.Controls.Add(this.labelTanggal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Name = "Form_Retur_Pembelian";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Retur_Pembelian";
            this.Load += new System.EventHandler(this.Form_Retur_Pembelian_Load);
            this.groupBoxDetail.ResumeLayout(false);
            this.groupBoxDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetail)).EndInit();
            this.groupBoxBarang.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxID;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtJmlRet;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboBoxReturBy;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtDeskripsi;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtJumlahBar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.GroupBox groupBoxDetail;
        private System.Windows.Forms.TextBox txtNamaBar;
        private System.Windows.Forms.TextBox txtIDBar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridViewDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.GroupBox groupBoxBarang;
        private System.Windows.Forms.ListBox listBoxBrg;
        private System.Windows.Forms.Label labelTanggal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;

    }
}