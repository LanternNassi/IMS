using Abbey_Trading_Store.DAL.DAL_Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Abbey_Trading_Store.DAL
{
    public class ExpCategories
    {
        Expenditure_Categories expenditure_category;
        int Expense_id;
        public ExpCategories(int expense_id)
        {
            Expense_id = expense_id;
        }

        public ExpCategories(Expenditure_Categories exp) {
            expenditure_category = exp;
        }  
      
        public bool Insert()
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            try
            {
                const string cmds = "INSERT INTO Expenditure_Categories(Name , Overall_category , Description , Added_by)VALUES(@Name , @Overall_category , @Description , @Added_by);";
                SqlCommand cmd = new SqlCommand(cmds, conn);
                cmd.Parameters.AddWithValue("@Name", expenditure_category.Name);
                cmd.Parameters.AddWithValue("@Overall_category", expenditure_category.Overall_category);
                cmd.Parameters.AddWithValue("@Description", expenditure_category.Description);
                cmd.Parameters.AddWithValue("@Added_by", expenditure_category.Added_by);
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

        public bool Update()
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            try
            {
                const string cmds = "UPDATE Expenditure_Categories SET Name=@Name,Description=@Description WHERE ID = @id";
                SqlCommand cmd = new SqlCommand(cmds, conn);
                cmd.Parameters.AddWithValue("@Name", expenditure_category.Name);
                cmd.Parameters.AddWithValue("@Description", expenditure_category.Description);
                cmd.Parameters.AddWithValue("@id", expenditure_category.ID);
                conn.Open();
                MessageBox.Show(expenditure_category.ID.ToString());
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

        public bool Delete()
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            try
            {
                const string cmds = "DELETE  FROM Expenditure_Categories WHERE ID = @id";
                SqlCommand cmd = new SqlCommand(cmds, conn);
                cmd.Parameters.AddWithValue("@id", expenditure_category.ID);
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
            string command = "SELECT * FROM Expenditure_Categories WHERE Overall_category = " + Expense_id.ToString();
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
