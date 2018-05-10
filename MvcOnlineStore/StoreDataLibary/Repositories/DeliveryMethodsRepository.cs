using BuildSchool.MvcSolution.OnlineStore.Models.Models;
using System;
using System.Collections.Generic;
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
        public DeliveryMethods FindById(int DeliveryMethodID)
        //單筆資料查詢
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");
            var sql = "SELECT * FROM DeliveryMethods WHERE DeliveryMethodID = @id";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@id", DeliveryMethodID);

            var result = command.ExecuteScalar();//純量值
            //如果查詢資料是NULL的話
            //if (result == DBNull.Value)
            connection.Open();

            var reader = command.ExecuteReader();
            var DeliveryMethods = new DeliveryMethods();

            while (reader.Read())
            {
                DeliveryMethods.DeliveryMethodID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("DeliveryMethodID")));
                DeliveryMethods.DeliveryMethod = reader.GetValue(reader.GetOrdinal("DeliveryMethod")).ToString();
                DeliveryMethods.Freight = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("Freight")));
            }

            reader.Close();

            return DeliveryMethods;
        }
        public IEnumerable<DeliveryMethods> GetAll()
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");

            var sql = "SELECT * FROM DeliveryMethods";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();

            var reader = command.ExecuteReader();
            var deliveryMethods = new List<DeliveryMethods>();

            while (reader.Read())
            {
                var DeliveryMethods = new DeliveryMethods();
                DeliveryMethods.DeliveryMethodID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("DeliveryMethodID")));
                DeliveryMethods.DeliveryMethod = reader.GetValue(reader.GetOrdinal("DeliveryMethod")).ToString();
                DeliveryMethods.Freight = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("Freight")));
            }

            reader.Close();

            return deliveryMethods;
        }
    }
}
