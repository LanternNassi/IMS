using Abbey_Trading_Store.DAL;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abbey_Trading_Store.UI.Advanced.Screen_forms
{
    public partial class SyncChanges : MaterialForm
    {
        public SyncChanges(DataTable Changes)
        {
            InitializeComponent();
            dataGridView1.DataSource = Changes;
        }

        private void SyncChanges_Load(object sender, EventArgs e)
        {
            DealerAndCustomer cust = new DealerAndCustomer();
            DataTable dt = cust.BulkSendCustomerContacts();
            materialButton1.Text = "Send to the " + dt.Rows.Count.ToString() + " customers";
        }
    }
}
