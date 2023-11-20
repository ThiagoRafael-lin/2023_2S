using senai.inlock.webApi.Domains;
using System.Data.SqlClient;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Controller;

namespace senai.inlock.webApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {

        private string Stringconexao = "Data Source = DESKTOP-2KJISQH\\SENAI; Initial Catalog = inlock_games; User Id = sa; Pwd = Senai@134";

        void IEstudioRepository.Cadastrar(EstudioDomain estudioDomain)
        {
            using (SqlConnection con = new SqlConnection(Stringconexao))
            {
                string queryInsert = "INSERT into Estudio (Nome) VALUES Nome = @Nome ";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", estudioDomain.Nome);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public List<EstudioDomain> ListarTodos(int IdEstudio, string? Nome)
        {
            List<EstudioDomain> listaEstudio = new List<EstudioDomain>();

            using (SqlConnection con = new SqlConnection(Stringconexao))
            {
                string querySelectAll = "SELECT Estudio.IdEstudio, Estudio.Nome FROM Estudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(@querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain();
                        {
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]);
                            Nome = rdr["Nome"].ToString();
                        };

                        listaEstudio.Add(estudio);

                    }

                }
            }
            return listaEstudio;
        }

        public List<EstudioDomain> ListaEstudio()
        {
            throw new NotImplementedException();
        }
    }
}

