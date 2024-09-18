using BloodDonationDatabase.Core.Entities;
using System.Text.Json.Serialization;

namespace BloodDonationDatabase.Application.Model
{
    public class AdressViewModel
    {
        public AdressViewModel(string street, string city, string state, int zipCode)
        {
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
        }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }

        public static AdressViewModel FromEntity(Adress adress)
            => new(adress.Street,adress.City,adress.State,adress.ZipCode);

    }
}
