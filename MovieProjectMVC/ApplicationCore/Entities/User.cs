using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;

public class User
{
    [Key]
    public int Id { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(128)")]
    public string FirstName { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(128)")]
    public string LastName { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(256)")]
    public string Email { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(1024)")]
    public string HashedPassword { get; set; }
    [Column(TypeName = "bit")]
    public bool? IsLocked { get; set; }
    [Column(TypeName = "nvarchar(16)")]
    public string? PhoneNumber { get; set; }
    public string? ProfilePictureUrl { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(1024)")]
    public string Salt { get; set; }
    
    public ICollection<UserRole>? UserRoles { get; set; }
    public ICollection<Favorite>? Favorites { get; set; }
    public ICollection<Review>? Reviews { get; set; }
    public ICollection<Purchases>? Purchases { get; set; }
}