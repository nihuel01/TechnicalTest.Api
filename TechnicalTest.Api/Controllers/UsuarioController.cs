using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

using TechnicalTest.Core.Dto;
using TechnicalTest.Core.Model;
using TechnicalTest.DataAccess;
using TechnicalTest.Service.IServices;
using TechnicalTest.Service.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechnicalTest.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        protected readonly ILogger<tUsers> _logger;
        protected readonly DataAccess.DataContext _ctx;
        private readonly UserManager<tUsers> _userManager;
        private readonly IEmailSenderService _emailSenderService;

        public UsuarioController(ILogger<tUsers> logger, DataContext ctx,
            SignInManager<tUsers> signInManager, UserManager<tUsers> userManager
            , IEmailSenderService emailSenderService)
        {
            _ctx = ctx;
            _logger = logger;
            _userManager = userManager;
            _emailSenderService = emailSenderService;
        }

        [HttpGet("ReadUsers")]
        [AllowAnonymous]
        public async Task<ActionResult<List<UsuarioDto>>> GetUsers()
        {
            try
            {
                var usuarios = await _ctx.Set<tUsers>()
                    .Join(_ctx.Set<tRol>(), x => x.cod_rol, r => r.cod_rol, (x, c) =>
                    new
                    {
                        x.txt_nombre,
                        x.txt_apellido,
                        x.nro_doc,
                        x.sn_activo,
                        c.txt_desc,
                        x.cod_usuario
                    })
                    .Select(x => new
                    {
                        id = x.cod_usuario,
                        nombre = x.txt_nombre,
                        apellido = x.txt_apellido,
                        documento = x.nro_doc,
                        activo = x.sn_activo,
                        rol = x.txt_desc
                    }).ToListAsync();

                if (usuarios != null)
                {
                    return Ok(new GenericResponseDto
                    {
                        Success = true,
                        Result = usuarios.Select(x => new UsuarioDto
                        {
                            Id = x.id,
                            Nombre = x.nombre,
                            Apellido = x.apellido,
                            Documento = x.documento,
                            Activo = x.activo,
                            Rol = x.rol
                        }).ToList()
                    });
                }
                else
                {
                    return Ok(new GenericResponseDto
                    {
                        Success = false,
                        Result = null
                    });
                }
            }
            catch (Exception ex)
            {
                return Ok(new GenericResponseDto
                {
                    Success = false,
                    Result = null,
                    Error = ex
                });
            }
        }

        [HttpDelete("DeleteUser/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<GenericResponseDto>> DeleteUser(long id)
        {
            try
            {
                var user = _ctx.Set<tUsers>().Where(x => x.cod_usuario == id).FirstOrDefault();
                if (user == null)
                {
                    return Ok(new GenericResponseDto
                    {
                        Success = false,
                        Message = "El usuario no existe",
                    });
                }
                _ctx.Set<tUsers>().Remove(user);
                _ctx.SaveChanges();

                return Ok(new GenericResponseDto
                {
                    Success = true,
                    Message = $"El usuario {user.txt_user} se eliminó con éxito."
                });
            }
            catch (Exception ex)
            {
                return Ok(new GenericResponseDto
                {
                    Success = false,
                    Result = null,
                    Error = ex,
                    Message = ex.Message
                });
            }
        }

        [HttpPost("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<GenericResponseDto>> CreateOrUpdateUser(long id, UsuarioRegistroDto userCreate)
        {
            try
            {
                var user = _ctx.Set<tUsers>().Where(x => x.cod_usuario == id).FirstOrDefault();
                if (user == null)
                {
                    var maxId = 0;
                    maxId = _ctx.Set<tUsers>().Max(x => x.cod_usuario);

                    var newUser = new tUsers();
                    newUser.txt_nombre = userCreate.Nombre;
                    newUser.txt_password = userCreate.Password;
                    newUser.txt_apellido = userCreate.Apellido;
                    newUser.Email = userCreate.Email;
                    newUser.nro_doc = userCreate.Documento;
                    newUser.cod_rol = userCreate.Rol;
                    newUser.cod_usuario = maxId + 1;
                    newUser.UserName = userCreate.Username;
                    newUser.txt_user = userCreate.Username;

                    _ctx.Set<tUsers>().Add(newUser);
                    _ctx.SaveChanges();

                    return Ok(new GenericResponseDto
                    {
                        Success = true,
                        Message = "El usuario fué creado exitosamente",
                    });
                }
                else
                {
                    user.txt_nombre = userCreate.Nombre;
                    user.txt_password = userCreate.Password;
                    user.txt_apellido = userCreate.Apellido;
                    user.Email = userCreate.Email;
                    user.nro_doc = userCreate.Documento;
                    user.UserName = userCreate.Username;
                    user.txt_user = userCreate.Username;
                    user.cod_rol = userCreate.Rol;

                    _ctx.Set<tUsers>().Update(user);
                    _ctx.SaveChanges();

                    return Ok(new GenericResponseDto
                    {
                        Success = true,
                        Message = $"El usuario {user.txt_user} se modificó con éxito."
                    });
                }
            }
            catch (Exception ex)
            {
                return Ok(new GenericResponseDto
                {
                    Success = false,
                    Result = null,
                    Error = ex,
                    Message = ex.Message
                });
            }
        }

        [AllowAnonymous]
        [HttpGet("ConfirmarMail")]
        public async Task<ActionResult<GenericResponseDto>> ConfirmarMail([FromQuery] UsuarioConfirmacionEmailDto request)
        {
            try
            {
                tUsers user = _userManager.FindByIdAsync(request.userId).Result;
                IdentityResult result = await _userManager.ConfirmEmailAsync(user, request.token);

                if (result.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    return Ok(new GenericResponseDto
                    {
                        Success = false,
                        Result = null,
                    });
                }
            }
            catch (Exception ex)
            {
                return Ok(new GenericResponseDto
                {
                    Success = false,
                    Result = null,
                    Error = ex
                });
            }
        }


        [AllowAnonymous]
        [HttpPost("registrar")]
        public async Task<ActionResult<GenericResponseDto>> RegistrarUsuario(UsuarioRegistroDto request)
        {
            try
            {

                var maxId = 0;
                maxId = _ctx.Set<tUsers>().Max(x => x.cod_usuario);

                var response = await _userManager.CreateAsync(new tUsers()
                {
                    cod_usuario = maxId + 1,
                    txt_nombre = request.Nombre,
                    txt_apellido = request.Apellido,
                    nro_doc = request.Documento,
                    Email = request.Email,
                    UserName = request.Username,
                    cod_rol = request.Rol
                }, request.Password);

                if (response.Succeeded)
                {
                    var user = _ctx.Set<tUsers>().Where(x => x.UserName == request.Username).FirstOrDefault();
                    var emailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    var link = HttpContext.Request.Host.ToString();
                    link += "/Api/Usuario/ConfirmarMail?userId=" + user.Id + "&token=" + HttpUtility.UrlEncode(emailToken);

                    var usuarioEmail = new UsuarioEmailDto()
                    {
                        Email = user.Email,
                        Nombre = user.txt_nombre,
                        Apellido = user.txt_apellido,
                        Link = link
                    };

                    var emailResponse = await _emailSenderService.EnviarMailRegistro(usuarioEmail);

                    return Ok();

                }
                else
                {
                    return Ok(response.Errors.Select(e => e.Description));
                }
            }
            catch (Exception ex)
            {
                return Ok(new GenericResponseDto
                {
                    Success = false,
                    Result = null,
                    Error = ex
                });
            }
        }

    }
}
