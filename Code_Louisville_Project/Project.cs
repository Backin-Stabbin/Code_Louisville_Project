using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Code_Louisville {
    class Project {
        static void Main() {

            Console.Clear();

            try {
                // Used for list of Computers
                var computers = new List<Computer>();

                // Creating DB Instance
                var dataBase = new Database();

                // Making Connection String
                dataBase.DBConnection = new SQLiteConnection("Data Source=" + dataBase.FileName + ";Version=3;");

                // Creating DB File
                Database.Create_DB_File(dataBase);

                // Open DB Connection
                dataBase.DBConnection.Open();

                // Creating Computers Table
                Database.Create_DB_Table(dataBase);

                // Inserting Data to DB Table
                Database.Insert_Data_To_Table(dataBase);

                // Reading Data from DB
                var reader = Database.Read_DB_Data(dataBase);

                // Adding data to computer list
                while (reader.Read()) {
                    var theComputer = new Computer(
                        computer_Name: reader.GetString(0),
                        building: reader.GetString(1),
                        physical_Machine: (bool) reader.GetValue(2),
                        active: (bool) reader.GetValue(3)
                    );

                    computers.Add(theComputer);
                }

                // Closing DB Connection
                dataBase.DBConnection.Close();

                var selectedComputers = Computer.SelectComputersFromBuilding(computers);
                var headers = Computer.GetHeaders();

                Console.Clear();

                if (selectedComputers.Count > 0) {
                    Console.WriteLine(string.Format("{0} {1} {2,-20} {3,-10}",
                        headers[0].PadRight(20), headers[1].PadRight(10), headers[2], headers[3]));

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
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine("error");
            }
        }
    }
}
