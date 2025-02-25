using YAFIT.Databases.Services;

namespace YAFIT.Databases.Entities;

public class AbteilungEntity
{
    private static readonly AbteilungService _abteilungService = new AbteilungService();
    public virtual int Id { get; set; }
    public virtual string Name { get; set; }
    public static AbteilungService GetAbteilungService()
    {
        return _abteilungService;
    }
}