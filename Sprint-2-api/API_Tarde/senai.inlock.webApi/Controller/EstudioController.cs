using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using Microsoft.AspNetCore.Http;
using senai.inlock.webApi.Controller;
using Microsoft.AspNetCore.Authorization;

namespace senai.inlock.webApi.Controller
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudioRepository {get;set;}


        public EstudioController() 
        {
            _estudioRepository = new EstudioRepository();
        }


        [HttpGet]
        public IActionResult get()
        {
            try
            {
                List<EstudioDomain> ListaEstudio = _estudioRepository.ListaEstudio();
                return Ok(ListaEstudio);

            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }


        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Post(EstudioDomain novoEstudio)
        {

            try
            {
                _estudioRepository.Cadastrar(novoEstudio);
                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
 