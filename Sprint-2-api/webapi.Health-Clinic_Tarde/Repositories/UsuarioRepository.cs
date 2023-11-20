using System.Collections.Generic;
using webapi.Health_Clinic_Tarde.Contexts;
using webapi.Health_Clinic_Tarde.Domains;
using webapi.Health_Clinic_Tarde.Interfaces;
using webapi.Health_Clinic_Tarde.Utils;

namespace webapi.Health_Clinic_Tarde.Repositories
{
    public class UsuarioRepository
    {

        private readonly HealthContext ctx;

        public UsuarioRepository()
        {
            ctx = new HealthContext();
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                ctx.Usuario.Add(usuario);

                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = ctx.Usuario
                     .Select(u => new Usuario
                     {
                         IdUsuario = u.IdUsuario,
                         Nome = u.Nome,
                         Email = u.Email,
                         Senha = u.Senha,

                         TipoUsuario = new TipoUsuario
                         {
                             IdTipoUsuario = u.IdTipoUsuario,
                             Titulo = u.TipoUsuario!.Titulo
                         }

                     }).FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (confere)
                    {
                        return usuarioBuscado;
                    }

                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Usuario> Listar()
        {
            try
            {
                return ctx.Usuario.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
