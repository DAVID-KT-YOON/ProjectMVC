namespace ApplicationCore.Contracts.Services;

public interface IUserService
{
    bool ValidateUser(string modelEmail, string modelPassword,ref string errorMessage);
}