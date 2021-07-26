using System;
namespace MyLibrary
{
    public class CardDeckFiller
    {
        public static void Filler(Deck deckCards)
        {
            string[] suit = { "черви", "буби", "крести", "пики" };
            string[] nameCard = {"шестерка","семерка","восьмерка","девятка","десятка","валет",
            "дама","король","туз"};
            for (int i = 0; i < suit.Length; i++)
            {
                for (int attack = 0; attack < nameCard.Length; attack++)
                {
                    deckCards.CardsDeck = new Cards(nameCard[attack], suit[i], attack + 6);
                }
            }
        }
    }
}
