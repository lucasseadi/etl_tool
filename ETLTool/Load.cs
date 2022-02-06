using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace ETLTool
{
    /* Load the extracted data into the Tables. */
    internal class Load
    {
        internal static void DeleteAll()
        {
            // Clean all tables
            SqlCommand command;
            SqlConnection conn = Util.DBConnect();
            Util.LogInf("Connection Open!");

            command = new SqlCommand("DELETE FROM dbo.Lineitem", conn);
            Util.LogInf("Table dbo.Lineitem (" + command.ExecuteNonQuery() + " lines) deleted.");

            command = new SqlCommand("DELETE FROM dbo.Partsupp", conn);
            Util.LogInf("Table dbo.Partsupp (" + command.ExecuteNonQuery() + " lines) deleted.");

            command = new SqlCommand("DELETE FROM dbo.Orders", conn);
            Util.LogInf("Table dbo.Orders (" + command.ExecuteNonQuery() + " lines) deleted.");

            command = new SqlCommand("DELETE FROM dbo.Supplier", conn);
            Util.LogInf("Table dbo.Supplier (" + command.ExecuteNonQuery() + " lines) deleted.");

            command = new SqlCommand("DELETE FROM dbo.Customer", conn);
            Util.LogInf("Table dbo.Customer (" + command.ExecuteNonQuery() + " lines) deleted.");

            command = new SqlCommand("DELETE FROM dbo.Part", conn);
            Util.LogInf("Table dbo.Part (" + command.ExecuteNonQuery() + " lines) deleted.");

            command = new SqlCommand("DELETE FROM dbo.Nation", conn);
            Util.LogInf("Table dbo.Nation (" + command.ExecuteNonQuery() + " lines) deleted.");

            command = new SqlCommand("DELETE FROM dbo.Region", conn);
            Util.LogInf("Table dbo.Region (" + command.ExecuteNonQuery() + " lines) deleted.");

            command = new SqlCommand("DELETE FROM dbo.Monthsales", conn);
            Util.LogInf("Table dbo.Monthsales (" + command.ExecuteNonQuery() + " lines) deleted.");

            command = new SqlCommand("DELETE FROM dbo.Revenue", conn);
            Util.LogInf("Table dbo.Revenue (" + command.ExecuteNonQuery() + " lines) deleted.");
            
            conn.Close();
            Util.LogInf("Connection Closed...");
        }

        internal static void LoadCustomer(List<Table> customerList)
        {
            try
            {
                SqlCommand command;
                SqlConnection conn = Util.DBConnect();
                string query;
                int cont = 0;
                Util.LogInf("Connection Open!");

                // Insert lines
                foreach (Customer row in customerList)
                {
                    query = "INSERT INTO dbo.Customer (c_custkey, c_name, c_address, c_nationkey, c_phone, c_acctbal, " +
                        "c_mktsegment, c_comment) VALUES(@c_custkey, @c_name, @c_address, @c_nationkey, " +
                        "@c_phone, @c_acctbal, @c_mktsegment, @c_comment)";
                    command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@c_custkey", row.CustKey);
                    command.Parameters.AddWithValue("@c_name", row.Name);
                    command.Parameters.AddWithValue("@c_address", row.Address);
                    command.Parameters.AddWithValue("@c_nationkey", row.NationKey);
                    command.Parameters.AddWithValue("@c_phone", row.Phone);
                    command.Parameters.AddWithValue("@c_acctbal", row.AcctBal);
                    command.Parameters.AddWithValue("@c_mktsegment", row.MktSegment);
                    command.Parameters.AddWithValue("@c_comment", row.Comment);
                    command.ExecuteNonQuery();
                    cont++;
                }

                Util.LogInf(cont + " lines insertedin dbo.Customer.");

                conn.Close();
                Util.LogInf("Connection Closed...");
            }
            catch (Exception e)
            {
                throw;
            }
        }

        internal static void LoadLineitem(List<Table> lineitemList)
        {
            try
            {
                SqlCommand command;
                SqlConnection conn = Util.DBConnect();
                string query;
                int cont = 0;
                Util.LogInf("Connection Open!");

                // Insert lines
                foreach (Lineitem row in lineitemList)
                {
                    query = "INSERT INTO dbo.Lineitem (l_id, l_orderkey, l_ps_id, l_linenumber, l_quantity, l_extendedprice, " +
                        "l_discount, l_tax, l_returnflag, l_linestatus, l_shipdate, l_commitdate, l_receiptdate, l_shipinstruct, " +
                        "l_shipmode, l_comment) VALUES(@l_id, @l_orderkey, @l_ps_id, @l_linenumber, @l_quantity, @l_extendedprice, " +
                        "@l_discount, @l_tax, @l_returnflag, @l_linestatus, @l_shipdate, @l_commitdate, @l_receiptdate, @l_shipinstruct, " +
                        "@l_shipmode, @l_comment)";
                    command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@l_id", row.Id);
                    command.Parameters.AddWithValue("@l_orderkey", row.OrderKey);
                    command.Parameters.AddWithValue("@l_ps_id", row.PsId);
                    command.Parameters.AddWithValue("@l_linenumber", row.LineNumber);
                    command.Parameters.AddWithValue("@l_quantity", row.Quantity);
                    command.Parameters.AddWithValue("@l_extendedprice", row.ExtendedPrice);
                    command.Parameters.AddWithValue("@l_discount", row.Discount);
                    command.Parameters.AddWithValue("@l_tax", row.Tax);
                    command.Parameters.AddWithValue("@l_returnflag", row.ReturnFlag);
                    command.Parameters.AddWithValue("@l_linestatus", row.LineStauts);
                    command.Parameters.AddWithValue("@l_shipdate", row.ShipDate);
                    command.Parameters.AddWithValue("@l_commitdate", row.CommitDate);
                    command.Parameters.AddWithValue("@l_receiptdate", row.ReceiptDate);
                    command.Parameters.AddWithValue("@l_shipinstruct", row.ShipInstruct);
                    command.Parameters.AddWithValue("@l_shipmode", row.ShipMode);
                    command.Parameters.AddWithValue("@l_comment", row.Comment);
                    command.ExecuteNonQuery();
                    cont++;
                }

                Util.LogInf(cont + " lines insertedin dbo.Lineitem.");

                conn.Close();
                Util.LogInf("Connection Closed...");
            }
            catch (Exception e)
            {
                throw;
            }
        }

        internal static void LoadNation(List<Table> nationList)
        {
            try
            {
                SqlCommand command;
                SqlConnection conn = Util.DBConnect();
                string query;
                int cont = 0;
                Util.LogInf("Connection Open!");

                // Insert lines
                foreach (Nation row in nationList)
                {
                    query = "INSERT INTO dbo.Nation (n_nationkey, n_name, n_regionkey, n_comment) " +
                        "VALUES (@n_nationkey, @n_name, @n_regionkey, @n_comment)";
                    command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@n_nationkey", row.NationKey);
                    command.Parameters.AddWithValue("@n_name", row.Name);
                    command.Parameters.AddWithValue("@n_regionkey", row.RegionKey);
                    command.Parameters.AddWithValue("@n_comment", row.Comment);
                    command.ExecuteNonQuery();
                    cont++;
                }

                Util.LogInf(cont + " lines insertedin dbo.Nation.");

                conn.Close();
                Util.LogInf("Connection Closed...");
            }
            catch (Exception e)
            {
                throw;
            }
        }

        internal static void LoadOrders(List<Table> ordersList)
        {
            try
            {
                SqlCommand command;
                SqlConnection conn = Util.DBConnect();
                string query;
                int cont = 0;
                Util.LogInf("Connection Open!");

                // Insert lines
                foreach (Orders row in ordersList)
                {
                    query = "INSERT INTO dbo.Orders (o_orderkey, o_custkey, o_orderstatus, o_totalprice, o_orderdate, " +
                        "o_orderpriority, o_cleark, o_shippriority, o_comment) VALUES(@o_orderkey, @o_custkey, @o_orderstatus, " +
                        "@o_totalprice, @o_orderdate, @o_orderpriority, @o_cleark, @o_shippriority, @o_comment)";
                    command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@o_orderkey", row.OrderKey);
                    command.Parameters.AddWithValue("@o_custkey", row.CustKey);
                    command.Parameters.AddWithValue("@o_orderstatus", row.OrderStatus);
                    command.Parameters.AddWithValue("@o_totalprice", row.TotalPrice);
                    command.Parameters.AddWithValue("@o_orderdate", row.OrderDate);
                    command.Parameters.AddWithValue("@o_orderpriority", row.OrderPriority);
                    command.Parameters.AddWithValue("@o_cleark", row.Cleark);
                    command.Parameters.AddWithValue("@o_shippriority", row.ShipPriority);
                    command.Parameters.AddWithValue("@o_comment", row.Comment);
                    command.ExecuteNonQuery();
                    cont++;
                }

                Util.LogInf(cont + " lines insertedin dbo.Orders.");

                conn.Close();
                Util.LogInf("Connection Closed...");
            }
            catch (Exception e)
            {
                throw;
            }
        }

        internal static void LoadPart(List<Table> partList)
        {
            try
            {
                SqlCommand command;
                SqlConnection conn = Util.DBConnect();
                string query;
                int cont = 0;
                Util.LogInf("Connection Open!");

                // Insert lines
                foreach (Part row in partList)
                {
                    query = "INSERT INTO dbo.Part (p_partkey, p_name, p_mfgr, p_brand, p_type, p_size, p_container, p_retailprice, " +
                        "p_comment) " +
                        "VALUES (@p_partkey, @p_name, @p_mfgr, @p_brand, @p_type, @p_size, @p_container, @p_retailprice, " +
                        "@p_comment)";
                    command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@p_partkey", row.PartKey);
                    command.Parameters.AddWithValue("@p_name", row.Name);
                    command.Parameters.AddWithValue("@p_mfgr", row.Mfgr);
                    command.Parameters.AddWithValue("@p_brand", row.Brand);
                    command.Parameters.AddWithValue("@p_type", row.Type);
                    command.Parameters.AddWithValue("@p_size", row.Size);
                    command.Parameters.AddWithValue("@p_container", row.Container);
                    command.Parameters.AddWithValue("@p_retailprice", row.RetailPrice);
                    command.Parameters.AddWithValue("@p_comment", row.Comment);
                    command.ExecuteNonQuery();
                    cont++;
                }

                Util.LogInf(cont + " lines insertedin dbo.Part.");

                conn.Close();
                Util.LogInf("Connection Closed...");
            }
            catch (Exception e)
            {
                throw;
            }
        }

        internal static void LoadPartsupp(List<Table> partsuppList)
        {
            try
            {
                SqlCommand command;
                SqlConnection conn = Util.DBConnect();
                string query;
                int cont = 0;
                Util.LogInf("Connection Open!");

                // Insert lines
                foreach (Partsupp row in partsuppList)
                {
                    query = "INSERT INTO dbo.Partsupp (ps_id, ps_partkey, ps_suppkey, ps_availqty, ps_supplycost, ps_comment) " +
                        "VALUES(@ps_id, @ps_partkey, @ps_suppkey, @ps_availqty, @ps_supplycost, @ps_comment)";
                    command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@ps_id", row.Id);
                    command.Parameters.AddWithValue("@ps_partkey", row.PartKey);
                    command.Parameters.AddWithValue("@ps_suppkey", row.SuppKey);
                    command.Parameters.AddWithValue("@ps_availqty", row.AvailQty);
                    command.Parameters.AddWithValue("@ps_supplycost", row.SupplyCost);
                    command.Parameters.AddWithValue("@ps_comment", row.Comment);
                    command.ExecuteNonQuery();
                    cont++;
                }

                Util.LogInf(cont + " lines insertedin dbo.Partsupp.");

                conn.Close();
                Util.LogInf("Connection Closed...");
            }
            catch (Exception e)
            {
                throw;
            }
        }

        internal static void LoadRegion(List<Table> regionList)
        {
            try
            {
                SqlCommand command;
                SqlConnection conn = Util.DBConnect();
                string query;
                int cont = 0;
                Util.LogInf("Connection Open!");

                // Insert lines
                foreach (Region row in regionList)
                {
                    query = "INSERT INTO dbo.Region (r_regionkey, r_name, r_comment) VALUES (@r_regionkey, @r_name, @r_comment)";
                    command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@r_regionkey", row.RegionKey);
                    command.Parameters.AddWithValue("@r_name", row.Name);
                    command.Parameters.AddWithValue("@r_comment", row.Comment);
                    command.ExecuteNonQuery();
                    cont++;
                }

                Util.LogInf(cont + " lines insertedin dbo.Region.");

                conn.Close();
                Util.LogInf("Connection Closed...");
            }
            catch (Exception e)
            {
                throw;
            }
        }

         internal static void LoadSupplier(List<Table> supplierList)
        {
            try
            {
                SqlCommand command;
                SqlConnection conn = Util.DBConnect();
                string query;
                int cont = 0;
                Util.LogInf("Connection Open!");

                // Insert lines
                foreach (Supplier row in supplierList)
                {
                    query = "INSERT INTO dbo.Supplier (s_suppkey, s_name, s_address, s_nationkey, s_phone, s_acctbal, s_comment) " +
                        "VALUES(@s_suppkey, @s_name, @s_address, @s_nationkey, @s_phone, @s_acctbal, @s_comment)";
                    command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@s_suppkey", row.SuppKey);
                    command.Parameters.AddWithValue("@s_name", row.Name);
                    command.Parameters.AddWithValue("@s_address", row.Address);
                    command.Parameters.AddWithValue("@s_nationkey", row.NationKey);
                    command.Parameters.AddWithValue("@s_phone", row.Phone);
                    command.Parameters.AddWithValue("@s_acctbal", row.AcctBal);
                    command.Parameters.AddWithValue("@s_comment", row.Comment);
                    command.ExecuteNonQuery();
                    cont++;
                }

                Util.LogInf(cont + " lines insertedin dbo.Supplier.");

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
