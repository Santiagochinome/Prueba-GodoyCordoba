using API.Models;
using System.Net.Http.Json;
using System.Web;

namespace API.Services
{
    public class GifService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "voaNIOg1u7ONPbckzWK71C48YqCOkhVP";

        public GifService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string?> SearchGifAsync(string query)
        {
            var encodedQuery = HttpUtility.UrlEncode(query);
            var url = $"https://api.giphy.com/v1/gifs/search?api_key={ApiKey}&q={encodedQuery}&limit=1&offset=0&rating=g&lang=en";

            var response = await _httpClient.GetFromJsonAsync<GifResponse>(url);

            return response?.Data?.FirstOrDefault()?.Images?.Original?.Url;
        } 
    }
}
