using FluentNHibernate.Mapping;
using YAFIT.Databases.Entities;

namespace YAFIT.Databases.Mapping;

public class UmfrageMapping : ClassMap<UmfrageEntity>
{
    public UmfrageMapping()
    {
        Id(x => x.Id).GeneratedBy.Increment();
        Map(x => x.User_Id).Not.Nullable();
        Map(x => x.Klassen_Id);
        Map(x => x.Abteilung_Id);
        Map(x => x.Fach_Id);
        Map(x => x.Formulartyp).Not.Nullable();
        Map(x => x.Schluessel).Not.Nullable();
        Map(x => x.ErstelltDatum);
    }
}