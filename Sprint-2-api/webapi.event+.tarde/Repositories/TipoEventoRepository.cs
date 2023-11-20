using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        private readonly EventContext _eventContext;

        public TipoEventoRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid Id, TipoEvento tipoevento)
        {
            TipoEvento tipoEventoBuscado = _eventContext.TipoEvento.Find(Id)!;

            if (tipoEventoBuscado != null)
            {
                tipoEventoBuscado.Titulo = tipoevento.Titulo;
            }

            _eventContext.TipoEvento.Update(tipoEventoBuscado!);
            _eventContext.SaveChanges();

        }

        public TipoEvento BuscarPorId(Guid Id)
        {
            try
            {
                TipoEvento tipoEventoBuscado = _eventContext.TipoEvento.Find(Id)!;

                if (tipoEventoBuscado != null)
                {
                    return _eventContext.TipoEvento.FirstOrDefault(x => x.IdTipoEvento == Id)!;
                }

                return null;
            }
            catch (Exception)
            {

                throw new Exception("Erro ao buscar pelo id");
            }
        }

        public void Cadastrar(TipoEvento tipoevento)
        {
            try
            {
                _eventContext.TipoEvento.Add(tipoevento);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao cadastrar o tipo evento");
            }
        }

        public void Deletar(Guid Id)
        {
            try
            {
                TipoEvento tipoEventoBuscado = _eventContext.TipoEvento.Find(Id)!;

                if (tipoEventoBuscado != null)
                {
                    _eventContext.TipoEvento.Remove(tipoEventoBuscado);
                }

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao deletar o tipo de evento");
            }
        }

        public List<TipoEvento> Listar()
        {
            return _eventContext.TipoEvento.ToList();
        }
    }
}
