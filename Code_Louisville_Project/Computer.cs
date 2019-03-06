using System;
using System.Collections.Generic;
using System.IO;

namespace Code_Louisville {

    public class Computer {

        public string Computer_Name;
        public string Building;
        public bool Physical_Machine;
        public bool Active;

        public Computer computer { get; set; }

        public static List<Computer> SelectComputersFromBuilding(List<Computer> computers) {

            var buildingSelection = Menu.DisplayBuildingMenu(computers);

            if (buildingSelection == "ALL") {
                return computers;
            }
            else {
                var selectedComputers = computers.FindAll(computer => computer.Building == buildingSelection);
                return selectedComputers;
            }
        }

        public static void DisplayListOfComputers(List<Computer> computers, Database database) {

            var selectedComputers = SelectComputersFromBuilding(computers);
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

        public static List<Computer> ImportComputers() {

            var reader = new StreamReader(File.OpenRead("Sample_Computers.csv"));
            var sampleComputers = new List<Computer>();
            reader.ReadLine();

            while (!reader.EndOfStream) {
                var computer = new Computer();
                var line = reader.ReadLine().Split(",");

                computer.Computer_Name = line[0];
                computer.Building = line[1];
                computer.Physical_Machine = Convert.ToBoolean(line[2]);
                computer.Active = Convert.ToBoolean(line[3]);

                sampleComputers.Add(computer);
            }
            return sampleComputers;
        }
    }
}
