using KomodoIns_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoIns_Tests
{
    [TestClass]
    public class DeveloperRepoTests
    {
        private DeveloperRepo _repo;
        private Developer _developer;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new DeveloperRepo();
            _developer = new Developer("Elon Musk", 21716, false);

            _repo.AddDeveloperToList(_developer);
        }
        //Test Add Method
        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {
            Developer developer = new Developer();
            developer.Name = "Elon Musk";
            DeveloperRepo repository = new DeveloperRepo();

            repository.AddDeveloperToList(developer);
            Developer contentFromDirectory = repository.GetDeveloperByName("Elon Musk");

            Assert.IsNotNull(contentFromDirectory);
        }
        //Test Update Method
        [TestMethod]
        public void UpdateExistingDeveloper_ShouldReturnTrue()
        {
            Developer newDeveloper = new Developer("Elon Musk", 21716, true);
            bool updateResult = _repo.UpdateExistingDeveloper("Elon Musk", newDeveloper);
            Assert.IsTrue(updateResult);
        }

        [DataTestMethod]
        [DataRow("Elon Musk", true)]
        [DataRow("Wayne Gretzky", false)]
        public void UpdateExistingDeveloper_ShouldMatchGivenBool(string originalName, bool shouldUpdate)
        {
            Developer newDeveloper = new Developer("Elon Musk", 21716, true);
            bool updateResult = _repo.UpdateExistingDeveloper(originalName, newDeveloper);
            Assert.AreEqual(shouldUpdate, updateResult);
        }
        //Test Delete Method
        [TestMethod]
        public void DeleteDeveloper_ShouldReturnTrue()
        {
            bool deleteResult = _repo.RemoveDeveloperFromList(_developer.Name);
            Assert.IsTrue(deleteResult);
        }
        [DataTestMethod]
        [DataRow("Elon Musk", true)]
        [DataRow("Simon Musk", false)]
        public void DeleteDeveloper_ShouldMatchGivenBool(string deleteName, bool shouldDelete)
        {
            bool updateResult = _repo.RemoveDeveloperFromList(deleteName);
            Assert.AreEqual(shouldDelete, updateResult);
        }
    }
}
