using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary
{
    public class GameDesk
    {
        List<Cards> desk;
        int length;
        Cards cardAttack;

        public GameDesk()
        {
            desk = new List<Cards>();
            length = 0;
        }
        public List<Cards> Desk
        {
            get
            {
                return desk;
            }
            private set { }
        }
        public int Length { get { return length; } private set { } }

        public void GettingAttackPlayerCard(Cards cardAttack)
        {            
            this.cardAttack = cardAttack;
        }
        public bool GettingProtected(Player player)
        {
            for (int i = player.CountHand - 1; i <= 0; i--)
            {
                if (GettingProtectedPlayerCard(player.Hand[i]))
                {
                    DeskAdd(cardAttack, player.Hand[i]);
                    return true;
                }
            }
            Desk.Add(cardAttack);
            return false;
        }
        public void PutCardsBat()
        {
            desk.Clear();
        }

        
       
        void DeskAdd(Cards attack, Cards protect)
        {
            desk.Add(attack);
            desk.Add(protect);
            length += 2;
        }

    }
}
