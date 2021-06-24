using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

using BitgoWallet.Dtos;
using BitgoWallet.Bitgo.Requests;
using BitgoWallet.Bitgo.Objects;
using BitgoWallet.Bitgo.Clients.Interfaces;

namespace BitgoWallet.Bitgo.Clients
{
    public class BitGoExpressClient : Client, IBitGoExpressClient
    {
        public BitGoExpressClient(IOptions<Config> config) : base(config) { }

        public async Task<ResponseDto> GenerateWallet(
            string coin,
            string label = "DefaultLabel",
            string passphrase = "DefaultPass"
        )
        {
            string apiEndpoint = ExpressApiUrl + coin + "/wallet/generate";

            GenerateWalletRequest data = new()
            {
                label = label,
                passphrase = passphrase
            };
            ResponseDto response = await _post(apiEndpoint, data);
            if (response.success)
                response.data = JsonConvert.DeserializeObject<Wallet>(response.data);

            return response;
        }

        public async Task<ResponseDto> GenerateAddress(
            string coin,
            string walletId
        )
        {
            string apiEndpoint = ExpressApiUrl + coin + "/wallet/" + walletId + "/address";

            GenerateAddressRequest data = new();
            ResponseDto response = await _post(apiEndpoint, data);
            if (response.success)
                response.data = JsonConvert.DeserializeObject<Address>(response.data);

            return response;
        }


    }
}
