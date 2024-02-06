using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class Match : IComparable<Match>
    {
        public int Id { get; set; }

        [JsonProperty("venue")]
        public string? Venue { get; set; }

        [JsonProperty("location")]
        public string? Location { get; set; }

        [JsonProperty("fifa_id")]
        public long FifaId { get; set; }

        [JsonProperty("weather")]
        public Weather Weather { get; set; }

        [JsonProperty("attendance")]
        public int Attendance { get; set; }

        [JsonProperty("officials")]
        public string[] Officials { get; set; }

        [JsonProperty("stage_name")]
        public string? StageName { get; set; }

        [JsonProperty("home_team_country")]
        public string? HomeTeamCountry { get; set; }

        [JsonProperty("away_team_country")]
        public string? AwayTeamCountry { get; set; }

        [JsonProperty("datetime")]
        public DateTimeOffset Datetime { get; set; }

        [JsonProperty("winner")]
        public string? Winner { get; set; }

        [JsonProperty("winner_code")]
        public string? WinnerCode { get; set; }


        [JsonProperty("home_team")]
        public HomeAndAwayTeam HomeTeam { get; set; }

        [JsonProperty("away_team")]
        public HomeAndAwayTeam AwayTeam { get; set; }


        [JsonProperty("home_team_events")]
        public TeamEvent[] HomeTeamEvents { get; set; }

        [JsonProperty("away_team_events")]
        public TeamEvent[] AwayTeamEvents { get; set; }


        [JsonProperty("home_team_statistics")]
        public TeamStatistics HomeTeamStatistics { get; set; }

        [JsonProperty("away_team_statistics")]
        public TeamStatistics AwayTeamStatistics { get; set; }


        [JsonProperty("last_event_update_at")]
        public DateTimeOffset LastEventUpdateAt { get; set; }

        [JsonProperty("last_score_update_at")]
        public DateTimeOffset? LastScoreUpdateAt { get; set; }

        public Match(int id, string? venue, string? location, long fifaId, Weather weather, int attendance, string[] officials, string? stageName, string? homeTeamCountry, string? awayTeamCountry, DateTimeOffset datetime, string? winner, string? winnerCode, HomeAndAwayTeam homeTeam, HomeAndAwayTeam awayTeam, TeamEvent[] homeTeamEvents, TeamEvent[] awayTeamEvents, TeamStatistics homeTeamStatistics, TeamStatistics awayTeamStatistics, DateTimeOffset lastEventUpdateAt, DateTimeOffset? lastScoreUpdateAt)
        {
            Id = id;
            Venue = venue;
            Location = location;
            FifaId = fifaId;
            Weather = weather;
            Attendance = attendance;
            Officials = officials;
            StageName = stageName;
            HomeTeamCountry = homeTeamCountry;
            AwayTeamCountry = awayTeamCountry;
            Datetime = datetime;
            Winner = winner;
            WinnerCode = winnerCode;
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            HomeTeamEvents = homeTeamEvents;
            AwayTeamEvents = awayTeamEvents;
            HomeTeamStatistics = homeTeamStatistics;
            AwayTeamStatistics = awayTeamStatistics;
            LastEventUpdateAt = lastEventUpdateAt;
            LastScoreUpdateAt = lastScoreUpdateAt;
        }

        public List<Player> GetAllHomeTeamPlayers()
        {
            List<Player> players = new List<Player>();

            foreach (var player in HomeTeamStatistics.StartingEleven)
            {
                players.Add(player);
            }

            foreach (var player in HomeTeamStatistics.Substitutes)
            {
                players.Add(player);
            }

            return players;
        }

        public List<Player> GetAllAwayTeamPlayers() 
        {
            List<Player> players = new List<Player>();

            foreach (var player in AwayTeamStatistics.StartingEleven)
            {
                players.Add(player);
            }

            foreach (var player in AwayTeamStatistics.Substitutes)
            {
                players.Add(player);  
            }


            return players;
        }

        public List<Player> GetHomeStartingElevenPlayers()
        {
            List<Player> players = new List<Player>();

            foreach (var player in HomeTeamStatistics.StartingEleven)
            {
                players.Add(player);
            }

            return players;
        }

        public List<Player> GetAwayStartingElevenPlayers()
        {
            List<Player> players = new List<Player>();

            foreach (var player in AwayTeamStatistics.StartingEleven)
            {
                players.Add(player);
            }

            return players;
        }

        public override bool Equals(object? obj) => obj is Match match && FifaId == match.FifaId;


        public override int GetHashCode() => HashCode.Combine(FifaId);


        public override string ToString() => $"Match: {HomeTeamCountry} vs {AwayTeamCountry} Score: {HomeTeam.Goals} - {AwayTeam.Goals} Winner: {WinnerCode}";

        public int CompareTo(Match? other) => -Attendance.CompareTo(other.Attendance);
        
    }

    public partial class HomeAndAwayTeam
    {


        [JsonProperty("country")]
        public string? Country { get; set; }

        [JsonProperty("code")]
        public string? Code { get; set; }

        [JsonProperty("goals")]
        public int Goals { get; set; }

        [JsonProperty("penalties")]
        public long Penalties { get; set; }
        public HomeAndAwayTeam(string? country, string? code, int goals, long penalties)
        {
            Country = country;
            Code = code;
            Goals = goals;
            Penalties = penalties;
        }

        public override string ToString() => $"Country: {Country} ({Code}), Goals scored: {Goals}, Penalties: {Penalties}";
        
    }

    public partial class TeamEvent
    {

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("type_of_event")]
        public string? TypeOfEvent { get; set; }

        [JsonProperty("player")]
        public string? Player { get; set; }

        [JsonProperty("time")]
        public string? Time { get; set; }

        public TeamEvent(long id, string? typeOfEvent, string? player, string? time)
        {
            Id = id;
            TypeOfEvent = typeOfEvent;
            Player = player;
            Time = time;
        }

        public override bool Equals(object? obj) => obj is TeamEvent teamEvent && Id == teamEvent.Id;
        public override int GetHashCode() => HashCode.Combine(Id);
        public override string ToString() => $"{Player} has recieved: {TypeOfEvent} in the {Time} minute";
        

    }

    public partial class TeamStatistics
    {
        public TeamStatistics(string? country, long attemptsOnGoal, long onTarget, long offTarget, long blocked, long woodwork, long corners, long offsides, long ballPossession, long passAccuracy, long numPasses, long passesCompleted, long distanceCovered, long ballsRecovered, long tackles, long clearances, int yellowCards, long redCards, long? foulsCommitted, string? tactics, List<Player> startingEleven, List<Player> substitutes)
        {
            Country = country;
            AttemptsOnGoal = attemptsOnGoal;
            OnTarget = onTarget;
            OffTarget = offTarget;
            Blocked = blocked;
            Woodwork = woodwork;
            Corners = corners;
            Offsides = offsides;
            BallPossession = ballPossession;
            PassAccuracy = passAccuracy;
            NumPasses = numPasses;
            PassesCompleted = passesCompleted;
            DistanceCovered = distanceCovered;
            BallsRecovered = ballsRecovered;
            Tackles = tackles;
            Clearances = clearances;
            YellowCards = yellowCards;
            RedCards = redCards;
            FoulsCommitted = foulsCommitted;
            Tactics = tactics;
            StartingEleven = startingEleven;
            Substitutes = substitutes;
        }

        [JsonProperty("country")]
        public string? Country { get; set; }

        [JsonProperty("attempts_on_goal")]
        public long AttemptsOnGoal { get; set; }

        [JsonProperty("on_target")]
        public long OnTarget { get; set; }

        [JsonProperty("off_target")]
        public long OffTarget { get; set; }

        [JsonProperty("blocked")]
        public long Blocked { get; set; }

        [JsonProperty("woodwork")]
        public long Woodwork { get; set; }

        [JsonProperty("corners")]
        public long Corners { get; set; }

        [JsonProperty("offsides")]
        public long Offsides { get; set; }

        [JsonProperty("ball_possession")]
        public long BallPossession { get; set; }

        [JsonProperty("pass_accuracy")]
        public long PassAccuracy { get; set; }

        [JsonProperty("num_passes")]
        public long NumPasses { get; set; }

        [JsonProperty("passes_completed")]
        public long PassesCompleted { get; set; }

        [JsonProperty("distance_covered")]
        public long DistanceCovered { get; set; }

        [JsonProperty("balls_recovered")]
        public long BallsRecovered { get; set; }

        [JsonProperty("tackles")]
        public long Tackles { get; set; }

        [JsonProperty("clearances")]
        public long Clearances { get; set; }

        [JsonProperty("yellow_cards")]
        public int YellowCards { get; set; }

        [JsonProperty("red_cards")]
        public long RedCards { get; set; }

        [JsonProperty("fouls_committed")]
        public long? FoulsCommitted { get; set; }

        [JsonProperty("tactics")]
        public string? Tactics { get; set; }

        [JsonProperty("starting_eleven")]
        public List<Player> StartingEleven { get; set; }

        [JsonProperty("substitutes")]
        public List<Player> Substitutes { get; set; }

        public override bool Equals(object? obj) => obj is TeamStatistics teamStatistics && Country == teamStatistics.Country;
        public override int GetHashCode() => HashCode.Combine(Country);
        
       
    }

    public partial class Weather
    {
        [JsonProperty("humidity")]
        public long Humidity { get; set; }

        [JsonProperty("temp_celsius")]
        public long TempCelsius { get; set; }

        [JsonProperty("temp_farenheit")]
        public long TempFarenheit { get; set; }

        [JsonProperty("wind_speed")]
        public long WindSpeed { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        public override string ToString() => $"Humidity: {Humidity}, Celsius: {TempCelsius}, Farenheit: {TempFarenheit}, Wind Speed: {WindSpeed}, {Description}";
    }

}
