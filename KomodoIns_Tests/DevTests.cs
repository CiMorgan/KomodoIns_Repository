using KomodoIns_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoIns_Tests
{
    [TestClass]
    public class DevTests
    {
        [TestMethod]
        public void SetName_ShouldAddCorrectName()
        {
            Developer developer = new Developer();

            developer.Name = "Elon Musk";

            string expected = "Elon Musk";
            string actual = developer.Name;

            Assert.AreEqual(expected, actual);
        }
    }
}
