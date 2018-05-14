using Dapper;
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

            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
            {
                connection.Execute(
                "INSERT INTO Managers VALUES(@ManagerID,@ManagerName,@ManagerPassword,@ManagerMail)",
                new
                {
                    ManagerID = model.ManagerID,
                    ManagerName = model.ManagerName,
                    ManagerPassword = model.ManagerPassword,
                    ManagerMail = model.ManagerMail,

                });
            }


        }

        public void Update(Managers model)
        {


            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
            {
                connection.Execute(
                "UPDATE Managers SET " +
                "ManagerName = @ManagerName,ManagerPassword = @ManagerPassword,ManagerMail = @ManagerMail WHERE ManagerID=@id",
                new
                {
                    id = model.ManagerID,
                    ManagerName = model.ManagerName,
                    ManagerPassword = model.ManagerPassword,
                    ManagerMail = model.ManagerMail,

                });
            }

        }
        public void Delete(string ManagerID)
        {
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
            {
                connection.Execute(
                "DELETE FROM Managers WHERE ManagerID = @id",
                new
                {
                    id = ManagerID
                });
            }
        }
        public Managers FindById(string ManagerID)
        {
            Managers manager = null;
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
            {
                var managers = connection.Query<Managers>(
                    "SELECT * FROM Managers WHERE ManagerID = @id",
                    new
                    {
                        id = ManagerID
                    });

                foreach (var item in managers)
                {
                    if (item.ManagerID != null)
                        manager = item;
                }
            }
            return manager;
        }
        public IEnumerable<Managers> GetAll()
        {
            var managerlist = new List<Managers>();
            using (var connection = new SqlConnection(SqlConnectionString.ConnectionString))
            {
                var managers = connection.Query<Managers>(
                    "SELECT * FROM Managers");

                foreach (var item in managers)
                {
                    managerlist.Add(item);
                }
            }
            return managerlist;

        }

    }
}
