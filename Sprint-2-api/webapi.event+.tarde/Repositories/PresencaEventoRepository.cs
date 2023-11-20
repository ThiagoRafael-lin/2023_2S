using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class PresencaEventoRepository : IPresencaEventoRepository
    {
        private readonly EventContext _eventContext;

        public PresencaEventoRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, PresencaEvento presencaEvento)
        {
            PresencaEvento BuscarPresenca = _eventContext.PresencaEvento.Find(id)!;
            if (BuscarPresenca != null)
            {
                BuscarPresenca.Situacao = presencaEvento.Situacao;
            }
        }

        public PresencaEvento BuscarPorId(Guid id)
        {
            PresencaEvento BuscarPresenca = _eventContext.PresencaEvento.Find(id)!;
            if (BuscarPresenca != null)
            {
                return _eventContext.PresencaEvento.FirstOrDefault(b => b.IdPresencaEvento == id)!;
            }

            return null!;
        }

        public void Deletar(Guid id)
        {
            PresencaEvento BuscarPresenca = _eventContext.PresencaEvento.Find(id)!;
            if (BuscarPresenca != null)
            {
                _eventContext.PresencaEvento.Remove(BuscarPresenca);
            }
        }

        public void Inscrever(PresencaEvento inscricao)
        {
            try
            {
                _eventContext.PresencaEvento.Add(inscricao);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao encontrar rota");
            }
        }

        public List<PresencaEvento> Listar()
        {
            return _eventContext.PresencaEvento.ToList();
        }

        public List<PresencaEvento> ListarMinhas(Guid id)
        {
            return _eventContext.PresencaEvento.Where(l => l.IdUsuario == id).ToList();
        }
    }
}
