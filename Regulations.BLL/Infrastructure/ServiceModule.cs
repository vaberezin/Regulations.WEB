using System;
using System.Collections.Generic;
using System.Text;
using Regulations.DAL.Interfaces;
using Regulations.DAL.Repositories;
using Ninject.Modules;

namespace Regulations.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
