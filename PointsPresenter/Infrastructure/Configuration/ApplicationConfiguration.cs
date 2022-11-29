using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class ApplicationConfiguration : ConfigurationBase
    {

        public ApplicationConfiguration(IConfiguration configuration) : base(configuration)
        {
        }

        public string WorldMapPath => GetConfigurationSection(nameof(ApplicationConfiguration))["WorldMapPath"];
        public string SvgWidth => GetConfigurationSection(nameof(ApplicationConfiguration))["SvgWidth"];
        public string SvgHeight => GetConfigurationSection(nameof(ApplicationConfiguration))["SvgHeight"];
        public string ClientUrl => GetConfigurationSection(nameof(ApplicationConfiguration))["ClientUrl"];

    }
}
