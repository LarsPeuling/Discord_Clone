using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord_Clone.Models
{
    public class Friend : User
    {
        public int Id { get; set; }
        public User FriendedUser { get; set; }

        public Friend() { }
        //public Friend() : base(int Id, string name, string email, status) { }
    }

}
