using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord_Clone.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public User User{ get; set; }
        public Role Role{ get; set; }
    }
}
