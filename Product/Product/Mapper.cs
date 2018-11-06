using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Product.RequestModels;

namespace Product
{
    public static class Mapper
    {
        //Mapper from the RestApi Layer to the Service Layer
        public static Service.Model.Product MapRequestModelToModel(ProductPost postedProduct)
        {
            if (postedProduct == null)
                return null;

            return new Service.Model.Product()
            {
                Id = postedProduct.Id,
                Description = postedProduct.Description,
                Name = postedProduct.Name,
                Price = postedProduct.Price,
                Is4G = postedProduct.Is4G,
                Weight = postedProduct.Weight
            };
        }

    }
}