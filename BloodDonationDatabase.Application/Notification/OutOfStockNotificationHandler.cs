using BloodDonationDatabase.Core.Repositories;
using BloodDonationDatabase.Core.Services;
using MediatR;

namespace BloodDonationDatabase.Application.Notification
{
    public class OutOfStockNotificationHandler : INotificationHandler<OutOfStockNotification>
    {
        public OutOfStockNotificationHandler(IBloodStockRespository respository, IEmailSenderService emailSender)
        {
            _respository = respository;
            _emailSender = emailSender;
        }
        private readonly IEmailSenderService _emailSender;
        private readonly IBloodStockRespository _respository;

        public async Task Handle(OutOfStockNotification notification, CancellationToken cancellationToken)
        {
            var bloodStock = await _respository.GetById(notification.Id);

            if (bloodStock.ReachedTheMinimum())
            {
                _emailSender.SendEmail("abigale.bernier@ethereal.email","Estoque atingiu o limite mínimo");
            }
        }
    }
}