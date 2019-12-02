using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA.Model
{
    public class Fixtures
    {
        [JsonProperty(PropertyName = "league_key")]
        public int League_key { get; set; }

        [JsonProperty(PropertyName = "home_team_key")]
        public int Home_team_key { get; set; }

        [JsonProperty(PropertyName = "event_home_team")]
        public string Event_home_team { get; set; }

        [JsonProperty(PropertyName = "away_team_key")]
        public int Away_team_key { get; set; }

        [JsonProperty(PropertyName = "event_away_team")]
        public string Event_away_team { get; set; }
    }
}
