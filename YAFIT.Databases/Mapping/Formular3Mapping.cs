using YAFIT.Databases.Entities;

namespace YAFIT.Databases.Mapping;

public class Formular3Mapping : FormularBaseMapping<Formular3Entity>
{
    public Formular3Mapping()
    {
        Map(x => x.Text0).Nullable();
        Map(x => x.Text1).Nullable();
    }
}