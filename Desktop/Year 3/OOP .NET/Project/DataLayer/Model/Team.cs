using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class Team : IComparable<Team>
    {
        private static readonly char DEL = '|';

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("alternate_name")]
        public string AlternateName { get; set; }

        [JsonProperty("fifa_code")]
        public string FifaCode { get; set; }

        [JsonProperty("group_id")]
        public long GroupId { get; set; }

        [JsonProperty("group_letter")]
        public string GroupLetter { get; set; }

        [JsonProperty("wins")]
        public long Wins { get; set; }

        [JsonProperty("draws")]
        public long Draws { get; set; }

        [JsonProperty("losses")]
        public long Losses { get; set; }

        [JsonProperty("games_played")]
        public long GamesPlayed { get; set; }

        [JsonProperty("points")]
        public long Points { get; set; }

        [JsonProperty("goals_for")]
        public long GoalsFor { get; set; }

        [JsonProperty("goals_against")]
        public long GoalsAgainst { get; set; }

        [JsonProperty("goal_differential")]
        public long GoalDifferential { get; set; }

        public Team()
        {

        }

        public Team(long id, string country, string? alternateName, string fifaCode, long groupId, string groupLetter, long wins, long draws, long losses, long gamesPlayed, long points, long goalsFor, long goalsAgainst, long goalDifferential)
        {
            Id = id;
            Country = country;
            AlternateName = alternateName;
            FifaCode = fifaCode;
            GroupId = groupId;
            GroupLetter = groupLetter;
            Wins = wins;
            Draws = draws;
            Losses = losses;
            GamesPlayed = gamesPlayed;
            Points = points;
            GoalsFor = goalsFor;
            GoalsAgainst = goalsAgainst;
            GoalDifferential = goalDifferential;
        }

        public static string FormatForFileLines(Team team)
        {
            return $"{team.Id}{DEL}{team.Country}{DEL}{(team.AlternateName is null ? "No Alternate Name" : team.AlternateName)}{DEL}{team.FifaCode}{DEL}{team.GroupId}{DEL}{team.GroupLetter}{DEL}{team.Wins}{DEL}{team.Draws}{DEL}{team.Losses}{DEL}{team.GamesPlayed}{DEL}{team.Points}{DEL}{team.GoalsFor}{DEL}{team.GoalsAgainst}{DEL}{team.GoalDifferential}";
        }

        public static Team FormatFromFile(string lines)
        {
            try
            {
                string[] details = lines.Split(DEL);

                long id = long.Parse(details[0]);
                string country = details[1];
                string alternateName = details[2];
                string fifaCode = details[3];
                long groupId = long.Parse(details[4]);
                string groupLetter = details[5];
                long wins = long.Parse(details[6]);
                long draws = long.Parse(details[7]);
                long losses = long.Parse(details[8]);
                long gamesPlayed = long.Parse(details[9]);
                long points = long.Parse(details[10]);
                long goalsFor = long.Parse(details[11]);
                long goalsAgainst = long.Parse(details[12]);
                long goalDifferential = long.Parse(details[13]);

                return new Team(id, country, alternateName, fifaCode, groupId, groupLetter, wins, draws, losses, gamesPlayed, points, goalsFor, goalsAgainst, goalDifferential);
            }
            catch (Exception)
            {
                return new Team();
            }
        }

        public override string ToString() => $"{Country} ({FifaCode})";
        public override bool Equals(object? obj) => obj is Team team && Id == team.Id;
        public override int GetHashCode() => HashCode.Combine(Id);

        public int CompareTo(Team? other) => Id.CompareTo(other.Id);
        
    }
}
