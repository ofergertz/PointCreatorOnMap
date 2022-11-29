using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Point
{
    public interface IPoint
    {
        double XPoint { get; set; }
        double YPoint { get; set; }
        string Name { get; set; }
    }
}
