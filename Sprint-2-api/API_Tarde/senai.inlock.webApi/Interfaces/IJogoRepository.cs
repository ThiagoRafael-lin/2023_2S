using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    public interface IJogoRepository
    {

        void Cadastrar(JogoDomain novoJogo);

        List<JogoDomain> ListarTodos();


    }
}

