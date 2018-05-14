using BuildSchool.MvcSolution.OnlineStore.Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
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

            connection.Open();

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var properties = typeof(Orders).GetProperties();
            Orders orders = null;

            while(reader.Read())
            {
                orders = new Orders();
                for(var i = 0 ; i < reader.FieldCount ; i++)
                {
                    var fieldName = reader.GetName(i);
                    var property = properties.FirstOrDefault(p => p.Name == fieldName);
                    if (property == null)
                        continue;
                    if (!reader.IsDBNull(i))
                        property.SetValue(orders, reader.GetValue(i));
                }
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
            Orders orders = null;
            var orderslist = new List<Orders>();
            var properties = typeof(Orders).GetProperties();

            while (reader.Read())
            {
                orders = new Orders();
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    var fieldName = reader.GetName(i);
                    var property = properties.FirstOrDefault(p => p.Name == fieldName);
                    if (property == null)
                        continue;
                    if (!reader.IsDBNull(i))
                        property.SetValue(orders, reader.GetValue(i));
                }
                orderslist.Add(orders);
            }

            reader.Close();

            return orderslist;
        }
    }
}
