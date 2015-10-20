using BlackJack.model;
using BlackJack.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.controller
{
    class PlayGame : BlackJackObserver
    {
        public bool Play(model.Game a_game, view.IView a_view)
        {
            a_game.AddSubscriber(this);

            a_view.DisplayWelcomeMessage();
            
            a_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
            a_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());

            if (a_game.IsGameOver())
            {
                a_view.DisplayGameOver(a_game.IsDealerWinner());
            }

            MasterView.MenuChoice input = a_view.GetMenuChoice();

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
        }

        public void DealCard(bool showHiddenCard, Player a_player) {
            //a_view.DisplayCard(model.Card a_card);
        }
    }
}
