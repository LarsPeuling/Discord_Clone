using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord_Clone.Models.User___Roles
{
    public class Tag
    {
        public int UserId { get; set; }
        public string UserTag { get; set; }
        public Tag()
        {

        }

        public string CreateTag(int userId)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var stringChars = new char[4];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String("#" + userId.ToString() + stringChars);
            return finalString;
        }
    }

    

}
