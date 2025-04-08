using Discord_Clone.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord_Clone.Models.Server___Channels
{
    public class Server
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Channel> Channels { get; set; }
        public string ImageSource { get; set; } = "/Icons/server.png";

        public string InviteLink { get; set; }


        public Server() { }

        DataAccessLayer dal = new DataAccessLayer();
        
        public Server GetServerByServerName(string serverName)
        {
            return dal.GetServerByServerName(serverName);
        }

        public List<Server> GetServers()
        {
            return dal.GetServers();
        }
    }
}
