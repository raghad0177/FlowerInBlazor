using BlazorApp3.Shared;
using System.Net.Http.Json;

namespace BlazorApp3.Client.Serveses
{
    public class FlowerServes
    {
        private readonly HttpClient _httpClient;

        public FlowerServes(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Flower>> GetAllFlowers()
        {
            return await _httpClient.GetFromJsonAsync<List<Flower>>("api/Flower");
        }

        public async Task<Flower> GetFlowerById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Flower>($"api/Flower/{id}");
        }

        public async Task<Flower> AddFlower(Flower flower)
        {
            var flower1 = await _httpClient.PostAsJsonAsync("api/Flower", flower);

            return await flower1.Content.ReadFromJsonAsync<Flower>();
        }
    }
}
