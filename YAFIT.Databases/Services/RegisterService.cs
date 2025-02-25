using YAFIT.Databases.Entities;

namespace YAFIT.Databases.Services;

public class RegisterService
{
    public bool createCode(string code)
    {
        using (var session = SessionManager.Instance.OpenStatelessSession())
        {
            RegisterEntity entity = new RegisterEntity();
            entity.Code = code;
            if (session.Query<RegisterEntity>().Where(x => x.Code == code).Count() == 0)
            {
                session.Insert(entity);
                return true;
            }

            return false;
        }
    }
}