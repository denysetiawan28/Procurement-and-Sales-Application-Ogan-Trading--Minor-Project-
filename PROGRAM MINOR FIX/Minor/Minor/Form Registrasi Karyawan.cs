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
    public partial class Form_Registrasi_Karyawan : Form
    {
        databaseEntities db = new databaseEntities();
        int status;

        public Form_Registrasi_Karyawan()
        {
            InitializeComponent();
            textBox1.Enabled = false;
        }

        private void loadData()
        {
            var a = from c in db.db_Karyawan select c;
            dataGridView1.DataSource = a;
        }

        public void InsertKaryawan()
        {
            var cek2 = (from c in db.db_Karyawan
                        orderby c.ID_Karyawan descending
                        select c).ToList();
            string id;
            if (cek2.Count == 0)
            {
                id = "KR0001";
                textBox1.Text = id;
            }
            else
            {
                id = cek2[0].ID_Karyawan;
                textBox1.Text = string.Format("KR" + "{0:0000}", Int32.Parse(id.Substring(2, 4)) + 1);
            }
        }

        private void textEnabled(bool a)
        {
            textBox2.Enabled = a;
            textBox3.Enabled = a;
            comboBox1.Enabled = a;
            textBox5.Enabled = a;
            textBox4.Enabled = a;
            textBox6.Enabled = a;
            textBox7.Enabled = a;
            dateTimePicker1.Enabled = a;
            radioButton2.Enabled = a;
            radioButton1.Enabled = a;
        }

        private void btnEnabled(bool a)
        {
            button1.Enabled = a;
            button2.Enabled = a;
            button3.Enabled = a;
            button4.Enabled = !a;
            button5.Enabled = !a;
        }

        private void Form_Registrasi_Karyawan_Load(object sender, EventArgs e)
        {
            textEnabled(false);
            btnEnabled(true);
            loadData();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            dateTimePicker1.Value= DateTime.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());
            string jk= dataGridView1.CurrentRow.Cells[3].Value.ToString();
            if (jk == "Perempuan")radioButton2.Checked = true;
            else radioButton1.Checked = true;
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            comboBox1.Text= dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertKaryawan();
            textEnabled(true);
            btnEnabled(false);
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            dateTimePicker1.Value = DateTime.Now;
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

        private void DeleteKaryawan(string id)
        {
            if (id == "")
            {
                MessageBox.Show("Pilih data yang ingin dihapus!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (MessageBox.Show(this, "Are you sure want to delete Karyawan " + textBox1.Text + " ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var t = (from a in db.db_Karyawan.ToList()
                         where a.ID_Karyawan == id
                         select a).First();
                db.DeleteObject(t);
                db.SaveChanges();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteKaryawan(textBox1.Text);   
            Form_Registrasi_Karyawan_Load(this,e);//awal
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form_Registrasi_Karyawan_Load(this, e);//awal
        }

        private void AddKaryawan(string id,string nama,string tgl,string jenis,string tlp,string eml,string alm,string kota,string jabatan,string pass)
        {
            db_Karyawan kr = new db_Karyawan()
            {
                ID_Karyawan = id,
                Nama_Karyawan = nama,
                Tanggal_Lahir_Karyawan = DateTime.Parse(tgl),
                Jenis_Kelamin_Karyawan = jenis,
                No_Telepon_Karyawan = tlp,
                Email_Karyawan = eml,
                Alamat_Karyawan = alm,
                Kota_Karyawan = kota,
                Jabatan = jabatan,
                Password = pass
            };
            db.AddTodb_Karyawan(kr);
            db.SaveChanges();
        }
        private void UpdateKaryawan(string id, string nama, string tgl, string jenis, string tlp, string eml, string alm, string kota, string jabatan, string pass)
        {
            var kt = (from a in db.db_Karyawan.ToList()
                      where a.ID_Karyawan == id
                      select a).First();
            kt.Nama_Karyawan = nama;
            kt.Tanggal_Lahir_Karyawan = DateTime.Parse(tgl);
            kt.Jenis_Kelamin_Karyawan = jenis;
            kt.No_Telepon_Karyawan = tlp;
            kt.Email_Karyawan = eml;
            kt.Alamat_Karyawan = alm;
            kt.Kota_Karyawan = kota;
            kt.Jabatan = jabatan;
            kt.Password = pass;
            db.SaveChanges();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            Regex email = new Regex(@"^\w+@\w+\.\w+$");
            if(textBox1.Text=="")
                MessageBox.Show("Kolom ID tidak boleh kosong !","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            else if(textBox2.Text=="")
                MessageBox.Show("Kolom Nama tidak boleh kosong !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if(dateTimePicker1.Value.Year>1996)
                MessageBox.Show("Umur karyawan minimum = 17 Tahun !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if(radioButton1.Checked==false&&radioButton2.Checked==false)
                MessageBox.Show("Pilih Jenis Kelamin !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (textBox5.Text == "")
                MessageBox.Show("Kolom Nomor Telepon tidak boleh kosong !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (textBox6.Text == "")
                MessageBox.Show("Kolom Email tidak boleh kosong !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (email.IsMatch(textBox6.Text)==false)
                MessageBox.Show("Format Email salah !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if(textBox3.Text=="")
                MessageBox.Show("Kolom Alamat tidak boleh kosong !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (textBox4.Text == "")
                MessageBox.Show("Kolom Kota tidak boleh kosong !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if(comboBox1.Text=="")
                MessageBox.Show("Pilih Jabatan ! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (textBox7.Text == "")
                MessageBox.Show("Kolom Password tidak boleh kosong !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    AddKaryawan(textBox1.Text,textBox2.Text,dateTimePicker1.Text,jk,textBox5.Text,textBox6.Text,textBox3.Text,textBox4.Text,comboBox1.Text,textBox7.Text);
                }
                else if (status == 1)
                {
                    UpdateKaryawan(textBox1.Text, textBox2.Text, dateTimePicker1.Text, jk, textBox5.Text, textBox6.Text, textBox3.Text, textBox4.Text, comboBox1.Text, textBox7.Text);
                }
                Form_Registrasi_Karyawan_Load(this, e);//awal
            }
        }
    }
}
