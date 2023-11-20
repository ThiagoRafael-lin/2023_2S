using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Repositories;

namespace webapi.event_.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class InstituicaoController : ControllerBase
    {
        private readonly InstituicaoRepository _InstituicaoRepository;

        public InstituicaoController()
        {
            _InstituicaoRepository = new InstituicaoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_InstituicaoRepository.Listar());
            }
            catch (Exception)
            {

                throw new Exception("Erro para acessar metodo listar");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetId(Guid Id)
        {
            try
            {
                return Ok(_InstituicaoRepository.BuscarPorId(Id));
            }
            catch (Exception)
            {

                throw new Exception("Erro para acessa método ");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid Id)
        {
            try
            {
                _InstituicaoRepository.Deletar(Id);

                return NoContent();
            }
            catch (Exception)
            {

                throw new Exception("Erro para acessar metodo deletar");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid Id, Instituicao instituicaoRepository)
        {
            try
            {
                _InstituicaoRepository.Atualizar(Id, instituicaoRepository);
                return NoContent();
            }
            catch (Exception)
            {

                throw new Exception("Erro para acessar metodo atualizar");
            }
        }

        [HttpPost]
        public IActionResult Post(Instituicao instituicaoRepository)
        {
            try
            {
                _InstituicaoRepository.Cadastrar(instituicaoRepository);
                return StatusCode(201);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
