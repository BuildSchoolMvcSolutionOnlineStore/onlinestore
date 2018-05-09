using BuildSchool.MvcSolution.OnlineStore.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.MvcSolution.OnlineStore.Models.Repositories
{
    public class PaymentMethodsRepository
    {
        string serviceIP = "192.168.40.21";
        public void Create(PaymentMethods model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");
            var sql = "INSERT INTO PaymentMethods VALUES(@PaymentMethodID, @PaymentMethod)";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@PaymentMethodID", model.PaymentMethodID);
            command.Parameters.AddWithValue("@PaymentMethod", model.PaymentMethod);
            command.Parameters.AddWithValue("@PaymentMethodID", model.PaymentMethodID);

            connection.Open();//連線打開
            command.ExecuteNonQuery();//執行指令
            connection.Close();//關閉結束
        }

        public void Update(PaymentMethods model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");
            var sql = "UPRATE PaymentMethods SET @PaymentMethodID, @PaymentMethod WHERE PaymentMethodID = @id";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", model.PaymentMethodID);
            command.Parameters.AddWithValue("@customerAccountNumber", model.PaymentMethod);
            command.Parameters.AddWithValue("@customerID", model.PaymentMethodID);

            connection.Open();//連線打開
            command.ExecuteNonQuery();//執行指令
            connection.Close();//關閉結束
        }
        public void Delete(PaymentMethods model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");
            var sql = "Delete From PaymentMethods WHERE PaymentMethodID = @id";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@id", model.PaymentMethodID);
            connection.Open();//連線打開
            command.ExecuteNonQuery();//執行指令
            connection.Close();//關閉結束
        }

        public PaymentMethods FindById(string PaymentMethodId)
        //單筆資料查詢
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");
            var sql = "SELECT * FROM PaymentMethods WHERE PaymentMethodID = @id";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@id", PaymentMethodId);

            var result = command.ExecuteScalar();//純量值
            //如果查詢資料是NULL的話
            //if (result == DBNull.Value)
            connection.Open();

            var reader = command.ExecuteReader();
            var paymentMethods = new PaymentMethods();

            while (reader.Read())
            {
                paymentMethods.PaymentMethodID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("PaymentMethodID")));//每個get都是欄位序號
                paymentMethods.PaymentMethod = reader.GetValue(reader.GetOrdinal("PaymentMethod")).ToString();

            }

            reader.Close();

            return paymentMethods;
        }
        public IEnumerable<PaymentMethods> GetAll()
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");

            var sql = "SELECT * FROM PaymentMethods";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();

            var reader = command.ExecuteReader();
            var paymentMethodlist = new List<PaymentMethods>();

            while (reader.Read())
            {
                var paymentMethods = new PaymentMethods();
                paymentMethods.PaymentMethodID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("PaymentMethodID")));//每個get都是欄位序號
                paymentMethods.PaymentMethod = reader.GetValue(reader.GetOrdinal("PaymentMethod")).ToString();
            }

            reader.Close();

            return paymentMethodlist;
        }
    }
}
