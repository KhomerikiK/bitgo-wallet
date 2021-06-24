using System.Threading.Tasks;
using BitgoWallet.Dtos;

namespace BitgoWallet.Bitgo.Clients.Interfaces
{
    public interface IBitGoExpressClient
    {
        public Task<ResponseDto> GenerateWallet(string coin, string label = "DefaultLabel", string passphrase = "DefaultPass");
        public Task<ResponseDto> GenerateAddress(string coin, string walletId);
    }
}
