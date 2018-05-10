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
        string serviceIP = "192.168.40.21";
        public void Create(Products model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");
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
        public void Update(Products model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");
            var sql = "UPRATE Products SET @CategoryID,@ProductName,@Stock,@UnitPrice,@Size,@Color,@Instructions WHERE PaymentMethodID = @id";
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
        public void Delete(Products model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");
            var sql = "Delete From Products WHERE ProductID = @id";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@id", model.ProductID);
            connection.Open();//連線打開
            command.ExecuteNonQuery();//執行指令
            connection.Close();//關閉結束
        }
        public Products FindById(string ProductID)
        //單筆資料查詢
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");
            var sql = "SELECT * FROM Products WHERE ProductID = @id";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@id", ProductID);

            var result = command.ExecuteScalar();//純量值
            //如果查詢資料是NULL的話
            //if (result == DBNull.Value)
            connection.Open();

            var reader = command.ExecuteReader();
            var products = new Products();

            while (reader.Read())
            {
                products.ProductID = reader.GetValue(reader.GetOrdinal("ProductID")).ToString();
                products.CategoryID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("CategoryID")));
                products.ProductName = reader.GetValue(reader.GetOrdinal("ProductName")).ToString();
                products.Stock = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("Stock")));
                products.UnitPrice = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("UnitPrice")));
                products.Size = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("Size")));
                products.Color = reader.GetValue(reader.GetOrdinal("Color")).ToString();
                products.Instructions = reader.GetValue(reader.GetOrdinal("Instructions")).ToString();
            }

            reader.Close();

            return products;
        }
        public IEnumerable<Products> GetAll()
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");

            var sql = "SELECT * FROM Products";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();

            var reader = command.ExecuteReader();
            var productlist = new List<Products>();

            while (reader.Read())
            {
                var product = new Products();
                product.ProductID = reader.GetValue(reader.GetOrdinal("ProductID")).ToString();
                product.CategoryID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("CategoryID")));
                product.ProductName = reader.GetValue(reader.GetOrdinal("ProductName")).ToString();
                product.Stock = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("Stock")));
                product.UnitPrice = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("UnitPrice")));
                product.Size = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("Size")));
                product.Color = reader.GetValue(reader.GetOrdinal("Color")).ToString();
                product.Instructions = reader.GetValue(reader.GetOrdinal("Instructions")).ToString();
            }

            reader.Close();

            return productlist;
        }
    }
}
