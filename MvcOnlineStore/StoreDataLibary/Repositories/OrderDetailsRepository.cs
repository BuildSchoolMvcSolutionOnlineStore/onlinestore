using BuildSchool.MvcSolution.OnlineStore.Models.Models;
using Dapper;
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
        public void CreateOrderDeta(OrderDetails model)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
            {
                connection.Execute("INSERT INTO OrderDetails VALUES(@OrderID ,@ProductID,@Quantity,@Discount)",model);
            }
        }
        public void UpdateOrderDeta(OrderDetails model)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
            {
                connection.Execute("UPRATE OrderDetails SET @OrderID ,@ProductID,@Quantity,@Discount WHERE orderID = @id",
                    new
                    {
                        id = model.OrderID,
                        OrderID = model.OrderID,
                        ProductID = model.ProductID,
                        Quantity = model.Quantity,
                        Discount = model.Discount
                    });
            }
        }
        public void DeleteOrderData(string OrderId)
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
                orderDetail = DbReaderModelBinder<OrderDetails>.Bind(reader);
                //for (var i = 0; i < reader.FieldCount; i++)
                //{
                //    var filedName = reader.GetName(i);
                //    var property = properties.FirstOrDefault(p => p.Name == filedName);

                //    if (property == null)
                //        continue;

                //    if (!reader.IsDBNull(i))
                //        property.SetValue(orderDetail, reader.GetValue(i));
                //}
                orderDetails.Add(orderDetail);
            }

            reader.Close();

            return orderDetails;
        }
    }
}
