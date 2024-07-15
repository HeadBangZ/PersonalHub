using PersonalHub.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalHub.Application.DTOs
{
    public record ApiUserDto(
        string Id,
        string FirstName,
        string LastName,
        string Email,
        DateTime CreatedAt,
        DateTime? UpdatedAt
    );

    public record CreateApiUserDto(
        [Required][StringLength(50)] string FirstName,
        [Required][StringLength(75)] string LastName,
        [Required][EmailAddress] string Email,
        [Required][DataType(DataType.Password)] string Password
    );

    public record LoginApiUserDto(
        [Required] string Email,
        [Required] string Password
    );
}
