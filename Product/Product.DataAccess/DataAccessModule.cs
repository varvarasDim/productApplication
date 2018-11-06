using Autofac;
using Product.DataAccess.Repository;

namespace Product.DataAccess
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //SingleInstance lifecycle to persist the changes while it runs
            builder.RegisterType<ProductRepository>().As<IProductRepository>().SingleInstance();
        }
    }
}
