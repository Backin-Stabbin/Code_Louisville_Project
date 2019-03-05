using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;

namespace Code_Louisville {
    class Project {
        static void Main() {

            Console.Clear();

            try {
                // List for Computers
                var fileName = "Computer_Data.sqlite";
                var computers = new List<Computer>();
                var buildingChoice = "";
                var buildingChoices = new List<string> {
                    "BLDG1",
                    "BLDG2",
                    "BLDG3",
                    "BLDG4",
                    "BLDG5"
                };

                if (File.Exists(fileName)) {
                    File.Delete(fileName);
                    Console.WriteLine("Deleting current DB File and recreating");
                }
                else {
                    Console.WriteLine("File does not exist");
                }

                SQLiteConnection.CreateFile("Computer_Data.sqlite");
                SQLiteConnection m_dbConnection;

                m_dbConnection = new SQLiteConnection("Data Source=Computer_Data.sqlite;Version=3;");
                m_dbConnection.Open();

                string sqlCreateTable = @"
                        CREATE TABLE Computers (
                            Computer_Name VARCHAR(20) PRIMARY KEY NOT NULL,
                            Building VARCHAR(25) NOT NULL,
                            Physical_Machine BIT NOT NULL DEFAULT '1',
                            Active BIT NOT NULL DEFAULT '0'
                        );
                    ";

                var commandCreateTable = new SQLiteCommand(sqlCreateTable, m_dbConnection);

                commandCreateTable.ExecuteNonQuery();

                var sqlCreateData = @"
                        INSERT INTO Computers
                            (Computer_Name, Building, Physical_Machine, Active)
                        VALUES
                            ('Computer-013', 'BLDG1', 'FALSE', 'TRUE'),
                            ('Computer-014', 'BLDG1', 'FALSE', 'TRUE');
                        ";
                SQLiteCommand commandCreateData = new SQLiteCommand(sqlCreateData, m_dbConnection);

                SQLiteDataReader reader = commandCreateData.ExecuteReader();

                while (reader.Read()) {
                    var theComputer = new Computer(
                        computer_Name: reader.GetString(0),
                        building: reader.GetString(1),
                        physical_Machine: reader.GetBoolean(2),
                        active: reader.GetBoolean(3)
                    );

                    computers.Add(theComputer);
                }

                m_dbConnection.Close();

                //Menu.DisplayMenu();

                // Prompting to choose a building
                /*while (!buildingChoices.Contains(buildingChoice)) {
                    Console.WriteLine("
                    Test ");

                }*/

                foreach (Computer computer in computers) {
                    if (computer.Building == "BLDG1 ") {
                        computer.Computer_Name = computer.Computer_Name.Replace("Computer ", "Machine ");

                        Console.WriteLine(
                            " { 0, 20 } { 1, 8 } { 2, 6 } { 3, 6 }",
                            computer.Computer_Name, computer.Building, computer.Physical_Machine, computer.Active
                        );
                    }

                }

                //Console.WriteLine(computers.Count);

            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine("error");
            }

            //Console.WriteLine ("Press any key to finish.");
            //Console.ReadLine ();
        }
    }
}
