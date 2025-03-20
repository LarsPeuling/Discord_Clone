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
    }
}
