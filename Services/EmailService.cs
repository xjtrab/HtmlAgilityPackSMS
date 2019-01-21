
using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp;

public class EmailService : IEmailService
{
    public async Task<bool> SendEmail(string subject ,string body)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("通知", "xjtrab@126.com"));
        message.To.Add(new MailboxAddress("xjtrab", "xjtrab@126.com"));

        message.Subject = subject;

        message.Body = new TextPart("plain") { Text = body };

        using (var client = new SmtpClient())
        {
            // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
            client.ServerCertificateValidationCallback = (s, c, h, e) => true;

            client.Connect("smtp.126.com", 25, false);

            // Note: since we don't have an OAuth2 token, disable
            // the XOAUTH2 authentication mechanism.
            client.AuthenticationMechanisms.Remove("XOAUTH2");

            // Note: only needed if the SMTP server requires authentication
            client.Authenticate("xjtrab", "");

            client.Send(message);
            client.Disconnect(true);
            //test devops
        }
        return await Task.FromResult(true);
    }
}