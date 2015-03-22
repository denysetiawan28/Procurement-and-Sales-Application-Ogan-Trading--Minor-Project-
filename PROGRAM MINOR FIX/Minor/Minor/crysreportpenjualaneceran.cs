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
    public partial class crysreportpenjualaneceran : Form
    {
        public crysreportpenjualaneceran()
        {
            InitializeComponent();
        }

        private void crysreportpenjualaneceran_Load(object sender, EventArgs e)
        {
            string id = FormPenjRetail.id;
            MyDataSet ds = new MyDataSet();
            db_Form_Penjualan_EceranTableAdapter d = new db_Form_Penjualan_EceranTableAdapter();
            db_BarangTableAdapter b = new db_BarangTableAdapter();
            db_Detail_Form_Penjualan_EceranTableAdapter dt = new db_Detail_Form_Penjualan_EceranTableAdapter();

            d.FillById(ds.db_Form_Penjualan_Eceran, id);
            b.FillByIdeceran(ds.db_Barang, id);
            dt.FillByid(ds.db_Detail_Form_Penjualan_Eceran, id);

            ReportClass rc = new formpenjualaneceran();
            rc.SetDataSource(ds);

            this.crystalReportViewer1.ReportSource = rc;
            this.crystalReportViewer1.ToolPanelView = ToolPanelViewType.None;

        }
    }
}
