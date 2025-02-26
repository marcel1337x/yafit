using NHibernate;
using YAFIT.Databases.Entities;

namespace YAFIT.Databases.Services;

public class UmfrageService : SessionService<UmfrageEntity>
{
    protected override bool Insert(IStatelessSession session, params UmfrageEntity[] entities)
    {
        foreach (var entity in entities)
        {
            session.Insert(entity);
        }
        return true;
    }

    protected override bool Update(IStatelessSession session, params UmfrageEntity[] entities)
    {
        foreach (var entity in entities)
        {
            session.Update(entity);
        }
        return true;
    }

    protected override bool Delete(IStatelessSession session, params UmfrageEntity[] entities)
    {
        foreach (var entity in entities)
        {
            session.Delete(entity);
        }
        return true;
    }

    //TODO:
    //Mehtode, die eine Umfrage anhand des Schlüssels sucht 
}