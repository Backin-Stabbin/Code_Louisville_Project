using System;

namespace Code_Louisville {

    public class Menu {

        static public string DisplayBuildingMenu() {

            string buildingName = "";
            int selectionError = 0;

            while (buildingName == "") {
                Console.Clear();

                if (selectionError != 0) {
                    Console.WriteLine();
                    Console.WriteLine("Incorrect selection, please try again...");
                    Console.WriteLine();
                }

                Console.WriteLine("Would you like to work with one building or select all buildings?");
                Console.WriteLine();

                foreach (string building in Building.Get_List_Of_Buildings()) {
                    Console.WriteLine(building.Substring(building.Length - 1) + " - " + building.Replace("BLDG", "Building "));
                }

                Console.WriteLine("ALL - All Buildings");
                Console.WriteLine();
                Console.Write("Choose option [1-5] or [ALL] - ");

                var buildingSelection = Console.ReadLine();

                foreach (string building in Building.Get_List_Of_Buildings()) {
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
