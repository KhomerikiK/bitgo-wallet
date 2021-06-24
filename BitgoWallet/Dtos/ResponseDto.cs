namespace BitgoWallet.Dtos
{
    public class ResponseDto
    {
        public bool success{get; set;}
        public string message{get; set;}
        public dynamic data{get; set;}
    }
}