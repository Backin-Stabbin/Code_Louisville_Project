using System;

namespace Code_Louisville {

    public class Menu {

        static public string DisplayBuildingMenu() {

            Console.Clear();

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
                    Console.WriteLine(building.Split(" ") [1] + " - " + building);
                }

                Console.WriteLine("ALL - All Buildings");
                Console.WriteLine();
                Console.Write("Choose option [1-5] or [ALL] - ");

                var buildingSelection = Console.ReadLine();

                switch (buildingSelection) {
                    case "1":
                        buildingName = "BLDG1";
                        break;
                    case "2":
                        buildingName = "BLDG2";
                        break;
                    case "3":
                        buildingName = "BLDG3";
                        break;
                    case "4":
                        buildingName = "BLDG4";
                        break;
                    case "5":
                        buildingName = "BLDG5";
                        break;
                    case "ALL":
                        buildingName = "ALL";
                        break;
                }
                selectionError = 1;
            }
            return buildingName;
        }
    }
}
