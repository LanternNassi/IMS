using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abbey_Trading_Store.DAL.DAL_Properties
{
    public class CategoriesProps
    {
        //Fields
        private string id;
        private string title;
        private string description;
        private string added_by;
        private int server_id;

        // properties
        public string ID { get { return id; } set { id = value; } }
        public string Title { get { return title; } set { title = value; } }
        public string Description { get { return description; } set { description = value; } }
        public string Added_by { get { return added_by; } set { added_by = value; } }
        public int Server_id { get { return server_id; }set { server_id = value;} }
    }
}
