using Cars.Core.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Core.Domain.Repositories
{
    public interface IMarkRepository
    {
        void Add(Mark mark);
        void Update(Mark mark);
        void Delete(int id);

        Mark Get(int id);
        List<Mark> Get();
    }
}
