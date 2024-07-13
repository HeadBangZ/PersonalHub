using PersonalHub.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace PersonalHub.Domain.Entities
{
    public class User : IdentityUser
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(75)]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM-yyyy}")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM-yyyy}")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
