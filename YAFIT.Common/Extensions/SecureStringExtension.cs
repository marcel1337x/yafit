using System.Net;
using System.Security;

namespace YAFIT.Common.Extensions
{
    public static class SecureStringExtension
    {
        //SOURCE: https://stackoverflow.com/questions/818704/how-to-convert-securestring-to-system-string

        public static string? ConvertToPlainText(this SecureString secureString)
        {
            return new NetworkCredential(string.Empty, secureString).Password;
        }
    }
}
