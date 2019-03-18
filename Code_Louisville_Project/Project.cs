using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Final_Project {

    class Project {

        static void Main() {

            Console.Title = "Code Louisville C# / .NET Project";
            Console.Clear();
            Console.WriteLine();
            ConsoleView.ResetColor();

            try {
                // Used for list of Computers
                var computerList = new List<Computer>();
                // Creating DB Instance
                var database = new Database();
                // Making Connection String
                database.DBConnection = new SQLiteConnection("Data Source=" + database.FileName + ";Version=3;");
                // Creating DB File
                Database.CreateDBFile(database);
                // Open DB Connection
                database.DBConnection.Open();
                // Creating Computers Table
                Database.CreateComputersTable(database);

                // Main Menu
                var Choice = Menu.MainMenu();

                if (Choice == 1) {

                    // Importing Computer List
                    var importedComputers = Computer.ImportComputersFromCSV("Sample_Computers.csv");

                    // Inserting Computers to DB Table
                    Database.AddComputersToDB(database, importedComputers);
                }
                else if (Choice == 2) {

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
                }
                else if (Choice == 3) {

                    Database.AddDBRecord(database);
                }
                else if (Choice == 4) {

                    Database.UupdateDBRecord(database);
                }
                else if (Choice == 5) {

                    Database.DeleteDBRecord(database);
                }
                else if (Choice == 6) {

                    Database.DeleteDBFile(database);
                }
                else if (Choice == 7) {

                    database.DBConnection.Close();
                    Environment.Exit(1);
                }

                // Closing DB Connection
                database.DBConnection.Close();

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Press ANY Key to close window.");
                Console.ReadKey();
                Environment.Exit(1);
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
