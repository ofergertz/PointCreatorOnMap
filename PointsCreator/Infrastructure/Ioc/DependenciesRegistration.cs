using BusinessComponents.Points;
using Infrastructure.Configurations;
using Infrastructure.Point;
using Microsoft.Extensions.DependencyInjection;
using Model.Infrastructure.Ioc;
using Model.Point;
using Model.Point.Handler;
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
            builder.AddTransient<IPoint, BusinessComponents.Points.Point>().
                    AddTransient<IPointCreatorHandler, PointCreatorHandler>();
        }

        public static void LoadConfigurations(this IServiceCollection builder)
        {
            builder.AddSingleton<ApplicationConfiguration>().
                    AddSingleton<IApplicationResolver, ApplicationResolver>();
        }
    }
}
