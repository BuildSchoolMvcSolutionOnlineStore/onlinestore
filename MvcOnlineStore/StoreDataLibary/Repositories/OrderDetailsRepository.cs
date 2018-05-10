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
    public class OrderDetailsRepository
    {
        string serviceIP = "192.168.40.21";
        public void Create(OrderDetails model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");
            var sql = "INSERT INTO OrderDetails VALUES(@OrderID ,@ProductID,@Quantity,@Discount)";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@orederID", model.OrderID);
            command.Parameters.AddWithValue("@productID", model.ProductID);
            command.Parameters.AddWithValue("@quantity", model.Quantity);
            command.Parameters.AddWithValue("@discount", model.Discount);

            connection.Open();//連線打開
            command.ExecuteNonQuery();//執行指令
            connection.Close();//關閉結束
        }
        public void Update(OrderDetails model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");
            var sql = "UPRATE OrderDetails SET @OrderID ,@ProductID,@Quantity,@Discount WHERE orderID = @id";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@orederID", model.OrderID);
            command.Parameters.AddWithValue("@productID", model.ProductID);
            command.Parameters.AddWithValue("@quantity", model.Quantity);
            command.Parameters.AddWithValue("@discount", model.Discount);


            connection.Open();//連線打開
            command.ExecuteNonQuery();//執行指令
            connection.Close();//關閉結束
        }
        public void Delete(OrderDetails model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");
            var sql = "Delete From OrderDetails WHERE OrderID = @id";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@id", model.OrderID);
            connection.Open();//連線打開
            command.ExecuteNonQuery();//執行指令
            connection.Close();//關閉結束
        }
        public OrderDetails FindById(string orderId)
        //單筆資料查詢
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");
            var sql = "SELECT * FROM OrderDetails WHERE OrderID = @id";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@id", orderId);

            
            connection.Open();

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var properties = typeof(OrderDetails).GetProperties();
            OrderDetails orderDetails = null;

            while (reader.Read())
            {
                orderDetails = new OrderDetails();
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    var fieldName = reader.GetName(i);
                    var property = properties.FirstOrDefault(p => p.Name == fieldName);
                    if (property == null)
                        continue;

                    if (!reader.IsDBNull(i))
                        property.SetValue(orderDetails, reader.GetValue(i));
                }
            }

            reader.Close();
            return orderDetails;
        }
        public IEnumerable<OrderDetails> GetAll()
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");

            var sql = "SELECT * FROM OrderDetails";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();

            var reader = command.ExecuteReader();
            OrderDetails orderDetail = null;
            var orderDetails = new List<OrderDetails>();
            var properties = typeof(OrderDetails).GetProperties();

            while (reader.Read())
            {
                orderDetail = new OrderDetails();
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    var filedName = reader.GetName(i);
                    var property = properties.FirstOrDefault(p => p.Name == filedName);

                    if (property == null)
                        continue;

                    if (!reader.IsDBNull(i))
                        property.SetValue(orderDetail, reader.GetValue(i));
                }
                orderDetails.Add(orderDetail);
            }

            reader.Close();

            return orderDetails;
            //123
        }
    }
}
