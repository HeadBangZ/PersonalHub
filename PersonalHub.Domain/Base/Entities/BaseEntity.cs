using System.ComponentModel.DataAnnotations;
namespace PersonalHub.Domain.Base.Entities;

public abstract class BaseEntity
{
    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [DataType(DataType.DateTime)]
    public DateTime? UpdatedAt { get; set; }
}
