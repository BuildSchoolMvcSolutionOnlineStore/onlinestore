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
        public void CreatePaymentMethods(PaymentMethods model)
        {
            SqlConnection connection = new SqlConnection(SqlConnectionString.ConnectionString);
            var sql = "INSERT INTO PaymentMethods VALUES(@PaymentMethodID, @PaymentMethod)";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@PaymentMethodID", model.PaymentMethodID);
            command.Parameters.AddWithValue("@PaymentMethod", model.PaymentMethod);

            connection.Open();//連線打開
            command.ExecuteNonQuery();//執行指令
            connection.Close();//關閉結束
        }

        public void UpdatePaymentMethods(PaymentMethods model)
        {
            SqlConnection connection = new SqlConnection(SqlConnectionString.ConnectionString);
            var sql = "UPRATE PaymentMethods SET @PaymentMethodID, @PaymentMethod WHERE PaymentMethodID = @id";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", model.PaymentMethodID);
            command.Parameters.AddWithValue("@PaymentMethod", model.PaymentMethod);

            connection.Open();//連線打開
            command.ExecuteNonQuery();//執行指令
            connection.Close();//關閉結束
        }
        public void DeletePaymentMethods(PaymentMethods model)
        {
            SqlConnection connection = new SqlConnection(SqlConnectionString.ConnectionString);
            var sql = "Delete From PaymentMethods WHERE PaymentMethodID = @id";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@id", model.PaymentMethodID);
            connection.Open();//連線打開
            command.ExecuteNonQuery();//執行指令
            connection.Close();//關閉結束
        }

        public PaymentMethods FindPaymentMethodsByPaymentMethodsId(int PaymentMethodId)
        //單筆資料查詢
        {
            SqlConnection connection = new SqlConnection(SqlConnectionString.ConnectionString);
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
        public IEnumerable<PaymentMethods> GetAllPaymentMethods()
        {
            SqlConnection connection = new SqlConnection(SqlConnectionString.ConnectionString);

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
