using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abbey_Trading_Store.DAL.Helpers
{
    public class MoneyFormatter
    {
        private static string ConcatenateStrings(params string[] strings)
        {
            return string.Concat(strings);
        }
        //private static void ChangeColumnTypeToString(DataTable dt, string columnName)
        //{
        //    // Add a new column with the desired data type
        //    dt.Columns.Add(columnName + "_string", typeof(string));

        //    // Copy values from the original column to the new column as strings
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        row[columnName + "_string"] = Convert.ToString(row[columnName]);
        //    }

        //    // Remove the original column
        //    dt.Columns.Remove(columnName);
        //}

        private static void ChangeColumnTypeToString(DataTable dt, DataTable dt2, string columnName)
        {
            int initial_col_position = dt.Columns[columnName].Ordinal;
            dt.Columns.Remove(columnName);

            DataColumn newColumn = dt.Columns.Add(columnName, typeof(string));
            newColumn.SetOrdinal(initial_col_position);
            
            for(int i = 0; i < dt2.Rows.Count; i++)
            {
                dt.Rows[i][newColumn] = dt2.Rows[i][columnName].ToString();
            }
        }

        public static DataTable formatDT(DataTable dt, int[] columns)
        {
            DataTable dt2 = dt.Copy();

            if (dt == null || dt.Rows.Count == 0)
            {
                //throw new ArgumentException("DataTable is null or empty.");
            }

            foreach(int col in columns)
            {
                if (dt.Columns[col].DataType.ToString() != "System.String")
                {
                    ChangeColumnTypeToString(dt, dt2, dt.Columns[col].ColumnName);
                }
            }

            foreach (DataRow row in dt.Rows)
            {
                foreach (int col in columns)
                {
                    if (col < 0 || col >= dt.Columns.Count)
                    {
                        throw new ArgumentException($"Column index {col} is out of bounds.");
                    }

                    if (row[col] == DBNull.Value)
                    {
                        // Handle DBNull if necessary
                    }
                    else
                    {
                        try
                        {
                            long money_value;
                            if (long.TryParse(row[col].ToString(), out money_value))
                            {
                                //row[col] = "shs. " + money_value.ToString("N0");
                                row[col] = ConcatenateStrings("shs. ", money_value.ToString("N0")); ;
                                //row[col] = money_value;
                            }
                            else
                            {
                                throw new ArgumentException($"Invalid value in column {col}: {row[col]}");
                            }
                        }
                        catch (System.ArgumentException)
                        {
                            //MessageBox.Show(row[col].ToString());
                            
                        }
                        
                    }
                }
            }

            return dt;
        }

    }
}
