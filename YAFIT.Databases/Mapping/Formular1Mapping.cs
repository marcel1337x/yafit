using FluentNHibernate.Mapping;
using YAFIT.Databases.Entities;

namespace YAFIT.Databases.Mapping;

public class Formular1Mapping : ClassMap<Formular1Entity>
{
    public Formular1Mapping()
    {
        Id(x => x.Id).GeneratedBy.Increment();
        References(x => x.Umfrage).Not.Nullable();
        Map(x => x.VerhaltenLehrer0).Not.Nullable();
        Map(x => x.VerhaltenLehrer1).Not.Nullable();
        Map(x => x.VerhaltenLehrer2).Not.Nullable();
        Map(x => x.VerhaltenLehrer3).Not.Nullable();
        Map(x => x.VerhaltenLehrer4).Not.Nullable();
        Map(x => x.VerhaltenLehrer5).Not.Nullable();
        Map(x => x.DieLehrer0).Not.Nullable();
        Map(x => x.DieLehrer1).Not.Nullable();
        Map(x => x.DieLehrer2).Not.Nullable();
        Map(x => x.DieLehrer3).Not.Nullable();
        Map(x => x.DieLehrer4).Not.Nullable();
        Map(x => x.Unterricht0).Not.Nullable();
        Map(x => x.Unterricht1).Not.Nullable();
        Map(x => x.Unterricht2).Not.Nullable();
        Map(x => x.Unterricht3).Not.Nullable();
        Map(x => x.Unterricht4).Not.Nullable();
        Map(x => x.Unterricht5).Not.Nullable();
        Map(x => x.Unterricht6).Not.Nullable();
        Map(x => x.Unterricht7).Not.Nullable();
        Map(x => x.Unterricht8).Not.Nullable();
        Map(x => x.Bewertung0).Not.Nullable();
        Map(x => x.Bewertung1).Not.Nullable();
        Map(x => x.Bewertung2).Not.Nullable();
        Map(x => x.Text0).Nullable();
        Map(x => x.Text1).Nullable();
        Map(x => x.Text2).Nullable();
    }
    
}