using Infrastructure.Configurations;
using Infrastructure.Extensions;
using Model.Infrastructure;
using Model.Point;
using Model.Point.Handler;
using System.Net.Http.Json;
using System.Text.Json;

namespace Infrastructure.Point
{
    public class PointCreatorHandler : IPointCreatorHandler
    {
        private readonly HttpClient _httpClient;
        private readonly ApplicationConfiguration _appConfiguration;

        public PointCreatorHandler(HttpClient httpClient, ApplicationConfiguration appConfiguration)
        {
            _httpClient = httpClient;
            _appConfiguration = appConfiguration;
        }

        public async Task<IServiceWrapper<IPoint>> SendPointToThirdParty(IPoint point)
        {
            var response = await _httpClient.PostAsJsonAsync(_appConfiguration.ThirdPartyUrl, ParseRequest(point));
            var result = await response.ToResult<IPoint>();
            return result;
        }

        private  string ParseRequest(IPoint point)
        {
            return JsonSerializer.Serialize(point);
        }
    }
}
