using BloodDonationDatabase.Core.Enum;
using MediatR;

namespace BloodDonationDatabase.Application.Notification
{
    public class OutOfStockNotification : INotification
    {
        public int Id { get; set; }
    }
}
