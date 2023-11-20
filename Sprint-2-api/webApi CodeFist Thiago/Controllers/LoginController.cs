using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webApi_CodeFist_Thiago.Domain;
using webApi_CodeFist_Thiago.Interfaces;
using webApi_CodeFist_Thiago.Repositories;
using webApi_CodeFist_Thiago.ViewModels;

namespace webApi_CodeFist_Thiago.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]

        public IActionResult Login (LoginViewModel usuario)
        {
            try
            {
              Usuario usuarioBuscado = _usuarioRepository.BuscarUsuario(usuario.Email, usuario.Senha);

                if (usuarioBuscado == null)
                {
                    return StatusCode(401, "Email ou Senha inaválidos");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
