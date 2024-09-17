using BloodDonationDatabase.Core.Entities;
using BloodDonationDatabase.Core.Repositories;
using System.Text.Json;

namespace BloodDonationDatabase.Infrastructure.Repositories
{
    public class CepRepository : ICepRepository
    {
        private readonly HttpClient _httpClient;

        public CepRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Adress?> CheckAddress(string cep)
        {
            var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");

            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
                var adress = JsonSerializer.Deserialize<Adress>(jsonResult);
                return adress;
            }
            return null;

        }
    }
}
