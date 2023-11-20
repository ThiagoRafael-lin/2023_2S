using webApi_CodeFist_Thiago.Controllers;
using webApi_CodeFist_Thiago.Domain;

namespace webApi_CodeFist_Thiago.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario BuscarUsuario(string email, string senha);

        void Cadastrar(Usuario usuario);
        Usuario Login(string? email, string? senha);
    }
}
