using webapi.Health_Clinic_Tarde.Contexts;
using webapi.Health_Clinic_Tarde.Domains;

namespace webapi.Health_Clinic_Tarde.Repositories
{

    public class EspecialidadeRepository
    {
        private readonly HealthContext ctx;

        public EspecialidadeRepository()
        {
            ctx = new HealthContext();
        }

        public void Cadastrar(Especialidade especialidade)
        {
            try
            {
                ctx.Especialidade.Add(especialidade);
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Especialidade> Listar()
        {
            try
            {
                return ctx.Especialidade.ToList();
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
                Especialidade especialidadeBuscado = ctx.Especialidade.Find(id);

                if (especialidadeBuscado == null)
                {
                    ctx.Especialidade.Remove(especialidadeBuscado);
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
