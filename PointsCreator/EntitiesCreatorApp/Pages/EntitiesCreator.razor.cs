using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using BusinessComponents.Points;
using Model.Point;
using MudBlazor;
using Infrastructure.Configurations;
using Microsoft.AspNetCore.SignalR.Client;
using System.Text.Json;
using EntitiesCreatorApp.Extensions;

namespace EntitiesCreatorApp.Pages
{
    public partial class EntitiesCreator
    {
        IPoint model = new Point();

        [Inject]
        public ApplicationConfiguration ApplicationConfiguration { get; set; }

        [CascadingParameter] private HubConnection hubConnection { get; set; }

        protected override async Task OnInitializedAsync()
        {
            hubConnection = hubConnection.TryInitialize(_navigationManager, "https://localhost:7035/pointhub");

            if (hubConnection.State == HubConnectionState.Disconnected)
            {
                StartHubConnection(hubConnection);
            }
        }

        public async Task Send()
        {
            if (hubConnection is not null)
            {
                var serializedMessage = JsonSerializer.Serialize(model);
                await hubConnection.SendAsync("SendMessage", serializedMessage);
            }
        }

        private async Task OnValidSubmit(EditContext context)
        {
            await Send();
            _snackBar.Add("Point was sent successfully", Severity.Success);
        }

        private string GetImageUrl()
        {
            return ApplicationConfiguration.BackgroundImagePath;
        }

        private async Task StartHubConnection(HubConnection hubConnection)
        {
            try
            {
                await hubConnection.StartAsync();
            }
            catch (Exception ex)
            {
                _snackBar.Add("Please run server first and than refresh the page", Severity.Error);
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (hubConnection != null)
                await hubConnection.DisposeAsync();
        }
    }
}
