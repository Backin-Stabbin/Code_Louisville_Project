using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Treehouse.CodeChallenges {
    public class Program {
        public static void Main (string[] arg) { }

        public static List<WeatherForecast> DeserializeWeather(string fileName){
            var weatherForecast = new List<WeatherForecast>();
            using(var reader = new StreamReader(fileName))
            using(var jsonReader = new JsonTextReader(reader)){
                var serializer = new JsonSerializer();
                weatherForecast = serializer.Deserialize<List<WeatherForecast>>(jsonReader);

            }
            return weatherForecast;
        }

        public static WeatherForecast ParseWeatherForecast (string[] values) {
            var weatherForecast = new WeatherForecast ();
            weatherForecast.WeatherStationId = values[0];
            DateTime timeOfDay;
            if (DateTime.TryParse (values[1], out timeOfDay)) {
                weatherForecast.TimeOfDay = timeOfDay;
            }
            Condition condition;
            if (Enum.TryParse (values[2], out condition)) {
                weatherForecast.Condition = condition;
            }
            int temperature;
            if (int.TryParse (values[3], out temperature)) {
                weatherForecast.Temperature = temperature;
            }
            double precipitation;
            if (double.TryParse (values[4], out precipitation)) {
                weatherForecast.PrecipitationChance = precipitation;
            }
            if (double.TryParse (values[5], out precipitation)) {
                weatherForecast.PrecipitationAmount = precipitation;
            }
            return weatherForecast;
        }
    }
}