using Cars.Core.Domain.Repositories;
using Microsoft.Data.SqlClient;
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
    public class SqlUnitOfWork : IUnitOfWork
    {
        private readonly string _connectionString;

        public SqlUnitOfWork(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IMarkCarRepository markCarRepository => new SqlMarkCarRepository(_connectionString);

        public IFuelRepository FuelRepository => new SqlFuelRepository(_connectionString);

        public ICarRepository CarRepository => throw new NotImplementedException();

        public IMarkRepository markRepository => throw new NotImplementedException();

        public bool IsOnline()
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
