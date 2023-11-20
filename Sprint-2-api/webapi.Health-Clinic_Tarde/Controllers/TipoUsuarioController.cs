using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Health_Clinic_Tarde.Domains;
using webapi.Health_Clinic_Tarde.Repositories;

namespace webapi.Health_Clinic_Tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TipoUsuarioController : ControllerBase
    {
        private readonly TipoUsuarioRepository _tipoUsuarioRepository;

        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        /// <summary>
        /// Cadastra um TipoUsuario
        /// </summary>
        /// <param name="tipoUsuario">Nome do TipoUsuario</param>
        /// <returns></returns>

        [HttpPost]

        public IActionResult Post(TipoUsuario tipoUsuario) 
        {
            try
            {
                _tipoUsuarioRepository.Cadastrar(tipoUsuario);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Deleta um TipoUsuario pelo Id
        /// </summary>
        /// <param name="id">Nome do TipoUsuario</param>
        /// <returns></returns>

        [HttpDelete("{id}")]

        public IActionResult Delete(Guid id)
        {
            try
            {
                _tipoUsuarioRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Lista um TipoUsuario pelo Id
        /// </summary>
        /// <param name="id">Nome do TipoUsuario</param>
        /// <returns></returns>

        [HttpGet ("{id}")]

        public IActionResult BuscarPorId(Guid id)
        {
            try
            {
               var tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);

                return Ok(tipoUsuarioBuscado);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Lista todos os TipoUsuario
        /// </summary>
        /// <returns></returns>

        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                return Ok(_tipoUsuarioRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Atualiza um TipoUsuario pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tipoUsuario">Nome do TipoUsuario</param>
        /// <returns></returns>

        [HttpPut("{id}")]

        public IActionResult Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            try
            {
                _tipoUsuarioRepository.Atualizar(id, tipoUsuario);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}
