using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace webapidapper.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task SendNotification(string sampleMessge)
        {
            await Clients.All.SendAsync("showNotification", sampleMessge);
        }
    }
}
