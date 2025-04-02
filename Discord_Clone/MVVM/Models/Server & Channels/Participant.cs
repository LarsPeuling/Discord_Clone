using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Discord_Clone.Data;

namespace Discord_Clone.Models
{
    public class Participant
    {
        public int Id { get; set; } //Same as User Id
        public User User{ get; set; }
        public Role Role{ get; set; }
        public string UserName { get; set; }

        public ObservableCollection<Message> Messages { get; set; }
        public string LastMessage => Messages.Last().Text;

        public Participant() { }

        public Participant(int id, User user, Role role, string username)
        {
            Id = id;
            User = user;
            Role = role;
            UserName = username;

        }

        DataAccessLayer dal = new DataAccessLayer();

        public Participant GetParticipant(int id)
        {
            return dal.GetParticipant(id);
        }

        public List<Participant> GetParticipants()
        {
            return dal.GetParticipants();
        }


       /* public Message SendMessage(Channel channelName, Message message)
        {
            List<Message> messages = new List<Message>();
            messages.Add(message);
            return message;
        }*/
    }
}
