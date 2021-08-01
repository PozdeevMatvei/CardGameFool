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
                        countHand--;
                    }
                    else if (hand[index] == null)
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
        public Cards[] Hand { get { return hand; } private set { } }
        public string Name { get { return name; } private set { } }
        public int LengthCardsHand { get { return lengthCardsHand; } private set { } }

        public void TakeInHand(Cards card)
        {
            hand[countHand] = card;
            countHand++;
        }
        public Cards GiveCardHand()
        {
            Cards tmp = hand[countHand - 1];
            hand[countHand - 1] = null;
            countHand--;
            return tmp;
        }
        public Cards GiveThisCardHand(Cards card)
        {
            for( int i = countHand-1; i >= 0; i++)
            {
                if(Cards.CompareCards(card,hand[i]))
                {
                    hand[i] = null;
                    SortingCardsHand();
                    countHand--;
                }
            }
            return card;
        }
        bool GettingProtectedPlayerCard(Cards cardAttack, Cards cardProtected)
        {
            bool cardProtectedFlag = false;
            if (cardProtected.Trump == 1 & cardAttack.Trump == 1)
            {
                if (cardProtected.AttackCard > cardAttack.AttackCard)
                    cardProtectedFlag = true;
            }
            else if (cardProtected.Trump == 1)
            {
                cardProtectedFlag = true;
            }
            else if (cardAttack.Trump != 1)
            {
                if (cardProtected.SuitCard == cardAttack.SuitCard)
                    if (cardProtected.AttackCard > cardAttack.AttackCard)
                        cardProtectedFlag = true;
            }
            return cardProtectedFlag;
        }
        void SortingCardsHand()
        {
            Array.Sort(hand);
            Array.Reverse(hand);

            for (int i = CountHand - 1; i > 0; i--)
            {
                if (hand[i] != null & hand[i - 1] == null)
                {
                    hand[i - 1] = hand[i];
                    hand[i] = null;
                }
                else if (hand[i].Trump == hand[i - 1].Trump)
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

        bool Ok(int index)
        {
            if (index >= 0 & index < lengthCardsHand)
                return true;
            return false;
        }
    }
}
