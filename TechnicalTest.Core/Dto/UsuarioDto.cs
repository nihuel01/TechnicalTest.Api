using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalTest.Core.Dto
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public string Rol { get; set; }
        public int Activo { get; set; }
    }

    public class UsuarioRegistroDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public int Rol { get; set; }
    }
    public class UsuarioEmailDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Link { get; set; }
    }
    public class UsuarioConfirmacionEmailDto
    {
        public string userId { get; set; }
        public string token { get; set; }
    }
    public class UsuarioSearchDto
    {
    }
}
