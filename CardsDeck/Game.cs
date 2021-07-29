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
        public Game(Player player1, Player player2) : base (player1,player2)
        {
            this.player1 = player1;
            this.player2 = player2;
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
        public void PlayerAttack(Player player)
        {
            int count = player.CountHand;
            if (player.Hand[count] != null)
            {
                if (player.Hand[count].Trump == 0)
                {
                    player.Hand[count] = null;
                }
            }
        }
        public void PlayerProtection(Player player)
        {

        }
    }
}
