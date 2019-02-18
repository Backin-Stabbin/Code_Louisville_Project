using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Code_Louisville {
    class Final_Project {
        static void Main () {
            try {
                List<string> results = new List<string> ();
                string connectionString = "Server=localhost\\SQLEXPRESS_CL;Database=TestData;Trusted_Connection=Yes;";

                using (SqlConnection connection = new SqlConnection (connectionString)) {
                    string myQuery = @"
                        SELECT [ProductID]
                            ,[ProductName]
                            ,[Price]
                            ,[ProductDescription]
                        FROM [TestData].[dbo].[Products]";

                    SqlCommand myCommand = new SqlCommand (myQuery, connection);

                    connection.Open ();
                    SqlDataReader reader = myCommand.ExecuteReader ();

                    /*while (reader.Read ()) {
                        results.Add (
                            (string) reader["ProductID"],
                            (string) reader["ProductName"],
                            (string) reader["Price"],
                            (string) reader["ProductDescription"]
                        );
                    }

                    foreach (Product_Info prod () in results) {
                        Console.WriteLine (prod);
                    }*/

                    connection.Close ();
                }
            }
            catch (Exception ex) {
                Console.WriteLine (ex.Message);
            }

            //Console.WriteLine ("Press any key to finish.");
            //Console.ReadLine ();
        }
    }
}