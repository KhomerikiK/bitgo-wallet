using System.Collections.Generic;
using Newtonsoft.Json;

namespace BitgoWallet.Bitgo.Objects
{
    public class User
    {
        [JsonProperty("user")]
        public string user { get; internal set; }

        [JsonProperty("permissions")]
        public List<string> permissions{get; internal set;}
    }
}