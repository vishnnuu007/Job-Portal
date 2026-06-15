using Domain.Helper;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Domain.Services
{
    public class EmailService : IEmailService
    {
        private readonly MailSettings _mail;
        private readonly IConfiguration _config;

        public EmailService(IOptions<MailSettings> mail, IConfiguration config)
        {
            _mail = mail.Value;
            _config = config;

        }

        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            try
            {
                var FromMail = _config.GetSection("MailSettings")["FromMail"];
                var DisplayName = _config.GetSection("MailSettings")["DisplayName"];
                var email = new MimeMessage();
                email.From.Add(new MailboxAddress(DisplayName, FromMail));
                email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
                email.Subject = mailRequest.Subject;

                var builder = new BodyBuilder();
                builder.HtmlBody = mailRequest.Body;
                email.Body = builder.ToMessageBody();
                using var smtp = new SmtpClient();
                smtp.Connect(_mail.Host, _mail.Port, _mail.UseSSL);
                smtp.Authenticate(_mail.UserMail, _mail.Password);

                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
        }
    }
}

