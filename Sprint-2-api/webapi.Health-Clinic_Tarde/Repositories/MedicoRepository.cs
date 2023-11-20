using webapi.Health_Clinic_Tarde.Contexts;
using webapi.Health_Clinic_Tarde.Domains;

namespace webapi.Health_Clinic_Tarde.Repositories
{
    public class MedicoRepository
    {
        private readonly HealthContext ctx;

        public MedicoRepository()
        {
            ctx = new HealthContext();
        }


        public void Cadastrar(Medico medico)
        {
            try
            {
                ctx.Medico.Add(medico);
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Medico> Listar()
        {
            try
            {
                return ctx.Medico.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Consulta> ListarConsulta()
        {
            try
            {
                return ctx.Consulta.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid Id)
        {
            try
            {
                Medico medicoBuscado = ctx.Medico.Find(Id);

                if (medicoBuscado == null)
                {
                    ctx.Medico.Remove(medicoBuscado);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
