using System.Collections.Immutable;
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
        UserEntity? user = UserEntity.GetUserService().GetEntity(x => x.Name == "root");
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

    public void InsertTestRegisterCode()
    {
        RegisterEntity register = new RegisterEntity()
        {
            Code = "123"
        };
        if (RegisterEntity.GetRegisterService().GetEntity(x => x.Code == "123") == null)
        {
            RegisterEntity.GetRegisterService().Insert(register);
        }
    }
    
    public void CheckAndPutFirstUser()
    {
        UserEntity firstUser = new UserEntity();
        firstUser.Name = "lehrer";
        firstUser.Id = 2;
        firstUser.password = "lehrer";
        firstUser.isAdmin = false;
        UserEntity? user = UserEntity.GetUserService()
            .GetEntity(x => x.Name == firstUser.Name);
        if (user != null && user.password == firstUser.password && user.isAdmin == false && user.Id == firstUser.Id)
        {
            return;
        }else if (user != null)
        {
            UserEntity.GetUserService().Update(firstUser);
            PutFirstUserUmfrage(firstUser);
        }
        else
        {
            UserEntity.GetUserService().Insert(firstUser);
            PutFirstUserUmfrage(firstUser);
        }
        
    }

    public void AddFormular1TestResults()
    {
    }

    private void PutFirstUserUmfrage(UserEntity user)
    {
        UmfrageEntity umfrage = new UmfrageEntity();
        umfrage.ErstelltDatum = DateTime.Now;
        umfrage.Id = 1;
        umfrage.Schluessel = "12345678";
        umfrage.Formulartyp = 1;
        umfrage.User = user;
        UmfrageEntity.GetUmfrageService().Insert(umfrage);

        Formular1Entity formular1Entities = new Formular1Entity() { DieLehrer0 = 3, DieLehrer2 = 2 , Umfrage = umfrage};
        Formular1Entity.GetFormular1Service().InsertIfNotExist(x => x.Id == formular1Entities.Id, formular1Entities);
    }
}