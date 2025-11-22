using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CastRepository:BaseRepository<Cast>,ICastRepository
{
    public CastRepository(MovieShopDbContext context) : base(context)
    {
    }
    
    public Cast GetByID(int id)
    {
        return _context.Casts
            .Include(c => c.MovieCasts)
            .ThenInclude(mc => mc.Movie)    // load Movies belonging to this Cast
            .FirstOrDefault(c => c.Id == id);
    }
}