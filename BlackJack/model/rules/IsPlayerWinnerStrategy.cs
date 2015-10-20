using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class IsPlayerWinnerStrategy : IWinnerStrategy
    {
        public bool IsDealerWinner(Player a_player, int score)
        {
            return score > a_player.CalcScore();
        }
    }
}
