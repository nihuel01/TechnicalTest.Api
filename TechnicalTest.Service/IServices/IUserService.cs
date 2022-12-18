using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechnicalTest.Core.Dto;

namespace TechnicalTest.Service.IServices
{
    public interface IUserService
    {
        Task EnviarMailRegistro(UsuarioEmailDto usuarioEmailDto);
    }
}
