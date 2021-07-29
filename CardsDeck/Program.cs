using System;
using MyLibrary;

namespace CardsDeck
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck36 = new Deck();
            CardDeckFiller.Filler(deck36);
            Console.WriteLine("DECK CARDS");
            deck36.CardsDeckShow();
            Console.WriteLine("---------");

            Player player1 = new Player("player1");
            Player player2 = new Player("player2");
            GameDesk gameDesk1 = new GameDesk();
            StartGame game1 = new StartGame(player1, player2);
            Game playfool = new Game(player1, player2, gameDesk1);

            game1.ShuffleCardsDeck(deck36);
            game1.TrumpSuit(deck36);
            game1.DistributionCards(deck36);
            game1.WhoseMove(player1.Hand, player2.Hand);
            //Console.WriteLine("DECK CARDS");
            //deck36.CardsDeckShow();
            Console.WriteLine("----------");
            Console.WriteLine("HAND PLAYER1");
            player1.ShowHand();
            Console.WriteLine("HAND PLAYER2");
            player2.ShowHand();
            playfool.SortingCardsHand(player1);
            Console.WriteLine("HAND PLAYER1 SORT");
            player1.ShowHand();

        }
    }
}
