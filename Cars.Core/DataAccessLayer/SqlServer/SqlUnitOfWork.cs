using Cars.Core.Domain.Repositories;

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
    }
}
