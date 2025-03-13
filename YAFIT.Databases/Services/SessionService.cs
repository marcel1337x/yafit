using System.Diagnostics;
using NHibernate;
using System.Linq.Expressions;
using YAFIT.Databases.Entities;

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
                Debug.WriteLine("Fehler beim einfügen in die Datenbank: \n" + e);
                Console.WriteLine("Fehler beim einfügen in die Datenbank: \n" + e);
                transaction.Rollback();
            }
            return false;
        }

        public bool InsertIfNotExist(Expression<Func<T, bool>> expression, T value)
        {
            using var session = SessionManager.Instance.OpenStatelessSession();
            using var transaction = session.BeginTransaction();
            try
            {
                if (GetEntity(expression) == null)
                {
                    Insert(value);
                    transaction.Commit();
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Fehler beim akutalisieren in die Datenbank: \n" + e);
                Console.WriteLine("Fehler beim akutalisieren in die Datenbank: \n" + e);
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
                Debug.WriteLine("Fehler beim akutalisieren in die Datenbank: \n" + e);
                Console.WriteLine("Fehler beim akutalisieren in die Datenbank: \n" + e);
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
                Debug.WriteLine("Fehler beim löschen aus der Datenbank: \n" + e);
                Console.WriteLine("Fehler beim löschen aus der Datenbank: \n" + e);
                transaction.Rollback();
            }
            return false;
        }
        protected virtual bool Insert(IStatelessSession session, params T[] entities)
        {
            foreach (var entity in entities)
            {
                session.Insert(entity);
            }
            return true;
        }

        protected virtual bool Update(IStatelessSession session, params T[] entities)
        {
            foreach (var entity in entities)
            {
                session.Update(entity);
            }
            return true;
        }

        protected virtual bool Delete(IStatelessSession session, params T[] entities)
        {
            foreach (var entity in entities)
            {
                session.Delete(entity);
            }
            return true;
        }
    }
}
