using System.ComponentModel.DataAnnotations;
namespace PersonalHub.Domain.Common.Models;

public abstract class BaseEntity
{
    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [DataType(DataType.DateTime)]
    public DateTime? ModifiedAt { get; set; }
}
