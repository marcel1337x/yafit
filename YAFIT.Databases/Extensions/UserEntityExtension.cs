using System.Security.Cryptography;
using System.Text.RegularExpressions;
using YAFIT.Databases.Entities;

namespace YAFIT.Databases.Extensions
{
    public static class UserEntityExtension
    {
        public static bool IsPasswordValid(this UserEntity userEntity,string? password)
        {
            if (string.IsNullOrEmpty(password) == true)
            {
                return false;
            }
            if(PASSWORD_BASE64_PATTERN.IsMatch(userEntity.Password) == false)
            {
                return false;
            }
            byte[] userPasswordBase64 = Convert.FromBase64String(userEntity.Password);
            byte[] salt = new byte[16];
            try
            {
                Array.Copy(userPasswordBase64, 0, salt, 0, 16);
            } catch(Exception e)
            {

                return false;
            }
            var pbkdf2 = new Rfc2898DeriveBytes(password ?? "", salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            for (int i = 0; i < 20; i++)
            {
                if (userPasswordBase64[i + 16] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }
        private static readonly Regex PASSWORD_BASE64_PATTERN = new Regex(@"^[a-zA-Z0-9\+/]*={0,2}$");
    }
}
