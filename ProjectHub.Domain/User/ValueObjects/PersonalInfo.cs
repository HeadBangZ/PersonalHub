using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectHub.Domain.User.ValueObjects;

public class PersonalInfo
{
    [Column("FirstName")]
    [MaxLength(50)]
    public required string FirstName { get; set; } = default!;

    [Column("LastName")]
    [MaxLength(75)]
    public required string LastName { get; set; } = default!;

    [Column("DateOfBirth")]
    public DateTime? DateOfBirth { get; set; }

    [Column("Nationality")]
    public string? Nationality { get; set; }
}
