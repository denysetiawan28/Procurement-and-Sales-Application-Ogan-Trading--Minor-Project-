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
    public partial class FormPenjRetail : Form
    {
        databaseEntities db = new databaseEntities();
        FormMDI fm;
        int total = 0;
        public static string id = "";

        public void createNewFormPenjualanEceran()
        {
            var cek2 = (from c in db.db_Form_Penjualan_Eceran
                        orderby c.No_Form_Penjualan_Eceran descending
                        select c).ToList();
            string id;
            if (cek2.Count == 0)
            {
                id = "FPE0000001";
                textBox6.Text = id;
            }
            else
            {
                id = cek2[0].No_Form_Penjualan_Eceran;
                textBox6.Text = string.Format("FPE" + "{0:0000000}", Int64.Parse(id.Substring(3, 7)) + 1);
            }
        }


        public void hitungtotal()
        {
            try
            {
                total = 0;
                if (dataGridView1.RowCount== 0)
                {
                    total = 0;
                    label14.Text = "Total : " + total;
                }
                else
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        total = total + int.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
                        label14.Text = "Total : " + total;
                    }
                }
                
            }
            catch (Exception asd) { }
        }

        public FormPenjRetail(FormMDI fm)
        {
            InitializeComponent();
            this.fm = fm;
            textBox1.Text = fm.id;
            createNewFormPenjualanEceran();
        }

        

        private void FormPenjRetail_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Visible = false;
            label15.Text = dateTimePicker1.Text;
            textBox1.Enabled = false;
            textBox6.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox7.Enabled = false;
            listBox1.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            dataGridView1.Rows.Clear();
            label14.Text = "Total : ";
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            int jumlah = 0, stock = 0;
            bool flag = true;
            try
            {
                stock = int.Parse(textBox4.Text);
                jumlah = int.Parse(textBox9.Text);
                flag = true;
            }
            catch (Exception d) { flag = false; }
            if (textBox2.Text == "")
            {
                label6.Text = "Pilih barang yang ingin dibeli";
            }
            else if (textBox9.Text == "")
                label6.Text = "Isi jumlah yang ingin dibeli";
            else if (flag == false)
                label6.Text = "Jumlah harus numeric";
            else if (jumlah > stock)
                label6.Text = "Jumlah tidak dapat lebih besar dari stock yang tersedia";
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
                        string id = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        if (id == textBox2.Text)
                        {
                            int qty = int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                            dataGridView1.Rows[i].Cells[4].Value = qty + j;
                            int harga2 = int.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
                            dataGridView1.Rows[i].Cells[5].Value = harga2 + totalharga;
                            cek = false;
                        }

                    }
                    catch (Exception) { }
                }
                if (cek)
                dataGridView1.Rows.Add(textBox6.Text, textBox2.Text, listBox1.Text, textBox7.Text, textBox9.Text,totalharga);
                
                hitungtotal();
                textBox8.Text = "";
                listBox1.Items.Clear();
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox7.Text = "";
                textBox9.Text = "";
                label6.Text = "Error Label";
                button5.Enabled = true;
                button6.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
            }
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
            catch (Exception) { }
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                string k = listBox1.Text;
                var temp = (from a in db.db_Barang where a.Nama_Barang == k select a).First();
                string har = temp.Harga_Jual.ToString();

                textBox2.Text = temp.ID_Barang;
                textBox3.Text = temp.Jenis_Barang;
                textBox7.Text = har;
                textBox4.Text = temp.Stock+"";

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox8.Text = "";
            listBox1.Items.Clear();
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox7.Text = "";
            textBox9.Text = "";
            label6.Text = "Error Label";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count <= 0)
            {
                MessageBox.Show("Tidak ada item yang bisa di remove", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                hitungtotal();
                label14.Text = "Total : " + total;
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

        private void button6_Click(object sender, EventArgs e)
        {
            FormPenjRetail_Load(this, e);   
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count <= 0)
                MessageBox.Show("Tidak ada data untuk di simpan", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                db_Form_Penjualan_Eceran fe = new db_Form_Penjualan_Eceran()
                {
                    No_Form_Penjualan_Eceran=textBox6.Text,
                    ID_Karyawan=textBox1.Text,
                    Tanggal=dateTimePicker1.Text
                };
                db.AddTodb_Form_Penjualan_Eceran(fe);
                db.SaveChanges();


                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    string ih = "";
                    string ah = "";
                    int h = 0, l = 0;
                    try
                    {
                        ih = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        h = int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                        l = int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                        ah = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    }
                    catch (Exception) { }

                    db_Detail_Form_Penjualan_Eceran dfe = new db_Detail_Form_Penjualan_Eceran()
                    {
                        No_Form_Penjualan_Eceran=textBox6.Text,
                        ID_Barang=ih,
                        Harga=h,
                        Jumlah=l,
                        Nama_Barang=ah
                    };
                    db.AddTodb_Detail_Form_Penjualan_Eceran(dfe);
                    db.SaveChanges();

                    
                
                    try
                    {
                        var up = (from a in db.db_Barang where a.ID_Barang == ih select a).FirstOrDefault();
                        if (up.Stock != null )
                        {
                            up.Stock = up.Stock - l;
                            db.SaveChanges();
                            if (up.Stock <= 500)
                            {
                                MessageBox.Show("Stock " + dataGridView1.Rows[i].Cells[2].Value.ToString() + " mulai menipis, harap segera buat Faktur Pemesanan! ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }
                        
                    }
                    catch (Exception ) { }

                    
                }
                MessageBox.Show("Transaksi berhasil", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                id = textBox6.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            crysreportpenjualaneceran c = new crysreportpenjualaneceran();
            c.Show();
        }
    }
}
