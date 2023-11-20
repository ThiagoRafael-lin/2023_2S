using webapi.Health_Clinic_Tarde.Contexts;
using webapi.Health_Clinic_Tarde.Domains;

namespace webapi.Health_Clinic_Tarde.Repositories
{
    public class TipoUsuarioRepository
    {
        private readonly HealthContext ctx;

        public TipoUsuarioRepository()
        {
            ctx = new HealthContext();
        }

        public void Cadastrar(TipoUsuario tipoUsuario)
        {
            try
            {
                ctx.TipoUsuario.Add(tipoUsuario);

                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public void Deletar (Guid id)
        {
            TipoUsuario usuarioBuscado = ctx.TipoUsuario.Find(id)!;

            if (usuarioBuscado != null)
            {
                ctx.TipoUsuario.Remove(usuarioBuscado);
            }
            ctx.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            try
            {
                return ctx.TipoUsuario.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            TipoUsuario usuarioBuscado = ctx.TipoUsuario.Find(id)!;

            if (usuarioBuscado != null)
            {
                usuarioBuscado.IdTipoUsuario = usuarioBuscado.IdTipoUsuario;
              
            }
            ctx.SaveChanges();
        }

        public TipoUsuario BuscarPorId(Guid id)
        {
            TipoUsuario usuarioBuscado = ctx.TipoUsuario.Find(id)!;

            if (usuarioBuscado != null)
            {
                return ctx.TipoUsuario.FirstOrDefault(x => x.IdTipoUsuario == id)!;
            }
            return null;
        }


    }
}
