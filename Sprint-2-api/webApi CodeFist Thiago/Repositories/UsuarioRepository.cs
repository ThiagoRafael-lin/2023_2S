using webApi_CodeFist_Thiago.Contexts;
using webApi_CodeFist_Thiago.Controllers;
using webApi_CodeFist_Thiago.Domain;
using webApi_CodeFist_Thiago.Interfaces;
using webApi_CodeFist_Thiago.Utils;

namespace webApi_CodeFist_Thiago.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly InlockContexts ctx;

        public UsuarioRepository()
        {
            ctx = new InlockContexts();
        }

        public Usuario BuscarUsuario(string email, string senha)
        {
            try
            {
                var usuarioBuscado = ctx.Usuarios.FirstOrDefault(u => u.Email == email);

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (confere)
                    {
                        return usuarioBuscado;
                    }
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                ctx.Usuarios.Add(usuario);

                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
