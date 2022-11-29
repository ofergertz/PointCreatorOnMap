using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Infrastructure.Ioc
{
    public interface IApplicationResolver
    {
        void Init(IServiceProvider serviceProvider);
        IEnumerable<T> ResolveAll<T>();
        T Resolve<T>();
    }
}
