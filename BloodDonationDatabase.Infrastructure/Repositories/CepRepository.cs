using BloodDonationDatabase.Application.Model;
using BloodDonationDatabase.Core.Entities;
using BloodDonationDatabase.Core.Repositories;
using BloodDonationDatabase.Infrastructure.Context;
using System.Text.Json;

namespace BloodDonationDatabase.Infrastructure.Repositories
{
    public class CepRepository : ICepRepository
    {
        private readonly HttpClient _httpClient;
        private readonly BloodDonationDbContext _context;

        public CepRepository(HttpClient httpClient, BloodDonationDbContext context)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://viacep.com.br");
            _context = context;
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

        public async Task Insert(Adress adress)
        {
            await _context.AddAsync(adress);
            await _context.SaveChangesAsync();
        }
    }
}
