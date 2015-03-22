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
    public partial class Form_Registrasi_Customer : Form
    {
        databaseEntities db = new databaseEntities();
        int status;

        private void loadData()
        {
            var a = from c in db.db_Pelanggan select new { c.ID_Pelanggan,c.Nama_Pelanggan,c.Jenis_Kelamin_Pelanggan,c.No_Telepon_Pelanggan,c.Email_Pelanggan,c.Alamat_Pelanggan ,c.Kota_Pelanggan };
            dataGridView1.DataSource = a;
        }

        public void InsertPelanggan()
        {
            var cek2 = (from c in db.db_Pelanggan
                        orderby c.ID_Pelanggan descending
                        select c).ToList();
            string id;
            if (cek2.Count == 0)
            {
                id = "PL0001";
                textBox1.Text = id;
            }
            else
            {
                id = cek2[0].ID_Pelanggan;
                textBox1.Text = string.Format("PL" + "{0:0000}", Int32.Parse(id.Substring(2, 4)) + 1);
            }
        }

        private void textEnabled(bool a)
        {
            textBox2.Enabled = a;
            textBox3.Enabled = a;
            textBox4.Enabled = a;
            textBox5.Enabled = a;
            textBox6.Enabled = a;
            radioButton1.Enabled = a;
            radioButton2.Enabled = a;
        }

        private void btnEnabled(bool a)
        {
            button1.Enabled = a;
            button2.Enabled = a;
            button3.Enabled = a;
            button4.Enabled = !a;
            button5.Enabled = !a;
        }

        public Form_Registrasi_Customer()
        {
            InitializeComponent();
            textBox1.Enabled = false;
        }

        private void Form_Registrasi_Customer_Load(object sender, EventArgs e)
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
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string jkl= dataGridView1.CurrentRow.Cells[2].Value.ToString();
            if (jkl == "Perempuan") radioButton2.Checked = true;
            else radioButton1.Checked = true;
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertPelanggan();
            textEnabled(true);
            btnEnabled(false);
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            status = 0;
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

        private void deletePelanggan(string id)
        {
            if (id == "")
            {
                MessageBox.Show("Pilih data yang ingin dihapus!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (MessageBox.Show(this, "Are you sure want to delete Pelanggan " + textBox1.Text + " ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var t = (from a in db.db_Pelanggan.ToList()
                         where a.ID_Pelanggan == id
                         select a).First();
                db.DeleteObject(t);
                db.SaveChanges();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            deletePelanggan(textBox1.Text);
            Form_Registrasi_Customer_Load(this, e);//awal
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form_Registrasi_Customer_Load(this, e);//awal
        }


        private void addPelanggan(string id,string nama,string jkp,string tlp,string eml,string ala,string kota)
        {
            db_Pelanggan kr = new db_Pelanggan()
            {
                ID_Pelanggan = id,
                Nama_Pelanggan = nama,
                Jenis_Kelamin_Pelanggan = jkp,
                No_Telepon_Pelanggan = tlp,
                Email_Pelanggan = eml,
                Alamat_Pelanggan = ala,
                Kota_Pelanggan = kota,
                Count=0
            };
            db.AddTodb_Pelanggan(kr);
            db.SaveChanges();
        }

        private void updatePelanggan(string id, string nama, string jkp, string tlp, string eml, string ala, string kota)
        {
            var kt = (from a in db.db_Pelanggan.ToList()
                      where a.ID_Pelanggan == id
                      select a).First();
            kt.Nama_Pelanggan = nama;
            kt.Jenis_Kelamin_Pelanggan = jkp;
            kt.No_Telepon_Pelanggan = tlp;
            kt.Email_Pelanggan = eml;
            kt.Alamat_Pelanggan = ala;
            kt.Kota_Pelanggan = kota;

            db.SaveChanges();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Regex email = new Regex(@"^\w+@\w+\.\w+$");
            if (textBox1.Text == "")
                MessageBox.Show("Kolom ID tidak boleh kosong !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (textBox2.Text == "")
                MessageBox.Show("Kolom Nama tidak boleh kosong !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (radioButton1.Checked == false && radioButton2.Checked == false)
                MessageBox.Show("Pilih Jenis Kelamin !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (textBox4.Text == "")
                MessageBox.Show("Kolom Nomor Telepon tidak boleh kosong !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (textBox5.Text == "")
                MessageBox.Show("Kolom Email tidak boleh kosong !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (email.IsMatch(textBox5.Text) == false)
                MessageBox.Show("Format Email salah !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (textBox3.Text == "")
                MessageBox.Show("Kolom Alamat tidak boleh kosong !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (textBox6.Text == "")
                MessageBox.Show("Kolom Kota tidak boleh kosong !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            else
            {
                string jk = "";
                if (radioButton2.Checked == true)
                {
                    jk = "Perempuan";
                }
                else
                {
                    jk = "Laki-Laki";
                }
                if (status == 0)
                {
                    addPelanggan(textBox1.Text,textBox2.Text,jk,textBox4.Text,textBox5.Text,textBox3.Text,textBox6.Text);
                }
                else if (status == 1)
                {
                    updatePelanggan(textBox1.Text, textBox2.Text, jk, textBox4.Text, textBox5.Text, textBox3.Text, textBox6.Text);
                }
                Form_Registrasi_Customer_Load(this, e);//awal
            }
        }

        private void SearchPelanggan(string nama)
        {
            var temp = from a in db.db_Pelanggan where a.Nama_Pelanggan.Contains(nama) select a;
            dataGridView1.DataSource = temp;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            SearchPelanggan(textBox7.Text);
        }
    }
}
