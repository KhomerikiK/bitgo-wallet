using Newtonsoft.Json;

namespace BitgoWallet.Bitgo.Requests
{
    public class GenerateWalletRequest
    {
        [JsonProperty("label")]
        public string label { get; internal set; }
        [JsonProperty("passphrase")]
        public string passphrase { get; internal set; } 
    }
}
