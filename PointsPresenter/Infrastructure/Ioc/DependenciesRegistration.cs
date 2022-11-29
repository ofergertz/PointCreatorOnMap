using BusinessComponents.Point;
using Infrastructure.Cache;
using Infrastructure.Configuration;
using Infrastructure.Mappers;
using Infrastructure.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Model.Cache;
using Model.Hub;
using Model.Infrastructure.Ioc;
using Model.Point;
using Model.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Ioc
{
    public static class DependenciesRegistration
    {
        public static void RegisterComponents(this IServiceCollection builder)
        {
            builder.AddTransient<IMapPoint, MapPoint>();
        }
        public static void LoadConfigurations(this IServiceCollection builder)
        {
            builder.AddSingleton<ApplicationConfiguration>().
                    AddSingleton<ShapeConfiguration>().
                    AddSingleton<CacheConfiguration>().
                    AddTransient<IJsonSerializer, NewtonSoftJsonSerializer>().
                    AddTransient<IMapper<string, IMapPoint>, PointMapperDto>().
                    AddSingleton<IApplicationResolver, ApplicationResolver>().
                    //AddTransient<IHubConnection, PointHub>().
                    AddTransient<ICacheManager, CacheManager>();

        }
    }
}
