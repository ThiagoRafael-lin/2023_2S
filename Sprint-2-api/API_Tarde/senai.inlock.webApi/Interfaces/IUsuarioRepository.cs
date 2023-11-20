using senai.inlock.webApi.Domains;
using System.Data.SqlClient;
using senai.inlock.webApi.Interfaces;


namespace senai.inlock.webApi.Interfaces
{
    public interface IUsuarioRepository
    {
        
        UsuarioDomain Login(string email, string senha);
    }
}
