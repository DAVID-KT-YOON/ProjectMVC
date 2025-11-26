using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using Infrastructure.Helpers;

namespace Infrastructure.Services;

public class UserService:IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository =  userRepository;
    }
    public User? ValidateUser(string modelEmail, string modelPassword, out string errorMessage)
    {
        errorMessage = "";
        var user = _userRepository.GetUser(modelEmail);
        if (user == null)
        {
            errorMessage = "User not found";
            return null;
        }

        bool isCorrect = PasswordHasher.Verify(modelPassword, user.HashedPassword, user.Salt);
        if (!isCorrect)
        {
            errorMessage = "Invalid password";
            return null;
        }
        return user;
    }
}