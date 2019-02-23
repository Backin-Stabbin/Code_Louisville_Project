using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Soccer_Stats {

    public class  RootObject{
        public Player[] Player { get; set; }
    }

    public class Player {
        [JsonProperty ("first_name")]
        public string FirstName { get; set; }
        [JsonProperty ("id")]
        public long Id { get; set; }
        [JsonProperty ("points_per_game")]
        public string PointsPerGame { get; set; }
        [JsonProperty ("second_name")]
        public string SecondName { get; set; }
        [JsonProperty ("team_name")]
        public string TeamName { get; set; }
    }    
}