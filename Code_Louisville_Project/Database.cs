using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Threading;

namespace Final_Project {

    public class Database {

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

        public Database database { get; set; }

        public static void CreateDBFile(Database database) {

            if (File.Exists(database.FileName)) {
                File.Delete(database.FileName);
            }
            SQLiteConnection.CreateFile(database.FileName);
        }

        public static void CreateComputersTable(Database database) {

            var command = new SQLiteCommand(database.CreateTableQuery, database.DBConnection);
            command.ExecuteNonQuery();
        }

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

                sqlCommand.CommandText = insertCommandString;
                sqlCommand.ExecuteNonQuery();
            }
        }

        public static SQLiteDataReader SelectComputersFromDB(Database database) {

            var command = new SQLiteCommand(database.SelectDataQuery, database.DBConnection);
            return command.ExecuteReader();
        }

        public static List<string> GetComputerTableHeaders(Database database) {

            List<string> computerTableHeaders = new List<string>();

            var command = new SQLiteCommand(database.SelectDataQuery, database.DBConnection);
            var reader = command.ExecuteReader();
            var tableSchema = reader.GetSchemaTable();

            foreach (DataRow row in tableSchema.Rows) {
                computerTableHeaders.Add(row["ColumnName"].ToString());
            }

            return computerTableHeaders;
        }

        public static void AddDBRecord(Database database) {
            Console.Clear();

            string computerName = "";
            string buildingName = "";
            bool? physicalMachine = null;
            bool? activeStatus = null;
            string boolString = "";
            int buildingNumber = 0;

            while (computerName == "" || computerName.Length < 4 || computerName.Substring(0, 1) == "-" ||
                computerName.Substring(computerName.Length - 1, 1) == "-" || computerName.IndexOf("-") < 0
            ) {
                Console.Clear();
                Console.WriteLine();
                Console.Write("Enter Computer Name (Must have a hyphen): ");
                computerName = Console.ReadLine().ToUpper();
            }

            while (buildingName == "") {
                Console.Clear();
                Console.WriteLine();
                Console.Write("Enter Building NUmber [1-9]: ");
                buildingName = Console.ReadLine();
                try {
                    buildingNumber = Convert.ToInt16(buildingName);
                    if (buildingNumber >= 1 && buildingNumber <= 9) {
                        buildingName = "BLDG" + buildingNumber;
                    }
                    else {
                        buildingName = "";
                    }
                }
                catch {
                    buildingName = "";
                }

            }
            while (boolString != "Y" && boolString != "N") {
                Console.Clear();
                Console.WriteLine();
                Console.Write("Is this computer a physical machine. [Y] or [N]? ");
                boolString = Console.ReadLine().ToUpper();

                if (boolString == "Y") {
                    physicalMachine = true;
                }
                else if (boolString == "N") {
                    physicalMachine = false;
                }
                else {
                    physicalMachine = null;
                }

            }

            boolString = "";

            while (boolString != "Y" && boolString != "N") {
                Console.Clear();
                Console.WriteLine();
                Console.Write("Is this computer an active machine. [Y] or [N]? ");
                boolString = Console.ReadLine().ToUpper();

                if (boolString == "Y") {
                    activeStatus = true;
                }
                else if (boolString == "N") {
                    activeStatus = false;
                }
                else {
                    activeStatus = null;
                }
            }

            string query = @"INSERT INTO Computers(Computer_Name, Building, Physical_Machine, Active) VALUES ('" +
                computerName + "','" + buildingName + "'," + physicalMachine + "," + activeStatus + ");";

            using(var sqlCommand = new SQLiteCommand(query, database.DBConnection)) {

                sqlCommand.ExecuteNonQuery();
            }
        }

        public static void UupdateDBRecord(Database database) {

        }

        public static void DeleteDBRecord(Database database) {

        }
    }
}
