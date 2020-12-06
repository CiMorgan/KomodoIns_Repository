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
        [TestMethod]
        public void SetID_ShouldAddCorrectID()
        {
            Developer developer = new Developer();

            developer.IDnumber = 987654;

            int expected = 987654;
            int actual = developer.IDnumber;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SetAccess_ShouldAddCorrectAccess()
        {
            Developer developer = new Developer();

            developer.AccessToPluralsight = true;

            bool expected = true;
            bool actual = developer.AccessToPluralsight;

            Assert.AreEqual(expected, actual);
        }
    }
}
