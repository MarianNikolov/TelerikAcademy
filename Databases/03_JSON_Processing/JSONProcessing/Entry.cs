using Newtonsoft.Json;

namespace JSONProcessing
{
    public class Entry
    {
        [JsonProperty("link")]
        public Link VideoLink { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
