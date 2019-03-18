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

        public static int UserChoice() {
            int choice = 99;

            while (choice == 99 || choice == 0) {

                if (choice == 0) {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Incorrect selection. Try again");

                }

                Console.WriteLine();
                Console.WriteLine("1 - Add a new computer");
                Console.WriteLine("2 - Update existing computer");
                Console.WriteLine("3 - Delete a computer");
                Console.WriteLine("4 - Nothing");
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
                else {
                    choice = 0;
                }

            }

            return choice;

        }
    }
}
