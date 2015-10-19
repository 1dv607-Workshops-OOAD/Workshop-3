using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.view
{
    class MasterView
    {
        public enum MenuChoice
        {
            Play,
            Hit,
            Stand,
            Quit
        }

        public char GetInput()
        {
            return Console.ReadKey().KeyChar;
        }
    }
}
