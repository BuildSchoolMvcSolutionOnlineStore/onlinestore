using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.MvcSolution.OnlineStore.Models.Repositories
{
    public class CustomersRepository
    {
        public void CreateCustomer(Customers model)
        {
            SqlConnection connection = new SqlConnection(SqlConnectionString.ConnectionString);
            var sql = "INSERT INTO Customers VALUES(@CustomerID,@CustomerPassword,@CustomerName,@Telephone,@Address,@CustomerMail)";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@customerID", model.CustomerID);
            command.Parameters.AddWithValue("@customerPassword", model.CustomerPassword);
            command.Parameters.AddWithValue("@customerName", model.CustomerName);
            command.Parameters.AddWithValue("@telephone", model.Telephone);
            command.Parameters.AddWithValue("@address", model.Address);
            command.Parameters.AddWithValue("@CustomerMail", model.CustomerMail);

            connection.Open();//連線打開
            command.ExecuteNonQuery();//執行指令
            connection.Close();//關閉結束
        }
        public void Update(Customers model)
        {
            SqlConnection connection = new SqlConnection(SqlConnectionString.ConnectionString);
            var sql = "UPDATE Customers SET " +
                "CustomerPassword = @CustomerPassword,CustomerName = @CustomerName,Telephone = @Telephone,Address = @Address,CustomerMail = @CustomerMail WHERE CustomerID = @id";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", model.CustomerID);
            command.Parameters.AddWithValue("@CustomerPassword", model.CustomerPassword);
            command.Parameters.AddWithValue("@CustomerName", model.CustomerName);
            command.Parameters.AddWithValue("@Telephone", model.Telephone);
            command.Parameters.AddWithValue("@Address", model.Address);
            command.Parameters.AddWithValue("@CustomerMail", model.CustomerMail);

            connection.Open();//連線打開
            command.ExecuteNonQuery();//執行指令
            connection.Close();//關閉結束
        }

        public void Delete(String CustomerID)
        {
            SqlConnection connection = new SqlConnection(SqlConnectionString.ConnectionString);
            var sql = "Delete From Customers WHERE CustomerID = @id";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@id", CustomerID);
            connection.Open();//連線打開
            command.ExecuteNonQuery();//執行指令
            connection.Close();//關閉結束
        }
        public Customers FindById(string CustomerId)
        //單筆資料查詢
        {
            SqlConnection connection = new SqlConnection(SqlConnectionString.ConnectionString);
            var sql = "SELECT * FROM Customers WHERE CustomerID = @id";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@id", CustomerId);

            connection.Open();

            var reader = command.ExecuteReader();
            var properties = typeof(Customers).GetProperties();
            Customers customer = null;

            while (reader.Read())
            {
                customer = DbReaderModelBinder<Customers>.Bind(reader); 
            }

            reader.Close();
            return customer;
        }
        public IEnumerable<Customers> GetAll()
        {
            SqlConnection connection = new SqlConnection(SqlConnectionString.ConnectionString);

            var sql = "SELECT * FROM Customers";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();

            var reader = command.ExecuteReader();
            Customers customer = null;
            var customerlist = new List<Customers>();
            var properties = typeof(Customers).GetProperties();

            while (reader.Read())
            {
                customer = DbReaderModelBinder<Customers>.Bind(reader);
                customerlist.Add(customer);
            }

            reader.Close();

            return customerlist;
        }
    }
}
