using Microsoft.AspNetCore.SignalR;
using SignalRServerExample.Hubs;
using System.Threading.Tasks;

namespace SignalRServerExample.Business
{
    public class MyBusiness
    {
        private readonly IHubContext<MyHub> _hubContext;

        public MyBusiness(IHubContext<MyHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendMessageAsync(string message)
        {
            //Ekstra işlemler....
            await _hubContext.Clients.All.SendAsync("receiveMessage", message);
        }
    }
}
