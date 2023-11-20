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
    public class PacienteController : ControllerBase
    {

        private readonly PacienteRepository _PacienteRepository;

        public PacienteController()
        {
            _PacienteRepository = new PacienteRepository();
        }

        /// <summary>
        /// Cadastra um Usuario
        /// </summary>
        /// <param name="paciente">Nome do Usuario</param>
        /// <returns></returns>

        [HttpPost]

        public IActionResult Post(Paciente paciente)
        {
            try
            {
                _PacienteRepository.Cadastrar(paciente);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Lista os Usuarios 
        /// </summary>
        /// <returns></returns>

        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                return Ok(_PacienteRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Deleta os Usuarios pelo Id
        /// </summary>
        /// <param name="id">Nome do Usuario</param>
        /// <returns></returns>

        [HttpDelete("{id}")]

        public IActionResult Delete(Guid id)
        {
            try
            {
                _PacienteRepository.Deletar(id);

                return NoContent();

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Lista as consultas
        /// </summary>
        /// <returns></returns>

        [HttpGet("Listagem de Consulta")]

        public IActionResult GetQuery()
        {
            try
            {
                return Ok(_PacienteRepository.ListarConsulta());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
