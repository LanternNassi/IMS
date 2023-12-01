using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abbey_Trading_Store.DAL.DAL_Properties
{
    public class BusinessAccountProps
    {

        //Fields
        private int id;
        private string name;
        private string description;
        private string tel_1;
        private string tel_2;
        private string tel_3;
        private string valid;
        private string location;
        private int server_id;

        // properties
        public int ID { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Description { get { return description; } set { description = value; } }
        public string Tel_1 { get { return tel_1; } set { tel_1 = value; } }
        public string Tel_2 { get { return tel_2; } set { tel_2 = value; } }
        public string Tel_3 { get { return tel_3; } set { tel_3 = value; } }
        public string Valid { get { return valid; } set { valid = value; } }
        public string Location { get { return location; } set { location = value; } }
        public int Server_id { get { return server_id; } set { server_id = value; } }


    }
}
