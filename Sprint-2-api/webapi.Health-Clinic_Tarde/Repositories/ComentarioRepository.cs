using webapi.Health_Clinic_Tarde.Contexts;
using webapi.Health_Clinic_Tarde.Domains;

namespace webapi.Health_Clinic_Tarde.Repositories
{
    public class ComentarioRepository
    {
        private readonly HealthContext ctx;

        public ComentarioRepository()
        {
            ctx = new HealthContext();
        }

        public void Cadastrar(Comentario comentario)
        {
            try
            {
                ctx.Comentario.Add(comentario);
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Comentario> Listar()
        {
            try
            {
                return ctx.Comentario.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Comentario comentarioBuscado = ctx.Comentario.Find(id);

                if (comentarioBuscado == null)
                {
                    ctx.Comentario.Remove(comentarioBuscado);
                }
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
