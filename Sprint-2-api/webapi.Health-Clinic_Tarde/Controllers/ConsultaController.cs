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
    public class ConsultaController : ControllerBase
    {
        private readonly ConsultaRepository _ConsultaRepository;

        public ConsultaController()
        {
            _ConsultaRepository = new ConsultaRepository();
        }

        /// <summary>
        /// Cadastra uma consulta
        /// </summary>
        /// <param name="consulta">Nome da consulta</param>
        /// <returns></returns>

        [HttpPost]

        public IActionResult Post(Consulta consulta)
        {
            try
            {
                _ConsultaRepository.Cadastrar(consulta);

                return StatusCode(201);
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

        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                return Ok(_ConsultaRepository.Listar());

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Deleta uma consultaa através do Id
        /// </summary>
        /// <param name="id">Id do Delete</param>
        /// <returns></returns>

        [HttpDelete("{id}")]

        public IActionResult Delete(Guid id)
        {
            try
            {
                _ConsultaRepository.Deletar(id);

                return NoContent();

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}
