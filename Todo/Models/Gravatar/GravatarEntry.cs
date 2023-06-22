using Newtonsoft.Json;

namespace Todo.Models.Gravatar
{
    public class GravatarEntry
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("profileUrl")]
        public string ProfileUrl { get; set; }

        [JsonProperty("preferredUsername")]
        public string Username { get; set; }

        [JsonProperty("thumbnailUrl")]
        public string ThumbnailUrl { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

    }
}
