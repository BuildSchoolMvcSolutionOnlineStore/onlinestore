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
            command.Parameters.AddWithValue("@PaymentMethod", model.PaymentMethod);

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

        public PaymentMethods FindById(int PaymentMethodId)
        //單筆資料查詢
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");
            var sql = "SELECT * FROM PaymentMethods WHERE PaymentMethodID = @id";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@id", PaymentMethodId);

            connection.Open();

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var properties = typeof(PaymentMethods).GetProperties();
            PaymentMethods paymentMethods = null;

            while (reader.Read())
            {
                paymentMethods = new PaymentMethods();
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    var fieldName = reader.GetName(i);
                    var property = properties.FirstOrDefault(p => p.Name == fieldName);
                    if (property == null)
                        continue;
                    if (!reader.IsDBNull(i))
                        property.SetValue(paymentMethods, reader.GetValue(i));
                }
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
            PaymentMethods paymentMethods = null;
            var paymentMethodlist = new List<PaymentMethods>();
            var properties = typeof(PaymentMethods).GetProperties();

            while (reader.Read())
            {
                paymentMethods = new PaymentMethods();
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    var fieldName = reader.GetName(i);
                    var property = properties.FirstOrDefault(p => p.Name == fieldName);
                    if (property == null)
                        continue;
                    if (!reader.IsDBNull(i))
                        property.SetValue(paymentMethods, reader.GetValue(i));
                }
                paymentMethodlist.Add(paymentMethods);
            }


            reader.Close();

            return paymentMethodlist;
        }
    }
}
