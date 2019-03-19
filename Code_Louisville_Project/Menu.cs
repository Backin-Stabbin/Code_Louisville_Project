using System;
using System.Collections.Generic;
using System.IO;

namespace Final_Project {

    public class Menu {

        static public string DisplayBuildingMenu(List<Computer> ComputerList) {

            string buildingName = "";
            int selectionError = 0;

            var buildingList = Building.GetListOfBuildings(ComputerList);

            while (buildingName == "") {

                if (selectionError != 0) {
                    Console.Clear();
                    Console.WriteLine();
                    ConsoleView.SetColors(ConsoleColor.Magenta);
                    Console.WriteLine("Incorrect selection, please try again...");
                    ConsoleView.ResetColor();
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
                Console.Write(" ALL");
                ConsoleView.ResetColor();
                Console.WriteLine(" - All Buildings");
                ConsoleView.ResetColor();
                Console.WriteLine();
                if (buildingList.Count > 1) {
                    Console.Write("Choose option [");
                    ConsoleView.SetColors(ConsoleColor.Yellow);
                    Console.Write("1");
                    ConsoleView.ResetColor();
                    Console.Write("-");
                    ConsoleView.SetColors(ConsoleColor.Yellow);
                    Console.Write(buildingList.Count);
                    ConsoleView.ResetColor();
                    Console.Write("] or [");
                    ConsoleView.SetColors(ConsoleColor.Yellow);
                    Console.Write("ALL");
                    ConsoleView.ResetColor();
                    Console.Write("] - ");
                }
                else if (buildingList.Count == 1) {
                    Console.Write("Choose option [");
                    ConsoleView.SetColors(ConsoleColor.Yellow);
                    Console.Write(buildingList[0].Substring(buildingList[0].Length - 1));
                    ConsoleView.ResetColor();
                    Console.Write("] or [");
                    ConsoleView.SetColors(ConsoleColor.Yellow);
                    Console.Write("ALL");
                    ConsoleView.ResetColor();
                    Console.Write("] - ");
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

        public static int MainMenu(Database database) {

            int choice = 99;

            while (choice == 99 || choice == 0) {

                Console.Clear();

                var databaseCheck = Database.CheckDBExist(database);
                var tableCheck = Database.CheckComputerTableExist(database);

                if (databaseCheck == "Exist") {
                    Console.WriteLine();
                    ConsoleView.SetColors(ConsoleColor.Green);
                    Console.Write("Database Exists");
                    ConsoleView.ResetColor();

                    if (tableCheck == "Exist") {
                        Console.Write(" - ");
                        ConsoleView.SetColors(ConsoleColor.Green);
                        Console.Write("Computers Table Exists");
                        ConsoleView.ResetColor();
                        Console.WriteLine(" - No need to create a Database");
                    }
                    else if (tableCheck == "Missing") {
                        Console.Write(" - ");
                        ConsoleView.SetColors(ConsoleColor.Magenta);
                        Console.Write("Computer Table Missing");
                        ConsoleView.ResetColor();
                        Console.WriteLine(" - Recreate Database before performing any action!");
                    }
                }
                else if (databaseCheck == "Missing") {
                    Console.WriteLine();
                    ConsoleView.SetColors(ConsoleColor.Magenta);
                    Console.Write("Database Missing");
                    ConsoleView.ResetColor();
                    Console.WriteLine(" - Create a Database before performing any action!");
                }

                if (choice == 0) {
                    Console.WriteLine();
                    ConsoleView.SetColors(ConsoleColor.Magenta);
                    Console.WriteLine("Incorrect selection. Try again");
                    ConsoleView.ResetColor();
                }

                Console.WriteLine();
                ConsoleView.SetColors(ConsoleColor.Cyan);
                Console.WriteLine("Warning - Importing or Adding Computers does not check for Dupelicates");
                ConsoleView.ResetColor();

                Console.WriteLine();
                ConsoleView.SetColors(ConsoleColor.Yellow);
                Console.WriteLine("-MAIN MENU-");
                ConsoleView.ResetColor();
                Console.WriteLine(" 1 - Import Computers from Sample CSV to DB");
                Console.WriteLine(" 2 - View Computers in DB");
                Console.WriteLine(" 3 - Add a new computer to DB");
                Console.WriteLine(" 4 - Update existing computer in DB (Not Implemented Yet)");
                Console.WriteLine(" 5 - Delete a computer from DB (Not Implemented Yet)");
                Console.WriteLine(" 6 - Create Database File");
                Console.WriteLine(" 7 - Delete Database File");
                Console.WriteLine(" 8 - Exit Program");
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
                else if (stringChoice == "8") {
                    return choice = 8;
                }
                else {
                    choice = 0;
                }

            }

            return choice;

        }

    }
}
