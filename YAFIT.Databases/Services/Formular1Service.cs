using NHibernate;
using YAFIT.Databases.Entities;

namespace YAFIT.Databases.Services;

public class Formular1Service : SessionService<Formular1Entity>
{
    protected override bool Insert(IStatelessSession session, params Formular1Entity[] entities)
    {
        foreach (var entity in entities)
        {
            session.Insert(entity);
        }
        return true;
    }

    protected override bool Update(IStatelessSession session, params Formular1Entity[] entities)
    {
        foreach (var entity in entities)
        {
            session.Update(entity);
        }
        return true;
    }

    protected override bool Delete(IStatelessSession session, params Formular1Entity[] entities)
    {
        foreach (var entity in entities)
        {
            session.Delete(entity);
        }
        return true;
    }

    //TODO:
    //Methode, die ein Formular anhand der UmfrageId holt
}