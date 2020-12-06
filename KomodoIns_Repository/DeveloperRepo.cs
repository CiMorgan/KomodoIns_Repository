using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoIns_Repository
{
    public class DeveloperRepo
    {
        private List<Developer> _listOfDevelopers = new List<Developer>();

        //Create
        public void AddDeveloperToList(Developer developer)
        {
            _listOfDevelopers.Add(developer);
        }

        //Read
        public List<Developer> GetDeveloperList()
        {
            return _listOfDevelopers;
        }

        //Update
        public bool UpdateExistingDeveloper(string originalName, Developer newDeveloper)
        {
            Developer oldDeveloper = GetDeveloperByName(originalName);

            if (oldDeveloper != null)
            {
                oldDeveloper.Name = newDeveloper.Name;
                oldDeveloper.IDnumber = newDeveloper.IDnumber;
                oldDeveloper.AccessToPluralsight = newDeveloper.AccessToPluralsight;

                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool RemoveDeveloperFromList(string name)
        {
            Developer developer = GetDeveloperByName(name);

            if (developer == null)
            {
                return false;
            }
            int initialCount = _listOfDevelopers.Count;
            _listOfDevelopers.Remove(developer);
            if(initialCount > _listOfDevelopers.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Helper methods to search developers by name or ID number
        public Developer GetDeveloperByName(string name)
        {
            foreach(Developer developer in _listOfDevelopers)
            {
                if(developer.Name == name)
                {
                    return developer;
                }
            }
            return null;
        }
        public Developer GetDeveloperByID(int number)
        {
            foreach (Developer developer in _listOfDevelopers)
            {
                if (developer.IDnumber == number)
                {
                    return developer;
                }
            }
            return null;
        }
    }
}
