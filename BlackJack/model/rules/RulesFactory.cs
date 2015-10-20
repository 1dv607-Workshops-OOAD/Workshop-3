using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class RulesFactory
    {
        public IHitStrategy GetHitRule()
        {
            //Choose to return Soft17Strategy or BasicHitStrategy
            return new Soft17Strategy();
        }

        public INewGameStrategy GetNewGameRule()
        {
            //Choose to return AmericanNewGameStrategy or InternationalNewGameStrategy
            return new AmericanNewGameStrategy();
        }
    }
}
