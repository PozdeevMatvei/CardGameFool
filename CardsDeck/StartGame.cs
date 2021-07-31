using System;
using System.Collections.Generic;
using System.Text;
using MyLibrary;

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
        public void DefineTrumpSuit(Deck deck)
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
        public Player WhoseMove(Player player1, Player player2)
        {         
            Random r = new Random();
            Player playerMinTrump = CompareMinTrumpPlayer(player1, player2);

            if (playerMinTrump != null)
            {
                Console.WriteLine("Первым ходит {0}", playerMinTrump.Name);
                return playerMinTrump;
            }
            else if (r.Next(1, 3) == 1)
            {
                Console.WriteLine("Первым ходит {0}", player1.Name);
                return player1;
            }
            else
            {
                Console.WriteLine("Первым ходит {0}", player2.Name);
                return player2;
            }                      
        }

        int SearchMinTrumpFromHand(Player player)
        {
            int minAttackCard = 15; 
            for (int i = 0; i < 6; i++)
            {
                if (player.Hand[i].Trump == 1)
                    if (player.Hand[i].AttackCard < minAttackCard)
                        minAttackCard = player.Hand[i].AttackCard;
            }
            return minAttackCard;
        }
        Player CompareMinTrumpPlayer(Player player1, Player player2)
        {
            int minTrumpPlayer1 = SearchMinTrumpFromHand(player1);
            int minTrumpPlayer2 = SearchMinTrumpFromHand(player2);

            if (minTrumpPlayer1 < minTrumpPlayer2)
                return player1;
            else if (minTrumpPlayer2 < minTrumpPlayer1)
                return player2;
            else
                return null;
        }
    }  
}
