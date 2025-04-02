using Discord_Clone.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord_Clone.Models.Server___Channels
{
    public class Channel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Message> Messages { get; set; }
        public List<Participant> Participants { get; set; }

        public Channel() { }


        DataAccessLayer dal = new DataAccessLayer();
        public List<Channel> GetChannelsByServerId(int serverId)
        {
            return dal.GetChannelsByServerId(serverId);
        }
    }
}
