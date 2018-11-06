namespace Product.Service
{
    public static class Mapper 
    {
        //Mapper from the DataAccess Layer to the Service Layer
        public static Model.Product MapEntityToModel(DataAccess.Entity.Product entity)
        {
            if (entity == null)
                return null;

            return new Model.Product()
            {
                Id = entity.Id,
                Description = entity.Description,
                Name = entity.Name,
                Price = entity.Price,
                Is4G = entity.Is4G,
                Weight = entity.Weight
            };
        }

        public static Model.ProductInfo MapEntityToModelLight(DataAccess.Entity.Product entity)
        {
            if (entity == null)
                return null;

            return new Model.ProductInfo()
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }

        public static DataAccess.Entity.Product MapModelToEntity(Model.Product product)
        {
            if (product == null)
                return null;

            return new DataAccess.Entity.Product()
            {
                Id = product.Id,
                Description = product.Description,
                Name = product.Name,
                Price = product.Price,
                Is4G = product.Is4G,
                Weight = product.Weight
            };
        }
    }
}
