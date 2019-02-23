using System;

/* Sample JSON 

[
  {
    "weather_station_id": "HGKL8Q",
    "time_of_day": "06/11/2016 0:00",
    "condition": "Rain",
    "temperature": 53,
    "precipitation_chance": 0.3,
    "precipitation_amount": 0.03
  },
  {
    "weather_station_id": "HGKL8Q",
    "time_of_day": "06/11/2016 6:00",
    "condition": "Cloudy",
    "temperature": 56,
    "precipitation_chance": 0.08,
    "precipitation_amount": 0.01
  },
  {
    "weather_station_id": "HGKL8Q",
    "time_of_day": "06/11/2016 12:00",
    "condition": "PartlyCloudy",
    "temperature": 70,
    "precipitation_chance": 0,
    "precipitation_amount": 0
  },
  {
    "weather_station_id": "HGKL8Q",
    "time_of_day": "06/11/2016 18:00",
    "condition": "Sunny",
    "temperature": 76,
    "precipitation_chance": 0,
    "precipitation_amount": 0
  },
  {
    "weather_station_id": "HGKL8Q",
    "time_of_day": "06/11/2016 19:00",
    "condition": "Clear",
    "temperature": 74,
    "precipitation_chance": 0,
    "precipitation_amount": 0
  }
]
*/

namespace Treehouse.CodeChallenges {
    public class WeatherForecast {
        public string WeatherStationId { get; set; }
        public DateTime TimeOfDay { get; set; }
        public Condition Condition { get; set; }
        public int Temperature { get; set; }
        public double PrecipitationChance { get; set; }
        public double PrecipitationAmount { get; set; }
    }

    public enum Condition {
        Rain,
        Cloudy,
        PartlyCloudy,
        PartlySunny,
        Sunny,
        Clear
    }
}