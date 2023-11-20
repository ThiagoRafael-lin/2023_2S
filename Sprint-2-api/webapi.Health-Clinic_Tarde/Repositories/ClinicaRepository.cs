using webapi.Health_Clinic_Tarde.Contexts;
using webapi.Health_Clinic_Tarde.Domains;

namespace webapi.Health_Clinic_Tarde.Repositories
{
    public class ClinicaRepository
    {
        private readonly HealthContext ctx;

        public ClinicaRepository()
        {
            ctx = new HealthContext();
        }

        public void Cadastrar(Clinica clinica)
        {
            try
            {
                ctx.Clinica.Add(clinica);
                ctx.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Clinica> Listar()
        {
            try
            {
                return ctx.Clinica.ToList();
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
                Clinica clinicaBuscado = ctx.Clinica.Find(id);

                if (clinicaBuscado == null)
                {
                    ctx.Clinica.Remove(clinicaBuscado);
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
