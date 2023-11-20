using webapi.Health_Clinic_Tarde.Domains;

namespace webapi.Health_Clinic_Tarde.Interfaces
{
    public interface IComentarioRepository
    {
        void Cadastrar(Comentario comentario);

        List<Comentario> Listar();

        void Deletar(Guid id);
    }
}
