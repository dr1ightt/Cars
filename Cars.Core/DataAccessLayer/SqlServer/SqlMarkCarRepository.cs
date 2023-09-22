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

            const string query = @"select cm.Id, cm.CarId, c.Name CarName, c.Price, c.Category, cm.MarkId, c.Name MarkName
            from MarkCars cm
            join Cars c on c.Id = cm.CarId
            join Marks m on m.Id = cm.MarkId
            where cm.id = @id";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("id", id);


            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return Mapper.MapMarkCar(reader);
            }
            return null;
        }

        public List<MarkCar> Get()
        {
            throw new NotImplementedException();
        }

        public List<MarkCar> GetByCarId(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = @"select cm.Id, cm.CarId, c.Name CarName, c.Price, c.Category, cm.MarkId, b.Name MarkName
            from MarkCars cm
            join Cars c on c.Id = cm.CarId
            join Marks m on m.Id = cm.MarkId
            where c.id = @id";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("id", id);


            SqlDataReader reader = cmd.ExecuteReader();

            List<MarkCar> markCars = new List<MarkCar>();

            while (reader.Read())
            {
                MarkCar cm = Mapper.MapMarkCar(reader);

                markCars.Add(cm);
            }

            return markCars;
        }

        public List<MarkCar> GetByMarkId(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = @"select cm.Id, cm.CarId, c.Name CarName, c.Price, c.Category, cm.MarkId, b.Name MarkName
            from MarkCars cm
            join Cars c on c.Id = cm.CarId
            join Marks m on m.Id = cm.MarkId
            where m.id = @id";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("id", id);


            SqlDataReader reader = cmd.ExecuteReader();

            List<MarkCar> markCars = new List<MarkCar>();

            while (reader.Read())
            {
                MarkCar cm = Mapper.MapMarkCar(reader);

                markCars.Add(cm);
            }

            return markCars;
        }
    }
}
