using Core.Utilities.Mail;
using Microsoft.Extensions.Configuration;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;

public class MailHelper : IMailHelper
{


    private readonly SmtpClient _smtpClient;

    public MailHelper(IConfiguration configuration)
    {


        _smtpClient = new SmtpClient();
    }

    public async Task SendMailAsync(string subject, string body, string recepients)
    {
        if (_smtpClient.IsConnected)
        {
            await _smtpClient.DisconnectAsync(true);
        }

        await _smtpClient.ConnectAsync("smtp.gmail.com", 587, false);

        _smtpClient.Authenticate("ulasergn007@gmail.com", "jfybcqbmbuprynmb");

        var email = new MimeMessage();

        email.From.Add(MailboxAddress.Parse("ulasergn007@gmail.com"));
        email.To.AddRange(InternetAddressList.Parse(recepients));

        email.Subject = subject;
        email.Body = new TextPart(TextFormat.Plain) { Text = body };

        await _smtpClient.SendAsync(email);

        if (_smtpClient.IsConnected)
        {
            await _smtpClient.DisconnectAsync(true);
        }
    }








}
