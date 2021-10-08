using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAESP.Clases
{
    public static class StaticServiceProvider
    {
        static IServiceProvider provider;

        public static void GenerarProveedor(IServiceCollection serviceCollection) 
        {
            provider = serviceCollection.BuildServiceProvider();
        }

        public static T GetService<T>()
        {
            return provider.GetService<T>();
        }
    }
}
