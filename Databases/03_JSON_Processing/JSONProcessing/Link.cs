using Newtonsoft.Json;

namespace JSONProcessing
{
    public class Link
    {
        private string embedCorrectURL;

        [JsonIgnore]
        public string URL { get; set; }

        [JsonProperty("@href")]
        public string Href
        {
            get
            {
                return this.embedCorrectURL;
            }
            set
            {
                /* because does not permit cross-origin framing in browser(FF).*/
                value = value.Replace("watvh?v=", "embed/");

                this.embedCorrectURL = value;
            }
        }
    }
}