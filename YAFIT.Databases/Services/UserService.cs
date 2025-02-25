using YAFIT.Databases.Entities;

namespace YAFIT.Databases.Services;

public class UserService
{

    public UserEntity getUserById(int id)
    {
        using (var session = SessionManager.Instance.OpenStatelessSession())
        {
            return session.Get<UserEntity>(id);
        }
    }

    public UserEntity getUserByName(string name)
    {
        using (var session = SessionManager.Instance.OpenStatelessSession())
        {
            return session.Get<UserEntity>(name);
        }
    }

    public bool save(UserEntity user)
    {
        using (var session = SessionManager.Instance.OpenStatelessSession())
        {
            if (existsById(user.Id))
            {
                return false;
            }
            session.Insert(user);
            return true;
        }
    }

    public bool existsById(int id)
    {
        using (var session = SessionManager.Instance.OpenStatelessSession())
        {
            if (session.Get<UserEntity>(id) == null)
            {
                return false;
            }

            return true;
        }
    }

    public bool deleteById(int id)
    {
        using (var session = SessionManager.Instance.OpenStatelessSession())
        {
            var user = session.Get<UserEntity>(id);
            if (user == null)
            {
                return false;
            }
            session.Delete(user);
            return true;
        }
    }

    public List<UserEntity> getAllUsers()
    {
        using (var session = SessionManager.Instance.OpenStatelessSession())
        {
            return session.Query<UserEntity>().ToList();
        }
    }
}