using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETLTool
{

    /* Extract data from the .tbl files. */
    internal class Extract
    {
        private const string FilePath = @"..\..\..\data\";

        internal static void ValidateFiles()
        {
            if(!File.Exists(FilePath + "customer.tbl") || !File.Exists(FilePath + "lineitem.tbl") || 
                !File.Exists(FilePath + "nation.tbl") || !File.Exists(FilePath + "orders.tbl") || 
                !File.Exists(FilePath + "part.tbl") || !File.Exists(FilePath + "partsupp.tbl") || 
                !File.Exists(FilePath + "region.tbl") || !File.Exists(FilePath + "supplier.tbl"))
            {
                throw new Exception("File(s) missing.");
            }
        }

        internal static List<Table> ReadFile(string className)
        {
            try
            {
                Util.LogInf("ReadFile start");
                
                string filePath = FilePath + className.ToLower() + ".tbl";

                Util.LogInf("Reading file " + filePath);

                int counter = 0;
                List<Table> objectList = new List<Table>();

                // Read the file and display it line by line.  
                foreach (string line in System.IO.File.ReadLines(filePath))
                {
                    // Parses the line into object and adds it to the object list
                    switch (className)
                    {
                        case "Customer": 
                            objectList.Add(Customer.ParseLine(line));
                            break;
                        case "Lineitem":
                            objectList.Add(Lineitem.ParseLine(line));
                            break;
                        case "Nation":
                            objectList.Add(Nation.ParseLine(line));
                            break;
                        case "Orders":
                            objectList.Add(Orders.ParseLine(line));
                            break;
                        case "Part":
                            objectList.Add(Part.ParseLine(line));
                            break;
                        case "Partsupp":
                            objectList.Add(Partsupp.ParseLine(line));
                            break;
                        case "Region":
                            objectList.Add(Region.ParseLine(line));
                            break;
                        case "Supplier":
                            objectList.Add(Supplier.ParseLine(line));
                            break;
                        default:
                            throw new Exception("Unknown table.");
                    }
                    counter++;
                }

                Util.LogInf("ReadFile end");

                return objectList;
            }
            catch (Exception e)
            {
                throw ;
            }
        }
    }
}
