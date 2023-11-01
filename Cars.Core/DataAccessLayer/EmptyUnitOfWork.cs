using Cars.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Core.DataAccessLayer
{
    public class EmptyUnitOfWork : IUnitOfWork
    {
        public IMarkCarRepository markCarRepository => throw new NotImplementedException();

        public IFuelRepository FuelRepository => throw new NotImplementedException();

        public ICarRepository CarRepository => throw new NotImplementedException();

        public IMarkRepository markRepository => throw new NotImplementedException();

        public bool IsOnline()
        {
            return false;
        }
    }
}
