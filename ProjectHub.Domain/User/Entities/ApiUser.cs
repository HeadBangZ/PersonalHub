using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using ProjectHub.Domain.User.ValueObjects;

namespace ProjectHub.Domain.User.Entities;

public sealed class ApiUser : IdentityUser
{
    public UserProfileId UserProfileId { get; set; }

    public UserProfile UserProfile { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [DataType(DataType.DateTime)]
    public DateTime? UpdatedAt { get; set; }
}
