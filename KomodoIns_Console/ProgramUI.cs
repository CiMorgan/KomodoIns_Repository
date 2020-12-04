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
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        //Display all developers
        private void DisplayAllDevelopers()
        {
            Console.Clear();
            List<Developer> listOfDevelopers = _developerRepo.GetDeveloperList();

            foreach (Developer developer in listOfDevelopers)
            {
                Console.WriteLine($"Name: {developer.Name}\n" +
                    $"ID number: {developer.IDnumber}\n");
            }
        }
        //Add new developer
        private void AddNewDeveloper()
        {
            Developer newDeveloper = new Developer();
            List<Developer> listOfDevelopers = _developerRepo.GetDeveloperList();
            Console.Clear();
            //name
            Console.WriteLine("Enter the developer's name:");
            newDeveloper.Name = Console.ReadLine();
            //ID number
            Console.WriteLine("Does the developer have an ID number?\n" +
                "1. Yes: the developer has an ID number\n" +
                "2. No: the developer needs an ID number\n" +
                "Enter 1 or 2");
            string IDnum = Console.ReadLine();

            bool NotValidID = true;
            int tempID = 1;
            while (NotValidID)
            {
                if (tempID == 1)
                {
                    if (IDnum == "1")
                    {
                        Console.WriteLine("Enter the developer's IDnumber:");
                        tempID = int.Parse(Console.ReadLine());
                    }
                    else
                    {
                        Random rnd = new Random();
                        tempID = rnd.Next(100001, 999999);
                    }
                }
                foreach (Developer developer in listOfDevelopers)
                {
                    if (tempID == developer.IDnumber)
                    {
                        Console.WriteLine("That ID number is already in use.\n" +
                                          "A new ID number will be assigned.");
                        tempID = 1;
                        IDnum = "2";
                        NotValidID = true;
                    }
                    else
                    {
                        newDeveloper.IDnumber = tempID;
                        NotValidID = false;
                    }
                }
            }
            Console.WriteLine($"{newDeveloper.Name}'s ID number is {newDeveloper.IDnumber}.");
            //Pluralsight
            Console.WriteLine("Does the developer have a Pluralsight license?\n" +
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
            Console.WriteLine($"Name: {newDeveloper.Name}\n" +
                              $"ID number: {newDeveloper.IDnumber}\n" +
                              $"Pluralsight: {newDeveloper.AccessToPluralsight}");
        }
        //Remove developer
        private void RemoveDeveloper()
        {
            Console.Clear();
            DisplayAllDevelopers();
            Console.WriteLine("Enter the developer's name to be deleted:");
            string deleteDeveloper = Console.ReadLine();
            Console.WriteLine($"Confirm that {deleteDeveloper} should be deleted?\n" +
                $"1. Delete user\n" +
                $"2. Do not delete user");
            string delInput = Console.ReadLine();
            bool wasDeleted = false;
            bool delete = false;
            if (delInput == "1")
            {
                List<Developer> listOfDevelopers = _developerRepo.GetDeveloperList();
                foreach (Developer developer in listOfDevelopers)
                {
                    if (developer.Name == deleteDeveloper)
                    {
                        delete = true;
                    }
                }
                if (delete)
                {
                    wasDeleted = _developerRepo.RemoveDeveloperFromList(deleteDeveloper);
                }
                if (wasDeleted)    
                {
                    Console.WriteLine($"Developer {deleteDeveloper} was deleted.");
                }
                else
                {
                    Console.WriteLine($"Developer {deleteDeveloper} was not deleted.");
                }
            }
        }
        //Display all developers with pluralsight
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
        //Display all developers without pluralsight
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
            Console.WriteLine("To what team should the developer be added?");
            string addTeamInput = Console.ReadLine();
            DisplayAllDevelopers();
            Console.WriteLine($"Enter ID number of developer that will be added to {addTeamInput}?");
            int memberToAdd = int.Parse(Console.ReadLine());
            bool added = false;
            while (!added)
            {
                foreach (DevTeam devteam in listOfDevTeams)
                {
                    if (devteam.TeamName == addTeamInput)
                    {
                        foreach (Developer developer in listOfDevelopers)
                            if (developer.IDnumber == memberToAdd)
                            {
                                devteam.Members.Add(developer.Name);
                                Console.WriteLine($"{developer.Name} has been added to {addTeamInput}.");
                                added = true;
                            }
                    }
                }
            }
            
        }
        //Remove developer from team
        private void TeamRemoveDeveloper()
        {
            Console.Clear();
            List<DevTeam> listOfDevTeams = _devTeamRepo.GetDevTeamList();
            TeamDisplay();
            Console.WriteLine("To what team should the developer be removed?");
            string removeTeamInput = Console.ReadLine();
            TeamDisplayMembers();
            Console.WriteLine($"Which developer should be removed from {removeTeamInput}?");
            string removeTeamMember = Console.ReadLine();
            bool delete = false;

            foreach (DevTeam devteam in listOfDevTeams)
            {
                if (devteam.TeamName == removeTeamInput)
                {
                    for (int i = 0; i < devteam.Members.Count; i++)
                    {
                        if (devteam.Members[i] == removeTeamMember)
                        {
                            devteam.Members.Remove(removeTeamMember);
                            delete = _devTeamRepo.UpdateExistingDevTeam(removeTeamInput, devteam);
                        }
                    }
                }
            }
            if (delete)
            {
                Console.WriteLine($"Developer {removeTeamMember} was deleted from {removeTeamInput}.");
            }
            else
            {
                Console.WriteLine($"Developer {removeTeamMember} was not deleted from {removeTeamInput}.");
            }
        }
        //Display team members
        private void TeamDisplayMembers()
        {
            Console.Clear();
            List<DevTeam> listOfDevTeams = _devTeamRepo.GetDevTeamList();
            TeamDisplay();
            Console.WriteLine("Display the team members for which of the above team?");
            string displayTeamInput = Console.ReadLine();

            foreach (DevTeam devTeam in listOfDevTeams)
            {
                if (devTeam.TeamName == displayTeamInput)
                {
                    for(int i = 0; i < devTeam.Members.Count; i++)
                    {
                        Console.WriteLine(devTeam.Members[i]);
                    }
                    
                }
                
            }
        }
        //Display teams
        private void TeamDisplay()
        {
            Console.Clear();
            List<DevTeam> listOfDevTeams = _devTeamRepo.GetDevTeamList();

            foreach (DevTeam devTeam in listOfDevTeams)
            {
                Console.WriteLine($"Team Name: {devTeam.TeamName}");
            }
        }
        //Create team
        private void CreateTeam()
        {
            DevTeam newDevTeam = new DevTeam();
            List<DevTeam> listOfDevTeams = _devTeamRepo.GetDevTeamList();
            Console.Clear();
            //name
            Console.WriteLine("Enter the name of the new developer team:");
            string newName = Console.ReadLine();

            bool NotValidID = true;
            int tempID;
            int newNumber = 000;
            while (NotValidID)
            {
                Random rnd = new Random();
                tempID = rnd.Next(101, 999);
                foreach (DevTeam devteam in listOfDevTeams)
                {
                    if (tempID != devteam.TeamNumber)
                    {
                        newNumber = tempID;
                        NotValidID = false;
                    }
                }
            }

            string addDev = "1";
            Console.WriteLine($"Would you like to add a developers to Team {newName}?\n" +
                  $"1. Yes\n" +
                  $"2. No");
            addDev = Console.ReadLine();
            List<string> memberList = new List<string>();
            while (addDev == "1") 
            {
                Console.Clear();
                DisplayAllDevelopers();
                Console.WriteLine($"Which developers would you like to add to Team {newName}?");
                string addName = Console.ReadLine();
                memberList.Add(addName);
                Console.WriteLine($"Name: {newName}\n" +
                  $"Number: {newNumber}\n" +
                  $"Members:");
                for (int i = 0; i < memberList.Count; i++)
                {
                    Console.WriteLine(memberList[i]);
                }
                Console.WriteLine($"Would you like to another developer to Team {newName}?\n" +
                  $"1. Yes\n" +
                  $"2. No");
                addDev = Console.ReadLine();
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
    }
}
