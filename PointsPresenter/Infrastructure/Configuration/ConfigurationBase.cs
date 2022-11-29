using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public abstract class ConfigurationBase
    {
        protected readonly IConfiguration _configuration;

        public ConfigurationBase(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected virtual IConfigurationSection GetConfigurationSection(string sectionName)
        {
            return _configuration.GetSection(sectionName);
        }
    }
}
