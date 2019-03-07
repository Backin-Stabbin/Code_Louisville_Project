using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;

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
                    computer.Computer_Name = computer.Computer_Name.Replace("Computer".ToUpper(), "Machine").ToUpper();

                    Console.WriteLine(string.Format("{0} {1} {2,-20} {3,-10}",
                        computer.Computer_Name.PadRight(20), computer.Building.PadRight(10), computer.Physical_Machine, computer.Active
                    ));
                }
                Console.WriteLine("Total Computer Diplayed: " + selectedComputers.Count);
            }
            else {
                Console.WriteLine("No Results to display");
            }
        }

        public static List<Computer> ImportComputers() {

            var fileName = "Sample_Computers.csv";
            var sampleComputers = new List<Computer>();
            int progress = 0;
            int total = 0;

            using(StreamReader reader = new StreamReader(File.OpenRead(fileName))) {
                reader.ReadLine();
                while (reader.ReadLine() != null) {
                    total = total + 1;
                }
            }

            Console.WriteLine("Identifying computers in CSV...");

            StreamReader reader2 = new StreamReader(File.OpenRead(fileName));
            reader2.ReadLine();
            while (!reader2.EndOfStream) {
                var computer = new Computer();
                var line = reader2.ReadLine().Split(",");

                computer.Computer_Name = line[0].ToUpper();
                computer.Building = line[1];
                computer.Physical_Machine = Convert.ToBoolean(line[2]);
                computer.Active = Convert.ToBoolean(line[3]);

                sampleComputers.Add(computer);
                ProgressBar.drawTextProgressBar(progress, total);
                progress = progress + 1;

            }
            Console.WriteLine();
            Console.WriteLine("Completed Identification.");
            Console.WriteLine();
            return sampleComputers;
        }

        public static void ShowComputersByBuilding(SQLiteDataReader reader) {
            var computers = new List<Computer>();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Computers per Building");
            Console.ResetColor();

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
            var test = uniqueBuildings;

            foreach (var building in uniqueBuildings) {
                Console.Write(building.Key + " - ");
                Console.WriteLine(computers.Where(computer => computer.Building == building.Key).Count());
            }
            Console.WriteLine("Total Computers: " + computers.Count);
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
