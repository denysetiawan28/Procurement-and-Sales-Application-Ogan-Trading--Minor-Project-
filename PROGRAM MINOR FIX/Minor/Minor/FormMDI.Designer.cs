namespace Minor
{
    partial class FormMDI
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.karyawanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masterPelangganToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masterSupplierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masterBarangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transaksiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.penjualanGrosirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.penjualanRetailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pemesananToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.returToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.returPenjualanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.returPembelianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.laporanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.laporanPenjualanGrosirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.laporanPenjualanRetailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.laporanReturPenjualanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.laporanReturPembelianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutUsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.masterToolStripMenuItem,
            this.transaksiToolStripMenuItem,
            this.returToolStripMenuItem,
            this.laporanToolStripMenuItem,
            this.aboutUsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(370, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.logoutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // masterToolStripMenuItem
            // 
            this.masterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.karyawanToolStripMenuItem,
            this.masterPelangganToolStripMenuItem,
            this.masterSupplierToolStripMenuItem,
            this.masterBarangToolStripMenuItem});
            this.masterToolStripMenuItem.Name = "masterToolStripMenuItem";
            this.masterToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.masterToolStripMenuItem.Text = "Master";
            // 
            // karyawanToolStripMenuItem
            // 
            this.karyawanToolStripMenuItem.Name = "karyawanToolStripMenuItem";
            this.karyawanToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.karyawanToolStripMenuItem.Text = "Master Karyawan";
            this.karyawanToolStripMenuItem.Click += new System.EventHandler(this.karyawanToolStripMenuItem_Click);
            // 
            // masterPelangganToolStripMenuItem
            // 
            this.masterPelangganToolStripMenuItem.Name = "masterPelangganToolStripMenuItem";
            this.masterPelangganToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.masterPelangganToolStripMenuItem.Text = "Master Pelanggan";
            this.masterPelangganToolStripMenuItem.Click += new System.EventHandler(this.masterPelangganToolStripMenuItem_Click);
            // 
            // masterSupplierToolStripMenuItem
            // 
            this.masterSupplierToolStripMenuItem.Name = "masterSupplierToolStripMenuItem";
            this.masterSupplierToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.masterSupplierToolStripMenuItem.Text = "Master Supplier";
            this.masterSupplierToolStripMenuItem.Click += new System.EventHandler(this.masterSupplierToolStripMenuItem_Click);
            // 
            // masterBarangToolStripMenuItem
            // 
            this.masterBarangToolStripMenuItem.Name = "masterBarangToolStripMenuItem";
            this.masterBarangToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.masterBarangToolStripMenuItem.Text = "Master Barang";
            this.masterBarangToolStripMenuItem.Click += new System.EventHandler(this.masterBarangToolStripMenuItem_Click);
            // 
            // transaksiToolStripMenuItem
            // 
            this.transaksiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.penjualanGrosirToolStripMenuItem,
            this.penjualanRetailToolStripMenuItem,
            this.pemesananToolStripMenuItem});
            this.transaksiToolStripMenuItem.Name = "transaksiToolStripMenuItem";
            this.transaksiToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.transaksiToolStripMenuItem.Text = "Transaksi";
            // 
            // penjualanGrosirToolStripMenuItem
            // 
            this.penjualanGrosirToolStripMenuItem.Name = "penjualanGrosirToolStripMenuItem";
            this.penjualanGrosirToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.penjualanGrosirToolStripMenuItem.Text = "Penjualan Grosir";
            this.penjualanGrosirToolStripMenuItem.Click += new System.EventHandler(this.penjualanGrosirToolStripMenuItem_Click);
            // 
            // penjualanRetailToolStripMenuItem
            // 
            this.penjualanRetailToolStripMenuItem.Name = "penjualanRetailToolStripMenuItem";
            this.penjualanRetailToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.penjualanRetailToolStripMenuItem.Text = "Penjualan Retail";
            this.penjualanRetailToolStripMenuItem.Click += new System.EventHandler(this.penjualanRetailToolStripMenuItem_Click);
            // 
            // pemesananToolStripMenuItem
            // 
            this.pemesananToolStripMenuItem.Name = "pemesananToolStripMenuItem";
            this.pemesananToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.pemesananToolStripMenuItem.Text = "Pemesanan";
            this.pemesananToolStripMenuItem.Click += new System.EventHandler(this.pemesananToolStripMenuItem_Click);
            // 
            // returToolStripMenuItem
            // 
            this.returToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.returPenjualanToolStripMenuItem,
            this.returPembelianToolStripMenuItem});
            this.returToolStripMenuItem.Name = "returToolStripMenuItem";
            this.returToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.returToolStripMenuItem.Text = "Retur";
            // 
            // returPenjualanToolStripMenuItem
            // 
            this.returPenjualanToolStripMenuItem.Name = "returPenjualanToolStripMenuItem";
            this.returPenjualanToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.returPenjualanToolStripMenuItem.Text = "Retur Penjualan";
            this.returPenjualanToolStripMenuItem.Click += new System.EventHandler(this.returPenjualanToolStripMenuItem_Click);
            // 
            // returPembelianToolStripMenuItem
            // 
            this.returPembelianToolStripMenuItem.Name = "returPembelianToolStripMenuItem";
            this.returPembelianToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.returPembelianToolStripMenuItem.Text = "Retur Pembelian";
            this.returPembelianToolStripMenuItem.Click += new System.EventHandler(this.returPembelianToolStripMenuItem_Click);
            // 
            // laporanToolStripMenuItem
            // 
            this.laporanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.laporanPenjualanGrosirToolStripMenuItem,
            this.laporanPenjualanRetailToolStripMenuItem,
            this.laporanReturPenjualanToolStripMenuItem,
            this.laporanReturPembelianToolStripMenuItem});
            this.laporanToolStripMenuItem.Name = "laporanToolStripMenuItem";
            this.laporanToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.laporanToolStripMenuItem.Text = "Laporan";
            // 
            // laporanPenjualanGrosirToolStripMenuItem
            // 
            this.laporanPenjualanGrosirToolStripMenuItem.Name = "laporanPenjualanGrosirToolStripMenuItem";
            this.laporanPenjualanGrosirToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.laporanPenjualanGrosirToolStripMenuItem.Text = "Laporan Penjualan Grosir";
            this.laporanPenjualanGrosirToolStripMenuItem.Click += new System.EventHandler(this.laporanPenjualanGrosirToolStripMenuItem_Click);
            // 
            // laporanPenjualanRetailToolStripMenuItem
            // 
            this.laporanPenjualanRetailToolStripMenuItem.Name = "laporanPenjualanRetailToolStripMenuItem";
            this.laporanPenjualanRetailToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.laporanPenjualanRetailToolStripMenuItem.Text = "Laporan Penjualan Retail";
            this.laporanPenjualanRetailToolStripMenuItem.Click += new System.EventHandler(this.laporanPenjualanRetailToolStripMenuItem_Click);
            // 
            // laporanReturPenjualanToolStripMenuItem
            // 
            this.laporanReturPenjualanToolStripMenuItem.Name = "laporanReturPenjualanToolStripMenuItem";
            this.laporanReturPenjualanToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.laporanReturPenjualanToolStripMenuItem.Text = "Laporan Retur Penjualan";
            this.laporanReturPenjualanToolStripMenuItem.Click += new System.EventHandler(this.laporanReturPenjualanToolStripMenuItem_Click);
            // 
            // laporanReturPembelianToolStripMenuItem
            // 
            this.laporanReturPembelianToolStripMenuItem.Name = "laporanReturPembelianToolStripMenuItem";
            this.laporanReturPembelianToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.laporanReturPembelianToolStripMenuItem.Text = "Laporan Retur Pembelian";
            this.laporanReturPembelianToolStripMenuItem.Click += new System.EventHandler(this.laporanReturPembelianToolStripMenuItem_Click);
            // 
            // aboutUsToolStripMenuItem
            // 
            this.aboutUsToolStripMenuItem.Name = "aboutUsToolStripMenuItem";
            this.aboutUsToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.aboutUsToolStripMenuItem.Text = "About Us";
            // 
            // FormMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 261);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMDI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PD.Ogan Tradding Food";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem masterPelangganToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem masterSupplierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem masterBarangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem returPenjualanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem returPembelianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem laporanPenjualanGrosirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem laporanPenjualanRetailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem laporanReturPenjualanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem laporanReturPembelianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutUsToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem masterToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem transaksiToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem penjualanGrosirToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem penjualanRetailToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem pemesananToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem returToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem laporanToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem karyawanToolStripMenuItem;
    }
}