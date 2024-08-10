using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using PersonalHub.Domain.User.ValueObjects;

namespace PersonalHub.Domain.User.Entities;

public class ApiUser : IdentityUser
{
    public PersonalInfo? Information { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [DataType(DataType.DateTime)]
    public DateTime? UpdatedAt { get; set; }
}
