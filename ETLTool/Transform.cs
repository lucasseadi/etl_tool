using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ETLTool
{
    /* Reads data from the "old" classes e transforms it to load it into the new fields and Tables. */
    internal class Transform
    {
        // Populates the fields c_revenue and c_quantity
        internal static void TransformCustomer()
        {
            try
            {
                SqlCommand command, command2;
                SqlConnection conn = Util.DBConnect();
                string query;
                int cont = 0;
                Util.LogInf("Connection Open!");

                // Select values for field c_revenue

                query = "SELECT c.c_custkey, c.c_name, SUM(o.o_totalprice) AS revenue " +
                    "FROM dbo.Customer c " +
                    "JOIN Orders o ON c.c_custkey = o.o_custkey " +
                    "GROUP BY c.c_custkey, c.c_name " +
                    "ORDER BY 3 DESC";
                command = new SqlCommand(query, conn);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // Update values for field c_revenue
                    query = "UPDATE dbo.Customer SET c_revenue = @revenue WHERE c_custkey = @custkey";
                    command2 = new SqlCommand(query, conn);
                    command2.Parameters.AddWithValue("@revenue", reader["revenue"]);
                    command2.Parameters.AddWithValue("@custkey", reader["c_custkey"]);
                    command2.ExecuteNonQuery();
                    cont++;
                }

                // Select values for field c_quantity

                query = "SELECT c.c_custkey, c.c_name, SUM(l.l_quantity) AS quantity " +
                    "FROM dbo.Customer c " +
                    "JOIN Orders o ON c.c_custkey = o.o_custkey " +
                    "JOIN Lineitem l ON o.o_orderkey = l.l_orderkey " +
                    "GROUP BY c.c_custkey, c.c_name " +
                    "ORDER BY 3 DESC";
                command = new SqlCommand(query, conn);

                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // Update values for field c_quantity
                    query = "UPDATE dbo.Customer SET c_quantity = @quantity WHERE c_custkey = @custkey";
                    command2 = new SqlCommand(query, conn);
                    command2.Parameters.AddWithValue("@quantity", reader["quantity"]);
                    command2.Parameters.AddWithValue("@custkey", reader["c_custkey"]);
                    command2.ExecuteNonQuery();
                    cont++;
                }

                Util.LogInf(cont + " lines updated in dbo.Customer.");

                conn.Close();
                Util.LogInf("Connection Closed...");
            }
            catch (Exception e)
            {
                throw;
            }
        }

        // Populates the table Monthsales
        internal static void TransformMonthsales()
        {
            try
            {
                SqlCommand command, command2;
                SqlConnection conn = Util.DBConnect();
                string query;
                int cont = 0;
                Util.LogInf("Connection Open!");

                // Select values for the table Monthsales

                query = "SELECT MONTH(o.o_orderdate) AS ms_month, YEAR(o.o_orderdate) AS ms_year, SUM(o.o_orderkey) AS ms_sales " +
                        "FROM dbo.Orders o " +
                        "GROUP BY MONTH(o.o_orderdate), YEAR(o.o_orderdate) " +
                        "ORDER BY 3 DESC";
                command = new SqlCommand(query, conn);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // Insert values for the table Monthsales
                    query = "INSERT INTO dbo.Monthsales(ms_month, ms_year, ms_sales) VALUES(@ms_month, @ms_year, @ms_sales)";
                    command2 = new SqlCommand(query, conn);
                    command2.Parameters.AddWithValue("@ms_month", reader["ms_month"]);
                    command2.Parameters.AddWithValue("@ms_year", reader["ms_year"]);
                    command2.Parameters.AddWithValue("@ms_sales", reader["ms_sales"]);
                    command2.ExecuteNonQuery();
                    cont++;
                }

                Util.LogInf(cont + " lines inserted in dbo.Monthsales.");

                conn.Close();
                Util.LogInf("Connection Closed...");
            }
            catch (Exception e)
            {
                throw;
            }
        }

        // Populates the fields n_income and n_prefshipmode
        internal static void TransformNation()
        {
            try
            {
                SqlCommand command, command2;
                SqlConnection conn = Util.DBConnect();
                string query;
                int cont = 0;
                Util.LogInf("Connection Open!");

                // Select values for field n_income

                query = "SELECT n.n_nationkey, n.n_name, SUM(o.o_totalprice) AS income " +
                        "FROM dbo.Nation n " +
                        "JOIN dbo.Customer c ON n.n_nationkey = c.c_nationkey " +
                        "JOIN dbo.Orders o ON c.c_custkey = o.o_custkey " +
                        "GROUP BY n.n_nationkey, n.n_name " +
                        "ORDER BY 2";
                command = new SqlCommand(query, conn);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // Update values for field n_income
                    query = "UPDATE dbo.Nation SET n_income = @income WHERE n_nationkey = @nationkey";
                    command2 = new SqlCommand(query, conn);
                    command2.Parameters.AddWithValue("@income", reader["income"]);
                    command2.Parameters.AddWithValue("@nationkey", reader["n_nationkey"]);
                    command2.ExecuteNonQuery();
                    cont++;
                }

                // Select values for field n_prefershipmode

                query = "WITH grouped AS ( " +
                        "SELECT n.n_nationkey, grouped2.l_shipmode, MAX(grouped2.shipcount) AS maxshipcount " +
                        "FROM dbo.Nation n " +
                        "JOIN (" +
                        "SELECT n.n_nationkey, l.l_shipmode, COUNT(l.l_shipmode) AS shipcount " +
                        "FROM dbo.Nation n " +
                        "JOIN dbo.Customer c ON n.n_nationkey = c.c_nationkey " +
                        "JOIN dbo.Orders o ON c.c_custkey = o.o_custkey " +
                        "JOIN dbo.Lineitem l ON o.o_orderkey = l.l_orderkey " +
                        "GROUP BY n.n_nationkey, l.l_shipmode " +
                        ") grouped2 ON n.n_nationkey = grouped2.n_nationkey " +
                        "GROUP BY n.n_nationkey, grouped2.l_shipmode " +
                        ") SELECT grouped.n_nationkey, grouped.l_shipmode, grouped.maxshipcount " +
                        "FROM grouped " +
                        "JOIN(" +
                        "SELECT n_nationkey, MAX(maxshipcount) AS maxmax " +
                        "FROM grouped " +
                        "GROUP BY n_nationkey " +
                        ") AS child ON grouped.n_nationkey = child.n_nationkey AND grouped.maxshipcount = child.maxmax " +
                        "ORDER BY 1, 2";
                command = new SqlCommand(query, conn);

                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // Update values for field n_prefershipmode
                    query = "UPDATE dbo.Nation SET n_prefshipmode = @prefshipmode WHERE n_nationkey = @nationkey";
                    command2 = new SqlCommand(query, conn);
                    command2.Parameters.AddWithValue("@prefshipmode", reader["l_shipmode"]);
                    command2.Parameters.AddWithValue("@nationkey", reader["n_nationkey"]);
                    command2.ExecuteNonQuery();
                    cont++;
                }

                Util.LogInf(cont + " lines updated in dbo.Nation.");

                conn.Close();
                Util.LogInf("Connection Closed...");
            }
            catch (Exception e)
            {
                throw;
            }
        }

        // Populates the table Revenue
        internal static void TransformRevenue()
        {
            try
            {
                SqlCommand command, command2;
                SqlConnection conn = Util.DBConnect();
                string query;
                int cont = 0;
                Util.LogInf("Connection Open!");

                // Select values for the table Revenue

                query = "SELECT CASE WHEN MONTH(o.o_orderdate) <= 6 THEN YEAR(o.o_orderdate)-1 ELSE YEAR(o.o_orderdate) END " +
                        "AS r_year, SUM(o.o_totalprice) AS revenue " +
                        "FROM dbo.Orders o " +
                        "GROUP BY CASE WHEN MONTH(o.o_orderdate) <= 6 THEN YEAR(o.o_orderdate)-1 ELSE YEAR(o.o_orderdate) END";
                command = new SqlCommand(query, conn);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // Insert values for the table Revenue
                    query = "INSERT INTO dbo.Revenue(r_year, r_revenue) VALUES(@year, @revenue)";
                    command2 = new SqlCommand(query, conn);
                    command2.Parameters.AddWithValue("@year", reader["r_year"]);
                    command2.Parameters.AddWithValue("@revenue", reader["revenue"]);
                    command2.ExecuteNonQuery();
                    cont++;
                }

                Util.LogInf(cont + " lines inserted in dbo.Revenue.");

                conn.Close();
                Util.LogInf("Connection Closed...");
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
