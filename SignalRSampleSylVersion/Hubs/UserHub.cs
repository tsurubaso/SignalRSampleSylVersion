using Microsoft.AspNetCore.SignalR;

namespace SignalRSampleSylVersion.Hubs
{
    public class UserHub : Hub 
    {

        public static int TotalViews { get; set; } = 0;

        public static int TotalUsers { get; set; } = 0;

        public override Task OnConnectedAsync()
        {
            TotalUsers++;
             Clients.All.SendAsync("updateTotalUsers", TotalViews).GetAwaiter().GetResult();
            return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            TotalUsers--;
            Clients.All.SendAsync("updateTotalUsers", TotalViews).GetAwaiter().GetResult();
            return base.OnDisconnectedAsync(exception);
        }

        public async Task NewWindowLoaded()
        {
            TotalViews++;
            await Clients.All.SendAsync("updateTotalUsers", TotalViews);




        }

    }
}
