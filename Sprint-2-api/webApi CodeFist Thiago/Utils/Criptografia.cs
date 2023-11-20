using System.Runtime.CompilerServices;

namespace webApi_CodeFist_Thiago.Utils
{
    public class Criptografia
    {
        public static String GerarHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        /// <summary>
        /// Verificar se a Hash da senha informada é igual á hash salva no bd
        /// </summary>
        /// <param name="senhaForm">Senha passada no form do login</param>
        /// <param name="senhaBanco">Senha cadastrada no Banco</param>
        /// <returns>True ou False</returns>

        public  static bool CompararHash(string senhaForm, string senhaBanco)
        {
            return BCrypt.Net.BCrypt.Verify(senhaForm, senhaBanco);
        }
    }
}
