using DataLayer.Model;
using Newtonsoft.Json;
using System.Net;

namespace DataLayer.DAL
{
    public class API : IRepository
    {
        private HttpClient httpClient;

        public API() { 
            httpClient = new HttpClient();
        }

        
        public async Task<List<Match>> GetMatches(IRepository.Gender gender)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"https://worldcup-vua.nullbit.hr/{gender.ToString().ToLower()}/matches");

                if (response.IsSuccessStatusCode)
                {
                    string jsonData = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Match>>(jsonData) ?? new List<Match>();
                }
                else
                {
                    return new List<Match>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"API request failed: {ex.Message}");

            }
        }

        public async Task<Match> GetMatch(int id, IRepository.Gender gender)
        {
            try
            {
                List<Match> match = await GetMatches(gender);
                return match.FirstOrDefault(m => m.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Match>> GetMatchesByFifaCode(string fifaCode, IRepository.Gender gender)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync($"https://worldcup-vua.nullbit.hr/{gender.ToString().ToLower()}/matches/country?fifa_code={fifaCode.ToUpper()}");

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<Match>>(content) ?? new List<Match>();
                    }

                }
                return new List<Match>();
            }
            catch (Exception ex)
            {
                throw new Exception($"API request failed: {ex.Message}");
            }
        }



        public async Task<List<Team>> GetTeams(IRepository.Gender gender)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"https://worldcup-vua.nullbit.hr/{gender.ToString().ToLower()}/teams");

                if (response.IsSuccessStatusCode)
                {
                    string jsonData = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Team>>(jsonData) ?? new List<Team>();
                }
                else
                {
                    return new List<Team>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"API request failed: {ex.Message}");

            }
        }
        public async Task<Team> GetTeam(int id, IRepository.Gender gender)
        {
            try
            {
                List<Team> team = await GetTeams(gender);
                return team.FirstOrDefault(t => t.Id == id) ?? new Team();
            }
            catch
            {
                return new Team();
            }
        }


        public async Task<List<Player>> GetPlayers(string fifaCode, IRepository.Gender gender)
        {
            try
            {
                List<Match> matches = await GetMatchesByFifaCode(fifaCode,gender);

                if (matches.First().HomeTeam.Code == fifaCode)
                {
                   return matches.First().GetAllHomeTeamPlayers();
                }
                else
                {
                    return matches.First().GetAllAwayTeamPlayers();

                }
            }
            catch (Exception )
            {
                return new List<Player>();

            }
        }
        public async Task<Player> GetPlayer(int id, string fifaCode, IRepository.Gender gender)
        {
            try
            {
                List<Player> player = await GetPlayers(fifaCode, gender);
                return player.FirstOrDefault(p => p.Id == id) ?? new Player();
            }
            catch (Exception)
            {
                return new Player();
            }
        }

        public async Task<List<Player>> GetStartingPlayers(string fifaCode, IRepository.Gender gender)
        {
            try
            {
                List<Match> matches = await GetMatchesByFifaCode(fifaCode, gender);
                if (matches.First().HomeTeam.Code == fifaCode)
                {
                    return matches.First().GetHomeStartingElevenPlayers();
                }
                else
                {
                    return matches.First().GetAwayStartingElevenPlayers();
                }
            }
            catch (Exception)
            {
                return new List<Player>();
              
                
            }
        }
    }
}