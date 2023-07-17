using Abbey_Trading_Store.DAL.DAL_Properties;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abbey_Trading_Store.DAL
{
    public class BusinessAccount
    {
        private int id;
        private string name;
        private string description;
        private string tel_1;
        private string tel_2;
        private string tel_3;
        private string valid;
        private int server_id;

        BusinessAccountProps props = new BusinessAccountProps();

        //Properties
        public int ID { get { return id; } set { 
                id = value;
                props.ID = value;
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                props.Name = value;
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                props.Description = value;
            }
        }

        public string Tel_1
        {
            get { return tel_1; }
            set
            {
                tel_1 = value;
                props.Tel_1 = value;
            }
        }

        public string Tel_2
        {
            get { return tel_2; }
            set
            {
                tel_2 = value;
                props.Tel_2 = value;
            }
        }

        public string Tel_3
        {
            get { return tel_3; }
            set
            {
                tel_3 = value;
                props.Tel_3 = value;
            }
        }
        public string Valid
        {
            get { return valid; }
            set
            {
                valid = value;
                props.Valid = value;
            }
        }

        public int Server_id
        {
            get { return server_id; }
            set
            {
                server_id = value;
                props.Server_id = value;
            }
        }

        SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);




        // Methods to Add and update
        public bool Insert()
        {
            bool isSuccess = false;
            try
            {
                string cmd_txt = "INSERT INTO BusinessAccount(Name , Description , Tel_1 , Tel_2 , Tel_3 , Valid , Server_id) VALUES (@Name , @Description , @Tel_1 , @Tel_2 , @Tel_3 , @Valid , @Server_id)";
                SqlCommand cmd = new SqlCommand(cmd_txt, conn);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@Tel_1", Tel_1);
                cmd.Parameters.AddWithValue("@Tel_2", Tel_2);
                cmd.Parameters.AddWithValue("@Tel_3", Tel_3);
                cmd.Parameters.AddWithValue("@Valid", Valid);
                cmd.Parameters.AddWithValue("@Server_id", Server_id);
                conn.Open();
                int results = cmd.ExecuteNonQuery();
                if (results > 0)
                {
                    isSuccess = true;
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();

            }

            return isSuccess;
        }

        public bool Update(int id)
        {
            bool success = false;
            try
            {
                string cmd_txt = "UPDATE BusinessAccount SET Name = @Name , Description = @Description , Tel_1 = @Tel_1 , Tel_2 = @Tel_2 , Tel_3 = @Tel_3 , Valid = @Valid , Server_id = @Server_id WHERE id = @id";
                SqlCommand cmd = new SqlCommand(cmd_txt, conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@Tel_1", Tel_1);
                cmd.Parameters.AddWithValue("@Tel_2", Tel_2);
                cmd.Parameters.AddWithValue("@Tel_3", Tel_3);
                cmd.Parameters.AddWithValue("@Valid", Valid);
                cmd.Parameters.AddWithValue("@Server_id", Server_id);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    success = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();
            }
            return success;

        }

        public static SqlDataAdapter Select()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            try
            {
                string cmd_txt = "SELECT * FROM BusinessAccount";
                conn.Open();
                adapter = new SqlDataAdapter(cmd_txt , conn);

                adapter.Fill(dt);

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return adapter;

        }

    }
}
