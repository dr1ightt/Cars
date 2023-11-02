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
    public class SqlCarRepository : ICarRepository
    {
        private readonly string _connectionString;
        private string connectionString;

        public SqlCarRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(Car car)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "Insert onto Car(@Id)";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("name", car.Id);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);

            const string query = "Delete from car where id = @Id";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
        }


        public void Update(Car car)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "Update car set type = @type where id = @id";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", car.Id);
            cmd.Parameters.AddWithValue("name", car.Name);
            cmd.Parameters.AddWithValue("price", car.Price);
            cmd.Parameters.AddWithValue("category", car.Category);

            cmd.ExecuteNonQuery();
        }
        public Car Get(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "select * from car where id = @Id";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("id", id);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return Mapper.MapCar(reader);
            }

            return null;
        }

        public List<Car> Get()
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "select * from car";

            SqlCommand cmd = new SqlCommand(query, connection);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Car> result = new List<Car>();

            while (reader.Read())
            {
                Car car = Mapper.MapCar(reader);
                result.Add(car);
            }

            return result;
        }
    }
}
