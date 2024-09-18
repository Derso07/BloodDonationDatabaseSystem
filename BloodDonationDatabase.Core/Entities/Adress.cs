namespace BloodDonationDatabase.Core.Entities
{
    public class Adress : BaseEntity
    {
        public Adress() { }

        public Adress(string street, string city, string state, int zipCode)
        {
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        public Adress(string street, string city, string state, int zipCode, Donor donor)
        {
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
            Donor = donor;
        }

        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public int ZipCode { get; private set; }
        public Donor Donor { get; private set; }
    }
}
