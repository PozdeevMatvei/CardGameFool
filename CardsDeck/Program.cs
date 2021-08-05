using System;
using MyLibrary;

namespace CardsDeck
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck36 = new Deck();
            deck36.CardsDeckShow();

            Player player1 = new Player("player1");
            Player player2 = new Player("player2");
            StartGame startGame = new StartGame(player1, player2);
            Game game = new Game(new GameDesk());

            startGame.ShuffleCardsDeck(deck36);
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
                startGame.DistributionCards(deck36, ref attack, ref protection);//distr
                ShowHandsPlayers(player1, player2);
                WhoseMove(countCardsProtection, ref attack, ref protection);

            } while (deck36.Count != 0 || (player1.CountHand != 0 & player2.CountHand != 0));

            PlayerWins(player1, player2);

        }
        static void WhoseMove(int countCardsProtection, ref Player attack, ref Player protection)
        {           
            if(countCardsProtection >= protection.CountHand)
            {
                Player buf = attack;
                attack = protection;
                protection = buf;
            }           
            Console.WriteLine($"Ходит {attack.Name}");
            Console.WriteLine();
        }
        static void ShowHandsPlayers(Player player1, Player player2)
        {
            player1.ShowHand(player1.Name);
            Console.WriteLine();
            player2.ShowHand(player2.Name);
        }
        static void PlayerWins(Player player1, Player player2)
        {
            if (player1.CountHand == 0 && player2.CountHand == 0)
            {
                Console.WriteLine("Dead heaat");
            }
            else if (player1.CountHand == 0)
                Console.WriteLine($"{player1.Name} wins!");
            else
                Console.WriteLine($"{player2.Name} wins!");
        }
    }
}
