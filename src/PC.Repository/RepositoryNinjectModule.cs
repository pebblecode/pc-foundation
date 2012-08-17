using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PebbleCode.Framework.IoC;
using System.Reflection;
using PebbleCode.Framework;

namespace PebbleCode.Repository
{
    /// <summary>
    /// Sets up Ninject bindings for mocking out all database repositories
    /// </summary>
    public abstract class BaseRepositoryNinjectModule : BaseNinjectModule
    {
        string _productRepositoryAssembly;
        
        protected BaseRepositoryNinjectModule(string productRepositoryAssembly)
        {
            _productRepositoryAssembly = productRepositoryAssembly;
        }

        public override void Load()
        {
            //Mock each of the repositories
            Assembly repos = Assembly.Load(_productRepositoryAssembly);
            repos.GetTypes()
                .Where(type => typeof(EntityRepository).IsAssignableFrom(type) && !type.IsAbstract)
                .ForEach(repoType => Bind(repoType).ToMockSingleton());
        }
    }
}
