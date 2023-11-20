using senai.inlock.webApi.Domains;
using System.Data.SqlClient;
using senai.inlock.webApi.Interfaces;

namespace senai.inlock.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private string StringConexao = "Data Source = DESKTOP-2KJISQH\\SENAI; Initial Catalog = inlock_games; User Id = sa; Pwd = Senai@134";
      
        public UsuarioDomain Login(string nome, string senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryLogin = "SELECT Senha FROM Usuario, nome FROM Estudio WHERE Nome = @Nome AND Senha = @Senha";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryLogin, con))
                {
                    cmd.Parameters.AddWithValue("@Senha", senha);
                    cmd.Parameters.AddWithValue("@Nome", nome);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            Nome = rdr["Nome"].ToString(),
                            Senha = rdr["Senha"].ToString()


                        };
                        return usuario;


                    }
                    return null;

                }

            }
        }
    }
}
