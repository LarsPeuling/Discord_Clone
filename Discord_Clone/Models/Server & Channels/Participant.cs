using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Discord_Clone.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public User User{ get; set; }
        public Role Role{ get; set; }

        public Participant() { }


        public Message SendMessage(Channel channelName, Message message)
        {
            List<Message> messages = new List<Message>();
            messages.Add(message);
            return message;
        }
    }
}
