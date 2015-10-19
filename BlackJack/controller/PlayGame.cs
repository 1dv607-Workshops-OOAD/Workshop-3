using BlackJack.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.controller
{
    class PlayGame
    {
        public bool Play(model.Game a_game, view.IView a_view)
        {
            a_view.DisplayWelcomeMessage();
            
            a_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
            a_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());

            if (a_game.IsGameOver())
            {
                a_view.DisplayGameOver(a_game.IsDealerWinner());
            }

            MasterView.MenuChoice input = a_view.GetMenuChoice();
            Console.WriteLine("Enum:" + input);

            if (input == MasterView.MenuChoice.Play)
            {
                a_game.NewGame();
            }
            else if (input == MasterView.MenuChoice.Hit)
            {
                a_game.Hit();
            }
            else if (input == MasterView.MenuChoice.Stand)
            {
                a_game.Stand();
            }

            return input != MasterView.MenuChoice.Quit;

            //if (input == MasterView.MenuChoice.Quit)
            //{
            //    return false;
            //}
            //else
            //{
            //    return true;
            //}
        }
    }
}
