using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Repositories;
using webapi.event_.tarde.ViewModels;
using webapi.event_.tarde.Domains;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace webapi.event_.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TipoEventoController : ControllerBase
    {
        private readonly ITipoEventoRepository _eventoRepository;

        public TipoEventoController()
        {
            _eventoRepository = new TipoEventoRepository();  
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {

                return Ok(_eventoRepository.Listar());
            }
            catch (Exception)
            {

                throw new Exception("Erro ao acessar o método de listar");
            }
        }



        [HttpGet("{id}")]
        public IActionResult GetId(Guid id)
        {
            try
            {
                return Ok(_eventoRepository.BuscarPorId(id));
            }
            catch (Exception)
            {
                throw new Exception("Erro ao acessar o método de listar por id");
            }
        }


        [HttpPut("{id}")]
        public IActionResult Put(Guid id, TipoEvento tipoEvento)
        {
            try
            {
                _eventoRepository.Atualizar(id, tipoEvento);
                return NoContent();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao acessar o método de atualizar");
            }
        }


        [HttpPost]
        public IActionResult Post(TipoEvento tipoEvento)
        {
            try
            {
                _eventoRepository.Cadastrar(tipoEvento);
                return StatusCode(201);
            }
            catch (Exception)
            {

                throw new Exception("Erro ao acessar o método cadastrar");
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _eventoRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao acessar o método deletar");
            }
        }

    }
}
