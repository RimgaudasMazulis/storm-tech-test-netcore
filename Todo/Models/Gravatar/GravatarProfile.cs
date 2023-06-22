using Newtonsoft.Json;
using System.Collections.Generic;

namespace Todo.Models.Gravatar
{
    public class GravatarProfile
    {
        [JsonProperty("entry")]
        public List<GravatarEntry> Entry { get; set; }
    }
}
