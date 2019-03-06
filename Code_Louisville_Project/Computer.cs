using System;
using System.Collections.Generic;

namespace Code_Louisville {

    public class Computer {

        public string Computer_Name;
        public string Building;
        public bool Physical_Machine;
        public bool Active;

        public static List<Computer> SelectComputersFromBuilding(List<Computer> computerListInput, List<string> buildingList) {

            var buildingSelection = Menu.DisplayBuildingMenu(buildingList);

            if (buildingSelection == "ALL") {
                return computerListInput;
            }
            else {
                var selectedComputers = computerListInput.FindAll(computer => computer.Building == buildingSelection);
                return selectedComputers;
            }
        }

        public static void DisplayListOfComputers(List<Computer> computers, Database database, List<string> buildingList) {

            var selectedComputers = SelectComputersFromBuilding(computers, buildingList);
            var readerHeaders = Database.Read_DB_Table_Headers(database);

            Console.Clear();
            if (selectedComputers.Count > 0) {
                Console.WriteLine(string.Format("{0} {1} {2,-20} {3,-10}",
                    readerHeaders[0].PadRight(20), readerHeaders[1].PadRight(10), readerHeaders[2], readerHeaders[3]));

                foreach (Computer computer in selectedComputers) {
                    computer.Computer_Name = computer.Computer_Name.Replace("Computer", "Machine");

                    Console.WriteLine(string.Format("{0} {1} {2,-20} {3,-10}",
                        computer.Computer_Name.PadRight(20), computer.Building.PadRight(10), computer.Physical_Machine, computer.Active
                    ));
                }
            }
            else {
                Console.WriteLine("No Results to display");
            }
        }
    }
}
