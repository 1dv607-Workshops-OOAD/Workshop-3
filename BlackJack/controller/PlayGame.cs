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
        private IView m_view;
        private Game m_game;

        public PlayGame(IView a_view, Game a_game)
        {
            m_view = a_view;
            m_game = a_game;
        }

        public bool Play()
        {
            m_view.DisplayWelcomeMessage();

            m_view.DisplayDealerHand(m_game.GetDealerHand(), m_game.GetDealerScore());
            m_view.DisplayPlayerHand(m_game.GetPlayerHand(), m_game.GetPlayerScore());

            if (m_game.IsGameOver())
            {
                m_view.DisplayGameOver(m_game.IsDealerWinner());
            }

            MasterView.MenuChoice input = m_view.GetMenuChoice();

            if (input == MasterView.MenuChoice.Play)
            {
                m_game.AddSubscriber(this);
                m_game.NewGame();
            }
            else if (input == MasterView.MenuChoice.Hit)
            {
                m_game.Hit();
            }
            else if (input == MasterView.MenuChoice.Stand)
            {
                m_game.Stand();
            }

            return input != MasterView.MenuChoice.Quit;
        }

        public void CardIsDealt(model.Card a_card) 
        {
            m_view.DisplayCard(a_card);
        }
    }
}
