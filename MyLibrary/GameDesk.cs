using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary
{
    class GameDesk
    {
        List<Cards> desk;
        Cards card;

        public GameDesk()
        {
            desk = new List<Cards>();            
        }
        public List<Cards> Desk
        {
            get
            {
                return desk;
            }
            private set { }
        }
        public void AttackDesk(Cards cardAttack)
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
        private void DeskAdd(Cards attack, Cards protect)
        {
            desk.Add(attack);
            desk.Add(protect);
        }

    }
}
