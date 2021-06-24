
using System.ComponentModel.DataAnnotations;

namespace BitgoWallet.Http.Requests
{
    public class CreateWalletRequest
    {
        public string coin { get; set; }

        [Required(ErrorMessage = "A label is required", AllowEmptyStrings = false)]
        public string label { get; set; }

        [Required(ErrorMessage = "A passphrase is required", AllowEmptyStrings = false)]
        public string passphrase { get; set; }
    }
}