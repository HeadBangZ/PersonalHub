using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalHub.Domain.User.ValueObjects;

public class PersonalInfo
{
    [Column("FirstName")]
    public required string FirstName { get; set; } = default!;

    [Column("LastName")]
    public required string LastName { get; set; } = default!;

    [Column("DateOfBirth")]
    public DateTime? DateOfBirth { get; set; }

    [Column("Nationality")]
    public string? Nationality { get; set; }
}
