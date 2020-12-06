using KomodoIns_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoIns_Tests
{
    [TestClass]
    public class DevTeamRepoTests
    {
        private DevTeamRepo _repo;
        private DevTeam _devteam;
       
        [TestInitialize]
        public void Arrange()
        {
            List<string> list1 = new List<string>();
            list1.Add("George Washington");
            list1.Add("Ben Franklin");
            _repo = new DevTeamRepo();
            _devteam = new DevTeam("Panthers", 321, list1);
            _repo.AddDevTeamToList(_devteam);
        }
        //Add DevTeam
        [TestMethod]
        public void AddTeamToList_ShouldGetNotNull()
        {
            //Arrange
            DevTeam devTeam = new DevTeam();
            devTeam.TeamName = "Panther";
            DevTeamRepo repository = new DevTeamRepo();
            //Act
            repository.AddDevTeamToList(devTeam);
            DevTeam fromDirectory = repository.GetDevTeamByName("Panther");
            //Assert
            Assert.IsNotNull(fromDirectory);    
        }
        //Update DevTeam
        [TestMethod]
        public void UpdateExistingContent_ShouldReturnTrue()
        {
            //Arrange
            List<string> list2 = new List<string>();
            list2.Add("Abe Lincoln");
            list2.Add("Teddy Roosevelt");
            DevTeam newDevTeam = new DevTeam("Patriots", 776, list2);
            //Act
            bool updateResult = _repo.UpdateExistingDevTeam("Panthers", newDevTeam);
            //Assert
            Assert.IsTrue(updateResult);
        }

        [DataTestMethod]
        [DataRow("Panthers", true)]
        [DataRow("Steelers", false)]
        public void UpdateExistingContent_ShouldMatchGivenBool(string originalName, bool shouldUpdate)
        {
            //Arrange
            List<string> list2 = new List<string>();
            list2.Add("Abe Lincoln");
            list2.Add("Teddy Roosevelt");
            DevTeam newDevTeam = new DevTeam("Patriots", 776, list2);
            //Act
            bool updateResult = _repo.UpdateExistingDevTeam(originalName, newDevTeam);
            //Assert
            Assert.AreEqual(shouldUpdate, updateResult);
        }
        [TestMethod]
        public void DeleteContent_ShouldReturnTrue()
        {
            //Act
            bool deleteResult = _repo.RemoveDevTeamFromList(_devteam.TeamName);
            //Assert
            Assert.IsTrue(deleteResult);
        }
        [DataTestMethod]
        [DataRow("Panthers", true)]
        [DataRow("Colts", false)]
        public void DeleteContent_ShouldMatchGivenBool(string originalName, bool shouldDelete)
        {
            //Arrange
            bool deleteResult = _repo.RemoveDevTeamFromList(originalName);
            //Assert
            Assert.AreEqual(shouldDelete, deleteResult);
        }
    }
}
