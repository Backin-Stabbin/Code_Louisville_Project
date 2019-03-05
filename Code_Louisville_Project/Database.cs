using System.Data.SQLite;
using System.IO;

namespace Code_Louisville {

    public class Database {
        public string FileName = "Computer_Data.sqlite";
        public SQLiteConnection DBConnection = new SQLiteConnection("Data Source=" + Get_DB_Filename() + ";Version=3;");

        public Database database { get; set; }

        public static string Get_DB_Filename() {

            var database = new Database();
            var fileName = database.FileName;
            return fileName;
        }

        public static void Create_DB_File() {
            var fileName = Get_DB_Filename();

            if (File.Exists(fileName)) {
                File.Delete(fileName);
            }

            SQLiteConnection.CreateFile(fileName);
        }

        public static void Open_DB_Connection() {
            var database = new Database();
            var dBConnection = database.DBConnection;
            dBConnection.Open();

        }

        public static void Close_DB_Connection() {
            var database = new Database();
            var dBConnection = database.DBConnection;
            dBConnection.Close();

        }

        public static void Create_DB_Table(string query) {
            var database = new Database();
            var dBConnection = database.DBConnection;
            var command = new SQLiteCommand(query, dBConnection);

            command.ExecuteNonQuery();
        }

        public static void Insert_Data_To_Table(string query) {
            var database = new Database();
            var dBConnection = database.DBConnection;
            var command = new SQLiteCommand(query, dBConnection);

            command.ExecuteNonQuery();
        }

        public static SQLiteDataReader Read_DB_Data(string query) {
            var database = new Database();
            var dBConnection = database.DBConnection;
            var command = new SQLiteCommand(query, dBConnection);

            return command.ExecuteReader();
        }
    }
}
