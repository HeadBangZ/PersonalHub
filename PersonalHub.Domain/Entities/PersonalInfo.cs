using System.ComponentModel.DataAnnotations;

namespace PersonalHub.Domain.Entities;

public class PersonalInfo
{
    public required string FirstName { get; set; } = default!;

    public required string LastName { get; set; } = default!;

    public DateTime? DateOfBirth { get; set; }

    public string? Nationality { get; set; }
}
