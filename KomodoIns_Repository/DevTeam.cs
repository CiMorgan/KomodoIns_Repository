using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoIns_Repository
{
    public class DevTeam
    {
        public string TeamName { get; set; }
        public int TeamNumber { get; set; }
        public List<string> Members { get; set; }

        public DevTeam() { }

        public DevTeam(string teamName, int teamNumber, List<string> listOfMembers)
        {
            TeamName = teamName;
            TeamNumber = teamNumber;
            Members = listOfMembers;
        }
    }
}
