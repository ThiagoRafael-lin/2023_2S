using webapi.Health_Clinic_Tarde.Domains;

namespace webapi.Health_Clinic_Tarde.Interfaces
{
    public interface IPacienteRepository
    {
        void Cadastrar(Paciente paciente);
        List<Paciente> Listar();
        void Deletar(Guid id);
        List<Consulta> ListarConsulta();
    }
}
