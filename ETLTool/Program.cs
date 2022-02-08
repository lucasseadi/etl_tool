using System;
using System.Diagnostics;


namespace ETLTool
{
    class Program
    {
        /* Main class. Calls all ETL classes. */
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("=== ETL Tool in C# === \n" +
                                  "This tool reads data from .tbl files in /data folder and loads them into the DB.\n" +
                                  "Press any key to start.");
                Console.ReadLine();

                var sw = Stopwatch.StartNew();
                Util.SetLog();

                Util.SetProgressBar();

                //////////////// EXTRACT ////////////////

                Extract.ValidateFiles();

                Util.TickProgressBar("Reading Customer file...");
                List<Table> customerList = Extract.ReadFile("Customer");

                Util.TickProgressBar("Reading Lineitem file...");
                List<Table> lineitemList = Extract.ReadFile("Lineitem");

                Util.TickProgressBar("Reading Nation file...");
                List<Table> nationList = Extract.ReadFile("Nation");

                Util.TickProgressBar("Reading Orders file...");
                List<Table> ordersList = Extract.ReadFile("Orders");

                Util.TickProgressBar("Reading Part file...");
                List<Table> partList = Extract.ReadFile("Part");

                Util.TickProgressBar("Reading Partsupp file...");
                List<Table> partsuppList = Extract.ReadFile("Partsupp");

                Util.TickProgressBar("Reading Region file...");
                List<Table> regionList = Extract.ReadFile("Region");

                Util.TickProgressBar("Reading Supplier file...");
                List<Table> supplierList = Extract.ReadFile("Supplier");

                //////////////// LOAD ////////////////

                Util.TickProgressBar("Cleaning all tables...");
                Load.DeleteAll();

                Util.TickProgressBar("Loading Region data...");
                Load.LoadRegion(regionList);

                Util.TickProgressBar("Loading Nation data...");
                Load.LoadNation(nationList);

                Util.TickProgressBar("Loading Part data...");
                Load.LoadPart(partList);

                Util.TickProgressBar("Loading Customer data...");
                Load.LoadCustomer(customerList);

                Util.TickProgressBar("Loading Supplier data...");
                Load.LoadSupplier(supplierList);

                Util.TickProgressBar("Loading Orders data...");
                Load.LoadOrders(ordersList);

                Util.TickProgressBar("Loading Partsupp data...");
                Load.LoadPartsupp(partsuppList);

                Util.TickProgressBar("Loading Lineitem data...");
                Load.LoadLineitem(lineitemList);

                //////////////// TRANSFORM ////////////////

                Util.TickProgressBar("Generating Customer data...");
                Transform.TransformCustomer();

                Util.TickProgressBar("Generating Monthsales data...");
                Transform.TransformMonthsales();

                Util.TickProgressBar("Generating Nation data...");
                Transform.TransformNation();

                Util.TickProgressBar("Generating Revenue data...");
                Transform.TransformRevenue();

                Util.LogInf($"done in {sw.Elapsed.TotalSeconds} seconds");

            }
            catch (Exception e)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(e, true);
                Util.LogErr("ERROR: " + e.ToString());
                Util.LogErr(trace.GetFrame(0).GetMethod().ReflectedType.FullName);
                Util.LogErr("Line: " + trace.GetFrame(0).GetFileLineNumber());
                Util.LogErr("Column: " + trace.GetFrame(0).GetFileColumnNumber());

                Util.TickProgressBar("There was an error in processing. Check the log for more information.");
            }
            finally
            {
                Util.TickProgressBar("All done. Press any key to exit.");

                Console.ReadLine();

                Console.WriteLine("\n"); // Friendly linespacing.

                Util.LogInf("End of execution");
            }
        }
    }
}