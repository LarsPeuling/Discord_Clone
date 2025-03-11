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
        public string Avatar { get; set; }
        public string Status   { get; set; }
        public List<User> Friends { get; set; }

        public User() { }

        public void Register() { }
        public void Login() { }
        public void ResetPassword() { }
        public void UpdateProfile() { }
        public void SendMessage() { }
    }
}
