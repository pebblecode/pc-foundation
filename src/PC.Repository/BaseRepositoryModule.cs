using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Modules;
using System.Reflection;

namespace PebbleCode.Repository
{
    public class BaseRepositoryModule : NinjectModule
    {
        public override void Load()
        {
            // For each BindRepository_XXX method, via reflection, call
            foreach (MethodInfo method in
                this.GetType()
                .GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(m => m.Name.StartsWith("BindRepository_")))
            {
                method.Invoke(this, null);
            }
        }
    }
}
