using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;

namespace Final_Project {

    public class Computer {

        public string Computer_Name;
        public string Building;
        public bool Physical_Machine;
        public bool Active;

        public Computer computer { get; set; }

        public static List<Computer> SelectComputersFromBuilding(List<Computer> computerList) {

            var selectedBuilding = Menu.DisplayBuildingMenu(computerList);

            if (selectedBuilding == "ALL") {
                return computerList;
            }
            else {
                var selectedComputers = computerList.FindAll(computer => computer.Building == selectedBuilding);
                return selectedComputers;
            }
        }

        public static void DisplayListOfComputers(List<Computer> computerList, Database database) {

            var selectedComputers = SelectComputersFromBuilding(computerList);
            var computerHeaders = Database.GetComputerTableHeaders(database);
            Console.Clear();

            if (selectedComputers.Count > 0) {
                ConsoleView.SetColors(ConsoleColor.Yellow);
                Console.WriteLine(string.Format("{0} {1} {2,-20} {3,-10}",
                    computerHeaders[0].PadRight(20), computerHeaders[1].PadRight(10), computerHeaders[2], computerHeaders[3]));
                ConsoleView.ResetColor();

                foreach (Computer computer in selectedComputers) {

                    Console.WriteLine(string.Format("{0} {1} {2,-20} {3,-10}",
                        computer.Computer_Name.PadRight(20), computer.Building.PadRight(10), computer.Physical_Machine, computer.Active
                    ));
                }
                ConsoleView.SetColors(ConsoleColor.Yellow);
                Console.WriteLine();
                Console.Write("Total Computers Diplayed: ");
                ConsoleView.ResetColor();
                Console.WriteLine(selectedComputers.Count);
            }
            else {
                ConsoleView.SetColors(ConsoleColor.Yellow);
                Console.WriteLine("No Results to display");
                ConsoleView.ResetColor();
            }
        }

        public static List<Computer> ImportComputersFromCSV(string fileName) {

            Console.Clear();
            var importedComputers = new List<Computer>();
            int currentProgress = 0;
            int totalComputers = 0;

            using(var reader = new StreamReader(File.OpenRead(fileName))) {
                reader.ReadLine();
                while (reader.ReadLine() != null) {
                    totalComputers = totalComputers + 1;
                }
            }

            Console.WriteLine("Identifying computers in CSV...");

            using(var reader = new StreamReader(File.OpenRead(fileName))) {

                reader.ReadLine();

                while (!reader.EndOfStream) {
                    var computer = new Computer();
                    var line = reader.ReadLine().Split(",");

                    computer.Computer_Name = line[0].ToUpper();
                    computer.Building = line[1];
                    computer.Physical_Machine = Convert.ToBoolean(line[2]);
                    computer.Active = Convert.ToBoolean(line[3]);

                    importedComputers.Add(computer);

                    ProgressBar.ShowProgressBar(currentProgress, totalComputers);
                    currentProgress = currentProgress + 1;

                }
            }

            Console.WriteLine();
            Console.WriteLine("Identification complete");
            Console.WriteLine();
            return importedComputers;
        }

        public static void ShowComputerCountPerBuilding(SQLiteDataReader reader) {

            var computers = new List<Computer>();
            Console.Clear();

            ConsoleView.SetColors(ConsoleColor.Yellow);
            Console.WriteLine("Computers per Building");
            ConsoleView.ResetColor();

            while (reader.Read()) {
                var computer = new Computer();
                computer.Computer_Name = reader.GetString(0);
                computer.Building = reader.GetString(1);
                computer.Physical_Machine = reader.GetBoolean(2);
                computer.Active = reader.GetBoolean(3);

                computers.Add(computer);
            }

            var buildingList = new List<string>();

            var uniqueBuildings = computers.GroupBy(computer => computer.Building).ToList();

            foreach (var building in uniqueBuildings) {
                Console.Write(building.Key + " - ");
                Console.WriteLine(computers.Where(computer => computer.Building == building.Key).Count());
            }

            ConsoleView.SetColors(ConsoleColor.Yellow);
            Console.Write("Total Computers: ");
            ConsoleView.ResetColor();
            Console.WriteLine(computers.Count);
            Console.WriteLine();
            Console.WriteLine();
        }

        public static string ChangeComputerName(string oldComputerName) {

            string newComputerName = "";
            Console.WriteLine();
            Console.WriteLine("Please choose a new name for your computers.");
            Console.Write("Currently your computers are named like - ");
            ConsoleView.SetColors(ConsoleColor.Yellow);
            Console.WriteLine(oldComputerName);
            ConsoleView.ResetColor();
            Console.WriteLine();
            Console.Write("Enter new name to replace ");
            ConsoleView.SetColors(ConsoleColor.Yellow);
            Console.Write(oldComputerName.Split("-") [0]);
            ConsoleView.ResetColor();
            Console.Write(": ");
            newComputerName = Console.ReadLine();

            return newComputerName;
        }
    }
}
