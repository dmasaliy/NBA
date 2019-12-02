using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NBA
{
    class NetworkManager
    {
        public string GetJson(string url)
        {
            HttpClient client = new HttpClient();
            var task = client.GetAsync(url).Result;
            return task.Content.ReadAsStringAsync().Result;
        }
    }
}
