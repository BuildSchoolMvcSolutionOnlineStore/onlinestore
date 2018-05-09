using BuildSchool.MvcSolution.OnlineStore.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.MvcSolution.OnlineStore.Models.Repositories
{
    public class OrdersRepository
    {
        string serviceIP = "192.168.40.21";
        public void Create(Orders model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");
            var sql = "INSERT INTO Orders VALUES(@OrderID ,@CustomerID, @OrderDate, @ShippedDate, @PaymentMethodID, @DeliveryMethodID)";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@OrderID",model.OrderID);
            command.Parameters.AddWithValue("@CustomerID",model.CustomerID);
            command.Parameters.AddWithValue("@OrderDate",model.OrderDate);
            command.Parameters.AddWithValue("@ShippedDate",model.ShippedDate);
            command.Parameters.AddWithValue("@PaymentMethodID",model.PaymentMethodID);
            command.Parameters.AddWithValue("@DeliveryMethodID",model.DeliveryMethodID);
            command.Parameters.AddWithValue("@OrderID", model.OrderID);


            connection.Open();//連線打開
            command.ExecuteNonQuery();//執行指令
            connection.Close();//關閉結束
        }

        public void Update(Orders model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");
            var sql = "UPRATE Orders SET @CustomerID, @OrderDate, @ShippedDate, @PaymentMethodID, @DeliveryMethodID WHERE OrderID = @id";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", model.OrderID);
            command.Parameters.AddWithValue("@CustomerID", model.CustomerID);
            command.Parameters.AddWithValue("@OrderDate", model.OrderDate);
            command.Parameters.AddWithValue("@ShippedDate", model.ShippedDate);
            command.Parameters.AddWithValue("@PaymentMethodID", model.PaymentMethodID);
            command.Parameters.AddWithValue("@DeliveryMethodID", model.DeliveryMethodID);
            command.Parameters.AddWithValue("@OrderID", model.OrderID);

            connection.Open();//連線打開
            command.ExecuteNonQuery();//執行指令
            connection.Close();//關閉結束
        }

        public void Delete(Orders model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");
            var sql = "Delete From Orders WHERE OrderID = @id";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@id",model.OrderID);
            connection.Open();//連線打開
            command.ExecuteNonQuery();//執行指令
            connection.Close();//關閉結束
        }

        public Orders FindById(string orderId)
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");
            var sql = "SELECT * FROM Orders WHERE OrdersID = @id";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@id",orderId);

            var result = command.ExecuteScalar();

            connection.Open();

            var reader = command.ExecuteReader();
            var orders = new Orders();

            while(reader.Read())
            {
                orders.OrderID = reader.GetValue(reader.GetOrdinal("OrderID")).ToString();
                orders.CustomerID = Convert.ToInt32(reader.GetOrdinal("CustomerID"));
                orders.OrderDate = Convert.ToDateTime(reader.GetOrdinal("OrderDate"));
                orders.ShippedDate = Convert.ToDateTime(reader.GetOrdinal("ShippedDate"));
                orders.PaymentMethodID = Convert.ToInt32(reader.GetOrdinal("PaymentMethodID"));
                orders.DeliveryMethodID = Convert.ToInt32(reader.GetOrdinal("DeliveryMethodID"));
            }

            reader.Close();

            return orders;
        }

        public IEnumerable<Orders> GetAll()
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");
            var sql = "SELECT * FROM Orders";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();

            var reader = command.ExecuteReader();
            var orderslist = new List<Orders>();

            while (reader.Read())
            {
                var orders = new Orders();
                orders.OrderID = reader.GetValue(reader.GetOrdinal("OrderID")).ToString();
                orders.CustomerID = Convert.ToInt32(reader.GetOrdinal("CustomerID"));
                orders.OrderDate = Convert.ToDateTime(reader.GetOrdinal("OrderDate"));
                orders.ShippedDate = Convert.ToDateTime(reader.GetOrdinal("ShippedDate"));
                orders.PaymentMethodID = Convert.ToInt32(reader.GetOrdinal("PaymentMethodID"));
                orders.DeliveryMethodID = Convert.ToInt32(reader.GetOrdinal("DeliveryMethodID"));
            }

            reader.Close();

            return orderslist;
        }
    }
}
