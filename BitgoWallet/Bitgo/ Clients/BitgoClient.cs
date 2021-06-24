using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using BitgoWallet.Dtos;
using BitgoWallet.Bitgo.Objects;
using BitgoWallet.Bitgo.Clients.Interfaces;

namespace BitgoWallet.Bitgo.Clients
{
    public class BitgoClient : Client, IBitgoClient
    {
        public BitgoClient(IOptions<Config> config) : base(config) { }

        public async Task<ResponseDto> GetWallet(
            string coin,
            string walletId
        )
        {
            string apiEndpoint = BitgoApiUrl + coin + "/wallet/" + walletId;
            ResponseDto response = await _get(apiEndpoint);
            if (response.success)
                response.data = JsonConvert.DeserializeObject<Wallet>(response.data);

            return response;
        }
    }
}
