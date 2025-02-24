using FluentNHibernate.Mapping;
using YAFIT.Databases.Entities;

namespace YAFIT.Databases.Mapping
{
    public class TestEntityMapping : ClassMap<TestEntity>
    {
        public TestEntityMapping()
        {
            //Table("TestEntity");
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Email);
            Map(x => x.Name);
        }
    }
}
