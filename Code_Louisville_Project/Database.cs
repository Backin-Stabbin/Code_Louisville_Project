using System.Data.SQLite;
using System.IO;

namespace Code_Louisville {

    public class Database {
        public string FileName = "Computer_Data.sqlite";
        public SQLiteConnection DBConnection;

        public Database database { get; set; }

        public static void Create_DB_File(Database database) {
            if (File.Exists(database.FileName)) {
                File.Delete(database.FileName);
            }
            SQLiteConnection.CreateFile(database.FileName);
        }

        public static void Create_DB_Table(Database database, string query) {
            var command = new SQLiteCommand(query, database.DBConnection);
            command.ExecuteNonQuery();
        }

        public static void Insert_Data_To_Table(Database database, string query) {
            var command = new SQLiteCommand(query, database.DBConnection);
            command.ExecuteNonQuery();
        }

        public static SQLiteDataReader Read_DB_Data(Database database, string query) {
            var command = new SQLiteCommand(query, database.DBConnection);
            return command.ExecuteReader();
        }
    }
}
