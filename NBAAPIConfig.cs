using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA
{
    class NBAAPIConfig
    {
        public static string Key { get => "bb01d7f3459348505f203191cfa06653fb9c15d4011c69e122b8948cb375c22f"; }

        public static long TimeStamp => DateTimeOffset.Now.ToUnixTimeSeconds();

        public static string BaseURL => "https://allsportsapi.com/api/basketball/";
    }
}
