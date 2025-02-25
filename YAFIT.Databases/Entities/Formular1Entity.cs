using YAFIT.Databases.Services;

namespace YAFIT.Databases.Entities;

public class Formular1Entity
{
    private static readonly Formular1Service _formular1Service = new Formular1Service();
    public virtual int Id { get; set; }
    public virtual UmfrageEntity Umfrage { get; set; }
    public virtual int VerhaltenLehrer0 { get; set; }
    public virtual int VerhaltenLehrer1 { get; set; }
    public virtual int VerhaltenLehrer2 { get; set; }
    public virtual int VerhaltenLehrer3 { get; set; }
    public virtual int VerhaltenLehrer4 { get; set; }
    public virtual int VerhaltenLehrer5 { get; set; }
    public virtual int DieLehrer0 { get; set; }
    public virtual int DieLehrer1 { get; set; }
    public virtual int DieLehrer2 { get; set; }
    public virtual int DieLehrer3 { get; set; }
    public virtual int DieLehrer4 { get; set; }
    public virtual int Unterricht0 { get; set; }
    public virtual int Unterricht1 { get; set; }
    public virtual int Unterricht2 { get; set; }
    public virtual int Unterricht3 { get; set; }
    public virtual int Unterricht4 { get; set; }
    public virtual int Unterricht5 { get; set; }
    public virtual int Unterricht6 { get; set; }
    public virtual int Unterricht7 { get; set; }
    public virtual int Unterricht8 { get; set; }
    public virtual int Bewertung0 { get; set; }
    public virtual int Bewertung1 { get; set; }
    public virtual int Bewertung2 { get; set; }
    public virtual string Text0 { get; set; }
    public virtual string Text1 { get; set; }
    public virtual string Text2 { get; set; }
    public static Formular1Service GetFormular1Service()
    {
        return _formular1Service;
    }
}