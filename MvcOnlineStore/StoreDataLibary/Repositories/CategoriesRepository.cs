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
    public class CategoriesRepository
    {
        string serviceIP = "192.168.40.21";
        public void Create(Categories model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");
            var sql = "INSERT INTO Categories VALUES(@CategoryID, @CategoryName)";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@PaymentMethodID", model.CategoryID);
            command.Parameters.AddWithValue("@PaymentMethod", model.CategoryName);

            connection.Open();//連線打開
            command.ExecuteNonQuery();//執行指令
            connection.Close();//關閉結束
        }
        public void Update(Categories model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");
            var sql = "UPRATE Categories SET @CategoryName WHERE CategoryID = @id";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", model.CategoryID);
            command.Parameters.AddWithValue("@PaymentMethod", model.CategoryName);

            connection.Open();//連線打開
            command.ExecuteNonQuery();//執行指令
            connection.Close();//關閉結束
        }
        public void Delete(Categories model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");
            var sql = "Delete From Categories WHERE CategoryID = @id";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@id", model.CategoryID);
            connection.Open();//連線打開
            command.ExecuteNonQuery();//執行指令
            connection.Close();//關閉結束
        }
        public Categories FindById(int CategoryID)
        //單筆資料查詢
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");
            var sql = "SELECT * FROM Categories WHERE CategoryID = @id";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@id", CategoryID);

            var result = command.ExecuteScalar();//純量值
            //如果查詢資料是NULL的話
            //if (result == DBNull.Value)
            connection.Open();

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var properties = typeof(Categories).GetProperties();
            Categories categories = null;

            while (reader.Read())
            {
                categories = new Categories();
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    var fieldName = reader.GetName(i);
                    var property = properties.FirstOrDefault(p => p.Name == fieldName);
                    if (property == null)
                        continue;

                    if (!reader.IsDBNull(i))
                        property.SetValue(categories, reader.GetValue(i));
                }
            }

            reader.Close();
            return categories;
        }
        public IEnumerable<Categories> GetAll()
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");

            var sql = "SELECT * FROM Categories";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();

            var reader = command.ExecuteReader();
            var categorylist = new List<Categories>();

            while (reader.Read())
            {
                var category = new Categories();
                category.CategoryID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("CategoryID")));
                category.CategoryName = reader.GetValue(reader.GetOrdinal("CategoryName")).ToString();
            }

            reader.Close();

            return categorylist;
        }
    }
}
