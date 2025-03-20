using Discord_Clone.Models.User___Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord_Clone.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Avatar Avatar { get; set; }
        public Status Status { get; set; }
        public List<Friend> Friends { get; set; }
        public Tag Tag { get; set; }

        public User() { }

        public void Register() { }
        public void Login() { }
        public void ResetPassword() { }
        public void UpdateProfile() { }
        public void SendMessage() { }
    }
}
