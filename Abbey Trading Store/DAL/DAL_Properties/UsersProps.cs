using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abbey_Trading_Store.DAL.DAL_Properties
{
    public class UsersProps
    {
        //declaring fields
        private int Id;
        private string User;
        private string Password;
        private string Gender;
        private string Added_by;
        private string Type;
        private int Server_id;

        // declaring properties for the fields 
        public int id { get; set; }
        public string user { get { return User; } set { User = value; } }
        public string contact { get { return Password; } set { Password = value; } }
        public string gender { get { return Gender; } set { Gender = value; } }
        public string added_by { get { return Added_by; } set { Added_by = value; } }
        public string type { get { return Type; } set { Type = value; } }
        public int server_id { get { return Server_id; } set { Server_id = value;} }

    }
}
