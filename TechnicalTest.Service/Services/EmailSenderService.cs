using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechnicalTest.Core.Model;
using TechnicalTest.Service.IServices;
using TechnicalTest.Core.Dto;

namespace TechnicalTest.Service.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly EmailSettings _emailSettings;
        public EmailSenderService(
            IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                var mimeMessage = new MimeMessage();

                mimeMessage.From.Add(new MailboxAddress(_emailSettings.Name, _emailSettings.Address));

                mimeMessage.To.Add(new MailboxAddress(email));

                mimeMessage.Subject = subject;

                mimeMessage.Body = new TextPart("html")
                {
                    Text = message
                };

                using (var client = new SmtpClient())
                {
                    // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    await client.ConnectAsync(_emailSettings.Host, _emailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);

                    // Note: only needed if the SMTP server requires authentication
                    await client.AuthenticateAsync(_emailSettings.Address, _emailSettings.Password);

                    await client.SendAsync(mimeMessage);

                    await client.DisconnectAsync(true);
                }

            }
            catch (Exception ex)
            {
                // TODO: handle exception
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<bool> EnviarMailRegistro(UsuarioEmailDto request)
        {
            try
            {
                var message = "<h3> Hola " + request.Nombre + " " + request.Apellido + " este mail es para confirmar tu cuenta</h3>";
                message += "</br>";
                message += "<a href='" + request.Link + "'>Click aqui para continuar</a>";
                message += "<p>" + request.Link + "</p>";
                await SendEmailAsync(request.Email, "Confirmacion de mail", message);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
