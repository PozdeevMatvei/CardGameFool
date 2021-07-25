using System;
using System.Collections.Generic;
using System.Text;

namespace CardsDeck
{
    class StartGame
    {
        Player player1;
        Player player2;
        public StartGame(Player player1, Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }
        public void ShuffleCardsDeck(Deck deck)
        {
            Random rand = new Random();
            for (int i = deck.Count-1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);
                Cards tmp = deck[j];
                deck[j] = deck[i];
                deck[i] = tmp;
            }
        }
        public void DistributionCards(Deck deck)
        {
            while(player1.CountHand < 6)           
                player1.TakeInHand(deck.TakeCardFromDeck());
            
            while (player2.CountHand < 6)
                player2.TakeInHand(deck.TakeCardFromDeck());
        }
        public void TrumpSuit(Deck deck)
        {
            Random r = new Random();
            Cards trump = deck[r.Next(deck.Count)];
            foreach(Cards card in deck)
            {
                if (trump.SuitCard == card.SuitCard)
                    card.Trump = 1;
            }
            Console.WriteLine("Козырь {0}", trump.SuitCard);
        }
        public void WhoseMove(Cards[] hand1, Cards[] hand2)
        {
            int min1 = 15;
            int min2 = 15;
            Random r = new Random();
            for(int i = 0; i < 6; i++)
            {
                if (hand1[i].Trump == 1)
                    if (hand1[i].AttackCard < min1)
                        min1 = hand1[i].AttackCard;

                if (hand2[i].Trump == 1)
                    if (hand2[i].AttackCard < min2)
                        min2 = hand2[i].AttackCard;
            }
            if (min1 != min2)
            {
                if (min1 < min2)
                    Console.WriteLine("Первым ходит {0}",player1.Name);
                else
                    Console.WriteLine("Первым ходит {0}",player2.Name);
            }
            else
            {
                if (r.Next(1, 3) == 1)
                    Console.WriteLine("Первым ходит {0}",player1.Name);
                else
                    Console.WriteLine("Первым ходит {0}",player2.Name);
            }
            
        }
    }  
}
