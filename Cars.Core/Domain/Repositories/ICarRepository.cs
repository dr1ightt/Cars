using Cars.Core.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Core.Domain.Repositories
{
    public class ICarRepository
    {
        void Add(Car car);
        void Update(Car car);
        void Delete(int id );

        Car Get(int id);
        List<Car> Get();

    }
}
