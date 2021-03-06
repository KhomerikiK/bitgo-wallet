using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BitgoWallet.Bitgo.Objects;
using BitgoWallet.Dtos;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace BitgoWallet.Bitgo.Clients
{
    public class Client
    {
        static readonly HttpClient _httpClient = new();

        protected readonly string ExpressApiUrl; 
        protected readonly string BitgoApiUrl;
        private readonly string ApiKey;

        public Client(
            IOptions<Config> config
        )
        {
            ExpressApiUrl = config.Value.ExpressApiUrl;
            BitgoApiUrl = config.Value.ApiUrl;
            ApiKey = config.Value.ApiKey;
        }

        public async Task<ResponseDto> _post(string url, object requestData){
            try
            {
                string serialized = System.Text.Json.JsonSerializer.Serialize(requestData);
                StringContent requestContent = new(serialized, Encoding.UTF8, "application/json");

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);
                HttpResponseMessage response = await _httpClient.PostAsync(url, requestContent);

                string content = await response.Content.ReadAsStringAsync();
                return wrappResponse(response.IsSuccessStatusCode, content);
            }
            catch (Exception e)
            {    
                return new ResponseDto {
                    success = false,
                    message = e.Message,
                    data = null
                }; 
            }
            
        }

        protected async Task<ResponseDto> _get(string url){
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                string content = await response.Content.ReadAsStringAsync();
                return wrappResponse(response.IsSuccessStatusCode, content);
            }
            catch (Exception e)
            {    
                return new ResponseDto {
                    success = false,
                    message = e.Message,
                    data = null
                }; 
            }
            
        }

        private ResponseDto wrappResponse(bool succes, string content){
            ResponseDto ResponseDto = new ResponseDto {
                success = succes,
                message = null,
                data = content
            }; 
            if (!succes)
                ResponseDto.data = JsonConvert.DeserializeObject<Error>(content);
            return ResponseDto;
        }
    }
}