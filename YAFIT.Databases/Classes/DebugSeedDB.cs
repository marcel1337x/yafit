using YAFIT.Databases.Entities;

namespace YAFIT.Databases.Classes;

public class DebugSeedDB
{
    public void CheckAndPutRootUser()
    {
        UserEntity rootUser = new UserEntity();
        rootUser.Name = "root";
        rootUser.Id = 1;
        rootUser.password = "root";
        rootUser.isAdmin = true;
        UserEntity? user = UserEntity.GetUserService()
            .GetEntity(x => x.Name == "root");
        if (user != null && user.password == "root" && user.isAdmin == true && user.Id == 1)
        {
            return;
        }else if (user != null)
        {
            UserEntity.GetUserService().Update(rootUser);
        }
        else
        {
            UserEntity.GetUserService().Insert(rootUser);
        }
    }
}