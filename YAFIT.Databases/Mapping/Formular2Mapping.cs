using FluentNHibernate.Mapping;
using YAFIT.Databases.Entities;

namespace YAFIT.Databases.Mapping;

public class Formular2Mapping : ClassMap<Formular2Entity>
{
    public Formular2Mapping()
    {
        Id(x => x.Id).GeneratedBy.Increment();
        References(x => x.Umfrage).Not.Nullable();
        Map(x => x.Question1).Not.Nullable();
        Map(x => x.Question2).Not.Nullable();
        Map(x => x.Question3).Not.Nullable();
        Map(x => x.Question4).Not.Nullable();
        Map(x => x.Question5).Not.Nullable();
        Map(x => x.Question6).Not.Nullable();
        Map(x => x.Question7).Not.Nullable();
        Map(x => x.Question8).Not.Nullable();
        Map(x => x.Text).Nullable();
    }
    
}