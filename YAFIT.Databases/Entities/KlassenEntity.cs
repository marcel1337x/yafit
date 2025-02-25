using YAFIT.Databases.Services;

namespace YAFIT.Databases.Entities;

public class KlassenEntity
{
    private static readonly KlassenService _klassenService = new KlassenService();
    public virtual int Id { get; set; }
    public virtual string Name { get; set; }
    public static KlassenService GetKlassenService()
    {
        return _klassenService;
    }
}