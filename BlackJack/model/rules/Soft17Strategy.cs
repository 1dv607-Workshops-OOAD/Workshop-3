using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class Soft17Strategy : IHitStrategy
    {
        private const int g_hitLimit = 17;

        public bool DoHit(model.Player a_dealer)
        {
            int score = 0;

            if (a_dealer.CalcScore() == 17)
            {
                foreach (Card c in a_dealer.GetHand())
                {
                    score += (int)c.GetValue();

                    if (c.GetValue() == Card.Value.Ace)
                    {
                        score += 0;
                    }
                }

                if(score == 6){
                    return true;
                }
            }

            return a_dealer.CalcScore() < g_hitLimit;
        }
    }
}
