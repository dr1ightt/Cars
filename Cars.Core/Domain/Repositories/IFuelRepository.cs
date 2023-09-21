using Cars.Core.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Core.Domain.Repositories
{
    public interface IFuelRepository
    {
        void Add(Fuel fuel);
        void Update(Fuel fuel);
        void Delete(int id);

        Fuel Get(int id);
        List<Fuel> Get();
    }
}
