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
        string serviceIP = "192.168.40.21";
        public void Create(Managers model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");
            var sql = "INSERT INTO Managers VALUES(@ManagerID,@ManagerName,@ManagerAccountNumber,@ManagerPassword,@ManagerMail)";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ManagerID", model.ManagerID);
            command.Parameters.AddWithValue("@ManagerName", model.ManagerName);
            command.Parameters.AddWithValue("@ManagerAccountNumber", model.ManagerAccountNumber);
            command.Parameters.AddWithValue("@ManagerPassword", model.ManagerPassword);
            command.Parameters.AddWithValue("@ManagerMail", model.ManagerMail);

            connection.Open();//連線打開
            command.ExecuteNonQuery();//執行指令
            connection.Close();//關閉結束
        }

        public void Update(Managers model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");
            var sql = "UPRATE Managers SET @ManagerName,@ManagerAccountNumber,@ManagerPassword,@ManagerMail WHERE ManagerID=@id";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", model.ManagerID);
            command.Parameters.AddWithValue("@ManagerName", model.ManagerName);
            command.Parameters.AddWithValue("@ManagerAccountNumber", model.ManagerAccountNumber);
            command.Parameters.AddWithValue("@ManagerPassword", model.ManagerPassword);
            command.Parameters.AddWithValue("@ManagerMail", model.ManagerMail);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void Delete(Managers model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");
            var sql = "Delete FROM Managers WHERE ManagerID=@id";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@id", model.ManagerID);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public Managers FindById(int ManagerID)
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");
            var sql = "SELECT * FROM Managers WHERE ManagerID=@id";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", ManagerID);
            var result = command.ExecuteScalar();
            connection.Open();
            var reader = command.ExecuteReader();
            var Managers = new Managers();
            while(reader.Read())
            {
                Managers.ManagerID=Convert.ToInt32(reader.GetValue(reader.GetOrdinal("ManagersID")));
                Managers.ManagerName = reader.GetOrdinal("ManagerName").ToString();
                Managers.ManagerAccountNumber = reader.GetOrdinal("ManagerAccountNumber").ToString();
                Managers.ManagerPassword = reader.GetOrdinal("ManagerPassword").ToString();
                Managers.ManagerMail = reader.GetOrdinal("ManagerMail").ToString();

            }
            reader.Close();
            return Managers;
        }
        public IEnumerable<Managers> GetAll()
        {
            SqlConnection connection = new SqlConnection(
                "Server=" + serviceIP + ";Database=Shopping;User Id=linker;Password = 19960705;");
            var sql = "SELECT * FROM Managers";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            var reader = command.ExecuteReader();
            var managerslist = new List<Managers>();

            while (reader.Read())
            {
                var Managers = new Managers();
                Managers.ManagerID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("ManagersID")));
                Managers.ManagerName = reader.GetOrdinal("ManagerName").ToString();
                Managers.ManagerAccountNumber = reader.GetOrdinal("ManagerAccountNumber").ToString();
                Managers.ManagerPassword = reader.GetOrdinal("ManagerPassword").ToString();
                Managers.ManagerMail = reader.GetOrdinal("ManagerMail").ToString();

            }
            reader.Close();
            return managerslist;

        }

    }
}
