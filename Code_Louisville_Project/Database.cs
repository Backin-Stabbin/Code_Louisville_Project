using System.IO;

namespace Code_Louisville {

    public class Database {
        public string FileName = "Computer_Data.sqlite";

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
        }
    }
}
