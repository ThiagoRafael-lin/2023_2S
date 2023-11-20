using Microsoft.AspNetCore.Http;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Controller;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace senai.inlock.webApi.Controller
{
    [Produces("application/json")]
    [Route("api/[controller]")]

    [ApiController]

    public class JogoController : ControllerBase
    {
        private IJogoRepository _jogoRepository { get; set; }




        public JogoController()
        {

            _jogoRepository = new JogoRepository();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]

        public IActionResult post(JogoDomain novoJogo)
        {
            try
            {
                _jogoRepository.Cadastrar(novoJogo);
                return Ok(novoJogo);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }

        }

        [HttpGet]

        public IActionResult Get() 
        {
            try
            {
                List<JogoDomain> listaJogos = _jogoRepository.ListarTodos();

                return Ok(listaJogos);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        

        }
    }
}
