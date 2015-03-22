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
    public partial class FormPemesanan : Form
    {
        databaseEntities db = new databaseEntities();
        int total = 0;
        FormMDI fm;
        public FormPemesanan(FormMDI fm)
        {
            InitializeComponent();
            this.fm = fm;
            textBox9.Text = fm.id;
        }

        public void createNewFormPemesanan()
        {
            var cek2 = (from c in db.db_Faktur_Pemesanan
                        orderby c.No_Faktur_Pemesanan descending
                        select c).ToList();
            string id;
            if (cek2.Count == 0)
            {
                id = "FFP0000001";
                textBox1.Text = id;
            }
            else
            {
                id = cek2[0].No_Faktur_Pemesanan;
                textBox1.Text = string.Format("FFP" + "{0:0000000}", Int64.Parse(id.Substring(3, 7)) + 1);
            }
        }

        public void hitungtotal()
        {
            try
            {
                total = 0;
                if (dataGridView1.RowCount == 0)
                    total = 0;
                else
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        total = total + int.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString());
                        label10.Text = "Total : " + total;
                    }
                }
            }
            catch (Exception asd) { }
        }
        

        private void FormPemesanan_Load(object sender, EventArgs e)
        {
            label15.Text = dateTimePicker1.Text;
            dateTimePicker1.Visible = false;
            textBox1.Enabled = false;
            textBox9.Enabled = false;
            listBox1.Enabled = false;
            textBox6.Enabled = false;
            textBox5.Enabled = false;
            textBox3.Enabled = false;
            textBox2.Enabled = false;
            textBox7.Enabled = false;
            textBox10.Enabled = false;
            textBox11.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            createNewFormPemesanan();
            textBox8.Text = "";
            textBox5.Text = "";
            textBox3.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            listBox1.Items.Clear();
            dataGridView1.Rows.Clear();
            label10.Text = "Total : ";
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            listBox1.Enabled = true;
            try
            {
                string ka = textBox8.Text;
                var a = (from b in db.db_Barang where b.Nama_Barang.Contains(ka) select b).First();
                if (!listBox1.Items.Contains(a.Nama_Barang))
                    listBox1.Items.Add(a.Nama_Barang);
            }
            catch (Exception aw) { }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                string k = listBox1.Text;
                var temp = (from a in db.db_Barang where a.Nama_Barang == k select a).First();
                string har = temp.Harga_Beli.ToString();
                textBox2.Text = har;
                textBox5.Text = temp.ID_Barang;
                textBox3.Text = temp.Jenis_Barang;
                textBox10.Text = temp.Stock+"";

            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox8.Text = "";
            textBox5.Text = "";
            textBox3.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox11.Text = "";
            textBox10.Text = "";
            listBox1.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormPemesanan_Load(this, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
                label9.Text = "Masukan barang yang ingin dipesan";
            else if (textBox4.Text == "")
                label9.Text = "Masukan Jumlah barang yang ingin dibeli";
            else
            {
                int ttl = int.Parse(textBox2.Text);
                int jml = int.Parse(textBox4.Text);
                int harga = int.Parse(textBox2.Text)*jml;

                Boolean cek = true;
                Boolean cekk = true;
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    try
                    {
                        string nam = dataGridView1.Rows[i].Cells[2].Value.ToString();
                        string id = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        if (id == textBox5.Text)
                        {
                            int qty = int.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString());
                            dataGridView1.Rows[i].Cells[6].Value = qty + jml;
                            int harga2 = int.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString());
                            dataGridView1.Rows[i].Cells[7].Value = harga2 + harga;
                            cek = false;
                            hitungtotal();
                        }else if(nam != textBox6.Text)
                                cekk = false;
                        
                    }
                    catch (Exception) { }
                }

                if (cek&&cekk)
                {
                    dataGridView1.Rows.Add(textBox1.Text, textBox5.Text, textBox6.Text, listBox1.Text, textBox3.Text, ttl, jml, harga);
                    hitungtotal();
                    
                }else if(cekk==false)
                    MessageBox.Show("Hanya boleh meretur dari Satu supplier yang sama", "Warning !", MessageBoxButtons.OK);
                
                

                textBox8.Text = "";
                textBox5.Text = "";
                textBox3.Text = "";
                textBox2.Text = "";
                textBox4.Text = "";
                textBox10.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox11.Text = "";
                listBox1.Items.Clear();

                textBox6.Enabled = false;
                textBox7.Enabled = false; 
                button1.Enabled = true;
                button2.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                label9.Text = "Error Label";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count <= 0)
            {
                MessageBox.Show("Tidak ada item yang bisa di remove", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                hitungtotal();
                label10.Text = "Total : " + total;
            }
            else
            {
                try
                {
                    dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                    hitungtotal();
                }
                catch (Exception) { }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count <= 0)
                MessageBox.Show("Tidak ada data untuk di simpan", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                db_Faktur_Pemesanan df = new db_Faktur_Pemesanan()
                {
                    No_Faktur_Pemesanan=textBox1.Text,
                    ID_Karyawan=textBox9.Text,
                    ID_Supplier=textBox7.Text,
                    Tanggal=dateTimePicker1.Text
                };
                db.AddTodb_Faktur_Pemesanan(df);
                db.SaveChanges();

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    string ih = "";
                    string ah = "";
                    int h = 0;
                    int hh = 0;
                    try {
                        ih = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        ah = dataGridView1.Rows[i].Cells[3].Value.ToString();
                        hh = int.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
                        h = int.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString());
                    }
                    catch (Exception) { }

                    db_Detail_Faktur_Pemesanan dbf = new db_Detail_Faktur_Pemesanan() 
                    {
                        No_Faktur_Pemesanan=textBox1.Text,
                        ID_Barang=ih,
                        Nama_Barang=ah,
                        Harga=hh,
                        Jumlah=h
                    };
                    db.AddTodb_Detail_Faktur_Pemesanan(dbf);
                    db.SaveChanges();
                }
                MessageBox.Show("Transaksi berhasil", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button2.Enabled = false;
                button5.Enabled = false; button3.Enabled = false;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var ab = (from a in db.db_Barang where a.ID_Barang == textBox5.Text select a).First();
                textBox7.Text = ab.ID_Supplier;
                var ac = (from a in db.db_Supplier where a.ID_Supplier == ab.ID_Supplier select a).First();
                textBox6.Text = ac.Nama_Supplier;
                textBox11.Text = ac.Alamat_Supplier;
            }
            catch (Exception) { }
        }
    }
}
