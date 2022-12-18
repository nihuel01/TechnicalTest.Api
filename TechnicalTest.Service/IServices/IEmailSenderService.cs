using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechnicalTest.Core.Dto;
using TechnicalTest.Core.Model;

namespace TechnicalTest.Service.IServices
{
    public interface IEmailSenderService
    {
        Task SendEmailAsync(string email, string subject, string message);
        Task<bool> EnviarMailRegistro(UsuarioEmailDto request);
    }
}
