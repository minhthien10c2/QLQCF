using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQCF
{
    public partial class SalesReport : Form
    {
        public SalesReport()
        {
            InitializeComponent();
        }

        private void ReportView_Load(object sender, EventArgs e)
        {
         
        }

        private void ReportView_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QLCFDataSet.DataTable1' table. You can move, or remove it, as needed.
            this.DataTable1TableAdapter.Fill(this.QLCFDataSet.DataTable1);
            // TODO: This line of code loads data into the 'QLCFDataSet.bill' table. You can move, or remove it, as needed.
            this.billTableAdapter.Fill(this.QLCFDataSet.bill);

            this.reportViewer1.RefreshReport();
        }
    }
}
