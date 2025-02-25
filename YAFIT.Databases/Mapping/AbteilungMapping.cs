using FluentNHibernate.Mapping;
using YAFIT.Databases.Entities;

namespace YAFIT.Databases.Mapping;

public class AbteilungMapping : ClassMap<AbteilungEntity>
{
    public AbteilungMapping()
    {
        Id(x => x.Id).GeneratedBy.Increment();
        Map(x => x.Name).Not.Nullable();
    }
}