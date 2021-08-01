using System;
using MyLibrary;

#warning Пройтись по коду где стоит breakpoint исправить неработающие методы, сделать рефакторинг
namespace CardsDeck
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck36 = new Deck();
            DeckFiller.Filler(deck36);
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
            startGame.WhoseMove(player1, player2);

            while (deck36.CardsDeck != null || (player1.Hand != null & player2.Hand != null))
            {
                game.SkirmishPlayers(player1, player2);
                startGame.DistributionCards(deck36);

                Console.WriteLine("DECK CARDS");
                deck36.CardsDeckShow();
                Console.WriteLine("---------");

                Console.WriteLine("HAND PLAYER1");
                player1.ShowHand();
                Console.WriteLine("HAND PLAYER2");
                player2.ShowHand();
            }

            Console.WriteLine("----------");
            //game.SortingCardsHand(player1);
            //game.SortingCardsHand(player2);
            Console.WriteLine("HAND PLAYER1");
            player1.ShowHand();
            Console.WriteLine("HAND PLAYER2");
            player2.ShowHand();         

        }
    }
}
