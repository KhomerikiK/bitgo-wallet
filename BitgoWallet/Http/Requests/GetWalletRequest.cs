
using System.ComponentModel.DataAnnotations;

namespace BitgoWallet.Http.Requests
{
    public class GetWalletRequest
    {
        [Required(ErrorMessage = "A coin is required", AllowEmptyStrings = false)]
        public string coin { get; set; }

        [Required(ErrorMessage = "A walletId is required", AllowEmptyStrings = false)]
        public string walletId { get; set; }
    }
}