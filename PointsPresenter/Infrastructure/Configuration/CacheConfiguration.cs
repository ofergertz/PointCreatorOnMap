using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class CacheConfiguration : ConfigurationBase
    {
        public CacheConfiguration(IConfiguration configuration) : base(configuration)
        {
        }


        public string CacheKey => GetConfigurationSection(nameof(CacheConfiguration))["CacheKey"];       
    }
}
