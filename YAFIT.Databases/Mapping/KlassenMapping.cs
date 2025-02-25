using FluentNHibernate.Mapping;
using YAFIT.Databases.Entities;

namespace YAFIT.Databases.Mapping;

public class KlassenMapping : ClassMap<KlassenEntity>
{
    public KlassenMapping()
    {
        Id(x => x.Id).GeneratedBy.Increment();
        Map(x => x.Name).Not.Nullable();
    }
}