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
            Console.Beep();
            int pauseTime = 1000;
            System.Threading.Thread.Sleep(pauseTime);
        }
    }
}
