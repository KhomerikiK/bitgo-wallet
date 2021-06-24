using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BitgoWallet.Dtos;
using BitgoWallet.Http.Requests;
using BitgoWallet.Services.Interfaces;

namespace BitgoWallet.Http.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class WalletController : ControllerBase
    {
        public readonly IWalletService WalletService;

        public WalletController(
            IWalletService walletService
        )
        {
            WalletService = walletService;
        }

        [HttpPost]
        [Route("{coin}/wallet")]
        public async Task<ActionResult<ResponseDto>> CreateWallet(
            string coin, 
            [FromBody] CreateWalletRequest request
        )
        {
            request.coin = coin;
            return await WalletService.CreateWallet(request);
        }


        [HttpGet]
        [Route("{coin}/wallet/{walletId}")]
        public async Task<ActionResult<ResponseDto>> GetWallet(
            string coin, 
            string walletId
        )
        {
            return await WalletService.GetWallet(new GetWalletRequest{
                coin = coin,
                walletId = walletId
            });
        }

        [HttpPost]
        [Route("{coin}/wallet/{walletId}/address")]
        public async Task<ActionResult<ResponseDto>> CreateAddress(
            string coin,
            string walletId
        )
        {
            return await WalletService.CreateAddress(new CreateAddressRequest{
                walletId = walletId,
                coin = coin
            });
        }

    }
}
