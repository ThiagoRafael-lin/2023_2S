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
    public class EspecialidadeController : ControllerBase
    {

        private readonly EspecialidadeRepository _especialidadeRepository;

        public EspecialidadeController()
        {
            _especialidadeRepository = new EspecialidadeRepository();
        }

        /// <summary>
        /// Cadastra uma especialidade 
        /// </summary>
        /// <param name="especialidade">Nome da especialidade</param>
        /// <returns></returns>

        [HttpPost]

        public IActionResult Post(Especialidade especialidade)
        {
            try
            {
                _especialidadeRepository.Cadastrar(especialidade);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Lista todas as especialidades
        /// </summary>
        /// <returns></returns>

        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                return Ok(_especialidadeRepository.Listar());

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Deleta uma especialidade através do Id
        /// </summary>
        /// <param name="id">Nome da especialidade</param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _especialidadeRepository.Deletar(id);

                return NoContent();

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


    }
}
