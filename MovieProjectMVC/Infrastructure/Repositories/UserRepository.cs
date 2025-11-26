using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class UserRepository:BaseRepository<User>,IUserRepository
{
    public UserRepository(MovieShopDbContext context) : base(context)
    {
    }

    public User? GetUser(string userEmail)
    {
        return _context.Users.FirstOrDefault(m=>m.Email == userEmail);
    }
}