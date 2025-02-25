using YAFIT.Databases.Entities;

namespace YAFIT.Databases.Services;

public class FachService
{
    public FachEntity getFachByID(int id)
    {
        using (var session = SessionManager.Instance.OpenStatelessSession())
        {
            return session.Get<FachEntity>(id);
        }
    }
}