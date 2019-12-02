using NBA.Infrastructure;
using NBA.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA
{
    class NBAManager
    {
        NetworkManager networkManager;

        public NBAManager()
        {
            networkManager = new NetworkManager();
        }

        public Task<IList<Country>> GetCountries()
        {
            return Task.Run(() =>
            {
                string burl = NBAAPIConfig.BaseURL;
                string key = NBAAPIConfig.Key;
                string urlNBA = $"{burl}?met=Countries&APIkey={key}";
                string json = networkManager.GetJson(urlNBA);

                IList<Country> searchResults = new List<Country>();
                if (json.Contains("success"))
                {
                    JObject countrySearch = JObject.Parse(json);
                    IList<JToken> results = countrySearch["result"].Children().ToList();
                    foreach (JToken result in results)
                    {
                        Country searchResult = result.ToObject<Country>();
                        searchResults.Add(searchResult);
                    }
                }
                return searchResults;
            });
        }

        public Task<IList<League>> GetLeagues()
        {
            return Task.Run(() =>
            {
                string burl = NBAAPIConfig.BaseURL;
                string key = NBAAPIConfig.Key;
                string urlNBA = $"{burl}?met=Leagues&APIkey={key}";
                string json = networkManager.GetJson(urlNBA);
                IList<League> leagsearchResults = new List<League>();
                if (json.Contains("success"))
                {
                    JObject leagueSearch = JObject.Parse(json);
                    IList<JToken> results = leagueSearch["result"].Children().ToList();
                    foreach (var result in results)
                    {
                        League leagsearchResult = result.ToObject<League>();
                        leagsearchResults.Add(leagsearchResult);
                    }
                }
                return leagsearchResults;
            });

        }

        public Task<Teams> GetTeams(string Team_key)
        {
            return Task.Run(() =>
            {
                string burl = NBAAPIConfig.BaseURL;
                string key = NBAAPIConfig.Key;
                string urlNBA = $"{burl}?&met=Teams&teamId={Team_key}&APIkey={key}";
                string json = networkManager.GetJson(urlNBA);

                JObject teamSearch = JObject.Parse(json);
                //  IList<JToken> results = teamSearch["result"].Children().ToList();
                Teams team = new Teams();
                team.Team_logo = teamSearch["result"][0]["team_logo"].ToString();
                return team;
            });
        }

        public Task<IList<Fixtures>> GetFixtures(string Date_Start, string Date_Finish)
        {
            return Task.Run(() =>
            {
                IList<Fixtures> fixturesResults = new List<Fixtures>();
                if (!string.IsNullOrEmpty(Date_Start) && !string.IsNullOrEmpty(Date_Finish))
                {
                    string burl = NBAAPIConfig.BaseURL;
                    string key = NBAAPIConfig.Key;
                    string urlNBA = $"{burl}?met=Fixtures&APIkey={key}&from={Date_Start}&to={Date_Finish}";
                    string json = networkManager.GetJson(urlNBA);

                    JObject fixturesSearch = JObject.Parse(json);
                    IList<JToken> results = fixturesSearch["result"].Children().ToList();
                    foreach (var result in results)
                    {
                        Fixtures fixturesResult = result.ToObject<Fixtures>();
                        fixturesResults.Add(fixturesResult);
                    }
                }
                return fixturesResults;
            });
        }




    }
}
