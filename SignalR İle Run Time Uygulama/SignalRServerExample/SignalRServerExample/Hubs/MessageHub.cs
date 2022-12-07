using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRServerExample.Hubs
{
    public class MessageHub : Hub
    {
        //public async Task SendMessageAsync(string message, IEnumerable<string> connectionIds)
        public async Task SendMessageAsync(string message, string groupName, IEnumerable<string> connectionIds)
        //public async Task SendMessageAsync(string message, IEnumerable<string> groups)
        {
            #region Caller
            //Sadece Server'a bildirim gönderen client'la iletişim kurar. Yani kendi kendine mesaj yollarsın.
            //await Clients.Caller.SendAsync("receiveMessage", message);
            #endregion
            #region All
            //Server'a bağlı olan tüm client'larla iletişim kurar.
            //await Clients.All.SendAsync("receiveMessage", message);
            #endregion
            #region Other
            //Sadece server'a bildirim gönderen client dışında Server'a bağlı olan tüm client'lara mesaj gönderir. 
            //Gönderenin dışında diğerlerine iletilecektir.
            //await Clients.Others.SendAsync("receiveMessage", message);
            #endregion

            #region Hub Clients Metotları
            //Özelleştirilmiş davranış sergilememizi sağlarlar.
            //Hedef client'lara mesaj gönderebilmek. Ya da hedef olanların dışındakilere mesaj gönderebilmek, eleyebilmek, belirli gruplara mesaj gönderebilmek bunun gibi filtreleme işlemeleri yapmamızı sağlarlar.
            #region AllExcept
            //Belirtilen client'lar hariç Server'a bağlı olan tüm client'lara bildiri de bulunur.
            //await Clients.AllExcept(connectionIds).SendAsync("receiveMessage",message);
            #endregion
            #region Client
            //Server'a bağlı olan client'lar arasından sadece belirli bir client'a bildiri de bulunmayı gerçekleştirebilmekteyiz.
            //await Clients.Client(connectionIds.First()).SendAsync("receiveMessage", message);  
            #endregion
            #region Clients
            //Server'a bağlı olan client'lar arasından sadece belirlilediğimiz client'lara bildiri de bulunmayı gerçekleştirebilmekteyiz.
            //AllExcept'in tam tersi görev görür.
            //await Clients.Clients(connectionIds).SendAsync("receiveMessage", message);
            #endregion
            #region Group
            //belirtilen gruptaki tüm client'lara bildiride bulunan bir fonksiyondur.
            //Önce gruplar oluşturulmalı ve ardından client'lar gruplara subscribe olmalıdır.
            //await Clients.Group(groupName).SendAsync("receiveMessage",message);

            #endregion
            #region GroupExcept
            //Belirtilen gruptaki, belirtilen client'lar dışındaki tümmmm client'lara mesaj iletmemizi sağlayan bir fonksiyondur.
            //await Clients.GroupExcept(groupName,connectionIds).SendAsync("receiveMessage", message);
            #endregion
            #region Groups
            //Birden çok gruptaki client'lara bildiride bulunmamızı sağlayan fonksiyondur.
            //await Clients.Groups(groups).SendAsync("receiveMessage", message); 
            #endregion
            #region OthersInGroup
            //Bildiri de bulunan client haricindeki gruptaki diğer tüm client'lara mesajı ileten bir fonksiyondur.
            //İletiyi gönderen client'e mesajı göndermez.
            //await Clients.OthersInGroup(groupName).SendAsync("receiveMessage",message);
            #endregion
            #region User
            //Authentication olan kullanıcıyla ilgili tüm client'lara bildiride bulunmamızı sağlayan fonksiyondur.
            #endregion
            #region Users
            //Authentication olan kullanıcılarla ilgili tüm client'lara bildiride bulunmamızı sağlayan fonksiyondur.
            #endregion
            #endregion

        }
        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);
        }
        public async Task addGroup(string connectionId, string groupName)
        {
            await Groups.AddToGroupAsync(connectionId, groupName);
        }
    }
}
