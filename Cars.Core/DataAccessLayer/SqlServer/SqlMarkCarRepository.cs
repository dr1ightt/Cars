using Cars.Core.Domain.Entites;
using Cars.Core.Domain.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Core.DataAccessLayer.SqlServer
{
    public class SqlMarkCarRepository : IMarkCarRepository
    {
        private readonly string _connectionString;

        public SqlMarkCarRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(MarkCar markCar)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "insert into markcars(carid, markid) values(@carid, @markid)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("markid", markCar.Id);
            cmd.Parameters.AddWithValue("carid", markCar.Id);

            cmd.ExecuteNonQuery();

        }

        public void Delete(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "delete from markcar where id = @id";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("id", id);

        }

        public MarkCar Get(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = ""
        }

        public List<MarkCar> Get()
        {
            throw new NotImplementedException();
        }

        public MarkCar GetByCarId(int id)
        {
            throw new NotImplementedException();
        }

        public MarkCar GetByMarkId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
