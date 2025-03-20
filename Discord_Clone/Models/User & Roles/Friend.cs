using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord_Clone.Models
{
    public class Friend
    {
        public int Id { get; set; }
        public User FriendedUser { get; set; }
    }
}
