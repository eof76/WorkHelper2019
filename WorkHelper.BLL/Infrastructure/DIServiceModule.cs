using Ninject.Modules;
using WorkHelper.DAL;
using WorkHelper.DAL.Interfaces;

namespace WorkHelper.BLL.Infrastructure
{
    public class DIServiceModule : NinjectModule
    {
        private string connectionString;

        public DIServiceModule(string connection)
        {
            connectionString = connection;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
