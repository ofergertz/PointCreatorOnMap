using BusinessComponents;
using BusinessComponents.Point;
using EntetiesPresenterApplication.Extensions;
using Infrastructure.Configuration;
using Infrastructure.Constatns;
using Infrastructure.Mappers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.SignalR.Client;
using Model.Point;
using static MudBlazor.Icons;

namespace EntetiesPresenterApplication.Pages
{
    public partial class Index
    {
        [Inject]
        public ApplicationConfiguration ApplicationConfiguration { get; set; }

        [Inject]
        public CacheConfiguration CacheConfiguration { get; set; }

        [CascadingParameter] private HubConnection hubConnection { get; set; }

        List<IMapPoint> MapPoints = new();     

        protected override async Task OnInitializedAsync()
        {
            hubConnection = hubConnection.TryInitialize(_navigationManager, ApplicationConfiguration.ClientUrl);
            if (hubConnection.State == HubConnectionState.Disconnected)
            {
                await hubConnection.StartAsync();
            }

            hubConnection.On<string>("PointsCreate", async (message) =>
            {
                UpdatePointInCache(message);

                _navigationManager.NavigateTo("/", true);
            });

            MapPoints = _cacheManager.GetData<IMapPoint>(CacheConfiguration.CacheKey);
        }

        private void UpdatePointInCache(string message)
        {
            var mapper = _applicationResolver.Resolve<IMapper<string, IMapPoint>>();
            var point = mapper.Map(message);
            _cacheManager.AddOrUpdate(_cacheConfiguration.CacheKey, point);
        }

        private string GetImageUrl()
        {
            return ApplicationConfiguration.WorldMapPath;
        }

        private void ClearMap()
        {
            MapPoints.Clear();
            _cacheManager.AddOrUpdate(CacheConfiguration.CacheKey, new List<IMapPoint>());
            StateHasChanged();
        }
        
        public async ValueTask DisposeAsync()
        {
            if(hubConnection != null)
                await hubConnection.DisposeAsync();
        }
    }
}
