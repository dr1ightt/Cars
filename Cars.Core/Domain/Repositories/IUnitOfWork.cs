using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Core.Domain.Repositories
{
    public interface IUnitOfWork
    {
        public IMarkCarRepository markCarRepository { get; }
        public IFuelRepository FuelRepository { get; }
    }
}
