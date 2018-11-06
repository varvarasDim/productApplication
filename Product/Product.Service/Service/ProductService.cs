using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Product.DataAccess.Repository;

namespace Product.Service.Service
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Model.Product GetProduct(int id)
        {
            //A Mapper is used from Entity to Model
            Model.Product product = Mapper.MapEntityToModel(_productRepository.Get(id));
            return product;
        }

        public List<Model.ProductInfo> GetAllProductInfos()
        {
            //A Mapper is used from Entity to ModelLight
            var allEntityProducts = _productRepository.GetAll();
            var allModelProductInfos = allEntityProducts.Select(Mapper.MapEntityToModelLight);
            return allModelProductInfos.ToList();
        }

        public void AddProduct(Model.Product product)
        {
            //A Mapper is used from Model to Entity
            _productRepository.Add(Mapper.MapModelToEntity(product));
        }

        public void DeleteProduct(int id)
        {
            _productRepository.Remove(id);
        }
    }
}
