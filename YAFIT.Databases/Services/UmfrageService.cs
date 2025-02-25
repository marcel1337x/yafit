using YAFIT.Databases.Entities;

namespace YAFIT.Databases.Services;

public class UmfrageService
{
    public UmfrageEntity getUmfrage(int id)
    {
        using (var session = SessionManager.Instance.OpenStatelessSession())
        {
            return session.Get<UmfrageEntity>(id);
        }
    }

    public List<UmfrageEntity> getUmfragenByUser(UserEntity user)
    {
        using (var session = SessionManager.Instance.OpenStatelessSession())
        {
            return session.Query<UmfrageEntity>().Where(entity => entity.User == user).ToList();
        }
    }

    public bool CreateUmfrage(UmfrageEntity umfrage)
    {
        using (var session = SessionManager.Instance.OpenStatelessSession())
        {
            return session.Insert(umfrage) != null;
        }
    }

    public bool DeleteById(int id)
    {
        using (var session = SessionManager.Instance.OpenStatelessSession())
        {
            var umfrage = session.Get<UmfrageEntity>(id);
            if (umfrage == null)
            {
                return false;
            }
            session.Delete(umfrage);
            return true;
        }
    }
}