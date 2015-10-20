using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.view
{
    class PausEvent
    {
        public void Pause(object sender, EventArgs args)
        {
            int pauseTime = 500;
            System.Threading.Thread.Sleep(pauseTime);
        }
    }
}
