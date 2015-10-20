using BlackJack.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Dealer : Player, BlackJackObserver
    {
        private Deck m_deck = null;
        private const int g_maxScore = 21;

        private rules.INewGameStrategy m_newGameRule;
        private rules.IHitStrategy m_hitRule;
        private rules.IWinnerStrategy m_winnerRule;

        List<BlackJackObserver> m_observers;


        public Dealer(rules.RulesFactory a_rulesFactory)
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_hitRule = a_rulesFactory.GetHitRule();
            m_winnerRule = a_rulesFactory.GetWinnerRule();
            m_observers = new List<BlackJackObserver>();
        }

        

        public bool NewGame(Player a_player)
        {
            if (m_deck == null || IsGameOver())
            {
                m_deck = new Deck();
                ClearHand();
                a_player.ClearHand();
                return m_newGameRule.NewGame(this, a_player);   
            }
            return false;
        }

        public bool Hit(Player a_player)
        {
            if (m_deck != null && a_player.CalcScore() < g_maxScore && !IsGameOver())
            {
                DealCard(true, a_player);
                return true;
            }
            return false;
        }

        public void DealCard(bool showHiddenCard, Player a_player) {
            Card c;
            c = m_deck.GetCard();
            c.Show(showHiddenCard);
            a_player.AddCardToHand(c);
        }

        public void AddSubscriber(BlackJackObserver a_sub)
        {
            m_observers.Add(a_sub);
        }


        public bool Stand() { 
            if(m_deck != null){
                ShowHand();

                foreach(Card card in GetHand().ToList<Card>()){
                    card.Show(true);
                }

                while(m_hitRule.DoHit(this)){
                    DealCard(true, this);
                }
                return true;
            }
            return false;
        }

        public bool IsDealerWinner(Player a_player)
        {
            if (a_player.CalcScore() > g_maxScore)
            {
                return true;
            }
            else if (CalcScore() > g_maxScore)
            {
                return false;
            }

            return m_winnerRule.IsDealerWinner(a_player, CalcScore());
        }

        public bool IsGameOver()
        {
            if (m_deck != null && /*CalcScore() >= g_hitLimit*/ m_hitRule.DoHit(this) != true)
            {
                return true;
            }
            return false;
        }
    }
}
