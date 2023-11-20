using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Http;




namespace senai.inlock.webApi.Controller
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController()
        {

            _usuarioRepository = new UsuarioRepository();

        }

        [HttpPost]

        public IActionResult Login(UsuarioDomain usuario)
        {
            try
            {
                UsuarioDomain usuarioBuscado = _usuarioRepository.Login(usuario.Email, usuario.Senha);
                if (usuarioBuscado == null) 
                {
                    return NotFound("Usuario não encontrado, Email ou Senha invalidos!");
                
                
                }
                var Claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim("Claim personalizada", "Valor personalizado")
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Usuario-chave-autenticacao-webapi-dev"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var Token = new JwtSecurityToken
                    (

                    issuer: "senai.inlock.webApi",

                    audience: "senai.inlock.webApi",

                    claims: Claims,

                    expires: DateTime.Now.AddMinutes(5),

                    signingCredentials: creds

                    );
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(Token) 

                });

            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
