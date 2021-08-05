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
            TranspositionTrumpInBegining(deck);
            
        }
        public void DistributionCards(Deck deck, ref Player attack, ref Player protection)
        {
            if (deck.Count != 0)
            {
                while (attack.CountHand < 6)
                {
                    if (deck.Count == 0) break;
                    attack[attack.CountHand] = (deck.TakeCardFromDeck());
                }

                while (protection.CountHand < 6)
                {
                    if (deck.Count == 0) break;
                    protection[protection.CountHand] = (deck.TakeCardFromDeck());
                }
            }
            attack.SortingCardsHand();
            protection.SortingCardsHand();
        }
        public void WhoseMoveFirst(Player player1, Player player2, ref Player attack, ref Player protection)
        {         
            Random r = new Random();
            Player playerMinTrump = CompareMinTrumpPlayer(player1, player2);

            if (playerMinTrump != null)
            {
                Console.WriteLine("Первым ходит {0}", playerMinTrump.Name);
                attack = playerMinTrump;
                if (attack == player1)
                    protection = player2;
                else
                    protection = player1;
            }
            else if (r.Next(1, 3) == 1)
            {
                Console.WriteLine("Первым ходит {0}", player1.Name);
                attack = player1;
                protection = player2;
            }
            else
            {
                Console.WriteLine("Первым ходит {0}", player2.Name);
                attack = player2;
                protection = player1;
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
        void TranspositionTrumpInBegining(Deck deck)
        {
            if(deck[0].Trump != 1)
                for (int i = 0; i < deck.Count; i++)
                {
                    if(deck[i].Trump == 1)
                    {
                        Cards buf = deck[0];
                        deck[0] = deck[i];
                        deck[i] = buf;
                        break;
                    } 
                        
                }
        }
    }  
}
