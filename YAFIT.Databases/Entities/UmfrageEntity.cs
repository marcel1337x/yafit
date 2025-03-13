using YAFIT.Databases.Services;

namespace YAFIT.Databases.Entities;

public class UmfrageEntity
{
    private static readonly UmfrageService _umfrageService = new UmfrageService();
    public virtual int Id { get; set; }
    public virtual int User_Id { get; set; }
    public virtual string Schluessel { get; set; }
    public virtual int Formulartyp { get; set; }
    public virtual int Klassen_Id { get; set; }
    public virtual int Abteilung_Id { get; set; }
    public virtual int Fach_Id { get; set; }
    public virtual DateTime ErstelltDatum { get; set; }
    public static UmfrageService GetUmfrageService()
    {
        return _umfrageService;
    }
}