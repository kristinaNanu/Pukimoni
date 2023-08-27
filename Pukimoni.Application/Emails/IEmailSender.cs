namespace Pukimoni.Application.Emails
{
    public interface IEmailSender
    {
        void Send(MailDto message);
    }
}
