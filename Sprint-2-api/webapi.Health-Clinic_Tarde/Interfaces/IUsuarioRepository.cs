using webapi.Health_Clinic_Tarde.Domains;

namespace webapi.Health_Clinic_Tarde.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);

        Usuario BuscarPorEmailESenha(string email, string senha);

        List<Usuario> Listar();
    }
}
