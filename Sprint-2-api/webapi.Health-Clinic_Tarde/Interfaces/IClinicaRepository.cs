using webapi.Health_Clinic_Tarde.Domains;

namespace webapi.Health_Clinic_Tarde.Interfaces
{
    public interface IClinicaRepository
    {
        void Cadastrar(Clinica clinica);
        List<Clinica> Listar();
        void Deletar(Guid Id);
    }
}
