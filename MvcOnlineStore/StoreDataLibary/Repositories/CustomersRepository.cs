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
        string serviceIP = "192.168.40.21";
        public void Create(Customer model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");
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
        public void Update(Customer model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");
            var sql = "UPRATE Customers SET @CustomerPassword,@CustomerName,@Telephone,@Address,@CustomerMail WHERE CustomerID = @id";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", model.CustomerID);
            command.Parameters.AddWithValue("@customerPassword", model.CustomerPassword);
            command.Parameters.AddWithValue("@customerName", model.CustomerName);
            command.Parameters.AddWithValue("@telephone", model.Telephone);
            command.Parameters.AddWithValue("@address", model.Address);
            command.Parameters.AddWithValue("@CustomerMail", model.CustomerMail);

            connection.Open();//連線打開
            command.ExecuteNonQuery();//執行指令
            connection.Close();//關閉結束
        }
        public void Delete(Customer model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");
            var sql = "Delete From Customers WHERE CustomerID = @id";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@id", model.CustomerID);
            connection.Open();//連線打開
            command.ExecuteNonQuery();//執行指令
            connection.Close();//關閉結束
        }
        public Customer FindById(string customerId)
        //單筆資料查詢
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");
            var sql = "SELECT * FROM Customers WHERE CustomerID = @id";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@id", customerId);

            connection.Open();

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var properties = typeof(Customer).GetProperties();
            Customer customer = null;

            while (reader.Read())
            {
                customer = new Customer();
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    var fieldName = reader.GetName(i);
                    var property = properties.FirstOrDefault(p => p.Name == fieldName);
                    if(property == null)
                        continue;

                    if (!reader.IsDBNull(i))
                        property.SetValue(customer, reader.GetValue(i));
                }           
            }

            reader.Close();
            return customer;
        }
        public IEnumerable<Customer> GetAll()
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");

            var sql = "SELECT * FROM Customers";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();

            var reader = command.ExecuteReader();
            Customer customer = null;
            var customerlist = new List<Customer>();
            var properties = typeof(Customer).GetProperties();

            while (reader.Read())
            {
                customer = new Customer();
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    var fieldName = reader.GetName(i);
                    var property = properties.FirstOrDefault(p => p.Name == fieldName);
                    if (property == null)
                        continue;

                    if (!reader.IsDBNull(i))
                        property.SetValue(customer, reader.GetValue(i));
                }
                customerlist.Add(customer);
            }

            reader.Close();

            return customerlist;
        }
    }
}
