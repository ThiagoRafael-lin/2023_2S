using Microsoft.AspNetCore.Http.HttpResults;
using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly EventContext _eventContext;

        public TipoUsuarioRepository()
        {
            _eventContext = new EventContext();
        }
        public void Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            TipoUsuario usuarioBuscado = _eventContext.TipoUsuario.Find(id)!;

            if (usuarioBuscado != null)
            {
                usuarioBuscado.IdTipoUsuario = usuarioBuscado.IdTipoUsuario;
            }

            _eventContext.SaveChanges();
        }

        public TipoUsuario BuscarPorId(Guid id)
        {
            TipoUsuario usuarioBuscado = _eventContext.TipoUsuario.Find(id)!;

            if (usuarioBuscado != null)
            {
                return _eventContext.TipoUsuario.FirstOrDefault(x => x.IdTipoUsuario == id)!;
            }

            return null;
        }

        public void Cadastrar(TipoUsuario tipoUsuario)
        {
            try
            {
                _eventContext.TipoUsuario.Add(tipoUsuario);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao cadastrar");
            }
        }

        public void Deletar(Guid id)
        {
            TipoUsuario usuarioBuscado = _eventContext.TipoUsuario.Find(id)!;

            if (usuarioBuscado != null)
            {
                _eventContext.TipoUsuario.Remove(usuarioBuscado);
            }

            _eventContext.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            try
            {
                return _eventContext.TipoUsuario.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
   
}
