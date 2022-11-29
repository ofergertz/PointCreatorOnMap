using BusinessComponents.Point;
using Model.Point;
using Model.Serialization;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mappers
{
    public class PointMapperDto : IMapper<string, IMapPoint>
    {
        private readonly IJsonSerializer _jsonSerializer;

        public PointMapperDto(IJsonSerializer jsonSerializer)
        {
            _jsonSerializer = jsonSerializer;
        }

        public IMapPoint Map(string source)
        {
            return _jsonSerializer.Deserialize<MapPoint>(source);
        }
    }
}
