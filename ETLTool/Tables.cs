using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ETLTool
{
    /* Classes representing the Tables. */

    internal class Table
    {
    }

    internal class Customer : Table
    {
        int custKey;
        string name;
        string address;
        int nationKey;
        string phone;
        Decimal acctBal;
        string mktSegment;
        string comment;
        Decimal revenue;
        int sales;

        public int CustKey { get { return custKey; } set { custKey = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Address { get { return address; } set { address = value; } }
        public int NationKey { get { return nationKey; } set { nationKey = value; } }
        public string Phone { get { return phone; } set { phone = value; } }
        public Decimal AcctBal { get { return acctBal; } set { acctBal = value; } }
        public string MktSegment { get { return mktSegment; } set { mktSegment = value; } }
        public string Comment { get { return comment; } set { comment = value; } }
        public Decimal Revenue { get { return revenue; } set { revenue = value; } }
        public int Sales { get { return sales; } set { sales = value; } }


        public static Customer ParseLine(string tblLine)
        {
            try
            {
                string[] values = tblLine.Split('|');
                Customer customer = new Customer();
                customer.CustKey = Convert.ToInt32(values[0]);
                customer.Name = Convert.ToString(values[1]);
                customer.Address = Convert.ToString(values[2]);
                customer.NationKey = Convert.ToInt32(values[3]);
                customer.Phone = Convert.ToString(values[4]);
                customer.AcctBal = Convert.ToDecimal(values[5], new CultureInfo("en-US"));
                customer.MktSegment = Convert.ToString(values[6]);
                customer.Comment = Convert.ToString(values[7]);
                return customer;
            }
            catch (Exception ex)
            {
                throw new Exception("File parsing problem: " + ex.ToString());
            }
        }
    }

    internal class Lineitem : Table
    {
        int id;
        int orderKey;
        int psId;
        int lineNumber;
        int quantity;
        Decimal extendedPrice;
        Decimal discount;
        Decimal tax;
        Char returnFlag;
        Char lineStauts;
        DateTime shipDate;
        DateTime commitDate;
        DateTime receiptDate;
        string shipInstruct;
        string shipMode;
        string comment;

        public int Id { get { return id; } set { id = value; } }
        public int OrderKey { get { return orderKey; } set { orderKey = value; } }
        public int PsId { get { return psId; } set { psId = value; } }
        public int LineNumber { get { return lineNumber; } set { lineNumber = value; } }
        public int Quantity { get { return quantity; } set { quantity = value; } }
        public Decimal ExtendedPrice { get { return extendedPrice; } set { extendedPrice = value; } }
        public Decimal Discount { get { return discount; } set { discount = value; } }
        public Decimal Tax { get { return tax; } set { tax = value; } }
        public Char ReturnFlag { get { return returnFlag; } set { returnFlag = value; } }
        public Char LineStauts { get { return lineStauts; } set { lineStauts = value; } }
        public DateTime ShipDate { get { return shipDate; } set { shipDate = value; } }
        public DateTime CommitDate { get { return commitDate; } set { commitDate = value; } }
        public DateTime ReceiptDate { get { return receiptDate; } set { receiptDate = value; } }
        public string ShipInstruct { get { return shipInstruct; } set { shipInstruct = value; } }
        public string ShipMode { get { return shipMode; } set { shipMode = value; } }
        public string Comment { get { return comment; } set { comment = value; } }


        public static Lineitem ParseLine(string tblLine)
        {
            try
            {
                string[] values = tblLine.Split('|');
                Lineitem lineitem = new Lineitem();
                lineitem.Id = Convert.ToInt32(values[0]);
                lineitem.OrderKey = Convert.ToInt32(values[1]);
                lineitem.PsId = Convert.ToInt32(values[2]);
                lineitem.LineNumber = Convert.ToInt32(values[3]);
                lineitem.Quantity = Convert.ToInt32(values[4]);
                lineitem.ExtendedPrice = Convert.ToDecimal(values[5], new CultureInfo("en-US"));
                lineitem.Discount = Convert.ToDecimal(values[6], new CultureInfo("en-US"));
                lineitem.Tax = Convert.ToDecimal(values[7], new CultureInfo("en-US"));
                lineitem.ReturnFlag = Convert.ToChar(values[8]);
                lineitem.LineStauts = Convert.ToChar(values[9]);
                lineitem.ShipDate = Convert.ToDateTime(values[10]);
                lineitem.CommitDate = Convert.ToDateTime(values[11]);
                lineitem.ReceiptDate = Convert.ToDateTime(values[12]);
                lineitem.ShipInstruct = Convert.ToString(values[13]);
                lineitem.ShipMode = Convert.ToString(values[14]);
                lineitem.Comment = Convert.ToString(values[15]);
                return lineitem;
            }
            catch (Exception ex)
            {
                throw new Exception("File parsing problem: " + ex.ToString());
            }
        }
    }

    internal class Nation : Table
    {
        int nationKey;
        string name;
        int regionKey;
        string comment;
        Decimal income;
        string prefShipMode;

        public int NationKey { get { return nationKey; } set { nationKey = value; } }
        public string Name { get { return name; } set { name = value; } }
        public int RegionKey { get { return regionKey; } set { regionKey = value; } }
        public string Comment { get { return comment; } set { comment = value; } }
        public Decimal Income { get { return income; } set { income = value; } }
        public string PrefShipMode { get { return prefShipMode; } set { prefShipMode = value; } }


        public static Nation ParseLine(string tblLine)
        {
            try
            {
                string[] values = tblLine.Split('|');
                Nation nation = new Nation();
                nation.NationKey = Convert.ToInt32(values[0]);
                nation.Name = Convert.ToString(values[1]);
                nation.RegionKey = Convert.ToInt32(values[2]);
                nation.Comment = Convert.ToString(values[3]);
                return nation;
            }
            catch (Exception ex)
            {
                throw new Exception("File parsing problem: " + ex.ToString());
            }

        }
    }

    internal class Orders : Table
    {
        int orderKey;
        int custKey;
        Char orderStatus;
        Decimal totalPrice;
        DateTime orderDate;
        string orderPriority;
        string cleark;
        int shipPriority;
        string comment;

        public int OrderKey { get { return orderKey; } set { orderKey = value; } }
        public int CustKey { get { return custKey; } set { custKey = value; } }
        public Char OrderStatus { get { return orderStatus; } set { orderStatus = value; } }
        public Decimal TotalPrice { get { return totalPrice; } set { totalPrice = value; } }
        public DateTime OrderDate { get { return orderDate; } set { orderDate = value; } }
        public string OrderPriority { get { return orderPriority; } set { orderPriority = value; } }
        public string Cleark { get { return cleark; } set { cleark = value; } }
        public int ShipPriority { get { return shipPriority; } set { shipPriority = value; } }
        public string Comment { get { return comment; } set { comment = value; } }

        public static Orders ParseLine(string tblLine)
        {
            try
            {
                string[] values = tblLine.Split('|');
                Orders orders = new Orders();
                orders.OrderKey = Convert.ToInt32(values[0]);
                orders.CustKey = Convert.ToInt32(values[1]);
                orders.OrderStatus = Convert.ToChar(values[2]);
                orders.TotalPrice = Convert.ToDecimal(values[3], new CultureInfo("en-US"));
                orders.OrderDate = Convert.ToDateTime(values[4]);
                orders.OrderPriority = Convert.ToString(values[5]);
                orders.Cleark = Convert.ToString(values[6]);
                orders.ShipPriority = Convert.ToInt32(values[7]);
                orders.Comment = Convert.ToString(values[8]);
                return orders;
            }
            catch (Exception ex)
            {
                throw new Exception("File parsing problem: " + ex.ToString());
            }

        }
    }

    internal class Part : Table
    {
        int partKey;
        string name;
        string mfgr;
        string brand;
        string type;
        int size;
        string container;
        Decimal retailPrice;
        string comment;

        public int PartKey { get { return partKey; } set { partKey = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Mfgr { get { return mfgr; } set { mfgr = value; } }
        public string Brand { get { return brand; } set { brand = value; } }
        public string Type { get { return type; } set { type = value; } }
        public int Size { get { return size; } set { size = value; } }
        public string Container { get { return container; } set { container = value; } }
        public Decimal RetailPrice { get { return retailPrice; } set { retailPrice = value; } }
        public string Comment { get { return comment; } set { comment = value; } }

        public static Part ParseLine(string tblLine)
        {
            try
            {
                string[] values = tblLine.Split('|');
                Part part = new Part();
                part.PartKey = Convert.ToInt32(values[0]);
                part.Name = Convert.ToString(values[1]);
                part.Mfgr = Convert.ToString(values[2]);
                part.Brand = Convert.ToString(values[3]);
                part.Type = Convert.ToString(values[4]);
                part.Size = Convert.ToInt32(values[5]);
                part.Container = Convert.ToString(values[6]);
                part.RetailPrice = Convert.ToDecimal(values[7], new CultureInfo("en-US"));
                part.Comment = Convert.ToString(values[8]);
                return part;
            }
            catch (Exception ex)
            {
                throw new Exception("File parsing problem: " + ex.ToString());
            }
        }
    }
 
    internal class Partsupp : Table
    {
        int id;
        int partKey;
        int suppKey;
        int availQty;
        Decimal supplyCost;
        string comment;

        public int Id { get { return id; } set { id = value; } }
        public int PartKey { get { return partKey; } set { partKey = value; } }
        public int SuppKey { get { return suppKey; } set { suppKey = value; } }
        public int AvailQty { get { return availQty; } set { availQty = value; } }
        public Decimal SupplyCost { get { return supplyCost; } set { supplyCost = value; } }
        public string Comment { get { return comment; } set { comment = value; } }

        public static Partsupp ParseLine(string tblLine)
        {
            try
            {
                string[] values = tblLine.Split('|');
                Partsupp partsupp = new Partsupp();
                partsupp.Id = Convert.ToInt32(values[0]);
                partsupp.PartKey = Convert.ToInt32(values[1]);
                partsupp.SuppKey = Convert.ToInt32(values[2]);
                partsupp.SupplyCost = Convert.ToDecimal(values[3], new CultureInfo("en-US"));
                partsupp.Comment = Convert.ToString(values[4]);
                return partsupp;
            }
            catch (Exception ex)
            {
                throw new Exception("File parsing problem: " + ex.ToString());
            }
        }
    }

    internal class Region : Table
    {
        int regionKey;
        string name;
        string comment;

        public int RegionKey { get { return regionKey; } set { regionKey = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Comment { get { return comment; } set { comment = value; } }

        public static Region ParseLine(string tblLine)
        {
            try
            {
                string[] values = tblLine.Split('|');
                Region region = new Region();
                region.RegionKey = Convert.ToInt32(values[0]);
                region.Name = Convert.ToString(values[1]);
                region.Comment = Convert.ToString(values[2]);
                return region;
            }
            catch (Exception ex)
            {
                throw new Exception("File parsing problem: " + ex.ToString());
            }
        }
    }

    internal class Supplier : Table
    {
        int suppKey;
        string name;
        string address;
        int nationKey;
        string phone;
        Decimal acctBal;
        string comment;

        public int SuppKey { get { return suppKey; } set { suppKey = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Address { get { return address; } set { address = value; } }
        public int NationKey { get { return nationKey; } set { nationKey = value; } }
        public string Phone { get { return phone; } set { phone = value; } }
        public Decimal AcctBal { get { return acctBal; } set { acctBal = value; } }
        public string Comment { get { return comment; } set { comment = value; } }


        public static Supplier ParseLine(string tblLine)
        {
            try
            {
                string[] values = tblLine.Split('|');
                Supplier supplier = new Supplier();
                supplier.SuppKey = Convert.ToInt32(values[0]);
                supplier.Name = Convert.ToString(values[1]);
                supplier.Address = Convert.ToString(values[2]);
                supplier.NationKey = Convert.ToInt32(values[3]);
                supplier.Phone = Convert.ToString(values[4]);
                supplier.AcctBal = Convert.ToDecimal(values[5], new CultureInfo("en-US"));
                supplier.Comment = Convert.ToString(values[6]);
                return supplier;
            }
            catch (Exception ex)
            {
                throw new Exception("File parsing problem: " + ex.ToString());
            }
        }
    }
}
