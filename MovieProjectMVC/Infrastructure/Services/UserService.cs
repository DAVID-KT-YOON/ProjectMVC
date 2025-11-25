using ApplicationCore.Contracts.Services;

namespace Infrastructure.Services;

public class UserService:IUserService
{
    public bool ValidateUser(string modelEmail, string modelPassword, ref string errorMessage)
    {
        throw new NotImplementedException();
    }
}