using YAFIT.Databases.Services;

namespace YAFIT.Databases.Entities;

public class FachEntity
{
    private static readonly FachService _fachService = new FachService();
    public virtual int Id { get; set; }
    public virtual string Name { get; set; }
    public static FachService GetFachService()
    {
        return _fachService;
    }
}