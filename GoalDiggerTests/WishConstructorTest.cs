using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoalDigger.Model;

namespace GoalDigger
{
    [TestClass]
    public class WishConstructorTest
    {
        [TestMethod]
        public void CreatingAnEventSotresItsProperties()
        {
            Wish rocketship = new Wish("rocketship", "02/14/2015", 1000000);
            Assert.AreEqual("rocketship", rocketship.Name);
            Assert.AreEqual("02/14/2015", rocketship.Date);
            Assert.AreEqual(1000000, rocketship.Price);
        }
    }
}
