using BuildSchool.MvcSolution.OnlineStore.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.MvcSolution.OnlineStore.Models.Repositories
{
    class OrderDetailsRepository
    {
        string serviceIP = "192.168.40.21";
        public void Create(OrderDetails model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");
            var sql = "INSERT INTO Customers VALUES(@OrderID ,@ProductID,@Quantity,@Discount)";
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
            var sql = "UPRATE Customers SET @OrderID ,@ProductID,@Quantity,@Discount WHERE orderID = @id";
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
            var sql = "Delete From Customers WHERE OrderID = @id";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@id", model.OrderID);
            connection.Open();//連線打開
            command.ExecuteNonQuery();//執行指令
            connection.Close();//關閉結束
        }
        public OrderDetails FindById(string orederId)
        //單筆資料查詢
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");
            var sql = "SELECT * FROM Customers WHERE OrderID = @id";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@id", orederId);

            var result = command.ExecuteScalar();//純量值
            //如果查詢資料是NULL的話
            //if (result == DBNull.Value)
            connection.Open();

            var reader = command.ExecuteReader();
            var orderDetail = new OrderDetails();

            while (reader.Read())
            {
                orderDetail.OrderID = reader.GetValue(reader.GetOrdinal("OrderID")).ToString();//每個get都是欄位序號
                orderDetail.ProductID = reader.GetValue(reader.GetOrdinal("ProductID")).ToString();
                orderDetail.Quantity = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("Quantity")));
                orderDetail.Discount = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("Discount")));

            }

            reader.Close();

            return orderDetail;
        }
        public IEnumerable<OrderDetails> GetAll()
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");

            var sql = "SELECT * FROM OrderDetails";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();

            var reader = command.ExecuteReader();
            var orderDetails = new List<OrderDetails>();

            while (reader.Read())
            {
                var orderDetail = new OrderDetails();
                orderDetail.OrderID = reader.GetValue(reader.GetOrdinal("OrderID")).ToString();
                orderDetail.ProductID = reader.GetValue(reader.GetOrdinal("ProductID")).ToString();
                orderDetail.Quantity = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("Quantity")));
                orderDetail.Discount = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("Discount")));
            }

            reader.Close();

            return orderDetails;
        }
    }
}
