using BuildSchool.MvcSolution.OnlineStore.Models.Models;
using Dapper;
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
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
            {
                connection.Execute(
                "INSERT INTO Products VALUES(@ProductID, @CategoryID,@ProductName,@Stock,@UnitPrice,@Size,@Color,@Instructions)",
                new
                {
                    ProductID = model.ProductID,
                    CategoryID = model.CategoryID,
                    ProductName = model.ProductName,
                    Stock = model.Stock,
                    UnitPrice = model.UnitPrice,
                    Size = model.Size,
                    Color = model.Color,
                    Instructions = model.Instructions
                });
            }
        }
        public void UpdateProduct(Products model)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
            {
                connection.Execute(
                "UPDATE Products SET " +
                "CategoryID = @CategoryID,ProductName = @ProductName,Stock = @Stock,UnitPrice = @UnitPrice," +
                "Size = @Size,Color = @Color,Instructions = @Instructions WHERE ProductID = @id",
                new
                {
                    id = model.ProductID,
                    CategoryID = model.CategoryID,
                    ProductName = model.ProductName,
                    Stock = model.Stock,
                    UnitPrice = model.UnitPrice,
                    Size = model.Size,
                    Color = model.Color,
                    Instructions = model.Instructions
                });
            }
        }
        public void DeleteProduct(String ProductID)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
            {
                connection.Execute(
                "DELETE FROM Products WHERE ProductID = @id",
                new
                {
                    id = ProductID
                });
            }
        }

        public Products FindProductByProductId(string ProductID)
        {
            Products product = null;
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
            {
                var products = connection.Query<Products>(
                    "SELECT * FROM Products WHERE ProductID = @id",
                    new
                    {
                        id = ProductID
                    });
                
                foreach(var item in products)
                {
                    if(item.ProductID != null)
                        product = item;
                }
            }
            return product;
        }
        public IEnumerable<Products> GetAllProducts()
        {
            var productlist = new List<Products>();
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
            {
                var products = connection.Query<Products>(
                    "SELECT * FROM Products");

                foreach (var item in products)
                {
                    productlist.Add(item);
                }
            }
            return productlist;
        }
        public IEnumerable<Products> GetProductsByProductName(string selectString)
        {
            var productlist = new List<Products>();
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
            {
                var products = connection.Query<Products>(
                    "SELECT * FROM Products WHERE ProductName LIKE '%'+@str+'%'",
                    new
                    {
                        str = selectString
                    });

                foreach (var item in products)
                {
                    productlist.Add(item);
                }
            }
            return productlist;
        }
        public IEnumerable<Products> FindTopProductByQuantity()
        {
            var productlist = new List<Products>();
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
            {
                var products = connection.Query<Products>(
                    "SELECT TOP 3 p.ProductID FROM Products p " +
                    "INNER JOIN OrderDetails od ON od.ProductID = p.ProductID "+
                    "GROUP BY p.ProductID "+
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
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
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
    }
}
