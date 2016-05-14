using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    class Order
    {
        public enum Status { New, InWork, Executed };

        public Guid OrderID { get; set; }
        public string CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public double Freight { get; set; }
        public string ShipName { get; set; }
        public Status OrderStatus { get; set; }

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }


        public int Total{ get; set; }
        public double ExtendedPrice { get; set; }

        public Order(Guid orderid, string customerid,int employeeid, DateTime orderdate, DateTime requireddate, DateTime shippeddate, double freight, string shipname)
        {
            OrderID = orderid;
            CustomerID = customerid;
            EmployeeID = employeeid;
            OrderDate = orderdate;
            RequiredDate = requireddate;
            ShippedDate = shippeddate;
            Freight = freight;
            ShipName = shipname;
        }

        public Order() { }
    }
}
