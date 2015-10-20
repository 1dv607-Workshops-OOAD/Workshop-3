using BlackJack.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.view
{
    class Observer
    {
        public event EventHandler EventTrigged;

        public void TriggedEvent()
        {
            EventHandler handler = EventTrigged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}
