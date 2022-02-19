using System.Net;

namespace CleanArchitecture.Infrastructure.Email
{
    public class EmailSettings
    {
        public string? Host { get; set; }
        public int? Port { get; set; }
        public ICredentialsByHost? Credentials { get; set; }
        public bool? IsBodyHtml { get; set; }
        public bool? EnableSsl { get; set; }
    }
}
