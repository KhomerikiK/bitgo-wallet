using System.Threading.Tasks;
using BitgoWallet.Dtos;
using BitgoWallet.Http.Requests;

namespace BitgoWallet.Services.Interfaces
{
    public interface IWalletService
    {
        public Task<ResponseDto> GetWallet(GetWalletRequest request);
        public Task<ResponseDto> CreateWallet(CreateWalletRequest request);
        public Task<ResponseDto> CreateAddress(CreateAddressRequest request);
    }
}