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
        public string Report_resource;

        public ReportView(ReportDataSource [] Source_list , string Report_resource_string)
        {
            Sources = Source_list;
            Report_resource = Report_resource_string;
            InitializeComponent();

        }
        private void ReportView_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.ReportEmbeddedResource = Report_resource;
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.ReportEmbeddedResource = Report_resource;
            this.reportViewer1.LocalReport.DataSources.Clear();
            for(int i = 0; i< Sources.Length; i++)
            {
                this.reportViewer1.LocalReport.DataSources.Add(Sources[i]);
            }
            
            this.reportViewer1.RefreshReport();
        }
    }
}
