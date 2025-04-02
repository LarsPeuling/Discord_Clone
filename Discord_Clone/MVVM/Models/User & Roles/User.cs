using Discord_Clone.Models.User___Roles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public string Status { get; set; }
        public List<User> Friends { get; set; }
        public string Tag { get; set; }

        public ObservableCollection<Message> Messages { get; set; }
        public string LastMessage => Messages.Last().Text;

        public User() { }
        public User(int id, string name, string email, string avatar, string status, List<User> friends, string tag)
        {
            Id = id;
            Name = name;
            Email = email;
            Avatar = avatar;
            Status = status;
            Friends = friends;
            Tag = tag;
        }

        public void Register() { }
        public void Login() { }
        public void ResetPassword() { }
        public void UpdateProfile() { }
        public void SendMessage() { }
    }
}
