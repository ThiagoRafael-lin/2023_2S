using webapi.Health_Clinic_Tarde.Contexts;
using webapi.Health_Clinic_Tarde.Domains;

namespace webapi.Health_Clinic_Tarde.Repositories
{
    public class PacienteRepository
    {
        private readonly HealthContext ctx;

        public PacienteRepository()
        {
            ctx = new HealthContext();
        }

        public void Cadastrar(Paciente paciente)
        {
            try
            {
                ctx.Paciente.Add(paciente);
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Paciente> Listar()
        {
            try
            {
                return ctx.Paciente.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            
                Paciente pacienteBuscado = ctx.Paciente.Find(id);

                if (pacienteBuscado == null)
                {
                    ctx.Paciente.Remove(pacienteBuscado);
                }
                ctx.SaveChanges();
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

    }
}
