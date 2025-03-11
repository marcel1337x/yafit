using FluentNHibernate.Mapping;
using YAFIT.Databases.Entities;

namespace YAFIT.Databases.Mapping
{
    public class FormularBaseMapping<T> : ClassMap<T> where T : FormularBaseEntity
    {
        public FormularBaseMapping()
        {
            Id(x => x.Id).GeneratedBy.Increment();
            References(x => x.Umfrage).Not.Nullable();
        }
    }
}
