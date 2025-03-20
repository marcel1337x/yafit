using YAFIT.Databases.Attributes;
using YAFIT.Databases.Services;

namespace YAFIT.Databases.Entities;

public class Formular1Entity : FormularBaseEntity
{
    private static readonly Formular1Service _formular1Service = new Formular1Service();

    [ValueBinding(0)]
    public virtual int VerhaltenLehrer0 { get; set; }
    [ValueBinding(1)]
    public virtual int VerhaltenLehrer1 { get; set; }
    [ValueBinding(2)]
    public virtual int VerhaltenLehrer2 { get; set; }
    [ValueBinding(3)]
    public virtual int VerhaltenLehrer3 { get; set; }
    [ValueBinding(4)]
    public virtual int VerhaltenLehrer4 { get; set; }
    [ValueBinding(5)]
    public virtual int VerhaltenLehrer5 { get; set; }
    [ValueBinding(6)]
    public virtual int DieLehrer0 { get; set; }
    [ValueBinding(7)]
    public virtual int DieLehrer1 { get; set; }
    [ValueBinding(8)]
    public virtual int DieLehrer2 { get; set; }
    [ValueBinding(9)]
    public virtual int DieLehrer3 { get; set; }
    [ValueBinding(10)]
    public virtual int DieLehrer4 { get; set; }
    [ValueBinding(11)]
    public virtual int Unterricht0 { get; set; }
    [ValueBinding(12)]
    public virtual int Unterricht1 { get; set; }
    [ValueBinding(13)]
    public virtual int Unterricht2 { get; set; }
    [ValueBinding(14)]
    public virtual int Unterricht3 { get; set; }
    [ValueBinding(15)]
    public virtual int Unterricht4 { get; set; }
    [ValueBinding(16)]
    public virtual int Unterricht5 { get; set; }
    [ValueBinding(17)]
    public virtual int Unterricht6 { get; set; }
    [ValueBinding(18)]
    public virtual int Unterricht7 { get; set; }
    [ValueBinding(19)]
    public virtual int Unterricht8 { get; set; }
    [ValueBinding(20)]
    public virtual int Bewertung0 { get; set; }
    [ValueBinding(21)]
    public virtual int Bewertung1 { get; set; }
    [ValueBinding(22)]
    public virtual int Bewertung2 { get; set; }
    
    public virtual string Text0 { get; set; }
    public virtual string Text1 { get; set; }
    public virtual string Text2 { get; set; }
    public static Formular1Service GetFormular1Service()
    {
        return _formular1Service;
    }
}