
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data;

public class MovieShopDbContext: DbContext
{
    public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options):base(options)
    {
        
    }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Cast> Casts { get; set; }
    public DbSet<MovieCast> MovieCasts { get; set; }
    public DbSet<MovieGenre> MovieGenres { get; set; }
    public DbSet<Favorite> Favorites { get; set; }
    public DbSet<Purchases> Purchases { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Trailer> Trailers { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MovieGenre>(ConfigureMovieGenre);
        modelBuilder.Entity<MovieCast>(ConfigureMovieCast);
        modelBuilder.Entity<Favorite>(ConfigureFavorite);
        modelBuilder.Entity<UserRole>(ConfigureUserRole);
        modelBuilder.Entity<Review>(ConfigureReview);
        modelBuilder.Entity<Purchases>(ConfigurePurchases);
        modelBuilder.Entity<Trailer>(ConfigureTrailer);
    }

    public void ConfigureTrailer(EntityTypeBuilder<Trailer> builder)
    {
        builder.HasOne(t => t.Movie).WithMany(m => m.Trailers).HasForeignKey(t => t.MovieId);
    }
    public void ConfigureMovieGenre(EntityTypeBuilder<MovieGenre> builder)
    {
        builder.HasKey(x => new { x.GenreId, x.MovieId });
        builder.HasOne(m=>m.Genre).WithMany(m=>m.MovieGenres).HasForeignKey(m => m.GenreId);
        builder.HasOne(m=>m.Movie).WithMany(m=>m.MovieGenres).HasForeignKey(m => m.MovieId);
    }
    public void ConfigureMovieCast(EntityTypeBuilder<MovieCast> builder)
    {
        builder.HasKey(x=> new { x.MovieId, x.CastId, x.Character });
        builder.HasOne(m=>m.Cast).WithMany(m => m.MovieCasts).HasForeignKey(m => m.CastId);
        builder.HasOne(m=>m.Movie).WithMany(m => m.MovieCasts).HasForeignKey(m => m.MovieId);
    }

    public void ConfigureFavorite(EntityTypeBuilder<Favorite> builder)
    {
        builder.HasKey(x => new { x.MovieId, x.UserId });
        builder.HasOne(m=>m.Movie).WithMany(m=>m.Favorites).HasForeignKey(m => m.MovieId);
        builder.HasOne(m=>m.User).WithMany(m=>m.Favorites).HasForeignKey(m => m.UserId);
    }
    public void ConfigureUserRole(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasKey(x => new { x.RoleId, x.UserId });
        builder.HasOne(m=>m.Role).WithMany(m => m.UserRoles).HasForeignKey(m => m.RoleId);
        builder.HasOne(m=>m.User).WithMany(m => m.UserRoles).HasForeignKey(m => m.UserId);
    }   
    public void ConfigureReview(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(x => new { x.MovieId, x.UserId });
        builder.HasOne(m=>m.Movie).WithMany(m=>m.Reviews).HasForeignKey(m => m.MovieId);
        builder.HasOne(m=>m.User).WithMany(m => m.Reviews).HasForeignKey(m => m.UserId);
        
        builder.Property(m=>m.CreatedDate).HasColumnType("Datetime2").IsRequired();
        builder.Property(m=>m.Rating).HasColumnType("decimal(3,2)").IsRequired();
        builder.Property(m=>m.ReviewText).HasColumnType("nvarchar(max)").IsRequired();
    }

    public void ConfigurePurchases(EntityTypeBuilder<Purchases> builder)
    {
        builder.HasKey(x => new { x.MovieId, x.UserId });
        builder.HasOne(m=>m.Movie).WithMany(m=>m.Purchases).HasForeignKey(m => m.MovieId);
        builder.HasOne(m=>m.User).WithMany(m => m.Purchases).HasForeignKey(m => m.UserId);
        
        builder.Property(m=>m.PurchaseDateTime).HasColumnType("datetime2").IsRequired();
        builder.Property(m=>m.PurchaseNumber).HasColumnType("uniqueidentifier").IsRequired();
        builder.Property(m=>m.TotalPrice).HasColumnType("decimal(5,2)").IsRequired();
    }   
    
}