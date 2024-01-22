using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract;
public interface ICarDal : IEntityRepository<Car, int>
{
    // IEntityRepository<Car, int> kalıtımının örnek canlandırması:
    //public IList<Car> GetList();
    //public Car? GetById(int id);
    //public void Add(Car entity);
    //public void Update(Car entity);
    //public void Delete(Car entity);
}