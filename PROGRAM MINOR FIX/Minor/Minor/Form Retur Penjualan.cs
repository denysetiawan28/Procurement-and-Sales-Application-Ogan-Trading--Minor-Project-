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
    public partial class Form_Retur_Penjualan : Form
    {
        databaseEntities db = new databaseEntities();
        List<string> li = new List<string>();
        List<string> _add = new List<string>();
        int index = 0;
        int cek = -1;
        
        public Form_Retur_Penjualan()
        {
            InitializeComponent();
        }
        public void GenerateID()
        {
            var cek2 = (from c in db.db_Retur_Penjualan
                        orderby c.No_Retur_Penjualan descending
                        select c).ToList();
            string id;
            if (cek2.Count == 0)
            {
                id = "FRJ0000001";
                labelID.Text = id;
            }
            else
            {
                id = cek2[0].No_Retur_Penjualan;
                labelID.Text = string.Format("FRJ" + "{0:0000000}", Int32.Parse(id.Substring(3, 7)) + 1);
            }
        }

        private void Form_Retur_Penjualan_Load(object sender, EventArgs e)
        {
            GenerateID();

            var tampIDPenj = from a in db.db_Form_Penjualan_Grosir
                             select a.No_Form_Penjualan_Grosir;
            comboBoxPenjGrosir.DataSource = tampIDPenj;
            comboBoxPenjGrosir.SelectedIndex = -1;
            li.Clear();
            listBoxBarang.DataSource = li;
            listBoxBarang.DataSource = _add;
            labelDate.Text = dateTimePicker1.Text;
            dateTimePicker1.Visible = false;
        }

        private void comboBoxPenjGrosir_SelectedIndexChanged(object sender, EventArgs e)
        {
            li = new List<string>();
            if (comboBoxPenjGrosir.Text != "")
            {

                string id = comboBoxPenjGrosir.Text;

                var tgl = (from a in db.db_Form_Penjualan_Grosir where a.No_Form_Penjualan_Grosir == id select a).First();
                textBox1.Text = tgl.Tanggal.ToString();

                var namabr = (from a in db.db_Detail_Form_Penjualan_Grosir where a.No_Form_Penjualan_Grosir == id select a).ToList();
                for (int i = 0; i < namabr.Count; i++)
                {
                    li.Add(namabr[i].Nama_Barang);
                }
                listBoxBarang.DataSource = li;



                //var tamp = (from a in db.db_Detail_Penjualan_Grosir
                //            where a.No_Form_Penjualan_Grosir == id
                //            select a).First();
                //string ad = tamp.ID_Barang;
                //var nam = (from a in db.db_Barang where a.ID_Barang == ad select a).First();
                //if (!listBoxBarang.Items.Contains(nam.Nama_Barang)){
                //    li.Add(nam.Nama_Barang);
                //}




            }
            

            
        }

        private void listBoxBarang_Click(object sender, EventArgs e)
        {
            if (comboBoxPenjGrosir.SelectedIndex == -1)
            {
                MessageBox.Show("Cari data terlebih dahulu", "Warning !", MessageBoxButtons.OK);
            }
            else
            {
                textBox6.Enabled = true;
                textBox5.Enabled = true;
                button3.Enabled = true;

                button1.Enabled = true;
                button2.Enabled = true;
                button4.Enabled = true;
                comboBoxPenjGrosir.Enabled = false;

                string tampNama = listBoxBarang.SelectedItem.ToString();
                var tampID = from a in db.db_Detail_Form_Penjualan_Grosir
                             where a.Nama_Barang == tampNama
                             select a.ID_Barang;

                var tampJml = (from b in db.db_Detail_Form_Penjualan_Grosir
                               where b.Nama_Barang == tampNama
                               select b).First();

                textBox2.Text = tampID.First();
                textBox3.Text = tampNama;
                textBox4.Text = tampJml.Jumlah.ToString();



            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            bool cek = true;
            int jmlRet = 0;
            int jmlBar = 0;
            try
            {
                jmlRet = int.Parse(textBox6.Text);
                jmlBar = int.Parse(textBox4.Text);
                cek = true;
            }
            catch (Exception a) { cek = false; }

            if (cek == false)
            {
                //MessageBox.Show("Jumlah Retur Harus Berupa Numeric / Angka","Warning!",MessageBoxButtons.OK);
            }

            else if (jmlRet > jmlBar || jmlRet == 0)
            {
                MessageBox.Show("Jumlah Retur Melebihi Jumlah Pembelian Barang atau kurang dari 1", "Warning !", MessageBoxButtons.OK);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool flag = true;
            bool cek = true;
            int jmlRet = 0;
            int jmlBar = 0;
            try
            {
                jmlRet = int.Parse(textBox6.Text);
                jmlBar = int.Parse(textBox4.Text);
                cek = true;
            }
            catch (Exception a) { cek = false; }

            if (listBoxBarang.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih barang terlebih dahulu!");
                flag = false;
            }

            else
            {
                flag = true;
                //int totRet = int.Parse(textBox6.Text);
            }
            if (flag == true)
            {

                bool baru = true;

                for (int i = 0; i < _add.Count; i++)
                {
                    if (_add.ElementAt(i).Equals(listBoxBarang.Text))
                    {
                        baru = false;
                    }
                }
                if (baru == false)
                {
                    MessageBox.Show("Tidak Bisa Memasukkan Barang yang Sama");
                }
                else
                {
                    if (textBox6.Text.Equals("") || textBox5.Text.Equals(""))
                    {
                        MessageBox.Show("Jumlah dan Deskripsi Tidak Boleh Kosong");
                    }
                    else if (cek == false)
                    {
                        MessageBox.Show("Jumlah Retur Harus Berupa Numeric / Angka", "Warning!", MessageBoxButtons.OK);
                    }

                    else if (jmlRet > jmlBar || jmlRet == 0)
                    {
                        MessageBox.Show("Jumlah Retur Melebihi Jumlah Pembelian Barang atau kurang dari 1", "Warning !", MessageBoxButtons.OK);
                    }
                    else if (textBox5.Text.Length > 50)
                    {
                        MessageBox.Show("Deskripsi Tidak Boleh ebih dari 50 Karakter");
                    }
                    else if (textBox5.Text.Equals(""))
                    {
                        MessageBox.Show("Deskripsi Tidak boleh Kosong");
                    }
                    else if (textBox6.Text.Equals(""))
                    {
                        MessageBox.Show("Jumlah Tidak boleh Kosong");
                    }

                    else
                    {
                        _add.Add(listBoxBarang.Text);
                        dataGridView2.Rows.Add(textBox2.Text, textBox3.Text, textBox6.Text, textBox5.Text);
                        index++;
                        textBox5.Clear();
                        textBox6.Clear();
                        comboBoxPenjGrosir.Enabled = false;
                    }

                }


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count <= 0)
            {
                MessageBox.Show("Belum ada barang yang di retur", "Warning!", MessageBoxButtons.OK);
            }
            else
            {
                db_Retur_Penjualan frpen = new db_Retur_Penjualan()
                {
                    No_Retur_Penjualan = labelID.Text,
                    No_Form_Penjualan_Grosir = comboBoxPenjGrosir.SelectedItem.ToString(),
                    Tanggal = dateTimePicker1.Text,
                };
                db.AddTodb_Retur_Penjualan(frpen);
                db.SaveChanges();

                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    string ih = "";
                    string ah = "";
                    int h = 0;
                    string eh = "";

                    try
                    {
                        ih = dataGridView2.Rows[i].Cells[0].Value.ToString();
                        ah = dataGridView2.Rows[i].Cells[1].Value.ToString();
                        h = int.Parse(dataGridView2.Rows[i].Cells[2].Value.ToString());
                        eh = dataGridView2.Rows[i].Cells[3].Value.ToString();
                    }
                    catch (Exception) { }

                    db_Detail_Retur_Penjualan dt = new db_Detail_Retur_Penjualan()
                    {
                        No_Retur_Penjualan = labelID.Text,
                        ID_Barang = ih,
                        Jumlah = h,
                        Deskripsi = eh,
                        Nama_Barang = ah,
                    };
                    db.AddTodb_Detail_Retur_Penjualan(dt);
                    db.SaveChanges();

                    
                }
                MessageBox.Show("Add Retur berhasil", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (index == 0)
            {
                MessageBox.Show("Add Data Retur Terlebih Dahulu", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (cek == -1)
            {
                MessageBox.Show("Please Choose the data first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {

                    _add.RemoveAt(cek);
                    dataGridView2.Rows.RemoveAt(dataGridView2.SelectedCells[0].RowIndex);
                    index--;
                }
                catch (Exception)
                {


                }
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cek = dataGridView2.SelectedRows.Count;
            if (dataGridView2.RowCount > 0)
            {
                int row = dataGridView2.CurrentRow.Index;
                textBox2.Text = dataGridView2.Rows[row].Cells[0].Value.ToString();
                textBox3.Text = dataGridView2.Rows[row].Cells[1].Value.ToString();
                textBox5.Text = dataGridView2.Rows[row].Cells[3].Value.ToString();
                textBox6.Text = dataGridView2.Rows[row].Cells[2].Value.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox6.Enabled = false;
            textBox5.Enabled = false;
            button3.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button4.Enabled = false;
            comboBoxPenjGrosir.Enabled = true;
            comboBoxPenjGrosir.SelectedIndex = -1;
            if (listBoxBarang.Items.Count != 0)
            {
                //listBoxBarang.DataSource = "";
                dataGridView2.Rows.Clear();
                index = 0;
                _add.Clear();
            }
            
            
            
        }
        }
    }

