using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BitgoWallet.Bitgo.Clients.Interfaces;
using BitgoWallet.Dtos;

namespace BitgoWallet.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class WalletController : ControllerBase
    {

        public readonly IBitgoClient BitgoClient;
        public readonly IBitGoExpressClient BitGoExpressClient;

        public WalletController(
            IBitgoClient bitgoClient, 
            IBitGoExpressClient bitGoExpressClient
        )
        {
            BitgoClient = bitgoClient;
            BitGoExpressClient = bitGoExpressClient;
        }

        [HttpGet]
        [Route("{coin}/wallet")]
        public async Task<ActionResult<ResponseDto>> GenerateWallet(
            string coin,
            string label = "DefaulTLabel",
            string passphrase = "DefaulPass"
        )
        {
            return await BitGoExpressClient.GenerateWallet(coin , label, passphrase);
        }


        [HttpGet]
        [Route("{coin}/wallet/{walletId}")]
        public async Task<ActionResult<ResponseDto>> GetWallet(
            string coin,
            string walletId
        )
        {
            return await BitgoClient.GetWallet(coin, walletId);
        }


        [HttpGet]
        [Route("{coin}/wallet/{walletId}/address")]
        public async Task<ActionResult<ResponseDto>> GenerateAddress(
            string coin,
            string walletId
        )
        {
            return await BitGoExpressClient.GenerateAddress(coin, walletId);
        }

    }
}
