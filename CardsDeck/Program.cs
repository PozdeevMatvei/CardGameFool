using System;
using MyLibrary;

namespace CardsDeck
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck36 = new Deck();
            Console.WriteLine("DECK CARDS");
            deck36.CardsDeckShow();
            Console.WriteLine("---------");

            Player player1 = new Player("player1");
            Player player2 = new Player("player2");
            GameDesk gameDesk = new GameDesk();
            StartGame startGame = new StartGame(player1, player2);
            Game game = new Game(gameDesk);

            startGame.ShuffleCardsDeck(deck36);
            startGame.DefineTrumpSuit(deck36);
            startGame.DistributionCards(deck36, ref player1, ref player2);

            Player attack = new Player();
            Player protection = new Player();

            startGame.WhoseMoveFirst(player1, player2, ref attack,ref protection);

            ShowHandsPlayers(player1, player2);

            do
            {
                int countCardsProtection = protection.CountHand;
                game.SkirmishPlayers(attack, protection);
                Console.WriteLine("\n");                
                startGame.DistributionCards(deck36, ref attack, ref protection);
                ShowHandsPlayers(player1, player2);
                WhoseMove(countCardsProtection, ref attack, ref protection);

            } while (deck36.Count != 0 || (player1.CountHand != 0 & player2.CountHand != 0));

            Player playerWins;
            if (player1.CountHand == 0)
                playerWins = player1;
            else
                playerWins = player2;
            Console.WriteLine("{0}  wins",playerWins.Name);

        }
        static void WhoseMove(int countCardsProtection, ref Player attack, ref Player protection)
        {           
            if(countCardsProtection >= protection.CountHand)
            {
                Player buf = attack;
                attack = protection;
                protection = buf;
            }           
            Console.WriteLine("Ходит {0}", attack.Name);
            Console.WriteLine();
        }
        static void ShowHandsPlayers(Player player1, Player player2)
        {
            Console.WriteLine("----------");
            Console.WriteLine("HAND PLAYER1");
            player1.ShowHand();
            Console.WriteLine();
            Console.WriteLine("HAND PLAYER2");
            player2.ShowHand();
            Console.WriteLine("------------");
        }
    }
}
