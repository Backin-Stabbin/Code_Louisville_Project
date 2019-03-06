using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Code_Louisville {

    class Project {
        static void Main() {

            // Clearing Console
            Console.Clear();

            try {
                // Used for list of Computers
                var computers = new List<Computer>();

                // Creating DB Instance
                var dataBase = new Database();

                // Making Connection String
                dataBase.DBConnection = new SQLiteConnection("Data Source=" + dataBase.FileName + ";Version=3;");

                // Creating DB File
                Database.Create_DB_File(dataBase);

                // Open DB Connection
                dataBase.DBConnection.Open();

                // Creating Computers Table
                Database.Create_DB_Table(dataBase);

                // Inserting Data to DB Table
                Database.Insert_Data_To_Table(dataBase);

                // Reading Data from DB
                var readerData = Database.Read_DB_Data(dataBase);

                // Adding data to computer list
                while (readerData.Read()) {
                    var computer = new Computer();
                    computer.Computer_Name = readerData.GetString(0);
                    computer.Building = readerData.GetString(1);
                    computer.Physical_Machine = readerData.GetBoolean(2);
                    computer.Active = readerData.GetBoolean(3);

                    computers.Add(computer);
                }

                // Getting list of possible buildings
                var buildingList = Building.Get_List_Of_Buildings(computers);

                // Displaying computers
                Computer.DisplayListOfComputers(computers, dataBase);

                // Closing DB Connection
                dataBase.DBConnection.Close();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine("error");
            }
        }
    }
}
