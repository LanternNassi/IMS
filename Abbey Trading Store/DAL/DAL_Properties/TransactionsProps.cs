using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abbey_Trading_Store.DAL.DAL_Properties
{
    public class TransactionsProps
    {
        // Fields
        private int ID;
        private string type;
        private string dea_cust_name;
        private int grandTotal;
        private DateTime transaction_date;
        private int discount;
        private string added_by;
        private int return_amount;
        private int paid_amount;
        private int total_profit;
        private string paid;
        private string taken;
        private int server_id;

        // properties
        public int id { get { return ID; } set { ID = value; } }
        public string Type { get { return type; } set { type = value; } }
        public string Dea_Cust_name { get { return dea_cust_name; } set { dea_cust_name = value; } }
        public int GrandTotal { get { return grandTotal; } set { grandTotal = value; } }
        public DateTime Transaction_date { get { return transaction_date; } set { transaction_date = value; } }
        public int Discount { get { return discount; } set { discount = value; } }
        public string Added_by { get { return added_by; } set { added_by = value; } }
        public int Return_amount { get { return return_amount; } set { return_amount = value; } }
        public int Paid_amount { get { return paid_amount; } set { paid_amount = value; } }
        public int Total_Profit { get { return total_profit; } set { total_profit = value; } }
        public string Paid { get { return paid; } set { paid = value; } }
        public string Taken { get { return taken; } set { taken = value; } }
        public int Server_id { get { return server_id; } set { server_id= value; } }



    }
}
