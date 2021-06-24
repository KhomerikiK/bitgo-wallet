using Newtonsoft.Json;

namespace BitgoWallet.Bitgo.Objects
{
    public class Address
    {
        [JsonProperty("id")]
        public string id { get; internal set; }

        [JsonProperty("address")]
        public string address { get; internal set; }

        [JsonProperty("coin")]
        public string coin { get; internal set; }

        [JsonProperty("wallet")]
        public string wallet { get; internal set; }
 
    }
}