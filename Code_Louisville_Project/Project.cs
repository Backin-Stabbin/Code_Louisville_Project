using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Code_Louisville {
    class Project {
        static void Main() {

            Console.Clear();

            try {

                string sqlCreateTable = @"
                        CREATE TABLE Computers (
                            Computer_Name VARCHAR(20) PRIMARY KEY NOT NULL,
                            Building VARCHAR(25) NOT NULL,
                            Physical_Machine BIT NOT NULL DEFAULT '1',
                            Active BIT NOT NULL DEFAULT '0'
                        );
                    ";
                var sqlCreateData = @"
                    INSERT INTO Computers
                        (Computer_Name, Building, Physical_Machine, Active)
                    VALUES
                        ('Computer-013', 'BLDG1', FALSE, TRUE),
                        ('Computer-014', 'BLDG1', FALSE, TRUE);
                    ";
                var sqlSelectData = @"
                    SELECT * FROM Computers;
                    ";

                //
                // To do List
                //
                var computers = new List<Computer>();
                //var buildingChoice = "";

                // Prompting to choose a building
                /*while (!buildingChoices.Contains(buildingChoice)) {
                    Console.WriteLine("
                    Test ");

                }*/

                //
                //
                // Getting List of Building
                var buildingChoices = Building.Get_List_Of_Buildings();

                // Creating DB Instance
                var dataBase = new Database();

                // Making Connection String
                dataBase.DBConnection = new SQLiteConnection("Data Source=" + dataBase.FileName + ";Version=3;");

                // Creating DB File
                Database.Create_DB_File(dataBase);

                // Open DB Connection
                dataBase.DBConnection.Open();

                // Creating Computers Table
                Database.Create_DB_Table(dataBase, sqlCreateTable);

                // Inserting Data to DB Table
                Database.Insert_Data_To_Table(dataBase, sqlCreateData);

                // Reading Data from DB
                var reader = Database.Read_DB_Data(dataBase, sqlSelectData);

                // Adding data to computer list
                while (reader.Read()) {
                    var theComputer = new Computer(
                        computer_Name: reader.GetString(0),
                        building: reader.GetString(1),
                        physical_Machine: (bool) reader.GetValue(2),
                        active: (bool) reader.GetValue(3)
                    );

                    computers.Add(theComputer);
                }

                // Closing DB Connection
                dataBase.DBConnection.Close();

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

            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine("error");
            }
        }
    }
}
