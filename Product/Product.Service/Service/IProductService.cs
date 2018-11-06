using System.Collections.Generic;

namespace Product.Service.Service
{
    public interface IProductService
    {
        Model.Product GetProduct(int id);
        List<Model.ProductInfo> GetAllProductInfos();
        void AddProduct(Model.Product product);
        void DeleteProduct(int id);
    }
}
