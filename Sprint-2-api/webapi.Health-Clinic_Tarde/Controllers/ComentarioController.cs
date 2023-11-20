using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Health_Clinic_Tarde.Domains;
using webapi.Health_Clinic_Tarde.Interfaces;
using webapi.Health_Clinic_Tarde.Repositories;

namespace webapi.Health_Clinic_Tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class ComentarioController : ControllerBase
    {
        private readonly ComentarioRepository _ComentarioRepository;

        public ComentarioController()
        {
            _ComentarioRepository = new ComentarioRepository();
        }


        /// <summary>
        /// Cadastra um Comentario
        /// </summary>
        /// <param name="comentario">Descrição do Comentario</param>
        /// <returns></returns>

        [HttpPost]

        public IActionResult Post(Comentario comentario)
        {
            try
            {
                _ComentarioRepository.Cadastrar(comentario);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Lista todos os Comentarios
        /// </summary>
        /// <returns></returns>

        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                return Ok(_ComentarioRepository.Listar());

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Deleta um comentario através do Id
        /// </summary>
        /// <param name="id">Id do comentarios</param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _ComentarioRepository.Deletar(id);

                return NoContent();

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}
