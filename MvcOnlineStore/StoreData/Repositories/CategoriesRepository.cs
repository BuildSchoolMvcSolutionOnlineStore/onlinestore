using Dapper;
using StoreData.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Repositories
{
    public class CategoriesRepository
    {
        public void Create(Categories model)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                connection.Execute("INSERT INTO Categories VALUES(@CategoryID, @CategoryName)",model);
            }
        }
        public void Update(Categories model)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                connection.Execute("UPDATE Categories SET CategoryName = @CategoryName WHERE CategoryID = @CategoryID",model);
            }
        }
        public void Delete(int CategoryID)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                connection.Execute("Delete From Categories WHERE CategoryID = @id",new {id = CategoryID });
            }
        }
        public Categories FindById(int CategoryID)
        //單筆資料查詢
        {
            Categories category = null;
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                var orders =  connection.Query<Categories>("SELECT * FROM Categories WHERE CategoryID = @id",
                    new {id = CategoryID });

                foreach (var item in orders)
                {
                    if (item.CategoryID != 0)
                        category = item;
                }
                return category;
            }
        }
       
            public IEnumerable<Categories> GetAll()
            {
                var categorylist = new List<Categories>();
                using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
                {
                    var category = connection.Query<Categories>(
                        "SELECT * FROM Categories");

                    foreach (var item in category)
                    {
                    categorylist.Add(item);
                    }
                }
                return categorylist;
            }
        

        public int FindLastCategoryID()
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString()))
            {
                var categories = connection.Query<int>(
                    "SELECT TOP 1 CategoryID FROM Categories ORDER BY CategoryID DESC");
                return categories.FirstOrDefault();
            }

        }
    }
}
