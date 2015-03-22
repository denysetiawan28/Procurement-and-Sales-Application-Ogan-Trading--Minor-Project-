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
    public partial class Form_Penjualan_Grosir : Form
    {
        databaseEntities db = new databaseEntities();
        FormMDI fm;
        int total = 0;
        public static string id = "";
        public static string idkaryawan="";
        public void createNewFormPenjualanGrosir()
        {
            var cek2 = (from c in db.db_Form_Penjualan_Grosir
                        orderby c.No_Form_Penjualan_Grosir descending
                        select c).ToList();
            string id;
            if (cek2.Count == 0)
            {
                id = "FPG0000001";
                textBox6.Text = id;
            }
            else
            {
                id = cek2[0].No_Form_Penjualan_Grosir;
                textBox6.Text = string.Format("FPG" + "{0:0000000}", Int64.Parse(id.Substring(3, 7)) + 1);
            }
        }

        public Form_Penjualan_Grosir(FormMDI fm)
        {
            InitializeComponent();
            this.fm = fm;
            textBox1.Text = fm.id;
            createNewFormPenjualanGrosir();
            
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
                        total = total + int.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString());
                        label14.Text = "Total : " + total;
                    }
                }
            }
            catch (Exception asd) { }
        }

        private void Form_Penjualan_Grosir_Load(object sender, EventArgs e)
        {
            label14.Text = "Total : ";
            groupBox1.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = true;
            label15.Text = dateTimePicker1.Text;
            dateTimePicker1.Visible = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button8.Enabled = false;
            button10.Enabled = false;
            textBox12.Enabled = false;
            textBox13.Enabled = false;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            listBox1.Items.Clear();
            listBox2.Items.Clear(); 
            textBox8.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox7.Text = "";
            textBox4.Text = "";
            textBox9.Text = "";
            textBox4.Enabled = false;
            dataGridView1.Rows.Clear();
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            

        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
       }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
                try
                {
                    string ka = textBox8.Text;
                    var a = (from b in db.db_Barang where b.Nama_Barang.Contains(ka) select b).First();
                    if (!listBox1.Items.Contains(a.Nama_Barang))
                        listBox1.Items.Add(a.Nama_Barang);
                }
                catch (Exception aw) { }
            
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form_Penjualan_Grosir_Load(this, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form_Penjualan_Grosir_Load(this, e);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (listBox1.SelectedIndex != -1)
            {
                string k = listBox1.Text;
                var temp=(from a in db.db_Barang where a.Nama_Barang==k select a).First();
                string har = temp.Harga_Jual.ToString();
                string ga = temp.Harga_Member.ToString();

                textBox2.Text = temp.ID_Barang;
                textBox3.Text = temp.Jenis_Barang;
                if (radioButton1.Checked == true)
                    textBox7.Text = ga;
                else textBox7.Text = har;
                textBox4.Text = temp.Stock.ToString();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox8.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox7.Text = "";
            textBox9.Text = "";
            listBox1.Items.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int jumlah=0,stock=0;
            bool flag = true;
            try
            {
                stock = int.Parse(textBox4.Text);
                jumlah = int.Parse(textBox9.Text);
                flag = true;
            }
            catch (Exception d) { flag = false; }
            if (textBox2.Text == "")
                label7.Text = "Pilih barang yang ingin di input";
            else if (textBox9.Text == "")
                label7.Text = "Masukan jumlah yang ingin di beli";
            else if (flag == false)
                label7.Text = " Jumlah harus numeric";
            else if (jumlah > stock)
                label7.Text = "Jumlah tidak dapat lebih besar dari stock yang tersedia";
            else
            {
                int harga = int.Parse(textBox7.Text);
                int j = int.Parse(textBox9.Text);
                int totalharga = harga * j;

                Boolean cek = true;
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    try
                    {
                        string id = dataGridView1.Rows[i].Cells[2].Value.ToString();
                        if (id == textBox2.Text)
                        {
                            int qty = int.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
                            dataGridView1.Rows[i].Cells[5].Value = qty + j;
                            int harga2 = int.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString());
                            dataGridView1.Rows[i].Cells[6].Value = harga2 + totalharga;
                            cek = false;
                        }
                            
                    }
                    catch (Exception) { }
                }
                if(cek)
                dataGridView1.Rows.Add(textBox6.Text, listBox2.Text, textBox2.Text, listBox1.Text, textBox7.Text, textBox9.Text, totalharga);
                
                hitungtotal();
                textBox8.Text = "";
                listBox1.Items.Clear();
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox7.Text = "";
                textBox9.Text = "";
                label7.Text = "Error Label";
                button5.Enabled = true;
                button6.Enabled = true;
                button8.Enabled = true;
                button10.Enabled = true;
            }
        }
        
        private void button8_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count <= 0)
            {
                MessageBox.Show("Tidak ada item yang bisa di remove", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                hitungtotal();
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
                    db_Form_Penjualan_Grosir fpg = new db_Form_Penjualan_Grosir() { 
                    No_Form_Penjualan_Grosir=textBox6.Text,
                    ID_Karyawan=textBox1.Text,
                    ID_Pelanggan=textBox12.Text,
                    Tanggal=dateTimePicker1.Text,
                };
                db.AddTodb_Form_Penjualan_Grosir(fpg);
                db.SaveChanges();

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    string ih = "";
                    string ah="";
                    int h = 0, l = 0;
                    try
                    {
                        ih = dataGridView1.Rows[i].Cells[2].Value.ToString();
                        h = int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                        l = int.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
                        ah=dataGridView1.Rows[i].Cells[3].Value.ToString();
                    }
                    catch (Exception) { }

                    db_Detail_Form_Penjualan_Grosir dt = new db_Detail_Form_Penjualan_Grosir() { 
                        No_Form_Penjualan_Grosir=textBox6.Text,
                        ID_Barang=ih,
                        Harga=h,
                        Jumlah=l,
                        Nama_Barang=ah
                    };
                    db.AddTodb_Detail_Form_Penjualan_Grosir(dt);
                    db.SaveChanges();
                    try
                    {
                        var up = (from a in db.db_Barang where a.ID_Barang == ih select a).FirstOrDefault();
                        if (up.Stock != null )
                        {
                            up.Stock = up.Stock - l;
                            db.SaveChanges();
                            if (up.Stock <= 200)
                            {
                                MessageBox.Show("Stock " + dataGridView1.Rows[i].Cells[3].Value.ToString() + " mulai menipis, harap segera buat Faktur Pemesanan! ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }
                        
                    }
                    catch (Exception ) { }

                    
                }
                var te = (from a in db.db_Pelanggan where a.ID_Pelanggan == textBox12.Text select a).First();
                if (te.Count < 3) te.Count += 1;
                db.SaveChanges();
                if (total >= 1000000) te.Count = 3;
                db.SaveChanges();

                MessageBox.Show("Transaksi berhasil", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                id = textBox6.Text;
                idkaryawan = textBox1.Text;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox12.Text == "")
                label6.Text = "Pilih Pelanggan! ";
            else
            {
                groupBox3.Enabled = true;
                groupBox4.Enabled = false;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox5.Text == "")
                {
                    listBox2.Items.Clear();
                    textBox12.Text = "";
                    textBox13.Text = "";
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                }
                string pel = textBox5.Text;
                var a = (from b in db.db_Pelanggan where b.Nama_Pelanggan.Contains(pel) select b).First();
                if (!listBox2.Items.Contains(a.Nama_Pelanggan))
                    listBox2.Items.Add(a.Nama_Pelanggan);
            }
            catch (Exception) { }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string c = listBox2.Text;
            if (listBox2.SelectedIndex != -1)
            {
                var temp = (from a in db.db_Pelanggan where a.Nama_Pelanggan == c select a).First();
                textBox12.Text = temp.ID_Pelanggan;
                textBox13.Text = temp.Alamat_Pelanggan;
                string asdf= temp.Count+"";
                int co = int.Parse(asdf);
                if (co != 3) radioButton2.Checked = true;
                else radioButton1.Checked = true;

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            crysreportpenjualangrosir fff = new crysreportpenjualangrosir();
            fff.Show();
        }
    }
}
