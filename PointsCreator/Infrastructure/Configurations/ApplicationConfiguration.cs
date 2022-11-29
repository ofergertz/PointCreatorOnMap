using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class ApplicationConfiguration : ConfigurationBase
    {
        public ApplicationConfiguration(IConfiguration configuration) : base(configuration)
        {

        }
        public string ThirdPartyUrl => GetConfigurationSection(nameof(ApplicationConfiguration))["ThirdPartyUrl"];
        public string BackgroundImagePath => GetConfigurationSection(nameof(ApplicationConfiguration))["BackgroundImagePath"];

    }
}
