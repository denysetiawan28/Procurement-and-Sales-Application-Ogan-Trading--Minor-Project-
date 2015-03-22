using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Minor
{
    public partial class Form_Registrasi_Barang : Form
    {

        databaseEntities db = new databaseEntities();
        int status;

        private void loadData()
        {
            var a = from c in db.db_Barang select c;
            dataGridView1.DataSource = a;
        }

        public void InsertBarang()
        {
            var cek2 = (from c in db.db_Barang
                        orderby c.ID_Barang descending
                        select c).ToList();
            string id;
            if (cek2.Count == 0)
            {
                id = "BR0001";
                textBox1.Text = id;
            }
            else
            {
                id = cek2[0].ID_Barang;
                textBox1.Text = string.Format("BR" + "{0:0000}", Int32.Parse(id.Substring(2, 4)) + 1);
            }
        }

        private void textEnabled(bool a)
        {
            textBox2.Enabled = a;
            textBox3.Enabled = a;
            textBox4.Enabled = a;
            textBox5.Enabled = a;
            textBox6.Enabled = a;
            textBox8.Enabled = a;
            textBox9.Enabled = a;
            listBox1.Enabled = a;
        }

        private void btnEnabled(bool a)
        {
            button1.Enabled = a;
            button2.Enabled = a;
            button3.Enabled = a;
            button4.Enabled = !a;
            button5.Enabled = !a;
        }

        public Form_Registrasi_Barang()
        {
            InitializeComponent();
            textBox1.Enabled = false;
            textBox10.Enabled = false;
        }

        private void Form_Registrasi_Barang_Load(object sender, EventArgs e)
        {
            textEnabled(false);
            btnEnabled(true);
            loadData();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            listBox1.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertBarang();
            textEnabled(true);
            btnEnabled(false);
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox8.Text = "";
            status = 0;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Pilih data yang ingin diubah!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                textEnabled(true);
                btnEnabled(false);
                status = 1;
            }
        }

        private void DeleteBarang(string id)
        {
            if (id == "")
            {
                MessageBox.Show("Pilih data yang ingin dihapus!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (MessageBox.Show(this, "Are you sure want to delete Barang " + textBox1.Text + " ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var t = (from a in db.db_Barang.ToList()
                         where a.ID_Barang == id
                         select a).First();
                db.DeleteObject(t);
                db.SaveChanges();
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            DeleteBarang(textBox1.Text);

            Form_Registrasi_Barang_Load(this, e);//awal
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form_Registrasi_Barang_Load(this, e);//awal
        }

        private void InsertBarang(string id, string nama,string jenis, string hargabeli, string hargajual,string hargamember, string stock,string iss) {
            db_Barang kr = new db_Barang()
            {
                ID_Barang = id,
                Nama_Barang = nama,
                Jenis_Barang = jenis,
                Harga_Beli = Int32.Parse(hargabeli),
                Harga_Jual = Int32.Parse(hargajual),
                Harga_Member = Int32.Parse(hargamember),
                Stock = Int32.Parse(stock),
                ID_Supplier=iss
            };
            db.AddTodb_Barang(kr);
            db.SaveChanges();

            
        }
        private void UpdateBarang(string id, string nama, string jenis, string hargabeli, string hargajual, string hargamember, string stock ,string iss)
        {
            var kt = (from a in db.db_Barang.ToList()
                      where a.ID_Barang == id
                      select a).First();
            kt.Nama_Barang = nama;
            kt.Jenis_Barang = jenis;
            kt.Harga_Beli = Int32.Parse(hargabeli);
            kt.Harga_Jual = Int32.Parse(hargajual);
            kt.Harga_Member = Int32.Parse(hargamember);
            kt.Stock = Int32.Parse(stock);
            kt.ID_Supplier = iss;
            db.SaveChanges();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            Regex regNum = new Regex(@"^\d+$");
            if (textBox1.Text == "")
                MessageBox.Show("Kolom ID Barang tidak boleh kosong !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (textBox2.Text == "")
                MessageBox.Show("Kolom Nama Barang tidak boleh kosong !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (textBox3.Text == "")
                MessageBox.Show("Kolom Jenis Barang tidak boleh kosong !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (textBox4.Text == "")
                MessageBox.Show("Kolom Harga Beli tidak boleh kosong !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (regNum.IsMatch(textBox4.Text) == false)
                MessageBox.Show("Kolom Harga Beli harus berupa angka !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (textBox6.Text == "")
                MessageBox.Show("Kolom Harga Jual tidak boleh kosong !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (regNum.IsMatch(textBox6.Text) == false)
                MessageBox.Show("Kolom Harga Jual harus berupa angka !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (textBox8.Text == "")
                MessageBox.Show("Kolom Harga Member tidak boleh kosong !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (regNum.IsMatch(textBox8.Text) == false)
                MessageBox.Show("Kolom Harga Member harus berupa angka !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           else if (textBox5.Text == "")
                MessageBox.Show("Kolom Stock tidak boleh kosong !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if(regNum.IsMatch(textBox5.Text)==false)
                MessageBox.Show("Kolom Stock harus berupa angka !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (textBox10.Text == "")
                MessageBox.Show("Kolom ID Supplier tidak boleh kosong tidak boleh kosong !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            else
            {
                if (status == 0)
                {
                    InsertBarang(textBox1.Text,textBox2.Text,textBox3.Text,textBox4.Text,textBox6.Text,textBox8.Text,textBox5.Text,textBox10.Text);
                }
                else if (status == 1)
                {
                    UpdateBarang(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox6.Text, textBox8.Text, textBox5.Text,textBox10.Text);
                   
                }
                Form_Registrasi_Barang_Load(this, e);//awal
            }
        
        }

        private void SearchBarang(string nama)
        {
            var temp = from a in db.db_Barang where a.Nama_Barang.Contains(nama) select a;
            dataGridView1.DataSource = temp;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            SearchBarang(textBox7.Text);
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox9.Text == "")
                {
                    listBox1.Items.Clear();
                    textBox10.Text = "";
                }
                string pel = textBox9.Text;
                var a = (from b in db.db_Supplier where b.Nama_Supplier.Contains(pel) select b).First();
                if (!listBox1.Items.Contains(a.Nama_Supplier))
                    listBox1.Items.Add(a.Nama_Supplier);
            }
            catch (Exception) { }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string c = listBox1.Text;
            if (listBox1.SelectedIndex != -1)
            {
                var temp = (from a in db.db_Supplier where a.Nama_Supplier == c select a).First();
                textBox10.Text = temp.ID_Supplier;
            }
        }
    }
}
