﻿using Cars.Core.Domain.Entites;
using Cars.Core.Domain.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Core.DataAccessLayer.SqlServer
{
    public class SqlMarkRepository : IMarkRepository
    {
        private readonly string _connectionString;
        private string connectionString;

        public SqlMarkRepository(string connectionString)
        {
            this.connectionString = _connectionString;
        }

        
        public void Add(Mark mark)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "Insert onto Mark(@Id)";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", mark.Id);
            cmd.Parameters.AddWithValue("name", mark.Name);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);

            const string query = "Delete from mark where id = @Id";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
        }
        public void Update(Mark mark)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "Update mark set type = @type where id = @id";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", mark.Id);
            cmd.Parameters.AddWithValue("name", mark.Name);

            cmd.ExecuteNonQuery();
        }

        public Mark Get(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "select * from mark where id = @Id";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("id", id);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return Mapper.MapMark(reader);
            }

            return null;
        }

        public List<Mark> Get()
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "select * from mark";

            SqlCommand cmd = new SqlCommand(query, connection);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Mark> result = new List<Mark>();

            while (reader.Read())
            {
                Mark mark = Mapper.MapMark(reader);
                result.Add(mark);
            }

            return result;
        }

    }
}
