using System.Threading.Tasks;
using BitgoWallet.Bitgo.Clients.Interfaces;
using BitgoWallet.Dtos;
using BitgoWallet.Http.Requests;
using BitgoWallet.Services.Interfaces;

namespace BitgoWallet.Services
{
    public class WalletService : IWalletService
    {
        public readonly IBitgoClient BitgoClient;
        public readonly IBitGoExpressClient BitGoExpressClient;

        public WalletService(
            IBitgoClient bitgoClient, 
            IBitGoExpressClient bitGoExpressClient
        )
        {
            BitgoClient = bitgoClient;
            BitGoExpressClient = bitGoExpressClient;
        }

        public Task<ResponseDto> CreateAddress(CreateAddressRequest request)
        {
            return BitGoExpressClient.GenerateAddress(request.coin, request.walletId);
        }

        public Task<ResponseDto> CreateWallet(CreateWalletRequest request)
        {
            return BitGoExpressClient.GenerateWallet(request.coin, request.label, request.passphrase);
        }

        public Task<ResponseDto> GetWallet(GetWalletRequest request)
        {
            return BitgoClient.GetWallet(request.coin, request.walletId);
        }
    }
}