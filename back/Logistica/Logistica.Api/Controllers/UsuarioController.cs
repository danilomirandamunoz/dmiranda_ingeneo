using Logistica.Api.AccesoDatos.Interfaces;
using Logistica.Api.Datos.Modelo;
using Logistica.Api.Datos.Modelo.In;
using Logistica.Api.Datos.Modelo.Out;
using Logistica.Api.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Logistica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IConfiguration config;
        private readonly IUsuarioRepositorio repositorio;

        public UsuarioController(IConfiguration config, IUsuarioRepositorio repositorio)
        {
            this.config = config;
            this.repositorio = repositorio;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login([FromBody] LoginRequest login)
        {

            try
            {
                var usuario = await this.repositorio.ObtenerPorUsername(login.Username);
                if (usuario == null)
                {
                    return NotFound("Usuario o contraseña inválidos");
                }

                if (login.Password != usuario.Password)
                {
                    return NotFound("Usuario o contraseña inválidos");
                }

                var datosToken = new List<Claim>
                {
                    new Claim("Nombre", usuario.Nombre),
                    new Claim("Id", usuario.Id.ToString()),
                    new Claim("Username", usuario.Username),
                };

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
                var tokenDescriptor = new JwtSecurityToken(
                    issuer: this.config["Jwt:Issuer"],
                    audience: this.config["Jwt:Audience"],
                    claims: datosToken,
                    expires: DateTime.Now.AddMinutes(720),
                    signingCredentials: credentials);

                var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);


                return Ok(new LoginResponse
                {
                    Token = jwt,
                    Id = usuario.Id,
                    Nombre = usuario.Nombre
                });



            }
            catch (Exception ex)
            {
                return StatusCode(500, new LoginResponse { Codigo=-1, Mensaje = "Nombre usuario y/o contraseña incorrectos" }); 
            }

        }

        [HttpPost("registro")]
        [AllowAnonymous]
        public async Task<ActionResult> Registro([FromBody] RegistroRequest registro)
        {
            Usuario usuario = new Usuario
            {
                Nombre = registro.Nombre,
                Password = registro.Password,
                Username = registro.Username
            };

            var response = await this.repositorio.Guardar(usuario);

            return Ok(response);
        }
    }
}
