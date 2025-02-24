using FluentNHibernate.Mapping;
using YAFIT.Databases.Entities;

namespace YAFIT.Databases.Mapping;

public class Formular1Map : ClassMap<Formular1>
{
    public Formular1Map()
    {
        Id(x => x.id).GeneratedBy.Native();
        Map(x => x.verhalten_lehrer_0);
        Map(x => x.verhalten_lehrer_1);
        Map(x => x.verhalten_lehrer_2);
        Map(x => x.verhalten_lehrer_3);
        Map(x => x.verhalten_lehrer_4);
        Map(x => x.verhalten_lehrer_5);
        Map(x => x.die_lehrer_0);
        Map(x => x.die_lehrer_1);
        Map(x => x.die_lehrer_2);
        Map(x => x.die_lehrer_3);
        Map(x => x.die_lehrer_4);
        Map(x => x.unterricht_0);
        Map(x => x.unterricht_1);
        Map(x => x.unterricht_2);
        Map(x => x.unterricht_3);
        Map(x => x.unterricht_4);
        Map(x => x.unterricht_5);
        Map(x => x.unterricht_6);
        Map(x => x.unterricht_7);
        Map(x => x.unterricht_8);
        Map(x => x.bewertung_0);
        Map(x => x.bewertung_1);
        Map(x => x.bewertung_2);
        Map(x => x.text0).Nullable();
        Map(x => x.text1).Nullable();
        Map(x => x.text2).Nullable();
    }
    
}