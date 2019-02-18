using System;
using System.Collections.Generic;
using System.IO;

namespace Treehouse.CodeChallenges {

    public class Program {

        public static void Main () {

        }

        public static WeatherForecast ParseWeatherForecast (string[] values) {
            WeatherForecast weatherForecast = new WeatherForecast ();
            weatherForecast.WeatherStationId = values[0];
            DateTime timeOfDay;
            if (DateTime.TryParse (values[1], out timeOfDay)) {
                weatherForecast.TimeOfDay = timeOfDay;
            }

            return weatherForecast;
        }

    }

}
