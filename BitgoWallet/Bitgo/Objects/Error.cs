using Newtonsoft.Json;

namespace BitgoWallet.Bitgo.Objects
{
    public class Error
    {
        [JsonProperty("error")]
        public string error { get; internal set; }

        [JsonProperty("name")]
        public string name { get; internal set; }

        [JsonProperty("requestId")]
        public string requestId { get; internal set; }
    }
}