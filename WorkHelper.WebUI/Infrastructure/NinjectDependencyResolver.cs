using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WorkHelper.BLL.Infrastructure;
using WorkHelper.BLL.Interfaces;
using WorkHelper.BLL.Services;

namespace WorkHelper.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver()
        {
            var modules = new INinjectModule[] { new DIServiceModule("EFDbConnection") };
            kernel = new StandardKernel(modules);
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IEmployeeService>().To<EmployeeService>();
        }
    }
}