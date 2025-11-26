
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Helpers;

public static class PasswordHasher
{
    public static string HashPassword(string password, string salt)
    {
        var sha = SHA256.Create();
        var combined = password + salt;
        var bytes = Encoding.UTF8.GetBytes(combined);
        var hash = sha.ComputeHash(bytes);
        return Convert.ToHexString(hash);
    }

    public static bool Verify(string password, string storedHash, string salt)
    {
        var hash = HashPassword(password, salt);
        return hash.Equals(storedHash, StringComparison.OrdinalIgnoreCase);
    }

    public static string GenerateSalt()
    {
        var random = RandomNumberGenerator.GetBytes(16);
        return Convert.ToHexString(random);
    }
}
