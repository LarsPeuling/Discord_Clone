using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord_Clone.Data;

namespace Discord_Clone.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Participant Sender { get; set; }
        public DateTime Time { get; set; }
        public bool IsNativeOrigin { get; set; }
        public bool? FirstMessage { get; set; }
        public int ChannelId { get; set; }

        public Message() { }

        public Message(string text, Participant sender, DateTime time, bool isNativeOrigin, bool firstMessage, int channelId)
        {
            Text = text;
            Sender = sender;
            Time = time;
            IsNativeOrigin = isNativeOrigin;
            FirstMessage = firstMessage;
            ChannelId = channelId;
        }


        DataAccessLayer dal = new DataAccessLayer();

        public List<Message> GetMessagesByChannelId(int channelId)
        {
            return dal.GetMessagesByChannelId(channelId);
        }

        public void SendMessage(Message message)
        {
            dal.SendMessage(message);
        }
    }
}
