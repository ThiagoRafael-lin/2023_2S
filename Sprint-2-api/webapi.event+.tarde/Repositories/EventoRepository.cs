using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly EventContext _eventContext;

        public EventoRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, Evento evento)
        {
            Evento EventoBuscado = _eventContext.Evento.Find(id)!;

            if (EventoBuscado == null)
            {
                EventoBuscado.Descricao = evento.Descricao;
                EventoBuscado.DataEvento = evento.DataEvento;
                EventoBuscado.NomeEvento = evento.NomeEvento;
            }
            _eventContext.SaveChanges();
        }

        public Evento BuscarPorId(Guid id)
        {
            Evento EventoBuscado = _eventContext.Evento.Find(id)!;

            if (EventoBuscado != null)
            {
                return _eventContext.Evento.FirstOrDefault(e => e.IdEvento == id)!;
            }

            return null!;
        }

        public void Cadastrar(Evento evento)
        {
            try
            {
                _eventContext.Evento.Add(evento);

                _eventContext.SaveChanges()
;
            }
            catch (Exception)
            {

                throw new Exception("Erro ao Cadastrar");
            }
        }

        public void Deletar(Guid Id)
        {
            Evento EventoBuscado = _eventContext.Evento.Find(Id)!;

            if (EventoBuscado != null)
            {
                _eventContext.Evento.Remove(EventoBuscado);
            }

            _eventContext.SaveChanges();
        }

        public List<Evento> Listar()
        {
            return _eventContext.Evento.ToList();

        }
    }
}
