using Autofac;
using Tekton.ECommerce.Domain.ICommand.ISQLServer.Core;

using Tekton.ECommerce.Domain.IQuery.ISQLServer.Core;
using Tekton.ECommerce.SQLServer.DB.Command.Core;
using Tekton.ECommerce.SQLServer.DB.Query.Core;

namespace Tekton.ECommerce.Api.Core.Infrastructura.AutofacModules
{
    public class MediatorModule : Autofac.Module
    {
        public static IConfiguration configuration;

        public MediatorModule(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            string connectionString = configuration.GetSection("ConnectionStrings:SQLDBConnection").Value;
            
            // BEGIN Core

            builder.RegisterType<CoreQuery>().As<ICoreQuery>().WithParameter("connectionString", connectionString)
               .InstancePerLifetimeScope();
            builder.RegisterType<CoreCommand>().As<ICoreCommand>().WithParameter("connectionString", connectionString)
               .InstancePerLifetimeScope();

            builder.RegisterType<CategoryQuery>().As<ICategoryQuery>().WithParameter("connectionString", connectionString)
               .InstancePerLifetimeScope();
            builder.RegisterType<CategoryCommand>().As<ICategoryCommand>().WithParameter("connectionString", connectionString)
               .InstancePerLifetimeScope();

            builder.RegisterType<ProductQuery>().As<IProductQuery>().WithParameter("connectionString", connectionString)
               .InstancePerLifetimeScope();
            builder.RegisterType<ProductCommand>().As<IProductCommand>().WithParameter("connectionString", connectionString)
               .InstancePerLifetimeScope();

            // BEGIN Core



        }
    }
}