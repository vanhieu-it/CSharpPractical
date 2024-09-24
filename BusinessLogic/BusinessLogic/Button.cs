using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Button
    {
        public event EventHandler Clicked;

        public void Click()
        {
            Clicked?.Invoke(this, EventArgs.Empty);
        }
    }

}
