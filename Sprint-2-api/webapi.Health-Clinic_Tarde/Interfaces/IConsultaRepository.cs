using webapi.Health_Clinic_Tarde.Domains;

namespace webapi.Health_Clinic_Tarde.Interfaces
{
    public interface IConsultaRepository
    {
        void Cadastrar(Consulta consulta);
        List<Consulta> Listar();
        void Deletar(Guid id);

    }
}
