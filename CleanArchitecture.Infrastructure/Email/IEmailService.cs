using System.Net.Mail;

namespace CleanArchitecture.Infrastructure.Email
{
    public interface IEmailService
    {
        void SendEmail(MailAddress from, IEnumerable<string> mailTo, string subject, string body, IEnumerable<File>? files = null, IEnumerable<string>? cc = null, IEnumerable<string>? bcc = null, MailPriority? priority = null);
        bool IsEmailValid(string email);
        bool IsEmailFromDomain(string email, string? domain = null);
    }
}
