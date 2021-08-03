using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary
{
    public class Player
    {       
        string name;
        Cards[] hand;
        int lengthCardsHand;
        int countHand;
        public Player()
        {

        }
        public Player(string name)
        {
            this.name = name;
            lengthCardsHand = 36;
            hand = new Cards[lengthCardsHand];
            countHand = 0;
        }

        public Cards this[int index]
        {
            get
            {
                if (Ok(index))
                {
                    return hand[index];
                }
                return null;
            }
            set
            {
                if (Ok(index) & (hand[index] != null || value != null))
                {
                    if (value == null)
                    {
                        hand[countHand - 1] = value;
                        SortingCardsHand();
                        countHand--;
                    }
                    else if (hand[index] == null)
                    {
                        hand[countHand] = value;
                        countHand++;
                        if (countHand == 6) 
                            SortingCardsHand();
                    }
                    else
                    {
                        hand[index] = value;
                    }
                }
            }
        }
        public int CountHand { get { return countHand; } private set { } }
        public Cards[] Hand { get { return hand; } private set { } }
        public string Name { get { return name; } private set { } }
        public int LengthCardsHand { get { return lengthCardsHand; } private set { } }

        public void ShowHand()
        {
            foreach (var card in hand)
            {
                if (card == null) break;
                Console.WriteLine("{0} {1} {2} {3}", card.NameCard, card.SuitCard,
                                                    card.AttackCard, card.Trump);
            }
            Console.WriteLine("Number cards on hand {0}", countHand);
        }

        public Cards Attack(GameDesk gameDesk)
        {
            int attackFlag = AttackCheck(gameDesk);
            if (attackFlag != -1)
            {
                Cards buf = hand[attackFlag];
                hand[attackFlag] = null;
                DecreaseCountHand();
                return buf;
            }
            return null;
        }
        public Cards Protection(Cards attack)
        {
            int protectionFlag = ProtectionCheck(attack);
            if (protectionFlag != -1)
            {
                Cards buf = hand[protectionFlag];
                hand[protectionFlag] = null;
                DecreaseCountHand();
                return buf;
            }
            return null;
        }
        int ProtectionCheck(Cards cardAttack)
        {          
            if(cardAttack != null)
                for (int i = countHand-1; i >= 0; i--)
                { 
                    if (hand[i].Trump ==  cardAttack.Trump)
                    {
                        if(hand[i].SuitCard == cardAttack.SuitCard)
                            if (hand[i].AttackCard > cardAttack.AttackCard)
                               return  i;
                    }
                    else if (hand[i].Trump == 1)
                    {
                        return i;
                    }               
                }
            return -1;
        }
        int AttackCheck(GameDesk gameDesk)
        {
            if (gameDesk.Length == 0)
            {
                return countHand-1;
            }
            else
            {
                for (int i = countHand - 1; i >= 0; i--)
                { 
                    foreach (Cards deskCard in gameDesk.Desk)                                    
                    {
                        if (hand[i].AttackCard == deskCard.AttackCard)
                            return i;
                    }
                }                
            }
            return -1;
        }
        void DecreaseCountHand()
        {
            countHand--;
            SortingCardsHand();   
        }
        public void SortingCardsHand()
        {
            Array.Sort(hand);
            Array.Reverse(hand);

            for (int count = CountHand - 1; count > 0; count--)
            {
                for (int i = CountHand - 1; i > 0; i--)
                {
                    if (hand[i].Trump == hand[i - 1].Trump)
                    {
                        if (hand[i].AttackCard > hand[i - 1].AttackCard)
                        {
                            Cards bufMinAttack = hand[i - 1];
                            hand[i - 1] = hand[i];
                            hand[i] = bufMinAttack;
                        }
                    }
                }
            }
        }        
        bool Ok(int index)
        {
            if (index >= 0 & index < lengthCardsHand)
                return true;
            return false;
        }
    }
}
