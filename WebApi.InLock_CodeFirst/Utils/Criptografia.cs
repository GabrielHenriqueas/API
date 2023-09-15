namespace WebApi.InLock_CodeFirst.Utils
{
    public class Criptografia
    {
        /// <summary>
        /// Gera uma Hash a partir de uma senha
        /// </summary>
        /// <param name="senha">Senha que receberá a hash</param>
        /// <returns>Senha Criptografada com a hash</returns>
        public static string GeraHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        /// <summary>
        /// Verifica se a hash da senha informada é igual á hash salva do bd
        /// </summary>
        /// <param name="senhaForm">Senha passada no form de Login</param>
        /// <param name="senhaBanco">Senha cadastrada no banco</param>
        /// <returns>True or False</returns>
        public static bool CompararHash(string senhaForm, string senhaBanco)
        {
            return BCrypt.Net.BCrypt.Verify(senhaForm, senhaBanco);
        }
    }
}
