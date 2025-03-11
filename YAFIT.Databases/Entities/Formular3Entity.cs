using YAFIT.Databases.Services;

namespace YAFIT.Databases.Entities;

public class Formular3Entity : FormularBaseEntity
{
    private static readonly Formular3Service _formular3Service = new Formular3Service();

    public virtual string Text0 { get; set; }
    public virtual string Text1 { get; set; }
    public static Formular3Service GetFormular3Service()
    {
        return _formular3Service;
    }
}