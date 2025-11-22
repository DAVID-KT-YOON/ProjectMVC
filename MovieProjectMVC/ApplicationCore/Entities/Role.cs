using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;

public class Role
{
    [Key]
    public int  Id { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(20)")]
    public string Name { get; set; }
    
    public ICollection<UserRole>? UserRoles { get; set; }
}