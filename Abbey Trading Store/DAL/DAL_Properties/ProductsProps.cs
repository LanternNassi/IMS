using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abbey_Trading_Store.DAL.DAL_Properties
{
    public class ProductsProps
    {
        //Fields
        private int id;
        private string Product;
        private string category;
        private string description;
        private decimal rate;
        private decimal selling_price;
        private decimal quantity;
        private DateTime added_date;
        private string added_by;

        // properties
        public int Id { get { return id; } set { id = value; } }
        public string products { get { return Product; } set { Product = value; } }
        public string Category { get { return category; } set { category = value; } }
        public string Description { get { return description; } set { description = value; } }
        public decimal Rate { get { return rate; } set { rate = value; } }
        public decimal Selling_price { get { return selling_price; } set { selling_price = value; } }
        public decimal Quantity { get { return quantity; } set { quantity = value; } }
        public DateTime Added_date { get { return added_date; } set { added_date = value; } }
        public string Added_by { get { return added_by; } set { added_by = value; } }
    }
}
