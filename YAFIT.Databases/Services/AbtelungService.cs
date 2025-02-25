using YAFIT.Databases.Entities;

namespace YAFIT.Databases.Services;

public class AbtelungService
{
    public AbteilungEntity getAbteilungByID(int id)
    {
        using (var session = SessionManager.Instance.OpenStatelessSession())
        {
            return session.Get<AbteilungEntity>(id);
        }
    }
}