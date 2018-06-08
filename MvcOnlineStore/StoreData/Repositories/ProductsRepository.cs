using Dapper;
using StoreData.Models;
using StoreData.ViewModels.Home;
using StoreData.ViewModels.Manager;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Repositories
{
    public class ProductsRepository
    {
        public void Create(Products model)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                connection.Execute(
                "INSERT INTO Products VALUES(@ProductID, @CategoryID,@ProductName,@Stock,@UnitPrice,@Size,@Color,@Instructions,@Path)",
                model);
            }
        }
        public void Update(Products model)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                connection.Execute(
                "UPDATE Products SET " +
                "CategoryID = @CategoryID,ProductName = @ProductName,Stock = @Stock,UnitPrice = @UnitPrice," +
                "Size = @Size,Color = @Color,Instructions = @Instructions,Path = @Path WHERE ProductID = @ProductID",
                model);
            }
        }
        public void Delete(String ProductID)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                connection.Execute(
                "DELETE FROM Products WHERE ProductID = @id",
                new
                {
                    id = ProductID
                });
            }
        }

        public Products FindById(string ProductID)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                var products = connection.Query<Products>(
                    "SELECT * FROM Products WHERE ProductID = @id",
                    new
                    {
                        id = ProductID
                    });
                var product = products.FirstOrDefault();

                return product;
            }
        }

        public IEnumerable<ProductsItem> FindByProductItemId(string ProductID)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                var products = connection.Query<ProductsItem>(
                    "SELECT * FROM Products WHERE ProductID = @id",
                    new
                    {
                        id = ProductID
                    });

                return products;
            }
        }

        public IEnumerable<ProductsItem> GetAll()
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                var products = connection.Query<ProductsItem>(
                    "SELECT * FROM Products");
                return products;
            }
        }

        public IEnumerable<ProductsItem> SearchByProductName(string selectString)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                var products = connection.Query<ProductsItem>(
                    "SELECT * FROM Products WHERE ProductName LIKE '%'+@str+'%'",/*CONCAT('%',@str,'%')"*/
                    new
                    {
                        str = selectString
                    });

                return products;
            }
        }

        public IEnumerable<Products> SearchById(string selectString)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                var products = connection.Query<Products>(
                    "SELECT * FROM Products WHERE ProductID LIKE '%'+@str+'%'",
                    new
                    {
                        str = selectString
                    });

                return products;
            }
        }
        public IEnumerable<Products> FindTopByQuantity()
        {
            var productlist = new List<Products>();
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                var products = connection.Query<Products>(
                    "SELECT TOP 3 p.ProductID FROM Products p " +
                    "INNER JOIN OrderDetails od ON od.ProductID = p.ProductID " +
                    "GROUP BY p.ProductID " +
                    "ORDER BY Count(od.Quantity) DESC ");

                foreach (var item in products)
                {
                    productlist.Add(item);
                }
            }
            return productlist;
        }
        public IEnumerable<Products> OrderByUnitPrice()
        {
            var productlist = new List<Products>();
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                var products = connection.Query<Products>(
                    "SELECT * FROM Products ORDER BY UnitPrice ");

                foreach (var item in products)
                {
                    productlist.Add(item);
                }
            }
            return productlist;
        }
        //SELECT ProductID, ProductName, Stock, UnitPrice, Size, Color
        public IEnumerable<AdminProduct> GetAll_Admin()
        {

            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                var products = connection.Query<AdminProduct>(
                    "SELECT p.ProductID, " +
                    "(SELECT CategoryName FROM Categories WHERE p.CategoryID = CategoryID)As CategoryName, " +
                    "p.ProductName, p.Stock, p.UnitPrice, p.Size, p.Color " +
                    "FROM Products p");
                return products;
            }
        }
        //SELECT ProductID,CategoryName, ProductName, Stock, UnitPrice, Size, Color
        public IEnumerable<AdminProduct> SearchById_Admin(string selectString)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                var products = connection.Query<AdminProduct>(
                    "SELECT p.ProductID, " +
                    "(SELECT CategoryName FROM Categories WHERE p.CategoryID = CategoryID)As CategoryName, " +
                    "p.ProductName, p.Stock, p.UnitPrice, p.Size, p.Color " +
                    "FROM Products p " +
                    "WHERE ProductID LIKE '%'+@str+'%'",
                    new
                    {
                        str = selectString
                    });
                return products;
            }
        }
        public AdminProduct FindById_Admin(string Id)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                var products = connection.Query<AdminProduct>(
                    "SELECT p.ProductID, " +
                    "(SELECT CategoryName FROM Categories WHERE p.CategoryID = CategoryID)As CategoryName, " +
                    "p.ProductName, p.Stock, p.UnitPrice, p.Size, p.Color " +
                    "FROM Products p " +
                    "WHERE ProductID = @Id",
                    new
                    {
                        Id
                    });
                return products.FirstOrDefault();
            }
        }
        //取得產品
        public IEnumerable<ProductsItem> FindById_Home()
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                var products = connection.Query<ProductsItem>("SELECT ProductID, CategoryID, ProductName, UnitPrice, Path FROM Products ORDER BY ProductID DESC");
                return products;
            }
        }
        //取得最新的產品ID
        public string GetNewId()
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                var id = connection.Query<string>("SELECT TOP 1 ProductID FROM Products ORDER BY ProductID DESC");
                return id.FirstOrDefault();
            }
        }
    }
}
