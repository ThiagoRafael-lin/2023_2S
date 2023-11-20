using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webApi_CodeFist_Thiago.Domain;
using webApi_CodeFist_Thiago.Interfaces;
using webApi_CodeFist_Thiago.Repositories;

namespace webApi_CodeFist_Thiago.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public object? Usuario { get;  set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }
        [HttpPost]

        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);

                return Ok(usuario);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("Login")]

        public IActionResult Login(Usuario Login)
        {
            Usuario usuario = _usuarioRepository.Login(Login.Email, Login.Senha);

            if (usuario = null)
            {
                return NotFound("Email ou Senha inválidos!");
            }

            var claims = new[]
            {
                new Claims(JwtRegisteredClaimsNames.Email, usuario.Email),
                new Claims(JwtRegisteredClaimsNames.Jti, usuario.IdUsuario.ToString()),
                new Claims(claimsTypes.Role, usuario.IdTipoUsuario.ToString())
            };
            /*UsuarioDomain usuario = _usuarioRepository.Login(login.Email, login.Senha);

            if (usuario == null)
            {
                return NotFound("Email ou senha inválidos!");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuario.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuario.IdTipoUsuario.ToString())

            };*/
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-autenticacao-webapi-dev"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
            (
                issuer: "webapi.inlock",
                audience: "webapi.inlock",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );
            return Ok(new

        };
        token = new JwtSecurityTokenHandler().WriteToken(token)

    }
}
