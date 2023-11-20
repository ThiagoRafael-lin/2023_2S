using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly EventContext _eventContext;

        public InstituicaoRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid Id, Instituicao instituicaoRepository)
        {
            try
            {
                Instituicao instituicaoBuscado = _eventContext.Instituicao.Find(Id)!;

                if (instituicaoBuscado != null)
                {
                    instituicaoBuscado.CNPJ = instituicaoRepository.CNPJ;
                    instituicaoBuscado.NomeFantasia = instituicaoRepository.NomeFantasia;
                    instituicaoBuscado.Endereco = instituicaoRepository.Endereco;
                }

                _eventContext.Instituicao.Update(instituicaoBuscado!);
                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Erro na atualizacao da instituicao");
            }
        }

        public Instituicao BuscarPorId(Guid Id)
        {
            try
            {
                Instituicao instituicaoBuscado = _eventContext.Instituicao.Find(Id)!;

                if (instituicaoBuscado != null)
                {
                    return _eventContext.Instituicao.FirstOrDefault(x => x.IdInstituicao == Id)!;
                }

                return null!;
            }
            catch (Exception)
            {

                throw new Exception("Erro na listagem da instituicao por id");
            }
        }

        public void Cadastrar(Instituicao instituicaoRepository)
        {
            try
            {
                _eventContext.Instituicao.Add(instituicaoRepository);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
                
        }

        public void Deletar(Guid Id)
        {
            try
            {
                Instituicao instituicaoBuscado = _eventContext.Instituicao.Find(Id)!;

                if (instituicaoBuscado != null)
                {
                    _eventContext.Instituicao.Remove(instituicaoBuscado);
                }

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao deletar instituicao");
            }
        }

        public List<Instituicao> Listar()
        {
            return _eventContext.Instituicao.ToList();
        }
    }
}
