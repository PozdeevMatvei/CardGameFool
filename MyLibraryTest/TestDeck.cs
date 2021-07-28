using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLibrary;

namespace MyLibraryTest
{
    [TestClass]
    public class TestDeck
    {
        public void TestDeckIndex(Cards card, int expecCount, int expectAttack, int index)
        {
            Deck deck = new Deck();
            deck[0] = new Cards("6", "буби", 6);
            deck[index] = card;

            Assert.AreEqual(expecCount, deck.Count);
            if (card != null && index < deck.Length)
            {
                Assert.AreEqual(expectAttack, deck[index].AttackCard);
            }
        }
       
        [TestMethod]
        public void TestAddCard()
        {
            Cards card = new Cards("7", "буби", 7);
            TestDeckIndex(card, 2, 7, 1);
        }
        [TestMethod]
        public void TestAddNull()
        {
            Cards card = null;
            TestDeckIndex(card, 1, 0, 1);
        }
        [TestMethod]
        public void TestDelete()
        {
            TestDeckIndex(null, 0, 0, 0);
        }
        [TestMethod]
        public void TestMaxCards()
        {
            Cards card = new Cards("7", "буби", 7);
            TestDeckIndex(card, 1, 0, 37);
        }
    }
}
