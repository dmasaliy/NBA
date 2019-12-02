using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA
{
    public class League
    {
        [JsonProperty(PropertyName = "league_key")]
        public int League_key { get; set; }

        [JsonProperty(PropertyName = "league_name")]
        public string League_name { get; set; }

        [JsonProperty(PropertyName = "country_key")]
        public int Country_key { get; set; }
    }
}
