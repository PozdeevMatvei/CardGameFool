using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using MyLibrary;
// Добавить класс стол создать поле типа list | array для записи выложенных на стол карт
//реализовать методы атаки и защиты сделать сбор карт со стола после хода либо на руку
//либо в мусор. Сделать алгоритм ии.
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

        public void SortingCardsHand(Player player)
        {           
            Array.Sort(player.Hand);
            Array.Reverse(player.Hand);
        }
        
        public Cards CompareCardsHandDesk(Player player)
        {
            foreach(Cards cardHand in player.Hand)
            {
                foreach(Cards cardDesk in gameDesk1.Desk)
                {
                    if (cardHand.AttackCard == cardDesk.AttackCard)
                        return player.GiveCardHand();
                }
            }
            return null;
        }
        public void PlayerAttack(Player player)
        {
            SortingCardsHand(player);
            if(gameDesk1.Length == 0)
            {
                gameDesk1.GettingAttackPlayerCard(player.GiveCardHand());
            }
            else
            {
                CompareCardsHandDesk(player);
            }
        }
        public void PlayerProtection(Player player)
        {

        }
    }
}
