using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NBA
{
    public class Teams
    {
        [JsonProperty(PropertyName = "team_key")]
        public int Team_key { get; set; }
        [JsonProperty(PropertyName = "team_name")]
        public int Team_name { get; set; }
        [JsonProperty(PropertyName = "league_key")]
        public int League_key { get; set; }
        
        [JsonProperty(PropertyName = "team_logo")]
        public  string Team_logo { get; set; }

    }
}
