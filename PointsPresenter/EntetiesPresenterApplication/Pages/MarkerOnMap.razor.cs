using Infrastructure.Configuration;
using Microsoft.AspNetCore.Components;

namespace EntetiesPresenterApplication.Pages
{
    public partial class MarkerOnMap
    {
        [Inject]
        public ShapeConfiguration ShapeConfiguration { get; set; }
        [Parameter] public double XPoint { get; set; }
        [Parameter] public double YPoint { get; set; }
        [Parameter] public string Description { get; set; }

    }
}
