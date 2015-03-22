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
    public partial class Form_Registrasi_Suuplier : Form
    {
        databaseEntities db = new databaseEntities();
        int status;

        private void loadData()
        {
            var a = from c in db.db_Supplier select c;
            dataGridView1.DataSource = a;
        }

        public void InsertSupplier()
        {
            var cek2 = (from c in db.db_Supplier
                        orderby c.ID_Supplier descending
                        select c).ToList();
            string id;
            if (cek2.Count == 0)
            {
                id = "SP0001";
                textBox1.Text = id;
            }
            else
            {
                id = cek2[0].ID_Supplier;
                textBox1.Text = string.Format("SP" + "{0:0000}", Int32.Parse(id.Substring(2, 4)) + 1);
            }
        }

        private void textEnabled(bool a)
        {
            textBox2.Enabled = a;
            textBox3.Enabled = a;
            textBox4.Enabled = a;
            textBox5.Enabled = a;
            textBox6.Enabled = a;
            textBox7.Enabled = a;
            textBox9.Enabled = a;
        }

        private void btnEnabled(bool a)
        {
            button1.Enabled = a;
            button2.Enabled = a;
            button3.Enabled = a;
            button4.Enabled = !a;
            button5.Enabled = !a;
        }

        public Form_Registrasi_Suuplier()
        {
            InitializeComponent();
            textBox1.Enabled = false;
        }

        private void Form_Registrasi_Suuplier_Load(object sender, EventArgs e)
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
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertSupplier();
            textEnabled(true);
            btnEnabled(false);
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
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

        private void DeleteSupplier(string id)
        {
            if (id == "")
            {
                MessageBox.Show("Pilih data yang ingin dihapus!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (MessageBox.Show(this, "Are you sure want to delete Supplier " + textBox1.Text + " ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var t = (from a in db.db_Supplier.ToList()
                         where a.ID_Supplier == id
                         select a).First();
                db.DeleteObject(t);
                db.SaveChanges();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteSupplier(textBox1.Text);
            Form_Registrasi_Suuplier_Load(this, e);//awal
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form_Registrasi_Suuplier_Load(this, e);//awal
        }

        private void AddSupplier(string id,string nama,string tlp,string eml, string alm, string kota,string kp,string lk){
            db_Supplier kr = new db_Supplier()
                    {
                        ID_Supplier = id,
                        Nama_Supplier = nama,
                        No_Telepon_Supplier = tlp,
                        Email_Supplier=eml,
                        Alamat_Supplier = alm,
                        Kota_Supplier=kota,
                        Kodepos=int.Parse(kp),
                        Lama_Kontrak=int.Parse(lk)
                    };
                    db.AddTodb_Supplier(kr);
                    db.SaveChanges();
        }

        private void UpdateSupplier(string id, string nama, string tlp, string eml, string alm, string kota, string kp,string lk)
        {
            var kt = (from a in db.db_Supplier.ToList()
                      where a.ID_Supplier == id
                      select a).First();
            kt.Nama_Supplier = nama;
            kt.No_Telepon_Supplier = tlp;
            kt.Email_Supplier = eml;
            kt.Alamat_Supplier = alm;
            kt.Kota_Supplier = kota;
            kt.Kodepos = int.Parse(kp);
            kt.Lama_Kontrak = int.Parse(lk);
            db.SaveChanges();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Regex regNum = new Regex(@"^\d+$");
            if (textBox1.Text == "")
                MessageBox.Show("Kolom ID tidak boleh kosong !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (textBox2.Text == "")
                MessageBox.Show("Kolom Nama tidak boleh kosong !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             else if (textBox4.Text == "")
                 MessageBox.Show("Kolom Nomor Telepon tidak boleh kosong !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             else if (textBox5.Text == "")
                 MessageBox.Show("Kolom Email tidak boleh kosong !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             else if (textBox3.Text == "")
                MessageBox.Show("Kolom Alamat tidak boleh kosong !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             else if (textBox6.Text == "")
                 MessageBox.Show("Kolom Kota tidak boleh kosong !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             else if (textBox7.Text == "")
                 MessageBox.Show("Kolom Kode Pos tidak boleh kosong !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if(regNum.IsMatch(textBox7.Text)==false)
                MessageBox.Show("Kolom Kode Pos harus Numeric !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (textBox9.Text == "")
                MessageBox.Show("Kolom Lama Kontrak tidak boleh kosong !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (regNum.IsMatch(textBox9.Text) == false)
                MessageBox.Show("Kolom Lama Kontrak harus Numeric !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (status == 0)
                {
                    AddSupplier(textBox1.Text,textBox2.Text,textBox4.Text,textBox5.Text,textBox3.Text,textBox6.Text,textBox7.Text,textBox9.Text);
                }
                else if (status == 1)
                {
                    UpdateSupplier(textBox1.Text, textBox2.Text, textBox4.Text, textBox5.Text, textBox3.Text, textBox6.Text, textBox7.Text,textBox9.Text);
                  
                }
                Form_Registrasi_Suuplier_Load(this, e);//awal
            }
        }

        private void SearchSupplier(string nama) {
            var temp = from a in db.db_Supplier where a.Nama_Supplier.Contains(nama) select a;
            dataGridView1.DataSource = temp;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            SearchSupplier(textBox8.Text);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
    }
}
