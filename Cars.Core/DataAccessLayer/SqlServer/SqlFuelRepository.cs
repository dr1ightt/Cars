using Cars.Core.Domain.Entites;
using Cars.Core.Domain.Repositories;
using Microsoft.Data.SqlClient;

namespace Cars.Core.DataAccessLayer.SqlServer
{
    public class SqlFuelRepository : IFuelRepository
    {
        private readonly string _connectionString;

        public void Add(Fuel fuel)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "Insert onto Fuel(@type)";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("name", fuel.Type);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);

            const string query = "Delete from fuel where id = @Id";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
        }
        public void Update(Fuel fuel)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "Update fuel set type = @type where id = @id";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", fuel.Id);
            cmd.Parameters.AddWithValue("type", fuel.Type);

            cmd.ExecuteNonQuery();
        }

        public Fuel Get(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "select * from fuel where id = @Id";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("id", id);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return Mapper.Map(reader);
            }

            return null;
        }

        public List<Fuel> Get()
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "select * from fuel";

            SqlCommand cmd = new SqlCommand(query, connection);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Fuel> result = new List<Fuel>();

            while (reader.Read())
            {
                Fuel fuel = Mapper.Map(reader);
                result.Add(fuel);
            }

            return result;
        }

    }
}
