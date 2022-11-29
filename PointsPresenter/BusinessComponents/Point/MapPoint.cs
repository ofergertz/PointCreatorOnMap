using Model;
using Model.Point;

namespace BusinessComponents.Point
{
    public class MapPoint : IMapPoint
    {
        public double XPoint { get; set; }

        public double YPoint { get; set; }

        public string Name { get; set; }
    }
}