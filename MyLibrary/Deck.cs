using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary
{
    public class Deck : IEnumerable
    {
        Cards[] cardsDeck;
        int length;
        int count;

        public Deck()
        {
            cardsDeck = new Cards[36];
            count = 0;
            length = 36;
            Filler();
        }
        public Cards this[int index]
        {                   
            get 
            {
                if (Ok(index))
                {
                    return cardsDeck[index];
                } 
                return null; 
            }
            set
            {
                if (Ok(index) & (value != null || cardsDeck[index] != null))
                {
                    if (value == null)
                    {
                        cardsDeck[count - 1] = value;
                        count--;
                    }
                    else if (cardsDeck[index] == null)
                    {
                        cardsDeck[count] = value;
                        count++;
                    }
                    else
                    {
                        cardsDeck[index] = value; 
                    }
                }
            }           
        }
        public int Count { get { return count; } private set { } }
        public int Length { get { return length; } private set { } }
        public Cards[] CardsDeck { get { return cardsDeck; } private set { } }

        public void CardsDeckShow()
        {
            Console.WriteLine("DECK CARDS");
            foreach (Cards card in cardsDeck)
            {
                Console.WriteLine("{0} {1} {2}", card.NameCard, card.SuitCard, card.AttackCard);
            }
            Console.WriteLine("Number cards in deck {0}", count);
            Console.WriteLine("---------------");
        }
        public Cards TakeCardFromDeck()
        {
            if (count == 0)
                return null;
            Cards takeCard = cardsDeck[count - 1];
            cardsDeck[count - 1] = null;
            count--;
            return takeCard;
        }

        void Filler()
        {
            int[] trumpSuit = DefineTrumpSuit();
            string[] suit = { "черви", "буби", "крести", "пики" };
            string[] nameCard = {"шестерка","семерка","восьмерка","девятка","десятка","валет",
                                "дама","король","туз"};
            for (int i = 0; i < suit.Length; i++)
            {
                for (int attack = 0; attack < nameCard.Length; attack++)
                {
                    cardsDeck[count] = new Cards(nameCard[attack], suit[i], attack + 6, trumpSuit[i]);
                    count++;
                }
            }
        }
        int[] DefineTrumpSuit()
        {
            Random r = new Random();
            int[] trumpSuit = { 0, 0, 0, 0 };
            trumpSuit[r.Next(0, 4)] = 1;
            return trumpSuit;
        }
        bool Ok(int index)
        {
            if (index >= 0 & index < length)
                return true;
            return false;
        }
        #region IEnum        
        private class MyEnumerator : IEnumerator
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
