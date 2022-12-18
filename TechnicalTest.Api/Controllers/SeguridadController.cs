using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalTest.Core.Dto;
using TechnicalTest.Core.Model;
using TechnicalTest.DataAccess;
using TechnicalTest.Service.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechnicalTest.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class SeguridadController : ControllerBase
    {
        protected readonly DataContext _ctx;
        protected readonly JwtHelper _jwtHelper;
        private readonly SignInManager<tUsers> _signInManager;

        public SeguridadController(DataContext ctx, JwtHelper jwtHelper, SignInManager<tUsers> signInManager)
        {
            _ctx = ctx;
            _jwtHelper = jwtHelper;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        public async virtual Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRequestDto request)
        {
            try
            {
                var user = await _signInManager.PasswordSignInAsync(request.Username, request.Password, true, false);

                if (user.Succeeded)
                {
                    var usuario = await _ctx.Set<tUsers>().Where(x => x.txt_user == request.Username).FirstOrDefaultAsync();
                    var token = _jwtHelper.GenerateToken(usuario);

                    var result = new LoginResponseDto()
                    {
                        Token = token
                    };
                    return Ok(new GenericResponseDto()
                    {
                        Success = true,
                        Result = result
                    });
                }
                else
                {
                    return Ok(new GenericResponseDto()
                    {
                        Success = false,
                        Result = null,
                        Error = new Exception("Los datos ingresados son incorrectos, intentelo nuevamente")
                    });
                }

            }
            catch (Exception ex)
            {
                return Ok(new GenericResponseDto()
                {
                    Success = false,
                    Result = null,
                    Error = ex
                });
            }
        }
    }
}
