using YAFIT.Databases.Services;

namespace YAFIT.Databases.Entities;

public class FormularBaseEntity
{
    public virtual int Id { get; set; }
    public virtual int Umfrage_Id { get; set; }
}