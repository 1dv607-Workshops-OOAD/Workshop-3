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
            m_game.AddSubscriber(this);
        }

        public bool Play()
        {
            RenderGame();

            if (m_game.IsGameOver())
            {
                m_view.DisplayGameOver(m_game.IsDealerWinner());
            }

            MenuChoice input = m_view.GetMenuChoice();

            if (input == MenuChoice.Play)
            {
                m_game.NewGame();
            }
            else if (input == MenuChoice.Hit)
            {
                m_game.Hit();
            }
            else if (input == MenuChoice.Stand)
            {
                m_game.Stand();
            }

            return input != MenuChoice.Quit;
        }

        public void CardIsDealt()
        {
            RenderGame();
            System.Threading.Thread.Sleep(2000);
        }

        public void RenderGame() {
            m_view.DisplayWelcomeMessage();
            m_view.DisplayDealerHand(m_game.GetDealerHand(), m_game.GetDealerScore());
            m_view.DisplayPlayerHand(m_game.GetPlayerHand(), m_game.GetPlayerScore());
        }
    }
}
