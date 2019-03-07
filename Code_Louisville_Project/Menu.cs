using System;
using System.Collections.Generic;

namespace Code_Louisville {

    public class Menu {

        static public string DisplayBuildingMenu(List<Computer> computers) {

            var buildingList = Building.Get_List_Of_Buildings(computers);
            string buildingName = "";
            int selectionError = 0;

            while (buildingName == "") {

                if (selectionError != 0) {
                    Console.WriteLine();
                    Console.WriteLine("Incorrect selection, please try again...");
                    Console.WriteLine();
                }

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Would you like to work with one building or select all buildings?");
                Console.ResetColor();

                foreach (string building in buildingList) {
                    Console.WriteLine(building.Substring(building.Length - 1) + " - " + building.Replace("BLDG", "Building "));
                }

                Console.WriteLine("ALL - All Buildings");
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
    }
}
