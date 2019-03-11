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

            foreach (Computer computer in computerList) {

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
            //reader.Read();

            var tableSchema = reader.GetSchemaTable();

            foreach (DataRow row in tableSchema.Rows) {
                computerTableHeaders.Add(row["ColumnName"].ToString());
            }

            return computerTableHeaders;
        }
    }
}
