using FluentNHibernate.Mapping;
using YAFIT.Databases.Entities;

namespace YAFIT.Databases.Mapping;

public class FachMapping : ClassMap<FachEntity>
{
    public FachMapping()
    {
        Id(x => x.Id).GeneratedBy.Increment();
        Map(x => x.Name).Not.Nullable();
    }
}