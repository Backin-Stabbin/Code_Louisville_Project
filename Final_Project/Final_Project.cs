using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Code_Louisville {
    class Final_Project {
        static void Main () {
            try {
                List<Product_Info> results = new List<Product_Info> ();
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

                    while (reader.Read ()) {
                        
                        var theProduct = new Product_Info (

                            product_ID: reader.GetValue (0).ToString (),
                            product_Name: reader.GetValue (1).ToString (),
                            price: reader.GetValue (2).ToString (),
                            product_Description: reader.GetValue (3).ToString ()
                        );
                        
                        results.Add(theProduct);
                    }
                    connection.Close ();

                    foreach (Product_Info pi in results){
                        Console.WriteLine(pi.Product_ID + "   " + pi.Product_Name);
                    }
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