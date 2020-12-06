using KomodoIns_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoIns_Tests
{
    [TestClass]
    public class DevTeamTests
    {
        [TestMethod]
        public void AddName_ShouldAddTeamName()
        {
            DevTeam devteam = new DevTeam();

            devteam.TeamName = "Tigers";

            string expected = "Tigers";
            string actual = devteam.TeamName;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddNum_ShouldAddTeamIDnum()
        {
            DevTeam devteam = new DevTeam();

            devteam.TeamNumber = 345;

            int expected = 345;
            int actual = devteam.TeamNumber;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddMemList_ShouldAddMemberList()
        {
            DevTeam actual = new DevTeam();
            //actual.Members.Add("Steve McQueen");            
            //actual.Members.Add("John Wayne");

            List<string> expected = new List<string>();
            expected.Add("Steve McQueen");
            expected.Add("John Wayne");

            //CollectionAssert.AreEquivalent(expected, actual.Members);
        }

    }
}
