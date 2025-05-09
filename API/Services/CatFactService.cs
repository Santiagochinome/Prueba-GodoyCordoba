using API.Models.CatFactApi.Models;
using System.Net.Http.Json;

namespace API.Services
{
    public class CatFactService
    {
        private readonly HttpClient _httpClient;

        public CatFactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CatFact?> GetRandomFactAsync()
        {
            return await _httpClient.GetFromJsonAsync<CatFact>("https://catfact.ninja/fact");
        }
    }
}
