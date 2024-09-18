using BloodDonationDatabase.Core.Entities;
using System.Text.Json.Serialization;

namespace BloodDonationDatabase.Application.Model
{
    public class AdressItemViewModel
    {
        [JsonPropertyName("logradouro")]
        public string Street { get; set; }
        [JsonPropertyName("localidade")]
        public string City { get; set; }
        [JsonPropertyName("estado")]
        public string State { get; set; }
        [JsonPropertyName("cep")]
        public string ZipCode { get; set; }

        public Adress ToEntity()
            => new (Street, City, State, int.Parse(ZipCode));

    }
}
