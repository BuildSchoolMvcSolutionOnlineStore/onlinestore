using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.MvcSolution.OnlineStore.Models.Repositories
{
    public class ManagersRepository
    {
        
        public void Create(Managers model)
        {
            SqlConnection connection = new SqlConnection(SqlConnectionString.ConnectionString);
            var sql = "INSERT INTO Managers VALUES(@ManagerID,@ManagerName,@ManagerPassword,@ManagerMail)";

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ManagerID", model.ManagerID);
            command.Parameters.AddWithValue("@ManagerName", model.ManagerName);
            command.Parameters.AddWithValue("@ManagerPassword", model.ManagerPassword);
            command.Parameters.AddWithValue("@ManagerMail", model.ManagerMail);

            connection.Open();//連線打開
            command.ExecuteNonQuery();//執行指令
            connection.Close();//關閉結束
        }

        public void Update(Managers model)
        {
            SqlConnection connection = new SqlConnection(SqlConnectionString.ConnectionString);
            var sql = "UPRATE Managers SET @ManagerName,@ManagerPassword,@ManagerMail WHERE ManagerID=@id";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", model.ManagerID);
            command.Parameters.AddWithValue("@ManagerName", model.ManagerName);
            command.Parameters.AddWithValue("@ManagerPassword", model.ManagerPassword);
            command.Parameters.AddWithValue("@ManagerMail", model.ManagerMail);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void Delete(Managers model)
        {
            SqlConnection connection = new SqlConnection(SqlConnectionString.ConnectionString);
            var sql = "Delete FROM Managers WHERE ManagerID=@id";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@id", model.ManagerID);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public Managers FindById(string ManagerID)
        {
            SqlConnection connection = new SqlConnection(SqlConnectionString.ConnectionString);
            var sql = "SELECT * FROM Managers WHERE ManagerID=@id";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", ManagerID);
            
            connection.Open();
            var reader = command.ExecuteReader();
            var properties = typeof(Managers).GetProperties();
            Managers manager = null;

            while (reader.Read())
            {
                manager = DbReaderModelBinder<Managers>.Bind(reader);
                //for(var i=0;i<reader.FieldCount;i++)
                //{
                //    var fieldName = reader.GetName(i);
                //    var property = properties.FirstOrDefault(p => p.Name == fieldName);
                //    if (property == null)
                //        continue;

                //    if(!reader.IsDBNull(i))
                //    property.SetValue(Managers, reader.GetValue(i));

                //}
            }
            reader.Close();
            return manager;
        }
        public IEnumerable<Managers> GetAll()
        {
            SqlConnection connection = new SqlConnection(SqlConnectionString.ConnectionString);
            var sql = "SELECT * FROM Managers";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            var reader = command.ExecuteReader();
            var managerslist = new List<Managers>();
            Managers manager = null;
            while (reader.Read())
            {
                manager = DbReaderModelBinder<Managers>.Bind(reader);
                managerslist.Add(manager);
            }
            reader.Close();
            return managerslist;

        }






    }
}
