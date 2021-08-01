using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using MyLibrary;

namespace CardsDeck
{
    class Game : IComparer
    {      
        GameDesk gameDesk;
        public Game(GameDesk gameDesk)
        {
            this.gameDesk = gameDesk;
        }
        public int Compare(Object x, Object y)
        {
            return (new CaseInsensitiveComparer()).Compare(y, x);
        }        
               
        public void SkirmishPlayers(Player pAttack, Player pProtected)
        {         
            if (PlayerAttack(pAttack))
            {
                if (pProtected.Hand == null)
                    return;
                if (PlayerProtection(pProtected))
                {
                    this.SkirmishPlayers(pAttack, pProtected);
                }
                else
                {
                    foreach (Cards card in gameDesk.Desk)
                    {
                        pProtected.TakeInHand(card);
                    }
                    gameDesk.PutCardsBat();
                }
            }
            else
            {
                gameDesk.PutCardsBat();
            }
        }
      
        bool PlayerAttack(Player player)
        {
            bool attackFlag = false;
            //SortingCardsHand(player);
            if (gameDesk.Length == 0)
            {
                gameDesk.GettingAttackPlayerCard(player.GiveCardHand());
                attackFlag = true;
            }
            else
            {
                Cards cardAttack = CompareCardsHandDesk(player, ref attackFlag);
                if (attackFlag)
                    gameDesk.GettingAttackPlayerCard(cardAttack);
            }
            return attackFlag;
        }
        bool PlayerProtection(Player player)
        {            
            //SortingCardsHand(player);
            return gameDesk.GettingProtected(player);           
        }
        Cards CompareCardsHandDesk(Player player, ref bool attackFlag)
        {
            for (int index = player.CountHand-1; index <= 0; index++)
            {
                foreach (Cards cardDesk in gameDesk.Desk)
                {
                    if (player[index].AttackCard == cardDesk.AttackCard)
                    {
                        attackFlag = true;
                        Cards cardAttack = player[index];
                        player[index] = null;
                        return cardAttack;
                    }
                }
            }
            attackFlag = false;
            return null;
        }       
    }
}
