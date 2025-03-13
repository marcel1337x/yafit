using NHibernate;
using System.Diagnostics;
using YAFIT.Databases.Entities;

namespace YAFIT.Databases.Services
{
    public class FormularBaseService<T> : SessionService<T> where T : FormularBaseEntity
    {

        public bool DeleteAllFormularBy(IStatelessSession session, int umfrageId)
        {
            try
            {
                IList<T> results = GetAllByCriteria(x => x.Umfrage_Id == umfrageId);
                foreach (T result in results)
                {
                    session.Delete(result);
                    Debug.WriteLine("DELETED: " + result.Id + ", " + result.Umfrage_Id);
                }
                return true;
            }catch(Exception e)
            {
                Debug.WriteLine(e);
            }
            return false;
        }
    }
}
