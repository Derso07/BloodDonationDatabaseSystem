namespace BloodDonationDatabase.Core.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsDeleted { get; private set; } = false;

        public void SetAsDeleted()
        {
            IsDeleted = true;
        }
    }
}
