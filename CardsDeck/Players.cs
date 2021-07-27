﻿using System;
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
                Console.WriteLine("{0} {1} {2} {3}", card.NameCard, card.SuitCard, card.AttackCard, card.Trump);                
            }
            Console.WriteLine("Number cards on hand {0}", countHand);
        }
    }
}
