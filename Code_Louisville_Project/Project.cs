using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Final_Project {

    class Project {

        static void Main() {

            Console.Title = "Code Louisville C# / .NET Project";

            ConsoleView.ResetColor();
            Console.Clear();

            try {
                // Used for list of Computers
                var computerList = new List<Computer>();

                // Creating DB Instance
                var database = new Database();

                // Importing Computer List
                var importedComputers = Computer.ImportComputersFromCSV("Sample_Computers.csv");

                // Making Connection String
                database.DBConnection = new SQLiteConnection("Data Source=" + database.FileName + ";Version=3;");

                // Creating DB File
                Database.CreateDBFile(database);

                // Open DB Connection
                database.DBConnection.Open();

                // Creating Computers Table
                Database.CreateComputersTable(database);

                // Inserting Computers to DB Table
                Database.AddComputersToDB(database, importedComputers);

                //Adding data to computer list
                using(var reader = Database.SelectComputersFromDB(database)) {
                    while (reader.Read()) {
                        var computer = new Computer();
                        computer.Computer_Name = reader.GetString(0);
                        computer.Building = reader.GetString(1);
                        computer.Physical_Machine = reader.GetBoolean(2);
                        computer.Active = reader.GetBoolean(3);

                        computerList.Add(computer);
                    }
                }

                // Grouping by building
                using(var reader = Database.SelectComputersFromDB(database)) {
                    Computer.ShowComputerCountPerBuilding(reader);
                }

                // Displaying computers
                Computer.DisplayListOfComputers(computerList, database);

                // Closing DB Connection
                database.DBConnection.Close();

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Press ANY Key to close window.");
                Console.ReadKey();
            }
            catch (Exception exception) {

                Console.WriteLine();
                Console.WriteLine(exception.Message);
                Console.WriteLine();
                Console.WriteLine(exception.StackTrace);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.ReadKey();
            }
        }
    }
}
