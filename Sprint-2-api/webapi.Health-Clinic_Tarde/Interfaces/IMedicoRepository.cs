using webapi.Health_Clinic_Tarde.Domains;

namespace webapi.Health_Clinic_Tarde.Interfaces
{
    public interface IMedicoRepository
    {

        void Cadastrar(Medico medico);
        List<Medico> Listar();

        List<Consulta> ListarConsulta();
        void Deletar(Guid Id);
        /*void Prontuario();*/
    }
}
