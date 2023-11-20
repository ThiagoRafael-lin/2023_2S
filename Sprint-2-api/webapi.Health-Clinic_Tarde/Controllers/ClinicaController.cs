using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Health_Clinic_Tarde.Domains;
using webapi.Health_Clinic_Tarde.Repositories;

namespace webapi.Health_Clinic_Tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ClinicaController : ControllerBase
    {

       private readonly ClinicaRepository _ClinicaRepository;

        public ClinicaController()
        {
            _ClinicaRepository = new ClinicaRepository();
        }

        /// <summary>
        /// Cadastra uma clinica
        /// </summary>
        /// <param name="clinica">Nome da Clinica</param>
        /// <returns></returns>

        [HttpPost]

        public IActionResult Post(Clinica clinica)
        {
            try
            {
                _ClinicaRepository.Cadastrar(clinica);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Lista todas as Clinica existentes
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                return Ok(_ClinicaRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Deleta uma Clinica pelo Id
        /// </summary>
        /// <param name="id">Id da Clinica</param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _ClinicaRepository.Deletar(id);

                return NoContent();
             
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}
