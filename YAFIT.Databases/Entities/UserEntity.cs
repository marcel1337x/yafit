namespace YAFIT.Databases.Entities;

public class UserEntity
{
    public virtual int Id { get; set; }
    public virtual string Name { get; set; }
    public virtual bool isAdmin { get; set; }
    public virtual string password { get; set; }
}