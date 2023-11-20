using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class ComentarioEventoRepository : IComentarioEventoRepository
    {
        private readonly EventContext _eventContext;

        public ComentarioEventoRepository()
        {
            _eventContext = new EventContext();
        }
        public ComentarioEvento BuscarPorId(Guid id)
        {
            ComentarioEvento ComentarioBuscado = _eventContext.ComentarioEvento.Find(id)!;

            if (ComentarioBuscado != null)
            {
                _eventContext.ComentarioEvento.FirstOrDefault(b => b.IdComentarioEvento == id);

                return ComentarioBuscado;
            }

            return null!;

        }

        public void Cadastrar(ComentarioEvento comentarioEvento)
        {
            try
            {
                _eventContext.ComentarioEvento.Add(comentarioEvento);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao encontrar a rota");
            }
        }

        public void Deletar(Guid id)
        {
            ComentarioEvento ComentarioBuscado = _eventContext.ComentarioEvento.Find(id)!;

            if (ComentarioBuscado != null)
            {
                _eventContext.ComentarioEvento.Remove(ComentarioBuscado);
            }

            _eventContext.SaveChanges();
        }

        public List<ComentarioEvento> Listar()
        {
            return _eventContext.ComentarioEvento.ToList();
        }
    }
}
