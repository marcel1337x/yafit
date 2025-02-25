using YAFIT.Databases.Entities;

namespace YAFIT.Databases.Services;

public class KlassenService
{
    public KlassenEntity getKlasseByID(int id)
    {
        using (var session = SessionManager.Instance.OpenStatelessSession())
        {
            return session.Get<KlassenEntity>(id);
        }
    }
}