using System.Data.SQLite;
using System.IO;

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
        public string InsertDataQuery = @"
            INSERT INTO Computers
                (Computer_Name, Building, Physical_Machine, Active)
            VALUES
                ('Computer-013', 'BLDG1', FALSE, TRUE),
                ('Computer-014', 'BLDG1', FALSE, TRUE)
            ;
        ";
        public string SelectDataQuery = @"
            SELECT
                *
            FROM
                Computers
            ;
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

        public static void Insert_Data_To_Table(Database database) {
            var command = new SQLiteCommand(database.InsertDataQuery, database.DBConnection);
            command.ExecuteNonQuery();
        }

        public static SQLiteDataReader Read_DB_Data(Database database) {
            var command = new SQLiteCommand(database.SelectDataQuery, database.DBConnection);
            return command.ExecuteReader();
        }
    }
}
