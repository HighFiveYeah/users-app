using Autofac;
using UserApi.DataAccess;

namespace UserApi.DiModules
{
    public class AppModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(GenericRepository<>)).AsImplementedInterfaces();
            builder
                .RegisterType<AppDbContext>()
                .WithParameter("options", DbContextOptionsFactory.Get())
                .InstancePerLifetimeScope();
        }
    }
}