using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    interface BlackJackObserver
    {
        void DealCard(bool showHiddenCard, Player a_player);
    }
}
