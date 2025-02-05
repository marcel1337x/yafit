using System.Net;
using System.Security;

namespace YAFIT.Common.Extensions
{

    /// <summary>
    /// Eine Klasse mit Erweiterungsmethoden für SecureString
    /// </summary>
    public static class SecureStringExtension
    {
        //SOURCE: https://stackoverflow.com/questions/818704/how-to-convert-securestring-to-system-string

        /// <summary>
        /// Eine Methode, die einen SecureString in einen Klartext konvertiert
        /// </summary>
        /// <param name="secureString">Der SecureString</param>
        /// <returns>Gibt im Klartext den SecureString Wertt zurück</returns>
        public static string? ConvertToPlainText(this SecureString secureString)
        {
            return new NetworkCredential(string.Empty, secureString).Password;
        }
    }
}
