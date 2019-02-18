using System;
using System.Collections.Generic;
using System.IO;

namespace Soccer_Stats {

    class Program {

        static void Main () {

            string currentdirectory = Directory.GetCurrentDirectory ();
            DirectoryInfo directory = new DirectoryInfo (currentdirectory);
            var fileSoccerGameResultscsv = Path.Combine (directory.FullName, "SoccerGameResults.csv");
            var fileContents = ReadSoccerResults (fileSoccerGameResultscsv);

            Console.WriteLine (fileContents.Count);
        }

        public static string ReadFile (string fileName) {
            using (var reader = new StreamReader (fileName)) {
                return reader.ReadToEnd ();
            }
        }

        public static List<Game_Result> ReadSoccerResults (string fileName) {
            var soccerResults = new List<Game_Result> ();
            using (var reader = new StreamReader (fileName)) {
                string line = "";
                reader.ReadLine ();
                while ((line = reader.ReadLine ()) != null) {
                    var gameResult = new Game_Result ();
                    string[] values = line.Split (',');
                    DateTime gameDate;
                    if (DateTime.TryParse (values[0], out gameDate)) {
                        gameResult.GameDate = gameDate;
                    }
                    gameResult.TeamName = values[1];
                    HomeOrAway homeOrAway;
                    if (Enum.TryParse (values[2], out homeOrAway)) {
                        gameResult.HomeOrAway = homeOrAway;
                    }
                    soccerResults.Add (gameResult);
                    int parseInt;
                    if (int.TryParse (values[3], out parseInt)) {
                        gameResult.Goals = parseInt;
                    }
                    if (int.TryParse (values[4], out parseInt)) {
                        gameResult.GoalAttempts = parseInt;
                    }
                    if (int.TryParse (values[5], out parseInt)) {
                        gameResult.ShotsOnGoal = parseInt;
                    }
                    if (int.TryParse (values[6], out parseInt)) {
                        gameResult.ShotsOffGoal = parseInt;
                    }
                    double possessionPercent;
                    if (double.TryParse(values[7], out possessionPercent)){
                        gameResult.PossessionPercent = possessionPercent;
                    }
                    
                }

            }
            return soccerResults;
        }
    }
}