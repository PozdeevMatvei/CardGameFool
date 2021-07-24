using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CardsDeck
{
    class Cards
    {
        string name;
        string suit;
        int attack;
        int trump;
        public Cards(string name, string suit, int attack)
        {
            this.name = name;
            this.suit = suit;
            this.attack = attack;
            trump = 0;
        }
        public string NameCard { get { return name; } private set { } }      
        public string SuitCard { get { return suit; } private set { } }
        public int AttackCard { get { return attack; } private set { } }
        public int Trump 
        { get { return trump; } 
            set 
            {
                if (value == 0 || value == 1)
                    trump = value;
            }
        }
    }
    class Deck : IEnumerable
    {
        Cards[] cardsDeck;
        int count;
        public Deck()
        {
            cardsDeck = new Cards[36];
            count = 0;
        }
        public Cards this[int index]
        {
            get { return cardsDeck[index]; }
            set { cardsDeck[index] = value; }
        }
        public int Count { get { return count; } private set { } }
        public Cards CardsDeck
        {
            get { return cardsDeck[count]; }
            set 
            {
                if (count < 36)
                {
                    cardsDeck[count] = value;
                    count++;
                }
            }
        }
        public void CardsDeckShow()
        {
            for (int i = 0; i < count; i++)
            {
                Cards e = cardsDeck[i];
                Console.WriteLine("{0} {1} {2}", e.NameCard, e.SuitCard, e.AttackCard);
            }
            Console.WriteLine("Number cards in deck {0}",count);
        }
        public Cards TakeCardFromDeck()
        {
            Cards takeCard = cardsDeck[count-1];
            cardsDeck[count-1] = null;
            count--;
            return takeCard;
        }
        #region IEnum        
        private class MyEnumerator:IEnumerator
        {
            Cards[] cardsDeck;
            int pozition = -1;
            public MyEnumerator(Cards[] cardsDeck)
            {
                this.cardsDeck = cardsDeck;
            }
            public bool MoveNext()
            {
                pozition++;
                return (pozition < cardsDeck.Length);
            }
            public void Reset()
            {
                pozition = -1;
            }
            public object Current
            {
                get
                {
                    try
                    {
                        return cardsDeck[pozition];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }
        public IEnumerator GetEnumerator()
        {
            return new MyEnumerator(cardsDeck);
        }
        #endregion
    }
}
