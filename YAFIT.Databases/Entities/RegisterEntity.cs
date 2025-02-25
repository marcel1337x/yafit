using YAFIT.Databases.Services;

namespace YAFIT.Databases.Entities;

public class RegisterEntity
{
    private static readonly RegisterService _registerService = new RegisterService();
    public virtual int Id { get; set; }
    public virtual string Code { get; set; }
    public static RegisterService GetRegisterService()
    {
        return _registerService;
    }
}