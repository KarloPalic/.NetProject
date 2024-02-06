using DataLayer.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DAL
{
    public class JSON : IRepository
    {

        private string basePath = @"C:\Users\wExzEk\Desktop\Year 3\OOP .NET\Project\DataLayer\DAL\worldcup.sfg.io\";

        private string GetFilePath(string fileName, IRepository.Gender gender)
        {
            return Path.Combine(basePath, gender.ToString().ToLower(), $"{fileName}.json");
        }
        public async Task<Match> GetMatch(int id, IRepository.Gender gender)
        {
            try
            {
                List<Match> matches = await GetMatches(gender);
                return matches.FirstOrDefault(m => m.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting match: {ex.Message}");
            }
        }

        public async Task<List<Match>> GetMatches(IRepository.Gender gender)
        {
            try
            {
                string filePath = GetFilePath("matches", gender);
                if (File.Exists(filePath))
                {
                    string jsonData = await File.ReadAllTextAsync(filePath);
                    return JsonConvert.DeserializeObject<List<Match>>(jsonData) ?? new List<Match>();
                }
                else
                {
                    return new List<Match>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error reading matches JSON file: {ex.Message}");
            }
        }

        public async Task<List<Match>> GetMatchesByFifaCode(string fifaCode, IRepository.Gender gender)
        {
            try
            {
                string filePath = GetFilePath("matches", gender);
                if (File.Exists(filePath))
                {
                    string jsonData = await File.ReadAllTextAsync(filePath);
                    List<Match> allMatches = JsonConvert.DeserializeObject<List<Match>>(jsonData) ?? new List<Match>();

                    return allMatches.Where(match =>
                        match.HomeTeam.Code.Equals(fifaCode, StringComparison.OrdinalIgnoreCase) ||
                        match.AwayTeam.Code.Equals(fifaCode, StringComparison.OrdinalIgnoreCase)
                                            ).ToList();
                }
                else
                {
                    return new List<Match>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error reading matches by FIFA code from JSON file: {ex.Message}");
            }
        }

        public async Task<Player> GetPlayer(int id, string fifaCode, IRepository.Gender gender)
        {
            try
            {
                List<Player> players = await GetPlayers(fifaCode, gender);
                return players.FirstOrDefault(p => p.Id == id) ?? new Player();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting player: {ex.Message}");
            }
        }

        public async Task<List<Player>> GetPlayers(string fifaCode, IRepository.Gender gender)
        {
            try
            {
                List<Match> matches = await GetMatchesByFifaCode(fifaCode, gender);

                var allPlayers = new List<Player>();
                foreach (var match in matches)
                {
                    if (match.HomeTeam.Code.Equals(fifaCode, StringComparison.OrdinalIgnoreCase))
                    {
                        allPlayers.AddRange(match.GetAllHomeTeamPlayers());
                    }
                    else if (match.AwayTeam.Code.Equals(fifaCode, StringComparison.OrdinalIgnoreCase))
                    {
                        allPlayers.AddRange(match.GetAllAwayTeamPlayers());
                    }
                }

                return allPlayers;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting players: {ex.Message}");
            }
        }

        public async Task<List<Player>> GetStartingPlayers(string fifaCode, IRepository.Gender gender)
        {
            try
            {
                List<Match> matches = await GetMatchesByFifaCode(fifaCode, gender);
                var startingPlayers = new List<Player>();

                foreach (var match in matches)
                {
                    if (match.HomeTeam.Code.Equals(fifaCode, StringComparison.OrdinalIgnoreCase))
                    {
                        startingPlayers.AddRange(match.GetHomeStartingElevenPlayers());
                    }
                    else if (match.AwayTeam.Code.Equals(fifaCode, StringComparison.OrdinalIgnoreCase))
                    {
                        startingPlayers.AddRange(match.GetAwayStartingElevenPlayers());
                    }
                }

                return startingPlayers;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting starting players: {ex.Message}");
            }
        }

        public async Task<Team> GetTeam(int id, IRepository.Gender gender)
        {
            try
            {
                List<Team> teams = await GetTeams(gender);
                return teams.FirstOrDefault(t => t.Id == id) ?? new Team();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting team: {ex.Message}");
            }
        }

        public async Task<List<Team>> GetTeams(IRepository.Gender gender)
        {
            try
            {
                string filePath = GetFilePath("teams", gender);
                if (File.Exists(filePath))
                {
                    string jsonData = await File.ReadAllTextAsync(filePath);
                    return JsonConvert.DeserializeObject<List<Team>>(jsonData) ?? new List<Team>();
                }
                else
                {
                    return new List<Team>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error reading teams JSON file: {ex.Message}");
            }
        }
    }
}
