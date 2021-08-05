using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary
{
    public class Cards : IComparable
    {      
        string name;
        string suit;
        int attack;
        int trump;
        public Cards(string name, string suit, int attack, int trump)
        {
            this.name = name;
            this.suit = suit;
            this.attack = attack;
            Trump = trump;
        }
        public string NameCard { get { return name; } private set { } }
        public string SuitCard { get { return suit; } private set { } }
        public int AttackCard { get { return attack; } private set { } }
        public int Trump
        {
            get { return trump; }
            set
            {
                if (value == 1)
                    trump = value;
                else
                    trump = 0;
            }
        }
        public int CompareTo(object obj)
        {
            Cards card = obj as Cards;
            if (card != null)
            {
                return this.Trump.CompareTo(card.Trump);
            }
            else if (card == null)
            {
                return 1;
            }
            else
            {
                throw new ArgumentException("object is not myArray");
            }
        }
        public static bool CompareCards(Cards card1, Cards card2)
        {
            if (card1.SuitCard == card2.SuitCard)
                if (card1.AttackCard == card2.AttackCard)
                    return true;
            return false;
        }
        public void Show()
        {
            if(this != null)
            Console.WriteLine("{0} {1} {2} {3}", name, suit, attack, trump);
        }
    }
}
