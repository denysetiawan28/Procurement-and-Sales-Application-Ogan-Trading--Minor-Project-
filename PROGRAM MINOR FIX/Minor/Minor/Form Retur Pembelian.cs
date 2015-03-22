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
    public partial class Form_Retur_Pembelian : Form
    {
        databaseEntities db = new databaseEntities();
        List<string> li = new List<string>();
        List<string> _add = new List<string>();
        List<string> nmmm = new List<string>();
        string status;
        int index = 0;
        int cek = -1;
        public Form_Retur_Pembelian()
        {
            InitializeComponent();
        }
        public void enableOn()
        {
            listBoxID.Enabled = true;
        }


        public void GenerateID()
        {/*
            var cek2 = (from c in db.db_Retur_Pembelian
                        orderby c.No_Retur_Pembelian descending
                        select c).ToList();
            string id;
            if (cek2.Count == 0)
            {
                id = "FRB0000001";
                labelID.Text = id;
            }
            else
            {
                id = cek2[0].No_Retur_Pembelian;
                labelID.Text = string.Format("FRB" + "{0:0000000}", Int32.Parse(id.Substring(3, 7)) + 1);
            }
            */
            string date = DateTime.Today.ToString("ddMMyy");
            int tambah = 0;
            try
            {
                var pecah = (from a in db.db_Retur_Pembelian
                           orderby a.No_Retur_Pembelian descending
                           select new { a.No_Retur_Pembelian }).First();

                string temp = pecah.No_Retur_Pembelian.Substring(1 , 6);
                //label4.Text = temp;
                if (temp != DateTime.Today.ToString("ddMMyy"))
                {
                    labelID.Text = "B" + date + "001";
                }
                else
                {
                    tambah = Int32.Parse(pecah.No_Retur_Pembelian.Substring(7));
                    tambah += 1;
                    if (tambah <= 9) labelID.Text = "B" + date + "00" + tambah;
                    else if (tambah >= 10 || tambah <= 99) labelID.Text = "B" + date + "0" + tambah;
                    else labelID.Text = "B" + date + tambah;
                    //else labelID.Text = "B" + date + tambah;
                }

            }

            catch (Exception e)
            {
                labelID.Text = "B" + date + "001";
            }
    
        }

        private void Form_Retur_Pembelian_Load(object sender, EventArgs e)
        {
            GenerateID();
            labelTanggal.Text = dateTimePicker3.Text;
            dateTimePicker3.Visible = false;
            comboBoxReturBy.Enabled = true;
            listBoxID.Enabled = true;
            txtNama.Enabled = false;
            textBox1.Enabled = false;
            txtNama.Text = "";
            txtDeskripsi.Text = "";
            txtIDBar.Text = "";
            txtJmlRet.Text = "";
            txtJumlahBar.Text = "";
            txtNamaBar.Text = "";
            button2.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            listBoxBrg.Items.Clear();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
           
            
                bool flag = true;
                bool cek = true;
                int jmlRet = 0;
                int jmlBar = 0;
                try
                {
                    jmlRet = int.Parse(txtJmlRet.Text);
                    jmlBar = int.Parse(txtJumlahBar.Text);
                    cek = true;
                }
                catch (Exception) { cek = false; }

                if (listBoxBrg.SelectedIndex == -1)
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
                        if (_add.ElementAt(i).Equals(listBoxBrg.Text))
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
                        if (txtJmlRet.Text.Equals("") || txtDeskripsi.Text.Equals(""))
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
                        else if (txtDeskripsi.Text.Length > 50)
                        {
                            MessageBox.Show("Deskripsi Tidak Boleh ebih dari 50 Karakter");
                        }
                        else if (txtDeskripsi.Text.Equals(""))
                        {
                            MessageBox.Show("Deskripsi Tidak boleh Kosong");
                        }
                        else if (txtJmlRet.Text.Equals(""))
                        {
                            MessageBox.Show("Jumlah Tidak boleh Kosong");
                        }

                        else
                        {
                            Boolean cekkk = true;
                            for (int i = 0; i < nmmm.Count; i++)
                            {
                                string namm = nmmm[i];
                                if (namm != txtNama.Text)
                                {
                                    cekkk = false;
                                    
                                }
                            }


                            if (cekkk)
                            {
                                _add.Add(listBoxBrg.Text);
                                dataGridViewDetail.Rows.Add(txtIDBar.Text, txtNamaBar.Text, txtJmlRet.Text, txtDeskripsi.Text);
                                nmmm.Add(txtNama.Text);
                            }
                            else
                            {
                                MessageBox.Show("Hanya boleh meretur dari Satu supplier yang sama", "Warning !", MessageBoxButtons.OK);
                            }
                            index++;
                            txtJmlRet.Clear();
                            txtDeskripsi.Clear();
                            comboBoxReturBy.Enabled = false; txtIDBar.Text = "";
                            txtNamaBar.Text = ""; txtJumlahBar.Text = "";
                            button2.Enabled = true;
                            button4.Enabled = true;
                            button5.Enabled = true;
                        }

                    }
                }

            }
            
        

        private void comboBoxReturBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNama.Text = "";
            txtIDBar.Text = "";
            txtNamaBar.Text = "";
            txtDeskripsi.Text = "";
            txtJumlahBar.Text = "";
            txtJmlRet.Text = "";
            if (comboBoxReturBy.SelectedIndex == 0)
            {
                enableOn();
                var tamp = from a in db.db_Faktur_Pemesanan
                           select a.No_Faktur_Pemesanan;

                label12.Text = "No Faktur Pemesanan";
                label2.Text = "ID Supplier";
                listBoxID.DataSource = tamp;
                status = "FPE";

            }
            else if (comboBoxReturBy.SelectedIndex == 1)
            {
                enableOn();
                var tamp = from a in db.db_Retur_Penjualan
                           select a.No_Retur_Penjualan;

                label12.Text = "No Retur Penjualan";
                label2.Text = "ID Supplier";
                listBoxID.DataSource = tamp;
                status = "FRJ";


            }
        }

        private void listBoxID_Click(object sender, EventArgs e)
        {
            if (listBoxID.DataSource == null)
            {
                MessageBox.Show("Cari data terlebih dahulu", "Warning !", MessageBoxButtons.OK);
            }
            else if (listBoxID.DataSource != null)
            {
                li = new List<string>();
                if (status=="FPE")
                {
                    string tampID = listBoxID.Text;


                    var id = (from a in db.db_Faktur_Pemesanan
                              where a.No_Faktur_Pemesanan == tampID
                              select a).First();
                    textBox1.Text = id.Tanggal;
                    var nama = from b in db.db_Supplier
                               where b.ID_Supplier == id.ID_Supplier
                               select b.Nama_Supplier;

                    txtNama.Text = nama.First();


                    var namabr = (from a in db.db_Detail_Faktur_Pemesanan where a.No_Faktur_Pemesanan == tampID select a).ToList();
                    for (int i = 0; i < namabr.Count; i++)
                    {
                        li.Add(namabr[i].Nama_Barang);
                    }
                    listBoxBrg.DataSource = li;

                }
                else if (status=="FRJ")
                {
                    string tampID = listBoxID.Text;


                    var id = (from a in db.db_Retur_Penjualan
                              where a.No_Retur_Penjualan == tampID
                              select a).First();
                    textBox1.Text = id.Tanggal;
                    var ed = (from c in db.db_Form_Penjualan_Grosir
                              where c.No_Form_Penjualan_Grosir == id.No_Form_Penjualan_Grosir
                              select c).First();

                    var nama = from b in db.db_Pelanggan
                               where b.ID_Pelanggan == ed.ID_Pelanggan
                               select b.Nama_Pelanggan;


                    var namabr = (from a in db.db_Detail_Retur_Penjualan where a.No_Retur_Penjualan == tampID select a).ToList();
                    for (int i = 0; i < namabr.Count; i++)
                    {
                        li.Add(namabr[i].Nama_Barang);
                    }
                    listBoxBrg.DataSource = li;
                    

                }

            }
        }

        private void listBoxBrg_Click(object sender, EventArgs e)
        {
            
            txtJmlRet.Text="";
            if (listBoxID.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih No Faktur Terlebih dahulu", "Warning", MessageBoxButtons.OK);
            }

            else
            {
                txtJmlRet.Enabled = true;
                txtDeskripsi.Enabled = true;

                button3.Enabled = true;

                button1.Enabled = true;
                
                listBoxID.Enabled = false;

                if (status == "FRJ")
                {
                    string tampNama = listBoxBrg.SelectedItem.ToString();
                    string idrt = listBoxID.SelectedItem.ToString();

                    
                    txtNamaBar.Text = tampNama;
                    var ta=(from a in db.db_Barang where a.Nama_Barang==tampNama select a).First();

                    var tam = (from a in db.db_Detail_Retur_Penjualan where a.ID_Barang == ta.ID_Barang select a).First();
                    txtIDBar.Text = ta.ID_Barang;
                    
                    txtJumlahBar.Text = tam.Jumlah.ToString();
                    txtDeskripsi.Enabled = false;
                    txtDeskripsi.Text = tam.Deskripsi;

                    var sp=(from a in db.db_Barang where a.ID_Barang==ta.ID_Barang select a).First();
                    var spnm=(from a in db.db_Supplier where a.ID_Supplier==sp.ID_Supplier select a).First();
                    txtNama.Text = spnm.Nama_Supplier;
                }
                else if (status == "FPE")
                {
                    string dd = listBoxID.SelectedItem.ToString();
                    string tampNama = listBoxBrg.SelectedItem.ToString();
                    var tampID = (from a in db.db_Detail_Faktur_Pemesanan
                                  where a.No_Faktur_Pemesanan == dd &&
                                  a.Nama_Barang == tampNama
                                  select a).First();
                    txtIDBar.Text = tampID.ID_Barang;
                    txtNamaBar.Text = tampNama;
                    txtJumlahBar.Text = tampID.Jumlah+"";
                    var sp = (from a in db.db_Barang where a.ID_Barang == tampID.ID_Barang select a).First();
                    var spnm = (from a in db.db_Supplier where a.ID_Supplier == sp.ID_Supplier select a).First();
                    txtNama.Text = spnm.Nama_Supplier;
                }


            }
        }

        private void txtJmlRet_TextChanged(object sender, EventArgs e)
        {
            bool cek = true;
            int jmlRet = 0;
            int jmlBar = 0;
            try
            {
                jmlRet = int.Parse(txtJmlRet.Text);
                jmlBar = int.Parse(txtJumlahBar.Text);
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

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (comboBoxReturBy.SelectedIndex == 0)
            {
                var culture = System.Globalization.CultureInfo.CurrentCulture;
                string a = dateTimePicker3.Value.ToString();
                var b = from d in db.db_Faktur_Pemesanan
                        where d.Tanggal == a
                        select d.No_Faktur_Pemesanan;

                listBoxID.DataSource = b;

            }
            else if (comboBoxReturBy.SelectedIndex == 1)
            {
                var culture = System.Globalization.CultureInfo.CurrentCulture;
                string a = dateTimePicker3.Value.ToString();
                var b = from d in db.db_Retur_Penjualan
                        where d.Tanggal == a
                        select d.No_Retur_Penjualan;

                listBoxID.DataSource = b;
            }
        }

        private void dataGridViewDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cek = dataGridViewDetail.SelectedRows.Count;
            if (dataGridViewDetail.RowCount > 0)
            {
                int row = dataGridViewDetail.CurrentRow.Index;
                txtIDBar.Text = dataGridViewDetail.Rows[row].Cells[0].Value.ToString();
                txtNamaBar.Text = dataGridViewDetail.Rows[row].Cells[1].Value.ToString();
                txtJmlRet.Text = dataGridViewDetail.Rows[row].Cells[3].Value.ToString();
                txtDeskripsi.Text = dataGridViewDetail.Rows[row].Cells[2].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
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
                    dataGridViewDetail.Rows.RemoveAt(dataGridViewDetail.SelectedCells[0].RowIndex);
                    index--;
                }
                catch (Exception)
                {


                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridViewDetail.Rows.Count <= 0)
            {
                MessageBox.Show("Belum ada barang yang di retur", "Warning!", MessageBoxButtons.OK);
            }
            else
            {
                string tampID = "";
                if (status=="FRJ")
                {
                    try
                    {
                        tampID = listBoxID.Text;
                        db_Retur_Pembelian frpem = new db_Retur_Pembelian()
                        {
                            No_Retur_Pembelian = labelID.Text,
                            No_Retur_Penjualan = tampID,
                            No_Faktur_Pemesanan = "",
                            Tanggal = dateTimePicker3.Text,
                        };
                        db.AddTodb_Retur_Pembelian(frpem);
                        db.SaveChanges();


                        for (int i = 0; i < dataGridViewDetail.RowCount; i++)
                        {
                            string ih = "";
                            string ah = "";
                            int h = 0;
                            string eh = "";

                            try
                            {
                                ih = dataGridViewDetail.Rows[i].Cells[0].Value.ToString();
                                ah = dataGridViewDetail.Rows[i].Cells[1].Value.ToString();
                                h = int.Parse(dataGridViewDetail.Rows[i].Cells[2].Value.ToString());
                                eh = dataGridViewDetail.Rows[i].Cells[3].Value.ToString();
                            }
                            catch (Exception) { }

                            db_Detail_Retur_Pembelian dd = new db_Detail_Retur_Pembelian()
                            {
                                No_Retur_Pembelian = labelID.Text,
                                ID_Barang = ih,
                                Jumlah = h,
                                Deskripsi = eh,
                                Nama_Barang = ah,
                            };
                            db.AddTodb_Detail_Retur_Pembelian(dd);
                            db.SaveChanges();

                            //var t = (from a in db.db_Detail_Retur_Penjualan where a.No_Retur_Penjualan == tampID && a.ID_Barang ==ih select a).First();
                            //t.Jumlah = t.Jumlah - h;
                            //db.SaveChanges();
                        }
                    }
                    catch (Exception) { }
                    

                }
                else if (status == "FPE")
                {
                    try
                    {
                        tampID = listBoxID.Text;
                        db_Retur_Pembelian frpem = new db_Retur_Pembelian()
                        {
                            No_Retur_Pembelian = labelID.Text,
                            No_Retur_Penjualan = "",
                            No_Faktur_Pemesanan = tampID,
                            Tanggal = dateTimePicker3.Text,
                        };
                        db.AddTodb_Retur_Pembelian(frpem);
                        db.SaveChanges();




                        for (int i = 0; i < dataGridViewDetail.RowCount; i++)
                        {
                            string ih = "";
                            string ah = "";
                            int h = 0;
                            string eh = "";

                            try
                            {
                                ih = dataGridViewDetail.Rows[i].Cells[0].Value.ToString();
                                ah = dataGridViewDetail.Rows[i].Cells[1].Value.ToString();
                                h = int.Parse(dataGridViewDetail.Rows[i].Cells[2].Value.ToString());
                                eh = dataGridViewDetail.Rows[i].Cells[3].Value.ToString();
                            }
                            catch (Exception) { }

                            db_Detail_Retur_Pembelian dt = new db_Detail_Retur_Pembelian()
                            {
                                No_Retur_Pembelian = labelID.Text,
                                ID_Barang = ih,
                                Jumlah = h,
                                Deskripsi = eh,
                                Nama_Barang = ah,
                            };
                            db.AddTodb_Detail_Retur_Pembelian(dt);
                            db.SaveChanges();
                            //try
                            //{
                            //    var t = (from a in db.db_Detail_Faktur_Pemesanan where a.No_Faktur_Pemesanan == tampID && a.ID_Barang == ih select a).First();
                            //    t.Jumlah = t.Jumlah - h;
                            //}
                            //catch (Exception) { }


                        }
                    }catch (Exception) { }
                }
                MessageBox.Show("Add Retur berhasil", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button2.Enabled = false;
                button1.Enabled = false;
                button4.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form_Retur_Pembelian_Load(this, e);
        }

        private void listBoxID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}