using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Final_Project {

    class Project {

        static void Main() {

            Console.Title = "Code Louisville C# / .NET Final Project";
            Console.Clear();
            Console.WriteLine();
            ConsoleView.ResetColor();

            try {
                // Creating DB Instance
                var database = new Database();
                // Making Connection String
                database.DBConnection = new SQLiteConnection("Data Source=" + database.FileName + ";Version=3;");
                // Menu Choice variable
                int choice = 0;
                // Used to identify Errors to display
                string selectionError = "";

                // Main Menu
                while (choice != 8) {
                    // Used for list of Computers
                    var computerList = new List<Computer>();

                    // Selected menu choice
                    choice = Menu.MainMenu(database, selectionError);

                    // Chosen if you want to import computers from CSV
                    if (choice == 1) {
                        if (Database.CheckComputerTableExist(database) == "Exist") {

                            var importedComputers = Computer.ImportComputersFromCSV("Sample_Computers.csv", database);

                            Database.AddComputersToDB(database, importedComputers);
                        }
                        else if (Database.CheckComputerTableExist(database) == "Missing") {
                            selectionError = "Missing";
                            continue;
                        }
                        else if (Database.CheckComputerTableExist(database) == "File Missing") {
                            selectionError = "File Missing";
                            continue;
                        }
                    }
                    // Chosen to select computers from DB
                    else if (choice == 2) {

                        if (Database.CheckComputerTableExist(database) == "Exist") {
                            database.DBConnection.Open();

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

                                    Computer.ShowComputerCountPerBuilding(database);

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
                        else if (Database.CheckComputerTableExist(database) == "Missing") {
                            selectionError = "Missing";
                            continue;
                        }
                        else if (Database.CheckComputerTableExist(database) == "File Missing") {
                            selectionError = "File Missing";
                            continue;
                        }

                    }
                    // Chosen to add a single computer record
                    else if (choice == 3) {
                        if (Database.CheckComputerTableExist(database) == "Exist") {
                            Database.AddDBRecord(database);
                        }
                        else if (Database.CheckComputerTableExist(database) == "Missing") {
                            selectionError = "Missing";
                            continue;
                        }
                        else if (Database.CheckComputerTableExist(database) == "File Missing") {
                            selectionError = "File Missing";
                            continue;
                        }
                    }
                    // Not implemented
                    else if (choice == 4) {
                        if (Database.CheckComputerTableExist(database) == "Exist") {
                            Database.UupdateDBRecord(database);
                        }
                        else if (Database.CheckComputerTableExist(database) == "Missing") {
                            selectionError = "Missing";
                            continue;
                        }
                        else if (Database.CheckComputerTableExist(database) == "File Missing") {
                            selectionError = "File Missing";
                            continue;
                        }
                    }
                    // Not implemented
                    else if (choice == 5) {
                        if (Database.CheckComputerTableExist(database) == "Exist") {
                            Database.DeleteDBRecord(database);
                        }
                        else if (Database.CheckComputerTableExist(database) == "Missing") {
                            selectionError = "Missing";
                            continue;
                        }
                        else if (Database.CheckComputerTableExist(database) == "File Missing") {
                            selectionError = "File Missing";
                            continue;
                        }
                    }
                    // Will create DB and Computers Table
                    else if (choice == 6) {
                        Database.CreateDBFile(database);
                        Database.CreateComputersTable(database);
                        selectionError = "";
                    }
                    // Will delete DB
                    else if (choice == 7) {
                        Database.DeleteDBFile(database);
                        selectionError = "";
                    }
                    // Exits program
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
