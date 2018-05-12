using BuildSchool.MvcSolution.OnlineStore.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.MvcSolution.OnlineStore.Models.Repositories
{
    public class ProductsRepository
    {
        public void CreateProduct(Products model)
        {
            SqlConnection connection = new SqlConnection(SqlConnectionString.ConnectionString);
            var sql = "INSERT INTO Products VALUES(@ProductID, @CategoryID,@ProductName,@Stock,@UnitPrice,@Size,@Color,@Instructions)";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ProductID", model.ProductID);
            command.Parameters.AddWithValue("@CategoryID", model.CategoryID);
            command.Parameters.AddWithValue("@ProductName", model.ProductName);
            command.Parameters.AddWithValue("@Stock", model.Stock);
            command.Parameters.AddWithValue("@UnitPrice", model.UnitPrice);
            command.Parameters.AddWithValue("@Size", model.Size);
            command.Parameters.AddWithValue("@Color", model.Color);
            command.Parameters.AddWithValue("@Instructions", model.Instructions);

            connection.Open();//連線打開
            command.ExecuteNonQuery();//執行指令
            connection.Close();//關閉結束
        }
        public void UpdateProduct(Products model)
        {
            SqlConnection connection = new SqlConnection(SqlConnectionString.ConnectionString);
            var sql = "UPDATE Products SET " +
                "CategoryID = @CategoryID,ProductName = @ProductName,Stock = @Stock,UnitPrice = @UnitPrice," +
                "Size = @Size,Color = @Color,Instructions = @Instructions WHERE ProductID = @id";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", model.ProductID);
            command.Parameters.AddWithValue("@CategoryID", model.CategoryID);
            command.Parameters.AddWithValue("@ProductName", model.ProductName);
            command.Parameters.AddWithValue("@Stock", model.Stock);
            command.Parameters.AddWithValue("@UnitPrice", model.UnitPrice);
            command.Parameters.AddWithValue("@Size", model.Size);
            command.Parameters.AddWithValue("@Color", model.Color);
            command.Parameters.AddWithValue("@Instructions", model.Instructions);

            connection.Open();//連線打開
            command.ExecuteNonQuery();//執行指令
            connection.Close();//關閉結束
        }
        public void DeleteProduct(String ProductID)
        {
            SqlConnection connection = new SqlConnection(SqlConnectionString.ConnectionString);
            var sql = "DELETE FROM Products WHERE ProductID = @id";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@id", ProductID);
            connection.Open();//連線打開
            command.ExecuteNonQuery();//執行指令
            connection.Close();//關閉結束
        }

        public Products FindProductByProductId(string ProductID)
        {
            SqlConnection connection = new SqlConnection(SqlConnectionString.ConnectionString);

            var sql = "SELECT * FROM Products WHERE ProductID = @id";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@id", ProductID);

            connection.Open();

            var reader = command.ExecuteReader();
            var properties = typeof(Products).GetProperties();

            Products product = null;

            while (reader.Read())
            {
                product = DbReaderModelBinder<Products>.Bind(reader);
            }

            reader.Close();

            return product;
        }
        public IEnumerable<Products> GetAllProducts()
        {
            SqlConnection connection = new SqlConnection(SqlConnectionString.ConnectionString);

            var sql = "SELECT * FROM Products";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();

            var reader = command.ExecuteReader();
            Products product = null;
            var productlist = new List<Products>();
            var properties = typeof(Products).GetProperties();

            while (reader.Read())
            {
                product = DbReaderModelBinder<Products>.Bind(reader);
                productlist.Add(product);
            }

            reader.Close();

            return productlist;
        }
    }
}
