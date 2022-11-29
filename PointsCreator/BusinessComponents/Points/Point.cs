using Model.Point;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessComponents.Points
{
    public class Point : IPoint
    {
        public double XPoint { get; set; }

        public double YPoint { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
