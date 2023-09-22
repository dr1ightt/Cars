using Cars.Core.Domain.Entites;

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
