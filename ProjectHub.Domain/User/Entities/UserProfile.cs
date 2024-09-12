using ProjectHub.Domain.Common.Models;
using ProjectHub.Domain.User.ValueObjects;

namespace ProjectHub.Domain.User.Entities;

public class UserProfile : BaseEntity
{
    public UserProfileId Id { get; private init; } = UserProfileId.NewEntityId();

    public PersonalInfo? Information { get; set; }

    public Address? AddressInfo { get; set; }

    public string ApiUserId { get; set; }
    public ApiUser ApiUser { get; set; }
}
