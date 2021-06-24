using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BitgoWallet.Bitgo.Objects
{
    public class Wallet
    {
        [JsonProperty("id")]
        public string id { get; internal set; }
        [JsonProperty("label")]
        public string label { get; internal set; }

        [JsonProperty("users")]
        public List<User> users {get; internal set;}

        [JsonProperty("balance")]
        public int balance { get; internal set; }

        [JsonProperty("confirmedBalance")]
        public int confirmedBalance { get; internal set; }

        [JsonProperty("spendableBalanceString")]
        public int spendableBalanceString { get; internal set; }

        [JsonProperty("receiveAddress")]
        public Address receiveAddress {get; internal set;}
    }
}
