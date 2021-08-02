using System;
using MyLibrary;

#warning Do refactoring method SortingCardsHand. Walk along DoWhile. Refactoring DoWhile.
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
            startGame.DistributionCards(deck36);

            Player attack = startGame.WhoseMove(player1, player2);
            Player protection;
            if (attack == player1)
                protection = player2;
            else
                protection = player1;

            Console.WriteLine("----------");
            Console.WriteLine("HAND PLAYER1");
            player1.ShowHand();
            Console.WriteLine("HAND PLAYER2");
            player2.ShowHand();

            do
            {
                game.SkirmishPlayers(attack, protection);
                startGame.DistributionCards(deck36);
                if (player1.CountHand < player2.CountHand)
                {
                    attack = player1;
                    protection = player2;
                }
                else
                {
                    attack = player2;
                    protection = player1;
                }
            } while (deck36.Count != 0 || (player1.CountHand != 0 & player2.CountHand != 0));

            Player playerWins;
            if (player1.CountHand == 0)
                playerWins = player1;
            else
                playerWins = player2;
            Console.WriteLine("{0} player wins",playerWins.Name);

        }
    }
}
