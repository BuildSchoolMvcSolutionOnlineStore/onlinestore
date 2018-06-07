using Dapper;
using StoreData.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StoreData.Repositories
{
    public class MessagesRepository
    {
        public void Create(Messages model)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                connection.Execute("INSERT INTO Messages VALUES(@OrderID,@Message,@Reply,@Time,@ReplyTime)",
                    model);
            }
        }
        public void Update(Messages model)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                connection.Execute(
                    "UPDATE Messages SET " +
                    "Message = @Message,Reply = @Reply,ReplyTime = @ReplyTime "+
                    "WHERE OrderID = @OrderID AND Time = @Time",
                    model);
            }
        }
        public void Delete(string orderId,DateTime time)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                connection.Execute(
                    "DELETE FROM[Messages] WHERE OrderID = @orderId AND[Time] = @time",
                    new
                    {
                        orderId,time
                    });
            }
        }
        public IEnumerable<Messages> FindById_Admin(string Id)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                var list = connection.Query<Messages>(
                    "SELECT * FROM [Messages] WHERE OrderID = @Id", new { Id });
                return list;
            }
        }

    }
}