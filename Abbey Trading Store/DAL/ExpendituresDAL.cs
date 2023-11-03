using Abbey_Trading_Store.DAL.DAL_Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abbey_Trading_Store.DAL
{
    public class ExpendituresDAL
    {
        Expenditures expenditure;
        int category;
        int overall_category;
        public ExpendituresDAL(Expenditures exp) {
            this.expenditure = exp;
        }
        public ExpendituresDAL(int category, int overall_category)
        {
            this.category = category;
            this.overall_category = overall_category;
        }
        public bool InsertExpenditure()
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            try
            {
                const string cmds = "INSERT INTO Expenditures(Description , Amount , Added_by , Overall_category , Category)VALUES(@Description , @Amount , @Added_by , @Overall_category , @Category);";
                SqlCommand cmd = new SqlCommand(cmds, conn);
                cmd.Parameters.AddWithValue("@Description", expenditure.Description);
                cmd.Parameters.AddWithValue("@Amount", expenditure.Amount);
                cmd.Parameters.AddWithValue("@Added_by", expenditure.Added_by);
                cmd.Parameters.AddWithValue("@Overall_category", expenditure.Overall_category);
                cmd.Parameters.AddWithValue("@Category", expenditure.Category);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
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
            return isSuccess;
        }

        public SqlDataAdapter Select()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter dummy_adapter = new SqlDataAdapter();
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            string command = "SELECT * FROM Expenditures WHERE Overall_category = " + overall_category.ToString();
            if (category != 0 )
            {
                command = "SELECT * FROM Expenditures WHERE Overall_category = " + overall_category.ToString() + "AND Category = " + category.ToString();

            }
        
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command, conn);
                dummy_adapter = adapter;
                //adapter.Fill(dt);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dummy_adapter;
        }
    }
}
