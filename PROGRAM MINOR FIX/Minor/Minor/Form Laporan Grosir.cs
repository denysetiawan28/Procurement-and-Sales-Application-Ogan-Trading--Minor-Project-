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
    public partial class FormLaporan : Form
    {
        databaseEntities db = new databaseEntities();
        int total = 0;

        public void hitungtotal()
        {
            try
            {
                total = 0;
                if (dataGridView2.RowCount == 0)
                    total = 0;
                else
                {
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        total = total + int.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString());
                        label4.Text = "Total : " + total;
                    }
                }
            }
            catch (Exception asd) { }
        }


        public void loadData(string text)
        {
            
                var temp = (from a in db.db_Form_Penjualan_Grosir
                            join b in db.db_Detail_Form_Penjualan_Grosir
                            on a.No_Form_Penjualan_Grosir equals b.No_Form_Penjualan_Grosir
                            where a.Tanggal.Contains(text)
                            select new { a.Tanggal, a.No_Form_Penjualan_Grosir, b.ID_Barang, b.Nama_Barang, b.Jumlah,b.Harga });
                dataGridView2.DataSource = temp;
                dataGridView2.Columns[0].DisplayIndex = dataGridView2.Columns.Count - 1;

                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    int qty = int.Parse(dataGridView2.Rows[i].Cells[5].Value.ToString());
                    int harga = int.Parse(dataGridView2.Rows[i].Cells[6].Value.ToString());
                    dataGridView2.Rows[i].Cells[0].Value = (qty * harga);
                    hitungtotal();
                }
            
        }

        public FormLaporan()
        {
            InitializeComponent();
        }

       


        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            loadData(textBox2.Text);
        }

        private void FormLaporan_Load(object sender, EventArgs e)
        {

        }
    }
}
