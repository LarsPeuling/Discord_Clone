using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord_Clone.MVVM.Models
{
    public class ButtonManager
    {
        public static event Action<string> OnNewButtonCreated;

        public static void AddButton(string btnname)
        {
            OnNewButtonCreated?.Invoke(btnname);
        }
    }
}
