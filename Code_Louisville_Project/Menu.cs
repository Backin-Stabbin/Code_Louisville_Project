using System;
using System.Collections.Generic;

namespace Final_Project {

    public class Menu {

        static public string DisplayBuildingMenu(List<Computer> ComputerList) {

            var buildingList = Building.GetListOfBuildings(ComputerList);
            string buildingName = "";
            int selectionError = 0;

            while (buildingName == "") {

                if (selectionError != 0) {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Incorrect selection, please try again...");
                    Console.WriteLine();
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Would you like to work with one building or select all buildings?");
                Console.ResetColor();

                foreach (string building in buildingList) {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(" " + building.Substring(building.Length - 1));
                    Console.ResetColor();
                    Console.WriteLine(" - " + building.Replace("BLDG", "Building "));
                }

                ConsoleView.SetColors(ConsoleColor.Yellow);
                Console.WriteLine(" ALL - All Buildings");
                ConsoleView.ResetColor();
                Console.WriteLine();
                if (buildingList.Count > 1) {
                    Console.Write("Choose option [1-" + buildingList.Count + "] or [ALL] - ");
                }
                else if (buildingList.Count == 1) {
                    Console.Write("Choose option [1] or [ALL] - ");

                }
                var buildingSelection = Console.ReadLine().ToUpper();

                foreach (string building in buildingList) {
                    if (buildingSelection == building.Substring(building.Length - 1)) {
                        buildingName = building;
                        return buildingName;
                    }
                }

                if (buildingSelection == "ALL") {
                    buildingName = buildingSelection;
                    return buildingName;
                }
                else {
                    selectionError = 1;
                    buildingName = "";
                }
            }

            return buildingName;
        }

        public static int MainMenu() {

            Console.Clear();
            int choice = 99;

            while (choice == 99 || choice == 0) {

                if (choice == 0) {
                    Console.Clear();
                    Console.WriteLine();
                    ConsoleView.SetColors(ConsoleColor.Yellow);
                    Console.WriteLine("Incorrect selection. Try again");
                    ConsoleView.ResetColor();
                }

                Console.WriteLine();
                Console.WriteLine("1 - Import Computers from Sample CSV to DB (Currently does not check for Duplicates)");
                Console.WriteLine("2 - View Computers in DB");
                Console.WriteLine("3 - Add a new computer to DB (Currently does not check for Duplicates)");
                Console.WriteLine("4 - Update existing computer in DB (Not Implemented Yet)");
                Console.WriteLine("5 - Delete a computer from DB (Not Implemented Yet)");
                Console.WriteLine("6 - Delete Database File (Not working yet)");
                Console.WriteLine("7 - Nothing (Exits Program)");
                Console.WriteLine();
                ConsoleView.SetColors(ConsoleColor.Yellow);
                Console.Write("What would you like to do? ");
                ConsoleView.ResetColor();

                string stringChoice = Console.ReadLine();

                if (stringChoice == "1") {
                    return choice = 1;
                }
                else if (stringChoice == "2") {
                    return choice = 2;
                }
                else if (stringChoice == "3") {
                    return choice = 3;
                }
                else if (stringChoice == "4") {
                    return choice = 4;
                }
                else if (stringChoice == "5") {
                    return choice = 5;
                }
                else if (stringChoice == "6") {
                    return choice = 6;
                }
                else if (stringChoice == "7") {
                    return choice = 7;
                }
                else {
                    choice = 0;
                }

            }

            return choice;

        }

    }
}
