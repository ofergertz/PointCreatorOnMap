using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class ShapeConfiguration : ConfigurationBase
    {
        public ShapeConfiguration(IConfiguration configuration) :
            base(configuration)
        {
        }

        public int YRadius
        {
            get
            {
                int.TryParse(GetConfigurationSection(nameof(ShapeConfiguration))["YRadius"], out int YRadius);
                return YRadius;
            }
        }
    }
}
