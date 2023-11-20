using System.Data.SqlClient;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
namespace senai.inlock.webApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private string StringConexao = "Data Source = DESKTOP-2KJISQH\\SENAI; Initial Catalog = inlock_games; User Id = sa; Pwd = Senai@134";

       
        public void Cadastrar(JogoDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {

                string queryInsert = "INSERT INTO Jogo(IdEstudio, Nome, Descrição, DataLancamento, Valor) VALUES (@IdEstudio, @Nome, @Descricao, @DataLancamento, @Valor0";


                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {

                    cmd.Parameters.AddWithValue("@IdEstudio", novoJogo.IdJogo);
                    cmd.Parameters.AddWithValue("@Nome", novoJogo.Nome);
                    cmd.Parameters.AddWithValue("@Descricao", novoJogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", novoJogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", novoJogo.Valor);

                    con.Open();

                    cmd.ExecuteNonQuery();

                }

            }
        }

        public List<JogoDomain> ListarTodos()
        {

            List<JogoDomain> listaJogos = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection())
            {
                string querySelectAll = "SELECT Estudio.IdEstudio,Estudio.Nome,Jogo.Nome FROM Estudio LEFT JOIN Jogo ON Estudio.IdEstudio = Jogo.IdEstudio;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain();
                        {

                            jogo.IdJogo = Convert.ToInt32(rdr["IdJogo"]);
                            jogo.IdEstudio = Convert.ToInt32(rdr["IdEstudio"]);
                            jogo.Nome = rdr["Nome"].ToString();
                            jogo.DataLancamento = rdr["DataLancamento"].ToString();

                            EstudioDomain Estudio = new EstudioDomain
                            {
                                IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                                Nome = rdr["Nome"].ToString(),

                            };

                            jogo.Estudio = Estudio;
                        };

                        listaJogos.Add(jogo);

                    }
                }
            }
            return listaJogos;
        }
    }
}
