using YAFIT.Databases.Services;

namespace YAFIT.Databases.Entities;

public class UserEntity
{
    private static readonly UserService _userService = new UserService();
    public virtual int Id { get; set; }
    public virtual string Name { get; set; }
    public virtual bool isAdmin { get; set; }
    public virtual string password { get; set; }

    public static UserService GetUserService()
    {
        return _userService;
    }
}