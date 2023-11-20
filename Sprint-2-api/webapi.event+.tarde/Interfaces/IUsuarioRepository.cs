using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);

        Usuario BuscarPorId(string email, Guid id);

        Usuario BuscarPorEmailESenha(string email, string senha);
       
    }
}
