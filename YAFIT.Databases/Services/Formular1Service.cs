using YAFIT.Databases.Entities;

namespace YAFIT.Databases.Services;

public class Formular1Service
{
    public Formular1Entity getFormular1Entity(int id)
    {
        using (var session = SessionManager.Instance.OpenStatelessSession())
        {
            return session.Get<Formular1Entity>(id);
        }
    }
}