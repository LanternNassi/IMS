using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.OleDb;
using Microsoft.Reporting.WinForms;
using System.Text;
using System.Windows.Forms;
using Abbey_Trading_Store.Reports.Invoice_Report;

namespace Abbey_Trading_Store.UI
{
    public partial class ReportView : Form
    {
        public ReportDataSource[] Sources;

        public ReportView(ReportDataSource [] Source_list)
        {
            Sources = Source_list;
            InitializeComponent();
        }
        private void ReportView_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Abbey_Trading_Store.Reports.Invoice_Report.Invoice.rdlc";
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Abbey_Trading_Store.Reports.Invoice_Report.Invoice.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(Sources[0]);
            this.reportViewer1.LocalReport.DataSources.Add(Sources[1]);
            this.reportViewer1.RefreshReport();
        }
    }
}
