using KomodoIns_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoIns_Console
{
    class ProgramUI
    {
        private DeveloperRepo _developerRepo = new DeveloperRepo();
        private DevTeamRepo _devTeamRepo = new DevTeamRepo();
        public void Run()
        {
            EstablishedDevelopersList();
            EstablishedDevTeamList();
            Menu();
        }
        //Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //Display options to user
                Console.WriteLine("Select a menu option:\n" +
                    "1. Display all developers\n" +
                    "2. Add new developer\n" +
                    "3. Remove developer\n" +
                    "4. Display all developers with Pluralsight\n" +
                    "5. Display all developers without Pluralsight\n" +
                    "6. Add developer to team\n" +
                    "7. Remove developer from team\n" +
                    "8. Display team members\n" +
                    "9. Display teams\n" +
                    "10. Create team\n" +
                    "11. Exit");

                //Get user input
                string input = Console.ReadLine();

                //Evaluate user input and respond
                switch (input)
                {
                    case "1":
                        //display all developers
                        DisplayAllDevelopers();
                        break;
                    case "2":
                        //add developer
                        AddNewDeveloper();
                        break;
                    case "3":
                        //remove developer
                        RemoveDeveloper();
                        break;
                    case "4":
                        //display developers with pluralsight
                        DevelopersWithPluralsight();
                        break;
                    case "5":
                        //display developers without plural sight
                        DevelopersNoPluralsight();
                        break;
                    case "6":
                        //add developers to team
                        TeamAddDeveloper();
                        break;
                    case "7":
                        //remove developers from team
                        TeamRemoveDeveloper();
                        break;
                    case "8":
                        //display team members
                        TeamDisplayMembers();
                        break;
                    case "9":
                        //display teams
                        TeamDisplay();
                        break;
                    case "10":
                        //create team
                        CreateTeam();
                        break;
                    case "11":
                        //exit
                        Console.WriteLine("Goodbye");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.WriteLine("\nPlease press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        //1. Display all developers
        private void DisplayAllDevelopers()
        {
            List<Developer> listOfDevelopers = _developerRepo.GetDeveloperList();
            Console.WriteLine("\n");
            foreach (Developer developer in listOfDevelopers)
            {
                Console.WriteLine($"ID number: {developer.IDnumber}    Name: {developer.Name}\n");
            }
        }
        //2. Add new developer
        private void AddNewDeveloper()
        {
            Developer newDeveloper = new Developer();
            List<Developer> listOfDevelopers = _developerRepo.GetDeveloperList();
            Console.Clear();
            //Ask for new developer's name
            Console.WriteLine("Enter the developer's name:");
            newDeveloper.Name = Console.ReadLine();
            //Ask if new developer already has an ID number
            Console.WriteLine("Does the developer have an ID number?\n" +
                "1. Yes: the developer has an ID number\n" +
                "2. No: the developer needs an ID number\n" +
                "Enter 1 or 2");
            string IDnum = Console.ReadLine();
            bool NotValidID = true;
            int tempID = 1;      //initial tempID
            if (IDnum == "1")  //user will input new ID number
                {
                Console.WriteLine("Enter the developer's six-digit ID number:");
                tempID = int.Parse(Console.ReadLine());
                }
            else  //program will randomly generate a new ID number
                {
                tempID = RandomNumber(100001, 999999);
                }
            while (NotValidID)
            {
                foreach (Developer developer in listOfDevelopers)
                {
                    if (tempID == developer.IDnumber) //determine whether ID number is unique and if not, produce unique ID
                    {
                        Console.WriteLine("That ID number is already in use.\n" +
                                          "A new ID number will be assigned.\n");
                        tempID = RandomNumber(100001, 999999);
                    }
                }
                newDeveloper.IDnumber = tempID;
                NotValidID = false;
            }
            Console.WriteLine($"\n{newDeveloper.Name}'s ID number is {newDeveloper.IDnumber}.\n");
            //Pluralsight
            Console.WriteLine("\nDoes the developer have a Pluralsight license?\n" +
                "1. Yes: the developer has a Pluralsight license\n" +
                "2. No: the developer does NOT have a Pluralsight license\n" +
                "Enter 1 or 2");
            string psLicense = Console.ReadLine();
            switch (psLicense)
            {
                case "1":
                    newDeveloper.AccessToPluralsight = true;
                    break;
                case "2":
                    newDeveloper.AccessToPluralsight = false;
                    break;
            }

            _developerRepo.AddDeveloperToList(newDeveloper);
            Console.WriteLine($"The following developer has been added:\n" +
                              $"    Name: {newDeveloper.Name}\n" +
                              $"    ID number: {newDeveloper.IDnumber}\n" +
                              $"    Pluralsight: {newDeveloper.AccessToPluralsight}");
        }
        //3. Remove developer
        private void RemoveDeveloper()
        {
            Console.Clear();
            DisplayAllDevelopers();
            Console.WriteLine("Enter the developer's ID number to be deleted:");
            int deleteDeveloper = int.Parse(Console.ReadLine());
            string delName = FindDeveloperByNumber(deleteDeveloper);
            if (delName != null)
            {
                Console.WriteLine($"Confirm that {delName} should be deleted?\n" +
                                  $"1. Delete user\n" +
                                  $"2. Do not delete user");
                string delInput = Console.ReadLine();
                bool wasDeleted = false;
                if (delInput == "1")
                {
                    wasDeleted = _developerRepo.RemoveDeveloperFromList(delName);
                }
                if (wasDeleted)
                {
                    Console.WriteLine($"Developer {delName} was deleted.");
                }
                else
                {
                    Console.WriteLine($"Developer {delName} was not deleted.");
                }
            }
            else
            {
                Console.WriteLine("That is not a valid ID number");
            }

        }
        //4. Display all developers with Pluralsight
        private void DevelopersWithPluralsight()
        {
            Console.Clear();
            List<Developer> listOfDevelopers = _developerRepo.GetDeveloperList();

            Console.WriteLine("The following developers have a Pluralsight license:");
            foreach (Developer developer in listOfDevelopers)
            {
                if (developer.AccessToPluralsight)
                {
                    Console.WriteLine(developer.Name);
                }
            }

        }
        //5. Display all developers without Pluralsight
        private void DevelopersNoPluralsight()
        {
            Console.Clear();
            List<Developer> listOfDevelopers = _developerRepo.GetDeveloperList();

            Console.WriteLine("The following developers do NOT have a Pluralsight license:");
            foreach (Developer developer in listOfDevelopers)
            {
                if (!developer.AccessToPluralsight)
                {
                    Console.WriteLine(developer.Name);
                }
            }
        }
        //#6 Add developer to team
        private void TeamAddDeveloper()
        {
            Console.Clear();
            List<DevTeam> listOfDevTeams = _devTeamRepo.GetDevTeamList();
            List<Developer> listOfDevelopers = _developerRepo.GetDeveloperList();
            TeamDisplay();
            Console.WriteLine("Add developers to which team? Please enter the team's ID number.");
            int addTeamInput = int.Parse(Console.ReadLine());
            string nameOfTeam;
            bool added = false;
            Console.Clear();
            foreach (DevTeam devteam in listOfDevTeams)
            {
                if (devteam.TeamNumber == addTeamInput)
                {
                    Console.WriteLine($"\n{devteam.TeamName} contains the following members:\n");
                    nameOfTeam = devteam.TeamName;
                    for (int i = 0; i < devteam.Members.Count; i++)
                    {
                        Console.WriteLine(devteam.Members[i]);
                    }
                    List<string> memberListName = new List<string>();
                    DisplayAllDevelopers();
                    while (!added)
                    {
                        Console.WriteLine("\nEnter the ID number of the developers you would like to add.\n" +
                                          "Press return / enter between each developer's ID number\n" +
                                          "Enter 'Done' when complete\n");
                        string addDevNum = Console.ReadLine();
                        while (addDevNum != "Done")
                        {
                            int addDevID = int.Parse(addDevNum);
                            Developer newDev = _developerRepo.GetDeveloperByID(addDevID);
                            memberListName.Add(newDev.Name);
                            addDevNum = Console.ReadLine();
                        }
                        added = true;
                    }
                    Console.WriteLine($"\nThe following developers were added to {devteam.TeamName}:\n");
                    for (int i = 0; i < memberListName.Count; i++)
                    {
                        Console.WriteLine(memberListName[i]);
                        devteam.Members.Add(memberListName[i]);
                    }
                    List<string> newList = devteam.Members;
                    DevTeam modDevTeam = new DevTeam(nameOfTeam, addTeamInput, newList);
                    added = _devTeamRepo.UpdateExistingDevTeam(nameOfTeam, modDevTeam);
                }
            }
            if (added)
            {
                Console.WriteLine("\nDevelopers have been successfully added to the team.");
            }
            else
            {
                Console.WriteLine("\nDevelopers were not added to the team.");
            }
        }
        //#7 Remove developer from team
        private void TeamRemoveDeveloper()
        {
            Console.Clear();
            List<DevTeam> listOfDevTeams = _devTeamRepo.GetDevTeamList();
            TeamDisplay();
            Console.WriteLine("Remove developers from which team? Please enter the team's ID number.");
            string strTeamNum = Console.ReadLine();
            int TeamNum = int.Parse(strTeamNum);
            List<string> removeList = new List<string>();
            bool removed = false;
            foreach (DevTeam devTeam in listOfDevTeams)
            {
                if (devTeam.TeamNumber == TeamNum)
                {
                    Console.WriteLine($"\n{devTeam.TeamName} contains the following members:\n");
                    if (devTeam.Members.Count == 0)
                    {
                        Console.WriteLine("This team has no members.");
                        removed = false;
                    }
                    else
                    {
                        for (int i = 0; i < devTeam.Members.Count; i++)
                        {
                            Developer remdev = _developerRepo.GetDeveloperByName(devTeam.Members[i]);
                            string name = remdev.Name;
                            int num = remdev.IDnumber;
                            Console.WriteLine($"{num}   {name}\n");
                        }
                        while (!removed)
                        {
                            Console.WriteLine("Which developer(s) would you like to delete?\n" +
                                              "Press return / enter between each developer's ID number\n" +
                                              "\nEnter 'Done' when complete\n");
                            string delDevNum = Console.ReadLine();
                            while (delDevNum != "Done")
                            {
                                int delDevID = int.Parse(delDevNum);
                                Developer removeDev = _developerRepo.GetDeveloperByID(delDevID);
                                removeList.Add(removeDev.Name);
                                delDevNum = Console.ReadLine();
                            }
                            removed = true;
                            }
                        Console.WriteLine($"\nThe following developers were removed from {devTeam.TeamName}:\n");
                        List<string> removeMembers = new List<string>();
                        for (int j = 0; j < removeList.Count; j++)
                        {
                            Console.WriteLine(removeList[j]);
                            devTeam.Members.Remove(removeList[j]);
                        }
                        List<string> upList = devTeam.Members;
                        DevTeam modDevTeam = new DevTeam(devTeam.TeamName, devTeam.TeamNumber, upList);
                        removed = _devTeamRepo.UpdateExistingDevTeam(devTeam.TeamName, modDevTeam);

                    }
                }
            }
            if (removed)
            {
                Console.WriteLine("\nDevelopers have been successfully removed the team.");
            }
            else
            {
                Console.WriteLine("\nDevelopers were not removed the team.");
            }
        }

        //8. Display team members
        private void TeamDisplayMembers()
        {
            List<DevTeam> listOfDevTeams = _devTeamRepo.GetDevTeamList();
            TeamDisplay();
            Console.WriteLine("Enter the ID number for the team?");
            string displayTeamInput = Console.ReadLine();
            foreach (DevTeam devTeam in listOfDevTeams)
            {
                int teamID = int.Parse(displayTeamInput);
                if (devTeam.TeamNumber == teamID)
                {
                    string Tname = devTeam.TeamName;
                    Console.WriteLine($"\nTeam {Tname} contains the following members:\n");
                    for(int i = 0; i < devTeam.Members.Count; i++)
                    {
                        Console.WriteLine(devTeam.Members[i]);
                    }    
                }  
            }
        }
        //9. Display teams
        private void TeamDisplay()
        {
            Console.Clear();
            List<DevTeam> listOfDevTeams = _devTeamRepo.GetDevTeamList();
            foreach (DevTeam devTeam in listOfDevTeams)
            {
                Console.WriteLine($"Team Number: {devTeam.TeamNumber}    Team Name: {devTeam.TeamName}\n");
            }
        }
        //10. Create team
        private void CreateTeam()
        {
            DevTeam newDevTeam = new DevTeam();
            List<DevTeam> listOfDevTeams = _devTeamRepo.GetDevTeamList();
            List<Developer> listOfDevelopers = _developerRepo.GetDeveloperList();
            Console.Clear();
            //name
            Console.WriteLine("Enter the name of the new developer team:");
            string newName = Console.ReadLine();

            bool NotValidID = true;
            int tempID;
            int newNumber = 000;
            while (NotValidID)
            {
                tempID = RandomNumber(101, 999);
                foreach (DevTeam devteam in listOfDevTeams)
                {
                    if (tempID == devteam.TeamNumber)
                    {
                        tempID = RandomNumber(101, 999);
                    }
                }
                newNumber = tempID;
                NotValidID = false;
            }
            string addDev = "1";
            Console.WriteLine($"Would you like to add developers to {newName}?\n" +
                  $"1. Yes\n" +
                  $"2. No");
            addDev = Console.ReadLine();
            List<int> memberListNum = new List<int>();
            if (addDev == "1") 
            {
                Console.Clear();
                DisplayAllDevelopers();
                Console.WriteLine("Enter the ID numbers of the developers you would like to add.\n" +
                    "Press return / enter between each developer's ID number\n" +
                    "Enter 'Done' when complete\n");
                string addDevNum = Console.ReadLine();
                while(addDevNum != "Done")
                {
                    int intID = int.Parse(addDevNum);
                    memberListNum.Add(intID);
                    addDevNum = Console.ReadLine(); 
                }
            }  
            List<string> memberList = new List<string>();
            foreach (int newID in memberListNum)
            {
                
                Developer newMember = _developerRepo.GetDeveloperByID(newID);
                memberList.Add(newMember.Name);
            }
            DevTeam newDev = new DevTeam(newName, newNumber, memberList);
            _devTeamRepo.AddDevTeamToList(newDev);
        }

        //See method
        private void EstablishedDevelopersList()
        {
            Developer dev1 = new Developer("Patrick Jane", 236984, false);
            Developer dev2 = new Developer("Elon Musk", 782472, true);
            Developer dev3 = new Developer("Aaron Swift", 899672, false);
            Developer dev4 = new Developer("Milly Ge", 213848, false);
            Developer dev5 = new Developer("Don Trump", 168923, true);
            Developer dev6 = new Developer("Ben Sharp", 672291, true);
            Developer dev7 = new Developer("Vanessa Tore", 762156, true);
            Developer dev8 = new Developer("Candance Oswald", 562984, false);

            _developerRepo.AddDeveloperToList(dev1);
            _developerRepo.AddDeveloperToList(dev2);
            _developerRepo.AddDeveloperToList(dev3);
            _developerRepo.AddDeveloperToList(dev4);
            _developerRepo.AddDeveloperToList(dev5);
            _developerRepo.AddDeveloperToList(dev6);
            _developerRepo.AddDeveloperToList(dev7);
            _developerRepo.AddDeveloperToList(dev8);
        }

        private void EstablishedDevTeamList()
        {
            List<string> list1 = new List<string>();
            list1.Add("Vanessa Tore");
            list1.Add("Patrick Jane");

            List<string> list2 = new List<string>();
            list2.Add("Milly Ge");
            list2.Add("Patrick Jane");
            list2.Add("Don Trump");

            List<string> list3 = new List<string>();
            list3.Add("Candance Oswald");

            List<string> list4 = new List<string>();
            list4.Add("Ben Sharp");

            DevTeam devteam1 = new DevTeam("Cobras", 123, list1);
            DevTeam devteam2 = new DevTeam("Scorpions", 421, list2);
            DevTeam devteam3 = new DevTeam("Black Adder", 659, list3);
            DevTeam devteam4 = new DevTeam("Diamond Backs", 216, list4);

            _devTeamRepo.AddDevTeamToList(devteam1);
            _devTeamRepo.AddDevTeamToList(devteam2);
            _devTeamRepo.AddDevTeamToList(devteam3);
            _devTeamRepo.AddDevTeamToList(devteam4);

        }
        public int RandomNumber(int min, int max)
        {
            Random rnd = new Random();
            int tempNum = rnd.Next(min, max);
            return tempNum;
        }
        public string FindDeveloperByNumber(int iDnumber)
        {
            List<Developer> listOfDevelopers = _developerRepo.GetDeveloperList();
            foreach (Developer developer in listOfDevelopers)
            {
                if (developer.IDnumber == iDnumber)
                {
                    return developer.Name;
                }
            }
            return null;
        }
    }
}
