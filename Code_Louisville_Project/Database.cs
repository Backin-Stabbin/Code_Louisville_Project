using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Threading;

namespace Code_Louisville {

    public class Database {
        public string FileName = "Computer_Data.sqlite";
        public SQLiteConnection DBConnection;

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

        public static void Create_DB_File(Database database) {
            if (File.Exists(database.FileName)) {
                File.Delete(database.FileName);
            }
            SQLiteConnection.CreateFile(database.FileName);
        }

        public static void Create_DB_Table(Database database) {
            var command = new SQLiteCommand(database.CreateTableQuery, database.DBConnection);
            command.ExecuteNonQuery();
        }

        public static void Insert_Computers_To_Table(Database database, List<Computer> computers) {
            Console.WriteLine();
            Console.WriteLine("Uploading computers to Database");
            Console.WriteLine();

            int progress = 0;
            int total = computers.Count;

            foreach (Computer computer in computers) {
                using(SQLiteCommand cmd = new SQLiteCommand(database.DBConnection)) {
                    cmd.CommandText = "INSERT INTO Computers (Computer_Name, Building, Physical_Machine, Active)" +
                        "VALUES ('" +
                        computer.Computer_Name + "','" +
                        computer.Building + "'," +
                        computer.Physical_Machine + "," +
                        computer.Active + ")" +
                        ";";
                    cmd.ExecuteNonQuery();

                    ProgressBar.drawTextProgressBar(progress, total);
                    progress = progress + 1;
                }
            }
        }

        public static SQLiteDataReader Read_DB_Data(Database database) {

            var command = new SQLiteCommand(database.SelectDataQuery, database.DBConnection);
            return command.ExecuteReader();
        }

        public static List<string> Read_DB_Table_Headers(Database database) {
            List<string> table_Headers = new List<string>();
            var command = new SQLiteCommand(database.SelectDataQuery, database.DBConnection);
            var reader = command.ExecuteReader();
            reader.Read();

            var tableSchema = reader.GetSchemaTable();

            // Each row in the table schema describes a column
            foreach (DataRow row in tableSchema.Rows) {
                table_Headers.Add(row["ColumnName"].ToString());
            }
            return table_Headers;
        }
    }
}
