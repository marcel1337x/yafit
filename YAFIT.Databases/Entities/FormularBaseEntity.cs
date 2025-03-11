namespace YAFIT.Databases.Entities;

public class FormularBaseEntity
{
    public virtual int Id { get; set; }
    public virtual UmfrageEntity Umfrage { get; set; }
}