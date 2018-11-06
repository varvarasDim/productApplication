using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Product.DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Entity.Product> _productsList;
        public ProductRepository()
        {
            //Imitating that the data is comming from a database or an external service
            _productsList = new List<Entity.Product>
                {
                    new Entity.Product() {Id = 1, Description = "Mobile Phone 1", Name = "Iphone X", Price = 10000, Is4G = true, Weight = 100},
                    new Entity.Product() {Id = 2, Description = "Mobile Phone 2", Name = "Samsung S9", Price = 9000, Is4G = true, Weight = 130},
                    new Entity.Product() {Id = 3, Description = "Mobile Phone 3", Name = "Nokia G5", Price = 3000, Is4G = false, Weight = 120},
                    new Entity.Product() {Id = 4, Description = "Mobile Phone 4", Name = "Alcatel R3", Price = 4000, Is4G = true, Weight = 110},
                    new Entity.Product() {Id = 5, Description = "Mobile Phone 5", Name = "Motorola F4", Price = 8000, Is4G = false, Weight = 90}
                };
        }

        public Entity.Product Get(int id)
        {
            return _productsList.FirstOrDefault(t => t.Id == id);
        }

        public List<Entity.Product> GetAll()
        {
            return _productsList;
        }

        public void Remove(int id)
        {
            var items = _productsList.Where(t => t.Id == id);

            foreach(var item in items.ToList())
            { 
                _productsList.RemoveAt(_productsList.IndexOf(item));
            }
        }

        public void Add(Entity.Product entity)
        {
            _productsList.Add(entity);
        }
    }
}
