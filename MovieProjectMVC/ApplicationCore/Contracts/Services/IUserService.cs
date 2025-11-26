using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Services;

public interface IUserService
{
    User? ValidateUser(string modelEmail, string modelPassword, out string errorMessage);
}