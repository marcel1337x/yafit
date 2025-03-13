using NHibernate;
using System.Security.Cryptography;
using YAFIT.Databases.Entities;

namespace YAFIT.Databases.Services;

public class UserService : SessionService<UserEntity>
{
    protected override bool Insert(IStatelessSession session, params UserEntity[] entities)
    {
        foreach(var entity in entities)
        {
            // https://stackoverflow.com/questions/4181198/how-to-hash-a-password#10402129
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(entity.Password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            entity.Password = savedPasswordHash;
        }
        return base.Insert(session,entities);
    }

    protected override bool Update(IStatelessSession session, params UserEntity[] entities)
    {
        foreach(var entity in entities)
        {
            if (!IsBase64String(entity.Password))
            {
                // https://stackoverflow.com/questions/4181198/how-to-hash-a-password#10402129
                byte[] salt;
                new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
                var pbkdf2 = new Rfc2898DeriveBytes(entity.Password, salt, 100000);
                byte[] hash = pbkdf2.GetBytes(20);
                byte[] hashBytes = new byte[36];
                Array.Copy(salt, 0, hashBytes, 0, 16);
                Array.Copy(hash, 0, hashBytes, 16, 20);
                string savedPasswordHash = Convert.ToBase64String(hashBytes);
                entity.Password = savedPasswordHash;
            }
        }
        return base.Update(session, entities);
    }
    
    private static bool IsBase64String(string base64)
    {
        Span<byte> buffer = new Span<byte>(new byte[base64.Length]);
        return Convert.TryFromBase64String(base64, buffer , out int bytesParsed);
    }
}