using BloodDonationDatabase.Application.Model;
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
            _httpClient.BaseAddress = new Uri("https://viacep.com.br");
        }

        public async Task<Adress?> CheckAddress(string cep)
        {
            var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");

            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
                var adressItem = JsonSerializer.Deserialize<AdressItemViewModel>(jsonResult);
                var zipCodeWithout = adressItem.ZipCode.Replace("-","");
                adressItem.ZipCode = zipCodeWithout;
                var adress = adressItem.ToEntity();

                return adress;
            }
            return null;

        }
    }
}
