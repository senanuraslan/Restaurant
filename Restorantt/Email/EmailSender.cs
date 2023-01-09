using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace Restorantt.Email
{
    public class EmailSender : IEmailSender
    {
        public EmailOptions Options { get; set; } 
        public EmailSender(IOptions<EmailOptions> emailOptions) //interface güvenlik için yaptık anahtar kelimemiz=emailOptions
        {
            Options = emailOptions.Value;
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage) //email onay mesaj
        {
            var client = new SendGridClient(Options.SendGridKey); //sunucu
            var mesaj = new SendGridMessage()
            {
                From = new EmailAddress("aslannsena@gmail.com", "SNA REstorant"),
                Subject = subject,
                PlainTextContent = htmlMessage,
                HtmlContent = htmlMessage

            };
            mesaj.AddTo(new EmailAddress(email)); //mesajı ekledi
            try
            {
                return client.SendEmailAsync(mesaj);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
