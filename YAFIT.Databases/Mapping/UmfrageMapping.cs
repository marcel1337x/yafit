using FluentNHibernate.Mapping;
using YAFIT.Databases.Entities;

namespace YAFIT.Databases.Mapping;

public class UmfrageMapping : ClassMap<UmfrageEntity>
{
    public UmfrageMapping()
    {
        Id(x => x.Id).GeneratedBy.Increment();
        References(x => x.User).Not.Nullable();
        References(x => x.Klassen);
        References(x => x.Abteilung);
        References(x => x.Fach);
        Map(x => x.Formulartyp).Not.Nullable();
        Map(x => x.Schluessel).Not.Nullable();
        Map(x => x.ErstelltDatum);
    }
}