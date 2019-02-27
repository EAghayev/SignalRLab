using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalRLab
{
    public class NotificationHub : Hub
    {
        static Dictionary<string, string> Users = new Dictionary<string, string>();

        public void Hello()
        {
            Clients.Others.hi();
        }

        public override Task OnConnected()
        {
            string FullName= this.Context.QueryString["fullName"];

            return base.OnConnected();
        }


        public override Task OnDisconnected(bool stopCalled)
        {
            string FullName = Users.FirstOrDefault(u => u.Key == Context.ConnectionId).Value;
            Clients.Others.ShowDiss(FullName);
            return base.OnDisconnected(stopCalled);
        }

        public void Enter(string Name,string Surname)
        {
            string FullName = Name + " " + Surname;
            Clients.Others.ShowUsers(Name, Surname);
            Users.Add(Context.ConnectionId, FullName);
        }
    }
}