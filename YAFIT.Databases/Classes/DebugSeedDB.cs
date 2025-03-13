using System.Collections.Immutable;
using System.Diagnostics;
using System.Reflection;
using YAFIT.Databases.Attributes;
using YAFIT.Databases.Entities;

namespace YAFIT.Databases.Classes;

public class DebugSeedDB
{
    public void CheckAndPutRootUser()
    {
        UserEntity rootUser = new UserEntity();
        rootUser.Name = "root";
        rootUser.Id = 1;
        rootUser.Password = "root";
        rootUser.IsAdmin = true;
        UserEntity? user = UserEntity.GetUserService().GetEntity(x => x.Name == "root");
        if (user != null && user.Password == "root" && user.IsAdmin == true && user.Id == 1)
        {
            return;
        }
        else if (user != null)
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
        firstUser.Password = "lehrer";
        firstUser.IsAdmin = false;
        UserEntity? user = UserEntity.GetUserService()
            .GetEntity(x => x.Name == firstUser.Name);
        if (user != null && user.Password == firstUser.Password && user.IsAdmin == false && user.Id == firstUser.Id)
        {
            return;
        }
        else if (user != null)
        {
            UserEntity.GetUserService().Update(firstUser);
        }
        else
        {
            UserEntity.GetUserService().Insert(firstUser);
        }

    }

    public void AddFormular1TestResults()
    {
    }

    public void PutFirstUserUmfrage()
    {
        UmfrageEntity umfrage = new UmfrageEntity();
        umfrage.ErstelltDatum = DateTime.Now;
        umfrage.Id = 1;
        umfrage.Schluessel = "12345678";
        umfrage.Formulartyp = 1;
        umfrage.User_Id = 2;
        Random random = new Random();


        if (UmfrageEntity.GetUmfrageService().InsertIfNotExist(x => x.Id == umfrage.Id, umfrage))
        {

            for (int i = 0; i < 10; i++)
            {
                Formular1Entity entity = new Formular1Entity() { Umfrage_Id = umfrage.Id };
                PropertyInfo[] properties = entity.GetType().GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    ValueBindingAttribute? bindings = property.GetCustomAttribute<ValueBindingAttribute>();
                    if(bindings != null)
                    {
                        property.SetValue(entity, random.Next(0, 4));

                    }
                }
                Formular1Entity.GetFormular1Service().Insert(entity);
            }
        }
        else
        {
            Debug.WriteLine("EXIST :(");
        }
    }

    public void CheckAndPutFirstAbteilung()
    {
        AbteilungEntity abteilung = new AbteilungEntity();
        abteilung.Name = "Abteilung1";
        abteilung.Id = 1;
        if (AbteilungEntity.GetAbteilungService().GetEntity(x => x.Id == abteilung.Id) != null)
        {
            if (AbteilungEntity.GetAbteilungService().GetEntity(x => x.Id == abteilung.Id && x.Name == abteilung.Name) != null)
            {
                return;
            }
            else
            {
                AbteilungEntity.GetAbteilungService().Update(abteilung);
            }
        }
        else
        {
            AbteilungEntity.GetAbteilungService().Insert(abteilung);
        }
    }

    public void CheckAndPutFirstFach()
    {
        FachEntity fach = new FachEntity();
        fach.Name = "Informatik";
        fach.Id = 1;
        if (FachEntity.GetFachService().GetEntity(x => x.Id == fach.Id) != null)
        {
            if (FachEntity.GetFachService().GetEntity(x => x.Id == fach.Id && x.Name == fach.Name) != null)
            {
                return;
            }
            else
            {
                FachEntity.GetFachService().Update(fach);
            }
        }
        else
        {
            FachEntity.GetFachService().Insert(fach);
        }
    }

    public void CheckAndPutFirstKlasse()
    {
        KlassenEntity klasse = new KlassenEntity();
        klasse.Name = "IFA-12-A";
        klasse.Id = 1;
        if (KlassenEntity.GetKlassenService().GetEntity(x => x.Id == klasse.Id) != null)
        {
            if (KlassenEntity.GetKlassenService().GetEntity(x => x.Id == klasse.Id && x.Name == klasse.Name) != null)
            {
                return;
            }
            else
            {
                KlassenEntity.GetKlassenService().Update(klasse);
            }
        }
        else
        {
            KlassenEntity.GetKlassenService().Insert(klasse);
        }
    }
}