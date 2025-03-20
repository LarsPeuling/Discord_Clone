using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord_Clone.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Participant Sender { get; set; }
        
        public Message() { }
    }
}
