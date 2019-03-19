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

                int choice = 0;

                // Main Menu
                while (choice != 8) {
                    choice = Menu.MainMenu(database);

                    if (choice == 1) {

                        // Importing Computer List
                        var importedComputers = Computer.ImportComputersFromCSV("Sample_Computers.csv", database);

                        // Inserting Computers to DB Table

                        Database.AddComputersToDB(database, importedComputers);
                    }
                    else if (choice == 2) {

                        database.DBConnection.Open();

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

                        using(var reader = Database.SelectComputersFromDB(database)) {

                            if (computerList.Count > 0) {
                                // Grouping by building
                                Computer.ShowComputerCountPerBuilding(reader);

                                // Displaying computers
                                Computer.DisplayListOfComputers(computerList, database);
                            }
                            else {
                                Console.Clear();
                                Console.WriteLine();
                                ConsoleView.SetColors(ConsoleColor.Yellow);
                                Console.WriteLine("No Computers in DB");
                                ConsoleView.ResetColor();
                            }
                        }

                        database.DBConnection.Close();
                    }
                    else if (choice == 3) {
                        Database.AddDBRecord(database);
                    }
                    else if (choice == 4) {
                        Database.UupdateDBRecord(database);
                    }
                    else if (choice == 5) {
                        Database.DeleteDBRecord(database);
                    }
                    else if (choice == 6) {
                        Database.CreateDBFile(database);
                        Database.CreateComputersTable(database);
                    }
                    else if (choice == 7) {
                        Database.DeleteDBFile(database);
                    }
                    else if (choice == 8) {
                        Environment.Exit(1);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Press ANY Key to return to Main Menu.");
                    Console.ReadKey();
                }
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
