using System.Collections.Generic;

namespace Product.DataAccess.Repository
{
    public interface IProductRepository
    {
        Entity.Product Get(int id);
        List<Entity.Product> GetAll();
        void Remove(int id);
        void Add(Entity.Product entity);
    }
}
