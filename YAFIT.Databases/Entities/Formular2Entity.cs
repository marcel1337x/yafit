using YAFIT.Databases.Services;

namespace YAFIT.Databases.Entities;

public class Formular2Entity : FormularBaseEntity
{
    private static readonly Formular2Service _formular2Service = new Formular2Service();

    public virtual int Question1 { get; set; }
    public virtual int Question2 { get; set; }
    public virtual int Question3 { get; set; }
    public virtual int Question4 { get; set; }
    public virtual int Question5 { get; set; }
    public virtual int Question6 { get; set; }
    public virtual int Question7 { get; set; }
    public virtual int Question8 { get; set; }
    public virtual string Text { get; set; }
    public static Formular2Service GetFormular2Service()
    {
        return _formular2Service;
    }
}