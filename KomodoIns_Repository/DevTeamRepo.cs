using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoIns_Repository
{
    public class DevTeamRepo
    {
        private List<DevTeam> _listOfDevTeams = new List<DevTeam>();
        //Create
        public void AddDevTeamToList(DevTeam devTeam)
        {
            _listOfDevTeams.Add(devTeam);
        }
        //Read
        public List<DevTeam> GetDevTeamList()
        {
            return _listOfDevTeams;
        }
        //Update
        public bool UpdateExistingDevTeam(string originalName, DevTeam newDevTeam)
        {
            DevTeam oldDevTeam = GetDevTeamByName(originalName);

            if (oldDevTeam != null)
            {
                oldDevTeam.TeamName = newDevTeam.TeamName;
                oldDevTeam.TeamNumber = newDevTeam.TeamNumber;
                oldDevTeam.Members = newDevTeam.Members;

                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete - returns false
        public bool RemoveDevTeamFromList(string name)
        {
            DevTeam devTeam = GetDevTeamByName(name);

            if (devTeam == null)
            {
                return false;
            }
            int initialCount = _listOfDevTeams.Count;
            _listOfDevTeams.Remove(devTeam);
            if (initialCount > _listOfDevTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Helper method - get DevTeam by name
        public DevTeam GetDevTeamByName(string name)
        {
            foreach (DevTeam devTeam in _listOfDevTeams)
            {
                if (devTeam.TeamName == name)
                {
                    return devTeam;
                }
            }
            return null;
        }
        public DevTeam GetDevTeamByID(int number)
        {
            foreach (DevTeam devTeam in _listOfDevTeams)
            {
                if (devTeam.TeamNumber == number)
                {
                    return devTeam;
                }
            }
            return null;
        }
    }
}
