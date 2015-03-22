using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Minor
{
    public partial class Form_Login : Form
    {
        databaseEntities db = new databaseEntities();
        FormMDI fm;
        public Form_Login(FormMDI fm)
        {
            InitializeComponent();
            this.fm = fm;
        }

        private void Form_Login_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show(this, "Masukan ID / Password anda!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var temp = from a in db.db_Karyawan where a.ID_Karyawan==textBox2.Text&& a.Password==textBox1.Text select a;
                if (temp.Any())
                {
                    MessageBox.Show(this, "Berhasil Login", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var b = (from a in db.db_Karyawan where a.ID_Karyawan == textBox2.Text select a).First();
                    string position = b.Jabatan;
                    
                    if (position == "Owner")
                    {
                        fm.loginToolStripMenuItem.Visible = false;
                        fm.logoutToolStripMenuItem.Visible = true;
                        fm.masterToolStripMenuItem.Visible = true;
                        fm.transaksiToolStripMenuItem.Visible = true;
                        fm.laporanToolStripMenuItem.Visible = true;
                        fm.returToolStripMenuItem.Visible = true;
                    }
                    else if (position == "Manager")
                    {
                        fm.loginToolStripMenuItem.Visible = false;
                        fm.logoutToolStripMenuItem.Visible = true;
                        fm.masterToolStripMenuItem.Visible = true;
                        fm.transaksiToolStripMenuItem.Visible = true;
                        fm.laporanToolStripMenuItem.Visible = true;
                        fm.returToolStripMenuItem.Visible = true;
                    }
                    else if (position == "Administrator Gudang")
                    {
                        fm.loginToolStripMenuItem.Visible = false;
                        fm.logoutToolStripMenuItem.Visible = true;
                        fm.masterToolStripMenuItem.Visible = true;
                        fm.karyawanToolStripMenuItem.Visible = false;
                        fm.transaksiToolStripMenuItem.Visible = true;
                        fm.penjualanRetailToolStripMenuItem.Visible = false;
                        fm.returToolStripMenuItem.Visible = true;
                    }
                    else if (position == "Kasir")
                    {
                        fm.loginToolStripMenuItem.Visible = false;
                        fm.logoutToolStripMenuItem.Visible = true;
                        fm.transaksiToolStripMenuItem.Visible = true;
                        fm.penjualanGrosirToolStripMenuItem.Visible = false; 
                        fm.penjualanRetailToolStripMenuItem.Visible = true;
                        fm.returToolStripMenuItem.Visible = false;
                        fm.pemesananToolStripMenuItem.Visible = false;
                    }
                    fm.id = textBox2.Text;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(this, "Login gagal, ID / Password salah", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
