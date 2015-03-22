using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using Minor.MyDataSetTableAdapters;

namespace Minor
{
    public partial class crysreportpenjualangrosir : Form
    {
        public crysreportpenjualangrosir()
        {
            InitializeComponent();
        }

        private void crysreportpenjualangrosir_Load(object sender, EventArgs e)
        {
            string id = Form_Penjualan_Grosir.id;
            MyDataSet ds = new MyDataSet();
            db_Form_Penjualan_GrosirTableAdapter g = new db_Form_Penjualan_GrosirTableAdapter();
            db_Detail_Form_Penjualan_GrosirTableAdapter d = new db_Detail_Form_Penjualan_GrosirTableAdapter();
            db_BarangTableAdapter b = new db_BarangTableAdapter();
            
            g.FillById(ds.db_Form_Penjualan_Grosir, id);
            d.FillById(ds.db_Detail_Form_Penjualan_Grosir, id);
            b.FillById(ds.db_Barang, id);
            
            

            ReportClass rc = new formpenjualangrosir();
            rc.SetDataSource(ds);

            this.crystalReportViewer1.ReportSource = rc;
            this.crystalReportViewer1.ToolPanelView = ToolPanelViewType.None;
        }
    }
}
