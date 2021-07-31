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
            game1.DefineTrumpSuit(deck36);
            game1.DistributionCards(deck36);
            game1.WhoseMove(player1, player2);

            while (deck36.CardsDeck != null || (player1.Hand != null & player2.Hand != null))
            {
                playfool.SkirmishPlayers(player1, player2);
                game1.DistributionCards(deck36);

                Console.WriteLine("DECK CARDS");
                deck36.CardsDeckShow();
                Console.WriteLine("---------");

                Console.WriteLine("HAND PLAYER1");
                player1.ShowHand();
                Console.WriteLine("HAND PLAYER2");
                player2.ShowHand();
            }

            Console.WriteLine("----------");
            Console.WriteLine("HAND PLAYER1");
            player1.ShowHand();
            Console.WriteLine("HAND PLAYER2");
            player2.ShowHand();         

        }
    }
}
