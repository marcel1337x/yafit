using NHibernate;
using System.Diagnostics;
using YAFIT.Databases.Entities;

namespace YAFIT.Databases.Services;

public class UmfrageService : SessionService<UmfrageEntity>
{

    public bool DeleteUmfrage(UmfrageEntity umfrage)
    {
        using var session = SessionManager.Instance.OpenStatelessSession();
        using var transaction = session.BeginTransaction();
        try
        {
            session.Delete(umfrage);
            bool resultsDeleted = false;
            switch (umfrage.Formulartyp)
            {
                case 1:
                    resultsDeleted = Formular1Entity.GetFormular1Service().DeleteAllFormularBy(session, umfrage.Id);
                    break;
                case 2:
                    resultsDeleted = Formular2Entity.GetFormular2Service().DeleteAllFormularBy(session, umfrage.Id);
                    break;
                case 3:
                    resultsDeleted = Formular3Entity.GetFormular3Service().DeleteAllFormularBy(session, umfrage.Id);
                    break;

            }
            if(resultsDeleted == false)
            {
                transaction.Rollback();
                return false;
            }
            transaction.Commit();
            return true;
        }
        catch (Exception e)
        {

            Debug.WriteLine(e);
        }
        transaction.Rollback();
        return false;
    }
}