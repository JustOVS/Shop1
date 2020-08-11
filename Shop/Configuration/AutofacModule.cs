using Autofac;
using Shop.Data;

namespace Shop.API.Configuration
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ShopRepository>().As<IShopRepository>();

        }
    }
}
