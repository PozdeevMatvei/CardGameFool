using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary
{
    public class GameDesk
    {
        List<Cards> desk;
        int length;
        Cards card;

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
            card = cardAttack;
        }
        public bool DeskProtected(Cards cardProtected)
        {
            if (cardProtected.Trump == 1 & card.Trump == 1)
            {
                if (cardProtected.AttackCard > card.AttackCard)
                {
                    DeskAdd(card, cardProtected);
                    return true;
                }
                return false;
            }
            else if (cardProtected.Trump == 1 & card.Trump != 1)
            {
                DeskAdd(card, cardProtected);
                return true;
            }
            else if (card.Trump != 1 & cardProtected.AttackCard > card.AttackCard)
            {
                DeskAdd(card, cardProtected);
                return true;
            }
            else
            {
                return false;
            }
        }
        void DeskAdd(Cards attack, Cards protect)
        {
            desk.Add(attack);
            desk.Add(protect);
            length += 2;
        }

    }
}
