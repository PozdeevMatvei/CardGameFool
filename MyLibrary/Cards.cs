using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary
{
    public class Cards
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
        {
            get { return trump; }
            set
            {
                if (value == 0 || value == 1)
                    trump = value;
            }
        }
    }
}
