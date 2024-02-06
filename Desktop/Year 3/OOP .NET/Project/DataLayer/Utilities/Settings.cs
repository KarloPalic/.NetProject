using DataLayer.DAL;
using DataLayer.Model;
using Newtonsoft.Json;

namespace DataLayer.Utilities
{
    public class Settings
    {
        public const string filePath = @"./settings.txt";

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("gender")]
        [JsonConverter(typeof(GenderConverter))]
        public IRepository.Gender Gender { get; set; }

        [JsonProperty("favorite_team")]
        public string FavTeam { get; set; }


        [JsonProperty("player_names")]
        public List<string> FavPlayerNames { get; set; }

        [JsonProperty("resolution")]
        public string Resolution { get; set; }



        private Settings()
        {
        }

        public void SaveSettings()
        {

            string json = JsonConvert.SerializeObject(this);
            File.WriteAllText(filePath, json);
        }

        public static Settings LoadSettings()
        {
            if (!File.Exists(filePath))
            {
                return new Settings();
            }

            string content = File.ReadAllText(filePath);
            if (string.IsNullOrEmpty(content))
            {
                return new Settings();
            }

            Settings? settings = JsonConvert.DeserializeObject<Settings>(content);
            return (settings == null ? new Settings() : settings);
        }

        public static bool IsFirstRun()
        {
            return !File.Exists(filePath);
        }

        public class ResolutionSettings
        {
            public string Resolution { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }

            public ResolutionSettings(int width, int height)
            {
                Width = width;
                Height = height;
                Resolution = width.ToString() + "x" + height.ToString();    
            }
            public ResolutionSettings(int width, int height, string fullscreen)
            {
                Width = width;
                Height = height;
                Resolution = fullscreen;
            }

            public static ResolutionSettings ParseResolution(string resolutionString)
            {
                string[] resolution = resolutionString.Split('x');

                if (resolution.Length == 2 && int.TryParse(resolution[0], out int width) && int.TryParse(resolution[1], out int height))
                {
                    return new ResolutionSettings(width, height);
                }

                throw new ArgumentException("Invalid resolution format");
            }

            public override string ToString()
            {
                return Resolution;
            }
        }

        internal class GenderConverter : JsonConverter
        {
            public override bool CanConvert(Type g) => g == typeof(IRepository.Gender) || g == typeof(IRepository.Gender?);

            public override object ReadJson(JsonReader reader, Type g, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "Men":
                        return IRepository.Gender.Men;
                    case "Women":
                        return IRepository.Gender.Women;

                }
                throw new Exception("Cannot unmarshal type Position");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (IRepository.Gender)untypedValue;
                switch (value)
                {
                    case IRepository.Gender.Men:
                        serializer.Serialize(writer, "Men");
                        return;
                    case IRepository.Gender.Women:
                        serializer.Serialize(writer, "Women");
                        return;

                }
                throw new Exception("Cannot marshal type Position");
            }
        }

    }
}

