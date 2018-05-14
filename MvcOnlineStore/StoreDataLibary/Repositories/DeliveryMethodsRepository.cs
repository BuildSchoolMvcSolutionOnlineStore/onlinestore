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
    public class DeliveryMethodsRepository
    {
        string serviceIP = "192.168.40.21";
        public void Create(DeliveryMethods model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");
            var sql = "INSERT INTO DeliveryMethods VALUES(@DeliveryMethodID, @DeliveryMethod, @Freight)";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@DeliveryMethodID", model.DeliveryMethodID);
            command.Parameters.AddWithValue("@DeliveryMethod", model.DeliveryMethod);
            command.Parameters.AddWithValue("@Freight", model.Freight);

            connection.Open();//連線打開
            command.ExecuteNonQuery();//執行指令
            connection.Close();//關閉結束
        }
        public void Update(DeliveryMethods model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");
            var sql = "UPRATE DeliveryMethods SET @DeliveryMethod, @Freight WHERE DeliveryMethodID = @id";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", model.DeliveryMethodID);
            command.Parameters.AddWithValue("@DeliveryMethod", model.DeliveryMethod);
            command.Parameters.AddWithValue("@Freight", model.Freight);

            connection.Open();//連線打開
            command.ExecuteNonQuery();//執行指令
            connection.Close();//關閉結束
        }
        public void Delete(DeliveryMethods model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");
            var sql = "Delete From DeliveryMethods WHERE DeliveryMethodID = @id";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@id", model.DeliveryMethodID);
            connection.Open();//連線打開
            command.ExecuteNonQuery();//執行指令
            connection.Close();//關閉結束
        }
        public DeliveryMethods FindDeliveryMethodByDeliveryMethodID(string DeliveryMethodID)
        {
            SqlConnection connection = new SqlConnection(SqlConnectionString.ConnectionString);

            var sql = "SELECT * FROM Products WHERE ProductID = @id";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@id", DeliveryMethodID);

            connection.Open();

            var reader = command.ExecuteReader();
            var properties = typeof(DeliveryMethods).GetProperties();

            DeliveryMethods deliveryMethods = null;

            while (reader.Read())
            {
                deliveryMethods = DbReaderModelBinder<DeliveryMethods>.Bind(reader);
            }

            reader.Close();

            return deliveryMethods;
        }

        public IEnumerable<DeliveryMethods> GetAllDeliveryMethods()
        {
            SqlConnection connection = new SqlConnection(SqlConnectionString.ConnectionString);

            var sql = "SELECT * FROM DeliveryMethods";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();

            var reader = command.ExecuteReader();
            DeliveryMethods deliveryMethods = null;
            var deliveryMethodslist = new List<DeliveryMethods>();
            var properties = typeof(DeliveryMethods).GetProperties();

            while (reader.Read())
            {
                deliveryMethods = DbReaderModelBinder<DeliveryMethods>.Bind(reader);
                deliveryMethodslist.Add(deliveryMethods);
            }

            reader.Close();

            return deliveryMethodslist;
        }
    }
}
