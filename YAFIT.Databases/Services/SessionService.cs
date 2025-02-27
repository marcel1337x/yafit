using System.Diagnostics;
using NHibernate;
using System.Linq.Expressions;

namespace YAFIT.Databases.Services
{
    public abstract class SessionService<T> where T : class
    {
        public IList<T> GetAll()
        {
            using var session = SessionManager.Instance.OpenStatelessSession();
            return session.CreateCriteria<T>().List<T>();
        }

        public IList<T> GetAllByCriteria(Expression<Func<T, bool>> expression)
        {
            using var session = SessionManager.Instance.OpenStatelessSession();
            return session.QueryOver<T>().Where(expression).List<T>();
        }

        public T? GetEntity(Expression<Func<T, bool>> expression)
        {
            using var session = SessionManager.Instance.OpenStatelessSession();
            return session.QueryOver<T>().Where(expression).SingleOrDefault()??null;
        }

        public bool Insert(params T[] entities)
        {
            using var session = SessionManager.Instance.OpenStatelessSession();
            using var transaction = session.BeginTransaction();
            try
            {
                bool result = Insert(session, entities);
                transaction.Commit();
                return result;
            }
            catch (Exception e)
            {
                //@TODO: Fehler nachricht hinzufügen
                transaction.Rollback();
            }
            return false;
        }
        public bool Update(params T[] entities)
        {
            using var session = SessionManager.Instance.OpenStatelessSession();
            using var transaction = session.BeginTransaction();
            try
            {
                bool result = Update(session, entities);
                transaction.Commit();
                return result;
            }
            catch (Exception e)
            {
                //@TODO: Fehler nachricht hinzufügen
                transaction.Rollback();
            }
            return false;
        }
        public bool Delete(params T[] entities)
        {
            using var session = SessionManager.Instance.OpenStatelessSession();
            using var transaction = session.BeginTransaction();
            try
            {
                bool result = Delete(session, entities);
                transaction.Commit();
                return result;
            }
            catch (Exception e)
            {
                //@TODO: Fehler nachricht hinzufügen
                transaction.Rollback();
            }
            return false;
        }



        protected abstract bool Insert(IStatelessSession session, params T[] entities);
        protected abstract bool Update(IStatelessSession session, params T[] entities);
        protected abstract bool Delete(IStatelessSession session, params T[] entities);
    }
}
