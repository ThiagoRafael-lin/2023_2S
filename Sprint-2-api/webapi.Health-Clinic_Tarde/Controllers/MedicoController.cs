using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Health_Clinic_Tarde.Domains;
using webapi.Health_Clinic_Tarde.Repositories;

namespace webapi.Health_Clinic_Tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MedicoController : ControllerBase
    {
       private readonly MedicoRepository _MedicoRepository;

        public MedicoController()
        {
            _MedicoRepository = new MedicoRepository();
        }

        /// <summary>
        /// Cadastra um nome de Médico
        /// </summary>
        /// <param name="medico">Nome do Médico</param>
        /// <returns></returns>

        [HttpPost]

        public IActionResult Post(Medico medico)
        {
            try
            {
                _MedicoRepository.Cadastrar(medico);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);   
            }
        }

        /// <summary>
        /// Lista todos os médico
        /// </summary>
        /// <returns></returns>

        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                return Ok(_MedicoRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Lista todas as consultas
        /// </summary>
        /// <returns></returns>

        [HttpGet("{Listagem de Consulta}")]

        public IActionResult GetQuery()
        {
            try
            {
            return Ok(_MedicoRepository.ListarConsulta());

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Deleta os Médicos pelo Id
        /// </summary>
        /// <param name="id">Nome do Medico</param>
        /// <returns></returns>

        [HttpDelete("{id}")]

        public IActionResult Delete(Guid id)
        {
            try
            {
            _MedicoRepository.Deletar(id);

            return NoContent();

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }



    }
}
