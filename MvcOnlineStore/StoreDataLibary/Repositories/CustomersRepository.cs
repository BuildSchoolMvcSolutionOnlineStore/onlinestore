using Dapper;
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
            using(var connection= new SqlConnection(SqlConnectionString.ConnectionString))
            {
                connection.Execute("INSERT INTO Customers VALUES(@CustomerID,@CustomerPassword,@CustomerName,@Telephone,@Address,@CustomerMail)",
                    new
                    {
                        customerID = model.CustomerID,
                        customerPassword = model.CustomerPassword,
                        customerName=model.CustomerName,
                        telephone=model.Telephone,
                        address=model.Address,
                        CustomerMail=model.CustomerMail
                    });
            }
        }
        public void UpdateCustomer(Customers model)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
            {
                connection.Execute(
                    "UPDATE Customers SET " +
                    "CustomerPassword = @CustomerPassword,CustomerName = @CustomerName,Telephone = @Telephone,Address = @Address,CustomerMail = @CustomerMail WHERE CustomerID = @id",
                    new
                    {
                        id = model.CustomerID,
                        customerPassword = model.CustomerPassword,
                        customerName = model.CustomerName,
                        telephone = model.Telephone,
                        address = model.Address,
                        CustomerMail = model.CustomerMail
                    });
            }
            
        }

        public void DeleteCustomer(String CustomerID)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
            {
                connection.Execute(
                    "Delete From Customers WHERE CustomerID = @id",
                    new
                    {
                        id =CustomerID
                    });
            }
        }
        public Customers FindCustomerByCustomerId(string CustomerID)
        //單筆資料查詢
        {
            Customers customer = null;
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
            {
                var customers=connection.Query<Customers>(
                    "SELECT * FROM Customers WHERE CustomerID = @id",
                    new
                    {
                        id = CustomerID
                    });
                foreach(var item in customers)
                {
                    if (item.CustomerID != null)
                        customer = item;
                }
            }
            return customer;
        }
        public IEnumerable<Customers> GetAllCustomers()
        {
            var customerlist = new List<Customers>();
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
            {
                var customers = connection.Query<Customers>(
                    "SELECT * FROM Customers");

                foreach (var item in customers)
                {
                        customerlist.Add(item);
                }
            }
            return customerlist;
        }
    }
}
