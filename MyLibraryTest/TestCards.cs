using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLibrary;

namespace MyLibraryTest
{
    [TestClass]
    public class TestCards
    {
        [TestMethod]
        public void TestCard()
        {
            Cards card = new Cards("9", "буби", 9);
            card.Trump = 4;
            Assert.AreEqual("9", card.NameCard);
            Assert.AreEqual("буби", card.SuitCard);
            Assert.AreEqual(9, card.AttackCard);
            Assert.AreEqual(0, card.Trump);
        }
    }
}
