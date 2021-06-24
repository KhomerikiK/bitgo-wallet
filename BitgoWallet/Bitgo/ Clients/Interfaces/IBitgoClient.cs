using System.Threading.Tasks;
using BitgoWallet.Dtos;

namespace BitgoWallet.Bitgo.Clients.Interfaces
{
    public interface IBitgoClient
    {
        public Task<ResponseDto> GetWallet(string coin, string walletId);
    }
}
