using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abbey_Trading_Store.DAL.DAL_Properties
{
    public class DealersCustProps
    {
        //fields
        private int id;
        private string type;
        private string name;
        private string email;
        private string contact;
        private string address;
        private string added_by;

        // properties
        public int Id { get { return id; } set { id = value; } }
        public string Type { get { return type; } set { type = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Contact { get { return contact; } set { contact = value; } }
        public string Address { get { return address; } set { address = value; } }
        public string Added_by { get { return added_by; } set { added_by = value; } }


    }
}
