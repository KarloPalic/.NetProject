using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class Player : IComparable<Player>
    {
        private readonly static char DEL = '.';

        [JsonProperty("shirt_number")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("captain")]
        public bool Captain { get; set; }

        [JsonProperty("position")]
        public string? Position { get; set; }

        public Player()
        {

        }
        public Player(long id, string? name, bool captain, string? position)
        {
            Id = id;
            Name = name;
            Captain = captain;
            Position = position;
        }

        public static string FormatForFileLines(Player player)
        {
            return $"{player.Id}{DEL}{player.Name}{DEL}{player.Captain}{DEL}{player.Position}";
        }

        public static Player FormatFromFile(string lines)
        {
            string[] details = lines.Split(DEL);
            return new Player(long.Parse(details[0]), details[1], bool.Parse(details[2]), details[3]);
        }

        public override string ToString() => $"Shirt number: {Id} - {(Captain ? "Captain" : "")} {Name} {Position}";
        public override bool Equals(object? obj) => obj is Player player && Id == player.Id && Name == player.Name;
        public override int GetHashCode() => HashCode.Combine(Id, Name);

        public int CompareTo(Player? other) => Id.CompareTo(other.Id);
        
    }
}
