using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA
{
    public class Country
    {
        [JsonProperty (PropertyName = "country_key")]
        public int Country_key { get; set; }
        [JsonProperty(PropertyName = "country_name")]
        public string Country_name { get; set; }
    }
}
