namespace BloodDonationDatabase.Core.Services
{
    public interface IEmailSenderService
    {
        void SendEmail(string toEmail,string subject);
    }
}
