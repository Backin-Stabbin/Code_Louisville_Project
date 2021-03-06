/*
    This is the Database Class

    Includes a generic constructor for a Database object
    Includes several queries
    Includes methods relating to SQLite DB
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace Final_Project {

    public class Database {

        // Variables
        public SQLiteConnection DBConnection;
        public string FileName = "Computer_Data.sqlite";
        public string CreateTableQuery = @"
            CREATE TABLE Computers (
                Computer_Name VARCHAR(20) PRIMARY KEY NOT NULL,
                Building VARCHAR(25) NOT NULL,
                Physical_Machine BIT NOT NULL DEFAULT '1',
                Active BIT NOT NULL DEFAULT '0'
            );
        ";
        public string SelectDataQuery = @"
            SELECT
                Computer_Name,
                Building,
                Physical_Machine,
                Active
            FROM
                Computers;
        ";
        public string CheckTableExist = @"
            SELECT
                Name
            FROM
                sqlite_master
            WHERE
                Name='Computers'
            ";

        // Simple constructor
        public Database database { get; set; }

        // Will create SQLite DB File
        public static void CreateDBFile(Database database) {

            Console.Clear();
            Console.WriteLine();
            Console.Write("Checking for Database File...");

            if (File.Exists(database.FileName)) {
                ConsoleView.SetColors(ConsoleColor.Green);
                Console.WriteLine(" Database Already Exist.");
                ConsoleView.ResetColor();
            }
            else {
                ConsoleView.SetColors(ConsoleColor.Yellow);
                Console.WriteLine(" Database File Missing");
                ConsoleView.ResetColor();
                Console.WriteLine();
                Console.Write("Attempting to Create Database File...");

                SQLiteConnection.CreateFile(database.FileName);

                if (File.Exists(database.FileName)) {
                    ConsoleView.SetColors(ConsoleColor.Green);
                    SQLiteConnection.CreateFile(database.FileName);
                    Console.WriteLine(" Created");
                    ConsoleView.ResetColor();
                }
                else {
                    ConsoleView.SetColors(ConsoleColor.Red);
                    Console.WriteLine(" Error Creating Database File.");
                    ConsoleView.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine("Press ANY Key to close.");
                    Console.ReadKey();
                    Environment.Exit(1);

                }
            }
        }

        // Will check if DB exists
        public static string CheckDBExist(Database database) {

            string databaseCheck = "";

            if (File.Exists(database.FileName)) {
                databaseCheck = "Exist";
                return databaseCheck;
            }
            else {
                databaseCheck = "Missing";
                return databaseCheck;
            }
        }

        // Will check is Computers table exists
        public static string CheckComputerTableExist(Database database) {

            using(var command = new SQLiteCommand(database.CheckTableExist, database.DBConnection)) {

                var checkTableExist = "";

                if (File.Exists(database.FileName)) {
                    database.DBConnection.Open();
                    var tableName = command.ExecuteScalar();
                    database.DBConnection.Close();

                    if (tableName == null) {
                        checkTableExist = "Missing";
                        return checkTableExist;
                    }
                    else {
                        checkTableExist = "Exist";
                        return checkTableExist;
                    }
                }

                checkTableExist = "File Missing";
                return checkTableExist;

            }
        }

        // Deletes DB File
        public static void DeleteDBFile(Database database) {

            Console.Clear();
            Console.WriteLine();
            Console.Write("Checking for Database File...");
            bool? doesExist = null;

            if (File.Exists(database.FileName)) {
                doesExist = true;

                ConsoleView.SetColors(ConsoleColor.Green);
                Console.WriteLine(" Database File Exist");
                ConsoleView.ResetColor();
            }
            else {
                doesExist = false;

                ConsoleView.SetColors(ConsoleColor.Yellow);
                Console.WriteLine(" No Database File to delete");
                ConsoleView.ResetColor();
            }

            if (doesExist == true) {

                File.Delete(database.FileName);

                Console.WriteLine();
                ConsoleView.SetColors(ConsoleColor.Yellow);
                Console.WriteLine("Datebase File Deleted");
                ConsoleView.ResetColor();
            }
        }

        // Creates Computers Table
        public static void CreateComputersTable(Database database) {

            database.DBConnection.Open();

            using(var command = new SQLiteCommand(database.CheckTableExist, database.DBConnection)) {
                var tableName = command.ExecuteScalar();

                Console.WriteLine();
                Console.Write("Checking to see if Computers Table exist...");

                if (tableName == null) {
                    ConsoleView.SetColors(ConsoleColor.Yellow);
                    Console.WriteLine("Missing DB Table");
                    ConsoleView.ResetColor();
                    Console.WriteLine();
                    Console.Write("Attempting to Create Computers Table...");

                    command.CommandText = database.CreateTableQuery;
                    command.ExecuteNonQuery();

                    using(var command2 = new SQLiteCommand(database.CheckTableExist, database.DBConnection)) {
                        tableName = command2.ExecuteScalar();

                        if (tableName == null) {
                            ConsoleView.SetColors(ConsoleColor.Red);
                            Console.WriteLine(" Error Creating Computers Table.");
                            ConsoleView.ResetColor();
                            Console.WriteLine();
                            Console.WriteLine("Press ANY Key to close.");
                            Console.ReadKey();
                            Environment.Exit(1);
                        }
                        else {
                            ConsoleView.SetColors(ConsoleColor.Green);
                            Console.WriteLine(" Created.");
                            ConsoleView.ResetColor();
                        }
                    }
                }
                else {
                    ConsoleView.SetColors(ConsoleColor.Green);
                    Console.WriteLine(" Computers Table Already Exist");
                    ConsoleView.ResetColor();
                }
            }

            database.DBConnection.Close();
        }

        // Will prompt for computer name changes and then add to DB
        public static void AddComputersToDB(Database database, List<Computer> computerList) {

            string insertCommandString = "INSERT INTO Computers (Computer_Name, Building, Physical_Machine, Active) VALUES ";
            int counter = 0;

            string oldComputerName = computerList[1].Computer_Name.ToUpper();
            string newComputerName = Computer.ChangeComputerName(oldComputerName);

            foreach (Computer computer in computerList) {

                computer.Computer_Name = computer.Computer_Name.Replace(oldComputerName.Split("-") [0].ToUpper(), newComputerName);

                counter = counter + 1;

                insertCommandString = insertCommandString + "('" +
                    computer.Computer_Name + "','" +
                    computer.Building + "'," +
                    computer.Physical_Machine + ",";

                if (counter == computerList.Count) {
                    insertCommandString = insertCommandString + computer.Active + ")";
                }
                else {
                    insertCommandString = insertCommandString + computer.Active + "),";
                }
            }

            insertCommandString = insertCommandString + ";";

            using(var sqlCommand = new SQLiteCommand(database.DBConnection)) {
                database.DBConnection.Open();

                sqlCommand.CommandText = insertCommandString;
                sqlCommand.ExecuteNonQuery();

                database.DBConnection.Close();
            }

        }

        // Will start the process for selecting computers from DB
        public static SQLiteDataReader SelectComputersFromDB(Database database) {

            var command = new SQLiteCommand(database.SelectDataQuery, database.DBConnection);
            var executeReader = command.ExecuteReader();
            command.Dispose();
            return executeReader;
        }

        // Gathers list of all headers in Computers Table
        public static List<string> GetComputerTableHeaders(Database database) {

            List<string> computerTableHeaders = new List<string>();

            using(var command = new SQLiteCommand(database.SelectDataQuery, database.DBConnection)) {

                using(var reader = command.ExecuteReader()) {
                    var tableSchema = reader.GetSchemaTable();

                    foreach (DataRow row in tableSchema.Rows) {
                        computerTableHeaders.Add(row["ColumnName"].ToString());
                    }
                }
            }

            return computerTableHeaders;
        }

        // Will allow adding of one DB Record
        public static void AddDBRecord(Database database) {

            database.DBConnection.Open();

            string computerName = "";
            string buildingName = "";
            bool? physicalMachine = null;
            bool? activeStatus = null;
            string boolString = "";
            int buildingNumber = 0;
            int selectionError = 0;

            while (computerName == "" || computerName.Length < 4 || computerName.Substring(0, 1) == "-" ||
                computerName.Substring(computerName.Length - 1, 1) == "-" || computerName.IndexOf("-") < 0 || computerName.IndexOf(" ") >= 0
            ) {
                Console.Clear();

                if (selectionError != 0) {
                    Console.WriteLine();
                    ConsoleView.SetColors(ConsoleColor.Magenta);
                    Console.WriteLine("Incorrect selection, please try again...");
                    ConsoleView.ResetColor();
                }

                Console.WriteLine();
                ConsoleView.SetColors(ConsoleColor.Yellow);
                Console.WriteLine("Name Rquirements:");
                ConsoleView.ResetColor();
                Console.WriteLine("- Must have atleast 1 hyphen");
                Console.WriteLine("- Cannot begin or end with a hyphen");
                Console.WriteLine("- Cannot be blank or contain a space");
                Console.WriteLine("- Must be atleast 4 characters long");
                Console.WriteLine();
                ConsoleView.SetColors(ConsoleColor.Yellow);
                Console.Write("Example");
                ConsoleView.ResetColor();
                Console.WriteLine(" - COMPUTER-123");
                Console.WriteLine();
                ConsoleView.SetColors(ConsoleColor.Yellow);
                Console.Write("Enter Computer Name: ");
                ConsoleView.ResetColor();
                computerName = Console.ReadLine().ToUpper();

                if (computerName == "" || computerName.Length < 4 || computerName.Substring(0, 1) == "-" ||
                    computerName.Substring(computerName.Length - 1, 1) == "-" || computerName.IndexOf("-") < 0 || computerName.IndexOf(" ") >= 0
                ) {
                    computerName = "";
                    selectionError = 1;
                }
                else {
                    selectionError = 0;
                }
            }

            while (buildingName == "") {
                Console.Clear();

                if (selectionError != 0) {
                    Console.WriteLine();
                    ConsoleView.SetColors(ConsoleColor.Magenta);
                    Console.WriteLine("Incorrect selection, please try again...");
                    ConsoleView.ResetColor();
                }

                Console.WriteLine();
                ConsoleView.SetColors(ConsoleColor.Yellow);
                Console.WriteLine("Building Rquirement:");
                ConsoleView.ResetColor();
                Console.WriteLine("- Must be single digit number 1-9");
                Console.WriteLine();
                ConsoleView.SetColors(ConsoleColor.Yellow);
                Console.Write("Enter Building NUmber: ");
                ConsoleView.ResetColor();
                buildingName = Console.ReadLine();
                try {
                    buildingNumber = Convert.ToInt16(buildingName);
                    if (buildingNumber >= 1 && buildingNumber <= 9) {
                        buildingName = "BLDG" + buildingNumber;
                        selectionError = 0;
                    }
                    else {
                        buildingName = "";
                        selectionError = 1;
                    }
                }
                catch {
                    buildingName = "";
                    selectionError = 1;
                }
            }
            while (boolString != "Y" && boolString != "N") {
                Console.Clear();

                if (selectionError != 0) {
                    Console.WriteLine();
                    ConsoleView.SetColors(ConsoleColor.Magenta);
                    Console.WriteLine("Incorrect selection, please try again...");
                    ConsoleView.ResetColor();
                }

                Console.WriteLine();
                Console.Write("Is this computer a Physical Machine. [");
                ConsoleView.SetColors(ConsoleColor.Yellow);
                Console.Write("Y");
                ConsoleView.ResetColor();
                Console.Write("] or [");
                ConsoleView.SetColors(ConsoleColor.Yellow);
                Console.Write("N");
                ConsoleView.ResetColor();
                Console.Write("]? ");
                boolString = Console.ReadLine().ToUpper();

                if (boolString == "Y") {
                    physicalMachine = true;
                    selectionError = 0;
                }
                else if (boolString == "N") {
                    physicalMachine = false;
                    selectionError = 0;
                }
                else {
                    physicalMachine = null;
                    selectionError = 1;
                }
            }

            boolString = "";

            while (boolString != "Y" && boolString != "N") {
                Console.Clear();

                if (selectionError != 0) {
                    Console.WriteLine();
                    ConsoleView.SetColors(ConsoleColor.Magenta);
                    Console.WriteLine("Incorrect selection, please try again...");
                    ConsoleView.ResetColor();
                }

                Console.WriteLine();
                Console.Write("Is this computer a Active Machine. [");
                ConsoleView.SetColors(ConsoleColor.Yellow);
                Console.Write("Y");
                ConsoleView.ResetColor();
                Console.Write("] or [");
                ConsoleView.SetColors(ConsoleColor.Yellow);
                Console.Write("N");
                ConsoleView.ResetColor();
                Console.Write("]? ");
                boolString = Console.ReadLine().ToUpper();

                if (boolString == "Y") {
                    activeStatus = true;
                    selectionError = 0;
                }
                else if (boolString == "N") {
                    activeStatus = false;
                    selectionError = 0;
                }
                else {
                    activeStatus = null;
                    selectionError = 1;
                }
            }

            string query = @"
                INSERT INTO Computers (Computer_Name, Building, Physical_Machine, Active) VALUES ('" +
                computerName + "','" + buildingName + "'," + physicalMachine + "," + activeStatus + ");";

            using(var sqlCommand = new SQLiteCommand(query, database.DBConnection)) {
                sqlCommand.ExecuteNonQuery();
            }
            database.DBConnection.Close();
        }

        public static void UupdateDBRecord(Database database) {

        }

        public static void DeleteDBRecord(Database database) {

        }
    }
}
