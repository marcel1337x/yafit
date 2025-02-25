using FluentNHibernate.Mapping;
using YAFIT.Databases.Entities;

namespace YAFIT.Databases.Mapping;

public class UmfrageMapping : ClassMap<UmfrageEntity>
{
    public UmfrageMapping()
    {
        Id(x => x.Id).GeneratedBy.Increment();
        References(x => x.User).Not.Nullable();
        References(x => x.Klassen).Not.Nullable();
        References(x => x.Abteilung).Not.Nullable();
        References(x => x.Fach).Not.Nullable();
        Map(x => x.Schluessel).Not.Nullable();
        Map(x => x.ErstelltDatum);
    }
}