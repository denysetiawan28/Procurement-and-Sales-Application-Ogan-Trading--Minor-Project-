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
    public partial class Form_Laporan_Retur_Pembelian : Form
    {
        databaseEntities db = new databaseEntities();

        public Form_Laporan_Retur_Pembelian()
        {
            InitializeComponent();
        }

        private void loadData(string text)
        {
            var temp = (from a in db.db_Retur_Pembelian
                        join b in db.db_Detail_Retur_Pembelian
                        on a.No_Retur_Pembelian equals b.No_Retur_Pembelian
                        where a.Tanggal.Contains(text)
                        select new { a.Tanggal, a.No_Retur_Pembelian ,b.ID_Barang, b.Nama_Barang, b.Jumlah,b.Deskripsi });
            dataGridView1.DataSource = temp;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            loadData(textBox2.Text);
        }

        private void Form_Laporan_Retur_Pembelian_Load(object sender, EventArgs e)
        {

        }
    }
}
