using Infrastructure.Configuration;
using Infrastructure.Mappers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR;
using Model.Cache;
using Model.Hub;
using Model.Infrastructure.Ioc;
using Model.Point;

namespace Infrastructure.Hubs
{
    public class PointHub : Hub, IHubConnection
    {
        //when a user connects to our hub
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public async Task SendMessage(string Message)
        {
            await Clients.All.SendAsync("PointsCreate", Message);
        }
    }
}
