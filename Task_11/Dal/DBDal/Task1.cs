using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Entities;
using System.Data.SqlClient;

namespace Dal.DBDal
{
    class Task1 : IDal
    {
        private string connectionsString = @"Data Source = (localdb)\ProjectsV12; Initial Catalog = Northwind; Integrated Security = True";

        public bool AddOrder(Order order)
        {
            using (var connection = new SqlConnection(connectionsString))
            {
                var command = new SqlCommand(
                    "insert into Northwind.Orders (CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, Freight, ShipName) values(@cid, @empid, #orddate, @reqdate, @sdate, @fr, @sn)", connection);

                command.Parameters.AddWithValue("@cid", order.CustomerID);
                command.Parameters.AddWithValue("@empid", order.EmployeeID);
                command.Parameters.AddWithValue("@orddate", order.OrderDate);
                command.Parameters.AddWithValue("@reqdate", order.RequiredDate);
                command.Parameters.AddWithValue("@sdate", order.ShippedDate);
                command.Parameters.AddWithValue("@fr", order.Freight);
                command.Parameters.AddWithValue("@sn", order.ShipName);

                connection.Open();

                return command.ExecuteNonQuery() == 1;
            }
        }

        public IEnumerable<Order> CustOrderHist(string customerID)
        {
            var result = new List<Order>();
            using (var connection = new SqlConnection(connectionsString))
            {
                var command = new SqlCommand("exec Northwind.CustOrderHist @cid", connection);
                command.Parameters.AddWithValue("@cid", customerID);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    Order order = new Order();
                    order.ProductName = reader.GetString(0);
                    order.Total = reader.GetInt32(1);
                    result.Add(order);
                }
            }
            return result;
        }

        public IEnumerable<Order> CustOrdersDetail(Guid orderID)
        {
            var result = new List<Order>();
            using (var connection = new SqlConnection(connectionsString))
            {
                var command = new SqlCommand("exec Northwind.CustOrdersDetail @id", connection);
                command.Parameters.AddWithValue("@id", orderID);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    Order order = new Order();
                    order.ProductName = reader.GetString(0);
                    order.UnitPrice = reader.GetDouble(1);
                    order.Quantity = reader.GetInt32(2);
                    order.Discount = reader.GetDouble(3);
                    order.ExtendedPrice = reader.GetDouble(4);
                    result.Add(order);
                }
            }
            return result;
        }

        public IEnumerable<Order> GetAll()
        {
            var result = new List<Order>();
            using (var connection = new SqlConnection(connectionsString))
            {

                var command = new SqlCommand(
                    "select OrderID, CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, Freight, ShipName from Northwind.Orders", connection);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        var order = new Order(
                            reader.GetGuid(0),      //OrderID
                            reader.GetString(1),    //CustomerID
                            reader.GetInt32(2),     //EmployeeID 
                            reader.GetDateTime(3),  //OrderDate
                            reader.GetDateTime(4),  //RequiredDate
                            reader.GetDateTime(5),  //ShippedDate
                            reader.GetDouble(6),    //Freight
                            reader.GetString(7)     //ShipName
                            );
                        if (reader.GetDateTime(3).ToString() == "NULL") order.OrderStatus = Order.Status.New;
                        else if (reader.GetDateTime(5).ToString() == "NULL") order.OrderStatus = Order.Status.InWork;
                        else order.OrderStatus = Order.Status.Executed;
                        result.Add(order);
                    }
                }
            }
            return result;
        }

        public IEnumerable<Order> GetById(Guid id)
        {
            var result = new List<Order>();
            using (var connection = new SqlConnection(connectionsString))
            {

                var command = new SqlCommand(
                    "select o.OrderID, o.CustomerID, o.EmployeeID, p.ProductID , p.ProductName, p.UnitPrice, ord.Quantity, ord.Discount from Northwind.Orders as o " + 
                    "join Northwind.[Order Details] as ord on o.OrderID = ord.OrderID " +
                    "join Northwind.Products as p on ord.ProductID = p.ProductID " +
                    "where @id = o.OrderID", connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Order order = new Order();
                        order.OrderID = reader.GetGuid(0);
                        order.CustomerID = reader.GetString(1);
                        order.EmployeeID = reader.GetInt32(2);
                        order.ProductID = reader.GetInt32(3);
                        order.ProductName = reader.GetString(4);
                        order.UnitPrice = reader.GetDouble(5);
                        order.Quantity = reader.GetInt32(6);
                        order.Discount = reader.GetDouble(7);
                        result.Add(order);
                    }
                }
            }
            return result;
        }

        public bool MarkMadeComplete(Guid id, DateTime data)
        {
            using (var connection = new SqlConnection(connectionsString))
            {
                var command = new SqlCommand("update Northwind.Orders set ShippedDate = @data where OrderID = @id", connection);
                command.Parameters.AddWithValue("@data", data);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();

                return command.ExecuteNonQuery() == 1;
            }
        }

        public bool TransferToWork(Guid id, DateTime data)
        {
            using (var connection = new SqlConnection(connectionsString))
            {
                var command = new SqlCommand("update Northwind.Orders set OrderDate = @data where OrderID = @id", connection);
                command.Parameters.AddWithValue("@data", data);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();

                return command.ExecuteNonQuery() == 1;
            }
        }
    }
}
