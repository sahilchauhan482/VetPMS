using FluentEmail.Core;

namespace VetPMS.Infrastructure.Email
{
    public class EmailService
    {
        private readonly IFluentEmail _fluentEmail;
        public EmailService(IFluentEmail fluentEmail) =>(_fluentEmail)=(fluentEmail);
        
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return _fluentEmail
                .To(email)
                .Subject(subject)
                .Body(htmlMessage, isHtml: true)
                .SendAsync();
        }
    }
}

