using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Code_Louisville {
    class Project {
        static void Main() {

            Console.Clear();

            try {

                // Creating DB File
                Database.Create_DB_File();

                // Getting List of Building
                var buildingChoices = Building.Get_List_Of_Buildings();

                var computers = new List<Computer>();
                //var buildingChoice = "";

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
                            ('Computer-013', 'BLDG1', FALSE, TRUE),
                            ('Computer-014', 'BLDG1', FALSE, TRUE);
                        ";
                SQLiteCommand commandCreateData = new SQLiteCommand(sqlCreateData, m_dbConnection);

                commandCreateData.ExecuteNonQuery();

                var sqlSelectData = @"
                        SELECT * FROM Computers;
                        ";

                SQLiteCommand commandSelectData = new SQLiteCommand(sqlSelectData, m_dbConnection);

                var reader = commandSelectData.ExecuteReader();

                while (reader.Read()) {
                    var theComputer = new Computer(
                        computer_Name: reader.GetString(0),
                        building: reader.GetString(1),
                        physical_Machine: (bool) reader.GetValue(2),
                        active: (bool) reader.GetValue(3)
                    );

                    computers.Add(theComputer);
                }

                m_dbConnection.Close();

                //

                // Prompting to choose a building
                /*while (!buildingChoices.Contains(buildingChoice)) {
                    Console.WriteLine("
                    Test ");

                }*/

                var selectedComputers = Computer.SelectComputersFromBuilding(computers);
                var headers = Computer.GetHeaders();

                if (selectedComputers.Count > 0) {
                    Console.WriteLine(string.Format("{0} {1} {2,-20} {3,-10}",
                        headers[0].PadRight(20), headers[1].PadRight(10), headers[2], headers[3]));

                    foreach (Computer computer in selectedComputers) {
                        computer.Computer_Name = computer.Computer_Name.Replace("Computer", "Machine");

                        Console.WriteLine(string.Format("{0} {1} {2,-20} {3,-10}",
                            computer.Computer_Name.PadRight(20), computer.Building.PadRight(10), computer.Physical_Machine, computer.Active
                        ));
                    }
                }
                else {
                    Console.WriteLine("No Results to display");
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
