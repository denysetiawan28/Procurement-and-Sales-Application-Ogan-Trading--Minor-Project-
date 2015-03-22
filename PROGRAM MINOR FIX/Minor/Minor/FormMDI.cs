using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Minor
{
    public partial class FormMDI : Form
    {
        Form_Login fl;
        Form_Registrasi_Barang fb;
        Form_Registrasi_Karyawan fk;
        Form_Registrasi_Customer fc;
        Form_Registrasi_Suuplier fs;
        FormPenjRetail fe;
        Form_Penjualan_Grosir pg;
        Form_Retur_Pembelian fp;
        Form_Retur_Penjualan fpp;
        FormPemesanan fp2;
        FormLaporan flg;
        Form_Laporan_Retail flr;
        Form_Laporan_Retur_Pembelian frp;
        Form_Laporan_Retur_Penjualan frpp;


        public string id;
        public void closeMdi()
        {
            while (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }
        }

        public FormMDI()
        {
            InitializeComponent();
            logoutToolStripMenuItem.Visible = false;
            loginToolStripMenuItem.Visible = true;
            masterToolStripMenuItem.Visible = false;
            transaksiToolStripMenuItem.Visible = false;
            returToolStripMenuItem.Visible = false;
            laporanToolStripMenuItem.Visible = false;
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Logout Success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            closeMdi();
            logoutToolStripMenuItem.Visible = false;
            loginToolStripMenuItem.Visible = true;
            masterToolStripMenuItem.Visible = false;
            transaksiToolStripMenuItem.Visible = false;
            returToolStripMenuItem.Visible = false;
            laporanToolStripMenuItem.Visible = false;
            fl.Show();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeMdi();
            fl = new Form_Login(this);
            fl.Show();
            fl.MdiParent = this;
        }

        private void penjualanGrosirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeMdi();
            pg = new Form_Penjualan_Grosir(this);
            pg.Show();
            pg.MdiParent = this;
        }

        private void karyawanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeMdi();
            fk = new Form_Registrasi_Karyawan();
            fk.Show();
            fk.MdiParent = this;
        }

        private void masterPelangganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeMdi();
            fc = new Form_Registrasi_Customer();
            fc.Show();
            fc.MdiParent = this;

        }

        private void masterSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeMdi();
            fs = new Form_Registrasi_Suuplier();
            fs.Show();
            fs.MdiParent = this;
        }

        private void masterBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeMdi();
            fb = new Form_Registrasi_Barang();
            fb.Show();
            fb.MdiParent = this;
        }

        private void penjualanRetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeMdi();
            fe = new FormPenjRetail(this);
            fe.Show();
            fe.MdiParent = this;
        }

        private void pemesananToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeMdi();
            fp2 = new FormPemesanan(this);
            fp2.Show();
            fp2.MdiParent = this;
        }

        private void returPenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeMdi();
            fpp = new Form_Retur_Penjualan();
            fpp.Show();
            fpp.MdiParent = this;
        }

        private void returPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeMdi();
            fp = new Form_Retur_Pembelian();
            fp.Show();
            fp.MdiParent = this;
        }

        private void laporanPenjualanGrosirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeMdi();
            flg = new FormLaporan();
            flg.Show();
            flg.MdiParent = this;
        }

        private void laporanPenjualanRetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeMdi();
            flr = new Form_Laporan_Retail();
            flr.Show();
            flr.MdiParent = this;
        }

        private void laporanReturPenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeMdi();
            frpp = new Form_Laporan_Retur_Penjualan();
            frpp.Show();
            frpp.MdiParent = this;
            
        }

        private void laporanReturPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeMdi();
            frp = new Form_Laporan_Retur_Pembelian();
            frp.Show();
            frp.MdiParent = this;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
