namespace YAFIT.Databases.Entities;

public class UmfrageEntity
{
    public virtual int Id { get; set; }
    public virtual UserEntity User { get; set; }
    public virtual string Schluessel { get; set; }
    public virtual KlassenEntity Klassen { get; set; }
    public virtual AbteilungEntity Abteilung { get; set; }
    public virtual FachEntity Fach { get; set; }
    public virtual DateTime ErstelltDatum { get; set; }
}