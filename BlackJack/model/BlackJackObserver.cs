using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    interface BlackJackObserver
    {
        void CardIsDealt(model.Card a_card);
    }
}
