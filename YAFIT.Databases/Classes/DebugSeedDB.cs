using System.Diagnostics;
using System.Reflection;
using YAFIT.Databases.Attributes;
using YAFIT.Databases.Entities;

namespace YAFIT.Databases.Classes;

public class DebugSeedDB
{

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

    public void AddTestUsers()
    {
        for (int i = 0; i < 10; i++)
        {

            UserEntity user = new()
            {
                Name = "lehrer" + i,
                Id = 2 + i,
                Password = "lehrer",
                IsAdmin = false
            };
            if (UserEntity.GetUserService().InsertIfNotExist(x => x.Id == user.Id, user))
            {
                Debug.WriteLine("Added " + user.Name + " with ID " + user.Id);
            }
        }
    }

    public void AddUmfragenTests()
    {
        for (int i = 0; i < 5; i++)
        {
            UmfrageEntity umfrage = new()
            {
                ErstelltDatum = DateTime.Now,
                Id = 1+i,
                Schluessel = "lehrer"+i,
                Formulartyp = 1,
                User_Id = 2+i
            };
            Random random = new Random();


            if (UmfrageEntity.GetUmfrageService().InsertIfNotExist(x => x.Id == umfrage.Id, umfrage) == false)
            {
                return;
            }

            for (int x = 0; x < random.Next(7,12); x++)
            {
                Formular1Entity entity = new Formular1Entity() { Umfrage_Id = umfrage.Id };
                PropertyInfo[] properties = entity.GetType().GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    ValueBindingAttribute? bindings = property.GetCustomAttribute<ValueBindingAttribute>();
                    if (bindings != null)
                    {
                        property.SetValue(entity, random.Next(0, 4));

                    }
                }
                Formular1Entity.GetFormular1Service().Insert(entity);
            }
        }
    }

    public void AddAbteilungen()
    {
        for (int i = 0; i < 10; i++)
        {
            AbteilungEntity abteilung = new()
            {
                Name = "Abteilung"+i,
                Id = 1 + i
            };
            AbteilungEntity.GetAbteilungService().InsertIfNotExist(x => x.Id == abteilung.Id, abteilung);
        }
    }

    public void AddFaecher()
    {
        for (int i = 0; i < 10; i++)
        {
            FachEntity fach = new()
            {
                Name = "Informatik" + i,
                Id = 1 + i
            };
            FachEntity.GetFachService().InsertIfNotExist(x => x.Id == fach.Id, fach);
        }
    }

    public void AddKlassen()
    {
        for (int i = 0; i < 10; i++)
        {
            KlassenEntity klasse = new()
            {
                Name = "IFA-12,"+i+"-A",
                Id = 1 + i
            };
            KlassenEntity.GetKlassenService().InsertIfNotExist(x => x.Id == klasse.Id, klasse);
        }
    }
}