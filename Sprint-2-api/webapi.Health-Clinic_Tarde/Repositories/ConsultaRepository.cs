using Microsoft.AspNetCore.Http.HttpResults;
using webapi.Health_Clinic_Tarde.Contexts;
using webapi.Health_Clinic_Tarde.Domains;

namespace webapi.Health_Clinic_Tarde.Repositories
{
    public class ConsultaRepository
    {
        private readonly HealthContext ctx;

        public ConsultaRepository()
        {
            ctx = new HealthContext();
        }
        public void Cadastrar(Consulta consulta)
        {
            try
            {
            ctx.Consulta.Add(consulta);
            ctx.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Consulta> Listar()
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

        public void Deletar(Guid id)
        {
            try
            {
                Consulta consultaBuscado = ctx.Consulta.Find(id);

                if (consultaBuscado == null)
                {
                    ctx.Consulta.Remove(consultaBuscado);
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
