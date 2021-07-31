using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using MyLibrary;

namespace CardsDeck
{
    class Game : StartGame, IComparer
    {
        Player player1;
        Player player2;
        GameDesk gameDesk1;
        public Game(Player player1, Player player2, GameDesk gameDesk1) : base (player1,player2)
        {
            this.player1 = player1;
            this.player2 = player2;
            this.gameDesk1 = gameDesk1;
        }
        public int Compare(Object x, Object y)
        {
            return (new CaseInsensitiveComparer()).Compare(y, x);
        }        
               
        public void SkirmishPlayers(Player pAttack, Player pProtected)
        {
            if (PlayerAttack(pAttack))
            {
                if (PlayerProtection(pProtected))
                {
                    this.SkirmishPlayers(pAttack, pProtected);
                }
                else
                {
                    foreach (Cards card in gameDesk1.Desk)
                    {
                        pProtected.TakeInHand(card);
                    }
                }
            }
            else
            {
                gameDesk1.PutCardsBat();
            }
        }
      
        bool PlayerAttack(Player player)
        {
            bool attackFlag = false;
            SortingCardsHand(player);
            if (gameDesk1.Length == 0)
            {
                gameDesk1.GettingAttackPlayerCard(player.GiveCardHand());
                attackFlag = true;
            }
            else
            {
                CompareCardsHandDesk(player, ref attackFlag);
            }
            return attackFlag;
        }
        Cards CompareCardsHandDesk(Player player, ref bool attackFlag)
        {
            foreach (Cards cardHand in player.Hand)
            {
                foreach (Cards cardDesk in gameDesk1.Desk)
                {
                    if (cardHand.AttackCard == cardDesk.AttackCard)
                    {
                        attackFlag = true;
                        return player.GiveCardHand();
                    }
                }
            }
            attackFlag = false;
            return null;
        }
        bool PlayerProtection(Player player)
        {
            SortingCardsHand(player);
            foreach (var cardProtected in player.Hand)
            {
                if (gameDesk1.GettingProtectedPlayerCard(cardProtected))
                {
                    //gameDesk1.GettingProtectedPlayerCard(cardProtected);
                    return true;
                }
            }
            return false;
        }
        void SortingCardsHand(Player player1)
        {
            Array.Sort(player1.Hand);
            Array.Reverse(player1.Hand);
        }
    }
}
