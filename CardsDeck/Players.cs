using System;
using System.Collections.Generic;
using System.Text;
using MyLibrary;

namespace CardsDeck
{
    class Player 
    {
        string name;
        Cards[] hand;
        int countHand;
        public Player(string name)
        {
            this.name = name;
            hand = new Cards[36];
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
                    if(value == null)
                    {
                        hand[countHand-1] = value;
                        countHand--;
                    }
                    else if(hand[index] == null)
                    {
                        hand[countHand] = value;
                        countHand++;
                    }
                    else
                    {
                        hand[index] = value;
                    }
                }
            }
        }
        public int CountHand { get { return countHand; } private set { } }
        public Cards[] Hand { get { return hand;} private set { } }
        public string Name { get { return name; } private set { } }

        public void TakeInHand(Cards card)
        {
            hand[countHand] = card;
            countHand++;
        }
        public void ShowHand()
        {
            foreach(var card in hand)
            {
                if (card == null) break;
                Console.WriteLine("{0} {1} {2} {3}", card.NameCard, card.SuitCard, 
                                                    card.AttackCard, card.Trump);                
            }
            Console.WriteLine("Number cards on hand {0}", countHand);
        }

        private bool Ok(int index)
        {
            if (index >= 0 & index < 36)
                return true;
            return false;
        }
    }
}
