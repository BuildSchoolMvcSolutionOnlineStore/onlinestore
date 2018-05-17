using Dapper;
using StoreData.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Repositories
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
                connection.Execute("UPDATE OrderDetails SET ProductID = @ProductID, Quantity = @Quantity, Discount =@Discount WHERE OrderID = @OrderID AND ProductID = @ProductID", model);
            }
        }
        public void DeleteOrderDeta(string OrderID)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
            {
                connection.Execute(
                    "Delete From OrderDetails WHERE OrderID = @id",
                    new
                    {
                        id = OrderID
                    });
            }
        }
        public OrderDetails FindOrderDetaByOrderId(string OrderId)
        //單筆資料查詢
        {
            OrderDetails orderDetails = null;
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
            {
                var orderdeta = connection.Query<OrderDetails>(
                    "SELECT * FROM OrderDetails WHERE OrderID = @id",
                    new
                    {
                        id = OrderId
                    });
                foreach(var item in orderdeta)
                {
                    if(item.OrderID != null)
                    {
                        orderDetails = item;
                    }
                }
            }
            return orderDetails;
        }
        public IEnumerable<OrderDetails> GetAllOrderDeta()
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
            {
                var orderdeta = connection.Query<OrderDetails>("SELECT * FROM OrderDetails");
                return orderdeta;
            }
        }
    }
}
