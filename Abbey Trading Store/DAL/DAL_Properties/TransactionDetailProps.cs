using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abbey_Trading_Store.DAL.DAL_Properties
{
    public class TransactionDetailProps
    {
        //Fields
        private int ID;
        private string product_name;
        private decimal rate;
        private string Qty;
        private decimal total;
        private string dea_cust_name;
        private DateTime added_date;
        private string added_by;
        private int Invoice_id;
        private int Profit;
        private string Type;
        private int Server_id;

        //Properties
        public int id { get { return ID; } set { ID = value; } }
        public string Product_name { get { return product_name; } set { product_name = value; } }
        public decimal Rate { get { return rate; } set { rate = value; } }
        public string qty { get { return Qty; } set { Qty = value; } }
        public decimal Total { get { return total; } set { total = value; } }
        public string Dea_Cust_name { get { return dea_cust_name; } set { dea_cust_name = value; } }
        public DateTime Added_date { get { return added_date; } set { added_date = value; } }
        public string Added_by { get { return added_by; } set { added_by = value; } }
        public int invoice_id { get { return Invoice_id; } set { Invoice_id = value; } }
        public int profit { get { return Profit; } set { Profit = value; } }
        public string type { get { return Type; } set { Type = value; } }
        public int server_id { get { return Server_id; } set { Server_id = value; } }
    }
}
