using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.SetWindowSize(100, 40);

            DisplayWelcomeScreen();
            DisplayMainMenu();
            DisplayClosingScreen();
        }

        static void DisplayMainMenu()
        {
            // menu variables	
            bool loop = true;
            int userChoice;

            // application variables
            List<SeaMonster> AllSeaMonsters = new List<SeaMonster> { };
            List<SpaceMonster> AllSpaceMonsters = new List<SpaceMonster> { };

            SeaMonster mySeaMonster;
            SpaceMonster mySpaceMonster;

            AllSeaMonsters = InitializeSeaMonster(AllSeaMonsters);
            //AllSeaMonsters.Add(mySeaMonster);

            mySpaceMonster = InitializeSpaceMonster();
            AllSpaceMonsters.Add(mySpaceMonster);

            do
            {
                do
                {
                    DisplayHeader("MAIN MENU");
                    Console.WriteLine();
                    LeftJustifyText(" 1) Display All Monster Info", 63);
                    LeftJustifyText(" 2) Monster Editing Menu", 63);
                    LeftJustifyText(" 3) Exit", 63);
                    Console.WriteLine();
                    CenterText(" Please type your selection's number, then press enter. ", 57);

                } while (!int.TryParse(Console.ReadLine(), out userChoice) && userChoice > 0 && userChoice <= 3);

                

                switch (userChoice)
                {                    
                    case 1:
                        DisplayMonsterInfoScreen(AllSeaMonsters, AllSpaceMonsters);
                        break;

                    case 2:
                        bool loop2 = true;

                        do
                        {
                            do
                            {
                                DisplayHeader("MONSTER EDITING MENU");
                                Console.WriteLine();

                                LeftJustifyText(" 1) Sea Monsters", 63);
                                LeftJustifyText(" 2) Space Monsters", 63);
                                LeftJustifyText(" 3) Return to Main Menu", 63);

                                CenterText(" Please type your selection's number, then press enter. ", 57);

                            } while (!int.TryParse(Console.ReadLine(), out userChoice) && userChoice > 0 && userChoice <= 3);



                            switch (userChoice)
                            {
                                case 1:
                                    AllSeaMonsters = DisplaySeaMonsterEditingMenu(AllSeaMonsters);
                                    break;

                                case 2:
                                    AllSpaceMonsters = DisplaySpaceMonsterEditingMenu(AllSpaceMonsters);
                                    break;

                                case 3:
                                    loop2 = false; break;
                            }
                        } while (loop2);
                        break;

                    case 3:
                        loop = false; break;
                }

            } while (loop);
        }



        // App Methods
        private static void DisplayMonsterInfoScreen(List<SeaMonster> SeaMonsterList, List<SpaceMonster> SpaceMonsterList)
        {
            DisplayHeader("ALL MONSTER INFO");
            Console.WriteLine();

            DisplaySeaMonsterInfo(SeaMonsterList);
            DisplaySpaceMonsterInfo(SpaceMonsterList);

            DisplayUserPause("continue");
        }



        // Sea Monster Methods
        static List<SeaMonster> InitializeSeaMonster(List<SeaMonster> AllSeaMonsters) // Create a new SeaMonster
        {
            SeaMonster seaMonster = new SeaMonster();

            seaMonster.Id = 34;
            seaMonster.Name = "Suzy";
            seaMonster.Age = 473;
            seaMonster.Height = 300;
            seaMonster.Weight = 9000;
            seaMonster.Color = "Light Blue";
            seaMonster.EatHumans = false;
            seaMonster.PlaysGolf = true;
            seaMonster.HasGills = true;
            seaMonster.HomeSea = "Baltic Sea";

            AllSeaMonsters.Add(seaMonster);

            SeaMonster seaMonster2 = new SeaMonster();

            seaMonster2.Id = 19;
            seaMonster2.Name = "Fred";
            seaMonster2.Age = 1320;
            seaMonster2.Height = 3590;
            seaMonster2.Weight = 20000;
            seaMonster2.Color = "Dark Yellow";
            seaMonster2.EatHumans = true;
            seaMonster2.PlaysGolf = true;
            seaMonster2.HasGills = true;
            seaMonster2.HomeSea = "Red Sea";

            AllSeaMonsters.Add(seaMonster2);

            return AllSeaMonsters;
        }

        private static void DisplaySeaMonsterInfo(List<SeaMonster> SeaMonsterList)
        {
            int cursorX = Console.CursorLeft;
            int cursorY = Console.CursorTop;
            int cursorOrigY = Console.CursorTop + 3;
            int xSpacing = 25;
            int ySpacing = 12;

            Console.ForegroundColor = ConsoleColor.Cyan;
            CenterText("Sea Monsters");
            Console.WriteLine();
            Console.Write(" ");
            Console.Write(string.Concat(Enumerable.Repeat("-", Console.WindowWidth - 2)));
            Console.Write("\n");

            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (SeaMonster monster in SeaMonsterList)
            {
                cursorY = cursorOrigY;

                Console.SetCursorPosition(cursorX, cursorY++);
                Console.WriteLine($" Name: {monster.Name}");

                Console.SetCursorPosition(cursorX, cursorY++);
                Console.WriteLine($" ID: {monster.Id}");

                Console.SetCursorPosition(cursorX, cursorY++);
                Console.WriteLine($" Age: {monster.Age}");

                Console.SetCursorPosition(cursorX, cursorY++);
                Console.WriteLine($" Height: {monster.Height}");

                Console.SetCursorPosition(cursorX, cursorY++);
                Console.WriteLine($" Weight: {monster.Weight}");

                Console.SetCursorPosition(cursorX, cursorY++);
                Console.WriteLine($" Color: {monster.Color}");

                Console.SetCursorPosition(cursorX, cursorY++);
                Console.WriteLine($" Eats Humans?: {(monster.EatHumans ? "Yes" : "No")}");

                Console.SetCursorPosition(cursorX, cursorY++);
                Console.WriteLine($" Plays Golf?: {(monster.PlaysGolf ? "Yes" : "No")}");

                Console.SetCursorPosition(cursorX, cursorY++);
                Console.WriteLine($" Is Happy?: {(monster.IsHappy() ? "Yes" : "No")}"); // Displays "Yes" if true, "No" if false.

                Console.SetCursorPosition(cursorX, cursorY++);
                Console.WriteLine($" Has Gills?: {(monster.HasGills ? "Yes" : "No")}");

                Console.SetCursorPosition(cursorX, cursorY++);
                Console.WriteLine($" Home Sea: {monster.HomeSea}");

                Console.SetCursorPosition(cursorX, cursorY++);
                Console.WriteLine();

                cursorX += xSpacing;
                if (cursorX >= 100)
                {
                    cursorX = 0;
                    cursorOrigY += ySpacing;
                }
            }
            Console.WriteLine();
        }

        private static List<SeaMonster> DisplayEditSeaMonster(List<SeaMonster> AllSeaMonsters) 
        {
            int selectedMonsterIndex = GetSeaMonsterIndex(AllSeaMonsters, "Edit");
            int userInt;
            bool userBool;
            bool isValid = true;

            DisplayHeader($"Edit Sea Monster: {AllSeaMonsters[selectedMonsterIndex].Name}");
            Console.WriteLine();

            do
            {
                isValid = true;

                Console.Write($" Current ID: {AllSeaMonsters[selectedMonsterIndex].Id}".PadLeft(40));
                Console.Write(" New ID: ".PadLeft(30));
                if (!int.TryParse(Console.ReadLine(), out userInt))
                {
                    CenterText("That is not a valid entry. Please try again with an integer. \n");
                    isValid = false;
                }
                else
                {
                    AllSeaMonsters[selectedMonsterIndex].Id = userInt;
                }

            } while (!isValid); // Get ID

            Console.Write($" Current Name: {AllSeaMonsters[selectedMonsterIndex].Name}".PadLeft(40));
            Console.Write(" New Name: ".PadLeft(30));
            AllSeaMonsters[selectedMonsterIndex].Name = Console.ReadLine();

            do
            {
                isValid = true;

                Console.Write($" Current Age: {AllSeaMonsters[selectedMonsterIndex].Age}".PadLeft(40));
                Console.Write(" New Age: ".PadLeft(30));
                if (!int.TryParse(Console.ReadLine(), out userInt))
                {
                    CenterText("That is not a valid entry. Please try again with an integer. \n");
                    isValid = false;
                }
                else
                {
                    AllSeaMonsters[selectedMonsterIndex].Age = userInt;
                    isValid = true;
                }

            } while (!isValid); // Get Age

            do
            {
                isValid = true;

                Console.Write($" Current Height: {AllSeaMonsters[selectedMonsterIndex].Height}".PadLeft(40));
                Console.Write(" New Height: ".PadLeft(30));
                if (!int.TryParse(Console.ReadLine(), out userInt))
                {
                    CenterText("That is not a valid entry. Please try again with an integer. \n");
                    isValid = false;
                }
                else
                {
                    AllSeaMonsters[selectedMonsterIndex].Height = userInt;
                    isValid = true;
                }

            } while (!isValid); // Get Height

            do
            {
                isValid = true;

                Console.Write($" Current Weight: {AllSeaMonsters[selectedMonsterIndex].Weight}".PadLeft(40));
                Console.Write(" New Weight: ".PadLeft(30));
                if (!int.TryParse(Console.ReadLine(), out userInt))
                {
                    CenterText("That is not a valid entry. Please try again with an integer. \n");
                    isValid = false;
                }
                else
                {
                    AllSeaMonsters[selectedMonsterIndex].Weight = userInt;
                    isValid = true;
                }

            } while (!isValid); // Get Weight

            Console.Write($" Current Color: {AllSeaMonsters[selectedMonsterIndex].Color}".PadLeft(40));
            Console.Write(" New Color: ".PadLeft(30));
            AllSeaMonsters[selectedMonsterIndex].Color = Console.ReadLine();

            do
            {
                isValid = true;

                Console.Write($" Current 'Eats Humans?': {AllSeaMonsters[selectedMonsterIndex].EatHumans}".PadLeft(40));
                Console.Write(" New 'Eats Humans?': ".PadLeft(30));
                if (!bool.TryParse(Console.ReadLine(), out userBool))
                {
                    CenterText("That is not a valid entry. Please try again with 'true' or 'false'. \n");
                    isValid = false;
                }
                else
                {
                    AllSeaMonsters[selectedMonsterIndex].EatHumans = userBool;
                    isValid = true;
                }

            } while (!isValid); // Get Eats Humans


            do
            {
                isValid = true;

                Console.Write($" Current 'Plays Golf?': {AllSeaMonsters[selectedMonsterIndex].PlaysGolf}".PadLeft(40));
                Console.Write(" New 'Plays Golf?': ".PadLeft(30));
                if (!bool.TryParse(Console.ReadLine(), out userBool))
                {
                    CenterText("That is not a valid entry. Please try again with 'true' or 'false'. \n");
                    isValid = false;
                }
                else
                {
                    AllSeaMonsters[selectedMonsterIndex].PlaysGolf = userBool;
                    isValid = true;
                }

            } while (!isValid); // Get Plays Golf

            do
            {
                isValid = true;

                Console.Write($" Current 'Has Gills?': {AllSeaMonsters[selectedMonsterIndex].HasGills}".PadLeft(40));
                Console.Write(" New 'Has Gills?': ".PadLeft(30));
                if (!bool.TryParse(Console.ReadLine(), out userBool))
                {
                    CenterText("That is not a valid entry. Please try again with 'true' or 'false'. \n");
                    isValid = false;
                }
                else
                {
                    AllSeaMonsters[selectedMonsterIndex].HasGills = userBool;
                    isValid = true;
                }

            } while (!isValid); // Get Has Gills

            Console.Write($" Current Home Sea: {AllSeaMonsters[selectedMonsterIndex].HomeSea}".PadLeft(40));
            Console.Write(" New Home Sea: ".PadLeft(30));
            AllSeaMonsters[selectedMonsterIndex].HomeSea = Console.ReadLine();

            return AllSeaMonsters;
        }

        static SeaMonster DisplayAddNewSeaMonster() // User creates a new SeaMonster.
        {
            SeaMonster userSeaMonster = new SeaMonster();
            int userInt;
            bool userBool;
            bool isValid = true;

            DisplayHeader("Add New Sea Monster");
            Console.WriteLine();

            do
            {
                isValid = true;

                CenterPadText(" New ID: ".PadLeft(30));
                if (!int.TryParse(Console.ReadLine(), out userInt))
                {
                    CenterText("That is not a valid entry. Please try again with an integer. \n");
                    isValid = false;
                }
                else
                {
                    userSeaMonster.Id = userInt;
                }

            } while (!isValid); // Get ID

            CenterPadText("New Name: ");
            userSeaMonster.Name = Console.ReadLine();

            do
            {
                isValid = true;

                CenterPadText(" New Age: ".PadLeft(30));
                if (!int.TryParse(Console.ReadLine(), out userInt))
                {
                    CenterText("That is not a valid entry. Please try again with an integer. \n");
                    isValid = false;
                }
                else
                {
                    userSeaMonster.Age = userInt;
                }

            } while (!isValid); // Get Age

            do
            {
                isValid = true;

                CenterPadText(" New Height: ".PadLeft(30));
                if (!int.TryParse(Console.ReadLine(), out userInt))
                {
                    CenterText("That is not a valid entry. Please try again with an integer. \n");
                    isValid = false;
                }
                else
                {
                    userSeaMonster.Height = userInt;
                }

            } while (!isValid); // Get Height

            do
            {
                isValid = true;

                CenterPadText(" New Weight: ".PadLeft(30));
                if (!int.TryParse(Console.ReadLine(), out userInt))
                {
                    CenterText("That is not a valid entry. Please try again with an integer. \n");
                    isValid = false;
                }
                else
                {
                    userSeaMonster.Weight = userInt;
                }

            } while (!isValid); // Get ID

            CenterPadText("New Color: ");
            userSeaMonster.Color = Console.ReadLine();

            do
            {
                isValid = true;

                CenterPadText(" New 'Eats Humans?': ".PadLeft(30));
                if (!bool.TryParse(Console.ReadLine(), out userBool))
                {
                    CenterText("That is not a valid entry. Please try again with 'true' or 'false'. \n");
                    isValid = false;
                }
                else
                {
                    userSeaMonster.EatHumans = userBool;
                    isValid = true;
                }

            } while (!isValid); // Get Eats Humans

            do
            {
                isValid = true;

                CenterPadText(" New 'Plays Golf?': ".PadLeft(30));
                if (!bool.TryParse(Console.ReadLine(), out userBool))
                {
                    CenterText("That is not a valid entry. Please try again with 'true' or 'false'. \n");
                    isValid = false;
                }
                else
                {
                    userSeaMonster.PlaysGolf = userBool;
                    isValid = true;
                }

            } while (!isValid); // Get Plays Golf

            do
            {
                isValid = true;

                CenterPadText(" New 'Has Gills?': ".PadLeft(30));
                if (!bool.TryParse(Console.ReadLine(), out userBool))
                {
                    CenterText("That is not a valid entry. Please try again with 'true' or 'false'. \n");
                    isValid = false;
                }
                else
                {
                    userSeaMonster.HasGills = userBool;
                    isValid = true;
                }

            } while (!isValid); // Get Has Gills

            CenterPadText("New Home Sea: ");
            userSeaMonster.HomeSea = Console.ReadLine();

            return userSeaMonster;
        }

        static List<SeaMonster> DisplayDeleteSeaMonster(List<SeaMonster> AllSeaMonsters)
        {
            int selectedMonsterIndex = 0;

            selectedMonsterIndex = GetSeaMonsterIndex(AllSeaMonsters, "Delete");

            DisplayHeader($"{AllSeaMonsters[selectedMonsterIndex].Name} was successfully deleted.");
            DisplayUserPause("return to Sea Monster Editing Menu");

            AllSeaMonsters.RemoveAt(selectedMonsterIndex);

            return AllSeaMonsters;
        }

        static List<SeaMonster> DisplaySeaMonsterEditingMenu(List<SeaMonster> AllSeaMonsters)
        {
            int userChoice;
            bool loop = true;

            do
            {
                do
                {
                    DisplayHeader("SEA MONSTER EDITING MENU");
                    Console.WriteLine();

                    LeftJustifyText(" 1) View All Sea Monsters", 63);
                    LeftJustifyText(" 2) Add New", 63);
                    LeftJustifyText(" 3) Edit", 63);
                    LeftJustifyText(" 4) Delete", 63);
                    LeftJustifyText(" 5) Return to Monster Editing Menu", 63);

                    CenterText(" Please type your selection's number, then press enter. ", 57);

                } while (!int.TryParse(Console.ReadLine(), out userChoice) && userChoice > 0 && userChoice <= 5);

                switch (userChoice)
                {
                    case 1:
                        DisplayHeader("Sea Monster Info");
                        DisplaySeaMonsterInfo(AllSeaMonsters);
                        DisplayUserPause("continue");
                        break;

                    case 2:
                        SeaMonster userSeaMonster = DisplayAddNewSeaMonster();
                        AllSeaMonsters.Add(userSeaMonster);
                        break;

                    case 3:
                        AllSeaMonsters = DisplayEditSeaMonster(AllSeaMonsters);

                        break;

                    case 4:
                        AllSeaMonsters = DisplayDeleteSeaMonster(AllSeaMonsters);
                        break;

                    case 5:
                        loop = false; 
                        break;
                }
            } while (loop);



            return AllSeaMonsters;
        }

        static int GetSeaMonsterIndex(List<SeaMonster> AllSeaMonsters, string Edit_Delete)
        {
            List<string> monsterNames = new List<string> { };
            string userChoice;
            int selectedMonsterIndex = 0;
            bool loop = true;


            foreach (SeaMonster seaMonster in AllSeaMonsters) // creates a list of Monster Names to be used later in the validation if-block.
            {
                monsterNames.Add(seaMonster.Name);
            }

            do
            {
                DisplayHeader($"{Edit_Delete} a Sea Monster");
                DisplaySeaMonsterInfo(AllSeaMonsters);

                CenterText("Type the Name of the SeaMonster");
                CenterText("you wish to select (Case-Sensitive): ");
                userChoice = Console.ReadLine();

                // This if-block validates that the user chose an actual Monster Name
                if (monsterNames.Contains(userChoice)) // Checks input against list of names
                {
                    foreach (string name in monsterNames) // Gets index of the selected monster if name choice is valid
                    {
                        if (name == userChoice)
                        {
                            selectedMonsterIndex = monsterNames.IndexOf(name);

                            loop = false;
                        }
                    }
                }

                else
                {
                    CenterText($"{userChoice} is not a valid entry. Please try again.");
                    DisplayUserPause("continue");
                }

            } while (loop);

            return selectedMonsterIndex;
        }



        // Space Monster Methods
        static SpaceMonster InitializeSpaceMonster() // Create a new SpaceMonster
        {
            return new SpaceMonster()
            {
                Id = 56,
                Name = "Sid",
                Age = 18,
                Height = 800,
                Weight = 16000,
                Color = "Maroon",
                EatHumans = true,
                PlaysGolf = true,
                Galaxy = "Andromeda"
            };
        }

        private static void DisplaySpaceMonsterInfo(List<SpaceMonster> SpaceMonsterList)
        {
            int cursorX = Console.CursorLeft;
            int cursorY = Console.CursorTop;
            int cursorOrigY = Console.CursorTop + 3;
            int xSpacing = 25;
            int ySpacing = 12;

            Console.ForegroundColor = ConsoleColor.Yellow;
            CenterText("Space Monsters");
            Console.WriteLine();
            Console.Write(" ");
            Console.Write(string.Concat(Enumerable.Repeat("-", Console.WindowWidth - 2)));
            Console.Write("\n");

            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (SpaceMonster monster in SpaceMonsterList)
            {
                cursorY = cursorOrigY;

                Console.SetCursorPosition(cursorX, cursorY++);
                Console.WriteLine($" Name: {monster.Name}");

                Console.SetCursorPosition(cursorX, cursorY++);
                Console.WriteLine($" ID: {monster.Id}");

                Console.SetCursorPosition(cursorX, cursorY++);
                Console.WriteLine($" Age: {monster.Age}");

                Console.SetCursorPosition(cursorX, cursorY++);
                Console.WriteLine($" Height: {monster.Height}");

                Console.SetCursorPosition(cursorX, cursorY++);
                Console.WriteLine($" Weight: {monster.Weight}");

                Console.SetCursorPosition(cursorX, cursorY++);
                Console.WriteLine($" Color: {monster.Color}");

                Console.SetCursorPosition(cursorX, cursorY++);
                Console.WriteLine($" Eats Humans?: {(monster.EatHumans ? "Yes" : "No")}");

                Console.SetCursorPosition(cursorX, cursorY++);
                Console.WriteLine($" Plays Golf?: {(monster.PlaysGolf ? "Yes" : "No")}");

                Console.SetCursorPosition(cursorX, cursorY++);
                Console.WriteLine($" Is Happy?: {(monster.IsHappy() ? "Yes" : "No")}"); // Displays "Yes" if true, "No" if false.

                Console.SetCursorPosition(cursorX, cursorY++);
                Console.WriteLine($" Galaxy: {monster.Galaxy}");


                Console.SetCursorPosition(cursorX, cursorY++);
                Console.WriteLine();

                cursorX += xSpacing;
                if (cursorX >= 100)
                {
                    cursorX = 0;
                    cursorOrigY += ySpacing;
                }
            }
        }

        private static List<SpaceMonster> DisplayEditSpaceMonster(List<SpaceMonster> AllSpaceMonsters)
        {
            int selectedMonsterIndex = GetSpaceMonsterIndex(AllSpaceMonsters, "Edit");
            int userInt;
            bool userBool;
            bool isValid = true;

            DisplayHeader($"Edit Sea Monster: {AllSpaceMonsters[selectedMonsterIndex].Name}");
            Console.WriteLine();

            do
            {
                isValid = true;

                Console.Write($" Current ID: {AllSpaceMonsters[selectedMonsterIndex].Id}".PadLeft(40));
                Console.Write(" New ID: ".PadLeft(30));
                if (!int.TryParse(Console.ReadLine(), out userInt))
                {
                    CenterText("That is not a valid entry. Please try again with an integer. \n");
                    isValid = false;
                }
                else
                {
                    AllSpaceMonsters[selectedMonsterIndex].Id = userInt;
                }

            } while (!isValid); // Get ID

            Console.Write($" Current Name: {AllSpaceMonsters[selectedMonsterIndex].Name}".PadLeft(40));
            Console.Write(" New Name: ".PadLeft(30));
            AllSpaceMonsters[selectedMonsterIndex].Name = Console.ReadLine();

            do
            {
                isValid = true;

                Console.Write($" Current Age: {AllSpaceMonsters[selectedMonsterIndex].Age}".PadLeft(40));
                Console.Write(" New Age: ".PadLeft(30));
                if (!int.TryParse(Console.ReadLine(), out userInt))
                {
                    CenterText("That is not a valid entry. Please try again with an integer. \n");
                    isValid = false;
                }
                else
                {
                    AllSpaceMonsters[selectedMonsterIndex].Age = userInt;
                    isValid = true;
                }

            } while (!isValid); // Get Age

            do
            {
                isValid = true;

                Console.Write($" Current Height: {AllSpaceMonsters[selectedMonsterIndex].Height}".PadLeft(40));
                Console.Write(" New Height: ".PadLeft(30));
                if (!int.TryParse(Console.ReadLine(), out userInt))
                {
                    CenterText("That is not a valid entry. Please try again with an integer. \n");
                    isValid = false;
                }
                else
                {
                    AllSpaceMonsters[selectedMonsterIndex].Height = userInt;
                    isValid = true;
                }

            } while (!isValid); // Get Height

            do
            {
                isValid = true;

                Console.Write($" Current Weight: {AllSpaceMonsters[selectedMonsterIndex].Weight}".PadLeft(40));
                Console.Write(" New Weight: ".PadLeft(30));
                if (!int.TryParse(Console.ReadLine(), out userInt))
                {
                    CenterText("That is not a valid entry. Please try again with an integer. \n");
                    isValid = false;
                }
                else
                {
                    AllSpaceMonsters[selectedMonsterIndex].Weight = userInt;
                    isValid = true;
                }

            } while (!isValid); // Get Weight

            Console.Write($" Current Color: {AllSpaceMonsters[selectedMonsterIndex].Color}".PadLeft(40));
            Console.Write(" New Color: ".PadLeft(30));
            AllSpaceMonsters[selectedMonsterIndex].Color = Console.ReadLine();

            do
            {
                isValid = true;

                Console.Write($" Current 'Eats Humans?': {AllSpaceMonsters[selectedMonsterIndex].EatHumans}".PadLeft(40));
                Console.Write(" New 'Eats Humans?': ".PadLeft(30));
                if (!bool.TryParse(Console.ReadLine(), out userBool))
                {
                    CenterText("That is not a valid entry. Please try again with 'true' or 'false'. \n");
                    isValid = false;
                }
                else
                {
                    AllSpaceMonsters[selectedMonsterIndex].EatHumans = userBool;
                    isValid = true;
                }

            } while (!isValid); // Get Eats Humans


            do
            {
                isValid = true;

                Console.Write($" Current 'Plays Golf?': {AllSpaceMonsters[selectedMonsterIndex].PlaysGolf}".PadLeft(40));
                Console.Write(" New 'Plays Golf?': ".PadLeft(30));
                if (!bool.TryParse(Console.ReadLine(), out userBool))
                {
                    CenterText("That is not a valid entry. Please try again with 'true' or 'false'. \n");
                    isValid = false;
                }
                else
                {
                    AllSpaceMonsters[selectedMonsterIndex].PlaysGolf = userBool;
                    isValid = true;
                }

            } while (!isValid); // Get Plays Golf

            Console.Write($" Current Home Galaxy: {AllSpaceMonsters[selectedMonsterIndex].Galaxy}".PadLeft(40));
            Console.Write(" New Home Sea: ".PadLeft(30));
            AllSpaceMonsters[selectedMonsterIndex].Galaxy = Console.ReadLine();

            return AllSpaceMonsters;
        }

        static SpaceMonster DisplayAddNewSpaceMonster() // User creates a new SpaceMonster.
        {
            SpaceMonster userSpaceMonster = new SpaceMonster();
            int userInt;
            bool userBool;
            bool isValid = true;

            DisplayHeader("Add New Space Monster");
            Console.WriteLine();

            do
            {
                isValid = true;

                CenterPadText(" New ID: ".PadLeft(30));
                if (!int.TryParse(Console.ReadLine(), out userInt))
                {
                    CenterText("That is not a valid entry. Please try again with an integer. \n");
                    isValid = false;
                }
                else
                {
                    userSpaceMonster.Id = userInt;
                }

            } while (!isValid); // Get ID

            CenterPadText("New Name: ");
            userSpaceMonster.Name = Console.ReadLine();

            do
            {
                isValid = true;

                CenterPadText(" New Age: ".PadLeft(30));
                if (!int.TryParse(Console.ReadLine(), out userInt))
                {
                    CenterText("That is not a valid entry. Please try again with an integer. \n");
                    isValid = false;
                }
                else
                {
                    userSpaceMonster.Age = userInt;
                }

            } while (!isValid); // Get Age

            do
            {
                isValid = true;

                CenterPadText(" New Height: ".PadLeft(30));
                if (!int.TryParse(Console.ReadLine(), out userInt))
                {
                    CenterText("That is not a valid entry. Please try again with an integer. \n");
                    isValid = false;
                }
                else
                {
                    userSpaceMonster.Height = userInt;
                }

            } while (!isValid); // Get Height

            do
            {
                isValid = true;

                CenterPadText(" New Weight: ".PadLeft(30));
                if (!int.TryParse(Console.ReadLine(), out userInt))
                {
                    CenterText("That is not a valid entry. Please try again with an integer. \n");
                    isValid = false;
                }
                else
                {
                    userSpaceMonster.Weight = userInt;
                }

            } while (!isValid); // Get ID

            CenterPadText("New Color: ");
            userSpaceMonster.Color = Console.ReadLine();

            do
            {
                isValid = true;

                CenterPadText(" New 'Eats Humans?': ".PadLeft(30));
                if (!bool.TryParse(Console.ReadLine(), out userBool))
                {
                    CenterText("That is not a valid entry. Please try again with 'true' or 'false'. \n");
                    isValid = false;
                }
                else
                {
                    userSpaceMonster.EatHumans = userBool;
                    isValid = true;
                }

            } while (!isValid); // Get Eats Humans

            do
            {
                isValid = true;

                CenterPadText(" New 'Plays Golf?': ".PadLeft(30));
                if (!bool.TryParse(Console.ReadLine(), out userBool))
                {
                    CenterText("That is not a valid entry. Please try again with 'true' or 'false'. \n");
                    isValid = false;
                }
                else
                {
                    userSpaceMonster.PlaysGolf = userBool;
                    isValid = true;
                }

            } while (!isValid); // Get Plays Golf

            CenterPadText("New Home Galaxy: ");
            userSpaceMonster.Galaxy = Console.ReadLine();

            return userSpaceMonster;
        }

        static List<SpaceMonster> DisplayDeleteSpaceMonster(List<SpaceMonster> AllSpaceMonsters)
        {
            int selectedMonsterIndex = 0;

            selectedMonsterIndex = GetSpaceMonsterIndex(AllSpaceMonsters, "Delete");

            DisplayHeader($"{AllSpaceMonsters[selectedMonsterIndex].Name} was successfully deleted.");
            DisplayUserPause("return to Sea Monster Editing Menu");

            AllSpaceMonsters.RemoveAt(selectedMonsterIndex);

            return AllSpaceMonsters;
        }

        static List<SpaceMonster> DisplaySpaceMonsterEditingMenu(List<SpaceMonster> AllSpaceMonsters)
        {
            int userChoice;
            bool loop = true;

            do
            {
                do
                {
                    DisplayHeader("SPACE MONSTER EDITING MENU");
                    Console.WriteLine();

                    LeftJustifyText(" 1) View All Space Monsters", 63);
                    LeftJustifyText(" 2) Add New", 63);
                    LeftJustifyText(" 3) Edit", 63);
                    LeftJustifyText(" 4) Delete", 63);
                    LeftJustifyText(" 5) Return to Monster Editing Menu", 63);

                    CenterText(" Please type your selection's number, then press enter. ", 57);

                } while (!int.TryParse(Console.ReadLine(), out userChoice) && userChoice > 0 && userChoice <= 5);

                switch (userChoice)
                {
                    case 1:
                        DisplayHeader("Space Monster Info");
                        DisplaySpaceMonsterInfo(AllSpaceMonsters);
                        DisplayUserPause("continue");
                        break;

                    case 2:
                        SpaceMonster userSpaceMonster = DisplayAddNewSpaceMonster();
                        AllSpaceMonsters.Add(userSpaceMonster);
                        break;

                    case 3:
                        AllSpaceMonsters = DisplayEditSpaceMonster(AllSpaceMonsters);

                        break;

                    case 4:
                        AllSpaceMonsters = DisplayDeleteSpaceMonster(AllSpaceMonsters);
                        break;

                    case 5:
                        loop = false;
                        break;
                }
            } while (loop);



            return AllSpaceMonsters;
        }

        static int GetSpaceMonsterIndex(List<SpaceMonster> AllSpaceMonsters, string Edit_Delete)
        {
            List<string> monsterNames = new List<string> { };
            string userChoice;
            int selectedMonsterIndex = 0;
            bool loop = true;


            foreach (SpaceMonster spaceMonster in AllSpaceMonsters) // creates a list of Monster Names to be used later in the validation if-block.
            {
                monsterNames.Add(spaceMonster.Name);
            }

            do
            {
                DisplayHeader($"{Edit_Delete} a Sea Monster");
                DisplaySpaceMonsterInfo(AllSpaceMonsters);

                CenterText("Type the Name of the Space Monster");
                CenterText("you wish to select (Case-Sensitive): ");
                userChoice = Console.ReadLine();

                // This if-block validates that the user chose an actual Monster Name
                if (monsterNames.Contains(userChoice)) // Checks input against list of names
                {
                    foreach (string name in monsterNames) // Gets index of the selected monster if name choice is valid
                    {
                        if (name == userChoice)
                        {
                            selectedMonsterIndex = monsterNames.IndexOf(name);

                            loop = false;
                        }
                    }
                }

                else
                {
                    CenterText($"{userChoice} is not a valid entry. Please try again.");
                    DisplayUserPause("continue");
                }

            } while (loop);

            return selectedMonsterIndex;
        }





        // Background Methods
        static void CenterText(string TextHere)
        {
            int origWidth;
            int charCount;
            int numberOfSpaces;

            origWidth = Console.WindowWidth;
            charCount = CountChars(TextHere);

            numberOfSpaces = (int)((origWidth - charCount) / 2);

            Console.WriteLine();

            for (int i = 0; i < numberOfSpaces; i++)
            {
                Console.Write(" ");
            }
            Console.Write(TextHere);
        }

        static void CenterText(string TextHere, int textChars)
        {
            int origWidth;
            int numberOfSpaces;

            origWidth = Console.WindowWidth;

            numberOfSpaces = (int)((origWidth - textChars) / 2);

            Console.WriteLine();

            for (int i = 0; i < numberOfSpaces; i++)
            {
                Console.Write(" ");
            }
            Console.Write(TextHere);
        }

        static void CenterPadText(string TextHere)
        {
            Console.Write(TextHere.PadLeft(Console.WindowWidth / 2));
        }

        static void LeftJustifyText(string TextHere, int rightPaddingSpaces)
        {
            int origWidth;
            int numberOfSpaces;

            origWidth = Console.WindowWidth;
            
            TextHere = TextHere.PadRight(rightPaddingSpaces);

            numberOfSpaces = origWidth - rightPaddingSpaces;
            numberOfSpaces = numberOfSpaces - 2;

            for (int i = 0; i <= numberOfSpaces; i++)
            {
                Console.Write(" ");
            }
            Console.Write(TextHere + "\n");
        }

        static int CountChars(string value)
        {
            int result = 0;
            bool lastWasSpace = false;

            foreach (char c in value)
            {
                if (char.IsWhiteSpace(c))
                {
                    // A.
                    // Only count sequential spaces one time.
                    if (lastWasSpace == false)
                    {
                        result++;
                    }
                    lastWasSpace = true;
                }
                else
                {
                    // B.
                    // Count other characters every time.
                    result++;
                    lastWasSpace = false;
                }
            }
            return result;
        }

        static int CountAllChars(string value)
        {
            int result = 0;

            foreach (char c in value)
            {
                result++;
            }
            return result;
        }

        static void DisplayHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            CenterText(headerText);
            Console.WriteLine();
        }

        static void DisplayWelcomeScreen()
        {
            DisplayHeader("Welcome!");
            DisplayUserPause("begin");
        }

        static void DisplayClosingScreen()
        {
            DisplayHeader("Good-bye!");
            DisplayUserPause("exit");
        }

        static void DisplayUserPause(string begin_continue_exit)
        {
            CenterText($" Press any key to {begin_continue_exit}. ");
            Console.ReadKey();
        }
    }
}
