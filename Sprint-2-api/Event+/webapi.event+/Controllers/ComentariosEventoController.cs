using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.ContentModerator;
using System.Text;
using webapi.event_.Domains;
using webapi.event_.Repositories;

namespace webapi.event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class ComentariosEventoController : ControllerBase
    {
        //Acesso aos métodos do repositório
        ComentariosEventoRepository comentario = new ComentariosEventoRepository();

        //Armazena dados da API externa (IA - Azure)
        private readonly ContentModeratorClient _contentModeratorClient;

        /// <summary>
        /// Construtur que recebe os dados necessários para o acesso ao serviço externo
        /// </summary>
        /// <param name="contentModeratorClient">Objeto do tipo ContentModeratorClient</param>
        /// 
        public ComentariosEventoController(ContentModeratorClient contentModeratorClient)
        {
            _contentModeratorClient = contentModeratorClient;
        }

        [HttpPost("comentarioIA")]

        public async Task<IActionResult> PostIA(ComentariosEvento comentariosEvento)
        {
            try
            {
                //se a descriça do mentario não for passado no objeto
                if (string.IsNullOrEmpty(comentariosEvento.Descricao))
                {
                    return BadRequest("O texto a ser analisado não pode ser vazio!");
                }

                    using var stream = new MemoryStream(Encoding.UTF8.GetBytes(comentariosEvento.Descricao));

                    //realiza a moderçao do conteúdo(descricão do comentario)
                    var moderationResult = await _contentModeratorClient.TextModeration
                        .ScreenTextAsync("text/plain", stream, "por", false, false, null, true);

                    //se existir termos ofensivos
                    if(moderationResult.Terms != null)
                    {
                        //atribuir false para "Exibe"
                        comentariosEvento.Exibe = false;

                        //cadastrar o comentáio
                        comentario.Cadastrar(comentariosEvento);
                    }
                    else
                    {
                        comentariosEvento.Exibe = true;

                        comentario.Cadastrar(comentariosEvento);
                    }

                    return StatusCode(201, comentariosEvento);

                
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                return Ok(comentario.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("BuscarPorIdUsuario")]

        public IActionResult GetByUserId (Guid IdUsuario, Guid IdEvento)
        {
            try
            {
                return Ok(comentario.BuscarPorIdUsuario(IdUsuario, IdEvento));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]

        public IActionResult Post (ComentariosEvento novoComentario)
        {
            try
            {
                comentario.Cadastrar(novoComentario);

                return StatusCode(201, novoComentario);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete]

        public IActionResult Delete(Guid id)
        {
            try
            {
                comentario.Deletar(id);

                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}
