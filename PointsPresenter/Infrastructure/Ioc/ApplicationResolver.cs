using Microsoft.Extensions.DependencyInjection;
using Model.Cache;
using Model.Infrastructure.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Ioc
{
    public class ApplicationResolver : IApplicationResolver
    {
        private IServiceProvider _serviceProvider;

        public void Init(IServiceProvider ServiceProvider)
        {
            _serviceProvider = ServiceProvider;
        }

        public T Resolve<T>()
        {
            return (T)_serviceProvider.GetService(typeof(T));
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return (IEnumerable<T>)_serviceProvider.GetServices(typeof(T));
        }
    }
}
