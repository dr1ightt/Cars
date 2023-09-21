using Cars.Core.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Core.Domain.Repositories
{
    public interface IMarkCarRepository
    {
        void Add(MarkCar markCar);
        void Delete(int id);
        MarkCar Get (int id);
        MarkCar GetByMarkId(int id);
        MarkCar GetByCarId(int id);
        List<MarkCar> Get();
    }
}
