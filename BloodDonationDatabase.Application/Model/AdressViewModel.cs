using BloodDonationDatabase.Core.Entities;

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

        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public int ZipCode { get; private set; }

        public static AdressViewModel FromEntity(Adress adress)
            => new(adress.Street,adress.City,adress.State,adress.ZipCode);

    }
}
