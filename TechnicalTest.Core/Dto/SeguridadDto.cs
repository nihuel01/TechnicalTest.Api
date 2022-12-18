using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalTest.Core.Dto
{
    public class SeguridadDto
    {
    }
    public class JwtTokenDto
    {
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
    }

    public class UserTokenInfoDto
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }

    public class LoginRequestDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }    
    public class LoginResponseDto
    {
        public JwtTokenDto Token { get; set; }
    }
}
