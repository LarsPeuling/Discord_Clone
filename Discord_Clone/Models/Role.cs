using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord_Clone.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public bool ViewChannel { get; set; }
        public bool ManageChannel { get; set; }
        public bool ManageRole { get; set; }

        public bool ViewAuditLog { get; set; }
        public bool ManageServer { get; set; }
        public bool CreateInvite { get; set; }
        public bool ChangeNickname { get; set; }
        public bool ManageNickname { get; set; }
        public bool KickMember { get; set; }
        public bool banMember { get; set; }
        public bool MentionAllRole { get; set; }
        public bool ManageMessage { get; set; }

        public Role() { }

        public void AssignRole() { }
        public void CreateRole() { }

    }
}
