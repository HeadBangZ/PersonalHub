using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace PersonalHub.Domain.Entities;

public class ApiUser : IdentityUser
{
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = default!;

    [Required]
    [StringLength(75)]
    public string LastName { get; set; } = default!;

    [Required]
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:dd/MM-yyyy}")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:dd/MM-yyyy}")]
    public DateTime? UpdatedAt { get; set; }
}
