using System;

namespace Code_Louisville {

    public class Menu {

        static public string DisplayMenu() {

            string buildingName = "";
            int buildingSelection = 0;

            while (buildingName == "") {
                Console.WriteLine("Would you like to work with one building or select all building?");
                Console.WriteLine();
                Console.WriteLine("1 - Building 1");
                Console.WriteLine("2 - Building 2");
                Console.WriteLine("3 - Building 3");
                Console.WriteLine("4 - Building 4");
                Console.WriteLine("5 - Building 5");
                Console.WriteLine("6 - All Buildings");
                Console.WriteLine();
                Console.Write("Choose an option [1-6] - ");

                buildingSelection = Convert.ToInt32(Console.ReadLine());

                if (buildingSelection == 1) {
                    buildingName = "BLDG1";
                }
                else if (buildingSelection == 2) {
                    buildingName = "BLDG2";
                }
                else if (buildingSelection == 3) {
                    buildingName = "BLDG3";
                }
                else if (buildingSelection == 4) {
                    buildingName = "BLDG4";
                }
                else if (buildingSelection == 5) {
                    buildingName = "BLDG5";
                }
                else if (buildingSelection == 6) {
                    buildingName = "ALL";
                }

            }
            return buildingName;

        }

    }
}
