namespace BloodDonationDatabase.Core.Entities
{
    public class Adress : BaseEntity
    {
        public Adress(string street, string city, string state, int zipCode, int donorId, Donor donor)
        {
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
            DonorId = donorId;
            Donor = donor;
        }

        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public int ZipCode { get; private set; }
        public int DonorId { get; private set; }
        public Donor Donor { get; private set; }
    }
}
